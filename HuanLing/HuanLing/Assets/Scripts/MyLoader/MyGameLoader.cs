using DRLoader;
using Skmioo.MyLoader.States;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UYMO;

namespace Skmioo.MyLoader
{
	public class MyGameLoader : MonoBehaviour
	{
		Queue<GameUpdateState> _States;
		GameUpdateState _CurState;
		bool _GameLaunched = false;
		LoadUI _UI;
		private void Start()
		{
			Screen.sleepTimeout = -1;
			string storagePath = Application.persistentDataPath + "/";
			switch (Application.platform)
			{
				case RuntimePlatform.Android:
					break;
				case RuntimePlatform.IPhonePlayer:
					break;
				case RuntimePlatform.WindowsEditor:
				case RuntimePlatform.OSXEditor:
				case RuntimePlatform.WindowsPlayer:
					storagePath = Application.dataPath + "../Data/";
					break;
			}
			GameDefine.SetStoragePath(storagePath);
			_UI = new LoadUI();
			_UI.logicGO = gameObject;
			_UI.clientInfo = string.Format("PlayerVer: {0}", ChannelImpl.GetVersion());

			_States = new Queue<GameUpdateState>();
			if (!Boot.ShouldDirectLaunchGame())
			{
				_States.Enqueue(new MyInitLangeState());
				_States.Enqueue(new MyCheckVersionState());
				_States.Enqueue(new MyUpdateResState());
			}
			_States.Enqueue(new MyLaunchGameState());
			_CurState = _States.Dequeue();
			_CurState.Enter(_UI,null);
		}


		private void Update()
		{
			if (AssetsFileMgr.me.needUpdate)
			{
				AssetsFileMgr.me.Update();
			}

			NetFrame.Update();
			NetworkStateUtil.me._Update();

			if (_GameLaunched)
				return;
			if (!_CurState.complete)
			{
				_CurState.update();
			}
			else
			{
				object data = _CurState.Exit();
				if (_States.Count > 0)
				{
					_CurState = _States.Dequeue();
					_CurState.Enter(_UI, data);
				} else
				{
					LuanchGame();
					
				}
			}

		}

		private void LuanchGame()
		{
			_GameLaunched = true;
		}
	}

	


	internal interface GameUpdateState
	{
		void Enter(LoadUI ui, object data);
		object Exit();
		void update();
		bool complete { get; }
	}
}
