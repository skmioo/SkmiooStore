using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Datas;

public class AIBoss_3302 : AIBossBase
{
    public override void StartBattle(){
        base.StartBattle();
        // 添加开场技能
        this.startSkillStack.Enqueue(3022);
        this.startSkillStack.Enqueue(3023);
        this.startSkillStack.Enqueue(3026);
        this.startSkillStack.Enqueue(3021);
        this.startSkillStack.Enqueue(3025);    

        // 添加常驻技能
        int[] list = {3023, 3024, 3021, 3022, 3025, 3026, 3025, 3026};
        this.skillList.AddRange(list);
        this.skillCheckMap.Add(2, Check2);
        this.skillCheckMap.Add(4, Check4);
        this.skillCheckMap.Add(5, Check5_6);
        this.skillCheckMap.Add(6, Check5_6);
        
    }

    /// <summary>
    /// 死亡处理
    /// </summary>
    public override void OnDeath(){
        base.OnDeath();
        // 死亡后召唤4只粘稠怪（ID3013）
        SkillSummon sum = new SkillSummon();
        sum.summonType = ObjBuffType.死亡召唤;
        sum.value = 0;
        sum.target = 3013;        
        for (int i = 0; i < 4; ++i)
        {
            bController.DoSummon(sum, objLife);
        }
    }

    /// <summary>
    ///  生命值小于100%有50%概率释放该技能
    /// </summary>
    public bool Check2(int index){
        if(objLife.GetHp() < objLife.GetMaxHp()){
            if(Range(50)){
                return true;
            }
        }
        return false;
    }

    /// <summary>
    ///  自身有恢复生命的buff
    /// </summary>
    public bool Check4(int index){
        if(objLife.ExistsSkillBuff(ObjBuffType.持续回复生命)){
            return true;
        }
        return false;
    }

    /// <summary>
    ///  50%概率释放该技能
    /// </summary>
    public bool Check5_6(int index)
    {
        return Range(50);
    }

}


