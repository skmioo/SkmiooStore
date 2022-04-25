using Datas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

/// <summary>
/// 处理角色属性的类
/// </summary>
public class HeroAttribute : MonoBehaviour
{
    public Text MaxHP;
    public Text attackText;
    public Text RateText;
    public Text CritsText;
    public Text DodgeText;
    public Text DefenceText;
    public Text SpeedText;


    public Image heroIcon;
    public Text heroName;
    public Text heroVocation;
    ObjLifeData objLifedata;

    private void Awake()
    {
        UIManager.Instance.onLanguageChangedAction += OnLanguageChanged;
    }
    private void OnDestroy()
    {
        UIManager.Instance.onLanguageChangedAction -= OnLanguageChanged;
    }
    public void SetInfo(ObjLifeData _objLifedata)
    {
        objLifedata = _objLifedata;
           AssetReferenceSprite ars = objLifedata.GetIcon();
        if(ars.Asset != null) ars.LoadAssetAsync().Completed += go =>
        {
            heroIcon.sprite = go.Result;
        };
        heroName.text = objLifedata.GetHeroName();
        heroVocation.text = objLifedata.GetVocation().ToString();
        OnLanguageChanged();
    }
    protected  void OnLanguageChanged()
    {
        if (objLifedata == null) return;
        attackText.text = $"{DataManager.Instance.GetLanguageData(1001, null)} ：{objLifedata.GetMinAtk()} - {objLifedata.GetMaxAtk()}";
        RateText.text = $"{DataManager.Instance.GetLanguageData(1003, null)} ：{objLifedata.GetRate()}";
        CritsText.text = $"{DataManager.Instance.GetLanguageData(1006, null)} ：{objLifedata.GetCrits()}";
        DodgeText.text = $"{DataManager.Instance.GetLanguageData(1005, null)} ：{objLifedata.GetDodge()}";
        DefenceText.text = $"{DataManager.Instance.GetLanguageData(1002, null)} ：{objLifedata.GetDefence()}";
        SpeedText.text = $"{DataManager.Instance.GetLanguageData(1004, null)} ：{objLifedata.GetSpeed()}";
        if (MaxHP != null) MaxHP.text = $"{DataManager.Instance.GetLanguageData(1007, null)} ：{objLifedata.GetHp()}";
    }
}
