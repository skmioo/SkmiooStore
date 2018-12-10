#define SYNC_SEND_MESSAGE

using UnityEngine;
using System.Collections;
using System;
using System.Threading;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.IO;
using com.mile.common.message;
/**********************************************
* @说明: Socket客户端
* @作者：ZHM --- 海鸣不骑猪 
* @版本号：V1.00
**********************************************/
public class SocketObject : BaseNetObject
{
    /// <summary>
    /// 连接
    /// </summary>
    private Socket _Socket = null;

    /// <summary>
    ///  是否包含消息包头
    /// </summary> 
    private bool _IsHeader = true;

    /// <summary>
    /// ip 地址
    /// </summary>
    private string _IP = null; 
    /// <summary>
    /// 端口
    /// </summary>
    private int _Port = 0; 
    /// <summary>
    /// // 重连的次数
    /// </summary>
    private int _ReconnectCount = 0;
    /// <summary>
    ///  返回数据处理线程
    /// </summary>
    private Thread _Thread = null;
     
    /// <summary>
    ///  超时对象
    /// </summary> 
    private static ManualResetEvent _TimeoutObject = new ManualResetEvent(false);

    private IPEndPoint _endPoint;
    public SocketObject(ServerDataType type, string ip, int port, bool hasHeader = true)
    {
        ServerMsgType = type;
        _IP = ip;
        _Port = port; 
        _endPoint = new IPEndPoint(IPAddress.Parse(_IP), _Port);
        _ReconnectCount = 0;
        _Thread = null;
        CurrNetState = NetState.NotConnect;

        ReadBuff = new byte[ReceiveLen];
        TempBuff = new byte[ReceiveLen];
        TempPos = 0;
        _IsHeader = hasHeader; 
    }

    /** 创建Socket链接 */
    public override void CreateConnect()
    {  
        _Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        _Socket.SendBufferSize = ReceiveLen; 
        // 异步链接服务器
        _Socket.BeginConnect(_endPoint, ConnectCallback, _Socket);
        _TimeoutObject.Reset();
        if (_TimeoutObject.WaitOne(NetworkManager.TimeoutMiliSecond, false))
        {
            if (CurrNetState == NetState.Connected)
            {
               Debug.Log("Success Connect: " + _IP + ":" + _Port);
			   NetworkManager.WaitCheckNetTimer = 2;
			   GameNet.Instance.OnInit();
                //心跳
               NetMsgManager.Instance.SendMessage(MessageID.CGheartbeatClientSend);
               return;
            }
        }else{
            CurrNetState = NetState.TimeOut;
            Debug.Log("TimeOut Connect: " + _IP + ":" + _Port);
			
        }

    }

    /** 异步链接回调 */
    private void ConnectCallback(IAsyncResult async)
    {
        try
        {
            Socket client = (Socket)async.AsyncState;
            // 网络链接上状态初始化
            if (client.Connected)
            {
                client.EndConnect(async);
                CurrNetState = NetState.Connected;
                _ReconnectCount = 0;
                CreateThread();
				Debug.Log("ConnectCallback Connected！");
            }
            else
            {
                CurrNetState = NetState.Disconnect; 
            }
        }
        catch (Exception e)
        {
            // 网络链接异常
            CurrNetState = NetState.Exception;
            Debug.LogError("Socket Connect Exception : " + e.ToString());
        }
        finally
        {
            _TimeoutObject.Set();
        } 
    } 
    ///网络线程处理=============================================================================
    /// <summary>
    ///   /** 创建客户端线程并启动 */
    /// </summary>
    private void CreateThread()
    {
        CloseThread();
        _Thread = new Thread(new ThreadStart(ReceiveSocketThread));
        _Thread.IsBackground = true; 
        _Thread.Start();
    } 
    /// <summary>
    /// /** 关闭接受数据线程 */
    /// </summary>
    private void CloseThread()
    {
        if (_Thread != null && _Thread.IsAlive)
        {
            // 清空缓冲区
            Array.Clear(TempBuff, 0, ReceiveLen);
            Array.Clear(ReadBuff, 0, ReceiveLen);
            TempPos = 0;
            _Thread.Abort();
            _Thread = null;
        }
    }

