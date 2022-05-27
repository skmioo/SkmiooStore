using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

namespace UnityEngine.Networking
{
    /// <summary>
    /// 内部的错误，如果抛出该错误，说明出现内部逻辑（而不是网络错误或者文件操作错误）
    /// </summary>
    class UnityLoadInnerExceptin : Exception
    {
        public UnityLoadInnerExceptin(string msg)
            : base(msg)
        { }
    }

    /// <summary>
    /// 资源加载器的状态枚举
    /// </summary>
    public enum UnityLoadState
    {
        /// <summary>
        /// 无状态，没有任何操作（调用Launch之前）
        /// </summary>
        Nil,
        /// <summary>
        /// http(s)协议头请求中（调用Launch之后，content-length回调触发之前，并且中间没有任何错误发生）
        /// </summary>
        Request,
        /// <summary>
        /// web资源内容传送中
        /// </summary>
        Content,
        /// <summary>
        /// web资源传送成功（整个文件或者页面传送完毕，并且写入到目标本地文件或者内存中）
        /// </summary>
        Success,
        /// <summary>
        /// 网络错误（来自于UnityWebRequest的错误）
        /// </summary>
        NetError,
        /// <summary>
        /// 本地读写错误（来自于读写本地文件或者内存的错误）
        /// </summary>
        IOError,
        /// <summary>
        /// 未知错误（其它逻辑错误）
        /// </summary>
        UnknownError,
        /// <summary>
        /// 即将重新连接（一个中间状态，标志不久即将尝试重新连接并下载）
        /// </summary>
        inner_Reconnnect,
        /// <summary>
        /// 触发一次进度变化（一个中间状态，标志马上触发一次下载进度变化）
        /// </summary>
        inner_Progress
    }

    /// <summary>
    /// 加载器触发的事件
    /// </summary>
    public enum UnityLoadStep
    {
        /// <summary>
        /// http头信息到来
        /// </summary>
        Header,
        /// <summary>
        /// http内容陆续到来（会被多次触发）
        /// </summary>
        Progress,
        /// <summary>
        /// 加载完毕（或者成功或者失败）
        /// </summary>
        Complete
    }

    /// <summary>
    /// 传给unity loader的加载信息
    /// </summary>
    public struct UnityLoadURL
    {
        /// <summary>
        /// 默认的超时间隔（秒）
        /// </summary>
        public const float c_DefaultTimeout = 15.0f;
        /// <summary>
        /// 默认的下载尝试次数
        /// </summary>
        public const int c_DefaultTryTimes = 2;
        /// <summary>
        /// 默认每下载512K就保存到文件
        /// </summary>
        public const long c_DefaultSaveThreshold = 512 * 1024;

