using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Datas;
using System;
using GEvent;

public class HealBox : HoverableItem
{
    public event Action<HealBox, ObjLifeData> OnPutHero, OnCancelHeal;
    public event Action<HealBox, int> OnConfirmHeal;
    public event Action<HealBox, HoverInfoUI> OnHoverEnter, OnHoverExit;
    public Image heroIcon;
    public Image lockIcon;
    public GameObject requireResItem;
    public GameObject confirmBtn, cancelBtn;
    private Text requireResText;
    public bool isLocked;
    public bool isOccupied;
    private bool isReady;
    private Transform cancelButton, confirmButton;
    [HideInInspector]
    public int boxIndex;
    [HideInInspector]
    public int level;
    [HideInInspector]
    public RoleItem roleItem;
    [HideInInspector]
    public Transform confirmPlan;

    private void Start()
    {
        requireResText = requireResItem.GetComponentInChildren<Text>(true);
    }

    //public void InitialBoxData(int requireRes)
    //{
    //    requireResource = requireRes;
    //    requireResText.text = requireRes.ToString();
    //}

    public void OnPutHeroIn(RoleItem roleItem)
    {
        if (isLocked || isOccupied)
            return;
        AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
        this.roleItem = roleItem;
        if (OnPutHero != null)
        {
            OnPutHero(this, Camp.Instance.getDateForObj(roleItem.gameObject));
        }
    }

    public void UnLock()
    {
        isLocked = false;
        lockIcon.gameObject.SetActive(false);
    }

    public void LoadHero(RoleItem roleItem)
    {
        this.roleItem = roleItem;
        confirmBtn.SetActive(false);
        cancelBtn.SetActive(true);
        isOccupied = true;
        roleItem.heroData.icon.LoadAssetAsync<Sprite>().Completed += s => { heroIcon.sprite = s.Result; heroIcon.gameObject.SetActive(true); };
        requireResItem.SetActive(false);
    }

    public void SetHero(RoleData heroData)
    {
        heroIcon.sprite = roleItem.Icon.sprite;
        heroIcon.gameObject.SetActive(true);
        requireResItem.SetActive(true);
        confirmBtn.SetActive(true);
    }

    public void ConfirmHeal()
    {
        if (isReady)
        {
            AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
            confirmBtn.SetActive(false);
            cancelBtn.SetActive(true);
            isOccupied = true;
            requireResItem.SetActive(false);
            roleItem.SetInTeam(false);
            roleItem.SetHeal(true);
            roleItem.herosMode.isHealing = true;
            roleItem.herosMode.healBoxIndex = boxIndex;

            //新数据修改
            var tempDate = Camp.Instance.getDateForObj(roleItem.gameObject);
            tempDate.GetHeroMode().isHealing = true;
            tempDate.GetHeroMode().healBoxIndex = boxIndex;
            if (OnConfirmHeal != null)
            {
                OnConfirmHeal(this, roleItem.heroData.id);
            }

            Hashtable args = new Hashtable();
            args["HeroItem"] = roleItem;
            EventHelper.Instance.ExcuteEvent(GEventType.HeroBusy, args);
        }
    }

    public void CancelHeal()
    {
        AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
        confirmPlan.gameObject.SetActive(true);
        cancelButton.GetComponent<Button>().onClick.RemoveAllListeners();
        confirmButton.GetComponent<Button>().onClick.RemoveAllListeners();

        cancelButton.GetComponent<Button>().onClick.AddListener(onCancelButton);
        confirmButton.GetComponent<Button>().onClick.AddListener(onConfirmButton);
    }

    public void RefreshBox(int requireRes, bool isReady)
    {
        requireResText.text = requireRes.ToString();
        this.isReady = isReady;
        if (isReady)
        {
            requireResText.color = Color.green;
        }
        else
        {
            requireResText.color = Color.red;
        }
    }

    public void ResetBox()
    {
        heroIcon.gameObject.SetActive(false);
        requireResItem.SetActive(false);
        confirmBtn.SetActive(false);
        cancelBtn.SetActive(false);
        isOccupied = false;
        if (roleItem != null)
        {
            roleItem.SetHeal(false);
            roleItem = null;
        }
    }

    public void setConfinButton()
    {
        cancelButton = confirmPlan.Find("black").Find("cancelButton");

        confirmButton = confirmPlan.Find("black").Find("confirmButton");

    }

    void onConfirmButton()
    {
        AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
        confirmPlan.gameObject.SetActive(false);
        confirmBtn.SetActive(true);
        cancelBtn.SetActive(false);
        isOccupied = false;

        var tempDate = Camp.Instance.getDateForObj(roleItem.gameObject);
        tempDate.GetHeroMode().isHealing = false;
        if (OnCancelHeal != null)
        {
            OnCancelHeal(this, tempDate);
        }
    }

    void onCancelButton()
    {
        AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
        confirmPlan.gameObject.SetActive(false);
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
