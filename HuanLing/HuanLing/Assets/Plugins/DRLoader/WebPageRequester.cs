using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UYMO;

namespace DRLoader
{
    /// <summary>
    /// 访问后台状态码
    /// </summary>
    public enum BGStatusCode
    {
        /// <summary>
        /// 正常访问到了后台
        /// </summary>
        Success = 0,
        /// <summary>
        /// 未知原因的访问后台失败
        /// </summary>
        Failed = -1001,
        /// <summary>
        /// 无网络连接
        /// </summary>
        NoNet = -1002,
    }
    /// <summary>
    /// 一个简单的web页面请求工具
    /// </summary>
    public static class WebPageRequester
    {
        static LoaderObjectPoolT<Dictionary<string, string>> sDicPool = new LoaderObjectPoolT<Dictionary<string, string>>(null, dic => dic.Clear());
        static LoaderObjectPoolT<ReqItem> sReqItemPool = new LoaderObjectPoolT<ReqItem>(null, item => item.Clear());

        class ReqItem
        {
            public string[] urls;
            public Action<BGStatusCode,string> callback;
            public Dictionary<string, string> fields;

            public void Clear()
            {
                urls = null;
                callback = null;
                if (fields != null)
                {
                    sDicPool.Release(fields);
                    fields = null;
                }
            }


            public void AppendUrls(StringBuilder sb)
            {
                for (int i = 0; urls != null && i < urls.Length; ++i)
                {
                    sb.Append(urls[i]);
                    sb.AppendLine();
                }
            }
        }

        static StringBuilder sStringBuild = new StringBuilder();
        static List<string> sUrls = new List<string>();

        static Queue<ReqItem> _List = new Queue<ReqItem>();
        static ReqItem _Reqing = null;

        static string _Error = null;
        static NetworkState _NetState = NetworkState.None;

        static void _NetworkStatusRet(NetworkState state, string info)
        {
            if(_Reqing!=null)
            {
                _NetState = state;
                _Error = string.Format("{0}\n", _Error, info);

                StringBuilder svrPing = new StringBuilder();
                for (int idx = 0; idx < NetworkStateUtil.me.svrCount; ++idx)
                {
                    svrPing.AppendFormat("{0}:{1}ms;", idx, NetworkStateUtil.me.GetSvrPing(idx));
                }

                
                BGStatusCode errorCode;
                if ((state & NetworkState.AccessInternet) != NetworkState.None)
                {//联网
                    errorCode = BGStatusCode.Failed;

                    sStringBuild.Length = 0;
                    sStringBuild.AppendFormat("网络正常，但后台访问失败：{0}\n", _Error);
                    _Reqing.AppendUrls(sStringBuild);
                    Debug.LogError(sStringBuild.ToString());
                }
                else
                {
                    errorCode = BGStatusCode.Failed;
                }
                string content = string.Format("{{\"status\":{0}, \"msg\":\"{1}\"}}", (int)BGStatusCode.NoNet, svrPing);
                _Reqing.callback(errorCode, content);
                _Reqing = null;
                RequestNext();
            }
        }

        //public bool Requesting
        //{
        //    get
        //    {
        //        return _Reqing != null || _List.Count > 0;
        //    }
        //}

        /// <summary>
        /// 请求一个页面,Put模式
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="ret">请求后返回，参数为 页面文件</param>
        public static void RequestPage(string url, Action<BGStatusCode, string> ret )
        {
            RequestPage(url, null, ret);
        }

        /// <summary>
        /// 请求一个页面，Post模式
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="fields">参数，null ? put : post</param>
        /// <param name="ret">结果回调</param>
        public static void RequestPage(string url, Dictionary<string, string> fields, Action<BGStatusCode,string> ret)
        {
            RequestPage(new string[] { url }, fields, ret);
        }

        public static void RequestPage(string[] urls, Dictionary<string, string> fields, Action<BGStatusCode,string> ret)
        {
            ReqItem item = sReqItemPool.Get();
            item.urls = urls;
            item.fields = fields;
            item.callback = ret;
            _List.Enqueue(item);

            if (_Reqing == null)
            {
                RequestNext();
            }
        }

        /// <summary>
        /// 请求后台
        /// <param name="apiName">后台接口名</param>
        /// <param name="fields">参数</param>
        /// <param name="isPost">是否使用Post模式</param>
        /// <param name="ret">结果返回回调</param>
        /// </summary>
        public static void RequestBackground(string apiName, Dictionary<string, string> fields, bool isPost, Action<BGStatusCode, string> ret)
        {
            sUrls.Clear();
            for ( var idx = 0; idx < GameDefine.bgUrls.Length; ++idx )
            {
                string bgroot = GameDefine.bgUrls[idx];
                if(isPost)
                {
                    sUrls.Add(string.Format("{0}/Api/{1}", bgroot, apiName));
                }
                else
                {
                    sStringBuild.Length = 0;
                    sStringBuild.AppendFormat("{0}/Api/GetVer", bgroot);
                    if(fields != null )
                    {
                        var enu = fields.GetEnumerator();
                        while(enu.MoveNext())
                        {
                            sStringBuild.AppendFormat("&{0}={1}", enu.Current.Key, enu.Current.Value);
                        }
                    }
                    sUrls.Add(sStringBuild.ToString());
                }
            }

            if(isPost && fields == null)
            {//pos必须要有参数
                fields = sDicPool.Get();
            }
            else if( !isPost && fields != null)
            {//put不能有参数（已经加入到url中了）
                fields = null;
            }
            RequestPage(sUrls.ToArray(), fields, ret);
        }

        static void RequestNext()
        {
            if (_List.Count > 0)
            {
                ReqItem item = _List.Dequeue();
                PostForm form = null;

                sStringBuild.Length = 0;
                sStringBuild.Append("Try request http page:");
                item.AppendUrls(sStringBuild);
                sStringBuild.Append("with fields:\n");

                if (item.fields != null)
                {
                    form = PostForm.Create();
                    var en = item.fields.GetEnumerator();
                    while (en.MoveNext())
                    {
                        form.AddField(en.Current.Key, en.Current.Value);
                        sStringBuild.AppendFormat("{0}:{1}\n", en.Current.Key, en.Current.Value);
                    }
                }
                NetFrame.unityWebLoader.Load(item.urls, null, HandleLoaded, form);

                Debug.Log(sStringBuild.ToString());

                _Reqing = item;
                _Error = null;
            }
        }

        static void HandleLoaded(INetResult result)
        {
            _Error = result.msg;
            string content = result.success ? result.text : "";

            if (string.IsNullOrEmpty(content))
            {//请求失败，检查网络状态
                NetworkStateUtil.me.FetchNetworkState(_NetworkStatusRet);
            }
            else
            {//成功，请求下一个
                _Reqing.callback(BGStatusCode.Success, content);
                _Reqing = null;
                RequestNext();
            }
        }

        public static string error { get { return _Error; } }
        public static NetworkState netState { get { return _NetState; } }
    }
}
