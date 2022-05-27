using System;
using System.Collections.Generic;
using UYMO;
using DRLoader.Http;

namespace DRLoader
{
    /// <summary>
    /// http/https单线程下载器
    /// </summary>
    public class HttpLoader : INetLoader
    {
        class HttpItem
        {
            public string[] urls;
            public int curSrc;
            public PostForm form;
            public string savePath;
            public bool breadkPoint;
            public Action<INetResult> callback;
            public void Clear()
            {
                urls = null;
                form = null;
                savePath = null;
                breadkPoint = true;
                callback = null;
            }
        }

        Queue<HttpItem> _ItemPool = new Queue<HttpItem>();
        Queue<HttpItem> _WaitLoads = new Queue<HttpItem>();
        HttpItem _Loading;

        NetLoadState _Step = NetLoadState.Requesting;
        HttpRequest _Request;
        Action<bool, string> _RequestHandler;
        HttpSave _Save;
        string _Error;

        bool _Pausing = false;


        public HttpLoader()
        {
            _RequestHandler = new Action<bool, string>(HandleRequestReturn);
        }
        /// <summary>
        /// 加载一个http地址
        /// </summary>
        /// <param name="url">http地址</param>
        /// <param name="breakPoint">是否要求断点续传</param>
        /// <param name="savePath">加载内容保存路径，若为null则保存在内存</param>
        /// <param name="complete">加载完成回调</param>
        /// <param name="form">post请求时的表单</param>
        public void Load(string[] url, string savePath, Action<INetResult> complete, PostForm form = null)
        {
            HttpItem item = _ItemPool.Count > 0 ? _ItemPool.Dequeue() : new HttpItem();
            item.Clear();
            item.urls = url;
            item.curSrc = 0;
            item.form = form;
            item.savePath = savePath;
            item.breadkPoint = true;
            item.callback = complete;
            _WaitLoads.Enqueue(item);

            if (_Loading == null)
            {
                LoadNext();
            }
        }

        /// <summary>
        /// 取消下载
        /// </summary>
        /// <param name="url">下载地址</param>
        public void CancelLoad(string url)
        {
            CancelLoad(new string[] { url });
        }
        /// <summary>
        /// 取消下载
        /// </summary>
        /// <param name="urls">下载地址</param>
        public void CancelLoad(string[] urls)
        {
            CancelLoads(new string[][] { urls });
        }
        /// <summary>
        /// 取消一组下载
        /// </summary>
        /// <param name="urlList">下地地址链接</param>
        public void CancelLoads(string[] urlList)
        {
            string[][] urlsList = new string[urlList.Length][];
            for (var idx = 0; idx < urlList.Length; ++idx)
            {
                urlsList[idx] = new string[] { urlList[idx] };
            }
            CancelLoads(urlsList);
        }
        /// <summary>
        /// 取消一组下载
        /// </summary>
        /// <param name="urlsList">下地地址链接</param>
        public void CancelLoads(string[][] urlsList)
        {
            if(urlsList == null || urlsList.Length == 0 )
            {
                return;
            }

            Queue<HttpItem> newWaits = new Queue<HttpItem>();
            var en = _WaitLoads.GetEnumerator();
            while(en.MoveNext())
            {
                HttpItem item = en.Current;
                bool needRemv = DiStrArrayContain(urlsList, item.urls);
                
                if(!needRemv)
                {
                    newWaits.Enqueue(item);
                }
            }
            _WaitLoads = newWaits;

            if(_Loading != null && DiStrArrayContain(urlsList, _Loading.urls) )
            {
                _Save.Dispose();
                _Save = null;
                _Request.DoneRequest();
                _ItemPool.Enqueue(_Loading);
                _Loading = null;
                LoadNext();
            }
        }


        public bool pause
        {
            get
            {
                return _Pausing;
            }
            set
            {
                if (_Pausing != value)
                {
                    _Pausing = value;
                    if (_Pausing)
                    {
                        if (_Loading != null)
                        {
                            _Request.DoneRequest();
                            _Save.pause = true;
                        }
                    }
                    else
                    {
                        if (_Loading == null)
                        {//当前没有在下载，尝试启动下一个
                            LoadNext();
                        }
                        else
                        {//重新请求源
                            _Save.pause = false;
                            TrySrc(false);
                        }
                    }
                }
            }
        }

        public long speed
        {
            get
            {
                return _Save == null ? 0 : _Save.speed;
            }
        }

        public float progress
        {
            get
            {
                return _Save == null ? 0 : _Save.progress;
            }
        }

        public long loaded
        {
            get
            {
                return _Save == null ? 0 : _Save.received;
            }
        }
        public long length
        {
            get
            {
                return _Save == null ? 0 : _Save.length;
            }
        }

        public bool loading
        {
            get
            {
                return _Loading != null;
            }
        }

