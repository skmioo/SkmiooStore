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
    public class NetworkStateUtil:SingletonAuto<NetworkStateUtil>
    {
        string[] _ServerList = new string[]
        {
            "go.gz.ledo.com",
            "tx.gz.ledo.com",
            "baidu.com",
            "qq.com",
            "youku.com"
        };

        Action<NetworkState, string> _Fetcher;
        bool _Checking;
        NetPing _Ping;
        int _CurPing;
        Dictionary<string, int> _SvrPings = new Dictionary<string, int>();
        StringBuilder _PingInfo = new StringBuilder();
        /// <summary>
        /// 获取当前网络状态
        /// </summary>
        /// <param name="result">得到状态后回调</param>
        public void FetchNetworkState(Action<NetworkState, string> result)
        {
            if( result != null)
            {
                _Fetcher += result;

                if(!_Checking)
                {
                    if(Application.internetReachability == NetworkReachability.NotReachable)
                    {
                        for(var idx = 0; idx < svrCount; ++idx )
                        {
                            _SvrPings[_ServerList[idx]] = -1;
                        }
                        Done(NetworkState.NoConnect | NetworkState.NoInternet, "No network connect!");
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

        void _PingRet(int time)
        {
            string svr = _ServerList[_CurPing];
            _PingInfo.AppendFormat("{0} => {1}ms\n", svr, time);
            _SvrPings[svr] = time;
            if ( time == -1 && _CurPing < _ServerList.Length -1 )
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
                Done(state, _PingInfo.ToString());
            }
        }
        public void _Update()
        {
            if(_Ping != null)
            {
                _Ping.Update();
            }
        }
        void Done(NetworkState state, string info)
        {
            _Checking = false;
            if(_Fetcher != null)
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
        public void SetCheckSvrs(string[] servers)
        {
            _ServerList = servers;
        }

        /// <summary>
        /// 检查目标服务器数量
        /// </summary>
        public int svrCount
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
        public int GetSvrPing(int svrIdx)
        {
            if( svrIdx < _ServerList.Length)
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
            }catch(Exception e)
            {
                return "unknown";
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
