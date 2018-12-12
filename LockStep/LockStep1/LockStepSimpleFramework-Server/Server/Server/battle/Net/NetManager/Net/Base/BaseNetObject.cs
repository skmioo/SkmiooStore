using com.mile.common.message;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using UnityEngine;
/**********************************************
* @说明:/// server 传输的数据类型
* @作者：ZHM --- 海鸣不骑猪 
* @版本号：V1.00
**********************************************/ 
public enum ServerDataType
{
    stream,
    str,
    json,
    protobuf
}

/// <summary>
/// 当前网络状态
/// </summary>
public enum NetState
{
    /// <summary>
    ///  未链接网络
    /// </summary> 
    NotConnect,
    /// <summary>
    /// 链接上
    /// </summary> 
    Connected,
    /// <summary>
    ///  断开链接
    /// </summary> 
    Disconnect,
    /// <summary>
    ///  网络不稳定
    /// </summary> 
    Unsteadiness,
    /// <summary>
    ///  网络异常
    /// </summary> 
    Exception,
    /// <summary>
    ///  链接超时
    /// </summary> 
    TimeOut,
    /// <summary>
    ///  账号异地登陆或服务器异常
    /// </summary> 
    OtherLogOrSvrException,
} 
/**********************************************
* @说明:网络连接的base控制
* @作者：ZHM --- 海鸣不骑猪 
* @版本号：V1.00
**********************************************/ 
public abstract class BaseNetObject
{
    /// <summary>
    /// 当前网络连接状态
    /// </summary>
    public NetState CurrNetState = NetState.NotConnect;
    /// <summary>
    /// 每次最多处理包个数 
    /// </summary> 
    public const int PROCESS_MAX_COUNT = 500;

    /// <summary>
    ///  多线程锁
    /// </summary> 
    protected object mLockObj = new object(); 
    /// <summary>
    ///  消息数据类型
    /// </summary> 
    protected ServerDataType ServerMsgType; 
    /// <summary>
    ///  是否允许立刻发送消息
    /// </summary> 
    protected bool IsReadySend;  
    /// <summary>
    ///  缓冲区大小
    /// </summary> 
    protected int ReceiveLen = 1024 * 1024;  
    /// <summary>
    ///  读取数据Buff
    /// </summary> 
    protected byte[] ReadBuff;
    /// <summary>
    ///  临时数据Buff
    /// </summary> 
    protected byte[] TempBuff; 
    /// <summary>
    ///  临时读取数据位置
    /// </summary> 
    protected int TempPos = 0;   
    /// <summary>
    /// 发送的消息队列 
    /// </summary> 
    protected Queue<byte[]> SendQueue = new Queue<byte[]>();
    /// <summary>
    ///  返回消息队列
    /// </summary> 
    protected Queue<Packet> ReceiveQueue = new Queue<Packet>(); 
    /// <summary>
    ///  发送消息
    /// </summary>
    /// <param name="msgID"></param>
    /// <param name="msg"></param>  
    public abstract void SendMessage(int msgID, PacketDistributed msg);
	public abstract void SendMessage(int msgID, byte[] msg);
    /// <summary>
    ///  网络心跳
    /// </summary> 
    public abstract void Update();
    /// <summary>
    /// 断开链接
    /// </summary> 
	public abstract void Disconnect();
    /// <summary>
    /// 重新链接
    /// </summary> 
    public abstract void Reconnect();
    /// <summary>
    ///  是否链接成功
    /// </summary>
    /// <returns></returns>
    public abstract bool IsConnectSuccess();
    public abstract void CreateConnect();
    /// <summary>
    /// 处理缓冲区中的数据包
    /// </summary>
    protected void ParseServerPacket()
    {
        // 包头长度
        int headerSize = PacketHeader.HeaderLen;
        int bodySize; 
        while (TempPos >= headerSize)
        {
            //try
            //{
            // 获取到消息包体长度
            // bodySize = IPAddress.HostToNetworkOrder(BitConverter.ToInt32(TempBuff, 0));
            bodySize = BitConverter.ToInt32(TempBuff, 0);
            bodySize = headerSize + bodySize;
                // 检查是否满足一个包长度
                if (TempPos < bodySize)
                {
                    Debug.Log("headSize " +headerSize + " TempPos "+TempPos + " bodySize " + bodySize);
                    return;
                }
                
                EnqueuePacket(bodySize); 

				//if (packet.Header.PacketID == 307)
				//{
				//	GameLog.LogCtrl.Info("{0} time {1}", packet.Header.PacketID, FacadeGlobal.TimerCtrl.GetTimeStamp());
				//}
            //}catch (Exception e) {
            //    Debug.LogError("Parse Packet Error :" + e.Message);
            //    return;
            //} 
        }  
    }
    
    /// <summary>
    /// 将包压入队列
    /// </summary>
    /// <param name="packetSize"></param>
    private void EnqueuePacket(int packetSize)
    { 
        Packet packet = new Packet(ServerMsgType, true);
        packet.Decode(TempBuff);

		#region LogCtrl
		//if (packet.Header.PacketID == 2003 || packet.Header.PacketID == 2005)
		//{
		//	Debug.Log("EnqueuePacket ====" + (packet.Header.PacketID.ToString() + "\t" + FacadeGlobal.TimerCtrl.GetTimeStamp().ToString()));
		//}
		#endregion

        // 接收缓冲区偏移处理
        for (int i = 0; i < (TempPos - packetSize); i++)
        {
            TempBuff[i] = TempBuff[packetSize + i];
        }
        // 偏移缓冲区标识
        TempPos -= packetSize; 

        if (packet.Header.RetCode == 0)
        {
             NetworkManager.ExecHandle(packet);
            ///加入到分发队列
             //lock (mLockObj)
    //        { 
                     //ReceiveQueue.Enqueue(packet);
    //        }
        } 
    }

    /// <summary>
    ///子线程处理返回数据
    /// </summary>
    //protected void ProcessReceivePacket()
    //{
    //    int tmpCount = 0;
    //    Packet receivePacket = null;
    //    while (ReceiveQueue.Count > 0)
    //    { 
    //        lock (mLockObj)
    //        { 
    //            receivePacket =  ReceiveQueue.Dequeue();
    //        }
    //        if (receivePacket != null)
    //        { 
    //            NetworkManager.ExecHandle(receivePacket);
    //        }
    //        tmpCount++;
    //        // 大于一次包最多处理数，返回等下一次处理
    //        if (tmpCount > PROCESS_MAX_COUNT)
    //        {
    //            return;
    //        }
    //    }

 
}
