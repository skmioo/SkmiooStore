using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Net.NetworkInformation;
using UnityEngine;
using UYMO;

namespace DRLoader
{
    /// <summary>
    /// 当前下载的状态
    /// </summary>
    public enum NetLoadState
    {
        /// <summary>
        /// 链接请求中
        /// </summary>
        Requesting,
        /// <summary>
        /// 数据接收中
        /// </summary>
        Transfering,
        /// <summary>
        /// 下载完成
        /// </summary>
        Complete,
    }

    /// <summary>
    /// 网络下载返回信息
    /// </summary>
    public interface INetResult
    {
        /// <summary>
        /// 下载是否成功
        /// </summary>
        bool success { get; }
        /// <summary>
        /// 下载失败时的错误消息，没有为null
        /// </summary>
        string msg { get; }
        /// <summary>
        /// 下载地址
        /// </summary>
        string[] urls { get; }
        /// <summary>
        /// 下载到文件时存储路径
        /// </summary>
        string path { get; }
        /// <summary>
        /// 下载到内存时下载好的数据
        /// </summary>
        byte[] data { get; }
        /// <summary>
        /// 获取下载的文本，只有下载到内存时有效，使用UTF-8编码
        /// </summary>
        string text { get; }
    }

    /// <summary>
    /// 一个统一的网络下载接口
    /// </summary>
    public interface INetLoader
    {
        /// <summary>
        /// 下载给定url(s)
        /// </summary>
        /// <param name="url">url地址数组（第一个元素为默认url地址，其后的元素为备用地址）</param>
        /// <param name="savePath">下载内容存放的本地路径，传null表示直接存放到内存中</param>
        /// <param name="complete">下载结束（成功或者失败）的回调</param>
        /// <param name="form">post数据（post协议时使用）,传递null表示使用get协议</param>
        void Load(string[] url, string savePath, Action<INetResult> complete, PostForm postForm = null);
        /// <summary>
        /// 取消下载
        /// </summary>
        /// <param name="url">下载地址</param>
        void CancelLoad(string url);
        /// <summary>
        /// 逻辑驱动
        /// </summary>
        void Update();
        /// <summary>
        /// 当前是否在下载中
        /// </summary>
        bool loading { get; }
        /// <summary>
        /// 暂停
        /// </summary>
        bool pause { get; set; }
        /// <summary>
        /// 当前下载状态
        /// </summary>
        NetLoadState state { get; }
        /// <summary>
        /// 最后的错误信息，没有错误返回null
        /// </summary>
        string error { get; }
        /// <summary>
        /// 当前下载速度（字节/秒）
        /// </summary>
        long speed { get; }
        /// <summary>
        /// 下载当前文件的进度
        /// </summary>
        float progress { get; }
        /// <summary>
        /// 当前文件已经下载的字节数
        /// </summary>
        long loaded { get; }
        /// <summary>
        /// 当前文件总的下载字节数
        /// </summary>
        long length { get; }
        /// <summary>
        /// 当前下载的数据源索引
        /// </summary>
        int curSrcIndex { get; }
    }

    //网络连接及访问状态
    public enum NetworkState
    {
        None = 0,
        /// <summary>
        /// 没有网络连接
        /// </summary>
        NoConnect = 1,
        /// <summary>
        /// 使用的是数据连接
        /// </summary>
        Data = 2,
        /// <summary>
        /// 使用的是WIFI或网线连接
        /// </summary>
        Local = 4,
        /// <summary>
        /// 可访问互连网
        /// </summary>
        AccessInternet = 8,
        /// <summary>
        /// 不可访问互连网
        /// </summary>
        NoInternet = 16,
    }

    /// <summary>
    /// DRLoader的网络框架（入口）
    /// </summary>
    public class NetFrame
    {
        /// <summary>
        /// 临时文件的后缀
        /// </summary>
        public static string TempFileExt = ".dlf";
        /// <summary>
        /// 断点续传信息文件的后缀
        /// </summary>
        public static string BreakpointExt = ".dli";

        static string[] _ServerList = new string[]
        {
            "go.gz.ledo.com",
            "tx.gz.ledo.com",
            "baidu.com",
            "qq.com",
            "youku.com"
        };

        private static Action<NetworkState, string> _Fetcher;
        private static bool _Checking;
        private static NetPing _Ping;
        private static int _CurPing;
        private static Dictionary<string, int> _SvrPings = new Dictionary<string, int>();
        private static StringBuilder _PingInfo = new StringBuilder();

        private static INetLoader _UnityWebLoader;
        private static INetLoader _MonoWebLoader;

        

        /// <summary>
        /// 默认的网络加载器
        /// </summary>
        public static INetLoader netLoader
        {
            get
            {
                return monoWebLoader;
            }
        }
        /// <summary>
        /// MONO版本的http加载器
        /// </summary>
        public static INetLoader monoWebLoader
        {
            get
            {
                if (_MonoWebLoader == null)
                    _MonoWebLoader = new HttpLoader();
                return _MonoWebLoader;
            }
        }
        /// <summary>
        /// unity版本的http加载器
        /// </summary>
        public static INetLoader unityWebLoader
        {
            get
            {
                if (_UnityWebLoader == null)
                    _UnityWebLoader = new UnityLoader();
                return _UnityWebLoader;
            }
        }

