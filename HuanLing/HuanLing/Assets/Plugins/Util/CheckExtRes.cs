using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.IO;

namespace UYMO
{
    /// <summary>
    /// 检查外部资源
    /// </summary>
    public class CheckExtRes
    {
        Action _Action;
        long _ExtVer;
        string _ExtDirPath;
        WWW _Loader;
        public CheckExtRes(Action callback)
        {
            _Action = callback;
            string extVerPath = System.IO.Path.Combine(Application.persistentDataPath + "/ExtRes", ".version");
            if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor)
            {
                extVerPath = System.IO.Path.Combine("./Data/ExtRes", ".version");
                extVerPath = Path.GetFullPath(extVerPath);
            }

            _ExtDirPath = Path.GetDirectoryName(extVerPath);

            if ( !File.Exists(extVerPath ))
            {
                Done();
                return;
            }

            try
            {
                FileStream ver = new FileStream(extVerPath, FileMode.Open, FileAccess.Read);
                BinaryReader reader = new BinaryReader(ver);
                sbyte branch = reader.ReadSByte();
                _ExtVer = reader.ReadInt64();
                Debug.LogFormat("ExtVer:{0}", _ExtVer);
                reader.Close();
                ver.Close();
            }
            catch(Exception e)
            {
                Debug.LogErrorFormat("Read extversion failed!\n{0}", e);
                Directory.Delete(_ExtDirPath, true);
                Done();
                return;
            }

            string verPath = System.IO.Path.Combine(Application.streamingAssetsPath, "version.ab");
            if (Application.platform != RuntimePlatform.Android)
            {
                verPath = "file://" + verPath;
            }

            try
            {
                _Loader = new WWW(verPath);
            }
            catch(Exception e )
            {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
                Debug.LogErrorFormat("Failed to load version.ab!\n{0}\n{1}", verPath, e);
#endif
                Done();
                return;
            }
        }

        public void Update()
        {
            if( _Loader != null && _Loader.isDone )
            {
                if( string.IsNullOrEmpty(_Loader.error))
                {
                    try
                    {
                        StringReader reader = new StringReader(_Loader.text);
                        long ver = MathUtil.ParseLong(reader.ReadLine());
                        reader.Close();
                        Debug.LogFormat("InnerVer:{0}", ver);
                        if(ver >= _ExtVer )
                        {
                            Debug.Log("Clear ext res!");
                            Directory.Delete(_ExtDirPath, true);
                        }
                    }
                    catch(Exception e)
                    {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
                        Debug.LogErrorFormat("Failed to load version.ab!\n url:{0}\n{1}", _Loader.url, e);
#endif
                    }
                }
                else
                {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
                    Debug.LogErrorFormat("Failed to load version.ab!\n url:{0}\n{1}", _Loader.url, _Loader.error);
#endif
                }
                _Loader.Dispose();
                _Loader = null;
                Done();
            }
        }

        void Done()
        {
            var temp = _Action;
            _Action = null;
            if( temp != null)
            {
                temp();
            }
        }
    }
}
