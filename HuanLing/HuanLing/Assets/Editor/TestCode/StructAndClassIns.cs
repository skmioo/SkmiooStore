using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;

//[CanEditMultipleObjects]
[CustomEditor(typeof(StructAndClass))]
public class StructAndClassIns : Editor
{
	StructAndClass _target;
	private void OnEnable()
	{
		_target = target as StructAndClass;
	}

	private void OnDisable()
	{
		_target = null;
	}
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		EditorGUILayout.HelpBox(serializedObject.FindProperty("tip").stringValue, MessageType.Info,true);
		//GUILayout.TextField
	}
}
