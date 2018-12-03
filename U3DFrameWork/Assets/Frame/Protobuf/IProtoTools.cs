using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProtoBuf;
using System.IO;

public class IProtoTools  {
    
    /// <summary>
    /// 序列化出来 给socket发送
    /// </summary>
    /// <param name="msg"></param>
    /// <returns></returns>
    public static byte[] Serialize(IExtensible msg)
    {
        byte[] result;
        using (var stream = new MemoryStream())
        {
            Serializer.Serialize(stream, msg);
            result = stream.ToArray();
        }
        return result;
    }

    /// <summary>
    /// 从socket接收数据 返序列化成类
    /// </summary>
    /// <typeparam name="IExtensible"></typeparam>
    /// <param name="msg"></param>
    /// <returns></returns>
    public static IExtensible Deserialize<IExtensible>(byte[] msg)
    {
        IExtensible result;
        using (var stream = new MemoryStream(msg))
        {
            result = Serializer.Deserialize<IExtensible>(stream);
        }
        return result;
    }

}
