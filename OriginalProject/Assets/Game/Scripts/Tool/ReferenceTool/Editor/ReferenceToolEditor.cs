using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System;

[CustomEditor(typeof(ReferenceTool))]
public class ReferenceToolEditor : Editor
{
    ReferenceTool ins;
    ReorderableList list;
    private void Awake()
    {
        ins = (ReferenceTool)target;
        list = new ReorderableList(ins.keys, typeof(string), false, false, true, true);
        list.drawElementCallback += Element;
        list.drawHeaderCallback += Header;
        list.onAddCallback += Add;
        list.onRemoveCallback += Remove;
    }


    private void Remove(ReorderableList list)
    {
        ins.Remove(ins.keys[list.index]);
    }

    private void Add(ReorderableList list)
    {
       string key = GetKey("New");
        ins.Add(key, null);
    }

    private void Header(Rect rect)
    {
        GUI.Label(rect, "引用管理");
    }

    private string GetKey(string key)
    {
        string tmp = key;
        while (ins.keys.Contains(tmp))
        {
            tmp += key;
        }
        return tmp;
    }

    private void Element(Rect rect, int index, bool isActive, bool isFocused)
    {
        var r = rect;
        r.width = rect.width * 0.3f;
        var tmp = EditorGUI.TextField(r, ins.keys[index]);

        if (tmp != ins.keys[index])
        {
            if (ins.keys.Contains(tmp))
            {
                EditorUtility.DisplayDialog("提示", "键值重复", "OK");
                ins.keys[index] = GetKey(tmp);
            }
            else
            {
                ins.keys[index] = tmp;
            }
        }

        r.x += r.width;
        r.width = rect.width * 0.05f;
        if (GUI.Button(r, "<<"))
        {
            if (ins.values[index] != null)
            {
                ins.keys[index] = GetKey(ins.values[index].name);
            }
        }
        r.x += rect.width * 0.05f;
        r.width = rect.width * 0.60f;
        ins.values[index] =  EditorGUI.ObjectField(r, ins.values[index], typeof(UnityEngine.Object), true);
        r.x += r.width;
        r.width = rect.width * 0.05f;
        while (ins.priority.Count <= index)
        {
            ins.priority.Add(0);
        }

        ins.priority[index] = EditorGUI.IntField(r, ins.priority[index]);
    }

    public override void OnInspectorGUI()
    {
        if (list == null) Awake();

        GUILayout.BeginHorizontal("box");
        ins.group = EditorGUILayout.TextField("当前分组：", ins.group);
        GUILayout.EndHorizontal();
        list.DoLayoutList();
        if (GUI.changed)
        {
            EditorUtility.SetDirty(ins);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }
}
