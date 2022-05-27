using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UYMO;
using System;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

/// <summary>
/// 游戏加载器，注意游戏代码中不要使用任何该命名空间下的类
/// </summary>
namespace DRLoader
{
    public class GameLoader : MonoBehaviour
    {
        Queue<GameUpdateSate> _States;
        GameUpdateSate _CurState;
        bool _GameLaunched = false;
        LoadUI _UI;

        // Use this for initialization
        void Start()
        {
            Screen.sleepTimeout = -1;
            System.Net.ServicePointManager.ServerCertificateValidationCallback += HandleServerCertificate;
            System.Net.ServicePointManager.DefaultConnectionLimit = 200;

            //一些初始化工作
            string storagePath = Application.persistentDataPath + "/";
            switch (Application.platform)
            {
                case RuntimePlatform.IPhonePlayer:
                    //BuglyAgent.EnableExceptionHandler();
                    BuglyAgent.ConfigDefault(ChannelImpl.GetChannelName(), ChannelImpl.GetVersion(), "Logining", 0);
                    BuglyAgent.InitWithAppId("da7857daf4");
                    break;
                case RuntimePlatform.Android:
                    //BuglyAgent.EnableExceptionHandler();
                    BuglyAgent.ConfigDefault(ChannelImpl.GetChannelName(), ChannelImpl.GetVersion(), "Logining", 0);
                    BuglyAgent.InitWithAppId("473e6a9eed");
                    break;
                case RuntimePlatform.WindowsPlayer:
                case RuntimePlatform.OSXEditor:
                case RuntimePlatform.WindowsEditor:
                    storagePath = Application.dataPath + "/../Data/";
                    break;
            }
            GameDefine.SetStoragePath(storagePath);
            AdjustBaseVersion();


            // Debug.Log("Enter DRLoader");
            _UI = new LoadUI();
            _UI.logicGO = gameObject;
            _UI.clientInfo = string.Format("PlayerVer: {0}", ChannelImpl.GetVersion());

            RefreshBackgroundUrl();

             _States = new Queue<GameUpdateSate>();
            if(!Boot.ShouldDirectLaunchGame())
            {
                _States.Enqueue(new InitLanguageState());
                _States.Enqueue(new CheckVersionState());
                _States.Enqueue(new UpdateResState());
            }
            _States.Enqueue(new LaunchGameState());

            _CurState = _States.Dequeue();
            _CurState.Enter(_UI, null);

        }

        private static bool HandleServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        public static void RefreshBackgroundUrl()
        {
            string chKey = ChannelImpl.GetChannelName();

            GameDefine.SetBackgroundUrl(BaseVersion.IsInner
                ? new string[] { GameDefine.InnerBGPublicUrl, GameDefine.InnerBGUrl }
                : new string[] { GameDefine.GetOuterBGUrl(chKey) });
        }

        // Update is called once per frame
        void Update()
        {
            if (AssetsFileMgr.me.needUpdate)
            {
                AssetsFileMgr.me.Update();
            }

            NetFrame.Update();
            NetworkStateUtil.me._Update();


            if (_GameLaunched)
            {
                return;
            }
            if (_CurState == null || _CurState.complete)
            {
                object preData = _CurState.Exit();
                if (_States.Count > 0)
                {
                    _CurState = _States.Dequeue();
                    _CurState.Enter(_UI, preData);
                }
                else
                {
                    LuanchGame();
                }
            }
            else
            {
                _CurState.Update();
            }
        }

        /// <summary>
        /// 启动游戏
        /// </summary>
        void LuanchGame()
        {
            //Debug.Log("Mount Game!");
            //GameObject _UI = GameObject.Find("LoaderUI");
            //if (_UI != null)
            //{
            //    Destroy(_UI);
            //}
            //if (gameObject.GetComponent<Game>() == null)
            //{
            //    gameObject.AddComponent<Game>();
            //}
            //Destroy(this);
            // Debug.Log("Launch Game...");
            _GameLaunched = true;
        }

        void OnDestroy()
        {
            AssetsFileMgr.me.Dispose();
        }

        void AdjustBaseVersion()
        {
            if (!BaseVersion.IsInner)
            {//不是内网版本，说明是发布版，不设置
                return;
            }
            if (!_CheckIsOutMode())
            {//没有手动切换成外网版本，忽略
                return;
            }
            BaseVersion.Branch = "testone"; //暂时设置
            BaseVersion.IsInner = false;
        }
        private bool _CheckIsOutMode()
        {
#if UNITY_EDITOR
            string path = DRLoader.GameDefine.storagePathRoot + "Local/out.xml";
            if (File.Exists(path))
            {
                Debug.LogWarning("注意你现在登录的是外网。如果需要切成内网，请删除Data/Local/out.xml");
                return true;
            }
            return false;
#else
            return false;
#endif
        }

        //void OnGUI()
        //{
        //    if (GUI.Button(new Rect(100, 100, 200, 45), "切换网络"))
        //    {
        //        //UpdateResState.nr = UpdateResState.nr == NetworkReachability.ReachableViaLocalAreaNetwork ? NetworkReachability.ReachableViaCarrierDataNetwork : NetworkReachability.ReachableViaLocalAreaNetwork;
        //        UpdateResState state = _CurState as UpdateResState;
        //        if(state != null)
        //        {
        //            state.ReportNetInfo();
        //        }
        //    }
        //}

        //public static void Log(string str)
        //{
        //    if(Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork )
        //    {
        //        Debug.LogError(str);
        //    }
        //}

        //public static void Log(string fmt, params object[] args)
        //{
        //    if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork)
        //    {
        //        Debug.LogErrorFormat(fmt, args);
        //    }
        //}
    }

    internal interface GameUpdateSate
    {
        void Enter(LoadUI ui, object preData);
        void Update();
        object Exit();
        bool complete { get; }
    }

}
