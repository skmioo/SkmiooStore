using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(NodeManager))]
public class NodeManagerEditor : Editor
{
	bool isEditor = false; //是否处于编辑状态
	NodeManager manager;
	private RaycastHit hit;

	private void OnEnable()
	{
		manager = (NodeManager)target;
	}

	private void OnDisable()
	{
		manager = null;
	}

	public override void OnInspectorGUI()
	{
		//base.OnInspectorGUI();
		manager.cube = EditorGUILayout.ObjectField("预制体", manager.cube, typeof(GameObject), true) as GameObject;
		serializedObject.Update();
		EditorGUILayout.PropertyField(serializedObject.FindProperty("nodes"),new GUIContent("路径"),true);
		if (!isEditor && GUILayout.Button("开始编辑"))
		{
			NodeWindow.OpenWindow(manager.gameObject);
			isEditor = true;
		}

		if (isEditor && GUILayout.Button("结束编辑"))
		{
			NodeWindow.CloseWindow();
			isEditor = false;
		}

		if (GUILayout.Button("删除一个节点"))
		{
			if (manager != null)
			{
				if (manager.nodes.Count > 0)
				{
					DestroyImmediate(manager.nodes[manager.nodes.Count - 1]);
					manager.nodes.RemoveAt(manager.nodes.Count - 1);
				}
				
			}
		}
		if (GUILayout.Button("删除所有节点"))
		{
			if (manager != null)
			{
				for (int i = manager.nodes.Count - 1; i >= 0; i--)
				{
					DestroyImmediate(manager.nodes[i]);
				}
				manager.nodes.Clear();
			}
		}
	}

	//鼠标的移动和点击都会执行该函数
	private void OnSceneGUI()
	{
		if (!isEditor)
			return;
		if (Event.current.button == 0 && Event.current.type == EventType.MouseDown)
		{
			//编辑器模式下从gui除发射射线
			Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
			if (Physics.Raycast(ray, out hit, 100, 1 << 31))
			{
				InstancePathNode(hit.point + Vector3.up * 0.1f);
			}
		}
	}

	private void InstancePathNode(Vector3 vector3)
	{
		GameObject cube = Instantiate(manager.cube, manager.gameObject.transform);
		cube.transform.position = vector3;
		cube.SetActive(true);
		manager.nodes.Add(cube);
		//manager.nodes.Add(new GameObject(typeof))
	}
}
