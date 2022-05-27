using System;
using System.Collections.Generic;
using SLua;

namespace UYMO
{
    /// <summary>
    /// 计时器基类
    /// </summary>
    public class UYTimerBase
    {
        /// <summary>
        /// 判断当前timer是否已经结束（不会再触发了）
        /// </summary>
        public virtual bool complete
        {
            get { return true; }
        }
    }

    public delegate void UYTimerHandler();

}
