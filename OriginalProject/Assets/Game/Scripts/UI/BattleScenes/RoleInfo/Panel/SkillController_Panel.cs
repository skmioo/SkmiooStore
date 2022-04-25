using Datas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 角色信息面板上的技能管理
/// </summary>
public class SkillController_Panel : MonoBehaviour
{
    Dictionary<int, SkillData> skillDict;
    Dictionary<int, SkillData> otherSkillDict;
    //角色技能
    public List<SkillButton> skillButtons;
    //角色其他技能
    public SkillButton otherSkillButton;
    public SkillInfo skillInfo;

    ObjLife _objLife;
    //被选中的技能
    List<SkillButton> useSkills = new List<SkillButton>();
    

    void SetSkillDict()
    {
        skillDict = new Dictionary<int, SkillData>();
        otherSkillDict = new Dictionary<int, SkillData>();

        DataSetItem dataSet = DataManager.Instance.GetData("SkillData");
        SkillDataSet skillDataSet = dataSet.scriptableObject as SkillDataSet;

        foreach (var item in skillDataSet.heroSkills)
        {
            skillDict.Add(item.id, item);
        }

        foreach (var item in skillDataSet.otherSkills)
        {
            otherSkillDict.Add(item.id, item);
        }

    }

    private List<SkillData> skillDatas = new List<SkillData>();
    public void SetSkillButton(ObjLife objLife)
    {
        if (skillDict == null || otherSkillDict == null)
            SetSkillDict();
        _objLife = objLife;

        List<SkillMode> heroSkillMode = objLife.GetHeroMode().skillModes;

        useSkills.Clear();
        for (int i = 0; i < skillButtons.Count; i++)
        {
            SkillMode skillMode = heroSkillMode[i];
            SkillData skillData = skillDict[skillMode.skillId];

            skillButtons[i].SetSkillButton(skillData, skillMode);

            if (skillMode.isUse)
            {
                useSkills.Add(skillButtons[i]);
            }

            skillDatas.Add(skillData);
        }

        /*SkillMode otherSkillMode = objLife.GetHeroMode().equipmentOtherSkill;
        if (otherSkillMode != null)
        {
            if (otherSkillDict.ContainsKey(otherSkillMode.skillId))
            {
                SkillData _skillData = otherSkillDict[otherSkillMode.skillId];

                otherSkillButton.SetSkillButton(_skillData, otherSkillMode);
            }
        }*/

        AddListener();

        SetSkillPosInfo();
    }

    void AddListener()
    {
        for (int i = 0; i < skillButtons.Count; i++)
        {
            //EventListener.Get(skillButtons[i].gameObject).onClick = (go) => skillButtonDwon(go);
            UIEventManager.AddTriggersListener(skillButtons[i].gameObject).onClick = go => skillButtonDwon(go);
            Temp(skillButtons[i].gameObject, skillDatas[i]);
            //UIEventManager.AddTriggersListener(skillButtons[i].gameObject).onEnter = go => skillInfo.ShowInfo(go, skillDatas[i]);
            UIEventManager.AddTriggersListener(skillButtons[i].gameObject).onExit = go => skillInfo.ExitShow();
        }

        //UIEventManager.AddTriggersListener(otherSkillButton.gameObject).onEnter = go => skillInfo.ShowInfo(go);
        //UIEventManager.AddTriggersListener(otherSkillButton.gameObject).onExit = go => skillInfo.ExitShow();
    }

    void Temp(GameObject go, SkillData sd)
    {
        UIEventManager.AddTriggersListener(go).onEnter = g => skillInfo.ShowInfo(go, sd);
    }

    //技能被选中的逻辑
    private void skillButtonDwon(GameObject go)
    {
		RoleData heroData = _objLife.GetRoleData() as RoleData;

        if (heroData.vocation == HeroVocation.双面间谍)
        {
            return;
        }

        //如果当前技能已经被打开,那么就关闭
        SkillButton skillButton = go.GetComponent<SkillButton>();

        if (skillButton.level < 1)
        {
            return;
        }

        if (skillButton.skillMode.isUse)
        {
            skillButton.skillMode.isUse = false;
            skillButton.SelectedOff();

            useSkills.Remove(skillButton);
        }
        else
        {
            //判断这个技能是否能够打开
            if (useSkills.Count < 4)
            {
                skillButton.skillMode.isUse = true;
                skillButton.SelectedOn();

                useSkills.Add(skillButton);
            }
            else
            {
                Debug.Log("最多只能选择4个技能使用");
            }
        }

        SetSkillPosInfo();


    }


    int[] heroPos = new int[4];
    int[] enemyPos = new int[4];

    public Image[] heroPosImage;
    public Image[] enemyPosImage;
  
    //偏好位置计算，分析每一个技能的位置
    void SetSkillPosInfo()
    {
        for (int i = 0; i < heroPos.Length; i++)
        {
            heroPos[i] = 0;
        }

        for (int i = 0; i < enemyPos.Length; i++)
        {
            enemyPos[i] = 0;
        }

        foreach (var item in useSkills)
        {
            for (int i = 0; i < item.startPos.Length; i++)
            {
                if (item.startPos[i])
                {
                    heroPos[i]++;
                }
               
            }

            for (int i = 0; i < item.endPos.Length; i++)
            {
                if (item.endPos[i])
                {
                    enemyPos[i]++;
                }
            }
        }

        for (int i = 0; i < heroPosImage.Length; i++)
        {
            heroPosImage[i].fillAmount = heroPos[i] * 0.25f;
        }

        for (int i = 0; i < enemyPosImage.Length; i++)
        {
            enemyPosImage[i].fillAmount = enemyPos[i] * 0.25f;
        }

    }


    //其他技能
}
