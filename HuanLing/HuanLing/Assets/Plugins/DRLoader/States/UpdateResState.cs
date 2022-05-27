using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Net;
using UnityEngine;
using UYMO;

namespace DRLoader
{
    class UpdateResState : GameUpdateSate
    {
        /// <summary>
        /// 更新规则文件名称
        /// </summary>
        const string UpgradeFileName = "update.txt";

        string _UpdatePackagePath;

        /// <summary>
        /// 资源包向前制作差异包的最大数量
        /// </summary>
        const int MaxDiffCount = 10;

        /// <summary>
        /// 本地资源版本
        /// </summary>
        long _LocalResVer = 0;
        // 当前正在更新的版本
        long _TargetResVer = 0;

        string _CurrLoaderMD5 = null;

        LoadUI _UI;

        bool _Complete = false;
        UpdateInfo _SvrVerInfo;

        ResDir _ExtRes;

        bool _UpdatedGameCore = false;

        MultiNetPing _Ping;

        public void Enter(LoadUI ui, object preData)
        {
            if( File.Exists( GameDefine.ResBagPath ))
            {//本地存储不再用文件包
                File.Delete(GameDefine.ResBagPath);
            }
            Debug.LogFormat("Current branch: {0}", BaseVersion.Branch);
            _UI = ui;
            _UpdatePackagePath = GameDefine.storagePathRoot + "update.bag";
            _SvrVerInfo = preData as UpdateInfo;
            Debug.LogFormat("Newest resource version: {0}", _SvrVerInfo.resVer);

            string md5Path = Application.persistentDataPath + "/loader.md5";
            if( File.Exists(md5Path))
            {
                StreamReader md5file = new StreamReader(md5Path, Encoding.ASCII);
                _CurrLoaderMD5 = md5file.ReadLine();
                md5file.Close();
            }
            
            if( _LocalResVer == 0 )
            {//尝试获取内部资源
                AssetsFileMgr.me.InitInner(InnerInited);
            }
        }

        void InnerInited()
        {
            Debug.LogFormat("Inner resource version: {0}", AssetsFileMgr.me.innerVersion);
            _LocalResVer = AssetsFileMgr.me.innerVersion;
            if (ResDir.CheckValidResDir(GameDefine.ExtResDirPath))
            {//有外部资源，以外部资源版本号为准
                _ExtRes = ResDir.Create(GameDefine.ExtResDirPath);
                Debug.LogFormat("Ext resource branch {0}, version {1}", _ExtRes.branchName, _ExtRes.version);
                if ( _ExtRes.branchName == BaseVersion.Branch && _ExtRes.version > _LocalResVer )
                {
                    _LocalResVer = _ExtRes.version;
                }
                else
                {//外部资源分支不对，或者版本比内部资源还低，删除
                    _ExtRes.Clear();
                    _ExtRes.Dispose();
                    _ExtRes = null;
                }
            }

            _UI.clientInfo = StringTrans.T("{0}:{1}\n{2}:{3}", ChannelImpl.GetVersion(), _LocalResVer,  _SvrVerInfo.appVer, _SvrVerInfo.resVer);
            
            if( _SvrVerInfo.resVer > 0 && _LocalResVer < _SvrVerInfo.resVer )
            {
                if (_SvrVerInfo.resVer - _LocalResVer > 2 && !string.IsNullOrEmpty(_SvrVerInfo.updListTag) )
                {//版本跨度太大，查询更新包列表，看是否可以一步更新到
                    string[] updListFileUrl = GameDefine.GetDownloadUrl(string.Format("{0}_{1}_package_{2}.zip", BaseVersion.Branch, GameDefine.osName, _SvrVerInfo.updListTag));
                    Debug.Log("Download update package list file:"+updListFileUrl);
                    NetFrame.netLoader.Load(updListFileUrl, null, RevUpdPackList);
                }
                else
                {
                    BeginCheckUpdate();
                }
            }
            else
            {//无资源可更新，跳过
                Debug.Log("无资源版本信息，跳过资源更新");
                _Complete = true;
            }
        }

