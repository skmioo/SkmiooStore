using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 保护技能/被保护者
/// </summary>
/*public class Buff_BaohuB : BuffBase
{
    //先保护B在被保护者身上创建
    //再由被保护者，通过保护B创建 保护A  到保护者身上.   此时.保护A通过保护B监听保护B的受伤情况
    public GameObject baohuA;
    Buff_BaoHuA buff_BaoHuA;

    protected override void StartBuff()
    {
        GameObject go = Instantiate(baohuA, attackerObjlife.roleUi.statusBox.transform);
        BuffBase buffBase = go.GetComponent<BuffBase>();

        buffBase.InitItam(skillLevel, skillBuff, attackerObjlife, objLife);
        attackerObjlife.roleUi.statusBox.AddBuff(buffBase);

        buff_BaoHuA = buffBase as Buff_BaoHuA;

        objLife.buff_BaohuB = this;
        //我这个Buff如何截获我的被攻击的包呢？
    }

    public bool Laihuole(DamagePack damagePack)
    {
        //我去问A可不可以对我进行保护，可以保护我返回真,不可以保护返回假
        return buff_BaoHuA.Laihuole(damagePack);
    }

    //当保护B更新伤害效果时,通知保护A同步
    public void UpdateStatus()
    {

    }


    protected override void EndDamege()
    {
        objLife.buff_BaohuB = null;
    }

}
    */

