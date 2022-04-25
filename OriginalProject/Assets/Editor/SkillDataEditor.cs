using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Datas;
using System.IO;
using System.Linq;
using LitJson;
using System;

[CustomEditor(typeof(SkillDataSet))]
public class SkillDataEditor : Editor
{
    SkillDataSet ins;

    private void Awake()
    {
        ins = target as SkillDataSet;
    }

    public class CurveData
    {
        public string time;
        public string value;
        public string inTangent;
        public string outTangent;
    }

    public class CameraJsonData
    {
        public bool sameTime = true;
        public string moveType;
        public string[] rotationValue;
        public string scaleValue;
        public string fovValue;
        public string[] shakeValue;
        public int shakeVabrato;
        public string radomness;
        public bool snapping = false;
        public bool fadeout = true;
        public CurveData[] curve;
        public string time;
    }

    public override void OnInspectorGUI()
    {

        GUILayout.TextField("拖拽导入CSV");

        var r = GUILayoutUtility.GetLastRect();

        if (Event.current.type == EventType.DragExited && r.Contains(Event.current.mousePosition) && DragAndDrop.objectReferences.Length > 0)
        {
            string path = AssetDatabase.GetAssetPath(DragAndDrop.objectReferences[0]);
            DragAndDrop.visualMode = DragAndDropVisualMode.Generic;
            if (Path.GetExtension(path) == ".csv")
            {
                var csvw = EditorWindow.CreateWindow<CSVWindow>();
                csvw.path = path;
                csvw.ins = ins;
            }
            else if (Path.GetExtension(path) == ".asset")
            {
                var csvw = EditorWindow.CreateWindow<CSVWindow>();
                csvw.path = path;
                csvw.ins = ins;
            }
            else
            {
                DragAndDrop.visualMode = DragAndDropVisualMode.Rejected;
            }
            Event.current.Use();
        }

        GUILayout.BeginHorizontal("box");

        if (GUILayout.Button("导出英雄镜头数据数据"))
        {
            ExportCameraData(ins.heroSkills);
        }

        if (GUILayout.Button("导入英雄镜头数据数据"))
        {
            InportCameraData(ins.heroSkills);
        }

        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal("box");
        if (GUILayout.Button("导出怪物镜头数据数据"))
        {
            ExportCameraData(ins.enemySkills);
        }

        if (GUILayout.Button("导出怪物镜头数据数据"))
        {
            InportCameraData(ins.enemySkills);
        }
        GUILayout.EndHorizontal();
        base.OnInspectorGUI();

    }

    public void InportCameraData(List<SkillData> source)
    {
        var path = EditorUtility.OpenFilePanelWithFilters("选择镜头数据", "Assets", new string[] { "json files", "json" });
        var str = File.ReadAllText(path);

        try
        {
            Dictionary<string, List<CameraJsonData>> cmds = LitJson.JsonMapper.ToObject<Dictionary<string, List<CameraJsonData>>>(str);
            foreach (var item in cmds)
            {
                List<CameraJsonData> one = item.Value;
                int id = int.Parse(item.Key);

                var skilldata = source.Find(x => x.id == id);
                if (skilldata != null)
                {
                    for (int i = 0; i < one.Count; i++)
                    {
                        CameraMoveData cmd;
                        if (skilldata.cameraMoveData.Count > i)
                        {
                            cmd = skilldata.cameraMoveData[i];
                        }
                        else
                        {
                            cmd = new CameraMoveData();
                            skilldata.cameraMoveData.Add(cmd);
                        }
                        cmd.sameTime = one[i].sameTime;
                        cmd.moveType = (CameraMoveType)Enum.Parse(typeof(CameraMoveType), one[i].moveType);
                        cmd.rotationValue = new Vector3(float.Parse(one[i].rotationValue[0]), float.Parse(one[i].rotationValue[1]), float.Parse(one[i].rotationValue[2]));
                        cmd.scaleValue = float.Parse(one[i].scaleValue);
                        cmd.fovValue = float.Parse(one[i].fovValue);
                        cmd.shakeValue = new Vector3(float.Parse(one[i].shakeValue[0]), float.Parse(one[i].shakeValue[1]), float.Parse(one[i].shakeValue[2]));
                        cmd.shakeVabrato = one[i].shakeVabrato;
                        cmd.radomness = float.Parse(one[i].radomness);
                        cmd.snapping = one[i].snapping;
                        cmd.fadeout = one[i].fadeout;

                        Keyframe[] frames = new Keyframe[one[i].curve.Length];
                        for (int j = 0; j < one[i].curve.Length; j++)
                        {
                            frames[j] = new Keyframe(
                                float.Parse(one[i].curve[j].time),
                                float.Parse(one[i].curve[j].value),
                                float.Parse(one[i].curve[j].inTangent),
                                float.Parse(one[i].curve[j].outTangent)
                                );
                        }
                        cmd.curve = new AnimationCurve(frames);
                        cmd.time = float.Parse(one[i].time);
                    }
                }
                else
                {
                    Debug.LogWarning($"没找到这个技能ID [{id}]");
                }
            }
        }
        catch (Exception ex)
        {
            EditorUtility.DisplayDialog("错误", "Json数据有误详细请看控制台！", "确认");
            Debug.Log(ex.Message);
        }
    }

