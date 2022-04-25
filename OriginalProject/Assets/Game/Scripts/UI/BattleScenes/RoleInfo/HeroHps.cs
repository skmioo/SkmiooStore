using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// 英雄血条类处理
/// </summary>
public class HeroHps : MonoBehaviour
{
    public Image hpp;
    public Image injuriesp;
    public Image[] moralep;
    public Sprite[] moraleSprete;

    public GameObject morale;

    public Text hpValue;
    public Text injuriespValue;
    public Text moralepValue;

    private void Start()
    {
        if (hpp != null)
            UIEventManager.AddTriggersListener(hpp.gameObject).onEnter = go => HpValueShow();
        UIEventManager.AddTriggersListener(injuriesp.gameObject).onEnter = go => InjuriespValueShow();
        UIEventManager.AddTriggersListener(morale).onEnter = go => MoralepValueShow();

        if (hpp != null)
            UIEventManager.AddTriggersListener(hpp.gameObject).onExit = go => ExitShow();
        UIEventManager.AddTriggersListener(injuriesp.gameObject).onExit = go => ExitShow();
        UIEventManager.AddTriggersListener(morale).onExit = go => ExitShow();
    }

    public void SetValue(ObjLifeData objLifedata)
    {
        if (hpValue != null)
            hpValue.text = $"{objLifedata.GetHp()} / {objLifedata.GetMaxHp()}";
        if (hpp != null)
        hpp.fillAmount = objLifedata.GetHp() / objLifedata.GetMaxHp();

        injuriespValue.text = $"{objLifedata.GetInjuries()} / {objLifedata.GetMaxInjuries()}";
        moralepValue.text = $"{objLifedata.GetMinMorale()}/{objLifedata.GetMorale()}/{objLifedata.GetMaxMorale()}";

        injuriesp.fillAmount = (float)objLifedata.GetInjuries() / (float)objLifedata.GetMaxInjuries();

        if (objLifedata.GetMorale() > 0)
        {
            int num = objLifedata.GetMorale() * 5 / objLifedata.GetMaxMorale();
            for (int i = 0; i < moralep.Length; i++)
            {
                if (i < num)
                {
                    moralep[i].sprite = moraleSprete[0];
                }
                else
                {
                    moralep[i].sprite = moraleSprete[1];
                }
            }
        }
    }

    void HpValueShow()
    {
        hpValue.transform.parent.gameObject.SetActive(true);
    }

    void InjuriespValueShow()
    {
        injuriespValue.transform.parent.gameObject.SetActive(true);

    }

    void MoralepValueShow()
    {
        moralepValue.transform.parent.gameObject.SetActive(true);
    }

    void ExitShow()
    {
        if (hpValue != null)
            hpValue.transform.parent.gameObject.SetActive(false);
        injuriespValue.transform.parent.gameObject.SetActive(false);
        moralepValue.transform.parent.gameObject.SetActive(false);
    }
}
