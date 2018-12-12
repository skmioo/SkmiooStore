using System.Runtime.InteropServices;
using System;
/**********************************************
* @说明: 项目中的协议头
* @作者：ZHM --- 海鸣不骑猪 
* @版本号：V1.00
**********************************************/ 
public struct PacketHeader 
{
    // 消息包的长度
    public int Len { get; set; }

    // 消息包ID
    public int PacketID { get; set; }

    // 时间戳
    public long Stamp { get; set; }

    // 框架层标识的返回代码。0表示正常。其他表示错误代码
    public int RetCode { get; set; }

    // 标志位
    public int Flag { get; set; }

    public static int HeaderLen = Marshal.SizeOf(typeof(PacketHeader));


    /// <summary>
    /// 将消息包头的数据转化为字节流
    /// </summary>
    /// <param name="header">传入需要转化的消息包头</param>
    /// <returns>返回转化后的字节流</returns>
    public static byte[] StructToBytes(PacketHeader header)
    {
        int size = Marshal.SizeOf(header);
        IntPtr buffer = Marshal.AllocHGlobal(size);
        try
        {
            Marshal.StructureToPtr(header, buffer, false);
            byte[] bytes = new byte[size];
            Marshal.Copy(buffer, bytes, 0, size);
            return bytes;
        }
        finally
        {
            Marshal.FreeHGlobal(buffer);
        }
    }

    /// <summary>
    /// 将字节流转化为消息包头结构
    /// </summary>
    /// <param name="bytes">传入需要转化的字节流</param>
    /// <returns>返回转化后的消息包头</returns>
    public static PacketHeader BytesToStruct(byte[] bytes)
    {
        int size = Marshal.SizeOf(typeof(PacketHeader));
        IntPtr buffer = Marshal.AllocHGlobal(size);
        try
        {
            Marshal.Copy(bytes, 0, buffer, size);
            return (PacketHeader)Marshal.PtrToStructure(buffer, typeof(PacketHeader));
        }
        finally
        {
            Marshal.FreeHGlobal(buffer);
        }
    }

}
