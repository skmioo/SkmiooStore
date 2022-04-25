using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Datas;
using UnityEngine.AddressableAssets;

public class EnemyInfoView : MonoBehaviour
{
    public Image icon;
    public Text enemyName;
    public Text hp;
    public Text maxHp;
    public Text dodge;
    public Text speed;

    [Header("抗性")]
    public Text vertigo;
    public Text bleed;
    public Text position;
    public Text poison;
    public Text debuff;
    
    [Header("技能")]
    public Text[] skills;

    public void Refresh(ObjLife objLife)
    {
        AssetReferenceSprite ars = objLife.GetIcon();
        if (ars.Asset != null) ars.LoadAssetAsync().Completed += go => icon.sprite = go.Result;

        enemyName.text = objLife.GetHeroName();
        hp.text = objLife.GetHp().ToString();
        maxHp.text = objLife.GetMaxHp().ToString();

        dodge.text = objLife.GetDodge().ToString();
        speed.text = objLife.GetSpeed().ToString();

        vertigo.text = objLife.GetVertigo().ToString();
        bleed.text = objLife.GetBleed().ToString();
        position.text = objLife.GetPosition().ToString();
        poison.text = objLife.GetPoison().ToString();
        debuff.text = objLife.GetDebuff().ToString();

        List<SkillData> skillDatas = DataManager.Instance.GetSkillDatasByIds(objLife.GetHaveSkill());
        for (int i = 0; i < skills.Length; i++)
        {
            skills[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < skillDatas.Count; i++)
        {
            if(i < skills.Length)
            {
                skills[i].gameObject.SetActive(true);
                skills[i].text = skillDatas[i].name;
            }
        }
    }
}