        /// <summary>
        /// 请求的url地址，多个备用地址（至少一个）
        /// </summary>
        public string[] urls;
        /// <summary>
        /// post协议使用的提交信息（get协议为null）
        /// </summary>
        public WWWForm postForm;
        /// <summary>
        /// 每个url尝试的次数，小于等于0表示使用默认尝试次数
        /// </summary>
        public int eachTryTimes;
        /// <summary>
        /// 超时（秒），小于等于0表示使用默认超时设置
        /// </summary>
        public float timeout;
        /// <summary>
        /// 每下载给定字节就尝试保存到文件（小于等于0表示使用默认字节数）
        /// </summary>
        public long saveThreshold;
        /// <summary>
        /// 文件的最后输出地址（本地路径），null表示输出到内存中
        /// </summary>
        public string outPath;
        /// <summary>
        /// 用户数据
        /// </summary>
        public object userdata;
        /// <summary>
        /// 剩余尝试次数（内部使用）
        /// </summary>
        public int _TryTimesLeft;
        public UnityLoadURL(string[] aURLs, WWWForm aPostForm = null, string aLocalPath = null, float aTimeout = 0.0f, int aEachTryTimes = 0)
        {
            urls = aURLs;
            postForm = aPostForm;
            timeout = aTimeout;
            eachTryTimes = aEachTryTimes;
            outPath = aLocalPath;
            saveThreshold = 0;
            userdata = null;
            _TryTimesLeft = 0;
        }
        public UnityLoadURL(string aURL, WWWForm aPostForm = null, float aTimeout = 0.0f, int aEachTryTimes = 0, string aLocalPath = null)
        {
            urls = new string[] { aURL };
            postForm = aPostForm;
            timeout = aTimeout;
            eachTryTimes = aEachTryTimes;
            outPath = aLocalPath;
            saveThreshold = 0;
            userdata = null;
            _TryTimesLeft = 0;
        }
        /// <summary>
        /// 当前处理的url地址
        /// </summary>
        public string url
        {
            get
            {
                return urls[urlIdx];
            }
        }
        /// <summary>
        /// 当前处理的url的索引（第几个url）
        /// </summary>
        public int urlIdx
        {
            get
            {
                int idx = eachTryTimes * urls.Length - _TryTimesLeft;
                if (idx < 0)
                    idx = 0;
                idx = idx / eachTryTimes;
                if (idx >= urls.Length)
                    idx = urls.Length - 1;
                return idx;
            }
        }
        /// <summary>
        /// 判断给定的url是否与当前加载器信息关联
        /// </summary>
        /// <param name="aUrl"></param>
        /// <returns></returns>
        public bool EqualUrl(string aUrl)
        {
            for (int i = 0; i < urls.Length; ++i)
            {
                if (aUrl == urls[i])
                    return true;
            }
            return false;
        }
    }

    /// <summary>
    /// 一个支持http、https协议的web加载请求，封装UnityWebRequest
    /// </summary>
    public class UnityLoadRequest : IDisposable
    {
        /// <summary>
        /// 描述加载器状态
        /// </summary>
        /// <param name="st"></param>
        /// <returns></returns>
        public static string DescribeState(UnityLoadState st)
        {
            switch (st)
            {
                case UnityLoadState.Nil:
                    return "就绪";
                case UnityLoadState.Request:
                    return "连接中";
                case UnityLoadState.Content:
                    return "数据传输中";
                case UnityLoadState.inner_Progress:
                    return "数据传输中(进度触发)";
                case UnityLoadState.inner_Reconnnect:
                    return "尝试重连";
                case UnityLoadState.Success:
                    return "下载成功";
                case UnityLoadState.NetError:
                    return "网络错误";
                case UnityLoadState.IOError:
                    return "文件读写错误";
                case UnityLoadState.UnknownError:
                    return "逻辑错误";
                default:
                    return "未知状态";
            }
        }
        /// <summary>
        /// 判断给定的加载状态是否表示正在加载资源中
        /// </summary>
        /// <param name="st"></param>
        /// <returns></returns>
        public static bool IsLoadingState(UnityLoadState st)
        {
            return st == UnityLoadState.Request 
                || st == UnityLoadState.inner_Progress 
                || st == UnityLoadState.inner_Reconnnect 
                || st == UnityLoadState.Content;
        }

        /// <summary>
        /// 资源加载器状态变化的回调
        /// </summary>
        /// <param name="loader">资源加载器本身</param>
        /// <param name="evt">加载操作事件</param>
        /// <returns>返回false表示取消加载</returns>
        public delegate bool UnityLoadEventHandler(UnityLoadRequest loader, UnityLoadStep evt);

        /// <summary>
        /// 断点续传文件头标志
        /// </summary>
        private const long BreakpointFlag = 4321;

        /// <summary>
        /// 对文件的操作（因为文件操作容易抛出异常，所以实现统一的文件操作接口，方便调用）
        /// 多个操作可以按位组合
        /// </summary>
        private enum FileOp
        {
            /// <summary>
            /// 保持文件状态不变，不进行任何处理
            /// </summary>
            Keep = 1,
            /// <summary>
            /// 同步文件状态到硬盘
            /// </summary>
            Flush = 2,
            /// <summary>
            /// 关闭文件
            /// </summary>
            Close = 4,
            /// <summary>
            /// 删除文件
            /// </summary>
            Delete = 8,
            /// <summary>
            /// 移动文件（重命名文件）
            /// </summary>
            Move = 16
        }

