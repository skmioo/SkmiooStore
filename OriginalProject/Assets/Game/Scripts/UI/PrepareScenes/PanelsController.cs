using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PanelsController : MonoBehaviour
{
    static PanelsController _instance;
    public PanelsController Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        _instance = this;
    }


    public void OffAllPanel()
    {
        foreach (Transform item in transform)
        {
            if (item.gameObject.name == "HealPanel") break;
            if (item.gameObject.name == "RollMedal") break;
            if (item.gameObject.name == "RelicPanel") break;
            if (item.gameObject.name == "ShopPanel") break;
            if (item.gameObject.name == "SkillUpPanel") break;
            item.gameObject.SetActive(false);
        }
    }


}
