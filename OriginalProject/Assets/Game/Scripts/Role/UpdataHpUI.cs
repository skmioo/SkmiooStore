using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// 更新血量UI的效果控制--待完善
/// </summary>
public class UpdataHpUI : MonoBehaviour
{
    public Image hph;
    public Image hpd;
    public Image hpp;

    float recordF;//记录系数
    ObjLife objLife;
    public void Init(ObjLife _objLife)
    {
        objLife = _objLife;
        SetValue();
    }

    public void SetValue()
    {
        recordF = objLife.GetHp() / objLife.GetMaxHp();
        hph.fillAmount = recordF;
        hpd.fillAmount = recordF;
        hpp.fillAmount = recordF;
    }

    public void AddHp()
    {
        float nowF = objLife.GetHp() / objLife.GetMaxHp();
        hph.DOFillAmount(nowF, 0.1f);
        hpp.DOFillAmount(nowF, 1f);
        hpd.DOFillAmount(nowF, 1f);
    } 

    public void ReduceHp()
    {
        float nowF = objLife.GetHp() / objLife.GetMaxHp();
        hph.fillAmount = nowF;
        hpp.DOFillAmount(nowF, 0.1f);
        hpd.DOFillAmount(nowF, 1f);


    }


}
