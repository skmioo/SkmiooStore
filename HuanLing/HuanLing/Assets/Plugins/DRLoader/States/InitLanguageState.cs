using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using UYMO;
using UnityEngine;

namespace DRLoader
{
    /// <summary>
    /// 初始化语言包
    /// </summary>
    class InitLanguageState : GameUpdateSate
    {
        LoadUI _UI;
        WWW _Loader;
        bool _Complete;
        public bool complete
        {
            get
            {
                return _Complete;
            }
        }

        public void Enter(LoadUI ui, object preData)
        {
            _UI = ui;
            _UI.loadInfo = StringTrans.T("初始化语言包...");
            string path = System.IO.Path.Combine(Application.persistentDataPath + "/ExtRes", StringTrans.LanPackName);
            if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor)
            {
                path = System.IO.Path.Combine("./Data/ExtRes", StringTrans.LanPackName);
                path = Path.GetFullPath(path);
            }
            if (File.Exists(path))
            {
                path = "file://" + path;
            }
            else
            {
                path = System.IO.Path.Combine(Application.streamingAssetsPath, StringTrans.LanPackName);
                if (Application.platform != RuntimePlatform.Android)
                {
                    path = "file://" + path;
                }
            }
            try
            {
                _Loader = new WWW(path);
            }
            catch
            {
                Debug.Log("No language pack!");
                _Complete = true;
            }
            
        }

        public object Exit()
        {
            return null;
        }

        public void Update()
        {
            if(_Loader != null && _Loader.isDone )
            {
                if( string.IsNullOrEmpty(_Loader.error))
                {
                    StringTrans.ReloadLanPack(_Loader.bytes);
                }
                else
                {
                    Debug.LogWarningFormat("load language error:{0}", _Loader.error);
                }
                _Complete = true;
            }
        }
    }
}
