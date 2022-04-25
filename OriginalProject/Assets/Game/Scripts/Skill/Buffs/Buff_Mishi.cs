using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 觅食
/// </summary>
/*public class Buff_Mishi :BuffBase
{
    //附加一个伤害
    protected override void StartBuff()
    {
        int hpd = objLife.GetHp() - Mathf.RoundToInt(objLife.GetNowHp());

        foreach (var item in skillBuff.buffValues)
        {
            if (item.statusType == SkillStatusTpye.最大生命)
            {
                int value = Mathf.RoundToInt(hpd * (GetBuffLevel(item) / 100));

                objLife.DamageSettlement(value, DamagePackType.HPDwon);
            }
        }
    }


}
*/