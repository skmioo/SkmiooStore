using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : MonoBehaviour
{

	public GameObject canvas;
	// Start is called before the first frame update
    void Start()
    {
		//加载主ab包
		AssetBundle main = AssetBundle.LoadFromFile(Config.ABPath +Config.MainABAsset);
		//获取主ab包的配置文件
		AssetBundleManifest manifest = main.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
		//分析预制体所在ab包，依赖哪些ab包
		string[] dependencies = manifest.GetAllDependencies("perfab/ui");
		//加载依赖的ab包
		foreach (string dep in dependencies)
		{
			AssetBundle.LoadFromFile(Config.ABPath + "/" + dep);
		}
		//加载预制体所在的ab包
		AssetBundle prefab_ui = AssetBundle.LoadFromFile(Config.ABPath + "/perfab/ui");
		//加载预制体
		GameObject go = prefab_ui.LoadAsset<GameObject>("testUI");
		GameObject.Instantiate<GameObject>(go, canvas.transform);
	}

}
