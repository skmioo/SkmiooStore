using System;
using System.Collections.Generic;
using System.Threading;
/**********************************************
* @说明: 线程处理
* @作者：zhm
* @版本号：V1.00
**********************************************/
public delegate void MyThreadEventDelegate();
public class MyThread
{ 
    public MyThreadEventDelegate OnStartEvent;
    public MyThreadEventDelegate OnUpdateEvent;
    public MyThreadEventDelegate OnQuitEvent;

    private Thread _thread = null;
    private bool m_IsRun = true;
    //每隔多少毫秒执行一次
    private short m_TickSleepTime = 10; 
    //构造方法
    public MyThread()
    {
        InitThread();
    }
    public MyThread(short tickSleepTime)
    {
        m_TickSleepTime = tickSleepTime;
        InitThread();
    } 
    //======================================================
    private void InitThread()
    {
        _thread = new Thread(this.Loop);
    } 
    //执行间隔时间
    public short TickSleepTime
    {
        get { return m_TickSleepTime; }
        set { m_TickSleepTime = value; }
    }
    
    //启动线程
    public void Start()
    {
        m_IsRun = true;
        _thread.Start();
    }
    //暂停线程
    public virtual void OnStop()
    {
        m_IsRun = false;
        _thread.Abort();  
    }
    
    //获取线程
    public Thread Thread
    {
        get
        {
            return _thread;
        }
    }

    private void Loop()
    {
        try
        {
            if (OnStartEvent != null)
            {
                OnStartEvent();
            }
            else
            {
                OnStart();
            }

            while (m_IsRun)
            {
                try
                { 
                    if (OnUpdateEvent != null)
                    {
                        OnUpdateEvent();
                    }
                    else
                    {
                        OnUpdate();
                    }
                }
                catch (Exception ex)
                {
                    //LogCtrl.Error("MyThread.Tick throw exception:{0}\n{1}", ex.Message, ex.StackTrace);
					Console.WriteLine("MyThread.Loop throw exception:" + ex.Message + "\n" + ex.StackTrace);
                }
                Thread.Sleep(m_TickSleepTime);
            }
            if (OnQuitEvent != null)
            {
                OnQuitEvent();
            }
            else
            {
                OnQuit();
            }
        }
        catch (Exception ex)
        {
            //LogCtrl.Error("MyThread.Loop throw exception:{0}\n{1}", ex.Message, ex.StackTrace);
			UnityEngine.Debug.LogError("MyThread.Loop throw exception:" + ex.Message + "\n" + ex.StackTrace);
        }
    }
      
    protected virtual void OnStart()
    {

    }
    protected virtual void OnUpdate()
    {

    }
    protected virtual void OnQuit()
    {

    } 
} 