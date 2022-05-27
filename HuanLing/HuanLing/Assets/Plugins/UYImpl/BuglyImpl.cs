using System;
#if UNITY_IOS
using System.Runtime.InteropServices;
#endif
using UnityEngine;

namespace UYMO
{
    public class BuglyImpl
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        public static void SetAppVersion(string appID)
        {
            try
            {
                AndroidJavaClass jc = new AndroidJavaClass("com.uye.bugly.Bugly");
                jc.CallStatic("SetAppVersion", appID);
            }
            catch(Exception e)
            {
                Debug.LogWarningFormat("SetAppVersion Error:{0}", e);
            }
        }

        public static void OpenOrCloseCrashReport(bool open)
        {
            try
            {
                AndroidJavaClass jc = new AndroidJavaClass("com.uye.bugly.Bugly");
                jc.CallStatic("OpenOrCloseCrashReport", open);
            }
            catch (Exception e)
            {
                Debug.LogWarningFormat("OpenOrCloseCrashReport Error:{0}", e);
            }
        }

        public static void SetUserName(string userName)
        {
            try
            {
                AndroidJavaClass jc = new AndroidJavaClass("com.uye.bugly.Bugly");
                jc.CallStatic("SetUserName", userName);
            }
            catch (Exception e)
            {
                Debug.LogWarningFormat("SetUserID Error:{0}", e);
            }
        }
#elif UNITY_IOS && !UNITY_EDITOR
        [DllImport("__Internal")]
        public static extern void SetAppVersion(string appID);
        public static void OpenOrCloseCrashReport(bool open)
        {
        }
        public static void SetUserName(string userName)
        {
            BuglyAgent.SetUserId(userName);
        }
#else
        public static void SetAppVersion(string appID)
        {
            Debug.Log("SetAppVersion not support!"+ appID);
        }
        public static void OpenOrCloseCrashReport(bool open)
        {
        }
        public static void SetUserName(string userName)
        {
            Debug.Log("SetUserName not support!");
        }
#endif
    }
}