        void RevUpdPackList(INetResult ret)
        {
            if( ret.success)
            {
                try
                {
                    MemoryStream archive = new MemoryStream(ret.data);
                    ICSharpCode.SharpZipLib.Zip.ZipConstants.DefaultCodePage = System.Text.Encoding.Default.CodePage;
                    ICSharpCode.SharpZipLib.Zip.ZipInputStream zip = new ICSharpCode.SharpZipLib.Zip.ZipInputStream(archive);
                    var entry = zip.GetNextEntry();
                    string fileName = string.Format("{0}_{1}_package.txt", BaseVersion.Branch, GameDefine.osName);
                    if (entry.Name == fileName)
                    {
                        byte[] data = new byte[entry.Size];
                        int readed = 0;
                        while (true)
                        {
                            int size = zip.Read(data, readed, data.Length - readed);
                            readed += size;
                            if (size <= 0)
                            {
                                break;
                            }
                        }
                        string content = System.Text.Encoding.ASCII.GetString(data);
                        _SvrVerInfo.Parse(content, true);
                    }
                    zip.Dispose();
                    archive.Close();
                }
                catch(Exception e )
                {
                    Debug.LogErrorFormat("Failed to parse updateinfo from zip file!\n{0}", e);
                }
            }
            else
            {
                Debug.LogWarning("Failed to get the update file list!");
            }
            BeginCheckUpdate();
        }

        void BeginCheckUpdate()
        {
            _UI.clientInfo = "";
            if (_LocalResVer < 0)
            {
                _LocalResVer = 0;
            }

            CheckUpdatePack();
        }

        //public static NetworkReachability net = NetworkReachability.ReachableViaLocalAreaNetwork;
        bool _forceRMB = false;
        string downloadStr;
        float preRefresh = 0;
        public static NetworkReachability nr = NetworkReachability.ReachableViaLocalAreaNetwork;
        public void Update()
        {
            if (_Ping != null)
            {
                _Ping.Update();
            }
            var step = NetFrame.netLoader.state;
            string netType = StringTrans.T("未知");
            if (step ==  NetLoadState.Transfering)
            {
                switch (Application.internetReachability)
                {
                    case NetworkReachability.NotReachable://没网
                        _UI.loadInfo = StringTrans.T("网络不可用");
                        netType = "无";
                        return;
                    case NetworkReachability.ReachableViaCarrierDataNetwork://流量
                        if (!_forceRMB && !NetFrame.netLoader.pause)
                        {
                            _UI.ShowMsgBox(StringTrans.T("正在使用流量\n是否继续下载?"), StringTrans.T("继续"), SelectIsUseCarrierData);
                            NetFrame.netLoader.pause = true;
                            return;
                        }
                        netType = StringTrans.T("数据");
                        break;
                    case NetworkReachability.ReachableViaLocalAreaNetwork://WIFI
                        if (NetFrame.netLoader.pause)
                        {
                            NetFrame.netLoader.pause = false;
                            _UI.CloseMsgBox();
                        }
                        netType = StringTrans.T("WIFI");
                        break;
                }
            }

            if(step == NetLoadState.Requesting)
            {

                _UI.loadInfo = StringTrans.T("[源{0}]请求数据...", NetFrame.netLoader.curSrcIndex + 1);
            }
            else if (step == NetLoadState.Transfering)
            {
                _UI.progress = NetFrame.netLoader.progress;
                if (Time.time - preRefresh > 0.5f)
                {
                    preRefresh = Time.time;
                    double loadedSize = (double)NetFrame.netLoader.loaded / (double)(1024 * 1024);
                    double totalSize = (double)NetFrame.netLoader.length / (double)(1024 * 1024);

                    string info = StringTrans.T("[{0}]{1} {2:F2}/{3:F2}MB 网络：{4} 速度：{5}", NetFrame.netLoader.curSrcIndex + 1,  downloadStr,  loadedSize, totalSize, netType, FomatSpeed(NetFrame.netLoader.speed));
                    _UI.loadInfo = info;
                }
            }
        }

