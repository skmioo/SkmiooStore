using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Datas;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MoraleSkillItem : HoverableItem
{
    public event Action<HoverableItem> OnHoverEnter, OnHoverExit;
    public Image skillIcon,lockIcon;
    public bool isActive;
    private OtherSkillData skillData;

    public OtherSkillData MoraleSkillData { get => skillData; }

    public void InitialData(OtherSkillData skillData, bool isNew)
    {
        this.skillData = skillData;
        if (skillIcon != null)
        {
            var temp = skillData.icon.LoadAssetAsync<Sprite>();
            temp.Completed += img => skillIcon.sprite = img.Result;
        }
        if (isNew) playAudioBySkillLevelType();
        //hoverInfoUI.AddItem(skillData.describe);
    }
    /// <summary>
    /// 根据技能的品级播放音效 （当前的设定好像没有技能品级的设定）
    /// </summary>
    void playAudioBySkillLevelType()
    {
        AudioManager.Instance.PlayAudio(AudioName.Tree_Rare_mono, AudioType.Common);
        //AudioManager.Instance.PlayAudio(AudioName.Tree_Ordinary_mono, AudioType.Common);
    }
    public void Active()
    {
        gameObject.SetActive(true);
        skillIcon.enabled = true;
        skillIcon.color = Color.white;
        lockIcon.gameObject.SetActive(false);
        isActive = true;
    }

    public void ClearItem()
    {
        gameObject.SetActive(false);
        isActive = false;
    }

    public void DisableItem()
    {
        isActive = false;
        skillIcon.color = Color.gray;
    }

    protected override void PointerEnter(GameObject go)
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
        HoverSkillInfoUI skillInfoUI = hoverInfoUI as HoverSkillInfoUI;
        skillInfoUI.AddItem(skillData.name,0,Color.white);
        skillInfoUI.AddPositionInfo(0, skillPos);
        skillInfoUI.AddItem(skillData.describe, 1, Color.white);
        if (OnHoverEnter != null)
        {
            OnHoverEnter(this);
        }
    }

    protected override void PointerExit(GameObject go)
    {
        if (OnHoverExit != null)
        {
            OnHoverExit(this);
        }
    }
}