        private UnityLoadURL _URL;
        private UnityLoadEventHandler _Callback;

        private UnityWebRequest _Request;
        private UnityLoadHandler _Handler;
        private static byte[] _LoadBuff;
        private float _LatestNetTime;

        private UnityLoadState _State;
        private string _Error;
        private long _HttpCode;

        private UnityByteBuff _MemBuf;

        private string _TmpPath;
        private string _BpPath;
        private Stream _OutStream;
        private Stream _BpStream;
        private long _Breakpoint;
        private long _ContentLength;

        private UnityLoadSpeedCalculator _SpeedCalculator;
        private bool _SimulateHeaderTrigger;
        /// <summary>
        /// 构造一个资源加载器
        /// </summary>
        /// <param name="url">加载信息（包括远程地址等）</param>
        /// <param name="callback">各种事件的回调函数</param>
        public UnityLoadRequest(UnityLoadURL url, UnityLoadEventHandler callback)
        {
            if(_LoadBuff == null)
            {
                _LoadBuff = new byte[1 * 1024 * 1024];
            }
            _SpeedCalculator = new UnityLoadSpeedCalculator();
            _SimulateHeaderTrigger = true;
            _State = UnityLoadState.Nil;
            _Callback = callback;
            _LatestNetTime = 0.0f;
            _URL = url;
            if (_URL.eachTryTimes <= 0)
            {//默认尝试一次
                _URL.eachTryTimes = UnityLoadURL.c_DefaultTryTimes;
            }
            _URL._TryTimesLeft = _URL.urls.Length * _URL.eachTryTimes;
            if (_URL.timeout <= 0)
            {//默认超时
                _URL.timeout = UnityLoadURL.c_DefaultTimeout;
            }
            if (_URL.saveThreshold <= 1024)
            {//默认断点间隔
                _URL.saveThreshold = UnityLoadURL.c_DefaultSaveThreshold;
            }
            if (_URL.outPath != null)
            {//临时文件路径
                _TmpPath = _URL.outPath + DRLoader.NetFrame.TempFileExt;
                _BpPath = _URL.outPath + DRLoader.NetFrame.BreakpointExt;
            }
        }
        ~UnityLoadRequest()
        {
            Dispose(false);
        }
        /// <summary>
        /// 停止下载并清理所有本地和网络资源，注意，调用该函数不会触发任何对外的回调时间
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }
        protected virtual void Dispose(bool disposing)
        {
            Cancel(false);
            _Callback = null;
            if (disposing)
            {//告诉垃圾回收器以后再也不要调用析构函数了
                GC.SuppressFinalize(this);
            }
        }
        /// <summary>
        /// 是否模拟http(s)头回调触发的行为（UnityWebRequest的实验版本并不触发http头回调）
        /// 如果要设置该属性，必须在Lanch调用之前，默认true
        /// </summary>
        public bool simulateHeaderTrigger
        {
            get { return _SimulateHeaderTrigger; }
            set { _SimulateHeaderTrigger = value; }
        }
        /// <summary>
        /// 当前设置的url
        /// </summary>
        public string url
        {
            get { return _URL.url; }
        }
        /// <summary>
        /// 所有的url源
        /// </summary>
        public string[] urls
        {
            get { return _URL.urls; }
        }
        /// <summary>
        /// 当前处理的url的索引
        /// </summary>
        public int urlIdx
        {
            get { return _URL.urlIdx; }
        }
        /// <summary>
        /// 判断给定的url是否对应当前的下载器
        /// </summary>
        /// <param name="aUrl"></param>
        /// <returns></returns>
        public bool EqualUrl(string aUrl)
        {
            return _URL.EqualUrl(aUrl);
        }
        /// <summary>
        /// 下载的目标路径（本地位置）
        /// </summary>
        public string outPath
        {
            get { return _URL.outPath; }
        }
        /// <summary>
        /// 中间文件使用的路径（临时）
        /// </summary>
        public string tempLocalPath
        {
            get { return _TmpPath; }
        }
        /// <summary>
        /// 记录断点续传信息的本地路径（临时）
        /// </summary>
        public string breakpointPath
        {
            get { return _BpPath; }
        }
        /// <summary>
        /// 当前设置的postform
        /// </summary>
        public WWWForm postForm
        {
            get { return _URL.postForm; }
        }
        /// <summary>
        /// 超时设置
        /// </summary>
        public float timeout
        {
            get { return _URL.timeout; }
            set
            {
                if (value <= 0.0f)
                    value = UnityLoadURL.c_DefaultTimeout;
                _URL.timeout = value;
            }
        }
        /// <summary>
        /// 超时倒计时
        /// </summary>
        public float timeoutCD
        {
            get
            {
                if (_State == UnityLoadState.Content
                    || _State == UnityLoadState.Request)
                {
                    var elp = Time.time - _LatestNetTime;
                    return elp > _URL.timeout ? elp - _URL.timeout : 0.0f;
                }
                return _URL.timeout;
            }
        }
        /// <summary>
        /// 剩余的尝试次数
        /// </summary>
        public int tryTimesLeft
        {
            get { return _URL._TryTimesLeft; }
        }
        /// <summary>
        /// 文件总长度
        /// </summary>
        public long contentLength
        {
            get { return _ContentLength; }
        }
        /// <summary>
        /// 当前下载的长度（包括之前的断点续传）
        /// </summary>
        public long downloadLength
        {
            get
            {
                try
                {
                    if (_OutStream != null)
                        return _OutStream.Position;
                    else if (_MemBuf != null)
                        return _MemBuf.position;
                    else
                        return 0;
                }
                catch (Exception e)
                {
                    _Error = e.ToString();
                    _HttpCode = 0;
                    _State = UnityLoadState.IOError;
                    return 0;
                }
            }
        }
        /// <summary>
        /// 当前下载进度
        /// </summary>
        public float progress
        {
            get { return contentLength == 0 ? 0.0f : downloadLength / (float)contentLength; }
        }
        /// <summary>
        /// 当前下载的断点续传位置（实时变化）
        /// </summary>
        public long breakpoint
        {
            get { return _Breakpoint; }
        }
        /// <summary>
        /// 断点续传进度
        /// </summary>
        public float breakpointProgress
        {
            get { return contentLength == 0 ? 0.0f : breakpoint / (float)contentLength; }
        }
        /// <summary>
        /// 下载速度
        /// </summary>
        public float speed
        {
            get { return _SpeedCalculator.speed; }
        }
        /// <summary>
        /// 当前的即时下载速度
        /// </summary>
        public float nowSpeed
        {
            get { return _SpeedCalculator.nowSpeed; }
        }
        /// <summary>
        /// 页面内容（当outPath参数为null时有效）
        /// </summary>
        public string pageContent
        {
            get
            {
                if (_MemBuf != null)
                {
                    var oldPos = _MemBuf.position;
                    _MemBuf.position = 0;
                    var str = _MemBuf.ReadString(oldPos, -1);
                    _MemBuf.position = oldPos;
                    return str;
                }
                return null;
            }
        }
        /// <summary>
        /// 页面内容（当outPath参数为null时有效）
        /// </summary>
        public byte[] pageData
        {
            get
            {
                if (_MemBuf != null)
                    return _MemBuf.ToArray();
                return null;
            }
        }
        /// <summary>
        /// 用户数据
        /// </summary>
        public object userdata
        {
            get { return _URL.userdata; }
        }
        /// <summary>
        /// 当前的加载状态
        /// </summary>
        public UnityLoadState state
        {
            get { return _State; }
        }
        /// <summary>
        /// 错误信息，如果没有就返回null（没有错误信息不表示加载成功）
        /// </summary>
        public string lastError
        {
            get { return _Error; }
        }
        /// <summary>
        /// http协议返回码
        /// </summary>
        public long httpCode
        {
            get { return _HttpCode; }
        }
        /// <summary>
        /// 获取下载器信息
        /// </summary>
        /// <param name="detailed">是否相信信息</param>
        /// <param name="sb">目标字符串构建器（如果不为null，则会将新的字符串添加进去，保留已有的）</param>
        /// <returns>下载器信息</returns>
        public string BuildInfo(bool detailed, StringBuilder sb = null)
        {
            if (sb == null)
                sb = new StringBuilder();
            int prePos = sb.Length;
            if (detailed)
            {
                sb.Append("-- 加载器详细信息 --");
                sb.AppendFormat("\n状态[{0}]：{1}", (int)state, DescribeState(state));
                sb.AppendFormat("\nhttp返回码：{0}", httpCode);
                sb.AppendFormat("\n超时等待：{0:0.0}/{1:0.0}", timeoutCD, timeout);
                sb.AppendFormat("\n地址：{0}", url);
                sb.AppendFormat("\n下载进度：{0:0.0}kb/{1:0.0}kb({2:0.00}%)", downloadLength / 1024.0f, contentLength / 1024.0f, progress * 100.0f);
                sb.AppendFormat("\n下载速度：{0}kb/s - {1}kb/s", (int)(speed / 1024.0f), (int)(nowSpeed / 1024.0f));
                if (outPath != null)
                {
                    sb.AppendFormat("\n本地路径：{0}", outPath);
                    sb.AppendFormat("\n本地临时路径：{0}", tempLocalPath);
                    sb.AppendFormat("\n断点信息路径：{0}", breakpointPath);
                    sb.AppendFormat("\n断点续传：{0:0.0}kb({1:0.00}%)", breakpoint / 1024.0f, breakpointProgress * 100.0f);
                }
                sb.AppendFormat("\n协议头模拟触发：{0}", simulateHeaderTrigger);
                if (lastError != null)
                    sb.AppendFormat("\n错误：{0}", lastError);
            }
            else
            {
                sb.AppendFormat("信息：{0} {1:0.0}kb/{2:0.0}kb/{3:0.0}kb", DescribeState(_State), breakpoint / 1024.0f, downloadLength / 1024.0f, contentLength / 1024.0f);
            }
            return sb.ToString(prePos, sb.Length - prePos);
        }

