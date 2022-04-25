using Datas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Buff基类

/// <summary>
/// 对象buff基类
/// </summary>
public abstract class ObjBuffBase
{
    public ObjBuffType buffType;
    public ValueType valueType;
    public int buffValue;
    public SpecialBuffType specialBuffType;


    public ObjBuffBase(ObjBuffType buffType, ValueType valueType, int buffValue)
    {
        this.buffType = buffType;
        this.valueType = valueType;
        this.buffValue = buffValue;
       
    }

    public ObjBuffBase(ObjBuffBase buffBase)
    {
        buffType = buffBase.buffType;
        valueType = buffBase.valueType;
        buffValue = buffBase.buffValue;
        specialBuffType = buffBase.specialBuffType;
       
    }
}

/// <summary>
/// 技能buff基类
/// </summary>
public abstract class SkillBuffBase : ObjBuffBase
{
    public int round;
    public ObjLife linkTarget;
    public SkillData nextSkill;

    public SkillBuffBase(ObjBuffType buffType, ValueType valueType, int buffValue, int round, ObjLife linkTarget = null, SkillData nextSkill = null)
        : base(buffType, valueType, buffValue)
    {
        this.round = round;
        this.linkTarget = linkTarget;
        this.nextSkill = nextSkill;
    }

    public SkillBuffBase(SkillBuffBase skillBuff) : base(skillBuff)
    {
        round = skillBuff.round;
        linkTarget = skillBuff.linkTarget;
        nextSkill = skillBuff.nextSkill;
    }
}

/// <summary>
/// 常驻buff基类（饰品、勋章、圣物等）
/// </summary>
public abstract class PermanentBuffBase : ObjBuffBase
{
    public BuffSourceType source;
    public ObjLimitType limitType;
    public int limitValue;
    public HeroVocation vocation;

    public PermanentBuffBase(ObjAction objAction, BuffSourceType source)
        : base(objAction.buffType, objAction.valueType, objAction.value)
    {
        this.source = source;
        limitType = objAction.limitType;
        limitValue = objAction.limitValue;
        vocation = objAction.vocation;
    }

    public PermanentBuffBase(ObjBuffType buffType, ValueType valueType, int value, BuffSourceType source)
        :base(buffType, valueType, value)
    {
        this.source = source;
        limitType = ObjLimitType.无;
        limitValue = 0;
        vocation = HeroVocation.所有;
    }

    public PermanentBuffBase(PermanentBuffBase permanentBuffBase) : base(permanentBuffBase)
    {
        source = permanentBuffBase.source;
        limitType = permanentBuffBase.limitType;
        limitValue = permanentBuffBase.limitValue;
        vocation = permanentBuffBase.vocation;
    }
}

#endregion

#region Buff实现类

/// <summary>
/// 技能修正buff类
/// </summary>
public class ObjSkillCorrect : ObjBuffBase
{
    public ObjSkillCorrect(ObjBuffType buffType, ValueType valueType, int buffValue) : base(buffType, valueType, buffValue)
    {

    }

    public ObjSkillCorrect(ObjSkillCorrect objSkillCorrect) : base(objSkillCorrect)
    {

    }
}

/// <summary>
/// 对象技能buff类
/// </summary>
public class ObjSkillBuff : SkillBuffBase
{
    public ObjSkillBuff(ObjBuffType buffType, ValueType valueType, int buffValue, int round)
        : base(buffType, valueType, buffValue, round)
    {

    }

    public ObjSkillBuff(ObjSkillBuff skillBuff) : base(skillBuff)
    {

    }

    public ObjSkillBuff(TalentBuff talentBuff)
        : base(talentBuff.buffType, talentBuff.valueType, talentBuff.value, talentBuff.round)
    {

    }

    public override string ToString()
    {
        return $"{buffType.ToString()}{(buffValue > 0 ? "+" : "")}{buffValue}{(valueType == ValueType.系数 ? "%" : "")}（{round}回合）";
    }
}

/// <summary>
/// 对象常驻buff类
/// </summary>
public class ObjPermanentBuff : PermanentBuffBase
{
    /// <summary>
    /// buff 是否生效
    /// </summary>
    public bool isTakeEffect;

    public ObjPermanentBuff(ObjAction objAction, BuffSourceType source)
        : base(objAction, source)
    {
        isTakeEffect = objAction.limitType == ObjLimitType.无;
    }

    public ObjPermanentBuff(ObjBuffType buffType, ValueType valueType, int value, BuffSourceType source)
        : base(buffType, valueType, value, source)
    {
        isTakeEffect = true;
    }

    public ObjPermanentBuff(ObjPermanentBuff objPermanentBuff) : base(objPermanentBuff)
    {
        isTakeEffect = objPermanentBuff.isTakeEffect;
    }

    public override string ToString()
    {
        return $"{buffType.ToString()}{(buffValue > 0 ? "+" : "")}{buffValue}{(valueType == ValueType.系数 ? "%" : "")}";
    }
}

#endregion