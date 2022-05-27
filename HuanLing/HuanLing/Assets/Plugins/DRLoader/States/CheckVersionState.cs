﻿using System;
using System.IO;
using UYMO;
using UnityEngine;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using DRLoader.Update;

namespace DRLoader
{
    /// <summary>
    /// 获取版本信息
    /// </summary>
    class CheckVersionState : GameUpdateSate
    {
        const float MaxRetryTime = 16.0f;
        float _BeginTime = 0.0f;
        Ticker _Ticker;
        LoadUI _UI;
        UpdateInfo _SvrVerInfo;
        bool _VerReqing = false;
        
        bool _Complete = false;

        public bool complete
        {
            get
            {
                return _Complete;
            }
        }

        public void Enter(LoadUI ui, object preData)
        {
            _UI = ui;

            Debug.Log("Check game and resource version!");

            if (!Directory.Exists(GameDefine.storagePathRoot))
            {
                Directory.CreateDirectory(GameDefine.storagePathRoot);
            }
            Debug.Log("DataPath:" + GameDefine.storagePathRoot);

            _UI.progress = 0.0f;
            _UI.loadInfo = StringTrans.T("匹配服务器...");

            if (BaseVersion.IsInner)
            {
                string svrAddress1 = string.Format("{0}/bin/purify/{1}/{2}/", GameDefine.InnerResServerUrl, BaseVersion.Branch, GameDefine.osName);
                string svrAddress2 = string.Format("{0}/bin/purify/{1}/{2}/", GameDefine.InnerResSErverPubUrl, BaseVersion.Branch, GameDefine.osName);

                GameDefine.SetDownloadUrlRoot(new string[] { svrAddress1, svrAddress2 });
            }

            HandleRetry(0);
        }

        void HandleRetry(int btn)
        {
            _Ticker = new Ticker(() =>
            {
                _BeginTime = Time.time;
                _VerReqing = true;
                _UI.loadInfo = StringTrans.T("匹配服务器...");
                VersionCheckUtil.ReqVersionInfo(HandleVersion);
            }, 0.2f);
        }

        void HandleVersion(UpdateInfo verInfo)
        {
            if( verInfo == null)
            {
                NetworkState state = WebPageRequester.netState;
                bool noInternet = state != NetworkState.None && (state & NetworkState.AccessInternet) == NetworkState.None;
                if(noInternet || Time.time - _BeginTime >= MaxRetryTime)
                {
                    _VerReqing = false;
                    _UI.ShowMsgBox(noInternet ? "无网络连接...":"匹配服务器失败...", "重试", HandleRetry);
                }
                else
                {
                    VersionCheckUtil.ReqVersionInfo(HandleVersion);
                }
                return;
            }
            _SvrVerInfo = verInfo;

            if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
            {
                //其它的按版本号来
                AppVersion localVer = AppVersion.Parse(ChannelImpl.GetVersion());
                ulong localNum = localVer.ToUlong();
                if (_SvrVerInfo.forceUpdateApp == 1
                    && _SvrVerInfo.appVer.ToUlong() > localNum)
                {
                    _UI.ShowMsgBox("检测到新版本，请立即更新！", "前往更新", HandleToUpdatePlayer);
                    return;
                }
            }
            _Complete = true;
        }

        public object Exit()
        {
            System.GC.Collect();
            _UI.errorStr = "";
            return _SvrVerInfo;
        }

        public void Update()
        {
            if(Input.touchCount >2)
            { //3指同时触摸才显示错误信息
                _UI.errorVisible = true;
            }
            _Ticker.Update();
            if( Application.internetReachability == NetworkReachability.NotReachable )
            {
                _UI.errorStr = StringTrans.T("无网络连接、请检查您的网格...");
                return;
            }

            if(_VerReqing)
            {
                _UI.progress = (float)(((int)(Time.time - _BeginTime)) % (int)MaxRetryTime) / 16.0f;
            }
            
            if (WebPageRequester.error != null)
            {
                _UI.errorStr = WebPageRequester.error;
            }
            else
            {
                _UI.errorStr = "";
            }
        }

        void HandleToUpdatePlayer(int btn)
        {
            string url = string.Format("{0}/uer/index.php?r=Api/RedirectUrl&keyword={1}", GameDefine.bgUrl, ChannelImpl.GetChannelName());

            Debug.Log("打开地址：" + url);
            Application.OpenURL(url);
            Debug.Log("游戏更新，打开更新链接：" + url);

            Application.Quit();
        }
    }
}