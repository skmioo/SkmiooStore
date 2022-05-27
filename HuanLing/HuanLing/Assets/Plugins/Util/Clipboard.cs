using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System;

namespace UYMO
{
	public class Clipboard
	{
#if UNITY_IPHONE&&!UNITY_EDITOR
		/* Interface to native implementation */
		[DllImport ("__Internal")]
		private static extern void _setTextToClipboard(string text);
		[DllImport("__Internal")]
		private static extern string _getTextFromClipboard ();
#elif UNITY_ANDROID && !UNITY_EDITOR
		static AndroidJavaClass _Clipboard;
        private static void _setTextToClipboard(string text)
        {
            try
            {
                clipboard.CallStatic("SetTextToClipboard", text);
            }
            catch(Exception e)
            {
                Debug.LogFormat("Set clipboard failed!\n{0}", e);
            }
        }
        private static string _getTextFromClipboard()
        {
            try
            {
                return clipboard.CallStatic<string>("GetTextFromClipboard");
            }
            catch (Exception e)
            {
                Debug.LogFormat("Get clipboard failed!\n{0}", e);
            }
            return "";
        }

        static AndroidJavaClass clipboard
        {
            get
            {
                if(_Clipboard == null)
                {
                    _Clipboard = new AndroidJavaClass("com.uye.system.Clipboard");
                }
                return _Clipboard;
            }
        }
#else
        private static void _setTextToClipboard(string text)
        {
            TextEditor te = new TextEditor();
            te.text = text;
            te.OnFocus();
            te.Copy();
        }
        private static string _getTextFromClipboard()
        {
            return "";
        }
#endif

        public static string text
		{
			get
			{
				return _getTextFromClipboard();
			}
			set
			{
				_setTextToClipboard(value);
			}
		}
	}
}