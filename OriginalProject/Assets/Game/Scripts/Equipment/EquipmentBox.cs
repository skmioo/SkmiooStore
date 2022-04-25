using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 装备盒子--用于存装备,并统一管理
/// </summary>
public class EquipmentBox : MonoBehaviour
{
    public List<EquipBase> equipBases = new List<EquipBase>();

    public void AddEquip(EquipBase basePanel)
    {
        equipBases.Add(basePanel);



    }


    public void ClearBox()
    {
        foreach (var item in equipBases)
        {
            item.TakeOff();
        }

        equipBases.Clear();
    }

    //一个增加方法 


    //一个清除方法


}
