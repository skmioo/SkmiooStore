using System;
using UnityEngine;
#if UNITY_IOS
using System.Runtime.InteropServices;
#endif
namespace UYMO
{
    public class ShareImpl
    {
#if UNITY_IOS && !UNITY_EDITOR
		[DllImport("__Internal")]
		public static extern void WXShareImage(string imagePath);

        [DllImport("__Internal")]
        public static extern void SaveInPhotoAlbum(string imageName);


        public static void InitWeChatShareSDK(string appid)
        {

        }

        public static void WeChatShareText(string content)
        {

        }

        public static void WeChatShareImage(string imagePath)
        {
			Debug.Log("微信分享图片");
			WXShareImage(imagePath);
        }

        public static bool SavePhotoInPhone(Texture2D tex,string path)
        {
            Debug.Log("IOS保存图片进相册");
            System.IO.File.WriteAllBytes(path, tex.EncodeToPNG());
            SaveInPhotoAlbum(path);
            return false;
        }
#elif UNITY_ANDROID && !UNITY_EDITOR
        public static void InitWeChatShareSDK(string appid)
        {
            Debug.Log("初始化微信分享SDK");
            try
            {
                AndroidJavaClass jc = new AndroidJavaClass("com.uye.Share.WXShare");
                jc.CallStatic("Init", appid);
            }
            catch(Exception e)
            {
                Debug.LogErrorFormat("初始化微信分享失败!{0}", e);
            }
        }

        public static void WeChatShareText(string content)
        {
            Debug.Log("微信分享文字");
            try
            {
                AndroidJavaClass jc = new AndroidJavaClass("com.uye.Share.WXShare");
                jc.CallStatic("ShareText", content);
            }
            catch(Exception e)
            {
                Debug.LogErrorFormat("微信分享文字失败!{0}", e);
            }
        }

        public static void WeChatShareImage(string imagePath)
        {
            Debug.Log("微信分享图片");
            try
            {
                AndroidJavaClass jc = new AndroidJavaClass("com.uye.Share.WXShare");
                jc.CallStatic("ShareImage", imagePath);
            }
            catch(Exception e)
            {
                Debug.LogErrorFormat("微信分享图片失败!{0}", e);
            }

        }

        public static bool SavePhotoInPhone(Texture2D tex,string path)
        {
            Debug.Log("Android保存图片进相册");
            System.IO.File.WriteAllBytes(path, tex.EncodeToPNG());
            AndroidJavaClass jc = new AndroidJavaClass("com.uye.Share.PhotoShare");
            jc.CallStatic("SavePhotoInPhone", path);
            return true;
        }
#else
        public static void InitWeChatShareSDK(string appid)
        {

        }

        public static void WeChatShareText(string content)
        {

        }

        public static void WeChatShareImage(string imagePath)
        {

        }

        public static bool SavePhotoInPhone(Texture2D tex,string path)
        {
            System.IO.File.WriteAllBytes(path, tex.EncodeToPNG());
            return true;
        }
#endif
    }
}
