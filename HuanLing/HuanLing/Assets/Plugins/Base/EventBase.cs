using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SLua;

namespace UYMO
{
    /// <summary>
    /// 事件基类
    /// </summary>
    [CustomLuaClassAttribute]
    public class EventBase
    {
        private string _EventType;
        private bool _Canceled;
        private IEventBus _Sender;
        public EventBase(string aEventType)
        {
            _EventType = aEventType;
            _Canceled = false;
        }
        /// <summary>
        /// 重置事件（用于重复利用），to override
        /// </summary>
        public virtual void Reset()
        {
            _Canceled = false;
            _Sender = null;
        }
        /// <summary>
        /// 事件类型
        /// </summary>
        public string eventType
        {
            get { return _EventType; }
        }
        /// <summary>
        /// 是否取消
        /// </summary>
        public bool canceled
        {
            get { return _Canceled; }
            set { _Canceled = value; }
        }
        /// <summary>
        /// 事件触发者
        /// </summary>
        public IEventBus sender
        {
            get { return _Sender; }
        }
        /// <summary>
        /// 设置当前的事件触发者，事件响应函数请不要随意调用
        /// </summary>
        /// <param name="aSender">事件触发者</param>
        public void _SetCurrentSender(IEventBus aSender)
        {
            _Sender = aSender;
        }
    }
}
