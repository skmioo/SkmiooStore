using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(Player))]
public class PlayerEditor : Editor
{
	private Player _Component;

	private void OnEnable()
	{
		_Component = target as Player;
	}

	private void OnDisable()
	{
		_Component = null;
	}

	public override void OnInspectorGUI()
	{
		//base.OnInspectorGUI();
		EditorGUILayout.LabelField("人物相关属性");
		_Component.Id = EditorGUILayout.IntField("玩家ID", _Component.Id);
		_Component.Name = EditorGUILayout.TextField("玩家姓名", _Component.Name);
		_Component.Atk = EditorGUILayout.FloatField("玩家攻击", _Component.Atk);
		_Component.isMan = EditorGUILayout.Toggle("玩家是否男性", _Component.isMan);
		_Component.headDir = EditorGUILayout.Vector3Field("玩家朝向", _Component.headDir);
		_Component.Hair = EditorGUILayout.ColorField("玩家头发", _Component.Hair);
		_Component.Weapon = EditorGUILayout.ObjectField("玩家武器", _Component.Weapon,typeof(GameObject),true) as GameObject;
		_Component.Cloth = EditorGUILayout.ObjectField("玩家衣服", _Component.Cloth, typeof(Texture), false) as Texture;
		_Component.pro = (PlayerProfression)EditorGUILayout.EnumPopup("玩家职业", _Component.pro);
		_Component.loveColor = (PlayerLoveColor)EditorGUILayout.EnumFlagsField("玩家喜欢颜色", _Component.loveColor);
	
		
		//终极数据类型绘制
		//更新可序列化数据
		serializedObject.Update();
		SerializedProperty Items = serializedObject.FindProperty("Items");
		EditorGUILayout.PropertyField(Items, new GUIContent("道具信息"), true);
		serializedObject.ApplyModifiedProperties();

		_Component.Atk = EditorGUILayout.Slider(new GUIContent("玩家攻击力"), _Component.Atk, 0, 100);
		if (_Component.Atk > 80)
		{
			EditorGUILayout.HelpBox("攻击力太高了", MessageType.Error);
		}
		if (GUILayout.Button("测试"))
		{
			Debug.Log("测试");
		}
		EditorGUILayout.BeginHorizontal();
		if (GUILayout.Button("按钮1"))
		{
			Debug.Log("按钮1");
		}
		if (GUILayout.Button("按钮2"))
		{
			Debug.Log("按钮2");
		}
		EditorGUILayout.EndHorizontal();
	}

}
