using UnityEngine;
using System;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices; 
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
/**********************************************
* @说明: Packet 收发协议的处理封装包
* @作者：ZHM --- 海鸣不骑猪 
* @版本号：V1.00
**********************************************/
public class Packet {
      
    private PacketHeader _header;
    /// <summary>
    /// 消息包头结构体
    /// </summary>
    public PacketHeader Header
    {
        get
        {
            return _header;
        }
    } 

    /// <summary>
    ///消息对象
    /// </summary> 
    public object CurrObject; 

    /// <summary>
    /// 消息对象的类型
    /// </summary>
    private ServerDataType _dataType;
    public ServerDataType DataType
    {
        get{
            return _dataType;
        } 
    }
    /// <summary>
    ///  消息对象转换为字节流后的数据
    /// </summary>
    private byte[] _bytes; 
    /// <summary>
    ///  是否包含消息头
    /// </summary> 
	private bool _IsHeader; 
	public bool IsHeader
	{
        get
        {
            return _IsHeader;
        }
	}

	public Packet(ServerDataType type, bool isHeader)
	{
        _dataType = type;
		_IsHeader = isHeader;
        _header.RetCode = 0;
	}

	public static byte[] Encode(int msgID, byte[] msgData, bool isHeader = true)
	{
		if (msgData == null)
			throw new System.Exception("msgData can not be null!");
		
		byte[] bytes = msgData;
		
		byte[] dataBytes;
		int len = bytes.Length;
		if (isHeader)
		{
			// 包头信息 
			//byte[] h1 = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(len));
			//byte[] h2 = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(msgID));
			//byte[] h3 = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(DateTime.Now.Ticks));
			//byte[] h4 = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(0));
			//byte[] h5 = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(0));

            byte[] h1 = BitConverter.GetBytes(len);
            byte[] h2 = BitConverter.GetBytes(msgID);
            byte[] h3 = BitConverter.GetBytes(DateTime.Now.Ticks);
            byte[] h4 = BitConverter.GetBytes(0);
            byte[] h5 = BitConverter.GetBytes(0);
            dataBytes = new byte[PacketHeader.HeaderLen + len];
            //Debug.Log("head len :" + h1.Length);
            // 合并数据
            int perLength = h1.Length;
			Array.Copy(h1, 0, dataBytes, 0, perLength);
			Array.Copy(h2, 0, dataBytes, perLength, perLength);
			Array.Copy(h3, 0, dataBytes, perLength * 2, h3.Length);
			Array.Copy(h4, 0, dataBytes, perLength * 4, perLength);
			Array.Copy(h5, 0, dataBytes, perLength * 5, perLength);
			Array.Copy(bytes, 0, dataBytes, perLength * 6, len);
		}
		else
		{
			dataBytes = new byte[len];
			Array.Copy(bytes, 0, dataBytes, 0, len);
		}
		return dataBytes;
	}
    /// <summary>
    /// 序列化数据包
    /// </summary>
    /// <param name="msgID"></param>
    /// <param name="msgData"></param>
    public static byte[] Encode(int msgID, object msgData, ServerDataType dataType, bool isHeader = true)
	{
        byte[] bytes; 
        switch (dataType)
        {
            case ServerDataType.str:
                bytes = System.Text.UTF8Encoding.UTF8.GetBytes(msgData as string);
                break;
            case ServerDataType.json: 
                JObject jd = msgData as JObject;
                bytes = System.Text.UTF8Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(jd));
                break;
            case ServerDataType.protobuf: 
                bytes =(msgData as PacketDistributed).ToByteArray();
                break;
            case ServerDataType.stream:
                bytes = msgData as byte[];
                break;
            default:
                throw new System.Exception("Message Data Type Error!");
        }
		return Encode(msgID, bytes, isHeader);
	} 

    /// <summary>
    /// 解码数据流
    /// </summary>
    public void Decode(byte[] data)
    {
        if (_IsHeader)
        {
            int headerSize = PacketHeader.HeaderLen;
            _header = PacketHeader.BytesToStruct(data);
            //_header.Len = IPAddress.NetworkToHostOrder(_header.Len);
            //_header.PacketID = IPAddress.NetworkToHostOrder(_header.PacketID);
            //_header.Stamp = IPAddress.NetworkToHostOrder(_header.Stamp);
            //_header.RetCode = IPAddress.NetworkToHostOrder(_header.RetCode);
            //_header.Flag = IPAddress.NetworkToHostOrder(_header.Flag);
            //Debug.Log("header len : " + _header.Len);
            //Console.WriteLine("收到 packetID : " + _header.PacketID + " len : " + _header.Len);
            _header.Len = _header.Len;
            _header.PacketID = _header.PacketID;
            _header.Stamp = _header.Stamp;
            _header.RetCode = _header.RetCode;
            _header.Flag = _header.Flag;
            _bytes = new byte[_header.Len];
            Array.Copy(data, headerSize, _bytes, 0, _header.Len); 
        }
        else
        {
            _bytes = data;
        }
        DecodeToObject();
    }

    /// <summary>
    /// 解析数据包
    /// </summary>
    private void DecodeToObject()
    {
        try
        {
            switch (_dataType)
            {
                case ServerDataType.str:
                    CurrObject = System.Text.UTF8Encoding.UTF8.GetString(_bytes);
                    break;
                case ServerDataType.json:
                    string temp = System.Text.UTF8Encoding.UTF8.GetString(_bytes);
                    CurrObject = JsonConvert.SerializeObject(temp);
                    break;
                case ServerDataType.protobuf:
					PacketDistributed pd = PacketDistributed.CreatePacket((com.mile.common.message.MessageID)_header.PacketID); 
                    pd.ParseFrom(_bytes);
                    CurrObject = pd;
                    break;
                case ServerDataType.stream:
                    CurrObject = _bytes;
                    break;
                default:
                    throw new System.Exception("Message Data Type Error!");
            }
        }
        catch (Exception ex)
        {
			Debug.LogError("Protocol Parse Error : " + ex.Message + "\t" + (com.mile.common.message.MessageID)_header.PacketID);
        }
    } 
}
