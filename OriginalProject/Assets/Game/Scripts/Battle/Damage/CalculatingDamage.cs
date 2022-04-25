using Datas;
using UnityEngine;
using System.Collections.Generic;
using static BattleFlowController;
using System.Linq;
using System;
using System.Text;

/// <summary>
/// 战斗计算类
/// </summary>
public static class BattleCalculating
{
    /// <summary>
    /// 获得伤害
    /// </summary>
    /// <param name="user">攻击者</param>
    /// <param name="target">被击者</param>
    /// <param name="skill">使用的技能</param>
    /// <param name="dodge">是否闪避</param>
    /// <param name="crits">是否暴击</param>
    /// <param name="debugLog">log日志</param>
    /// <returns>伤害值</returns>
    public static DamagePack GetDamage(ObjLife user, ObjLife target, SkillData skill)
    {
       
        int skillLevel = user.GetSkillLevel(skill);
        float finalDamageRate = 1;
        float finalDamageAdd = 0;
        int selfMoraleAdd = 0;
        int allMoraleAdd = 0;
        //计算是否暴击
        bool crits = false;
        Instance.logTarget.AppendLine($"=========被击侧({target.GetHeroName()}) - 当前属性（除技能外的所有属性加成后的值）=========");
        Instance.logTarget.AppendLine($"当前生命值 : {target.GetHp()}、当前士气 ：{target.GetMorale()}、伤害：{target.GetAtkBeforeLog()}、精准值:{target.GetRate()}、暴击率:{target.GetCrits()}、闪避:{target.GetDodge()}、减伤:{target.GetDefence()}、速度:{target.GetSpeed()}、眩晕:{target.GetVertigo()}、位移:{target.GetPosition()}、减益:{target.GetDebuff()}、流血:{target.GetBleed()}、中毒{target.GetPoison()}");
        Instance.logTarget.AppendLine($"=========被击侧 - 被攻击时技能计算过程=========");

        //将技能修正作为buff添加到角色buff列表中
        if (!user.HaveSkillCorrent())
        {
            user.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.精准, ValueType.加减, AnalysisLevel(skill.rate ?? new IntLevel(), skillLevel)));
            user.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.暴击, ValueType.加减, AnalysisLevel(skill.crits ?? new IntLevel(), skillLevel)));
            user.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.暴击伤害, ValueType.加减, AnalysisLevel(skill.critsDamage ?? new IntLevel(), skillLevel)));
            user.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.伤害, ValueType.系数, AnalysisLevel(skill.atk ?? new IntLevel(), skillLevel)));
        }

        //近战技能伤害
        if (skill.skillType == SkillType.近战伤害 && user.ExistsPermanentBuff(ObjBuffType.使用近战技能伤害))
        {
            var buffs = user.GetPermanentBuff().FindAll(s => s.buffType == ObjBuffType.使用近战技能伤害);
            int add = buffs.Where(s => s.valueType == ValueType.加减).Sum(s => s.buffValue);
            int ratio = buffs.Where(s => s.valueType == ValueType.系数).Sum(s => s.buffValue);
            user.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.伤害, ValueType.加减, add));
            user.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.伤害, ValueType.系数, ratio));
        }

        // 计算反击
        if (target.ExistsSkillBuff(ObjBuffType.反击))
        {
            Instance.Insert = true;
            Instance.InsertObj = target;
            target.GetBuff(ObjBuffType.反击).ForEach(x => x.linkTarget = user);
        }
        
       
                //计算攻击
        float damage = user.GetAtk();//基础攻击伤害
        float damage_Real = 0;//真实伤害不计算减伤
        string debugLog = "";
        Action<ExtraDamage.Data> func = (data) =>
        {
            switch (data.key)
            {
                case ExtraDamage.Keys.精准修正:
                    Instance.logUser.AppendLine($"[额外效果] 精准修正 {AnalysisLevel(data.value, skillLevel)}");
                    user.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.精准, ValueType.加减, AnalysisLevel(data.value, skillLevel)));
                    break;
                case ExtraDamage.Keys.暴击修正:
                    Instance.logUser.AppendLine($"[额外效果] 暴击修正 {AnalysisLevel(data.value, skillLevel)}");
                    user.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.暴击, ValueType.加减, AnalysisLevel(data.value, skillLevel)));
                    break;
                case ExtraDamage.Keys.暴击伤害修正:
                    Instance.logUser.AppendLine($"[额外效果] 暴击伤害修正 {AnalysisLevel(data.value, skillLevel)}");
                    user.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.暴击伤害, ValueType.加减, AnalysisLevel(data.value, skillLevel)));
                    break;
                case ExtraDamage.Keys.伤害修正:
                    Instance.logUser.AppendLine($"[额外效果] 伤害修正 {AnalysisLevel(data.value, skillLevel)}");
                    user.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.伤害修正, ValueType.加减, AnalysisLevel(data.value, skillLevel)));
                    break;
                case ExtraDamage.Keys.最终伤害率修正:
                    finalDamageRate += AnalysisLevel(data.value, skillLevel) / 100.0f;
                    Instance.logUser.AppendLine($"[额外效果] 最终伤害率修正 {finalDamageRate}");
                    break;
                case ExtraDamage.Keys.最终伤害增加:
                    finalDamageAdd += AnalysisLevel(data.value, skillLevel);
                    Instance.logUser.AppendLine($"[额外效果] 最终伤害增加 {finalDamageAdd}");
                    break;
                case ExtraDamage.Keys.自身士气:
                    selfMoraleAdd += AnalysisLevel(data.value, skillLevel);
                    Instance.logUser.AppendLine($"[额外效果] 自身士气增加 {selfMoraleAdd}");
                    break;
                case ExtraDamage.Keys.所有友方士气:
                    allMoraleAdd += AnalysisLevel(data.value, skillLevel);
                    Instance.logUser.AppendLine($"[额外效果] 所有友方士气增加 {selfMoraleAdd}");
                    break;
                case ExtraDamage.Keys.增加Buff种类:
                    SkillBuff buff = data.buff;
                    Instance.AddBuff(buff,user,target,skillLevel);
                    Instance.logUser.AppendLine($"[额外效果] 增加Buff {buff.buffType} ");
                    break;
                case ExtraDamage.Keys.损失生命计算伤害:
                    damage_Real += (user.GetMaxHp() - user.GetHp()) * AnalysisLevel(data.value, skillLevel) / 100f;
                   debugLog += " \n  真实伤害:(" + user.GetMaxHp() + "-" + user.GetHp() + ") *" + AnalysisLevel(data.value, skillLevel) + "/100f=" + damage_Real + "\n";
                    
                    break;
                case ExtraDamage.Keys.生命最大值计算伤害:
                    damage_Real += target.GetMaxHp() * AnalysisLevel(data.value, skillLevel) / 100f;
                    debugLog += " \n  真实伤害:(" + target.GetMaxHp() + "*" + AnalysisLevel(data.value, skillLevel) + "/100f=" + damage_Real + "\n";
                    break;
                case ExtraDamage.Keys.必定暴击:
                    crits = true;
                    debugLog += "必定产生暴击" + "\n";
                    break;
                case ExtraDamage.Keys.移除标记:
                    target.RemoveSkillBuff(ObjBuffType.标记);
                    break;

            }
           
        };

        ExtraDamage death = null;

        //额外伤害
        foreach (var item in skill.additionalDamage)
        {
            // 旧版
            //switch (item.limit.limitType)
            //{
            //    case LimitType.具有buff:
            //        if (target.ExistsSkillBuff(item.limit.buffType))
            //        {
            //            user.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.伤害, item.limit.valueType, item.limit.limitValue));
            //        }
            //        break;
            //}
            if (item.limit.limitType == LimitType.死亡)
            {
                death = item;
            }
            else
            {
                // 新版
                if (Instance.GetLimitResult(item.limit, user, new ObjLife[] { target }))
                {
                    foreach (var data in item.kv)
                    {
                        func(data);
                    }
                }
            }
        }

        //计算是否闪避
        bool dodge;
    
        if (user.ExistsSkillBuff(ObjBuffType.充分准备))
        {
            Instance.logTarget.AppendLine($"[计算是否闪避] 攻击者 {user.GetHeroName()} 拥 有充分准备 目标 {target.GetHeroName()} 无法闪避 \n");
            dodge = false;
        }
        else
        {
            if (user == target)//如果是对自身施放，不能闪避
            { 
                dodge = false; 
            }
            else
            {
                int _rate = user.GetRate();
                int _dodge = target.GetDodge();
				float hitPro = Mathf.Clamp((_rate - _dodge), 0, 999) / 100.0f;
				Instance.logTarget.AppendLine($"[计算是否闪避] 攻击者精准计算值({_rate})-目标闪避计算值({_dodge}) / 100 = {hitPro} \n");

                //debugLog += ("  (精准" + _rate + "-闪避" + _dodge + ")/100=" + hitPro);
                dodge = !AnalysisProbability(hitPro, ref debugLog);
                //debugLog += ("  闪避:" + dodge + "\n");
                if (dodge)
                {
                    Instance.logTarget.AppendLine($"闪避 {debugLog}");
                    //user.UpdateMorale(4);
                    user.ClearSkillCorrent();

					// 当触发闪避
					if (target.ExistsSkillBuff(ObjBuffType.反击))
					{
						Instance.Insert = false;
					}
					return new DamagePack(dodge, false, 0, debugLog);
                }
                else
                {
                    Instance.logTarget.AppendLine($"[计算是否闪避] 未闪避 {debugLog}");
                }
            }
        


        }



        Instance.logTarget.AppendLine($"[计算攻击]  最低值({user.GetMinAtk()})~最高值({user.GetMaxAtk()}) ：最终计算后的结果({damage}) | {user.GetAtkCalculateLog()}");

        if(crits==false)//如果计算前暴击为false，那么参与计算
        {
            if (user.ExistsSkillBuff(ObjBuffType.充分准备))

            {
                crits = true;
                Instance.logTarget.AppendLine($"[计算是否暴击] 攻击者 {user.GetHeroName()} 拥有 充分准备或目标流血必暴击 目标 {target.GetHeroName()} 必被暴击");
            }
            else
            {
                int _crits = user.GetCrits();
                float critsPro = _crits / 100f;
                //debugLog += ("  暴击" + _crits + "/100=" + critsPro);
                crits = AnalysisProbability(critsPro, ref debugLog);
                //debugLog += ("  暴击:" + crits);

                Instance.logTarget.AppendLine($"[暴击判定] 暴击率 {critsPro} 是否暴击 {crits} | {debugLog}");
            }
        }




        if (crits)
        {
            CritsAddMoral(user);
            CritsReduceTargetMoral(target);

            float cd = user.GetCritsDamage() / 100.0f;
            Instance.logTarget.AppendLine($"[暴击伤害] 暴击前伤害: {damage} 暴击后伤害: {damage * cd} 暴击百分比:{cd}");
            damage *= cd;
        }
        //debugLog += ("  伤害:" + damage + "\n");

        //计算减伤
        int _defence = target.GetDefence();
        float defence = _defence / 100f;
        Instance.logTarget.AppendLine("[减伤] 减伤率 " + _defence + " / 100 = " + defence);
        //debugLog += ("  减伤" + _defence + "/100=" + defence);
        damage *= 1 - defence;
        finalDamageAdd *= 1 - defence;
        Instance.logTarget.AppendLine("[减伤] 伤害:" + (damage+ finalDamageAdd));
        //debugLog += ("  伤害:" + damage + "\n");

        //清空技能修正buff
        user.ClearSkillCorrent();

        //额外伤害
        foreach (var item in skill.additionalDamage)
        {
            switch (item.limit.limitType)
            {
                case LimitType.生命值降至1:
                    if (AnalysisProbability(AnalysisLevel(item.limit.rate ,skillLevel) / 100f, ref debugLog))
                    {
                        damage = target.GetHp() - 1;
                        debugLog += "生命值降至1: 伤害:" + damage + "\n";
                    }
                    break;
            }
        }

       
        
        if(selfMoraleAdd > 0)
            user.UpdateMorale(selfMoraleAdd, "额外伤害 自身士气");

        if (allMoraleAdd > 0)
        {
            var heros = Instance.GetHeros();
            foreach (var item in heros)
            {
                item.UpdateMorale(allMoraleAdd);
            }
        }


        var damageAdd = user.GetDamageAdd();
       
        damage *= damageAdd / 100f;


        // 暴击
        if (crits)
        {
            user.OnCrits();
            target.OnBeCrits();
        }

		//最终伤害计算 +0.01f因为系统Mathf.RoundToInt四舍五入不准确
		var damageInt = Mathf.RoundToInt(damage * finalDamageRate + finalDamageAdd+damage_Real + 0.01f);
		damageInt = Mathf.Clamp(damageInt, 0, 999);
		//赦免
		if (target.ExistsSkillBuff(ObjBuffType.赦免))
        {
            damageInt = 0;
            Instance.logTarget.AppendLine("[触发赦免]  伤害:" + damage);
        }

        Instance.logTarget.AppendLine($"[最终伤害判定] 最终伤害数值(｛{damage}) * 最终伤害率修正({finalDamageRate})  + 最终伤害增加{finalDamageAdd}+真实伤害{damage_Real} = {damage * finalDamageRate + finalDamageAdd+ damage_Real}");
        Instance.logTarget.AppendLine($"[最终伤害判定] 向上取整后 {damageInt}");

        if (death != null && Instance.GetLimitResult(death.limit, user, new ObjLife[] { target }, damageInt))
        {
            foreach (var data in death.kv)
            {
                func(data);
            }
        }

        var pack = new DamagePack(dodge, crits, damageInt, debugLog);
        Instance.logTarget.AppendLine("===============被攻击后属性===============");
        Instance.logTarget.AppendLine($"当前生命值 : {Mathf.Max(0,target.GetHp() - damageInt)}、当前士气 ：{user.GetMorale()}、伤害：{user.GetAtkAfterLog()}、精准值:{user.GetRate()}、暴击率:{user.GetCrits()}、闪避:{user.GetDodge()}、减伤:{user.GetDefence()}、速度:{user.GetSpeed()}、眩晕:{user.GetVertigo()}、位移:{user.GetPosition()}、减益:{user.GetDebuff()}、流血:{user.GetBleed()}、中毒{user.GetPoison()}、死亡抗性{user.GetDeath()}");

        return pack;
    }
    /// <summary>
    /// 被暴击自身士气-18，队友士气-4
    /// </summary>
    /// <param name="target"></param>
    private static void CritsReduceTargetMoral(ObjLife target)
    {
        target.UpdateMorale(-6, "被爆击-本人");
        List<ObjLife> timeObjLifes = BattleFlowController.Instance.GetTeamFromRole(target).GetObjLifes();
        foreach (var objLife in timeObjLifes)
        {
            if (target != objLife)
            {
                objLife.UpdateMorale(-2, "被爆击-队友");
            }
        }
    }
    /// <summary>
    /// 暴击增加自身士气12，队友士气5
    /// </summary>
    /// <param name="user"></param>
    private static void CritsAddMoral(ObjLife user)
    {
        user.UpdateMorale(8, "暴击-本人");
        List<ObjLife> timeObjLifes = BattleFlowController.Instance.GetTeamFromRole(user).GetObjLifes();
        foreach (var objLife in timeObjLifes)
        {
            if (user != objLife)
            {
                objLife.UpdateMorale(2, "暴击-队友");
            }
        }
    }

    /// <summary>
    /// 计算即时效果
    /// </summary>
    /// <param name="user">技能使用者</param>
    /// <param name="target">即时效果目标</param>
    /// <param name="tail">即时效果</param>
    /// <param name="level">技能等级</param>
    /// <param name="isCalDodge">是否需要计算命中</param>
    /// <returns></returns>
    public static TailPack GetTail(ObjLife user, ObjLife target, TailValue tail, int level ,bool isCalDodge)
    {

        bool dodge = false;
        float min_val = (float)AnalysisLevel(tail.minValue, level)-0.5f;
        float max_val = (float)AnalysisLevel(tail.maxValue, level) + 0.5f;
        int value = (int)Mathf.Round( UnityEngine.Random.Range(min_val, max_val));

        string log = $"[即时效果计算] 使用者 ：{user.GetHeroName()} 目标 { target.GetHeroName()} 即时效果 : {tail.tailType} 随机值 :{value}\n";

        switch (tail.tailType)
        {
            case SkillTailType.位移:

            case SkillTailType.随机交换位置:
                if (isCalDodge)
                {
                    int rate = AnalysisLevel(tail.rate, level);
                    rate = user.GetAttribute(ObjBuffType.位移状态基础概率, rate);
                    string logstr = null;
                    dodge = !AnalysisProbability((rate - target.GetPosition()) / 100f, ref logstr);
                    log += $"\t[位移] 命中率({rate}) - 位移抗性({target.GetPosition()}) / 100  = {((rate - target.GetPosition()) / 100f)} | {logstr} \n";
                }
                else
                {
                    dodge = false;//如果自身对自身使用那么直接返回false
                }
                break;
            case SkillTailType.获得BUFF:
            case SkillTailType.移除buff:
                log += $"\t[获得BUFF | 移除buff] - {tail.tailType} \n";
                return new TailPack(target, tail.tailType, tail.buffType, log);
            case SkillTailType.回复生命:
                if (tail.valueType.Equals(ValueType.系数))
                {
                    value = Mathf.RoundToInt((target.GetMaxHp() - target.GetHp()) * value / 100f);
                    log += "\t[回复生命 系数] (" + target.GetMaxHp() + "-" + target.GetHp() + ")*" + value + "/100f=" + value + "\n";
                }
                else
                {
                    log += "\t[回复生命 值] value \n";
                }
                value = user.GetAttribute(ObjBuffType.治疗, value);
                value = target.GetAttribute(ObjBuffType.受到治疗, value);
               // target.OnCure();
                break;
            case SkillTailType.士气:
                log += $"\t[受到士气伤害] - {value} \n";
                value = target.GetAttribute(ObjBuffType.受到士气伤害, value);
                break;
        }

        return new TailPack(target, dodge, tail.tailType, value, log);
    }

    /// <summary>
    /// 计算buff
    /// </summary>
    /// <param name="user">技能使用者</param>
    /// <param name="target">buff目标</param>
    /// <param name="buff">buff</param>
    /// <param name="level">技能等级</param>
    /// <param name="isCalDodge">是否需要计算命中</param>
    /// <returns></returns>
    public static BuffPack GetBuff(ObjLife user, ObjLife target, SkillBuff buff, int level, bool isCalDodge)
    {
        int rate = AnalysisLevel(buff.rate, level);
        bool dodge = false;
        int value = AnalysisLevel(buff.value, level);
        string log = $"[buff计算] 使用者 ：{user.GetHeroName()} 目标 { target.GetHeroName()} Buff效果 : {buff.buffType}  buff概率 :{AnalysisLevel(buff.rate, level)} buff使用值 :{AnalysisLevel(buff.value,level)}";

        if (IsDebuff(buff.buffType, false))//计算使用者的debuff
        {
            if (isCalDodge)
            {
                string logstr = null;
                //制作用与减益状态
                if (value < 0)
                {
                    rate = user.GetAttribute(ObjBuffType.减益状态基础概率, rate);
                }
                rate = user.GetAttribute(ObjBuffType.减益概率, rate);
				

				dodge = !AnalysisProbability(Mathf.Clamp(rate - target.GetDebuff(), 0, 999) / 100f, ref logstr);
                log += $"[增减益buff] 基础概率({rate}) - 目标抗性({target.GetDebuff()}) / 100= {(rate - target.GetDebuff()) / 100f}  是否生效: {!dodge} | {logstr}";

            }
        }
        else
        {
            string logstr = null;
            switch (buff.buffType)
            {
                case ObjBuffType.眩晕:
                    rate = user.GetAttribute(ObjBuffType.眩晕状态基础概率, rate);
                    rate = user.GetAttribute(ObjBuffType.眩晕概率, rate);
                    if (isCalDodge || user == target)
                    {

                        dodge = !AnalysisProbability(Mathf.Clamp(rate - target.GetVertigo(), 0, 999) / 100f, ref logstr);
                        log += $"[眩晕buff] 眩晕概率({rate}) - 目标抗性({target.GetVertigo()}) / 100= {(rate - target.GetVertigo()) / 100f}  是否生效: {!dodge} | {logstr}";
                    }
                    break;
                case ObjBuffType.流血:
                    if (isCalDodge)
                    {
                        rate = user.GetAttribute(ObjBuffType.流血状态基础概率, rate);
                        dodge = !AnalysisProbability(Mathf.Clamp(rate - target.GetBleed(), 0, 999) / 100f, ref logstr);
                        log += $"[流血buff] 流血概率({rate}) - 目标抗性({target.GetBleed()}) / 100= {(rate - target.GetBleed()) / 100f}  是否生效: {!dodge} | {logstr}";
                    }
                    break;
                case ObjBuffType.中毒:
                    if (isCalDodge)
                    {
                        rate = user.GetAttribute(ObjBuffType.中毒状态基础概率, rate);
                        dodge = !AnalysisProbability(Mathf.Clamp(rate - target.GetPoison(), 0, 999) / 100f, ref logstr);
                        log += $"[中毒buff] 中毒概率({rate}) - 目标抗性({target.GetPoison()}) / 100= {(rate - target.GetPoison()) / 100f}  是否生效: {!dodge} | {logstr}";
                    }
                    break;
            }

        }
        return new BuffPack(target, dodge, buff.buffType, value, buff.valueType, buff.EffectiveRoundsOrRandom(), log);
    }

    /// <summary>
    /// 计算召唤
    /// </summary>
    /// <param name="summon"></param>
    /// <returns></returns>
    public static SummonPack GetSummon(SkillSummon summon, ObjLife user)
    {
        switch (summon.summonType)
        {
            case ObjBuffType.延迟召唤:
                user.AddSkillBuff(new ObjSkillBuff(ObjBuffType.延迟召唤, ValueType.加减, summon.value, summon.value));
                return new SummonPack(summon.summonType, summon.value, summon.target, user);
            case ObjBuffType.死亡召唤:
                user.AddSkillBuff(new ObjSkillBuff(ObjBuffType.死亡召唤, ValueType.加减, summon.value, summon.value));
                return new SummonPack(summon.summonType, summon.target, user);
            case ObjBuffType.即时召唤在前面:
                return new SummonPack(summon.summonType, summon.target, user);
            default:
                Debug.Log("召唤类型错误");
                return null;
        }
    }

    public static BuffPack GetBuff(ObjLife user, ObjLife target, TalentBuff talentBuff)
    {
        SkillBuff skillBuff = new SkillBuff()
        {
            buffTarget = SkillBuffTarget.目标,
            buffType = talentBuff.buffType,
            valueType = talentBuff.valueType,
            value = new IntLevel { level1 = talentBuff.value },
            effectiveRounds = talentBuff.round,
            rate = new IntLevel { level1 = talentBuff.rate }
        };
        return GetBuff(user, target, skillBuff, 1, false);
    }

    public static TailPack GetTail(ObjLife user, ObjLife target, TalentTail talentTail)
    {
        TailValue tailValue = new TailValue()
        {
            buffTarget = SkillBuffTarget.目标,
            tailType = talentTail.tailType,
            buffType = talentTail.buffType,
            valueType = talentTail.valueType,
            maxValue = new IntLevel { level1 = talentTail.maxValue },
            minValue = new IntLevel { level1 = talentTail.minValue },
            rate = new IntLevel { level1 = talentTail.rate }
        };
        return GetTail(user, target, tailValue, 1, false);
    }

    /// <summary>
    /// 判断某种buff是否属于增减益buff
    /// </summary>
    /// <param name="buffType"></param>
    /// <param name="includespecial">是否包含特殊类型</param>
    /// <returns></returns>
    public static bool IsDebuff(ObjBuffType buffType,bool includespecial = true)
    {
        switch (buffType)
        {
            case ObjBuffType.暴击伤害:
            case ObjBuffType.伤害修正:
            case ObjBuffType.精准:
            case ObjBuffType.伤害:
            case ObjBuffType.暴击:
            case ObjBuffType.减伤:
            case ObjBuffType.攻击上限:
            case ObjBuffType.攻击下限:
            case ObjBuffType.最大生命:
            case ObjBuffType.闪避:
            case ObjBuffType.速度:
            case ObjBuffType.流血抗性:
            case ObjBuffType.中毒抗性:
            case ObjBuffType.减益抗性:
            case ObjBuffType.眩晕抗性:
            case ObjBuffType.位移抗性:
            case ObjBuffType.死亡抗性:
            case ObjBuffType.士气上限:
            case ObjBuffType.士气下限:
            case ObjBuffType.伤势上限:
            case ObjBuffType.伤势伤害:
            case ObjBuffType.每次战斗结束回复士气:
            case ObjBuffType.每次战斗结束回复生命:
                return true;
            case ObjBuffType.减益状态基础概率:
            case ObjBuffType.流血状态基础概率:
            case ObjBuffType.中毒状态基础概率:
            case ObjBuffType.眩晕状态基础概率:
            case ObjBuffType.位移状态基础概率:
                return true && includespecial;
            default:
                return false;
        }
    }

    /// <summary>
    /// 获取技能等级对应的值
    /// </summary>
    /// <param name="intLevel"></param>
    /// <param name="level"></param>
    /// <returns></returns>
    public static int AnalysisLevel(IntLevel intLevel, int level)
    {
        switch (level)
        {
            case 1: return intLevel.level1;
            case 2: return intLevel.level2;
            case 3: return intLevel.level3;
            case 4: return intLevel.level4;
            case 5: return intLevel.level5;
            default:
                Debug.Log($"使用了一个超出技能等级长度的值{level}");
                return 100;
        }
    }

    /// <summary>
    /// 分析概率,返回True = 触发
    /// </summary>
    /// <param name="bValue">要计算的概率值，小于等于0必不触发，大于等于1必触发</param>
    /// <returns></returns>
    private static bool AnalysisProbability(float bValue, ref string str)
    {
        float vr = UnityEngine.Random.Range(0f, 1f);
        if (bValue > vr)
        {
            str += ("  " + bValue + ">" + "随机数" + vr + "触发");
            return true;
        }
        str += ("  " + bValue + "<=" + "随机数" + vr + "不触发");
        return false;
    }
}