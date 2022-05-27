using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SLua;

namespace UYMO
{
    /// <summary>
    /// 普通事件回调函数
    /// </summary>
    /// <param name="evt">事件</param>
    public delegate void EventBusHandle(EventBase evt);
    /// <summary>
    /// lua的动态事件回调函数
    /// </summary>
    /// <param name="lua">lua</param>
    /// <param name="evt">事件</param>
    public delegate void LuaEventBusHandle(LuaTable lua, EventBase evt);

    /// <summary>
    /// 事件插槽接口
    /// </summary>
    public interface IEventBus
    {
        /// <summary>
        /// 添加一个普通的事件响应
        /// </summary>
        /// <param name="eventType">事件类型</param>
        /// <param name="handle">回调</param>
        void AddListener(string eventType, EventBusHandle handle);
        /// <summary>
        /// 移除一个普通事件响应
        /// </summary>
        /// <param name="eventType">事件类型</param>
        /// <param name="handle">回调</param>
        void RemoveListener(string eventType, EventBusHandle handle);
        /// <summary>
        /// 判断给定的事件是否注册了给定的回调
        /// </summary>
        /// <param name="eventType">事件类型</param>
        /// <param name="handle">回调</param>
        /// <returns>已经注册了返回true</returns>
        bool HasListener(string eventType, EventBusHandle handle);
        /// <summary>
        /// 添加一个lua上的动态事件响应
        /// </summary>
        /// <param name="eventType">事件类型</param>
        /// <param name="lua">lua</param>
        /// <param name="handle">回调</param>
        void AddDynamicListener(string eventType, LuaTable lua, LuaEventBusHandle handle);
        /// <summary>
        /// 移除一个lua上的动态事件响应
        /// </summary>
        /// <param name="eventType">事件类型</param>
        /// <param name="lua">lua</param>
        /// <param name="handle">回调</param>
        void RemoveDynamicListener(string eventType, LuaTable lua, LuaEventBusHandle handle);
        /// <summary>
        /// 判断给定的事件是否注册了给定的lua回调
        /// </summary>
        /// <param name="eventType">事件类型</param>
        /// <param name="lua">lua</param>
        /// <param name="handle">lua回调</param>
        /// <returns>已经注册了返回true</returns>
        bool HasDynamicListener(string eventType, LuaTable lua, LuaEventBusHandle handle);
        /// <summary>
        /// 清理所有已经注册的事件响应
        /// </summary>
        void ClearAllListeners();
        /// <summary>
        /// 转发事件
        /// </summary>
        /// <param name="evt">待转发的事件</param>
        void DispatchEvent(EventBase evt);
    }

    /// <summary>
    /// 函数容器
    /// </summary>
    class HandleBucket
    {
        private enum ListenerOp
        {
            Null,
            Add,
            Remove
        }

        interface IEventListener
        {
            void Notify(EventBase evt);
            bool IsHandle(IEventListener ls);
            bool IsHandle(EventBusHandle h);
            bool IsHandle(LuaTable aLua, LuaEventBusHandle h);
            ListenerOp flag { get; }
        }
        class EventListener : IEventListener
        {
            private static Stack<EventListener> s_Pool = new Stack<EventListener>();
            public static EventListener Create(EventBusHandle h, ListenerOp opFlag)
            {
                var ls = s_Pool.Count == 0 ? new EventListener() : s_Pool.Pop();
                ls.Reset(h, opFlag);
                return ls;
            }
            public static void Destroy(EventListener ls)
            {
                ls.Reset(null, ListenerOp.Null);
                if (s_Pool.Count < 20)
                    s_Pool.Push(ls);
            }

            private EventBusHandle _Handle;
            private ListenerOp _OpFlag;
            private void Reset(EventBusHandle h, ListenerOp opFlag)
            {
                _Handle = h;
                _OpFlag = opFlag;
            }
            public ListenerOp flag
            {
                get { return _OpFlag; }
            }
            public bool IsHandle(IEventListener ls)
            {
                EventListener els = ls as EventListener;
                if (els != null)
                    return els._Handle == _Handle;
                return false;
            }
            public bool IsHandle(EventBusHandle h)
            {
                return _Handle == h;
            }
            public bool IsHandle(LuaTable aLua, LuaEventBusHandle h)
            {
                return false;
            }
            public void Notify(EventBase evt)
            {
                _Handle(evt);
            }
        }
        class LuaEventListener : IEventListener
        {
            private static Stack<LuaEventListener> s_Pool = new Stack<LuaEventListener>();
            public static LuaEventListener Create(LuaTable aLua, LuaEventBusHandle h, ListenerOp opFlag)
            {
                var ls = s_Pool.Count == 0 ? new LuaEventListener() : s_Pool.Pop();
                ls.Reset(aLua, h, opFlag);
                return ls;
            }
            public static void Destroy(LuaEventListener ls)
            {
                ls.Reset(null, null, ListenerOp.Null);
                if (s_Pool.Count < 20)
                    s_Pool.Push(ls);
            }

