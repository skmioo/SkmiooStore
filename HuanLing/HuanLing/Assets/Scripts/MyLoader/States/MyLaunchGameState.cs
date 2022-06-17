using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRLoader;
using SLua;
using UnityEngine;
using UYMO;

namespace Skmioo.MyLoader.States
{
	class MyLaunchGameState : GameUpdateState
	{
		LoadUI _UI;
		bool _Complete = false;
		public bool complete
		{
			get
			{
				return _Complete;
			}
		}

		public void Enter(LoadUI ui, object data)
		{
			_UI = ui;
			string path = System.IO.Path.Combine(Application.persistentDataPath + "/ExtRes", Boot.GameCore);
			if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor)
			{
				path = System.IO.Path.Combine("./Data/ExtRes", Boot.GameCore);
				path = Path.GetFullPath(path);
			}
			else
			{
				path = System.IO.Path.Combine(Application.streamingAssetsPath, Boot.GameCore);
				if (Application.platform != RuntimePlatform.Android)
				{
					path = "file://" + path;
				}
			}
			Debug.Log("GameCore Path:" + path);
			_Loader = new AssemblyLoader(path, "Assembly-CSharp,");
		}
		AssemblyLoader _Loader;
		public object Exit()
		{
			return null;
		}

		public void update()
		{
			_Loader.Update();
			if (_Loader.assemble != null)
			{
				var types = _Loader.assemble.GetTypes();
				var ss = _Loader.assemble.GetType("UYMO.Game");
				if (ss != null)
				{
					_UI.logicGO.AddComponent(ss);
				}
				else
				{
					Debug.LogError("Find Setup failed!");
				}
				LuaSvr.NotBindAssemblyCSharp = _Loader.isLoadFromFile;
				_Complete = true;
			}
		}
	}
}
