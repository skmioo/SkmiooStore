using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PopWindow : EditorWindow
{
	[MenuItem("工具/创建窗口")]
	static void openWindow()
	{
		PopWindow popupWindow = GetWindow<PopWindow>(false,"弹窗标题", true);
		popupWindow.minSize = new Vector2(40, 30);
		popupWindow.maxSize = new Vector2(80, 70);
	}

	private void OnEnable()
	{
		
	}

	private void OnDisable()
	{
		
	}

	//界面有一点变化的时候调用
	private void Update()
	{
		
	}

	private void OnGUI()
	{
		if (GUILayout.Button("测试点击"))
		{
			Debug.Log("测试点击");
		}
	}

	//场景里物体变化，比如添加gameobject
	private void OnHierarchyChange()
	{
		
	}

	//项目发生变化 比如项目创建删除一个prefab
	private void OnProjectChange()
	{
		
	}

	//选择的物体发生变化
	private void OnSelectionChange()
	{
		//Debug.Log(Selection.activeGameObject.name);
	}


}
