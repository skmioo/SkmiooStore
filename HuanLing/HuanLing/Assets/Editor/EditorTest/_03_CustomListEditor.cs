using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// 自定义绘制List对象
/// 使用serializedObject来修改参数的话Unity会自动有各种帮助函数，例如自动添加Undo功能
/// 如果直接修改参数的话，需要使用EditorUtility.SetDirty来告诉Unity需要保存数据
/// BeginChangeCheck()和EndChangeCheck()会检测它们之间的GUI有没有被修改，如果修改了的话可以据此修改参数
/// Undo.RecordObject可以为下一步修改添加Undo/Redo
/// EditorUtility.DisplayDialog可以打开内置对话框
/// </summary>
[CustomEditor(typeof(_03_CustomList))]
public class _03_CustomListEditor : Editor
{
	_03_CustomList m_Target;

	public override void OnInspectorGUI()
	{
		m_Target = (_03_CustomList)target;

		DrawDefaultInspector();
		DrawStatesInspector();
	}

	void DrawStatesInspector()
	{
		//这俩行代码跟	[Header("State")]效果一致
		GUILayout.Space(5);
		GUILayout.Label("State", EditorStyles.boldLabel);

		for (int i = 0; i < m_Target.States.Count; ++i)
		{
			DrawState(i);
		}

		DrawAddStateButton();
	}
	void DrawState(int index)
	{
		if (index < 0 || index >= m_Target.States.Count)
		{
			return;
		}
		// 在我们的serializedObject中找到States变量
		// serializedObject允许我们方便地访问和修改参数，Unity会提供一系列帮助函数。例如，我们可以通过serializedObject来修改组件值，而不是直接修改，Unity会自动创建Undo和Redo功能
		SerializedProperty list = serializedObject.FindProperty("States");

		GUILayout.BeginHorizontal();
		{
			//(未识别该代码)
			// 如果是在实例化的prefab上修改参数，我们可以模仿Unity默认的途径来让修改过的而且未被Apply的值显示成粗体
			if (list.isInstantiatedPrefab == true)
			{
				//The SetBoldDefaultFont functionality is usually hidden from us but we can use some tricks to
				//access the method anyways. See the implementation of our own EditorGUIHelper.SetBoldDefaultFont
				//for more info
				//EditorGUIHelper.SetBoldDefaultFont(list.GetArrayElementAtIndex(index).prefabOverride);	
			}
			GUILayout.Label("Name", EditorStyles.label, GUILayout.Width(50));

			#region 检测数值变化
			EditorGUI.BeginChangeCheck();
			string newName = GUILayout.TextField(m_Target.States[index].Name, GUILayout.Width(120));
			Vector3 newPosition = EditorGUILayout.Vector3Field("",m_Target.States[index].Position);
			if (EditorGUI.EndChangeCheck())
			{
				Undo.RecordObject(m_Target, "Modify State");
				m_Target.States[index].Name = newName;
				m_Target.States[index].Position = newPosition;
				// 如果我们直接修改属性，而没有通过serializedObject，那么Unity并不会保存这些数据，Unity只会保存那些标识为dirty的属性
				EditorUtility.SetDirty(m_Target);
			}
			#endregion

			if (GUILayout.Button("Remove"))
			{
				//Plays system beep sound.
				EditorApplication.Beep();

				// 可以很方便的显示一个包含特定按钮的对话框，例如是否同意删除
				if (EditorUtility.DisplayDialog("Really?", "Do you really want to remove the state '" + m_Target.States[index].Name + "'?", "Yes", "No") == true)
				{
					Undo.RecordObject(m_Target, "Delete State");
					m_Target.States.RemoveAt(index);
					EditorUtility.SetDirty(m_Target);
				}
			}
		}
		GUILayout.EndHorizontal();
	}

	//TODO
	void DrawAddStateButton()
	{

	}
}
