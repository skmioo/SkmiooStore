using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Datas;
using System;
using UnityEngine.UI;

public class SkillLevelGroup : MonoBehaviour
{
    public event Action<SkillLevelGroup, int> OnSkillUp;
    public List<SKillUpButton> skillUpButtons;
    public List<int> medalRequires, resRequires;

    private SkillData skillData;
    private SkillMode skillMode;
    private bool isReady;
    private int currentLvLimit, currentMedal;

    private void PrepareGroup()
    {
        for (int i = 0; i < skillUpButtons.Count; i++)
        {
            skillUpButtons[i].OnUpClicked += OnSkillUpRequest;
            skillUpButtons[i].OnHoverEnter += OnHoverEnter;
            skillUpButtons[i].OnHoverExit += OnHoverExit;
            skillUpButtons[i].requireMedalLevel = medalRequires[i];
            skillUpButtons[i].requireResource = resRequires[i];
        }
        isReady = true;
    }

    public void Initial(SkillData skillData, SkillMode skillMode)
    {
        if (!isReady)
            PrepareGroup();
        this.skillData = skillData;
        this.skillMode = skillMode;
        skillData.icon.LoadAssetAsync().Completed += go => skillUpButtons[0].activeIcon.sprite = go.Result;
        for (int i = 0; i < skillUpButtons.Count; i++)
        {
            skillUpButtons[i].level = i + 1;
            if (skillMode.level >= i + 1)
            {
                skillUpButtons[i].SetAsActive();
                skillUpButtons[i].HideResourceCost();
            }
            else
            {
                skillUpButtons[i].SetAsLocked();
                skillUpButtons[i].HideResourceCost();
            }
        }
    }

    public void RefreshGroup(int lvLimit, int medalLv, int res, float disc)
    {
        currentLvLimit = lvLimit; currentMedal = medalLv;
        for (int i = 0; i < skillUpButtons.Count; i++)
        {
            skillUpButtons[i].RefreshItem(lvLimit, medalLv, res, disc, skillMode.level + 1);
        }
    }

    private void OnHoverEnter(SKillUpButton skillUpBtn, HoverSkillInfoUI infoUI)
    {
        List<bool> skillPos = new List<bool>();
        skillPos.Add(skillData.position.A);
        skillPos.Add(skillData.position.B);
        skillPos.Add(skillData.position.C);
        skillPos.Add(skillData.position.D);
        skillPos.Add(skillData.position.W);
        skillPos.Add(skillData.position.X);
        skillPos.Add(skillData.position.Y);
        skillPos.Add(skillData.position.Z);
        if (skillUpBtn.isActive)
        {
            infoUI.AddItem(skillData.name, 0, Color.white);
            infoUI.AddPositionInfo(0, skillPos);
            infoUI.AddItem(skillData.describe, 1, Color.white);
        }
        else if (skillUpBtn.isEnabled)
        {
            infoUI.AddItem("当前等级", 0, Color.yellow);
            infoUI.AddItem(skillData.name, 1, Color.white);
            infoUI.AddPositionInfo(0, skillPos);
            infoUI.AddItem(skillData.describe, 2, Color.white);
            infoUI.AddItem("下一等级", 3, Color.yellow);
            infoUI.AddItem(skillData.name, 4, Color.white);
            infoUI.AddPositionInfo(1, skillPos);
            infoUI.AddItem(skillData.describe, 5, Color.white);
        }
        else
        {
            infoUI.AddItem("先决条件：", 0, Color.white);
            if (skillMode.level == skillUpBtn.level - 1)
                infoUI.AddItem(skillData.name + "等级" + (skillUpBtn.level - 1), 1, Color.white);
            else
                infoUI.AddItem(skillData.name + "等级" + (skillUpBtn.level - 1), 1, Color.red);
            if (currentLvLimit >= skillUpBtn.level)
                infoUI.AddItem("战斗心得等级" + skillUpBtn.level, 2, Color.white);
            else
                infoUI.AddItem("战斗心得等级" + skillUpBtn.level, 2, Color.red);
            if (currentMedal >= skillUpBtn.requireMedalLevel)
                infoUI.AddItem("勋章等级" + (skillUpBtn.level - 1), 3, Color.white);
            else
                infoUI.AddItem("勋章等级" + (skillUpBtn.level - 1), 3, Color.red);
        }
        infoUI.Show();
        infoUI.transform.SetParent(transform.parent, true);
        infoUI.transform.SetAsLastSibling();

        SkillUpPanel.instance.skillUpList.Add(skillUpBtn);
    }

    private void OnHoverExit(SKillUpButton skillUpBtn, HoverInfoUI infoUI)
    {
        infoUI.Hide();
        infoUI.transform.SetParent(skillUpBtn.transform, true);
        if (SkillUpPanel.instance.skillUpList.Contains(skillUpBtn))
            SkillUpPanel.instance.skillUpList.Remove(skillUpBtn);
    }

    public void SkillUp()
    {
        skillMode.level++;
        skillUpButtons[skillMode.level - 1].SetAsActive();
        skillUpButtons[skillMode.level - 1].HideResourceCost();
    }

    void OnSkillUpRequest(int targetLevel)
    {
        if (OnSkillUp != null)
        {
            OnSkillUp(this, skillUpButtons[targetLevel - 1].requireResource);
        }
    }
}
