using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBoss_3303 : AIBossBase
{
    public override void StartBattle(){
        base.StartBattle();
        // 添加开场技能
        this.startSkillStack.Enqueue(3035);
        this.startSkillStack.Enqueue(3036);
        this.startSkillStack.Enqueue(3031);
        this.startSkillStack.Enqueue(3034);

        // 添加常驻技能
        int[] list = {3032, 3035, 3036, 3031, 3033, 3034};
        this.skillList.AddRange(list);
        this.skillCheckMap.Add(0, Check0_4);
        this.skillCheckMap.Add(4, Check0_4);
    }
    
    /// <summary>
    ///  50%概率释放该技能
    /// </summary>
    public bool Check0_4(int index)
    {
        return Range(50);
    }
}


