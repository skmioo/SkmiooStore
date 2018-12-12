using com.mile.common.message;
using System;
using System.Collections.Generic;

public class NetMsgManager : CSharpSingletion<NetMsgManager>//, I_OnUpdate, I_OnDestroy, I_OnRelease
{
	private enum HandleType
	{
		None,
		Send,
		Handle,
		Execute,
		Count
	}

	private class NetMessageInfo
	{
		public NetMessageBase msgBase = null;
		public HandleType handleType = HandleType.None;
	}

	private Dictionary<MessageID, List<NetMessageInfo>> dic_HandleNetMessages = new Dictionary<MessageID, List<NetMessageInfo>>();

	public void SendMessage(MessageID msgID, params object[] msgParams)
	{
		HandleMessage(HandleType.Send, msgID, msgParams);
	}

	public void HandleMessage(MessageID msgID, params object[] msgParams)
	{
		HandleMessage(HandleType.Handle, msgID, msgParams);
	}

	public void OnUpdate()
	{
		if (dic_HandleNetMessages == null || dic_HandleNetMessages.Count <= 0)
			return;

		foreach (KeyValuePair<MessageID, List<NetMessageInfo>> keyValue in dic_HandleNetMessages)
		{
			List<NetMessageInfo> netMessageList = keyValue.Value;

			if (netMessageList == null || netMessageList.Count <= 0)
				continue;

			for (int i = 0; i < netMessageList.Count; i++)
			{
				NetMessageBase netBase = netMessageList[i].msgBase;
				HandleType type = netMessageList[i].handleType;

				if (netBase == null)
				{
					netMessageList.Remove(netMessageList[i]);
					i--;
					continue;
				}

				HandleMessage(type, netBase);

				if (!netBase.isFree)
					continue;

				netMessageList.Remove(netMessageList[i]);
				i--;
			}
		}
	}

	public void OnRelease()
	{
		if (dic_HandleNetMessages == null || dic_HandleNetMessages.Count <= 0)
			return;

		foreach (KeyValuePair<MessageID, List<NetMessageInfo>> keyValue in dic_HandleNetMessages)
		{
			List<NetMessageInfo> netMessageList = keyValue.Value;

			if (netMessageList == null || netMessageList.Count <= 0)
				continue;

			for (int i = 0; i < netMessageList.Count; i++)
			{
				NetMessageBase netBase = netMessageList[i].msgBase;

				if (netBase == null)
					continue;

				netBase.OnDestroy();
			}

			netMessageList.Clear();
		}

		dic_HandleNetMessages.Clear();
	}

	public void OnDestroy()
	{
		OnRelease();
		dic_HandleNetMessages = null;
	}

	private void AddMessage(MessageID msgID, NetMessageInfo info)
	{
		if (dic_HandleNetMessages.ContainsKey(msgID))
		{
			List<NetMessageInfo> netMessageList = dic_HandleNetMessages[msgID];

			netMessageList.Add(info);
		}
		else
		{
			List<NetMessageInfo> netMessageList = new List<NetMessageInfo>();

			netMessageList.Add(info);

			dic_HandleNetMessages.Add(msgID, netMessageList);
		}
	}

	private void HandleMessage(HandleType type, MessageID msgID, params object[] msgParams)
	{
		NetMessageBase msgBase = Factory_CreateMessage.Instance.CreateNetMessage(msgID);

		if (msgBase == null)
		{
			Console.WriteLine("MessageID Error: " + msgID + "\t");
			return;
		}
		msgBase.SetMessageParams(msgParams);

		HandleMessage(type, msgBase);

		if (msgBase.isFree)
			return;

		NetMessageInfo info = new NetMessageInfo();
		info.handleType = type;
		info.msgBase = msgBase;

		AddMessage(msgID, info);
	}

	private void HandleMessage(HandleType type, NetMessageBase msgBase)
	{
		switch (type)
		{
			case HandleType.Send:
				((SendNetMessageBase)msgBase).SendMessage();
				break;
			case HandleType.Handle:
				((HandleNetMessageBase)msgBase).HandleMessage();
				break;
			default:
				break;
		}
	}
}
