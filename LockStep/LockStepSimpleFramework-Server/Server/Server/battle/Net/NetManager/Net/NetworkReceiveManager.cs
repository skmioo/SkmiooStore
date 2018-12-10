using UnityEngine;
using System.Net;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using com.mile.common.message;
using System.Reflection;

public sealed class ReceiveManager : CSharpSingletion<ReceiveManager>
{
	/// <summary>
	/// 是否启动
	/// </summary>
	private bool _IsStart = true;
 
	/// <summary>
	/// 主线程执行队列
	/// </summary>
	private ActionQueue _actionQueue = new ActionQueue();
	/// <summary>
	/// 获取队列控制
	/// </summary>
	public static ActionQueue Queue
	{
		get
		{
			if (null == Instance._actionQueue)
			{
				throw new Exception("_actionQueue 是空的 还未进行初始化");
			}
			return Instance._actionQueue;
		}
	}

	/// <summary>
	/// 心跳
	/// </summary>
	public void OnTick()
	{
		if (!_IsStart)
		{
			return;
		}
		HandleAction(4096);
	}

	private void HandleAction(int size)
	{

		MyAction action = null;
		for (int i = 0; i < size; i++)
		{
			if (_actionQueue.CurActionNum > 0)
			{
				if (!_actionQueue.MyDequeue(out action))
				{
					continue;
				}
				action();
			}
			else
				break;
		}
		
	}
}