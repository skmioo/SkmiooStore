
using System;
using System.IO;
using UYMO;
using UnityEngine;
using SLua;

namespace DRLoader
{
    class LaunchGameState : GameUpdateSate
    {
        LoadUI _UI;
        AssemblyLoader _Loader;
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
            Debug.Log("Enter Launch Game!");
            _UI = ui;
            string path = System.IO.Path.Combine(Application.persistentDataPath + "/ExtRes", Boot.GameCore);
            if( Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor)
            {
                path = System.IO.Path.Combine("./Data/ExtRes", Boot.GameCore);
                path = Path.GetFullPath(path);
            }
            if (File.Exists(path))
            {
                path = "file://" + path;
            }
            else
            {
                path = System.IO.Path.Combine(Application.streamingAssetsPath, Boot.GameCore);
                if( Application.platform != RuntimePlatform.Android)
                {
                    path = "file://" + path;
                }
            }
            Debug.Log("GameCore Path:" + path);
            _Loader = new AssemblyLoader(path, "Assembly-CSharp,");
        }

        public object Exit()
        {
            return null;
        }

        public void Update()
        {
            _Loader.Update();
            if( _Loader.assemble != null)
            {
                var types = _Loader.assemble.GetTypes();
                var ss = _Loader.assemble.GetType("UYMO.Game");
                if( ss != null )
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
