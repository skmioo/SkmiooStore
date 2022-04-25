using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Datas;
using UIUtils;

/// <summary>
/// 技能信息面板
/// </summary>
public class SkillInfo : MonoBehaviour
{ 

    private static Color COLOR_CAST_POS = ColorHelper.HexaToRGB("F0E08A");
    private static Color COLOR_CAST_TARGET = ColorHelper.HexaToRGB("F76A6A");
    private static Color COLOR_NO_POS = ColorHelper.HexaToRGB("8A8A8A");


    [SerializeField]
    private Text infotext, _infotext;

    public Text skillNmae;

    [SerializeField]
    private GameObject position_target_monster;

    [SerializeField]
    private RawImage[] castPositions_m;
    [SerializeField]
    private RawImage[] target_aoe_m;
    [SerializeField]
    private RawImage[] targetPositions_m;


    [SerializeField]
    private GameObject position_target_hero;

    [SerializeField]
    private RawImage[] cast_aoe_h;
    [SerializeField]
    private RawImage[] castPositions_h;



    bool[] startPos = new bool[4];
    bool[] endPos = new bool[4];

    /// <summary>
    /// 当光标进入时,分析和显示技能的信息
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="skillButtonsIndex"></param>
    public void ShowInfo(GameObject pos, int skillButtonsIndex)
    {
        SkillData skillData = BattleFlowController.Instance.GetSkillDataByIndex(skillButtonsIndex);
        if (skillData == null)
        {
            return;
        }
        ShowInfo(pos, skillData);
    }

    public void ShowInfo(GameObject pos, SkillData skillData)
    {
        skillNmae.text = skillData.name;
        infotext.text = skillData.describe;
        _infotext.text = skillData.describe;

        ResetSkillPos(skillData);
        switch (skillData.targetType)
        {
            case SkillTargetType.自身:
                SetTargetHero(skillData);
                break;
            case SkillTargetType.己方单体:
                SetTargetHero(skillData);
                break;
            case SkillTargetType.己方单体_不含自身:
                SetTargetHero(skillData);
                break;
            case SkillTargetType.己方全体:
                SetTargetHero(skillData);
                break;
            case SkillTargetType.敌方单体:
                SetTargetMonster(skillData);
                break;
            case SkillTargetType.敌方群体:
                SetTargetMonster(skillData);
                break;
            default:
                break;
        }

        gameObject.SetActive(true);
        //transform.position = skillData is OtherSkillData? pos.transform.position + new Vector3(0,200,0): pos.transform.position;
        transform.position = pos.transform.position;

        //transform.position = pos.transform.position + new Vector3(0,-30,0);
    }

    public void ShowInfo(GameObject pos, OtherSkillData skillData)
    {
        skillNmae.text = skillData.name;
        infotext.text = skillData.describe + skillData.GetEntryDescribe();
        _infotext.text = skillData.describe + skillData.GetEntryDescribe();

        ResetSkillPos(skillData);
        switch (skillData.targetType)
        {
            case SkillTargetType.自身:
                SetTargetHero(skillData);
                break;
            case SkillTargetType.己方单体:
                SetTargetHero(skillData);
                break;
            case SkillTargetType.己方单体_不含自身:
                SetTargetHero(skillData);
                break;
            case SkillTargetType.己方全体:
                SetTargetHero(skillData);
                break;
            case SkillTargetType.敌方单体:
                SetTargetMonster(skillData);
                break;
            case SkillTargetType.敌方群体:
                SetTargetMonster(skillData);
                break;
            default:
                break;
        }

        gameObject.SetActive(true);
        transform.position = skillData is OtherSkillData ? pos.transform.position + new Vector3(0, 200, 0) : pos.transform.position;

        //transform.position = pos.transform.position + new Vector3(0,-30,0);
    }

    public void ExitShow()
    {
        gameObject.SetActive(false);
    }

    void SetTargetMonster(SkillData skillData)
    {
        position_target_monster.SetActive(true);
        position_target_hero.SetActive(false);

        //设置角色方
        for (int i = 0; i < startPos.Length; i++)
        {
            if (startPos[i])
            {
                castPositions_m[i].color = COLOR_CAST_POS;
            }
            else
            {
                castPositions_m[i].color = COLOR_NO_POS;
            }
        }

        //设置怪物方
        for (int i = 0; i < endPos.Length; i++)
        {
            if (endPos[i])
            {
                targetPositions_m[i].color = COLOR_CAST_TARGET;
            }
            else
            {
                targetPositions_m[i].color = COLOR_NO_POS;
            }
        }

        foreach (var item in target_aoe_m)
        {
            item.gameObject.SetActive(false);
        }

        //设置AOE
        if (skillData.targetType.Equals(SkillTargetType.敌方群体))
        {
            
            if (endPos[0] && endPos[1])
            {
                target_aoe_m[0].gameObject.SetActive(true);
            }

            if (endPos[1] && endPos[2])
            {
                target_aoe_m[1].gameObject.SetActive(true);
            }

            if (endPos[2] && endPos[3])
            {

                target_aoe_m[2].gameObject.SetActive(true);
            }
        }
  
        //解析有效位置，设置颜色
    }

    void SetTargetHero(SkillData skillData)
    {
        position_target_monster.SetActive(false);
        position_target_hero.SetActive(true);

        for (int i = 0; i < startPos.Length; i++)
        {
            if (startPos[i])
            {
                castPositions_h[i].color = COLOR_CAST_POS;
            }
            else
            {
                castPositions_h[i].color = COLOR_NO_POS;
            }
        }

        foreach (var item in cast_aoe_h)
        {
            item.gameObject.SetActive(false);
        }

        if (skillData.targetType.Equals(SkillTargetType.敌方群体))
        {
            if (startPos[0] && startPos[1])
            {               
                cast_aoe_h[0].gameObject.SetActive(true);
            }

            if (startPos[1] && startPos[2])
            {
                cast_aoe_h[1].gameObject.SetActive(true);
            }

            if (startPos[2] && startPos[3])
            {
                cast_aoe_h[2].gameObject.SetActive(true);
            }
        }

    }

    private void ResetSkillPos(SkillData skill)
    {
        startPos[0] = skill.position.A;
        startPos[1] = skill.position.B;
        startPos[2] = skill.position.C;
        startPos[3] = skill.position.D;


        endPos[0] = skill.position.W;
        endPos[1] = skill.position.X;
        endPos[2] = skill.position.Y;
        endPos[3] = skill.position.Z;
    }

    /// <summary>
    /// 技能描述解析,等所有技能描述更改规范后再启用
    /// </summary>
    /// <param name="s">技能描述</param>
    /// <param name="level">当前技能等级</param>
    /// <returns></returns>
    string AnalysisDicsString(string s,int level)
    {
        List<string> sList = new List<string>();
        string[] temp = s.Split('\n');//每行一串字符
        foreach (var item in temp)
        {
            string c = item;
            if (item.Contains("#"))
            {
                //int i = item.IndexOf("[");
                string[] _temp = item.Split('#');//@必定为第二串字符
                string[] _1t = _temp[1].Split('/');

                _temp[1] = _1t[level];

                foreach (var _item in _temp)
                {
                    c += _item;
                }
            }

            sList.Add(c);
        }

        string e = "";

        foreach (var item in sList)
        {
            e += item;
            e += "\n";
        }

        return e;
    }
}
