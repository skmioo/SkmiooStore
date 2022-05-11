using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
public class ExportAB
{
	[MenuItem("工具/导出AB包")]
	public static void exportAB()
	{
		string path = Config.ABPath;
		if (!Directory.Exists(path))
		{
			Directory.CreateDirectory(path);
		}
		//生成ab包文件
		BuildPipeline.BuildAssetBundles(path,
			BuildAssetBundleOptions.ForceRebuildAssetBundle | BuildAssetBundleOptions.ChunkBasedCompression, 
			BuildTarget.StandaloneWindows);
	}
}
