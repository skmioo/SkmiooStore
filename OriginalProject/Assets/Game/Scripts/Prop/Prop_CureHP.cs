using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 道具--回复HP
/// </summary>
public class Prop_CureHP : Prop_Common
{    
    /*protected override void GoOtherAction()
    {
        foreach (var item in objData.objActions)
        {
            if (item.actionType == SkillStatusTpye.回复生命)
            {
                if (item.value < 0)
                {
                    return;
                }
                //加血
                objLife.GetNowHp() += item.value;
                if (objLife.GetNowHp() > objLife.GetHp())
                    objLife.GetNowHp() = objLife.GetHp();
                //血量飘出
                objLife.roleUi.ShowValue(item.value, DamagePackType.HPUP);
                //血条加血效果
                objLife.roleUi.SetHp(DamagePackType.HPUP);
            }
        } 
    }*/


}
