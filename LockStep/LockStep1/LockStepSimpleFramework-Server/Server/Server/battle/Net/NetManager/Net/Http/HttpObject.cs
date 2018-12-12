using UnityEngine;
using System;
using System.Net;
using System.Collections;
using System.Collections.Generic;
/**********************************************
* @说明: http
* @作者：ZHM --- 海鸣不骑猪 
* @版本号：V1.00
**********************************************/ 
public class HttpObject : BaseNetObject
{
    private HttpWebClient mWebClient;

    private Uri mUrl;

    // 重连次数
    private int mReconnectCount;
	
	// 是否包含消息包头
	private bool mHasHeader = true;

    public static HttpObject CreateSingleObject(ServerDataType type, bool hasHeader, string url)
    {
        return new HttpObject(type, hasHeader, url);
    }

    public HttpObject(ServerDataType type, bool hasHeader, string url)
    {
        ServerMsgType = type;
		mHasHeader = hasHeader;

        mWebClient = new HttpWebClient();
        mWebClient.UploadDataCompleted += httpWebClient_UploadDataCompleted;

        mUrl = new Uri(url);
        IsReadySend = true;
        mReconnectCount = 0;
    }
    public override void CreateConnect()
    {
    
    }
    /// <summary>
    /// 创建消息包数据结构，并压入等待发送的消息队列中
    /// </summary>
    /// <param name="msgID">消息包协议号</param>
    /// <param name="msgData">消息对象</param>
    public override void SendMessage(int msgID, PacketDistributed msgData)
    {
        try
        {
            if (msgData == null)
            {
                throw new Exception("msgData can not be null");
            } 
            SendQueue.Enqueue(Packet.Encode(msgID, msgData, ServerMsgType, mHasHeader));
        }
        catch (Exception ex)
        {
            Debug.LogError("HttpObject SendMessage Exception: " + ex.Message);
        }
    }

	 public override void SendMessage(int msgID, byte[] msg)
	{
		 if (msg == null)
			 throw new Exception("msgData can not be null");
		 SendQueue.Enqueue(Packet.Encode(msgID, msg, mHasHeader));
	}

    public override void Update()
    {
        // 向服务器发送队列中的消息
        try
        {
            ParseServerPacket();

            if (IsReadySend && SendQueue.Count > 0)
            {
                SendData();
            }
            ///主线程发包方式
            //if (ReceiveQueue.Count > 0)
            //{
            //    ProcessReceivePacket();
            //}
        }
        catch (Exception ex)
        {
            Debug.LogError("HttpObject Update Exception: " + ex.Message);
        }
    }
	
	public override void Disconnect()
	{
		
	}

    public override void Reconnect()
    {
        
    }

    private void SendData()
    {
        if (SendQueue.Count <= 0)
        {
            return;
        } 
        // Packet sendPackage = mSendQueue.Dequeue();
        // byte[] data = sendPackage.GetBytes();
        byte[] data = SendQueue.Dequeue();
        mWebClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
        mWebClient.Headers.Add("ContentLength", data.Length.ToString());

        try
        {
            mWebClient.UploadDataAsync(mUrl, data);
        }
        catch (System.Exception e)
        {
            Debug.LogError("HttpObject SendData Exception: " + e.Message);
        }

        IsReadySend = false;
    }

   	void httpWebClient_UploadDataCompleted(object sender, UploadDataCompletedEventArgs e)
    {
        if (e.Error == null)
        {
            // 正常收到服务器回复的消息
            if (e.Result != null && e.Result.Length > 0)
            {
                // 加入到等待处理的消息列表
               	// AddPacketResult(e.Result);

                mReconnectCount = 0;
            }
            else
            {
                // 服务器返回消息的内容错误，尝试重连
                Debug.LogError("Http Received Packet Context Error: " + e.Error);
                Reconnection();
            }
        }
        else
        {
            // 链接错误，尝试重连
            Debug.LogError("Http Received Packet Error: " + e.Error);
            Reconnection();
        }

        IsReadySend = true;
    }

    private void Reconnection()
    {
        if (mReconnectCount >= NetworkManager.ReConnectLimit)
        {
            mReconnectCount = 0;
        }
        else
        {
            ++mReconnectCount;
        }
    }

    public override bool IsConnectSuccess()
    {
        return true;
    }
}
