using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SLua;

namespace UYMO
{
    /// <summary>
    /// 普通单例,会自动初始化对象
    /// </summary>
    /// <typeparam name="T">单例类</typeparam>
    public class SingletonAuto<T> where T : SingletonAuto<T>, new()
    {
        private static T _instance;
        public static T me
        {
            get
            {
                if( _instance == null )
                {
                    _instance = new T();
                }
                return _instance;
            }
        }
        public static T TryGetInstance()
        {
            return _instance;
        }
        public static void Destroy()
        {
            if (_instance != null)
            {
                _instance.OnDestroy();
                _instance = null;
            }
        }
        public SingletonAuto()
        {
            if (_instance != null)
            {
                throw new Exception(typeof(T).ToString() + "constructed twice!");
            }
            _instance = (T)this;
        }
        /// <summary>
        /// 清理时的处理
        /// </summary>
        protected virtual void OnDestroy()
        {
        }
    }

    /// <summary>
    /// 普通单例,会自动初始化对象，拥有EventBus功能
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SingletonAutoEvtBus<T> : IEventBus where T : SingletonAutoEvtBus<T>, new()
    {
        private static T _instance;
        public static T me
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new T();
                }
                return _instance;
            }
        }
        public static T TryGetInstance()
        {
            return _instance;
        }

        private EventBus _EventBus;
        public SingletonAutoEvtBus()
        {
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
