using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;
using UYMO;

/// <summary>
/// 引导入口
/// </summary>
public class Boot : MonoBehaviour
{
    /// <summary>
    /// 当前是否为本地烧制调试，默认false
    /// </summary>
    public static bool LocalBake
    {
        get { return false; }
    }
    /// <summary>
    /// 是否启用二级制layout，默认false
    /// </summary>
    public static bool LayoutBinEnabled
    {
        get { return false; }
    }

    public const string GameCore = "gamecore.ab";
    public const string LoaderDLLFile = "drloader.ab";

    GameObject _MessageDlg;
    AssemblyLoader _Loader;
    private static Boot _Instance;
    void Awake()
    {
        if (_Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        _Instance = this;
        gameObject.AddComponent<DRLoader.GameLoader>();
        //LoadDRLoader();
    }

    void LoadDRLoader()
    {
        string path = System.IO.Path.Combine(Application.persistentDataPath + "/ExtRes", LoaderDLLFile);
        if (File.Exists(path))
        {
            path = "file://" + path;
        }
        else
        {
            path = System.IO.Path.Combine(Application.streamingAssetsPath, LoaderDLLFile);
        }
        bool forceNative = Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor;
        _Loader = new AssemblyLoader(path, "DRLoader", forceNative ? AssemblyPosition.Native : AssemblyPosition.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        if (BaseVersion.IsInner)
        {//内网才处理

#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.F3))
            {
                ToggleGameConsole();
            }
#else
        if(Input.touchCount >= 6)
        {
            FetchGameConsole();
        }
#endif
        }

        if (_Loader != null)
        {
            _Loader.Update();
            if (_Loader.assemble != null)
            {
                Type loader = _Loader.assemble.GetType("DRLoader.GameLoader");
                gameObject.AddComponent(loader);
                StreamWriter md5file = new StreamWriter(Application.persistentDataPath + "/loader.md5", false, System.Text.Encoding.ASCII);
                md5file.Write(_Loader.md5);
                md5file.Flush();
                md5file.Close();
                _Loader = null;
                //Destroy(this);
            }
        }
    }

    public static void FetchGameConsole()
    {
        var dlg = UYMO.GameConsole.ConsoleMgr.FetchDlg<UYMO.GameConsole.ConsoleMainDlg>();
        dlg.visible = true;
    }

    public static void ToggleGameConsole()
    {
        var dlg = UYMO.GameConsole.ConsoleMgr.TryGetDlg<UYMO.GameConsole.ConsoleMainDlg>();
        if (dlg == null)
        {
            UYMO.GameConsole.ConsoleMgr.FetchDlg<UYMO.GameConsole.ConsoleMainDlg>();
        }
        else
        {
            dlg.visible = !dlg.visible;
        }
    }

    /// <summary>
    /// 是否直接启动游戏（不需要检查版本，更新资源)
    /// </summary>
    public static bool ShouldDirectLaunchGame()
    {
#if LOAD_FROM_RESOURCES && UNITY_EDITOR
        return true;
#else
        return false;
#endif
    }
}