            private LuaEventBusHandle _Handle;
            private LuaTable _Lua;
            private ListenerOp _OpFlag;
            private void Reset(LuaTable aLua, LuaEventBusHandle h, ListenerOp opFlag)
            {
                _Handle = h;
                _Lua = aLua;
                _OpFlag = opFlag;
            }
            public ListenerOp flag
            {
                get { return _OpFlag; }
            }
            public bool IsHandle(IEventListener ls)
            {
                LuaEventListener lusls = ls as LuaEventListener;
                if (lusls != null)
                    return lusls._Handle == _Handle;
                return false;
            }
            public bool IsHandle(EventBusHandle h)
            {
                return false;
            }
            public bool IsHandle(LuaTable aLua, LuaEventBusHandle h)
            {
                return _Handle == h;
            }
            public void Notify(EventBase evt)
            {
                _Handle(_Lua, evt);
            }
        }

        private List<IEventListener> _Listeners = new List<IEventListener>();
        private List<IEventListener> _ListToOp;
        private bool _Locked;
        private List<IEventListener> ListToOp
        {
            get
            {
                if (_ListToOp == null)
                    _ListToOp = new List<IEventListener>();
                return _ListToOp;
            }
        }
        public void AddHandle(EventBusHandle h)
        {
            if (_Locked)
            {
                ListToOp.Add(EventListener.Create(h, ListenerOp.Add));
            }
            else
            {
                _Listeners.Add(EventListener.Create(h, ListenerOp.Null));
            }
        }
        public void AddHandle(LuaTable lua, LuaEventBusHandle handle)
        {
            if (_Locked)
            {
                ListToOp.Add(LuaEventListener.Create(lua, handle, ListenerOp.Add));
            }
            else
            {
                _Listeners.Add(LuaEventListener.Create(lua, handle, ListenerOp.Null));
            }
        }
        public void DelHandle(EventBusHandle h)
        {
            if (_Locked)
            {
                ListToOp.Add(EventListener.Create(h, ListenerOp.Remove));
            }
            else
            {
                int i = 0;
                while (i < _Listeners.Count)
                {
                    var ls = _Listeners[i];
                    if (ls.IsHandle(h))
                    {
                        _Listeners.RemoveAt(i);
                        EventListener.Destroy(ls as EventListener);
                    }
                    else
                        ++i;
                }
            }
        }
        public void DelHandle(LuaTable lua, LuaEventBusHandle h)
        {
            if (_Locked)
            {
                ListToOp.Add(LuaEventListener.Create(lua, h, ListenerOp.Remove));
            }
            else
            {
                int i = 0;
                while (i < _Listeners.Count)
                {
                    var ls = _Listeners[i];
                    if (ls.IsHandle(lua, h))
                    {
                        _Listeners.RemoveAt(i);
                        LuaEventListener.Destroy(ls as LuaEventListener);
                    }
                    else
                        ++i;
                }
            }
        }
        public bool HasHandle(EventBusHandle h)
        {
            if (_ListToOp != null && _ListToOp.Count > 0)
            {//先看待处理的列表里是否有
                ListenerOp flag = ListenerOp.Null;
                for (int i = 0; i < _ListToOp.Count; ++i)
                {
                    var ls = _ListToOp[i];
                    if (ls.IsHandle(h))
                    {
                        flag = ls.flag;
                    }
                }
                if (flag == ListenerOp.Add)
                    return true;
                else if (flag == ListenerOp.Remove)
                    return false;
            }
            for (int idx = 0; idx < _Listeners.Count; idx++)
            {
                IEventListener ls = _Listeners[idx];
                if (ls.IsHandle(h))
                    return true;
            }
            return false;
        }
        public bool HasHandle(LuaTable lua, LuaEventBusHandle h)
        {
            if (_ListToOp != null && _ListToOp.Count > 0)
            {//先看待处理的列表里是否有
                ListenerOp flag = ListenerOp.Null;
                for (int i = 0; i < _ListToOp.Count; ++i)
                {
                    var ls = _ListToOp[i];
                    if (ls.IsHandle(lua, h))
                    {
                        flag = ls.flag;
                    }
                }
                if (flag == ListenerOp.Add)
                    return true;
                else if (flag == ListenerOp.Remove)
                    return false;
            }
            for (int idx = 0; idx < _Listeners.Count; idx++)
            {
                IEventListener ls = _Listeners[idx];
                if (ls.IsHandle(lua, h))
                    return true;
            }
            return false;
        }
        public void Notify(EventBase evt)
        {
            _Locked = true;
            for (int idx = 0; idx < _Listeners.Count; idx++)
            {
                IEventListener ls = _Listeners[idx];
                if (evt.canceled)
                    break;
                ls.Notify(evt);
            }
            _Locked = false;
            if (_ListToOp != null && _ListToOp.Count > 0)
            {
                for (int idx = 0; idx < _ListToOp.Count; idx++)
                {
                    IEventListener ls = _ListToOp[idx];
                    if (ls.flag == ListenerOp.Add)
                    {
                        _Listeners.Add(ls);
                    }
                    else
                    {
                        DelHandle(ls);
                    }
                }
                _ListToOp.Clear();
            }
        }
        private void DelHandle(IEventListener ls)
        {
            for (int i = 0; i < _Listeners.Count; ++i)
            {
                var cur = _Listeners[i];
                if (cur.IsHandle(ls))
                {
                    _Listeners.RemoveAt(i);
                    if (ls is EventListener)
                        EventListener.Destroy(ls as EventListener);
                    else
                        LuaEventListener.Destroy(ls as LuaEventListener);
                    break;
                }
            }
        }
    }

