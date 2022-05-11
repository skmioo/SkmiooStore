using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

public class NodeWindow : EditorWindow
{
	static NodeWindow window;
	static GameObject nodeManager;
	internal static void OpenWindow(GameObject gameObject)
	{
		window = GetWindow<NodeWindow>();
		nodeManager = gameObject;
	}
	//界面有一点变化的时候调用
	private void Update()
	{
		Selection.activeGameObject = nodeManager;
	}


	internal static void CloseWindow()
	{
		window.Close();
	}
}

