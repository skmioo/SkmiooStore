using com.mile.common.message;
using System;
/**********************************************
* @说明: 游戏中的网络操控
* @作者：ZHM --- 海鸣不骑猪 
* @版本号：V1.00
**********************************************/
public class GameNet : CSharpSingletion<GameNet> 
{
    /// <summary>
    /// 网络ip    "10.12.28.238";安雷
    /// </summary>"10.12.28.224";燕姐
    /// "10.12.16.60";钟文江
    public string IP = "10.12.28.238";

    /// <summary>
    /// 网络port
    /// </summary>
    public  int PORT = 8201;

    /// <summary>
    /// game服务器id
    /// </summary>
    public int GameServerId;

    /// <summary>
    /// 网络传输的类型
    /// </summary>
    public const ServerDataType CurrServerDataType = ServerDataType.protobuf;

    /// <summary>
    /// 网络连接的类型
    /// </summary>
    public const ConnnectType connnectType = ConnnectType.SocketObject;

    /// <summary>
    /// 网络协议是否有头信息
    /// </summary>
    public const bool hasHeader = true;
     

    /// <summary>
    /// 网络连接
    /// </summary>
    private NetworkManager _networkManager = NetworkManager.Instance;

    /// <summary>
    /// 当前连接的server 类型
    /// </summary>
    public ServerType CurrServerType
    {
        get
        {
            return NetworkManager.ServerType;   
        }
    }

    /// <summary>
    /// 是否已经初始化完成
    /// </summary>
    public bool IsInitOk
    {
        get
        { 
            return _networkManager.IsInitOk;
        } 
    } 

    /// <summary>
    /// 初始化完成
    /// </summary>
    public void OnInit()
    {
        _networkManager.OnInit();  
    }
   
    /// <summary>
    /// 初始化登录服务器连接
    /// </summary>
    public void CreateLoginConn(string ip = "", int port = -1)
    { 
        if (ip == "")
        {
            ip = IP;
            port = PORT;
        }
        IP = ip;
        PORT = port;
        NetworkManager.CreateConnnect(CurrServerDataType,IP,PORT,connnectType,hasHeader);
        NetworkManager.ServerType = ServerType.login;
    }
     
    /// <summary>
    /// 初始化游戏game服务器连接
    /// </summary>
    public void CreateGameConn(string ip,int port)
    {
        IP = ip;
        PORT = port; 
        NetworkManager.CreateConnnect(CurrServerDataType, IP, PORT, connnectType, hasHeader);
        NetworkManager.ServerType = ServerType.game;  
    }

    /// <summary>
    /// 登录登录服务器
    /// </summary>
    public void LoginLoginServer(string snsid, string ip = "", int port = -1)
    {  
        CreateLoginConn(ip, port);  
        //LoginDataProxy data = Game.GetDataProxy<LoginDataProxy>();
        //data.SnsId = snsid; 
        //发送登录数据
        //CLLogin cLLogin = new CLLogin();
        //cLLogin.PfUid = snsid;
        //SendMsg(cLLogin); 
    } 

    /// <summary>
    /// 登录game服务器
    /// </summary>
    public void LoginGameServer(string ip,int port,int gameServerId)
    { 
        CreateGameConn(ip, port);
        GameServerId = gameServerId;
        //发送登录game 服务器 
        //LoginDataProxy loginData = Game.GetData<LoginDataProxy>();
        //CGLoginGameServer cgs = new CGLoginGameServer();
		//int val = UnityEngine.Random.Range(0, 10000);
		//cgs.Uname = val.ToString();
	
		//cgs.Pwd = "QW";
        //cgs.PlayerId = loginData.CurrPlayerId;
        //cgs.VilidCode = loginData.VilidCode;
        //cgs.GameServerId = gameServerId;
        //SendMsg(cgs); 
    }  

    /// <summary>
    ///注册net 事件
    /// </summary>
    public void RegisterHandle(MessageID key, Action<Packet> handler)
    {
        NetworkManager.RegisterHandle(key,handler);
    }
    /// <summary>
    ///移除注册net 事件
    /// </summary>
    public void RemoveHandle(MessageID key)
    {
        NetworkManager.RemoveHandle(key);
    }

    /// <summary>
    ///移除注册net 事件
    /// </summary>
    public void SendMsg(PacketDistributed msg)
    {
        NetworkManager.SendToGameServer(msg);
    }

	public void SendMsg(int msgID, byte[] msg)
	{
		NetworkManager.SendToGameServer(msgID,msg);
	}

}