        /// <summary>
        /// 开始加载
        /// </summary>
        public void Launch()
        {
            //先结束
            Cancel(false);

            _MemBuf = null;
            _Error = null;
            _HttpCode = 0;
            _State = UnityLoadState.Request;
            _LatestNetTime = Time.time;
            if (_URL._TryTimesLeft > 0)
                --_URL._TryTimesLeft;
            ReadBreakpoint(out _Breakpoint, out _ContentLength);
            try
            {
                //回调器
                _Handler = new UnityLoadHandler(_LoadBuff, HandleContentLength, HandleContent);
                if (_URL.postForm == null)
                {//get
                    _Request = new UnityWebRequest(_URL.url, UnityWebRequest.kHttpVerbGET, null, null);
                }
                else
                {//post
                    _Request = UnityWebRequest.Post(_URL.url, _URL.postForm);
                }
                _Request.downloadHandler = _Handler;
                _Request.disposeDownloadHandlerOnDispose = true;
                _Request.SetRequestHeader("Range", string.Format("bytes={0}-", _Breakpoint));
                _Request.Send();
            }
            catch (Exception e)
            {//出错，把状态设置为失败，在下次循环的时候，会调用shutdown
                _Error = e.ToString();
                _HttpCode = 0;
                _State = UnityLoadState.NetError;
            }
        }
        /// <summary>
        /// 停止下载
        /// </summary>
        public void Shutdown()
        {
            if (!IsLoadingState(state))
            {//没有在下载中，忽略
                return;
            }
            _State = UnityLoadState.UnknownError;
            _Error = "canceled";
            Cancel(true);
        }
        /// <summary>
        /// 每帧驱动
        /// </summary>
        public void Update()
        {
            if (_State == UnityLoadState.inner_Reconnnect)
            {//重新连接
                Launch();
                return;
            }
            if (_Request == null)
            {//已经结束，并且已经清理
                return;
            }
            if (_State == UnityLoadState.inner_Progress)
            {//下载进度
                _State = UnityLoadState.Content;
                if (!NotifyEvent(UnityLoadStep.Progress))
                    Cancel(true);
                return;
            }   
            if (_State == UnityLoadState.Success)
            {//结束状态，需要清理
                Cancel(true);
                return;
            }
            if (_State == UnityLoadState.NetError)
            {//网络错误
                if (_URL._TryTimesLeft > 0)
                {//尝试再重试
                    Launch();
                }
                else
                {//重试次数已用完
                    Cancel(true);
                }
                return;
            }
            if (_State == UnityLoadState.IOError || _State == UnityLoadState.UnknownError)
            {//其它错误，不再尝试重试
                Cancel(true);
                return;
            }
            if (_Request.isNetworkError)
            {//出错，需要结束
                _Error = _Request.error;
                _HttpCode = _Request.responseCode;
                _State = UnityLoadState.NetError;
                if (_URL._TryTimesLeft > 0)
                    Launch();
                else
                    Cancel(true);
                return;
            }
            if (_State == UnityLoadState.Request && _SimulateHeaderTrigger)
            {//请求http头信息中
                var headers = _Request.GetResponseHeaders();
                if (headers != null)
                {
                    _HttpCode = _Request.responseCode;
                    string lenStr;
                    int len = 0;
                    if (headers.TryGetValue("Content-Length", out lenStr))
                        int.TryParse(lenStr, out len);
                    _Handler.ReceiveResponse(len);
                    return;
                }
            }
            if (_LatestNetTime + _URL.timeout < Time.time)
            {//超时
                _HttpCode = 0;
                _Error = "request timeout";
                _State = UnityLoadState.NetError;
                if (_URL._TryTimesLeft > 0)
                    Launch();
                else
                    Cancel(true);
                return;
            }
        }

