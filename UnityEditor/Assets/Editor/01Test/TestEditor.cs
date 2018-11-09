using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//选择test的物品,第二个是否包含test的子类
[CustomEditor(typeof(Test),true)]
public class TestEditor : Editor {
    //可以用于批量把场景中包含test与test子类的内部值进行修改
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        foreach (Object t in targets)
        {
            Test test = (Test)t;
            test.pos = new Vector3(2, 3, 4);
            test.x = 10;
        }
        EditorGUILayout.RectField("窗口坐标", new Rect(0,0,10,10));
    }
}
