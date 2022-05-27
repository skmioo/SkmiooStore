using System;
using System.Net;
using UnityEngine;

namespace DRLoader
{
    public class NetPing
    {
        private Ping _Ping;
        private float _PingStart = -1;
        private Action<int> _Result;
        /// <summary>
        /// 尝试Ping一个服务器
        /// </summary>
        /// <param name="nameOrIP">服务器域名，或IP地址</param>
        /// <param name="ret">结果回调，参数为Ping值，若失败则为-1</param>
        /// <param name="timeout">超时s</param>
        public void TryPing(string nameOrIP, Action<int> ret, float timeout = 2.0f)
        {
            try
            {
                IPAddress[] ads = Dns.GetHostAddresses(nameOrIP);
                if (ads == null || ads.Length <= 0)
                {
                    ret(-1);
                    return;
                }

                string ipAddress = ads[0].ToString();
                if (_Ping != null && _Result != null)
                {
                    throw new InvalidOperationException(string.Format("Now is ping: {0}, please wait it complete!", _Ping.ip));
                }

                try
                {
                    _PingStart = Time.time;
                    _Ping = new Ping(ipAddress);
                    _Result = ret;
                }
                catch
                {
                    Done(-1);
                }
            }
            catch
            {
                ret(-1);
            }

        }

        public void Update()
        {
            if( _PingStart != -1 )
            {
                if (_Ping.isDone)
                {
					Debug.Log("[Ping]ping time:"+ _Ping.time);
					if( _Ping.time >= 0 )
					{
						Done(_Ping.time);
					}
					else
					{
						Done(-1);
					}
                }
                else if( Time.time - _PingStart >= 2.0f )
                {
                    Done(-1);
                }
            }
        }
        private void Done(int time )
        {
			_PingStart = -1;
			_Ping = null;
			var temp = _Result;
			_Result = null;
			temp(time);
        }
    }
}
