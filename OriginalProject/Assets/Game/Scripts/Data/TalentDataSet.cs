using Datas;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Datas
{
    [Serializable]
    public class TalentGroup : DataBase
    {
        [Tooltip("触发条件")]
        public List<TalentTrigger> trigger;
        [Tooltip("秩序效果")]
        public List<TalentEffect> orderEffect;
        [Tooltip("昏乱效果")]
        public List<TalentEffect> chaosEffect;
    }

    [Serializable]
    public class TalentTrigger : DataBase
    {
        /// <summary>
        /// 触发条件类型
        /// </summary>
        public TalentTriggerType type;
    }

    [Serializable]
    public class TalentEffect : DataBase
    {
        [Tooltip("目标")]
        public SkillTargetType target;
        [Tooltip("效果类型")]
        public TalentEffectType type;
        [Tooltip("伤害值")]
        public int damageValue;
        [Tooltip("buff效果")]
        public List<TalentBuff> buff;
        [Tooltip("即时效果")]
        public List<TalentTail> tail;

        public override string ToString()
        {
            string str = "";
            switch (type)
            {
                case TalentEffectType.获得行动点:
                    return target.ToString() + "获得额外行动点";
                case TalentEffectType.造成伤害:
                    return target.ToString() + "受到" + damageValue.ToString() + "点伤害";
                case TalentEffectType.获得buff:
                    foreach (var b in buff)
                    {
                        str += b.ToString() + "\t";
                    }
                    return target.ToString() + str;
                case TalentEffectType.造成即时效果:
                    foreach (var t in tail)
                    {
                        str += t.ToString() + "\t";
                    }
                    return target.ToString() + str;
                default:
                    Debug.Log("未实现的天赋类型");
                    return "";
            }
        }
    }

    [Serializable]
    public class TalentBuff
    {
        public ObjBuffType buffType;
        public ValueType valueType;
        public int value;
        public int round;
        public int rate;

        public override string ToString()
        {
            return buffType.ToString() + (value > 0 ? "+" : "") + (value == 0 ? "" : value.ToString()) + (valueType == ValueType.加减 ? "" : "%") + "(" + round.ToString() + "回合)";
        }
    }

    [Serializable]
    public class TalentTail
    {
        public SkillTailType tailType;
        public ObjBuffType buffType;
        public ValueType valueType;
        public int maxValue;
        public int minValue;
        public int rate;

        public override string ToString()
        {
            return tailType.ToString() + (minValue > 0 ? "+" : "") + minValue.ToString() + (minValue == maxValue ? "" : "～" + maxValue.ToString()) + (valueType == ValueType.加减 ? "" : "%");
        }
    }

    /// <summary>
    /// 天赋数据集合
    /// </summary>
    [CreateAssetMenu(menuName = "NewData/TalentData")]
    [Serializable]
    public class TalentDataSet : ScriptableObject
    {
        [Header("天赋词条组")]
        [SerializeField] public List<TalentGroup> talentGroups;
    }
}

/// <summary>
/// 天赋数据类
/// </summary>
public class TalentData
{
    /// <summary>
    /// 类别id
    /// </summary>
    public int TypeId { get; set; }

    /// <summary>
    /// 触发器
    /// </summary>
    public TalentTrigger Trigger { get; set; }

    /// <summary>
    /// 秩序效果
    /// </summary>
    public TalentEffect Order { get; set; }

    /// <summary>
    /// 混乱效果
    /// </summary>
    public TalentEffect Chaos { get; set; }

    public string TriggerToString()
    {
        return $"触发条件：{Trigger.type.ToString()}";
    }

    public string OrderToString()
    {
        return $"秩序：{Order.ToString()}";
    }

    public string ChaosToString()
    {
        return $"混乱：{Chaos.ToString()}";
    }
}