using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRLoader;
using UnityEngine;
using UnityEngine.Networking;
using UYMO;

namespace Skmioo.MyLoader.States
{
	class MyInitLangeState : GameUpdateState
	{
		LoadUI _UI;
		bool _Complete;
		public bool complete
		{
			get
			{
				return _Complete;
			}
		}

		WWW _load;
		public void Enter(LoadUI ui, object data)
		{
			_UI = ui;
			_UI.loadInfo = MyStringTrans.T("初始化语言包...");
			string path = Path.Combine(Application.persistentDataPath + "/ExtRes", MyStringTrans.LanPackName);
			if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.OSXEditor)
			{
				path = Path.Combine("./Data/ExtRes", MyStringTrans.LanPackName);
				path = Path.GetFullPath(path);
			}
			if (File.Exists(path))
			{
				path = "file://" + path;
			}
			else {
				path = Path.Combine(Application.streamingAssetsPath, StringTrans.LanPackName);
				if (Application.platform != RuntimePlatform.Android)
				{
					path = "file://" + path;
				}
			}
			try
			{
				_load = new WWW(path);
			}
			catch (System.Exception ex)
			{
				Debug.Log("No language pack!");
				_Complete = true;
			}

		}

		public object Exit()
		{
			return null;
		}

		public void update()
		{
			if (_load != null && _load.isDone)
			{
				if (string.IsNullOrEmpty(_load.error))
				{
					MyStringTrans.ReloadLanPack(_load.bytes);
				}
				else
				{
					Debug.LogWarningFormat("load language error:{0}", _load.error);
				}
				_Complete = true;
			}
		}
	}
}
