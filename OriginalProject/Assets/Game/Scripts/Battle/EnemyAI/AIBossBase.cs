using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Datas;
using System.IO;

public class AIBossBase : AIBase
{
    /// <summary>
    /// Boss 开场技能
    /// </summary>
    public Queue<int> startSkillStack = new Queue<int>();

    /// <summary>
    /// Boss 常驻技能
    /// </summary>
    protected List<int> skillList = new List<int>();
    /// <summary>
    /// Boss 常驻技能条件判断委托
    /// </summary>
    protected delegate bool SkillCheck(int index);

    /// <summary>
    /// Boss 常驻技能条件判断Map
    /// </summary>
    protected Dictionary<int, SkillCheck> skillCheckMap = new Dictionary<int, SkillCheck>();

    public override void StartBattle()
    {
        base.StartBattle();
        startSkillStack.Clear();
        skillList.Clear();
        skillCheckMap.Clear();
    }

    /// <summary>
    /// Boss AI 放技能流程
    /// </summary>
    public override bool UseSkill()
    {
        // 首先释放开场技能
        if (this.UseStartSkill())
        {
            return true;
        }
        // 其次释放技能队列
        if (this.UseArraySkill())
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Boss AI 开场技能
    /// </summary>
    public bool UseStartSkill()
    {
        if (startSkillStack.Count <= 0)
        {
            return false;
        }
        int skillId = startSkillStack.Peek();
        SkillData skillData = DataManager.Instance.GetSkillDataById(skillId);
        if (skillData == null)
        {
            // 没有配置的技能
            return false;
        }
        if (bController.CanUseSkill(this.objLife, skillData))
        {
            bController.AddTargetToCanBeSelected(objLife, skillData);
            if (bController.canBeSelected.Count > 0)
            {
                startSkillStack.Dequeue();
                this.FightingCalculating(skillData);
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Boss AI 释放队列技能
    /// </summary>
    public bool UseArraySkill()
    {
        if (skillList.Count <= 0)
        {
            return false;
        }

        for (int index = 0; index < skillList.Count; index++)
        {
            int skillId = skillList[index];
            SkillData skillData = DataManager.Instance.GetSkillDataById(skillId);
            if (skillData == null)
            {
                // 没有配置的技能
                continue;
            }
            if (bController.CanUseSkill(this.objLife, skillData))
            {
                bController.AddTargetToCanBeSelected(objLife, skillData);
                if (bController.canBeSelected.Count > 0)
                {
                    if (skillCheckMap.ContainsKey(index) && !skillCheckMap[index].Invoke(index))
                    {
                        // 条件没有通过
                        continue;
                    }
                    this.FightingCalculating(skillData);
                    return true;
                }
            }
        }
        return false;
    }

    /// <summary>
    ///  检测是否有技能可以释放
    /// </summary>
    public override bool CheckCanSkill()
    {
        // 先判断是否能释放首要技能
        if (startSkillStack.Count > 0)
        {
            int skillId = startSkillStack.Peek();
            SkillData skillData = DataManager.Instance.GetSkillDataById(skillId);
            if (skillData != null)
            {
                if (bController.CanUseSkill(this.objLife, skillData))
                {
                    bController.AddTargetToCanBeSelected(objLife, skillData);
                    if (bController.canBeSelected.Count > 0)
                    {
                        return true;
                    }
                }
            }
        }
        if (skillList.Count > 0)
        {
            for (int index = 0; index < skillList.Count; index++)
            {
                int skillId = skillList[index];
                SkillData skillData = DataManager.Instance.GetSkillDataById(skillId);
                if (skillData == null)
                {
                    continue;
                }
                if (bController.CanUseSkill(this.objLife, skillData))
                {
                    bController.AddTargetToCanBeSelected(objLife, skillData);
                    if (bController.canBeSelected.Count > 0)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

}
