using UnityEngine;

namespace UYMO
{
    public class SystemSettingForJava
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        public static void SetBGUrl(string url)
        {
            using (AndroidJavaClass systemSetting = new AndroidJavaClass("com.uye.system.SystemSetting"))
            {
                systemSetting.CallStatic("SetBackgroundUrl", url);
            }
        }
#else
        public static void SetBGUrl(string url)
        {
        }
#endif
    }
}