        string FomatSpeed(long speed)
        {
            if (speed >= 1024 * 1024)
            {
                return string.Format("{0:F2} mb/s", (float)((double)speed / (double)(1024 * 1024)));
            }
            if (speed >= 1024)
            {
                return string.Format("{0:F2} kb/s", (float)((double)speed / (double)1024));
            }
            return string.Format("{0} b/s", speed);
        }
        void SelectIsUseCarrierData(int btn)
        {
            _forceRMB = true;
            NetFrame.netLoader.pause = false;
        }

        public object Exit()
        {
            _UI.CloseMsgBox();
            //删除所有下载临时文件
            DirectoryInfo dir = new DirectoryInfo(GameDefine.storagePathRoot);
            foreach (var file in dir.GetFiles("*" + NetFrame.TempFileExt))
            {
                File.Delete(file.FullName);
            }
            foreach (var file in dir.GetFiles("*" + NetFrame.BreakpointExt))
            {
                File.Delete(file.FullName);
            }

            if( _ExtRes != null )
            {
                _ExtRes.Dispose();
                _ExtRes = null;
            }
            AssetsFileMgr.me.InitExt();
            System.GC.Collect();
            return null;
        }

        void RestartApplication(int btn )
        {
            if( btn == 0)
            {
                ChannelImpl.RestartApp();
            }
        }

        public bool complete
        {
            get { return _Complete && _Ping == null; }
        }

        void CheckUpdatePack()
        {
            if (_LocalResVer >= _SvrVerInfo.resVer)
            {
                if (_UpdatedGameCore)
                {//有更新DLL代码，重启
                    _UI.ShowMsgBox(StringTrans.T("游戏更新了重要内容，需要重启！点击确定后请再次打开游戏，谢谢！"), StringTrans.T("重启游戏"), RestartApplication);
                }
                else
                {
                    _Complete = true;
                }
                return;
            }

            string updateBagName = _SvrVerInfo.GetUpdatePackName(_LocalResVer, out _TargetResVer);
            
            
            if( updateBagName != null )
            {
                string[] urls = GameDefine.GetDownloadUrl(updateBagName);
                string info = "";
                for(var idx = 0; idx < urls.Length; ++idx )
                {
                    info += string.Format("{0}\n", urls[idx]);
                }
                Debug.Log("下载资源包:"+ info);
                downloadStr = StringTrans.T("更新资源：{0}=>{1}", _LocalResVer, _TargetResVer);
                NetFrame.netLoader.Load(urls, _UpdatePackagePath, handleUpdatePackLoaded);
            }
            else
            {//资源包名称获取失败，无法更新资源
                _Complete = true;
            }
        }

        void Retry(int btn)
        {
            CheckUpdatePack();
        }

        void RetNetState(NetworkState state, string msg)
        {
            if( (state & NetworkState.AccessInternet) != NetworkState.None)
            {//有网
                _UI.loadInfo = NetFrame.netLoader.error;
                _UI.errorStr = NetFrame.netLoader.error;
                CheckUpdatePack();
                ReportNetInfo();
            }
            else
            {//没有网
                string info = StringTrans.T("请连接网络后重试...");
                _UI.ShowMsgBox(info, StringTrans.T("重试"), Retry);
            }
        }

        static byte[] ReadWholeEntry(ICSharpCode.SharpZipLib.Zip.ZipInputStream zip, ICSharpCode.SharpZipLib.Zip.ZipEntry entry)
        {
            byte[] buff = new byte[entry.Size];
            int readed = 0;
            while (true)
            {
                int size = zip.Read(buff, readed, buff.Length - readed);
                readed += size;
                if (size <= 0)
                {
                    break;
                }
            }
            return buff;
        }

