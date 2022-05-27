using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using SLua;

namespace UYMO
{
    [CustomLuaClass]
    [AddComponentMenu("YUI/YLuaScriptUI", 20)]
    public class YLuaScriptUI : MonoBehaviour, IClearable
    {
        /// <summary>
        /// 使用的lua脚本
        /// </summary>
        public LuaTable luaScript
        { get; set; }
        /// <summary>
        /// lua脚本类名称
        /// </summary>
        public string luaScriptName
        {
            get 
            {
                if (luaScript == null)
                    return "";
                return luaScript["__Name"] as string; 
            }
        }

        [SerializeField]
        private float _Frequency = 0.1f;
        /// <summary>
        /// update的调用频率
        /// </summary>
        public float frequency
        {
            get { return _Frequency; }
            set { _Frequency = value; }
        }

        [SerializeField]
        private bool _Pause = false;
        /// <summary>
        /// 刷新是否暂停
        /// </summary>
        public bool pause
        {
            get { return _Pause; }
            set { _Pause = value; }
        }

        private float _LastUpdTime = 0.0f;

        void OnEnable()
        {
            CallLuaFunc("OnEnable");
        }
        void OnDisable()
        {
            CallLuaFunc("OnDisable");
        }
        void OnDestroy()
        {
            Clear();
        }
        void Update()
        {
            if (pause)
                return;
            if (Time.time - _LastUpdTime < _Frequency)
                return;
            _LastUpdTime = _Frequency;
            CallLuaFunc("OnUpdate");
        }
        public void Clear()
        {
            if (luaScript != null)
            {
                CallLuaFunc("OnDestroy");
                luaScript = null;
            }
        }
        void CallLuaFunc(string funcName)
        {
            if (luaScript == null)
                return;
            try
            {
                luaScript.tryInvoke(funcName, luaScript);
            }
            catch (Exception e)
            {
                Debug.LogErrorFormat("luaScript[{0}] error: {1}", luaScriptName, e.ToString());
            }
        }
    }
}
