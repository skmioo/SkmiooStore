using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 赏金,技能发动前的判断
/// </summary>
public class StartSkill_Shangjin : StartSkillBase
{
    /*protected override void StartSkill()
    {
        //启动判断,判断我将要攻击的角色,他的身上是否带有赏金这个Buff,如果有,这个技能的伤害增加
        bool heveBuff = false; 
        foreach (var item in attackedObjlife.roleUi.statusBox.buffs)
        {
            if (item.skillBuff.skillBuffType == SkillBuffType.赏金)
            {
                heveBuff = true;
            }
        }

        if (heveBuff)
        {
            Debug.Log(damagePack.damageValue);
            damagePack.damageValue *= 1.25f;

            Debug.Log("伤害增加运行了" + damagePack.damageValue);
        }


        EndSkill();
    }*/


}
