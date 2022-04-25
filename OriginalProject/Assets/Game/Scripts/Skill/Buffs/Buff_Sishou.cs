using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 死守技能
/// 实现持续回血和持续恢复伤势
/// </summary>
/*public class Buff_Sishou : BuffBase
{
    protected override void Damage()
    {
        if (skillBuff.skillBuffType != SkillBuffType.持续回复)
        {
            //可以加这个判断,也可以不要
            //return;
        }


        foreach (var item in skillBuff.buffValues)
        {
            if (item.statusType == SkillStatusTpye.回复生命)
            {
                int value = GetBuffLevel(item);
                objLife.DamageSettlement(value, DamagePackType.morale);
                
            }
            else if (item.statusType == SkillStatusTpye.伤势)
            {
                int value = GetBuffLevel(item);
                objLife.DamageSettlement(value, DamagePackType.injuries);
            }
            
        }
    }



}*/
