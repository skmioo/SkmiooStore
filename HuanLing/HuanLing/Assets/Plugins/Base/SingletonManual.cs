using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SLua;

namespace UYMO
{
    /// <summary>
    /// 单例类，需要手动初始化
    /// </summary>
    public class SingletonManual<T> where T : SingletonManual<T>
    {
        private static T sm_Me;
        public SingletonManual()
        {
            if (sm_Me != null)
            {
                throw new Exception(typeof(T).ToString() + "constructed twice!");
            }
            sm_Me = (T)this;
        }
        public static T me
        {
            get
            {
                if (sm_Me == null)
                {
                    throw new NullReferenceException( typeof(T).ToString()+"not constructed yet!");
                }
                return sm_Me;
            }
        }
        public static T TryGetInstance()
        {
            return sm_Me;
        }

#if UNITY_EDITOR
        public static void Destroy()
        {
            sm_Me = null;
        }
#endif
    }

    /// <summary>
    /// 单例类：手动初始化，拥有EventBus功能
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SingletonManualEvtBus<T> : IEventBus where T : SingletonManualEvtBus<T>
    {
        private static T sm_Me;
        public static T me
        {
            get
            {
                if (sm_Me == null)
                {
                    throw new NullReferenceException( typeof(T).ToString()+"not constructed yet!");
                }
                return sm_Me;
            }
        }
        public static T TryGetInstance()
        {
            return sm_Me;
        }

        private EventBus _EventBus;
        public SingletonManualEvtBus()
        {
            if (sm_Me != null)
            {
                throw new Exception(typeof(T).ToString() + "constructed twice!");
            }
            sm_Me = (T)this;
            _EventBus = new EventBus(this);
        }
        public void AddListener(string eventType, EventBusHandle handle)
        {
            _EventBus.AddListener(eventType, handle);
        }
        public void RemoveListener(string eventType, EventBusHandle handle)
        {
            _EventBus.RemoveListener(eventType, handle);
        }
        public bool HasListener(string eventType, EventBusHandle handle)
        {
            return _EventBus.HasListener(eventType, handle);
        }
        public void AddDynamicListener(string eventType, LuaTable lua, LuaEventBusHandle handle)
        {
            _EventBus.AddDynamicListener(eventType, lua, handle);
        }
        public void RemoveDynamicListener(string eventType, LuaTable lua, LuaEventBusHandle handle)
        {
            _EventBus.RemoveDynamicListener(eventType, lua, handle);
        }
        public bool HasDynamicListener(string eventType, LuaTable lua, LuaEventBusHandle handle)
        {
            return _EventBus.HasDynamicListener(eventType, lua, handle);
        }
        public void ClearAllListeners()
        {
            _EventBus.ClearAllListeners();
        }
        public void DispatchEvent(EventBase evt)
        {
            _EventBus.DispatchEvent(evt);
        }
    }
}
