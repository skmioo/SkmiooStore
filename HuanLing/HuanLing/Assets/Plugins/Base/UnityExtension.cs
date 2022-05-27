using System;
using System.Collections.Generic;

namespace UnityEngine
{
    /// <summary>
    /// Unity类的一些扩展函数定义
    /// </summary>
    [SLua.CustomLuaClass]
    public static class UnityExtension
    {
        static List<HotComponent> sRet;
        /// <summary>
        /// 获取热更组件
        /// </summary>
        /// <typeparam name="T">组件类型</typeparam>
        /// <param name="gameObject">GameObject对象</param>
        /// <returns></returns>
        public static T GetHotComponent<T>(this GameObject gameObject)where T:HotComponent
        {
            return gameObject.GetHotComponent(typeof(T)) as T;
        }
        /// <summary>
        /// 获取热更组件
        /// </summary>
        /// <param name="gameObject">GameObject对象</param>
        /// <param name="type">组件类型</param>
        /// <returns></returns>
        public static HotComponent GetHotComponent(this GameObject gameObject, Type type)
        {
            if (!type.IsSubclassOf(typeof(HotComponent)))
            {
                throw new InvalidProgramException(string.Format("just for get the hot component!"));
            }
            HotMonoBehaviour[] hmbs = gameObject.GetComponents<HotMonoBehaviour>();
            for(var idx = 0; idx <hmbs.Length; ++idx )
            {
                if(hmbs[idx].componentType == type)
                {
                    return hmbs[idx].component;
                }
            }
            return null;
        }
        /// <summary>
        /// 获取所有指定类型的热更组件
        /// </summary>
        /// <typeparam name="T">组件类型</typeparam>
        /// <param name="gameObject">GameObject对象</param>
        /// <returns></returns>
        public static HotComponent[] GetHotComponents<T>(this GameObject gameObject) where T : HotComponent
        {
            return gameObject.GetHotComponents(typeof(T));
        }
        /// <summary>
        /// 获取所有指定类型的热更组件
        /// </summary>
        /// <param name="gameObject">GameObject对象</param>
        /// <param name="type">组件类型</param>
        /// <returns></returns>
        public static HotComponent[] GetHotComponents(this GameObject gameObject, Type type)
        {
            if(!type.IsSubclassOf(typeof(HotComponent)))
            {
                throw new InvalidProgramException(string.Format("just for get the hot component!"));
            }
            if(sRet == null)
            {
                sRet = new List<HotComponent>();
            }
            else
            {
                sRet.Clear();
            }
            HotMonoBehaviour[] hmbs = gameObject.GetComponents<HotMonoBehaviour>();
            for (var idx = 0; idx < hmbs.Length; ++idx)
            {
                if (hmbs[idx].componentType == type)
                {
                    sRet.Add(hmbs[idx].component);
                }
            }
            return sRet.ToArray();
        }

        public static HotComponent AddHotComponent<T>(this GameObject gameObject)where T:HotComponent
        {
            return gameObject.AddHotComponent(typeof(T));
        }

        public static HotComponent AddHotComponent(this GameObject gameObject, Type t )
        {
            if (!t.IsSubclassOf(typeof(HotComponent)))
            {
                throw new InvalidProgramException(string.Format("just for add hot component!"));
            }
            HotMonoBehaviour hmb = gameObject.AddComponent<HotMonoBehaviour>();
            hmb.SetBhaviourClass(t.FullName);
            return hmb.component;
        }
    }
}
