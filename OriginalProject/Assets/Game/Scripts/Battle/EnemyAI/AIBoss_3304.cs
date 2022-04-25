using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Datas;

public class AIBoss_3304 : AIBossBase
{
    /// <summary>
    ///  记录技能释放次数
    /// </summary>
    private int[] CheckHpList = { 80, 60, 40, 20 };

    public override void StartBattle()
    {
        base.StartBattle();
        // 添加开场技能
        this.startSkillStack.Enqueue(3042);
        this.startSkillStack.Enqueue(3041);
        // 添加常驻技能
        int[] list = { 3045, 3044, 3044, 3044, 3044, 3042, 3041, 3043 };
        this.skillList.AddRange(list);
        this.skillCheckMap.Add(1, Check1_2_3_4);
        this.skillCheckMap.Add(2, Check1_2_3_4);
        this.skillCheckMap.Add(3, Check1_2_3_4);
        this.skillCheckMap.Add(4, Check1_2_3_4);

        //初始化技能标记
        for (int i = 0; i < CheckHpList.Length; i++)
        {
            CheckHpList[i] = 100 - ((i + 1) * 20);
        }
    }

    /// <summary>
    /// 新的回合
    /// </summary>
    public override void OnNewRound(int round)
    {
        base.OnNewRound(round);
        if (round % 5 != 0)
        {
            return;
        }
        SkillSummon sum = new SkillSummon();
        sum.summonType = ObjBuffType.延迟召唤;
        sum.value = 0;
        sum.target = 3013;
        bController.DoSummon(sum, objLife);
        bController.DoSummon(sum, objLife);
    }

    /// <summary>
    ///  血量分别第一次低于 80% 60% 40% 20% 
    /// </summary>
    public bool Check1_2_3_4(int index)
    {
        int idx = index - 1;
        int hpScale = (int)Mathf.Floor(objLife.GetHp() / objLife.GetMaxHp() * 100);
        if (CheckHpList[idx] >= hpScale)
        {
            CheckHpList[idx] = -1;
            return true;
        }
        return false;
    }

}


