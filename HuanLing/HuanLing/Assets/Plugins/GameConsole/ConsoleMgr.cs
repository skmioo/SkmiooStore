using UnityEngine;

namespace UYMO.GameConsole
{
    public class ConsoleMgr
    {
        static GameObject sConsoleRoot;
        
        /// <summary>
        /// 获取调试窗口
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T FetchDlg<T>() where T : ConsoleDlgBase
        {
            return FetchDlg(typeof(T)) as T;
        }

        public static ConsoleDlgBase FetchDlg(System.Type type)
        {
            ConsoleDlgBase ret = null;
            if (sConsoleRoot == null)
            {
                sConsoleRoot = new GameObject("ConsoleRoot");
                U3DUtil.DontDestroyOnLoad(sConsoleRoot);
            }
            else
            {
                ret = sConsoleRoot.GetComponent(type) as ConsoleDlgBase;
            }

            if (ret == null)
            {
                ret = sConsoleRoot.AddComponent(type) as ConsoleDlgBase;
                ret.Init(sConsoleRoot.transform);
            }
            return ret;
        }
        /// <summary>
        /// 获取调试窗口
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T TryGetDlg<T>()where T:ConsoleDlgBase
        {
            return sConsoleRoot == null ? null : sConsoleRoot.GetComponent<T>();
        }
        /// <summary>
        /// 关闭调试窗口
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void CloseDlg<T>() where T:ConsoleDlgBase
        {
            var dlg = TryGetDlg<T>();
            if(dlg != null)
            {
                dlg.Close();
            }
            return;
        }
    }
}
