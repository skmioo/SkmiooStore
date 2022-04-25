using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement;
using UnityEngine.UI;
using Datas;


/// <summary>
/// 在准备场景单个角色
/// </summary>
public class RoleItem : MonoBehaviour
{
    public Image Icon;
    public Image InTeamIcon;
    public Image healIcon;
    public Text _name;
    public Text injuries;
    public Text morale;

    public GameObject goFlag;
    public GameObject goHp;
    public Image goMedal;
    public RawImage[] imgMoraleAry;

    //[HideInInspector]
    //public int numInteam;

    [HideInInspector]
    public RoleData heroData;
    [HideInInspector]
    public HeroMode herosMode;

    [HideInInspector]
    public Transform iconBox;

    [HideInInspector]
    public ObjLife objLife;

    [HideInInspector]
    public ObjLifeData objLifeData;

    [HideInInspector]
    public RoleInfo roleInfo;

    [HideInInspector]
    public bool isBusy;


    /// <summary>
    /// 初始化角色信息(现在貌似废了)
    /// </summary>
    /// <param name="_heroData">英雄数据</param>
    public void InitItem(HeroEquipment equipment, RoleData _heroData, HeroMode _herosMode)
    {
        Debug.Log("hero InitItem ---------- ");
        iconBox = Icon.transform.parent;

        heroData = _heroData;
        _name.text = heroData.name;

        heroData.icon.LoadAssetAsync().Completed += go =>
        {
            Icon.sprite = go.Result;
        };

        herosMode = _herosMode;

        objLife = GetComponent<ObjLife>();
        objLife.InitRole(new ObjLifeData(_heroData.hp, 0, _herosMode, _heroData));

        SetObjlife(equipment);


        if (herosMode == null)
        {
            //在招募角色中显示时，不需要伤势及士气
            return;
        }
        //morale.text = "士气:" + herosMode.morale;
        //injuries.text = "伤势:" + herosMode.injuries;
        Debug.Log("RoleItem InitItem");
    }


    //objlif拟态,只使用其中的值,不参与任何计算或使用其方法！！！暂时这样处理,有时间重写
    public void SetObjlife(HeroEquipment equipment)
    {
        //objLife = GetComponent<ObjLife>();

        //objLife.InitRole(equipment,herosMode, heroData ,null, null);

        // objLife.gameObject.SetActive(true);
    }

    public void SetHeal(bool healing)
    {
        Debug.Log("RoleItem SetHeal");
        isBusy = healing;
        healIcon.transform.SetAsLastSibling();
        healIcon.gameObject.SetActive(healing);
        //injuries.text = "伤势:" + objLifeData.GetInjuries();
        injuries.text = "伤势:" + Camp.Instance.getDateForObj(gameObject).GetInjuries();
    }

    public void SetInTeam(bool isInTeam)
    {
        if (isInTeam)
        {
            AudioManager.Instance.PlayAudio(AudioName.Chick_Camp_Hero_mono, AudioType.Common);
        }
        else
        {
            AudioManager.Instance.PlayAudio(AudioName.Delete_Hero_mono, AudioType.Common);
        }
        InTeamIcon.transform.SetAsLastSibling();
        InTeamIcon.gameObject.SetActive(isInTeam);
    }

    public bool isInTeam() { return InTeamIcon.gameObject.activeSelf; }

    /// <summary>
    /// 更新显示数据(士气，勋章)
    /// </summary>
    public void refreshData()
    {
        var tempMedal = DataManager.Instance.GetMedalDataById(objLifeData.GetMedal().objId);
        if (tempMedal != null)
        {
            goMedal.enabled = true;
            tempMedal.icon.LoadAssetAsync().Completed += inGo => goMedal.sprite = inGo.Result;
        }
        else
        {
            goMedal.enabled = false;
        }

        refreshMorale();
    }

    /// <summary>
    /// 更新士气
    /// </summary>
    public void refreshMorale()
    {
        Color color1 = Color.black;
        Color color2 = Color.black;
        ColorUtility.TryParseHtmlString("#ED881D", out color1);
        ColorUtility.TryParseHtmlString("#494949", out color2);

        float tempValue = (float)objLifeData.GetMaxMorale() / (float)imgMoraleAry.Length;
        float tempMorale = (float)objLifeData.GetMorale() / (float)objLifeData.GetMaxMorale();
        float tempValue2 = 0;

        for (int i = 0; i < imgMoraleAry.Length; i++)
        {
            tempValue2 = ((float)i * tempValue) / (float)objLifeData.GetMaxMorale();
            if (tempValue2 < tempMorale)
                imgMoraleAry[i].color = color1;
            else
                imgMoraleAry[i].color = color2;
        }
    }

}
