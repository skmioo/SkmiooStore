using Datas;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;
using System.Linq;
using System;

[CustomEditor(typeof(RoleDataSet))]
public class RoleDataEditor : Editor
{
    string csvPath = "";
    RoleDataSet ins;
    private void Awake()
    {
        ins = target as RoleDataSet;
    }

    public override void OnInspectorGUI()
    {

        GUILayout.BeginHorizontal();
        GUILayout.Label("CSV路径", GUILayout.Width(60));
        csvPath = GUILayout.TextField(csvPath);

        if (GUILayout.Button("导入Hero数据", GUILayout.Width(100)))
        {
            CsvTools ct = new CsvTools(csvPath);
            ct.HandleHeroCSV(ins.heroData);
            EditorUtility.SetDirty(ins);
            AssetDatabase.SaveAssets();
        }

        if (GUILayout.Button("导入怪物数据", GUILayout.Width(100)))
        {
            CsvTools ct = new CsvTools(csvPath);
            ct.HandleMonsterCSV(ins.enemyData);

            List<RoleData> rd = new List<RoleData>();
            for (int i = 0; i < ins.enemySeniorData.Count; i++)
            {
                rd.Add(ins.enemySeniorData[i].roleData);
            }

            ct.HandleMonsterCSV(rd);

            EditorUtility.SetDirty(ins);
            AssetDatabase.SaveAssets();
        }

        GUILayout.EndHorizontal();

        var lastR = GUILayoutUtility.GetLastRect();

        if (lastR.Contains(Event.current.mousePosition) && DragAndDrop.objectReferences.Length > 0)
        {
            DragAndDrop.visualMode = DragAndDropVisualMode.Copy;
            var path = AssetDatabase.GetAssetPath(DragAndDrop.objectReferences[0]);
            if (Path.GetExtension(path).ToLower().Trim() != ".csv")
            {
                DragAndDrop.visualMode = DragAndDropVisualMode.Rejected;
            }
            else if (Event.current.type == EventType.DragExited)
            {
                csvPath = path;
                Event.current.Use();
            }
        }


        GUILayout.Space(10);
        base.OnInspectorGUI();
    }
}


public class CsvTools
{
    string csvPath;
    string[] texts;
    public CsvTools(string path)
    {
        csvPath = path;
        FileInfo f = new FileInfo(csvPath);
        var t = File.ReadAllText(f.FullName);
        texts = t.Split('\r');

        for (int i = 0; i < texts.Length; i++) if (texts[i][0] == '\n') texts[i] = texts[i].Substring(1);

    }

    public string[] GetRow(int rowIndex)
    {
        if (rowIndex >= 0 && rowIndex < texts.Length)
        {
            return texts[rowIndex].Split(',');
        }
        return null;
    }

    public string[] GetColumn(int lineIndex)
    {
        if (texts.Length > 0 && lineIndex >= 0 && texts[0].Split(',').Length > lineIndex)
        {
            List<string> line = new List<string>();
            for (int i = 0; i < texts.Length; i++)
            {
                try
                {
                    var value = texts[i].Split(',')[lineIndex];
                    line.Add(value);
                }
                catch (Exception)
                {
                    Debug.Log($"i {i} c {texts[i]}");
                    throw;
                }

            }
            return line.ToArray();
        }
        return null;
    }

    public void HandleHeroCSV(List<RoleData> source)
    {
        var typelist = texts[1].Split(',');
        var idIndex = Array.IndexOf(texts[2].Split(','), "id");

        for (int i = 4; i < texts.Length; i++)
        {
            if (string.IsNullOrEmpty(texts[i]))
            {
                continue;
            }

            string[] line = texts[i].Split(',');

            RoleData r_data = source.Find(x => x.id == int.Parse(line[idIndex]));
            if (r_data == null)
            {
                source.Add(r_data = new RoleData());
            }

            r_data.name = line[1];
            r_data.unitType = UnitType.人类;
            //r_data.roleHaveSkill = new List<int>();
            //r_data.roleHaveSkill = line[2].Split('|').ParseToInt();
            r_data.hp = int.Parse(line[3]);
            r_data.defence = int.Parse(line[4]);
            r_data.minAtk = int.Parse(line[5]);
            r_data.maxAtk = int.Parse(line[6]);
            r_data.dodge = int.Parse(line[7]);
            r_data.crits = int.Parse(line[8]);
            r_data.rate = int.Parse(line[9]);
            r_data.speed = int.Parse(line[10]);
            r_data.bleed = int.Parse(line[11]);
            r_data.poison = int.Parse(line[12]);
            r_data.debuff = int.Parse(line[13]);
            r_data.vertigo = int.Parse(line[14]);
            r_data.position = int.Parse(line[15]);
            r_data.death = int.Parse(line[16]);
        }
    }

    public void HandleMonsterCSV(List<RoleData> source)
    {
        var typelist = texts[1].Split(',');
        var idIndex = Array.IndexOf(texts[2].Split(','), "id");

        for (int i = 4; i < texts.Length; i++)
        {
            string[] line = texts[i].Split(',');
            if (line.Length <= 10) continue;
            RoleData r_data = source.Find(x => x.id == int.Parse(line[idIndex]));
            if (r_data == null)
            {
                source.Add(r_data = new RoleData());
            }

            r_data.name = line[2];
            r_data.unitType = (UnitType)Enum.Parse(typeof(UnitType), line[3]);
            r_data.size = int.Parse(line[4]);
            r_data.roleHaveSkill = new List<int>();
            r_data.roleHaveSkill = line[5].Split('|').ParseToInt();
            r_data.actNum = int.Parse(line[6]);
            r_data.preferMove = (PreferMove)Enum.Parse(typeof(PreferMove), line[7]);
            r_data.hp = int.Parse(line[9]);
            r_data.defence = int.Parse(line[10]);
            r_data.minAtk = int.Parse(line[11]);
            r_data.maxAtk = int.Parse(line[12]);
            r_data.dodge = int.Parse(line[13]);
            r_data.crits = int.Parse(line[14]);
            r_data.rate = int.Parse(line[15]);
            r_data.speed = int.Parse(line[16]);
            r_data.bleed = int.Parse(line[17]);
            r_data.poison = int.Parse(line[18]);
            r_data.debuff = int.Parse(line[19]);
            r_data.vertigo = int.Parse(line[20]);
            r_data.position = int.Parse(line[21]);
        }
    }

}

public static class ListTools
{
    public static List<int> ParseToInt(this Array array)
    {
        List<int> intList = new List<int>();
        foreach (var item in array)
        {
            if (int.TryParse(item.ToString(), out var value))
            {
                intList.Add(value);
            }
        }
        return intList;
    }
}