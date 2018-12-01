using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class EventNode
{
	//当前数据
	public MonoBase data;
	//下一个结点
	public EventNode next; 

	public EventNode(MonoBase tmpMono)
	{
		data = tmpMono;
		next = null;
	}
}

public class ManagerBase : MonoBase
{
	//存储注册消息 key value
	public Dictionary<ushort, EventNode> eventTree = new Dictionary<ushort,EventNode> ();

	/// <summary>
	/// Registers the message.
	/// </summary>
	/// <param name="mono">要注册的脚本</param>
	/// <param name="msgs">一个脚本 可以注册多个msg</param>
	public void RegisterMsg(MonoBase mono, params ushort[] msgs)
	{
		for (int i = 0; i < msgs.Length; i++) {
			EventNode tmp = new EventNode (mono);
			RegisterMsg (msgs[i], tmp);
		}
	}

	/// <summary>
	/// Registers the message.
	/// </summary>
	/// <param name="id">根据msgId</param>
	/// <param name="mono">node 链表</param>
	public void RegisterMsg(ushort id, EventNode node)
	{
		if (!eventTree.ContainsKey (id)) 
		{
			eventTree.Add (id, node);
		} else {
			EventNode tmp = eventTree [id];
			while(tmp.next!= null)
			{
				tmp = tmp.next;
			}	
			tmp.next = node;
		}
	}

	/// <summary>
	/// 去掉多个 msg下的节点
	/// </summary>
	/// <param name="mono">Mono.</param>
	/// <param name="msgs">Msgs.</param>
	public void UnRegisterMsg(MonoBase mono, params ushort[] msgs)
	{
		for (int i = 0; i < msgs.Length; i++) {
			UnRegisterMsg (msgs[i], mono);
		}
	}

	/// <summary>
	/// 去掉一个消息链
	/// </summary>
	/// <param name="id">Identifier.</param>
	/// <param name="node">Node.</param>
	public void UnRegisterMsg(ushort id, MonoBase node)
	{
		if (!eventTree.ContainsKey (id)) {
			Debug.LogError ("not contain id ==" + id);
			return;
		} else {
			EventNode tmp = eventTree [id];
			//该消息结点位消息头
			if (tmp.data == node) {
				EventNode header = tmp;
				//该结点有下一个结点
				if (header.next != null) {
					header.data = tmp.next.data;
					header.next = tmp.next.next;
				} else {
					//只存在一个节点的情况
					eventTree.Remove (id);
				}
			} else {
				//在尾部或者中间
				while (tmp.next != null && tmp.next.data != node) {

					tmp = tmp.next;
				}

				if (tmp.next.next != null) {
					//节点在中间
					tmp.next = tmp.next.next;
				} else {
					//节点在结尾
					tmp.next = null;
				}
			}
		}
	}

    /// <summary>
    /// 通过key 找到链表 然后全部通知
    /// </summary>
    /// <param name="tmpMsg"></param>
    public override void ProcessEvent(MsgBase tmpMsg)
    {
        if (!eventTree.ContainsKey(tmpMsg.msgId))
        {
            Debug.LogError("ManagerBase : msg not contain msgId ==" + tmpMsg.msgId);
        }
        else {
            EventNode tmp = eventTree[tmpMsg.msgId];
            do
            {
                //策略模式
                tmp.data.ProcessEvent(tmpMsg);
            } while (tmp != null);
        }
    }
}

