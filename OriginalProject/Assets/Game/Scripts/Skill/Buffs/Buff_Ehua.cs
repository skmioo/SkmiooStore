using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 急速恶化
/// </summary>
/*public class Buff_Ehua : BuffBase
{
    //激发流血和中毒伤害

    protected override void StartBuff()
    {
        StatusBox statusBox = objLife.roleUi.statusBox;

        foreach (var item in statusBox.buffs)
        {
            if (item.skillBuff.skillBuffType == SkillBuffType.中毒)
            {
                //取回合数,结算伤害，移除状态
                RunValue(item);
            }
            else if (item.skillBuff.skillBuffType == SkillBuffType.流血)
            {
                RunValue(item);
            }

        }

    }


    void RunValue(BuffBase item)
    {
        int round = item.skillBuff.effectiveRounds - item._rounds;//剩余回合数
        foreach (var _item in item.skillBuff.buffValues)
        {
            if (_item.statusType == SkillStatusTpye.持续伤害)
            {
                int value = item.GetBuffLevel(_item) * round;
                objLife.DamageSettlement(value, DamagePackType.HPDwon);

            }
        }

    }

}
*/