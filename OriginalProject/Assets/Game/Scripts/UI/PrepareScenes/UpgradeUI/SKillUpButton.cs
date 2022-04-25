using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Datas;

public class SKillUpButton : HoverableItem
{
    public event Action<int> OnUpClicked;
    public event Action<SKillUpButton,HoverSkillInfoUI> OnHoverEnter, OnHoverExit;
    public Image activeIcon, lockedIcon, upIcon;
    public GameObject resourceObj;
    private Text resourceText;
    public int requireMedalLevel;
    public int requireResource;
    
    //[HideInInspector]
    public int level;
    private Button btn;
    [HideInInspector]
    public bool isActive,isEnabled;

    protected override void Awake()
    {
        base.Awake();
        btn = GetComponent<Button>();
        btn.onClick.AddListener(ClickUp);
        resourceText = resourceObj.GetComponentInChildren<Text>(true);
    }

    void ClickUp()
    {
        if (OnUpClicked != null)
        {
            OnUpClicked(level);
        }
    }

    protected override void PointerEnter(GameObject go)
    {
        if (OnHoverEnter != null)
        {
            OnHoverEnter(this,hoverInfoUI as HoverSkillInfoUI);
        }
    }

    protected override void PointerExit(GameObject go)
    {
        if (OnHoverExit != null)
        {
            OnHoverExit(this, hoverInfoUI as HoverSkillInfoUI);
        }
    }

    public void RefreshItem(int lvLimit,int medalLv,int res,float disc,int targetLv)
    {
        if (level.Equals(targetLv))
        {
            if (lvLimit >= level && medalLv >= requireMedalLevel)
            {
                //满足解锁条件
                SetAsUp();
                //判断资源是否足够
                int requireRes = (int)(requireResource * (1 - disc)+0.5);
                resourceText.text = requireRes.ToString();
                if (res >= requireRes)
                {
                    ShowResourceCost(true);
                }
                else
                {
                    ShowResourceCost(false);
                }
            }
        }
    }

    public void ShowResourceCost(bool isReady)
    {
        resourceObj.SetActive(true);
        if (isReady)
        {
            resourceText.color = Color.white;
        }
        else
        {
            resourceText.color = Color.red;
        }
    }

    public void HideResourceCost()
    {
        resourceObj.SetActive(false);
    }

    public void SetAsActive()
    {
        lockedIcon.gameObject.SetActive(false);
        upIcon.gameObject.SetActive(false);
        activeIcon.gameObject.SetActive(true);
        btn.enabled = false;
        isEnabled = false;
        isActive = true;
    }

    public void SetAsLocked()
    {
        upIcon.gameObject.SetActive(false);
        activeIcon.gameObject.SetActive(false);
        lockedIcon.gameObject.SetActive(true);
        btn.enabled = false;
        isActive = false;
        isEnabled = false;
    }

    public void SetAsUp()
    {
        activeIcon.gameObject.SetActive(false);
        lockedIcon.gameObject.SetActive(false);
        upIcon.gameObject.SetActive(true);
        btn.enabled = true;
        isEnabled = true;
        isActive = false;
    }
}
