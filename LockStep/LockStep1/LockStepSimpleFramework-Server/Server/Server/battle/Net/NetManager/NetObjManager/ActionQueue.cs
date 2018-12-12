using System.Collections;
using System.Collections.Generic;
/**********************************************
* @说明: 线程操控队列
* @作者：zhm
* @版本号：V1.00
**********************************************/
public class ActionQueue:IActionQueue //,IReset
{ 
    private object LockObj = new object();
    //需要处理的队列
    private Queue<MyAction> queue = new Queue<MyAction>(); 
    //出列
    public bool MyDequeue(out MyAction maction)
    {
        if (CurActionNum <= 0)
        {
            maction = null;
            return false;
        }  
        lock (LockObj)
        { 
            maction = queue.Dequeue();
            return true;
        } 
    }

	//
	public void CallAllFun(bool isDequeue = false)
	{
		if (isDequeue)
		{
			MyAction action;
			while (MyDequeue(out action))
			{
				action();
			}
		}
		else
		{
			MyAction[] actions = queue.ToArray();
			if (actions == null)
				return;
			for (int i = 0; i < actions.Length; i++)
			{
				if (actions[i] != null)
					actions[i]();
			}
		}
	}


    //出列
    public void CallFun()
    {
        MyAction maction;
        MyDequeue(out maction); 
        if (maction != null) maction();
    }

    //队列中的Action 数量
    public int  CurActionNum
    {
        get {
            return  queue.Count;
        }
    }
    //================================================================
    public void QueueAction(MyAction action)
    {
        lock (LockObj)
        {
            queue.Enqueue(action);
        }
    }

    public void  QueueAction<T1>(MyAction<T1> action, T1 t1)
    {
        lock (LockObj)
        {
            queue.Enqueue(() => { action(t1); });
        } 
    }

    public void  QueueAction<T1, T2>(MyAction<T1, T2> action, T1 t1, T2 t2)
    {
        lock (LockObj)
        {
            queue.Enqueue(() => { action(t1,t2); });
        } 
    }

    public void  QueueAction<T1, T2, T3>(MyAction<T1, T2, T3> action, T1 t1, T2 t2, T3 t3)
    {
        lock (LockObj)
        {
            queue.Enqueue(() => { action(t1, t2,t3); });
        } 
    }

    public void  QueueAction<T1, T2, T3, T4>(MyAction<T1, T2, T3, T4> action, T1 t1, T2 t2, T3 t3, T4 t4)
    {
        lock (LockObj)
        {
            queue.Enqueue(() => { action(t1, t2, t3,t4); });
        } 
    }

    public void  QueueAction<T1, T2, T3, T4, T5>(MyAction<T1, T2, T3, T4, T5> action, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
    {
        lock (LockObj)
        {
            queue.Enqueue(() => { action(t1, t2, t3, t4,t5); });
        } 
    }

    public void  QueueAction<T1, T2, T3, T4, T5, T6>(MyAction<T1, T2, T3, T4, T5, T6> action, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6)
    {
        lock (LockObj)
        {
            queue.Enqueue(() => { action(t1, t2, t3, t4, t5,t6); });
        } 
    }

    public void  QueueAction<T1, T2, T3, T4, T5, T6, T7>(MyAction<T1, T2, T3, T4, T5, T6, T7> action, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7)
    {
        lock (LockObj)
        {
            queue.Enqueue(() => { action(t1, t2, t3, t4, t5, t6,t7); });
        } 
    }

    public void  QueueAction<T1, T2, T3, T4, T5, T6, T7, T8>(MyAction<T1, T2, T3, T4, T5, T6, T7, T8> action, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8)
    {
        lock (LockObj)
        {
            queue.Enqueue(() => { action(t1, t2, t3, t4, t5, t6, t7,t8); });
        } 
    }

    public void  QueueAction<T1, T2, T3, T4, T5, T6, T7, T8, T9>(MyAction<T1, T2, T3, T4, T5, T6, T7, T8, T9> action, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9)
    {
        lock (LockObj)
        {
            queue.Enqueue(() => { action(t1, t2, t3, t4, t5, t6, t7, t8,t9); });
        } 
    }

    public void  QueueAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(MyAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10)
    {
        lock (LockObj)
        {
            queue.Enqueue(() => { action(t1, t2, t3, t4, t5, t6, t7, t8, t9,t10); });
        } 
    }

    public void  QueueAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(MyAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11)
    {
        lock (LockObj)
        {
            queue.Enqueue(() => { action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,t11); });
        } 
    }

