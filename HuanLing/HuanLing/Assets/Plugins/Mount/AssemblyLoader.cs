using System;
using System.Text;
using System.Reflection;
using UnityEngine;
using System.IO;
using System.Security.Cryptography;

namespace UYMO
{
    public enum AssemblyPosition
    {
        Auto,
        Native,
        ExtFile
    }
    //dll加载
    public class AssemblyLoader
    {
        string _Path;
        string _Name;
        WWW _Loader;
        Assembly _Assemble;
        string _MD5;
        bool _LoadFromFile;

        /// <summary>
        /// 构造一个dll加载器
        /// </summary>
        /// <param name="filePath">dll外部路径</param>
        /// <param name="assembleName">dll名称</param>
        /// <param name="pos">指定强制的加载位置，默认为自动</param>
        public AssemblyLoader(string filePath, string assembleName, AssemblyPosition pos = AssemblyPosition.Auto)
        {
            _Path = filePath;
            _Name = assembleName;
            if (Boot.LocalBake)
            {//本地烧制调试，不更新在线的dll代码
                pos = AssemblyPosition.Native;
            }
            switch (pos)
            {
                case AssemblyPosition.Native:
                    LoadFromNative();
                    break;
                case AssemblyPosition.ExtFile:
                    LoadFromFile();
                    break;
                case AssemblyPosition.Auto:
#if UNITY_ANDROID && !UNITY_EDITOR//只有android才可从外部文件加载dll
                    LoadFromFile();
#else
                    LoadFromNative();
#endif
                    break;
            }
        }

        public void Update()
        {
            if (_Loader != null && _Loader.isDone)
            {
                if (String.IsNullOrEmpty(_Loader.error))
                {

                    byte[] dllData = _Loader.bytes;
                    _MD5 = ByteArrayToHexString(dllData);
                    try
                    {//尝试解压
                        MemoryStream archive = new MemoryStream(_Loader.bytes);
                        ICSharpCode.SharpZipLib.Zip.ZipConstants.DefaultCodePage = System.Text.Encoding.Default.CodePage;
                        ICSharpCode.SharpZipLib.Zip.ZipInputStream zip = new ICSharpCode.SharpZipLib.Zip.ZipInputStream(archive);
                        var entry = zip.GetNextEntry();

                        byte[] data = new byte[entry.Size];
                        int readed = 0;
                        while (true)
                        {
                            int size = zip.Read(data, readed, data.Length - readed);
                            readed += size;
                            if (size <= 0)
                            {
                                break;
                            }
                        }
                        dllData = data;
                        zip.Dispose();
                        archive.Close();
                    }
                    catch
                    {
                        Debug.Log("failed try to decompress the data! it must be a unzip data!");
                        dllData = _Loader.bytes;
                    }

                    _Assemble = System.Reflection.Assembly.Load(dllData);
                    if (_Assemble == null)
                    {
                        throw new InvalidOperationException("Can't Load " + _Name);
                    }
                }
                else
                {
                    Debug.LogErrorFormat("Load {0} failed! path:{1}", _Name, _Path);
                }
                
                _Loader.Dispose();
                _Loader = null;
            }
        }

        public Assembly assemble
        {
            get
            {
                return _Assemble;
            }
        }

        public string md5
        {
            get
            {
                return _MD5;
            }
        }

        public bool isLoadFromFile
        {
            get
            {
                return _LoadFromFile;
            }
        }

        void LoadFromNative()
        {
            Debug.LogFormat("Load assemble {0} from native!", _Name);
            _LoadFromFile = false;
            System.Reflection.Assembly[] ams = AppDomain.CurrentDomain.GetAssemblies();
            for (int idx = 0; idx < ams.Length; ++idx)
            {
                var am = ams[idx];
                if (am.FullName.IndexOf(_Name) != -1)
                {
                    _Assemble = am;
                    break;
                }
            }
            if (_Assemble == null)
            {
                throw new InvalidOperationException("Can't find " + _Name);
            }
        }

        void LoadFromFile()
        {
            Debug.LogFormat("Load assemble {0} from file!", _Name);
            _LoadFromFile = true;
            try
            {
                _Loader = new WWW(_Path);
            }
            catch (Exception e)
            {
                Debug.LogErrorFormat("Load DLL failed! {0}", e.ToString());
            }
        }


        public static string ByteArrayToHexString(byte[] data)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            md5.Initialize();

            byte[] bytes = md5.ComputeHash(data);
            md5.Clear();

            StringBuilder sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString().ToLower();
        }
    }
}
