using UnityEngine;  
using System.Collections;
using System;
/**********************************************
* @说明: NetworkManager 检查网络连接状态
* @作者：ZHM --- 海鸣不骑猪 
* @版本号：V1.00
**********************************************/
public sealed partial class NetworkManager
{ 
    /// <summary>
    /// 用于获取显示对象的心跳处理
    /// </summary>
    private static GameObject _gameobject;
    private static NetworkCheckMono _NetworkCheckMono;
    private System.Action<NetState> _CheckNetTickFun;
    /// <summary>
    /// 初始化是否完成
    /// </summary>
    public bool IsInitOk = false;

    /// <summary>
    /// 初始化 网络连接
    /// </summary>
    /// <param name="CheckNetTickFun"> 网络状态检查 方法</param>
	public void OnInit(System.Action<NetState> CheckNetTickFun = null)
    {
        if (CheckNetTickFun == null)
        {
            CheckNetTickFun = CheckNet.CheckNetTick;
        }
        _CheckNetTickFun = CheckNetTickFun;
        if (_gameobject == null)
        {
            _gameobject = new GameObject("_Network_XW_");
            _NetworkCheckMono = _gameobject.AddComponent<NetworkCheckMono>();
        }
        _gameobject.SetActive(true);
		GameObject.DontDestroyOnLoad(_gameobject);
        _NetworkCheckMono.Run(WaitCheckNetTimer, CheckTick, Update, QuitFun);
        IsInitOk = true;
    }

    /// <summary>
    /// 销毁
    /// </summary>
    private void QuitFun()
    { 
        DestroyConnnect();
    }
    /// <summary>
    /// 用于检测连接状态
    /// </summary>
    private void CheckTick()
    { 
        if (_CheckNetTickFun == null || _NetObject == null)
        {
            return;
        }
        _CheckNetTickFun(CurrNetState);
    }

    /// <summary>
    /// 心跳处理
    /// </summary>
    private void Update()
    { 
        if (_NetObject == null)
        {
            return;
        } 
        _NetObject.Update();

		//ss
		ReceiveManager.Instance.OnTick();
		//ss
    } 
    //===================================================================================================================
    /// <summary>
    /// 连接的控制处理
    /// </summary>
    private class NetworkCheckMono : MonoBehaviour
    {
        private GameObject _gameObject; 
        private WaitForSeconds waitSecond ;
        /// <summary>
        /// 检查网络连接状态的 tick
        /// </summary>
		private System.Action _CheckNetTick;

        /// <summary>
        /// update
        /// </summary>
		private System.Action _UpdateFun;

        /// <summary>
        /// QuitFun
        /// </summary>
		private System.Action _QuitFun;
        
        /// <summary>
        ///  检查网络连接状态 的事件心跳
        /// </summary>
        private float _waitCheckNetTimer;

        private void Start()
        {
            _gameObject = gameObject;
            DontDestroyOnLoad(_gameObject);  
        }
        /// <summary>
        /// ka
        /// </summary>
        /// <param name="waitTimer"></param>
        /// <param name="CheckNetTick"></param>
        /// <param name="UpdateFun"></param>
		public void Run(float waitTimer, System.Action CheckNetTick, System.Action UpdateFun, System.Action QuitFun)
        {
			if (waitSecond != null)
				StopCoroutine(CheckTick());
            _waitCheckNetTimer = waitTimer;
            _CheckNetTick = CheckNetTick;
            _UpdateFun = UpdateFun;
            _QuitFun = QuitFun;
            waitSecond = new WaitForSeconds(_waitCheckNetTimer);
            StartCoroutine(CheckTick()); 
        }

        /// <summary>
        /// 心跳处理
        /// </summary>
        /// <returns></returns>
        private IEnumerator CheckTick()
        {
            while(true)
            { 
                yield return waitSecond;
                _CheckNetTick();
            }
        }

        /// <summary>
        /// 网络心跳
        /// </summary>
        private void Update()
        {
            _UpdateFun();
        }

		private void LateUpdate()
		{
			//_UpdateFun();
		}


        /// <summary>
        ///退出游戏的时候
        /// </summary>
        private void OnApplicationQuit()
        {
            _QuitFun();
            NetworkManager.DestroyConnnect();
        }
    }
}
