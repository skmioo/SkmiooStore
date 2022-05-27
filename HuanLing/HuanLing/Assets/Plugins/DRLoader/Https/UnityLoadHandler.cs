using System;

namespace UnityEngine.Networking
{
    /// <summary>
    /// 简单实现UnityWebRequest的下载回调接口
    /// </summary>
    class UnityLoadHandler : DownloadHandlerScript
    {
        /// <summary>
        /// 协议头到来的回调：包含即将要下载的数据长度
        /// </summary>
        /// <param name="length">内容总的长度</param>
        /// <returns>返回值无意义</returns>
        public delegate bool OnHttpContentLength(long length);
        /// <summary>
        /// 内容回调：下载一定内容，就回调一部分
        /// </summary>
        /// <param name="data">内容字节</param>
        /// <param name="dataLength">内容字节数</param>
        /// <param name="complete">下载是否完成</param>
        /// <returns>继续下载返回true，否则返回false</returns>
        public delegate bool OnHttpContent(byte[] data, int dataLength, bool complete);

        private OnHttpContentLength cbHttpContentLength;
        private OnHttpContent cbHttpContent;
        private long _ContentLength;
        private long _ContentLoaded;
        private bool _HeaderArrived;
        /// <summary>
        /// 构造一个loader的同时就给两个回调函数，必须给定
        /// </summary>
        /// <param name="httpContentLengthHandler">协议头的回调</param>
        /// <param name="httpContentHandler">协议内容的回调</param>
        public UnityLoadHandler(OnHttpContentLength httpContentLengthHandler, OnHttpContent httpContentHandler)
        {
            cbHttpContentLength = httpContentLengthHandler;
            cbHttpContent = httpContentHandler;
            _HeaderArrived = false;
        }
        public UnityLoadHandler(byte[] buff, OnHttpContentLength httpContentLengthHandler, OnHttpContent httpContentHandler)
            :base(buff)
        {
            cbHttpContentLength = httpContentLengthHandler;
            cbHttpContent = httpContentHandler;
            _HeaderArrived = false;
        }
        /// <summary>
        /// 清理所有回调函数
        /// </summary>
        public void ClearCallbacks()
        {
            cbHttpContent = null;
            cbHttpContentLength = null;
        }
        /// <summary>
        /// 要下载的内容的总长度，在协议头返回之前为0
        /// </summary>
        public long contentLength
        {
            get { return _ContentLength; }
        }
        /// <summary>
        /// 已经下载的内容字节数
        /// </summary>
        public long contentLoaded
        {
            get { return _ContentLoaded; }
        }
        /// <summary>
        /// 这个函数注意：当前UnityWebRequest有问题，它不会触发ReceiveContentLength回调，所以在外部两个地方会尝试调用该函数从而模拟触发ReceiveContentLength的回调：
        /// 1. 帧循环的时候，如果能够从UnityWebRequest里获取的http(s)协议头，说明网络已经返回content-length数据，可以触发了；
        /// 2. 在content数据第一次到达的时候，可以尝试查看协议头是否到达，并在处理content数据之前模拟触发一次content-length回调
        /// </summary>
        /// <param name="contentLen"></param>
        public void ReceiveResponse(int contentLen)
        {
            ReceiveContentLength(contentLen);
        }
        protected override float GetProgress()
        {
            return _ContentLength == 0 ? 0 : _ContentLoaded / _ContentLength;
        }
        protected override byte[] GetData()
        {
            return null;
        }
        protected override string GetText()
        {
            return "";
        }
        protected override void ReceiveContentLength(int contentLen)
        {
            if (!_HeaderArrived || contentLen != _ContentLength)
            {
                _HeaderArrived = true;
                _ContentLength = contentLen;
                if (cbHttpContentLength != null)
                    cbHttpContentLength(_ContentLength);
            }
        }
        protected override bool ReceiveData(byte[] data, int dataLength)
        {
            _ContentLoaded += dataLength;
            if (cbHttpContent != null)
                return cbHttpContent(data, dataLength, false);
            return false;
        }
        protected override void CompleteContent()
        {
            if (cbHttpContent != null)
                cbHttpContent(null, 0, true);
        }
    }
}
