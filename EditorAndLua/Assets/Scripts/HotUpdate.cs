using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class HotUpdate : MonoBehaviour
{
	public Image img;

	private void Start()
	{
		//第一步加载ab文件
		AssetBundle ab = AssetBundle.LoadFromFile(Config.ABPath + "/one" + "/ui");

		//第二步根据名称加载资源
		img.sprite = ab.LoadAsset<Sprite>("Grid");
		ab.Unload(false);
	}


	public void OnClick()
	{

		//第一步加载ab文件
		AssetBundle ab = AssetBundle.LoadFromFile(Config.ABPath + "/two" + "/ui");

		//第二步根据名称加载资源
		img.sprite = ab.LoadAsset<Sprite>("Grid");
		ab.Unload(false);
	}

}

