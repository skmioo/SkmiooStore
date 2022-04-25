using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Datas;
using System;
using UnityEngine.UI;

public class BuildingLevelGroup : MonoBehaviour
{
    public event Action<EquipType,int,int> OnEquipLvUp;
    public EquipType equipType;
    public List<EquipLvItem> equipLvItems;
    private int maxLevel;
    [HideInInspector]
    public int currentLevel;
    private EquipInfo equipInfo;

    public void InitialLevelGroup(int currentLevel,int currentRes1,int currentRes2,EquipInfo equipInfo)
    {
        this.equipInfo = equipInfo;
        maxLevel = equipInfo.requireMents.Count;
        this.currentLevel = currentLevel;
        for (int i = 0; i < equipInfo.requireMents.Count; i++)
        {
            equipLvItems[i].OnHoverEnter += OnHoverEnter;
            equipLvItems[i].OnHoverExit += OnHoverExit;
            equipLvItems[i].InitialItem(equipInfo.requireMents[i].x, equipInfo.requireMents[i].y);
            equipLvItems[i].level = i + 1;
            equipLvItems[i].OnLevelUp += OnEquipItemLevelUp;
            if (currentLevel >= i + 1)
            {
                equipLvItems[i].ActiveItem();
            }
        }
        UpdateGroup(currentRes1, currentRes2);
    }

    private void OnEquipItemLevelUp(EquipLvItem equipLvItem)
    {
        AudioManager.Instance.PlayAudio(AudioName.UI_Click_Metallic_mono, AudioType.Common);
        equipLvItem.ActiveItem();
        currentLevel++;
        if (OnEquipLvUp != null)
        {
            OnEquipLvUp(equipType,equipLvItem.requireRes1,equipLvItem.requireRes2);
        }
    }

    public void UpdateGroup(int currentRes1,int currentRes2)
    {
        if (currentLevel < maxLevel)
        {
            equipLvItems[currentLevel].CheckResource(currentRes1, currentRes2);
            equipLvItems[currentLevel].EnableItem();
        }
    }

    private void OnHoverEnter(EquipLvItem equipItem, HoverInfoUI infoUI)
    {
        Text text;
        if (equipItem.isLocked)
        {
            text=infoUI.AddItem("先决条件：", 0,Color.white);
            text.color = Color.white;
            text= infoUI.AddItem(equipInfo.limitations[equipItem.level-1].name + "等级" + 
                equipInfo.limitations[equipItem.level-1].value, 1,Color.red);
        }
        else
        {
            text= infoUI.AddItem(equipInfo.descriptions[equipItem.level-1], 0,Color.white);
        }
        infoUI.Show();
        infoUI.transform.SetParent(transform.parent, true);
        infoUI.transform.SetAsLastSibling();
    }

    private void OnHoverExit(EquipLvItem equipItem, HoverInfoUI infoUI)
    {
        infoUI.Hide();
        infoUI.transform.SetParent(equipItem.transform, true);
    }
}