    /** 读取Socket收到数据，新开线程 */
    private void ReceiveSocketThread()
    {
        while (true)
        {
            if (!NetworkManager.NetEnabled)
            {
                Thread.Sleep(30);
                return;
            }
            //try
            //{
                if (null == _Socket || !_Socket.Connected)
                {
                return;
                }
                // 清空临时缓冲区
                Array.Clear(ReadBuff, 0, ReceiveLen);
                int length = _Socket.Receive(ReadBuff);
                // 接受数据长度
                if (length > 0)
                {
                    //Debug.Log("ReceiveSocketThread");
                    Buffer.BlockCopy(ReadBuff, 0, TempBuff, TempPos, length);
                    // 更新标识
                    TempPos += length;
                    // 试图解析包
                    ParseServerPacket();
                }  
            //}
            //catch (Exception e)
            //{
            //    if (!(e is ThreadAbortException))
            //    {
            //       Debug.LogError("ReceiveSocket Exception: " + e.ToString() + ". Thread Id = " + Thread.CurrentThread.ManagedThreadId);
            //    }
            //}
            Thread.Sleep(10);
        }
    }
    //-=============================================================================================================  
    /// <summary>
    /// /** 客户端网络心跳 */ 主线程处理 
    /// </summary>
    public override void Update()
    {
        //try{
            if(CurrNetState != NetState.Connected)
            {
                return;
            }
            // 客户端断线检测
            if (_Socket == null || ! _Socket.Connected)
            {
                CurrNetState = NetState.Disconnect;
                return;
            }
            // 消息包发送
            if (SendQueue.Count > 0)
            {
                SendPacket();
            }
            // 处理返回消息包 目前已经改到子线程中进行处理了
            //if (ReceiveQueue.Count > 0)
            //{
            //    ProcessReceivePacket();
            //}
         //}catch (Exception e){
         //   Debug.LogError("Socket Update Heart Exception: " + e.Message);
        //}
    }

    /** 将消息队列中包发送出去 */
    private void SendPacket()
    {
        try
        {
            // 发送当前队列所有消息包
            while (SendQueue.Count > 0)
            {
                byte[] msg = SendQueue.Dequeue();
				
				#region SS
				//Packet packet = new Packet(ServerDataType.protobuf, true);
				//packet.Decode(msg);
				//Debug.Log("packed ID = " + packet.Header.PacketID);
				//if (packet.Header.PacketID == 2002 || packet.Header.PacketID == 2004)
				//{
				//	GameLog.LogCtrl.Info("{0} time {1}", packet.Header.PacketID, FacadeGlobal.TimerCtrl.GetTimeStamp());
				//}

				//if (packet.Header.PacketID == 307)
				//{
				//	GameLog.LogCtrl.Info("{0} time {1}", packet.Header.PacketID, FacadeGlobal.TimerCtrl.GetTimeStamp());
				//}
				#endregion
				 
				_Socket.BeginSend(msg, 0, msg.Length, SocketFlags.None, SendCallback, _Socket);
				//_Socket.Send(msg);
			
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Send Message Failed: " + e.ToString());
        }
    }

    /// <summary>
    ///  /** 异步发送消息回调 */
    /// </summary>
    /// <param name="asyncSend"></param>
    private void SendCallback(IAsyncResult asyncSend)
    {
        try
        {
            Socket client = (Socket)asyncSend.AsyncState;
            int bytesSent = client.EndSend(asyncSend);
        }
        catch (Exception e)
        {
            Debug.LogError("Send Message Failed: " + e.ToString());
        }
    } 

    //=================================================================================================================
    /** 断开游戏链接 */
    public override void Disconnect()
    {
        try{ 
            CurrNetState = NetState.NotConnect;
            CloseThread();
            if (_Socket == null || !_Socket.Connected)
            {
                _Socket = null;
                return;
            }
            _Socket.Shutdown(SocketShutdown.Both);
            _Socket.Close();
            _Socket = null;
        }catch (Exception e)
        {
           Debug.LogError("SocketObject Closed Exception: " + e.Message);
        }
    }

    /// <summary>
    /// /** 是否链接成功 */
    /// </summary>
    /// <returns></returns>
    public override bool IsConnectSuccess()
    {
        if (CurrNetState == NetState.Connected)
        {
            return true;
        }
        return false;
    }

	public void ClearReconnectCount()
	{
		_ReconnectCount = 0;
	}
    /// <summary>
    /// /** 断线重连 */
    /// </summary>
    public override void Reconnect()
    {
        Disconnect();
        // 记录客户端链接次数
        _ReconnectCount++;
        if (_ReconnectCount >= NetworkManager.ReConnectLimit)	//10秒连接不上
        {
            _ReconnectCount = 0;
			CreateConnect();
        }else{
            Debug.Log("Reconnect To Server. Repeat time:" + _ReconnectCount );
            CreateConnect();
        }
    }

    //---------------------------------------------------------------------------------------------------
    /** 添加消息到发送队列 */
    public override void SendMessage(int msgId, PacketDistributed msg)
    {
        //try
        //{
            if (!NetworkManager.NetEnabled)
            {
                return;
            }
            SendQueue.Enqueue(Packet.Encode(msgId, msg, ServerMsgType, _IsHeader));
        //}
        //catch (Exception e)
        //{
        //   Debug.LogError("Socket Send Message Exception " + e.Message);
        //}
    }

	public override void SendMessage(int msgID, byte[] msg)
	{
		if (msg == null)
			throw new Exception("msgData can not be null");
		if (!NetworkManager.NetEnabled)
			return;
		SendQueue.Enqueue(Packet.Encode(msgID, msg, _IsHeader));
	}
}
