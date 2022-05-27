using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
#if UNITY_IOS
using System.Runtime.InteropServices;
#endif

namespace UYMO
{
    /// <summary>
    /// 获取设备信息的相关接口
    /// </summary>
    [SLua.CustomLuaClass]
    public class DeviceImpl
    {
#if UNITY_IOS && !UNITY_EDITOR
        /// 获取手机型号
        [DllImport("__Internal")]
        public static extern string GetPhoneModel();
        
        // 获取操作系统版本名
        [DllImport("__Internal")]
        public static extern string GetOSVersion();

        /// 获取运营商
        [DllImport("__Internal")]
        public static extern string GetTeleOperator();

        /// 获取网络类型
        [DllImport("__Internal")]
        public static extern string GetNetType();

        /// 获取设备分辨率 w*h
        [DllImport("__Internal")]
        public static extern string GetResolution();

#elif UNITY_ANDROID && !UNITY_EDITOR
        static AndroidJavaClass _DeviceInfoCls;
        static AndroidJavaClass deviceInfoCls
        {
            get
            {
                if (_DeviceInfoCls == null)
                {
                    _DeviceInfoCls = new AndroidJavaClass("com.uye.system.DeviceInfo");
                }
                return _DeviceInfoCls;
            }
        }
        /// <summary>
        /// 获取手机型号
        /// </summary>
        /// <returns></returns>
        public static string GetPhoneModel()
        {
            try
            {
                return deviceInfoCls.CallStatic<string>("getModel");
            }
            catch
            {
                return "unknown";
            }
        }
        /// <summary>
        /// 获取操作系统版本名
        /// </summary>
        /// <returns></returns>
        public static string GetOSVersion()
        {
            try
            {
                return deviceInfoCls.CallStatic<string>("getOSVersion");
            }
            catch
            {
                return "unknown";
            }
        }

        /// <summary>
        /// 获取运营商
        /// </summary>
        /// <returns></returns>
        public static string GetTeleOperator()
        {
            try
            {
                return deviceInfoCls.CallStatic<string>("getTeleOperator");
            }
            catch
            {
                return "unknown";
            }
        }

        /// <summary>
        /// 获取网络类型
        /// </summary>
        /// <returns></returns>
        public static string GetNetType()
        {
            try
            {
                return deviceInfoCls.CallStatic<string>("getNetType");
            }
            catch
            {
                return "unknown";
            }
        }

        /// <summary>
        /// 获取设备分辨率 w*h
        /// </summary>
        /// <returns></returns>
        public static string GetResolution()
        {
            try
            {
                return deviceInfoCls.CallStatic<string>("getSolution");
            }
            catch
            {
                return string.Format("{0}*{1}", Screen.currentResolution.width, Screen.currentResolution.height);
            }
        }
#else
        /// <summary>
        /// 获取手机型号
        /// </summary>
        /// <returns></returns>
        public static string GetPhoneModel()
        {
            return "unknown";
        }
        /// <summary>
        /// 获取操作系统版本名
        /// </summary>
        /// <returns></returns>
        public static string GetOSVersion()
        {
            return "unknown";
        }

        /// <summary>
        /// 获取运营商
        /// </summary>
        /// <returns></returns>
        public static string GetTeleOperator()
        {
            return "unknown";
        }

        /// <summary>
        /// 获取网络类型
        /// </summary>
        /// <returns></returns>
        public static string GetNetType()
        {
            return "unknown";
        }

        /// <summary>
        /// 获取设备分辨率 w*h
        /// </summary>
        /// <returns></returns>
        public static string GetResolution()
        {
            return string.Format("{0}*{1}", Screen.currentResolution.width, Screen.currentResolution.height);
        }
#endif

    }
}
