using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EquipLvItem : HoverableItem
{
    public event Action<EquipLvItem> OnLevelUp;
    public event Action<EquipLvItem,HoverInfoUI> OnHoverEnter, OnHoverExit;
    public bool isLocked;
    public bool isReady;
    public GameObject activeIcon;
    public GameObject upIcon;
    public GameObject lockedIcon;
    public GameObject requireInfoObj;
    public int requireRes1, requireRes2;
    [HideInInspector]
    public int level;
    private Text res1Text, res2Text;
    private Button upBtn;

    public void InitialItem(int res1,int res2)
    {
        isLocked = true;
        requireRes1 = res1;requireRes2 = res2;
        res1Text = transform.Find("resourceObj/res1").GetComponent<Text>();
        res2Text = transform.Find("resourceObj/res2").GetComponent<Text>();
        res1Text.text = requireRes1.ToString();res2Text.text = requireRes2.ToString();
        upBtn = GetComponent<Button>();
    }

    public void ActiveItem()
    {
        //requireInfoObj.SetActive(false);
        upIcon.SetActive(false);
        activeIcon.SetActive(true);
        lockedIcon.SetActive(false);
        isLocked = false;
        upBtn.enabled = false;
    }

    public void EnableItem()
    {
        isLocked = false;
        activeIcon.SetActive(false);
        upIcon.SetActive(true);
        lockedIcon.SetActive(false);
        //requireInfoObj.SetActive(true);
        upBtn.enabled = true;
    }

    public void OnClickLvUp()
    {
        if (isLocked || !isReady) AudioManager.Instance.PlayAudio(AudioName.UI_Error_Subtle_Deep_stereo, AudioType.Common);
        if (!isLocked && isReady)
        {
            if (OnLevelUp != null)
            {
                OnLevelUp(this);
            }
        }
    }
    /// <summary>
    /// 检测材料是否足够支付
    /// </summary>
    /// <param name="resource1">玩家拥有的材料1数量</param>
    /// <param name="resource2">玩家拥有的材料2数量</param>
    /// <returns></returns>
    public bool CheckResource(int resource1,int resource2)
    {
        if (resource1 >= requireRes1)
        {
            res1Text.color = Color.white;
        }
        else
        {
            res1Text.color = Color.red;
        }
        if (resource2 >= requireRes2)
        {
            res2Text.color = Color.white;
        }
        else
        {
            res2Text.color = Color.red;
        }
        if (resource1 >= requireRes1 && resource2 >= requireRes2)
            isReady = true;
        else
            isReady = false;
        return isReady;
    }

    protected override void PointerEnter(GameObject go)
    {
        if (OnHoverEnter != null)
        {
            OnHoverEnter(this, hoverInfoUI);
        }
    }

    protected override void PointerExit(GameObject go)
    {
        if (OnHoverExit != null)
        {
            OnHoverExit(this, hoverInfoUI);
        }
    }
}
