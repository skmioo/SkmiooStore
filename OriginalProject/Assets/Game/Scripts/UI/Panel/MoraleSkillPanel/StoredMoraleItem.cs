using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using Datas;
using UnityEngine.EventSystems;

public class StoredMoraleItem : HoverableItem
{
    public bool isLocked;
    public event Action<HoverableItem> OnHoverEnter, OnHoverExit;
    public event Action<OtherSkillData, OtherSkillData,StoredMoraleItem> OnReplaceSkill;
    public Image skillIcon;
    public Image lockIcon;
    public HeroMoraleBox heroMoraleBox;
    public int needExtLv;
    public Text titleText;
    [HideInInspector]
    public int index;
    private OtherSkillData skillData;

    public OtherSkillData SkillData => skillData;

    public void InitialData(OtherSkillData skillData)
    {
        if (isLocked)
            return;
        if (this.skillData == null)
        {
            this.skillData = skillData;
            skillData.icon.LoadAssetAsync<Sprite>().Completed += img => skillIcon.sprite = img.Result;
            skillIcon.gameObject.SetActive(true);
            AudioManager.Instance.PlayAudio(AudioName.UI_Click_Metallic_Bright_mono, AudioType.Common);
            //hoverInfoUI.AddItem(skillData.describe);
            if (OnReplaceSkill != null)
            {
                OnReplaceSkill(null, skillData, this);
                titleText.text = "已装备";
            }
        }
        else
        {
            if (OnReplaceSkill != null)
            {
                AudioManager.Instance.PlayAudio(AudioName.UI_Click_Metallic_Bright_mono, AudioType.Common);
                OnReplaceSkill(this.skillData, skillData,this);

            }
        }
    }

    public void ReplaceSkill(OtherSkillData current)
    {
        skillIcon.gameObject.SetActive(true);
        this.skillData = current;
        skillData.icon.LoadAssetAsync<Sprite>().Completed += img => skillIcon.sprite = img.Result;
        hoverInfoUI.ClearData();
        //hoverInfoUI.AddItem(skillData.describe);
    }

    public void ReplaceSkill(Sprite icon,OtherSkillData skillData,bool refresh=true)
    {
        skillIcon.gameObject.SetActive(true);
        this.skillData = skillData;
        skillIcon.sprite = icon;
        if (refresh)
            PointerEnter(gameObject);
    }

    public void Clear()
    {
        titleText.text = "未装备";
        skillData = null;
        skillIcon.gameObject.SetActive(false);
        skillIcon.sprite = null;
        hoverInfoUI.ClearData();
    }

    public void SetSkill()
    {
        if (!isLocked&&heroMoraleBox != null&&skillData!=null)
        {
            var tempMode = heroMoraleBox.herosMode;
            if (tempMode != null)
            {
                //var tempList = tempMode.skillModes;
                tempMode.moraleSkillId = skillData.id;
                //if (tempList.Count > 0)
                //{
                //    tempList[0].skillId = skillData.id;
                //}
                //else
                //{
                //    tempList.Add(new SkillMode() { skillId = skillData.id });
                //}
                /*if (heroMoraleBox.herosMode.equipmentOtherSkill != null)
                {
                    heroMoraleBox.herosMode.equipmentOtherSkill.skillId = skillData.id;
                }
                else
                {
                    heroMoraleBox.herosMode.equipmentOtherSkill = new SkillMode();
                    heroMoraleBox.herosMode.equipmentOtherSkill.skillId = skillData.id;
                }*/
            }
            else Clear();
        }
    }

    public void Unlock()
    {
        lockIcon.gameObject.SetActive(false);
        if (heroMoraleBox != null)
            heroMoraleBox.Unlock();
        isLocked = false;
    }

    private void ItemDrag(GameObject go,PointerEventData eventData)
    {

    }

    private void ItemEndDrag(GameObject go, PointerEventData eventData)
    {

    }

    protected override void PointerEnter(GameObject go)
    {
        if (isLocked)
        {
            
        }
        else
        {
            if (skillData == null)
                return;
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
            skillInfoUI.AddItem(skillData.name, 0, Color.white);
            skillInfoUI.AddPositionInfo(0, skillPos);
            skillInfoUI.AddItem(skillData.describe, 1, Color.white);
            if (OnHoverEnter != null)
                OnHoverEnter(this);
        }
        
    }
    protected override void PointerExit(GameObject go)
    {
        if (isLocked)
        {

        }
        else
        {
            if (skillData == null)
                return;
        }
        if (OnHoverExit != null)
            OnHoverExit(this);
    }
}