        public NetLoadState state
        {
            get
            {
                return _Step;
            }
        }

        public int curSrcIndex
        {
            get
            {
                return _Loading == null ? 0 : _Loading.curSrc;
            }
        }

        void LoadNext()
        {
            if(_WaitLoads.Count <= 0 )
            {
                return;
            }
            _Loading = _WaitLoads.Dequeue();
            if(_Request ==null)
            {
                _Request = new HttpRequest();
            }
            _Save = new HttpSave(_Loading.savePath, _Loading.breadkPoint);
            TrySrc(false);
        }

        void TrySrc(bool next)
        {
            if(next)
            {
                ++_Loading.curSrc;
            }

            if(_Loading.curSrc < _Loading.urls.Length)
            {//还有其它源可尝试
                _Step = NetLoadState.Requesting;
                if (_Loading.form == null)
                {
                    _Request.Request(_Loading.urls[_Loading.curSrc], (int)_Save.received, _RequestHandler);
                }
                else
                {
                    _Request.RequestPost(_Loading.urls[_Loading.curSrc], _Loading.form, (int)_Save.received, _RequestHandler);
                }
            }
            else
            {//所有源都尝试过了
                Done(false);
            }
        }

        void HandleRequestReturn(bool success, string error)
        {
            if(success)
            {
                if(_Save.hasBegin ? _Save.ResetRev(_Request): _Save.BeginReceive(_Request))
                {
                    _Step = NetLoadState.Transfering;
                }
                else
                {//源与当前的接收不匹配，重置了接收，并且重新请求
                    _Error = _Save.error;
                    _Request.DoneRequest();
                    TrySrc(false);
                }
            }
            else
            {//当前的源不可用，尝试下一个
                _Error = error;
                _Request.DoneRequest();
                TrySrc(true);
            }
        }

        public void Update()
        {
            switch (_Step)
            {
                case NetLoadState.Requesting:
                    if (_Request != null)
                    {
                        _Request.Update();
                    }
                    break;
                case NetLoadState.Transfering:
                    if (_Save.ReceiveData())
                    {
                        if (_Save.complete)
                        {
                            Done(true);
                        }
                    }
                    else
                    {
                        _Error = _Save.error;
                        _Request.DoneRequest();
                        TrySrc(true);
                    }
                    break;
            }
        }


        void Done(bool success)
        {
            _Request.DoneRequest();
            _Step = NetLoadState.Complete;

            HttpResult result = new HttpResult();
            result.success = success;
            result.msg = _Error;
            result.urls = _Loading.urls;
            result.path = _Loading.savePath;
            result.data = success ? _Save.data : null;
            var temp = _Loading.callback;

            if (_Save != null)
            {
                _Save.Dispose();
                _Save = null;
            }
            _ItemPool.Enqueue(_Loading);
            _Loading = null;
            LoadNext();

            if (temp != null)
            {//通知
                temp(result);
            }
        }

        /// <summary>
        /// 当前加载的错误信息
        /// </summary>
        public string error
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// 判断两个字符串数组的内容是否完全一样，只在数组内无相同无素的情况下适用
        /// </summary>

        public static bool SameStrArray(string[] a, string[] b)
        {
            if (a == b)
            {
                return true;
            }
            if( a == null || b == null)
            {
                return false;
            }
            if (a.Length != b.Length)
            {
                return false;
            }
            for(var idx = 0; idx < a.Length; ++idx )
            {
                if(b.IndexOf(a[idx]) == -1 )
                {
                    return false;
                }
            }
            return true;
        }

        public static bool DiStrArrayContain(string[][] diStrArray, string[] item)
        {
            for (var idx = 0; idx < diStrArray.Length; ++idx)
            {
                if (SameStrArray(diStrArray[idx], item))
                {
                    return true;
                }
            }
            return false;
        }
    }

    public struct HttpResult: INetResult
    {
        /// <summary>
        /// 下载是否成功
        /// </summary>
        public bool success { get; set; }
        /// <summary>
        /// 下载失败时的错误消息，没有为null
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 下载地址
        /// </summary>
        public string[] urls { get; set; }
        /// <summary>
        /// 下载到文件时存储路径
        /// </summary>
        public string path { get; set; }
        /// <summary>
        /// 下载到内存时下载好的数据
        /// </summary>
        public byte[] data { get; set; }
        /// <summary>
        /// 获取下载的文本，只有下载到内存时有效，使用UTF-8编码
        /// </summary>
        public string text
        {
            get
            {
                return GetText(System.Text.Encoding.UTF8);
            }
        }

        public string GetText(System.Text.Encoding encode)
        {
            if (data == null && path != null)
            {
                throw new InvalidOperationException(string.Format("Loaded data has save to {0}, not support parse it as text, please read it yourself!", path));
            }
            return encode.GetString(data);
        }
    }
}