        /// <summary>
        /// 停止下载并清理内部占用资源（但下载器的对外状态和数据保留）
        /// </summary>
        /// <param name="evtTrigger">是否触发事件</param>
        private void Cancel(bool evtTrigger)
        {
            _SpeedCalculator.Reset();
            if (_Handler != null)
            {//清理回调函数，防止在析构request的时候触发不希望的回调
                _Handler.ClearCallbacks();
                _Handler = null;
            }
            if (_Request != null)
            {//清理http request
                _Request.Abort();
                _Request.Dispose();
                _Request = null;
            }
            if (_State == UnityLoadState.Success)
            {//下载成功
                ApplyFileOp(ref _BpStream, _BpPath, FileOp.Delete);
                if (!ApplyFileOp(ref _OutStream, _TmpPath, FileOp.Move | FileOp.Delete, _URL.outPath))
                {//拷贝失败
                    _HttpCode = 0;
                    _Error = "copy file failed";
                    _State = UnityLoadState.IOError;
                }
            }
            else
            {//其它情况，直接关闭文件即可
                //临时文件关闭
                ApplyFileOp(ref _OutStream, _TmpPath, FileOp.Close);
                //断点续传信息文件关闭
                ApplyFileOp(ref _BpStream, _BpPath, FileOp.Close);
            }
            if (evtTrigger)
            {//触发结束事件
                NotifyEvent(UnityLoadStep.Complete);
            }
        }
        private bool HandleContentLength(long length)
        {
            _LatestNetTime = Time.time;
            if (_ContentLength != 0 && _ContentLength != length + _Breakpoint)
            {//断点数据不吻合，需要重新下载
                ClearTempFile();
                _Breakpoint = 0;
                _ContentLength = 0;
                _State = UnityLoadState.inner_Reconnnect;
                return false;
            }
            _State = UnityLoadState.Content;
            _ContentLength = length + _Breakpoint;
            if (!NotifyEvent(UnityLoadStep.Header))
            {//强制结束
                _Error = "canceled";
                _State = UnityLoadState.UnknownError;
                return false;
            }
            if (_TmpPath != null)
            {//输出到文件
                try
                {
                    _OutStream = new FileStream(_TmpPath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    if (_OutStream.Length < _Breakpoint)
                    {//断点续传数据不吻合
                        ClearTempFile();
                        _Breakpoint = 0;
                        _ContentLength = 0;
                        _State = UnityLoadState.inner_Reconnnect;
                        return false;
                    }
                    else
                        _OutStream.Seek(_Breakpoint, SeekOrigin.Begin);
                }
                catch (Exception e)
                {
                    ClearTempFile();
                    _HttpCode = 0;
                    _Error = e.ToString();
                    _State = UnityLoadState.IOError;
                    return false;
                }
            }
            else
            {//写到内存
                _MemBuf = new UnityByteBuff();
                _MemBuf.Clear();
            }
            return true;
        }
        private bool HandleContent(byte[] data, int dataLength, bool complete)
        {
            if (_State == UnityLoadState.Request && _SimulateHeaderTrigger)
            {//头还未到
                long len = 0;
                var lenstr = _Request.GetResponseHeader("Content-Length");
                if (lenstr != null)
                    long.TryParse(lenstr, out len);
                _Handler.ReceiveResponse((int)len);
            }
            if (_State != UnityLoadState.Content
                && _State != UnityLoadState.inner_Progress)
            {//状态不对
                return false;
            }
            _LatestNetTime = Time.time;
            if (data == null || dataLength == 0 || data.Length < dataLength)
            {//数据为空
                //触发下载完成事件
                if (complete)
                {
                    _HttpCode = 0;
                    _Error = null;
                    _State = UnityLoadState.Success;
                }
                return true;
            }
            try
            {
                _SpeedCalculator.RecordSpeed(dataLength);
                if (_OutStream != null)
                {//写入文件
                    //_OutStream.Write(data, 0, dataLength);
                    if (complete || _OutStream.Position - _Breakpoint >= _URL.saveThreshold)
                    {//每过一段时间保存到文件并记录断点
                        //_OutStream.Flush();
                        _Breakpoint = _OutStream.Position;
                        string error;
                        //if (!WriteBreakpoint(out error, _Breakpoint, _ContentLength, FileOp.Flush))
                        //{
                        //    throw new Exception(string.Format("write breakpoint failed: {0}", error));
                        //}
                    }
                }
                else if (_MemBuf != null)
                {//写入内存
                    _MemBuf.WriteBytes(data, 0, dataLength);
                    _Breakpoint = _MemBuf.position;
                }
                else
                {//无处可写，出错
                    throw new UnityLoadInnerExceptin("no where to write for UnityLoader");
                }
                //设置为进度触发状态
                _State = UnityLoadState.inner_Progress;
                //触发下载完成事件
                if (complete)
                {
                    _HttpCode = 0;
                    _Error = null;
                    _State = UnityLoadState.Success;
                }
                return true;
            }
            catch (UnityLoadInnerExceptin ie)
            {
                _HttpCode = 0;
                _Error = ie.ToString();
                _State = UnityLoadState.UnknownError;
                return false;
            }
            catch (Exception e)
            {//io错误，需要清理断点续传数据
                ClearTempFile();
                _HttpCode = 0;
                _Error = e.ToString();
                _State = UnityLoadState.IOError;
                return false;
            }
        }
        private bool NotifyEvent(UnityLoadStep evt)
        {
            return _Callback == null || _Callback(this, evt);
        }

        private void ClearTempFile()
        {
            ApplyFileOp(ref _OutStream, _TmpPath, FileOp.Delete);
            ApplyFileOp(ref _BpStream, _BpPath, FileOp.Delete);
            _Breakpoint = 0;
            _ContentLength = 0;
        }
        private bool ReadBreakpoint(out long bp, out long len, FileOp op = FileOp.Keep)
        {
            string error;
            return ReadBreakpoint(out error, out bp, out len, op);
        }
        private bool ReadBreakpoint(out string error, out long bp, out long len, FileOp op = FileOp.Keep)
        {
            bp = 0;
            len = 0;
            error = null;
            if (_BpPath == null)
            {
                error = "no break point path";
                return false;
            }
            try
            {
                if (_BpStream == null)
                    _BpStream = new FileStream(_BpPath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                _BpStream.Seek(0, SeekOrigin.Begin);
                BinaryReader sr = new BinaryReader(_BpStream);
                if (sr.ReadInt64() != BreakpointFlag)
                    throw new UnityLoadInnerExceptin("bp content error");
                bp = sr.ReadInt64();
                len = sr.ReadInt64();
                return ApplyFileOp(out error, ref _BpStream, _BpPath, op);
            }
            catch (Exception e)
            {
                ApplyFileOp(ref _BpStream, _BpPath, FileOp.Delete);
                error = e.ToString();
                bp = 0;
                len = 0;
                return false;
            }
        }
        private bool WriteBreakpoint(long bp, long len, FileOp op = FileOp.Flush)
        {
            string error;
            return WriteBreakpoint(out error, bp, len, op);
        }
        private bool WriteBreakpoint(out string error, long bp, long len, FileOp op = FileOp.Flush)
        {
            if (_BpPath == null)
            {
                error = "no breakpoint path";
                return false;
            }
            error = null;
            try
            {
                if (_BpStream == null)
                    _BpStream = new FileStream(_BpPath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                _BpStream.Seek(0, SeekOrigin.Begin);
                BinaryWriter sw = new BinaryWriter(_BpStream);
                sw.Write(BreakpointFlag);
                sw.Write(bp);
                sw.Write(len);
                return ApplyFileOp(out error, ref _BpStream, _BpPath, op);
            }
            catch (Exception e)
            {
                ApplyFileOp(ref _BpStream, _BpPath, FileOp.Delete);
                error = e.ToString();
                return false;
            }
        }
        private bool ApplyFileOp(ref Stream stream, string path, FileOp op, string destPath = null)
        {
            string error;
            return ApplyFileOp(out error, ref stream, path, op, destPath);
        }
        private bool ApplyFileOp(out string error, ref Stream stream, string path, FileOp op, string destPath = null)
        {
            bool ret = true;
            error = null;
            if (stream != null)
            {
                try
                {
                    if ((op & FileOp.Flush) != 0)
                    {
                        stream.Flush();
                    }
                    if ((op & FileOp.Close) != 0
                        || (op & FileOp.Delete) != 0)
                    {
                        stream.Close();
                        stream = null;
                    }
                }
                catch (Exception e)
                {
                    error = e.ToString();
                    try
                    {
                        if (stream != null)
                            stream.Close();
                    }
                    catch (Exception ie)
                    {
                        if (error == null)
                            error = ie.ToString();
                    }
                    stream = null;
                    ret = false;
                }
            }
            if ((op & FileOp.Move) != 0 && path != null)
            {
                try
                {
                    if (File.Exists(destPath))
                        File.Delete(destPath);
                    if (File.Exists(path))
                        File.Move(path, destPath);
                    else
                        throw new Exception("source file not exist");
                }
                catch (Exception e)
                {
                    error = e.ToString();
                    ret = false;
                }
            }
            if ((op & FileOp.Delete) != 0 && path != null)
            {
                try
                {
                    if (File.Exists(path))
                        File.Delete(path);
                }
                catch (Exception e)
                {
                    error = e.ToString();
                    ret = false;
                }
            }
            return ret;
        }
    }
}
