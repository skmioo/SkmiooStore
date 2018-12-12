using System.Collections.Generic;
using System;
using System.Reflection; 
/**********************************************
* @说明: 子线程处理
* @作者：zhm
* @版本号：V1.00
**********************************************/
public  class SubThread : MyThread
{ 
    //子线程初始化
    public SubThread OnInit(short tickSleepTime,MyThreadEventDelegate OnUpdateEvent)
    { 
        this.TickSleepTime = tickSleepTime;
        this.OnUpdateEvent = OnUpdateEvent;
        return this;
    } 
     
}