    public void  QueueAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(MyAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12)
    {
        lock (LockObj)
        {
            queue.Enqueue(() => { action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11,t12); });
        }
    }

    public void  QueueAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(MyAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13)
    {
        lock (LockObj)
        {
            queue.Enqueue(() => { action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12,t13); });
        }
    }

    public void  QueueAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(MyAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14)
    {
        lock (LockObj)
        {
            queue.Enqueue(() => { action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14); });
        }
    }

    public void  QueueAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(MyAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15)
    {
        lock (LockObj)
        {
            queue.Enqueue(() => { action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13,t14,t15); });
        }
    }

    public void  QueueAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(MyAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16)
    {
        lock (LockObj)
        {
            queue.Enqueue(() => { action(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16); });
        }
    }

	/*********************************************************  Func *****************************************************************/

	public void QueueAction<R>(MyFunc<R> func)
	{
		lock (LockObj)
        {
            queue.Enqueue(() => { func(); });
        }
	}

	
	public void QueueAction<T1, R>(MyFunc<T1, R> func, T1 t1)
	{
		lock (LockObj)
        {
            queue.Enqueue(() => { func(t1); });
        }
	}

	public void QueueAction<T1, T2, R>(MyFunc<T1, T2, R> func, T1 t1, T2 t2)
	{
		lock (LockObj)
		{
			queue.Enqueue(() => { func(t1,t2); });
		}
	}

	public void QueueAction<T1, T2, T3, R>(MyFunc<T1, T2, T3, R> func, T1 t1, T2 t2, T3 t3)
	{
		lock (LockObj)
		{
			queue.Enqueue(() => { func(t1,t2,t3); });
		}
	}

	public void QueueAction<T1, T2, T3, T4, R>(MyFunc<T1, T2, T3, T4, R> func, T1 t1, T2 t2, T3 t3, T4 t4)
	{
		lock (LockObj)
		{
			queue.Enqueue(() => { func(t1, t2, t3, t4); });
		}
	}

	public void QueueAction<T1, T2, T3, T4, T5, R>(MyFunc<T1, T2, T3, T4, T5, R> func, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
	{
		lock (LockObj)
		{
			queue.Enqueue(() => { func(t1, t2, t3, t4, t5); });
		}
	}

	public void QueueAction<T1, T2, T3, T4, T5, T6, R>(MyFunc<T1, T2, T3, T4, T5, T6, R> func, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6)
	{
		lock (LockObj)
		{
			queue.Enqueue(() => { func(t1, t2, t3, t4, t5, t6); });
		}
	}

	public void QueueAction<T1, T2, T3, T4, T5, T6, T7, R>(MyFunc<T1, T2, T3, T4, T5, T6, T7, R> func, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7)
	{
		lock (LockObj)
		{
			queue.Enqueue(() => { func(t1, t2, t3, t4, t5, t6, t7); });
		}
	}

	public void QueueAction<T1, T2, T3, T4, T5, T6, T7, T8, R>(MyFunc<T1, T2, T3, T4, T5, T6, T7, T8, R> func, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8)
	{
		lock (LockObj)
		{
			queue.Enqueue(() => { func(t1, t2, t3, t4, t5, t6, t7, t8); });
		}
	}

	public void QueueAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, R>(MyFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, R> func, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9)
	{
		lock (LockObj)
		{
			queue.Enqueue(() => { func(t1, t2, t3, t4, t5, t6, t7, t8, t9); });
		}
	}

	public void QueueAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, R>(MyFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, R> func, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10)
	{
		lock (LockObj)
		{
			queue.Enqueue(() => { func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10); });
		}
	}

	public void QueueAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, R>(MyFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, R> func, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11)
	{
		lock (LockObj)
		{
			queue.Enqueue(() => { func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11); });
		}
	}

	public void QueueAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, R>(MyFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, R> func, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12)
	{
		lock (LockObj)
		{
			queue.Enqueue(() => { func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12); });
		}
	}

	public void QueueAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, R>(MyFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, R> func, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13)
	{
		lock (LockObj)
		{
			queue.Enqueue(() => { func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13); });
		}
	}

	public void QueueAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, R>(MyFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, R> func, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14)
	{
		lock (LockObj)
		{
			queue.Enqueue(() => { func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14); });
		}
	}

	public void QueueAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, R>(MyFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, R> func, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15)
	{
		lock (LockObj)
		{
			queue.Enqueue(() => { func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15); });
		}
	}

	public void QueueAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, R>(MyFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, R> func, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16)
	{
		lock (LockObj)
		{
			queue.Enqueue(() => { func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16); });
		}
	}

    public void OnReset()
    {
        lock (LockObj)
        {
            queue.Clear();
        } 
    }

    public bool Empty()
    {
        lock (LockObj)
        {
            return queue.Count == 0;
        } 
    }
}
