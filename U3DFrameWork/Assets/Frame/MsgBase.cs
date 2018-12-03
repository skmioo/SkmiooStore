using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MsgBase 
{
	//表示 65535个消息 8位
	public ushort  msgId;

	public MessageID GetManager()
	{
		int tmpId = msgId / FrameTools.MsgSpan;
		return (MessageID)(tmpId * FrameTools.MsgSpan);
	}

	public MsgBase(ushort tmpMsg)
	{
		msgId = tmpMsg;
	}
}
