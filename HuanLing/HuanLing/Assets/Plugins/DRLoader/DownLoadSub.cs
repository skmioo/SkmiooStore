using System;
using System.IO;
using System.Net;
using System.Threading;
using UnityEngine;

namespace DRLoader
{
    /// <summary>
    /// 下载线，下载不大于2.1G的文件（C#版本限制）2147483648byte
    /// </summary>
    class DownLoadSub
    {
        /// <summary>
        /// 下载线索引
        /// </summary>
        int _Idx;
        /// <summary>
        /// 下载地址
        /// </summary>
        string _Url;
        /// <summary>
        /// 缓存
        /// </summary>
        byte[] _Cache1;
        byte[] _Cache2;
        byte[] _LoadingCache;


        LoadedData _Loaded;

        /// <summary>
        /// 缓存使用量
        /// </summary>
        int _CacheUsed;

        /// <summary>
        /// 掉线尝试次数
        /// </summary>
        uint _RetryCount;
        /// <summary>
        /// 下载的开始位置
        /// </summary>
        long _Begin;
        /// <summary>
        /// 下载内容的总长度
        /// </summary>
        long _TotalLength;
        /// <summary>
        /// 已经下载的长度
        /// </summary>
        long _LoadedLength;
        /// <summary>
        /// 是否暂停
        /// </summary>
        bool _InPause;

        HttpWebResponse _Response;
        Stream _SrcStream;

        int _Speed;

        Thread _LoadThread;
        object _AsynLock;

        public DownLoadSub(int idx, string url, long begin, long length, long savedLength, uint retry = uint.MaxValue)
        {
            _Idx = idx;
            _Url = url;
            _Begin = begin;
            _TotalLength = length;
            _LoadedLength = savedLength;
            _RetryCount = retry;
            _Cache1 = new byte[1 * 1024 * 1024];
            _Cache2 = new byte[1 * 1024 * 1024];
            _CacheUsed = 0;
            _LoadingCache = _Cache1;
            _Loaded = new LoadedData();
            _Loaded.savedLength = savedLength;

            _InPause = false;

            _AsynLock = new object();
            _LoadThread = new Thread(HandleDownLoad);
            _LoadThread.Start();
        }

        public int index
        {
            get
            {
                return _Idx;
            }
        }

        public LoadedData loaded
        {
            get
            {
                lock(_Loaded)
                {
                    return _Loaded.length == 0 ? null : _Loaded;
                }
            }
        }

        public long begin
        {
            get
            {
                return _Begin;
            }
        }

        public long loadedLength
        {
            get
            {
                return _LoadedLength;
            }
        }

        public long totalLength
        {
            get
            {
                return _TotalLength;
            }
        }

        public bool allSaved
        {
            get
            {
                return _Loaded.savedLength >= _TotalLength;
            }
        }

        bool complete
        {
            get
            {
                return _LoadedLength >= _TotalLength;
            }
        }
        /// <summary>
        /// 速度 byte/s
        /// </summary>
        public int speed
        {
            get
            {
                return _Speed;
            }
        }
        /// <summary>
        /// 暂停下载
        /// </summary>
        public void Pause()
        {
            _InPause = true;
        }
        /// <summary>
        /// 继续下载
        /// </summary>
        public void Goon()
        {
            _InPause = false;
        }

        private void Close()
        {
            if (_SrcStream != null)
            {
                _SrcStream.Close();
                _SrcStream = null;
            }
            if (_Response != null)
            {
                _Response.Close();
                _Response = null;
            }
            _Speed = 0;
        }

        DateTime _Pretime = DateTime.Now;
        int _LoadPerSecond;
        public void HandleDownLoad()
        {
            while (true)
            {
                try
                {
                    Close();
                    HttpWebRequest request = HttpWebRequest.Create(_Url) as HttpWebRequest;
                    request.Timeout = 20000;
                    request.AddRange((int)(_Begin + _LoadedLength), (int)(_Begin + _TotalLength - 1));
                    _Response = request.GetResponse() as HttpWebResponse;
                    _SrcStream = _Response.GetResponseStream();

                    while (!complete && !_InPause)
                    {
                        int osize = _SrcStream.Read(_LoadingCache, _CacheUsed, _LoadingCache.Length - _CacheUsed);
                        if (osize > 0)
                        {
                            _LoadedLength += osize;
                            _CacheUsed += osize;
                            _LoadPerSecond += osize;
                        }

                        DateTime cur = DateTime.Now;
                        TimeSpan pass = cur - _Pretime;
                        if( pass.TotalSeconds >= 1 )
                        {
                            _Speed = (int)((double)_LoadPerSecond / pass.TotalSeconds);
                            _LoadPerSecond = 0;
                            _Pretime = cur;
                        }

                        if (_CacheUsed >= _LoadingCache.Length || complete )
                        {
                            while (true)
                            {
                                if (_Loaded.length == 0)
                                {
                                    lock (_Loaded)
                                    {
                                        _Loaded.data = _LoadingCache;
                                        _Loaded.length = _CacheUsed;
                                    }
                                    break;
                                }
                            }
                            _LoadingCache = _LoadingCache == _Cache1 ? _Cache2 : _Cache1;
                            _CacheUsed = 0;
                        }
                    }
                }
                catch
                {
                }

                if (complete)
                {
                    Close();
                    break;
                }
            }
        }
    }

    class LoadedData
    {
        public byte[] data;
        public int length;
        public long savedLength;

        public void MarkGeted()
        {
            data = null;
            savedLength += length;
            length = 0;
        }
    }
}