        /// <summary>
        /// 外部需要持续驱动
        /// </summary>
        public static void Update()
        {
            if (_MonoWebLoader != null)
            {
                _MonoWebLoader.Update();
            }
            if(_UnityWebLoader != null)
            {
                _UnityWebLoader.Update();
            }

            if (_Ping != null)
            {
                _Ping.Update();
            }
        }

        /// <summary>
        /// 获取当前网络状态
        /// </summary>
        /// <param name="result">得到状态后回调</param>
        public static void FetchNetworkState(Action<NetworkState, string> result)
        {
            if (result != null)
            {
                _Fetcher += result;

                if (!_Checking)
                {
                    if (Application.internetReachability == NetworkReachability.NotReachable)
                    {
                        for (var idx = 0; idx < svrCount; ++idx)
                        {
                            _SvrPings[_ServerList[idx]] = -1;
                        }
                        DoneNetState(NetworkState.NoConnect | NetworkState.NoInternet, "No network connect!");
                    }
                    else
                    {
                        _Checking = true;
                        _CurPing = 0;
                        _PingInfo.Length = 0;
                        _Ping = new NetPing();
                        _Ping.TryPing(_ServerList[_CurPing], _PingRet, 0.5f);
                    }
                }
            }
        }

        private static void _PingRet(int time)
        {
            string svr = _ServerList[_CurPing];
            _PingInfo.AppendFormat("{0} => {1}ms\n", svr, time);
            _SvrPings[svr] = time;
            if (time == -1 && _CurPing < _ServerList.Length - 1)
            {//失败,并且还有其它服务器可以ping
                ++_CurPing;
                _Ping.TryPing(_ServerList[_CurPing], _PingRet, 0.5f);
            }
            else
            {//成功，或者所有都Ping过了
                NetworkState state = NetworkState.None;
                switch (Application.internetReachability)
                {
                    case NetworkReachability.ReachableViaCarrierDataNetwork:
                        state |= NetworkState.Data;
                        break;
                    case NetworkReachability.ReachableViaLocalAreaNetwork:
                        state |= NetworkState.Local;
                        break;
                    default:
                        state |= NetworkState.NoConnect;
                        break;
                }
                state |= time == -1 ? NetworkState.NoInternet : NetworkState.AccessInternet;
                DoneNetState(state, _PingInfo.ToString());
            }
        }

        private static void DoneNetState(NetworkState state, string info)
        {
            _Checking = false;
            if (_Fetcher != null)
            {
                var temp = _Fetcher;
                _Fetcher = null;
                temp(state, info);
            }
        }
        /// <summary>
        /// 设置网络查检时目标服务器列表
        /// 服务器列表中有服务器能Ping能则认为已连接互连网，否则为未连接
        /// </summary>
        /// <param name="servers">服务器IP/域名列表</param>
        public static void SetCheckSvrs(string[] servers)
        {
            _ServerList = servers;
        }

        /// <summary>
        /// 检查目标服务器数量
        /// </summary>
        public static int svrCount
        {
            get
            {
                return _ServerList.Length;
            }
        }

        /// <summary>
        /// 获取目标服务器的ping值
        /// </summary>
        /// <param name="svrIdx">服务器索引</param>
        /// <returns>ping值，-1表示ping不通，0表示未ping过，>0表示ping值</returns>
        public static int GetSvrPing(int svrIdx)
        {
            if (svrIdx < _ServerList.Length)
            {
                string svr = _ServerList[svrIdx];
                int p = 0;
                _SvrPings.TryGetValue(svr, out p);
                return p;
            }
            else
            {
                return 0;
            }
        }
        public static string GetIP()
        {
            try
            {
                string tempip = "";
                WebRequest request = WebRequest.Create("http://ip.qq.com/");
                request.Timeout = 10000;
                WebResponse response = request.GetResponse();
                Stream resStream = response.GetResponseStream();
                StreamReader sr = new StreamReader(resStream, System.Text.Encoding.Default);
                string htmlinfo = sr.ReadToEnd();
                //匹配IP的正则表达式
                Regex r = new Regex("((25[0-5]|2[0-4]\\d|1\\d\\d|[1-9]\\d|\\d)\\.){3}(25[0-5]|2[0-4]\\d|1\\d\\d|[1-9]\\d|[1-9])", RegexOptions.None);
                Match mc = r.Match(htmlinfo);
                //获取匹配到的IP
                tempip = mc.Groups[0].Value;

                resStream.Close();
                sr.Close();
                return tempip;
            }
            catch (Exception e)
            {
                return "unknown: " + e.ToString();
            }
        }

        public static IPAddressCollection GetDnsAddresses()
        {
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in adapters)
            {

                IPInterfaceProperties adapterProperties = adapter.GetIPProperties();
                return adapterProperties.DnsAddresses;
            }
            return null;
        }
    }
}