    /// <summary>
    /// 一个已经实现IEventBus接口的类
    /// </summary>
    /// 
    [CustomLuaClassAttribute]
    public class EventBus : IEventBus
    {
        private Dictionary<string, HandleBucket> _HandleBuckets;
        private IEventBus _Owner;
        /// <summary>
        /// 构建一个事件触发器
        /// </summary>
        /// <param name="aOwner">触发器拥有者，在触发器分发事件的时候，会将事件的sender设置为该拥有者，如果传递null，则触发器本身为自己的拥有者</param>
        public EventBus(IEventBus aOwner = null)
        {
            _Owner = aOwner == null ? this : aOwner;
        }

        /// <summary>
        /// 是否监听了某类事件
        /// </summary>
        /// <param name="eventType">事件类型</param>
        /// <returns></returns>
        public bool HasEvent(string eventType)
        {
            if (_HandleBuckets == null)
            {
                return false;
            }
            return _HandleBuckets.ContainsKey(eventType);
        }
        public bool HasListener(string eventType, EventBusHandle handle)
        {
            if (_HandleBuckets == null)
                return false;
            HandleBucket bkt;
            if (_HandleBuckets.TryGetValue(eventType, out bkt))
            {
                return bkt.HasHandle(handle);
            }
            return false;
        }
        public void AddListener(string eventType, EventBusHandle handle)
        {
            if (_HandleBuckets == null)
                _HandleBuckets = new Dictionary<string, HandleBucket>();
            HandleBucket bkt;
            if (!_HandleBuckets.TryGetValue(eventType, out bkt))
            {
                bkt = new HandleBucket();
                _HandleBuckets.Add(eventType, bkt);
            }
            bkt.AddHandle(handle);
        }
        public void RemoveListener(string eventType, EventBusHandle handle)
        {
            if (_HandleBuckets == null)
                return;
            HandleBucket bkt;
            if (_HandleBuckets.TryGetValue(eventType, out bkt))
            {
                bkt.DelHandle(handle);
            }
        }
        public bool HasDynamicListener(string eventType, LuaTable lua, LuaEventBusHandle handle)
        {
            if (_HandleBuckets == null)
                return false;
            HandleBucket bkt;
            if (_HandleBuckets.TryGetValue(eventType, out bkt))
            {
                return bkt.HasHandle(lua, handle);
            }
            return false;
        }
        public void AddDynamicListener(string eventType, LuaTable lua, LuaEventBusHandle handle)
        {
            if (_HandleBuckets == null)
                _HandleBuckets = new Dictionary<string, HandleBucket>();
            HandleBucket bkt;
            if (!_HandleBuckets.TryGetValue(eventType, out bkt))
            {
                bkt = new HandleBucket();
                _HandleBuckets.Add(eventType, bkt);
            }
            bkt.AddHandle(lua, handle);
        }
        public void RemoveDynamicListener(string eventType, LuaTable lua, LuaEventBusHandle handle)
        {
            if (_HandleBuckets == null)
                return;
            HandleBucket bkt;
            if (_HandleBuckets.TryGetValue(eventType, out bkt))
            {
                bkt.DelHandle(lua, handle);
            }
        }
        public void ClearAllListeners()
        {
            if (_HandleBuckets == null)
                return;
            _HandleBuckets.Clear();
        }
        public void DispatchEvent(EventBase evt)
        {
            if (_HandleBuckets != null)
            {
                HandleBucket bkt;
                if (_HandleBuckets.TryGetValue(evt.eventType, out bkt))
                {
                    evt._SetCurrentSender(_Owner);
                    bkt.Notify(evt);
                    evt._SetCurrentSender(null);
                }
            }
        }
    }
}
