using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO;
using System.Text;
using UnityEngine;

namespace DRLoader.Http
{
    class HttpRequest
    {
        enum RequestStep
        {
            Ruesting,
            Complete,
            Done,
        }
        HttpWebRequest _Request;
        HttpWebResponse _Response;

        string _Url;
        PostForm _Form;
        int _Pos;
        byte[] _PostData;
        Action<bool, string> _CompleteCallback;
        float _TimeOut = 6f;
        float _StartTime = 0;

        RequestStep _Step;
        string _Error;
        public void Request(string url, int pos, Action<bool, string> callback)
        {
            if(_Request!= null)
            {
                throw new InvalidOperationException("Request is running, please waite it complete!");
            }
            try
            {
                _Url = url;
                _Pos = pos;
                _CompleteCallback = callback;
                _Step = RequestStep.Ruesting;
                _Error = null;
                _Request = HttpWebRequest.Create(_Url) as HttpWebRequest;
                _Request.AddRange(_Pos);
                _Request.Timeout = (int)(_TimeOut * 1000);
                _Request.KeepAlive = false;
                _StartTime = Time.time;
                _Request.BeginGetResponse(new AsyncCallback(GetResponseCallback), _Request);
            }
            catch (Exception e)
            {
                MarkComplete(e.ToString());
            }
        }

        public void RequestPost(string url, PostForm form, int pos, Action<bool, string> callback)
        {
            if (_Request != null)
            {
                throw new InvalidOperationException("Request is running, please waite it complete!");
            }

            _Url = url;
            _Form = form;
            _Pos = pos;
            _CompleteCallback = callback;
            _Step = RequestStep.Ruesting;
            _Error = null;
            HandleRequestPost();

        }

        void HandleRequestPost()
        {
            try
            {
                _Request = HttpWebRequest.Create(_Url) as HttpWebRequest;
                _Request.AddRange(_Pos);
                _Request.Timeout = (int)(_TimeOut * 1000);
                _Request.Method = "POST";
                _Request.KeepAlive = false;
                _Request.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
                _PostData = _Form.data;
                _Request.ContentLength = _PostData.Length;
                _Request.BeginGetRequestStream(new AsyncCallback(GetRequestStreamCallback), _Request);
                _StartTime = Time.time;
            }
            catch (Exception e)
            {
                MarkComplete(e.ToString());
            }
        }

        /// <summary>
        /// 返回数据长度
        /// </summary>
        public long length
        {
            get
            {
                return _Response == null ? 0 : _Pos + _Response.ContentLength;
            }
        }

        public Stream stream
        {
            get
            {
                return _Response == null ? null : _Response.GetResponseStream();
            }
        }

        public bool running
        {
            get
            {
                return _Request != null;
            }
        }

        void GetRequestStreamCallback(IAsyncResult asynResult)
        {
            try
            {
                HttpWebRequest request = asynResult.AsyncState as HttpWebRequest;
                Stream stream = request.EndGetRequestStream(asynResult);
                stream.Write(_PostData, 0, _PostData.Length);
                stream.Close();
                request.BeginGetResponse(new AsyncCallback(GetResponseCallback), request);
            }
            catch (Exception e)
            {
                MarkComplete(e.ToString());
            }
        }

        void GetResponseCallback(IAsyncResult asynResult)
        {
            try
            {
                HttpWebRequest request = asynResult.AsyncState as HttpWebRequest;
                _Response = request.EndGetResponse(asynResult) as HttpWebResponse;
                MarkComplete(null);
            }
            catch (Exception e)
            {
                MarkComplete(e.ToString());
            }
        }

        void MarkComplete(string err)
        {
            if(_Step == RequestStep.Ruesting)
            {
                _Step = RequestStep.Complete;
                _Error = err;
            }
        }

        public float timeOut
        {
            get { return _TimeOut; }
            set { _TimeOut = value; }
        }
        /// <summary>
        /// 主动结束当前的请求，清空数据以使可开启下一个请求
        /// </summary>
        public void DoneRequest(bool clearCallback = true)
        {
            if(clearCallback)
            {
                _CompleteCallback = null;
            }
            if (_Response!=null)
            {
                _Response.Close();
                _Response = null;
            }
            if(_Request !=null)
            {
                _Request.Abort();
                _Request = null;
            }
        }
        public void Update()
        {
            if(_Request !=null && _Step == RequestStep.Ruesting && Time.time >= _StartTime + _TimeOut )
            {//请求超时
                DoneRequest(false);
                //Complete(false, string.Format("request timeout {0}s", _TimeOut));
            }

            if(_Step == RequestStep.Complete)
            {
                Complete(_Error == null, _Error);
            }
        }

        void Complete(bool success, string error)
        {
            _Step = RequestStep.Done;
            var temp = _CompleteCallback;
            _CompleteCallback = null;
            if (temp != null)
            {
                temp(success, error);
            }
        }
    }
}
