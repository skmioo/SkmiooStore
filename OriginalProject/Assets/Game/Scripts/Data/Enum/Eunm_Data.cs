/// <summary>
/// 角色类型
/// </summary>
public enum RoleType
{
    英雄, 怪物
}

/// <summary>
/// 队伍中角色关系类型
/// </summary>
public enum RoleRelationType
{
    友方, 敌方
}

/// <summary>
/// 英雄性别
/// </summary>
public enum roleSex
{
	男,女
}

/// <summary>
/// 英雄职业
/// 所有--用于一些技能对应职业的判定
/// </summary>
public enum HeroVocation
{
    //按7.5(242BUG)需求修改排序
    //星际战犯, 行星劫匪, 雇佣杀手, 邪恶发明家, 亡命赌徒, 双面间谍, 奴隶商人, 神秘学者, 狡诈叛逃者, 蛮兽猎人, 所有, 小怪, boss
    星际战犯, 神秘学者, 双面间谍, 行星劫匪, 雇佣杀手, 邪恶发明家, 亡命赌徒, 奴隶商人, 狡诈叛逃者, 蛮兽猎人, 所有, 小怪, boss
}

#region 亡命赌徒
/// <summary>
/// 英雄亡命赌徒职业
/// 亡命赌徒技能类型
/// </summary>
public enum GamblerSkillType
{
    戒赌, 戒毒,
}
#endregion

/// <summary>
/// 怪物职业,分类暂定
/// </summary>
public enum EnemyVocation
{
    近战小怪, 远程小怪, 近战BOSS, 远程BOSS
}

/// <summary>
/// 怪物类型
/// </summary>
public enum UnitType
{
    人类, 异兽, 植物
}

/// <summary>
/// 技能的类型
/// </summary>
public enum SkillType
{
    近战伤害, 远程伤害, BUFF, 治疗, 召唤, 综合, 形态切换, 自残
}

/// <summary>
/// 技能的目标类型 （增加excel里的类型  by yx）
/// </summary>
public enum SkillTargetType
{
    自身, 己方单体, 己方单体_不含自身, 己方全体, 己方全体_不含自身, 敌方单体, 敌方群体, 随机敌方, 相邻队友
}

/// <summary>
/// Buff类技能的作用目标
/// </summary>
public enum SkillBuffTarget
{
    自身, 目标, 全体队友, 全体敌人, 其他队友, 其他敌人
}

/// <summary>
/// 状态类技能影响类型，弃用
/// </summary>
[System.Obsolete()]
public enum SkillStatusTpye
{
    最大生命, 士气, 伤势, 位置, 攻击, 精准, 暴击, 减伤, 闪避, 速度, 回复生命, 持续伤害, 流血抗性, 中毒抗性, 减益抗性, 眩晕抗性, 位移抗性, 死亡抗性,
    流血概率, 中毒概率, 减益概率, 眩晕概率, 士气上限, 士气下限, 伤势上限, 伤害增幅, 治疗增幅
}


/// <summary>
/// buff分类，用于角色已有状态类型判断管理，弃用
/// </summary>
[System.Obsolete]
public enum SkillBuffType
{
    增益, 减益, 中毒, 限制, 持续回复, 流血, 保护, 赏金, 陷阱, 触发, 移除
}
/// <summary>
/// 技能即时效果类型——使用技能后即时判定生效
/// </summary>
public enum SkillTailType
{
    士气, 伤势, 回复生命, 位移, 移除buff, 切换形态, 随机交换位置, 流血加重, 回归初始站位, 极速恶化, 吸血, 即死, 生命强化, 行动点, 同魂, 吞噬, 回复生命至上限, 获得BUFF,当前生命百分比
}

/// <summary>
/// buff类型——持续影响（过每个技能的时候做一个加一个）
/// </summary>
public enum ObjBuffType
{
    精准, 伤害, 暴击, 减伤, 攻击上限, 攻击下限, 最大生命, 流血, 眩晕, 标记, 持续回复生命, 持续回复伤势, 持续回复士气,
    闪避, 陷阱, 速度, 流血抗性, 中毒抗性, 减益抗性, 眩晕抗性, 位移抗性, 死亡抗性, 士气上限, 士气下限, 伤势上限,
    减益, 增益, 中毒, 伤势伤害, 异常状态, 充分准备, 炸弹, 增强实验, 赦免, 增减益, 祈祷,
    背水一战, 恐惧之心, 人心惶惶, 振奋军心, 血灌瞳人, 心力憔悴, 濒死, 迷茫,
    治疗, 使用近战技能伤害, 受到士气伤害, 受到治疗, 眩晕概率, 减益概率, 即时效果, 中毒概率, 正向士气, 负向士气, 割礼, 包裹, 吞噬,
    每次战斗结束回复生命, 每次战斗结束回复士气, 结算时鳞甲增加, 地牢商店商品出现稀有饰品概率, 地牢商店商品出现圣物概率, 逃离副本不损失士气,
    角色濒死时恢复生命值, 经文效果翻倍, 未知经文可以看到效果, 冥想台士气技能词条刷新次数增加, 圣物掉落率增加, 解救的战斗胜利后也可获得增益效果, 角色阵亡时其他角色增加伤害, 异常状态不包括濒死人心惶惶,
    暴击伤害, 延迟召唤, 死亡召唤, 即时召唤在前面, 伤害修正, 守护, 被守护, 反击, 所有抗性, 流血加重, 减益状态基础概率, 流血状态基础概率, 中毒状态基础概率, 眩晕状态基础概率, 位移状态基础概率
}

/// <summary>
/// 特殊buff类型，用于附加不同类型的buff类
/// </summary>
public enum SpecialBuffType
{
    通用
}

/// <summary>
/// 值类型
/// </summary>
public enum ValueType
{
    加减, 系数
}

/// <summary>
/// 限制类型
/// </summary>
public enum LimitType
{
    生命, 具有buff, 已损失生命, 最大生命值, 杀戮形态不可用, 间谍形态不可用, 不可对boss使用, 生命值降至1, 场上未存在buff, 目标流血必暴击,
    士气, 处于什么状态, 怪物类型, 死亡, 未具有buff
}

/// <summary>
/// 限制目标
/// </summary>
public enum LimitTarget
{
    自身, 目标
}

/// <summary>
/// 人物形态
/// </summary>
public enum LimitTargetStatus
{
    双面间谍_间谍形态,
    双面间谍_杀戮形态
}

/// <summary>
/// 限制条件
/// </summary>
public enum LimitCondition
{
    小于, 大于, 等于
}

/// <summary>
/// buff来源
/// </summary>
public enum BuffSourceType
{
    饰品1, 饰品2, 勋章, 圣物, 正向士气, 生命, 套装, 负向士气, 交互物_祭坛, 角色阵亡时其他角色增加伤害
}

public enum PreferMove
{
    前, 后
}

public enum SpecialEffect
{
    无, 异化套装, 每回合受到伤害, 首回合优先行动, 进入战斗后流血
}
/// <summary>
/// 天赋效果类型
/// </summary>
public enum TalentEffectType
{
    获得buff, 获得行动点, 造成伤害, 造成即时效果
}
/// <summary>
/// 天赋触发条件类型
/// </summary>
public enum TalentTriggerType
{
    流血结束, 被治疗3次, 位移2次, 释放治疗技能, 被暴击
}