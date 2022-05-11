using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleLoad : MonoBehaviour
{
	public Image img;
    // Start is called before the first frame update
    void Start()
    {
		//第一步加载ab文件
		AssetBundle ab = AssetBundle.LoadFromFile(Config.ABPath+"/ui");

		//第二步根据名称加载资源
		img.sprite = ab.LoadAsset<Sprite>("Grid");
    }

 
}