        public void handleUpdatePackLoaded(INetResult result)
        {
            bool success = result.success;
            string error = result.msg;
            if (!success)
            {
                NetworkStateUtil.me.FetchNetworkState(RetNetState);
                return;
            }
            Debug.Log("[GameUpdate]更新包下载成功！" + result.path);

            _UI.StartCoroutine(UnZipPack(result));
        }

        System.Collections.IEnumerator UnZipPack(INetResult result)
        {
            //try
            //{
            byte[] buff = null;
            UpgradeRule _Rule = null;
            ICSharpCode.SharpZipLib.Zip.ZipConstants.DefaultCodePage = System.Text.Encoding.Default.CodePage;
            FileStream updateFile = new FileStream(_UpdatePackagePath, FileMode.Open, FileAccess.Read);
            ICSharpCode.SharpZipLib.Zip.ZipInputStream _Zip = new ICSharpCode.SharpZipLib.Zip.ZipInputStream(updateFile);
            ICSharpCode.SharpZipLib.Zip.ZipEntry file;
            double total = 0;
            while ((file = _Zip.GetNextEntry()) != null)
            {
                total += file.Size;
                if (file.Name == UpgradeFileName)
                {
                    buff = ReadWholeEntry(_Zip, file);
                    string str = System.Text.Encoding.ASCII.GetString(buff);
                    _Rule = UnityEngine.JsonUtility.FromJson<UpgradeRule>(str);
                }
            }
            file = null;
            _Zip.Close();
            _Zip = null;
            updateFile.Close();
            updateFile = null;

            if (_Rule != null)
            {
                if (_ExtRes == null)
                {
                    //创建新的
                    _ExtRes = ResDir.Create(GameDefine.ExtResDirPath);
                    _ExtRes.SetInfo(_Rule.branch, 0);
                }

                if (_Rule.baseVersion != _LocalResVer && _LocalResVer != 0)
                {
                    string er = string.Format("Update package isn't suitable, local version is {0}, package is from {1} to {2}", _LocalResVer, _Rule.baseVersion, _Rule.version);
                    _UI.errorStr = er;
                    throw new System.InvalidOperationException(er);
                }

                for (var idx = 0; _Rule.remove != null && idx < _Rule.remove.Length; ++idx)
                {
                    var del = _Rule.remove[idx];
                    _ExtRes.DelRes(del);
                    Debug.LogFormat("删除文件:{0}", del);
                }
                updateFile = new FileStream(_UpdatePackagePath, FileMode.Open, FileAccess.Read);
                _Zip = new ICSharpCode.SharpZipLib.Zip.ZipInputStream(updateFile);

                _UI.loadInfo = StringTrans.T("资源归档中...");

                buff = new byte[1024 * 1024];
                double saved = 0;
                ICSharpCode.SharpZipLib.Zip.ZipEntry ab;
                while ((ab = _Zip.GetNextEntry()) != null)
                {
                    if (ab.Name == UpgradeFileName)
                    {//规则文件，不用读了
                        saved += ab.Size;
                        yield return null;
                    }
                    else if (ab.Name == Boot.LoaderDLLFile)
                    {//加载器文件，需要计算md5码
                        byte[] data = ReadWholeEntry(_Zip, ab);
                        _ExtRes.DelRes(ab.Name);
                        _ExtRes.AddRes(ab.Name, data);

                        string md5 = ByteArrayToHexString(data);
                        Debug.LogFormat("UpdateLoader\nold:{0}\nnew:{1}", _CurrLoaderMD5, md5);
                        if (md5 != _CurrLoaderMD5)
                        {//判断是否真的更新了 drloader
                            _UpdatedGameCore = true;
                        }
                        saved += ab.Size;
                    }
                    else
                    {
                        _ExtRes.DelRes(ab.Name);
                        _ExtRes.BeginAddRes(ab.Name);
                        int used = 0;
                        while (true)
                        {
                            int size = _Zip.Read(buff, used, buff.Length- used);
                            used += size;
                            if(used>= buff.Length || size <= 0)
                            {
                                _ExtRes.ProcessSaveRes(buff, 0, used);
                                used = 0;
                            }
                            saved += size;
                            if (size <= 0)
                            {
                                break;
                            }
                        }
                        _ExtRes.EndAddRes(ab.Name, false);
                    }
                    _UI.progress = (float)(saved / total);
                    yield return null;
                }

                _ExtRes.SetInfo(_Rule.branch, _Rule.version);
                _LocalResVer = _Rule.version;

                _Zip.Close();
                _Zip = null;
                updateFile.Close();
                updateFile = null;
            }
            else
            {
                Debug.LogErrorFormat("更新包错误，未找到更新说明文件...\n{0}", result.path);
            }
            File.Delete(_UpdatePackagePath);
            //}
            //catch (Exception e)
            //{
            //    string str = string.Format("资源归档失败:{0}", e);
            //    Debug.LogError(str);
            //    _UI.errorLabel.text = str;
            //}

            CheckUpdatePack();
        }


