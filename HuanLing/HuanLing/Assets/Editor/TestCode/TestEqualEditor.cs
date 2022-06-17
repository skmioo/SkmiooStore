#if UNITY_EDITOR
using UnityEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CustomEditor(typeof(TestEqual))]
[CanEditMultipleObjects]
public class TestEqualEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		EditorGUILayout.HelpBox(" 总结：\n1、对于值类型来说，Equlas和==并没有什么区别，比较的都是值是否相等。\n2、对于引用类型来说，==比较的两个变量的”引用“是否一样（也就是“地址”是否一样）。而equals比较的是”内容“是否一样。\n3、string是引用类型，俩个值引用不一样，但==值一样，因为string对==做了重写	public static bool operator ==(String a, String b);\n4、俩个类的equals值为false因为没有对equals方法重写，此时使用的object里的equals方法,所以不一样", MessageType.Info);
		//GUILayout.TextField
	}
}

#endif