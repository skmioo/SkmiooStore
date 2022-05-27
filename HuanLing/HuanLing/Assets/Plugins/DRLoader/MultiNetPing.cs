using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DRLoader
{
    public class MultiNetPing
    {
        private NetPing _Ping;
        private string[] _Hosts;
        private int _CurHost;
        private int[] _PingValue;
        private Action<int[]> _Callback;
        private float _Timeout;
        /// <summary>
        /// 尝试ping一组服务器
        /// </summary>
        /// <param name="hostNameOrIP">需要测试ping值的服务器列表</param>
        /// <param name="ret"></param>
        /// <param name="time"></param>
        public void TryPing(string[] hostNameOrIP, Action<int[]> ret, float time = 5.0f)
        {
            if(_Ping == null)
            {
                _Ping = new NetPing();
            }
            _Hosts = hostNameOrIP;
            _PingValue = new int[hostNameOrIP.Length];
            for(var idx = 0; idx < _PingValue.Length; ++idx )
            {
                _PingValue[idx] = -1;
            }
            _CurHost = -1;
            _Callback = ret;
            _Timeout = time;
            PingNext();
        }

        public void Update()
        {
            if(_Ping!= null)
            {
                _Ping.Update();
            }
        }

        void PingNext()
        {
            ++_CurHost;
            if(_CurHost<_Hosts.Length)
            {
                _Ping.TryPing(_Hosts[_CurHost], RetPing, _Timeout);
            }
            else
            {
                var temp = _Callback;
                var ret = _PingValue;
                _Callback = null;
                if(temp != null)
                {
                    temp(ret);
                }
            }
        }

        void RetPing(int ms)
        {
            _PingValue[_CurHost] = ms;
            PingNext();
        }
    }
}
