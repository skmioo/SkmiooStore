using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Datas;
using System;

/// <summary>
/// 准备场景角色信息面板
/// </summary>
public class RoleInfo : MonoBehaviour
{
    public RoleDefenseInfo roleDefenseInfo;
    public HeroAttribute heroAttribute;
    public HeroHps heroHps;

    public Transform roleModeBox;
    public Button expelButton;
    public Button restNmaeButton;

    public InputField restNmaeInput;

    public GameObject restNmaeTips;
    public GameObject expelTips;
    RoleItem roleItem;
    ObjLife objLife;
    Camp camp;

    public HeroEquipmentInfo heroEquipmentInfo;
    public SkillController_Panel skillController_Panel;


    private void Awake()
    {
        //expelButton.onClick.AddListener(ExpleHero);
        restNmaeInput.onEndEdit.AddListener(SetHeroName);
        restNmaeInput.onValueChanged.AddListener(SetHeroName);
    }



    /// <summary>
    /// 显示角色信息,准备场景用
    /// </summary>
    public void ShowMe(RoleItem _roleItem,Camp _camp)
    {
        expelTips.SetActive(false);
        restNmaeTips.SetActive(false);

        //清空之前的角色模型
        foreach (Transform item in roleModeBox)
        {
            Destroy(item.gameObject);
        }
        expelButton.gameObject.SetActive(false);
        if (_camp != null)
        {
            expelButton.gameObject.SetActive(true);
            heroEquipmentInfo.InitEquipment(_roleItem.objLife);
        }

        roleItem = _roleItem;
        objLife = roleItem.objLife;
        camp = _camp;

        gameObject.SetActive(true);

        roleItem.heroData.roleMode.InstantiateAsync(roleModeBox).Completed += go =>
        {
            Transform ui = go.Result.transform.Find("UI");
            Transform show = go.Result.transform.Find("DamageShow");

            ui.gameObject.SetActive(false);
            show.gameObject.SetActive(false);
        };

        skillController_Panel.SetSkillButton(roleItem.objLife);

        SetInfoValue();
    }

    /// <summary>
    /// 显示角色信息,战斗场景用
    /// </summary>
    /// <param name="_objlife"></param>
    public void ShowMe(ObjLife _objlife)
    {
        expelTips.SetActive(false);
        restNmaeTips.SetActive(false);
        expelButton.gameObject.SetActive(false);
        restNmaeButton.gameObject.SetActive(false);

        foreach (Transform item in roleModeBox)
        {
            Destroy(item.gameObject);
        }

        objLife = _objlife;

        heroEquipmentInfo.InitEquipment(objLife);
        skillController_Panel.SetSkillButton(objLife);
        gameObject.SetActive(true);

        gameObject.GetComponentInChildren<HeroHps>().SetValue(_objlife.GetObjLifeData());
    }


    void SetInfoValue()
    {
        Debug.Log("测试-SetInfoValue");
        heroAttribute.SetInfo(objLife.GetObjLifeData());
        roleDefenseInfo.SetInfo(objLife);
        heroHps.SetValue(objLife.GetObjLifeData());
    }

    public void UpdateValue()
    {
        SetInfoValue();
    }

    public void Off()
    {
        gameObject.SetActive(false);
    }

    //解雇角色
    public void ExpleHero()
    {
        if (camp != null)
        {
            camp.ReMoveRoleCamp(roleItem);
            gameObject.SetActive(false);
        }
    }

    string inputNmae;
    private void SetHeroName(string arg0)
    {
        inputNmae = arg0;
    }

    public void RestHeroName()
    {
        roleItem.objLife.SetHeroName(inputNmae);
        SetInfoValue();
    }
}
