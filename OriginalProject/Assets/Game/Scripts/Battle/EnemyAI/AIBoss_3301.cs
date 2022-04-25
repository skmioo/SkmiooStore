using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBoss_3301 : AIBossBase
{
    public override void StartBattle(){
        base.StartBattle();
        // 添加开场技能
        this.startSkillStack.Enqueue(3012);
        this.startSkillStack.Enqueue(3015);
        this.startSkillStack.Enqueue(3014);
        this.startSkillStack.Enqueue(3011);
        this.startSkillStack.Enqueue(3013);
        this.startSkillStack.Enqueue(3017);
        
        // 添加常驻技能
        int[] list = {3015, 3014, 3011, 3012, 3013, 3016, 3017};
        this.skillList.AddRange(list);

        // 第一个回合 添加20速度 buff 持续1回合
        objLife.AddSkillBuff(new ObjSkillBuff(ObjBuffType.速度, ValueType.加减, 20, 1));
    }
}


