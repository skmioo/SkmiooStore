using com.mile.common.message;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;

public class ServerSocketAnalyze
{
    public Socket sokClient;
    public Thread thr;

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

    private bool _IsHeader = true;

    public ServerSocketAnalyze(Socket socket)
    {
        ReadBuff = new byte[ReceiveLen];
        TempBuff = new byte[ReceiveLen];
        TempPos = 0;
        sokClient = socket;
        thr = new Thread(RecMsg);
        thr.IsBackground = true;
        thr.Start();
    }


    void RecMsg()
    {

        while (true)
        {
            try
            {
                if (!NetworkManager.NetEnabled)
                {
                    Thread.Sleep(30);
                    return;
                }
                //try
                //{
                if (null == sokClient || !sokClient.Connected)
                {
                    return;
                }
                // 清空临时缓冲区
                Array.Clear(ReadBuff, 0, ReceiveLen);
                int length = sokClient.Receive(ReadBuff);
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
                Thread.Sleep(10);
            }
            catch (Exception e)
            {
                sokClient.Close();
            }

        }

    }

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
                Console.WriteLine("headSize " + headerSize + " TempPos " + TempPos + " bodySize " + bodySize);
                return;
            }

            EnqueuePacket(bodySize);
        }
    }

    /// <summary>
    /// 将包压入队列
    /// </summary>
    /// <param name="packetSize"></param>
    private void EnqueuePacket(int packetSize)
    {
        Packet packet = new Packet(ServerDataType.protobuf, true);
        packet.Decode(TempBuff);

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
        }
    }


    public void SendMsg(MessageID msgID,PacketDistributed msgData)
    {
        //NetworkManager.SendMessage(msgID,)
        byte[] msg = Packet.Encode((int)msgID, msgData, ServerDataType.protobuf, true);
        try
        {
            sokClient.BeginSend(msg, 0, msg.Length, SocketFlags.None, SendCallback, sokClient);
        }
        catch (Exception e)
        {
            sokClient.Close();
        }
    }

    private void SendCallback(IAsyncResult asyncSend)
    {
        try
        {
            Socket client = (Socket)asyncSend.AsyncState;
            int bytesSent = client.EndSend(asyncSend);
        }
        catch (Exception e)
        {
            Console.WriteLine("Send Message Failed: " + e.ToString());
        }
    }
}