        string[] _DLHosts;
        public void ReportNetInfo()
        {
            _DLHosts = GameDefine.GetDownloadUrl(string.Empty);
            for (var idx = 0; idx < _DLHosts.Length; ++idx)
            {
                Uri url = new Uri(_DLHosts[idx]);
                _DLHosts[idx] = url.Host;
            }
            if (_Ping == null)
            {
                _Ping = new MultiNetPing();
            }
            _Ping.TryPing(_DLHosts, PingSrcRet, 5.0f);
        }

        void PingSrcRet(int[] pv)
        {
            _Ping = null;
            //本机公网IP
            string ip = NetworkStateUtil.GetIP();
            //资源服务器IP
            StringBuilder hostIps = new StringBuilder();
            hostIps.Append("资源服务器地址：\n");
            for (var idx = 0; idx < _DLHosts.Length && idx < pv.Length; ++idx)
            {
                hostIps.AppendFormat("{0} ping:{1}ms =>\n", _DLHosts[idx], pv[idx]);
                try
                {
                    IPAddress[] adress = Dns.GetHostAddresses(_DLHosts[idx]);
                    for (var ai = 0; ai < adress.Length; ++ai)
                    {
                        hostIps.AppendLine(adress[ai].ToString());
                    }
                }
                catch (Exception e)
                {
                    hostIps.AppendLine(e.ToString());
                }

            }
            //DNS服务器IP
            StringBuilder dnses = new StringBuilder();
            try
            {
                var dnsIps = NetworkStateUtil.GetDnsAddresses();
                foreach (var d in dnsIps)
                {
                    dnses.AppendLine(d.ToString());
                }
            }
            catch (Exception e)
            {
                dnses.AppendLine(e.ToString());
            }

            Debug.LogErrorFormat("网络正常 资源更新失败:{0}\n公网IP：{1}\n资源服务器信息：{2} \nDNS:{3}", NetFrame.netLoader.error, ip, hostIps, dnses);
        }

        public static string ByteArrayToHexString(byte[] data)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            md5.Initialize();

            byte[] bytes = md5.ComputeHash(data);
            md5.Clear();

            StringBuilder sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString().ToLower();
        }
    }
    [Serializable]
    public class UpgradeRule
    {
        /// <summary>
        /// 更新包的分支名称
        /// </summary>
        public string branch;
        /// <summary>
        /// 更新包的系统类型 windows,android,ios等
        /// </summary>
        public string platform;
        /// <summary>
        /// 更新包的版本号
        /// </summary>
        public long version;
        /// <summary>
        /// 基于此版本的差异包，0表示此为完整包
        /// </summary>
        public long baseVersion;
        /// <summary>
        /// 本次更新，修改的文件
        /// </summary>
        public string[] modify;
        /// <summary>
        /// 本次更新，需要删除的文件
        /// </summary>
        public string[] remove;
    }
}
