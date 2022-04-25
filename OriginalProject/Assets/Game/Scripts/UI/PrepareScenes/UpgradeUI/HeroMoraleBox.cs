using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using Datas;

public class HeroMoraleBox : MonoBehaviour
{
    public event Action<HeroMoraleBox, int> OnPutHero;
    public Image heroIcon, lockIcon;
    public Text heroBoxText;
    [HideInInspector]
    public HeroMode herosMode;
    [HideInInspector]

    public void OnPutHeroIn(RoleItem roleItem)
    {
        if (herosMode != null && herosMode.heroId != roleItem.herosMode.heroId)
        {
            //herosMode.equipmentOtherSkill = null;
        }
        var tempMode = Camp.Instance.getDateForObj(roleItem.gameObject).GetHeroMode();
        herosMode = tempMode;
        //herosMode = roleItem.herosMode;
        heroIcon.sprite = roleItem.Icon.sprite;
        heroIcon.gameObject.SetActive(true);
        if (OnPutHero != null)
        {
            OnPutHero(this, tempMode.heroId);
        }
        heroBoxText.enabled = false;
    }

    public void OnPutHeroIn(ObjLifeData inObjData)
    {
        herosMode = inObjData.GetHeroMode();
        //herosMode = roleItem.herosMode;
        inObjData.GetIcon().LoadAssetAsync().Completed += inGo => { heroIcon.sprite = inGo.Result; };
        heroIcon.gameObject.SetActive(true);
        if (OnPutHero != null)
        {
            OnPutHero(this, herosMode.heroId);
        }
        heroBoxText.enabled = false;
    }

    public void LoadHeroData(RoleItem roleItem)
    {
        /*S_debug.showDebug("LoadHeroData  ----");*/
        herosMode = roleItem.herosMode;
        heroIcon.sprite = roleItem.Icon.sprite;
        heroIcon.gameObject.SetActive(true);
    }

    public void Clear()
    {
        heroIcon.gameObject.SetActive(false);
        if (!lockIcon.IsActive()) heroBoxText.enabled = true;
        herosMode = null;
    }

    public void Unlock()
    {
        lockIcon.gameObject.SetActive(false);
    }
}