    public void ExportCameraData(List<SkillData> list)
    {
        Dictionary<string, List<CameraJsonData>> cmds = new Dictionary<string, List<CameraJsonData>>();
        for (int i = 0; i <list.Count; i++)
        {
            var d_list = new List<CameraJsonData>();

            for (int j = 0; j < ins.heroSkills[i].cameraMoveData.Count; j++)
            {
                var d = ins.heroSkills[i].cameraMoveData[j];
                CameraJsonData cjd = new CameraJsonData();
                cjd.sameTime = d.sameTime;
                cjd.moveType = d.moveType.ToString();
                cjd.rotationValue = new string[] { d.rotationValue.x.ToString(), d.rotationValue.y.ToString(), d.rotationValue.z.ToString() };
                cjd.scaleValue = d.scaleValue.ToString();
                cjd.fovValue = d.fovValue.ToString();
                cjd.shakeValue = new string[] { d.shakeValue.x.ToString(), d.shakeValue.y.ToString(), d.shakeValue.z.ToString() };
                cjd.shakeVabrato = d.shakeVabrato;
                cjd.radomness = d.radomness.ToString();
                cjd.snapping = d.snapping;
                cjd.fadeout = d.fadeout;
                cjd.curve = new CurveData[d.curve.length];
                for (int x = 0; x < d.curve.length; x++)
                {
                    cjd.curve[x] = new CurveData()
                    {
                        time = d.curve[x].time.ToString(),
                        value = d.curve[x].value.ToString(),
                        inTangent = d.curve[x].inTangent.ToString(),
                        outTangent = d.curve[x].outTangent.ToString()
                    };
                }
                cjd.time = d.time.ToString();
                d_list.Add(cjd);
            }
            cmds.Add(ins.heroSkills[i].id.ToString(), d_list);
        }
        string str = LitJson.JsonMapper.ToJson(cmds);
        File.WriteAllText(EditorUtility.SaveFilePanelInProject("保存镜头配置", "newCameraData", "json", ""), str);
        AssetDatabase.Refresh();
    }
}

public class CSVWindow : EditorWindow
{
    public string path;
    public SkillDataSet ins;

    private void OnGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("CSV路径:",GUILayout.Width(70));
        path = GUILayout.TextField(path);
        GUILayout.EndHorizontal();
        if (GUILayout.Button("导入技能描述(Hero)"))
        {
            CsvTools ct = new CsvTools(path);
            var r = new List<string>(ct.GetRow(0));

            if (r != null)
            {
                var index = r.FindIndex(x => x.Contains("技能描述"));
                var id_index = r.FindIndex(x => x.ToLower().Contains("id"));
                var  col = ct.GetColumn(index);
                var ids = ct.GetColumn(id_index);
                for (int i = 0; i < ids.Length; i++)
                {
                    if (int.TryParse(ids[i],out var id))
                    {
                        var hero = ins.heroSkills.Find(x => x.id == id);
                        if (hero != null)
                        {
                            Debug.Log($"ID {id} 原来描述 {hero.describe}");
                            hero.describe = col[i].Replace("\"", "");
                            Debug.Log($"ID {id} 现在描述 {hero.describe}");
                        }
                    }
                }
                EditorUtility.SetDirty(ins);
                AssetDatabase.SaveAssets();
            }
        }

        if (GUILayout.Button("导入技能数据(asset)"))
        {
            string u_path = path.Substring(path.IndexOf("Assets"));
            var data = AssetDatabase.LoadAssetAtPath<SkillDataSet>(u_path);
            ChangeData(ins.heroSkills, data.heroSkills);
            ChangeData(ins.enemySkills, data.enemySkills);
            EditorUtility.SetDirty(ins);
            AssetDatabase.SaveAssets();
        }
    }

    private void ChangeData(List<SkillData> src, List<SkillData> new_data)
    {
        for (int i = 0; i < new_data.Count; i++)
        {
            SkillData new_skill = new_data[i];
            SkillData old_skill = src.Find(x => x.id == new_skill.id);
            if (old_skill != null)
            {
                old_skill.name = new_skill.name;
                old_skill.describe = new_skill.describe;
                old_skill.tips = new_skill.tips;
                old_skill.skillType = new_skill.skillType;
                old_skill.targetType = new_skill.targetType;
                old_skill.position = new_skill.position;
                old_skill.rate = new_skill.rate;
                old_skill.crits = new_skill.crits;
                old_skill.critsDamage = new_skill.critsDamage;
                old_skill.atk = new_skill.atk;
                old_skill.skillTails = new_skill.skillTails;
                old_skill.skillBuffs = new_skill.skillBuffs;
                old_skill.useLimits = new_skill.useLimits;
                old_skill.targetLimits = new_skill.targetLimits;
                old_skill.additionalDamage = new_skill.additionalDamage;
                old_skill.killToActAgain = new_skill.killToActAgain;
                old_skill.summon = new_skill.summon;
                old_skill.cd = new_skill.cd;
            }
        }
    }

}