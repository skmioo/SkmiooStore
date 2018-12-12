using System.Net;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using com.mile.common.message;
using System.Reflection;
///// <summary>
///// 当前连接的 server 的类型
///// </summary>
public enum ServerType
{
    none,
    login,
    game,
}

/// <summary>
/// 当前连接的类型
/// </summary>
public enum ConnnectType
{
   SocketObject,
    HttpObject ,
}
/**********************************************
* @说明: NetworkManager
* @作者：ZHM --- 海鸣不骑猪 
* @版本号：V1.00
**********************************************/
public sealed partial class NetworkManager
{
    /// <summary>
    /// 连接超时时间
    /// </summary>
    public static int TimeoutMiliSecond = 850;
    /// <summary>
    /// 两秒检查一次连接状态
    /// </summary>
    public static float WaitCheckNetTimer = 2;
	/// <summary>
	///  消息是否可以继续发送
	/// </summary> 
	public static bool NetEnabled = true;
    /// <summary>
    ///  重连次数限制
    /// </summary> 
    public static int ReConnectLimit = 5; 

    ///// <summary>
    /////网络连接上的服务器类型（登录服务器、游戏服务器）
    ///// </summary>
    public static ServerType ServerType = ServerType.none; 

    //============================================================================================
    /// <summary>
    ///  游戏网络连接
    /// </summary> 
    private static BaseNetObject _NetObject = null;

    /// <summary>
    ///  游戏网络连接类型
    /// </summary> 
    private static ConnnectType CurrConnnectType = ConnnectType.SocketObject; 

    /// <summary>
    /// 当前网络状态
    /// </summary>
    public static NetState CurrNetState
    {
        get
        {
            if (_NetObject == null)
            {
                return NetState.NotConnect;
            } 
            return _NetObject.CurrNetState;
        }
    }

    /// <summary>
    /// 重新链接
    /// </summary>
    public static void Reconnnect()
    {
        if (_NetObject != null)
        {
            _NetObject.Reconnect();
            return ;
        }
        throw new Exception("没有可以进行重新连接的 连接");
    }
    
    /// <summary>
    /// 销毁网络连接控制器
    /// </summary>
    public static void DestroyConnnect()
    {
        if (_NetObject != null)
        {
            _NetObject.Disconnect();
        } 
        _NetObject = null; 
    }

    /// <summary>
    /// 销毁网络连接控制器
    /// </summary>
    public static void CreateConnnect(ServerDataType type, string ip, int port, ConnnectType connnectType = ConnnectType.SocketObject, bool hasHeader = true)
    {   
        DestroyConnnect(); 
        CurrConnnectType = connnectType;
        _NetObject = Activator.CreateInstance(Type.GetType(connnectType + ""), type, ip, port, hasHeader) as BaseNetObject; 
        _NetObject.CreateConnect();
    }

    ///============================================================================================
    /// <summary>
    /// 减少反射次数
    /// </summary>
    private static Dictionary<string, int> _messageIdMap = new Dictionary<string, int>(); 
    public static Type MessageIDType = typeof(MessageID);
    /** 发送消息 */ 
    public static void SendToGameServer(PacketDistributed msg)
    {
        if (null != _NetObject)
        {
            string msgName = msg.GetType().Name;
            if (!_messageIdMap.ContainsKey(msgName))
            {
                MessageID messageId = (MessageID)Enum.Parse(MessageIDType, msgName);
                Console.WriteLine("Send : " + messageId);
                _messageIdMap[msgName] = (int)messageId;
            }
            _NetObject.SendMessage(_messageIdMap[msgName], msg);
        }
    }

	public static void SendToGameServer(int msgID, byte[] msg)
	{
		if (null != _NetObject)
		{
			_NetObject.SendMessage(msgID,msg);
		}
	}
    ///事件处理=================================================================================================
    ///  /// <summary>
    /// 减少反射次数
    /// </summary> 
    private static object[] _arges = { null }; 
    /// <summary>
    ///   子线程调用执行
    /// </summary>
    /// <param name="packet"></param>
    public static void ExecHandle(Packet packet)
    { 
            if (!packet.IsHeader)
            {
                Console.WriteLine("Receive Packet Without Header");
                return;
            }
            int opcode = packet.Header.PacketID;
            //op处理=================================  
            Type type = Type.GetType("OP_" + Enum.GetName(MessageIDType, opcode));
            if (type == null)
            {
                Console.WriteLine("没有添加 :" + "OP_" + Enum.GetName(MessageIDType, opcode) + "类");
                return;
            } 
            try
			{
				MethodInfo methodInfo = null;
				methodInfo = type.GetMethod("Execute");
				if (methodInfo == null)
				{
					string exceptionStr = "协议的op 中需要有 Execute 静态方法啊" + Enum.GetName(MessageIDType, opcode).ToString();
                    Console.WriteLine(exceptionStr);
                    return;
				}
				_arges[0] = packet.CurrObject;
				methodInfo.Invoke(null, _arges);
			}
            catch (Exception e)
            {
                Console.WriteLine("执行的数据出现问题 :" + "OP_" + Enum.GetName(MessageIDType, opcode) + " " + e.Message);
                return;
            } 
    }
    
    /// <summary>
    ///  消息包回调 注册
    /// </summary> 
    private static IDictionary<int, Action<Packet>> _backHandle = new Dictionary<int, Action<Packet>>();
    // 注册Handle
    public static void RegisterHandle(MessageID key, Action<Packet> handler)
    {
        int msgKey = (int)key; 
        if (_backHandle.ContainsKey(msgKey))
        {
            Console.WriteLine("NetworkManager: Exist same handler (OPCODE=" + msgKey + ") already!");
            return;
        }
        _backHandle.Add(msgKey, handler);
    }

    /// <summary>
    /// 移除事件
    /// </summary>
    /// <param name="key"></param>
    /// <param name="handler"></param>
    public static void RemoveHandle(MessageID key)
    {
        int msgKey = (int)key;

        if (_backHandle.ContainsKey(msgKey))
        {
            _backHandle.Remove(msgKey);
            return;
        }
    }

    private static NetworkManager _Instance;

    public static NetworkManager Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = new NetworkManager();
            }
            return _Instance;
        }
    }
     
}
