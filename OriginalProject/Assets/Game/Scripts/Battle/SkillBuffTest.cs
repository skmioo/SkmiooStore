//#define 增减益ObjBuffType_伤害
//#define 增减益ObjBuffType_减伤
//#define 增减益ObjBuffType_精准
//#define 增减益ObjBuffType_速度
//#define 增减益ObjBuffType_闪避率
///暴击率跟暴击伤害是一起的
//#define 增减益ObjBuffType_暴击率
//#define 增减益ObjBuffType_暴击伤害
//#define 增减益ObjBuffType_流血抗性
//#define 增减益ObjBuffType_中毒抗性
#define 增减益ObjBuffType_位移抗性
//#define 增减益ObjBuffType_眩晕抗性
#define SkillBuffType_吞噬
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Datas;
using UnityEngine;

public class SkillBuffTest
{
	enum SkillBuffType
	{
		持续回复,
		标记,
		增益,
		减益,
		增减益,
		流血,
		陷阱,
		眩晕,
		中毒,
		炸弹,
		充分准备,
		赦免,
		保护,
		反击,
		祈祷,
		濒死,
		割礼,
		包裹,
		吞噬,
		恢复生命,		//tail
	}

	/// <summary>
	/// 是否进行技能buff测试
	/// </summary>
	public bool IsTestBuff = false;

	/// <summary>
	/// 测试的buff类型
	/// </summary>
	SkillBuffType testBuffType = SkillBuffType.流血;

	#region 收起
	/// <summary>
	/// 是否改变英雄的第二个技能
	/// </summary>
	bool isNeedChangeSecSkill = true;

	/// <summary>
	/// 每个英雄的第一个技能修改为需要测试的技能
	/// </summary>
	List<int> heroFirstIds = new List<int> { 1011, 1021, 1031, 1041, 1051, 1061, 1071, 1081 };
	List<int> heroSecondIds = new List<int> { 1012, 1022, 1032, 1042, 1052, 1062, 1072, 1082 };

	/// <summary>
	/// 敌方的技能修改为需要测试的技能
	/// 虔诚教徒 技能id 2001 2002
	/// </summary>
	List<int> enemyIds = new List<int> { 2001, 2002 };

	public SkillBuffTest()
	{
#if 增减益ObjBuffType_暴击率 || 增减益ObjBuffType_暴击伤害
		//同时开启暴击率跟暴击伤害方便测试
		isNeedChangeSecSkill = true;
#endif
	}

	internal SkillData GetSkillDataById(SkillData data)
	{
		//必须拷贝一份数据进行操作,不然会修改技能asset资源
		SkillData skillData = data.Clone();
		if (heroFirstIds.Any(id => { return id == skillData.id; }))
		{
			ResetSkillData(skillData);
			Type type = Type.GetType("SkillBuffTest");
			MethodInfo method = type.GetMethod(testBuffType.ToString());
			object obj = Activator.CreateInstance(type);
			return (SkillData)method.Invoke(obj, new object[] { skillData });
		}

		if (isNeedChangeSecSkill && heroSecondIds.Any(id => { return id == skillData.id; }))
		{
			ResetSkillData(skillData);
			Type type = Type.GetType("SkillBuffTest");
			MethodInfo method = type.GetMethod("修改技能2");
			object obj = Activator.CreateInstance(type);
			return (SkillData)method.Invoke(obj, new object[] { skillData });
		}

		if(enemyIds.Any(id => { return id == skillData.id; }) )
		{
			Type type = Type.GetType("SkillBuffTest");
			MethodInfo method = type.GetMethod("怪物技能");
			object obj = Activator.CreateInstance(type);
			return (SkillData)method.Invoke(obj, new object[] { skillData });
		}

		return skillData;
	}

	internal List<SkillData> GetSkillDatasByIds(List<SkillData> datas)
	{
		//必须拷贝一份数据进行操作,不然会修改技能asset资源
		List<SkillData> skillDatas = new List<SkillData>();
		foreach (SkillData data in datas)
		{
			skillDatas.Add(data.Clone());
		}
		for (int i = 0; i < skillDatas.Count; i++)
		{
			SkillData skillData = skillDatas[i];
			if (heroFirstIds.Any(id => { return id == skillData.id; }))
			{
				ResetSkillData(skillData);
				Type type = Type.GetType("SkillBuffTest");
				MethodInfo method = type.GetMethod(testBuffType.ToString());
				object obj = Activator.CreateInstance(type);
				skillData = (SkillData)method.Invoke(obj, new object[] { skillData });
			}
			if (isNeedChangeSecSkill && heroSecondIds.Any(id => { return id == skillData.id; }))
			{

				ResetSkillData(skillData);
				Type type = Type.GetType("SkillBuffTest");
				MethodInfo method = type.GetMethod("修改技能2");
				object obj = Activator.CreateInstance(type);
				skillData = (SkillData)method.Invoke(obj, new object[] { skillData });
			}
		}
		return skillDatas;
	}

	public SkillData 修改技能2(SkillData skillData)
	{
#if 增减益ObjBuffType_暴击伤害
		skillData.describe = $"增益";
		skillData.skillType = SkillType.BUFF;
		if (testBuffType == SkillBuffType.增益)
		{
			skillData.targetType = SkillTargetType.己方单体;
			skillData.skillBuffs.Add(增减益buff(ObjBuffType.暴击伤害, ValueType.加减, 50));
		}
		else if (testBuffType == SkillBuffType.减益)
		{
			skillData.targetType = SkillTargetType.己方单体;
			skillData.skillBuffs.Add(增减益buff(ObjBuffType.暴击伤害, ValueType.加减, -20));
		}
#elif SkillBuffType_吞噬
		return 吞噬(skillData);
#endif
		return skillData;
	}

	enum EnemySkillBuffType {无, 怪物技能测试 , 流血 , 陷阱, 眩晕 ,中毒};

	/// <summary>
	/// 怪物释放的技能
	/// </summary>
	EnemySkillBuffType testEnemyBuffType = EnemySkillBuffType.流血;

	public SkillData 怪物技能(SkillData skillData)
	{
		if (testEnemyBuffType == EnemySkillBuffType.怪物技能测试)
		{
			//修改怪物释放的技能
			setIntLevel(skillData.rate, 100, 100, 100, 100, 100);
		}
		
		if (testEnemyBuffType == EnemySkillBuffType.流血)
		{
			ResetSkillData(skillData);
			return 流血(skillData);
		}
		if (testEnemyBuffType == EnemySkillBuffType.陷阱)
		{
			ResetSkillData(skillData);
			return 陷阱(skillData);
		}
		if (testEnemyBuffType == EnemySkillBuffType.眩晕)
		{
			ResetSkillData(skillData);
			return 眩晕(skillData);
		}
		if (testEnemyBuffType == EnemySkillBuffType.中毒)
		{
			ResetSkillData(skillData);
			return 中毒(skillData);
		}
		return skillData;
	}


	int 持续回复Hp = 3;
	int 持续回复Morale = 2;

	/// <summary>
	/// 每回合持续回复x点生命/士气 （3回合）
	/// </summary>
	/// <param name="skillData"></param>
	/// <returns></returns>
	public SkillData 持续回复(SkillData skillData)
	{
		int round = 3;
		skillData.describe = $"持续回复{持续回复Hp}生命、{持续回复Morale}士气（{round}回合)";
		skillData.skillType = SkillType.BUFF;
		skillData.targetType = SkillTargetType.己方单体;
		SkillBuff 生命buff = CreateSkillBuff();
		生命buff.buffTarget = SkillBuffTarget.自身;
		生命buff.buffType = ObjBuffType.持续回复生命;
		生命buff.valueType = ValueType.加减;
		生命buff.value.level1 = 持续回复Hp;
		生命buff.effectiveRounds = round;

		SkillBuff 士气buff = CreateSkillBuff();
		士气buff.buffTarget = SkillBuffTarget.自身;
		士气buff.buffType = ObjBuffType.持续回复士气;
		士气buff.valueType = ValueType.加减;
		士气buff.value.level1 = 持续回复Morale;
		士气buff.effectiveRounds = round;

		skillData.skillBuffs.Add(生命buff);
		skillData.skillBuffs.Add(士气buff);
		return skillData;
	}

	/// <summary>
	/// 我方角色被标记时：增加被攻击的概率（3回合）
	/// 敌方角色：被标记（3回合）
	/// </summary>
	/// <param name="skillData"></param>
	/// <returns></returns>
	public SkillData 标记(SkillData skillData)
	{
		int round = 3;
		skillData.describe = $"我方角色被标记时：增加被攻击的概率（{round}回合）";
		skillData.skillType = SkillType.BUFF;
		skillData.targetType = SkillTargetType.己方单体;
		SkillBuff buff = CreateSkillBuff();
		buff.buffTarget = SkillBuffTarget.自身;
		buff.buffType = ObjBuffType.标记;
		buff.valueType = ValueType.加减;
		buff.value.level1 = 45;
		buff.effectiveRounds = round;
		skillData.skillBuffs.Add(buff);
		return skillData;
	}

#endregion
	/// <summary>
	/// 伤害、减伤、精准、速度、闪避率、暴击率、暴击伤害、流血抗性、中毒抗性、位移抗性、减益抗性、眩晕抗性、死亡抗性、减益状态基础概率、流血状态基础概率、中毒状态基础概率、眩晕状态基础概率、位移状态基础概率
	/// </summary>
	/// <param name="skillData"></param>
	/// <returns></returns>
	int 增益Round = 3;

	public SkillData 增益(SkillData skillData)
	{
		skillData.describe = $"增益";
		skillData.skillType = SkillType.BUFF;
#if 增减益ObjBuffType_伤害
		skillData.targetType = SkillTargetType.己方单体;
		skillData.skillBuffs.Add(增减益buff(ObjBuffType.伤害, ValueType.系数, 20));
#elif 增减益ObjBuffType_减伤
		skillData.targetType = SkillTargetType.己方单体;
		skillData.skillBuffs.Add(增减益buff(ObjBuffType.减伤, ValueType.系数, 20));
#elif 增减益ObjBuffType_精准
		skillData.targetType = SkillTargetType.己方单体;
		skillData.skillBuffs.Add(增减益buff(ObjBuffType.精准, ValueType.加减, 20));
#elif 增减益ObjBuffType_速度
		skillData.targetType = SkillTargetType.己方单体;
		skillData.skillBuffs.Add(增减益buff(ObjBuffType.速度, ValueType.加减, 5));
#elif 增减益ObjBuffType_闪避率
		skillData.targetType = SkillTargetType.己方单体;
		skillData.skillBuffs.Add(增减益buff(ObjBuffType.闪避, ValueType.加减, 50));
#elif 增减益ObjBuffType_暴击率
		skillData.targetType = SkillTargetType.己方单体;
		skillData.skillBuffs.Add(增减益buff(ObjBuffType.暴击, ValueType.加减, 80));
#elif 增减益ObjBuffType_流血抗性
		skillData.targetType = SkillTargetType.己方单体;
		skillData.skillBuffs.Add(增减益buff(ObjBuffType.流血抗性, ValueType.系数, 40));
#elif 增减益ObjBuffType_中毒抗性
		skillData.targetType = SkillTargetType.己方单体;
		skillData.skillBuffs.Add(增减益buff(ObjBuffType.中毒抗性, ValueType.系数, 40));
#elif 增减益ObjBuffType_眩晕抗性
		skillData.targetType = SkillTargetType.己方单体;
		skillData.skillBuffs.Add(增减益buff(ObjBuffType.眩晕抗性, ValueType.系数, 40));
#elif 增减益ObjBuffType_位移抗性
		skillData.targetType = SkillTargetType.己方单体;
		skillData.skillBuffs.Add(增减益buff(ObjBuffType.位移抗性, ValueType.系数, 40));
#endif
		return skillData;
	}

	public SkillData 减益(SkillData skillData)
	{
		skillData.describe = $"减益";
		skillData.skillType = SkillType.BUFF;
#if 增减益ObjBuffType_伤害
		skillData.targetType = SkillTargetType.己方单体;
		skillData.skillBuffs.Add(增减益buff(ObjBuffType.伤害, ValueType.系数, -20));
#elif 增减益ObjBuffType_减伤
		skillData.targetType = SkillTargetType.己方单体;
		skillData.skillBuffs.Add(增减益buff(ObjBuffType.减伤, ValueType.系数, -20));
#elif 增减益ObjBuffType_精准
		skillData.targetType = SkillTargetType.己方单体;
		skillData.skillBuffs.Add(增减益buff(ObjBuffType.精准, ValueType.加减, -20));
#elif 增减益ObjBuffType_速度
		skillData.targetType = SkillTargetType.己方单体;
		skillData.skillBuffs.Add(增减益buff(ObjBuffType.速度, ValueType.加减, -5));
#elif 增减益ObjBuffType_闪避率
		skillData.targetType = SkillTargetType.己方单体;
		skillData.skillBuffs.Add(增减益buff(ObjBuffType.闪避, ValueType.加减, -50));
#elif 增减益ObjBuffType_暴击率
		skillData.targetType = SkillTargetType.己方单体;
		skillData.skillBuffs.Add(增减益buff(ObjBuffType.暴击, ValueType.加减, -20));
#elif 增减益ObjBuffType_流血抗性
		skillData.targetType = SkillTargetType.己方单体;
		skillData.skillBuffs.Add(增减益buff(ObjBuffType.流血抗性, ValueType.系数, -50));
#elif 增减益ObjBuffType_中毒抗性
		skillData.targetType = SkillTargetType.己方单体;
		skillData.skillBuffs.Add(增减益buff(ObjBuffType.中毒抗性, ValueType.系数, -50));
#elif 增减益ObjBuffType_眩晕抗性
		skillData.targetType = SkillTargetType.己方单体;
		skillData.skillBuffs.Add(增减益buff(ObjBuffType.眩晕抗性, ValueType.系数, -50));
#elif 增减益ObjBuffType_位移抗性
		skillData.targetType = SkillTargetType.己方单体;
		skillData.skillBuffs.Add(增减益buff(ObjBuffType.位移抗性, ValueType.系数, -50));
#endif
		return skillData;
	}

	SkillBuff 增减益buff(ObjBuffType type, ValueType valueType, int value)
	{
		SkillBuff buff = CreateSkillBuff();
		buff.buffTarget = SkillBuffTarget.自身;
		buff.buffType = type;
		buff.valueType = valueType;
		buff.value.level1 = value;
		buff.effectiveRounds = 增益Round;
		return buff;
	}

	public SkillData 增减益(SkillData skillData)
	{
		return skillData;
	}

	/// <summary>
	/// 开启怪物技能使用流血，玩家使用增减益的流血抗性进行流血测试
	/// </summary>
	/// <param name="skillData"></param>
	/// <returns></returns>
	public SkillData 流血(SkillData skillData)
	{
		int round = 3;
		skillData.describe = $"流血";
		skillData.skillType = SkillType.远程伤害;
		//技能的命中率
		skillData.rate.level1 = 100;
		skillData.targetType = SkillTargetType.敌方单体;
		SkillBuff buff = CreateSkillBuff();
		buff.buffTarget = SkillBuffTarget.目标;
		buff.buffType = ObjBuffType.流血;
		buff.valueType = ValueType.加减;
		buff.value.level1 = -3;
		//buff的命中率
		buff.rate.level1 = 90;
		buff.effectiveRounds = round;
		skillData.skillBuffs.Add(buff);
		return skillData;
	}

	public SkillData 陷阱(SkillData skillData)
	{
		int round = 3;
		skillData.describe = $"陷阱";
		skillData.skillType = SkillType.远程伤害;
		//技能的命中率
		skillData.rate.level1 = 100;
		skillData.targetType = SkillTargetType.敌方单体;
		SkillBuff buff = CreateSkillBuff();
		buff.buffTarget = SkillBuffTarget.目标;
		buff.buffType = ObjBuffType.陷阱;
		buff.valueType = ValueType.加减;
		buff.value.level1 = -20;
		//buff的命中率
		buff.rate.level1 = 0;
		buff.effectiveRounds = round;
		skillData.skillBuffs.Add(buff);
		return skillData;
	}

	public SkillData 眩晕(SkillData skillData)
	{
		int round = 1;
		skillData.describe = $"眩晕";
		skillData.skillType = SkillType.远程伤害;
		//技能的命中率
		skillData.rate.level1 = 100;
		skillData.targetType = SkillTargetType.敌方单体;
		SkillBuff buff = CreateSkillBuff();
		buff.buffTarget = SkillBuffTarget.目标;
		buff.buffType = ObjBuffType.眩晕;
		buff.valueType = ValueType.加减;
		buff.value.level1 = 0;
		//buff的命中率
		buff.rate.level1 = 90;
		buff.effectiveRounds = round;
		skillData.skillBuffs.Add(buff);
		return skillData;
	}

	public SkillData 中毒(SkillData skillData)
	{
		int round = 3;
		skillData.describe = $"中毒";
		skillData.skillType = SkillType.远程伤害;
		//技能的命中率
		skillData.rate.level1 = 100;
		skillData.targetType = SkillTargetType.敌方单体;
		SkillBuff buff = CreateSkillBuff();
		buff.buffTarget = SkillBuffTarget.目标;
		buff.buffType = ObjBuffType.中毒;
		buff.valueType = ValueType.加减;
		buff.value.level1 = -3;
		//buff的命中率
		buff.rate.level1 = 90;
		buff.effectiveRounds = round;
		skillData.skillBuffs.Add(buff);
		return skillData;
	}

	public SkillData 炸弹(SkillData skillData)
	{
		skillData.describe = $"炸弹";
		skillData.skillType = SkillType.远程伤害;
		//技能的命中率
		skillData.rate.level1 = 100;
		skillData.targetType = SkillTargetType.敌方单体;
		SkillBuff buff = CreateSkillBuff();
		buff.buffTarget = SkillBuffTarget.目标;
		buff.buffType = ObjBuffType.炸弹;
		buff.valueType = ValueType.加减;
		buff.value.level1 = -15;
		//buff的命中率
		buff.rate.level1 = 90;
		buff.randomRounds = true;
		buff.effectiveRounds = 1;
		buff.effectiveRounds2 = 5;
		skillData.skillBuffs.Add(buff);
		return skillData;
	}

	public SkillData 充分准备(SkillData skillData)
	{
		int round = 3;
		skillData.describe = $"充分准备";
		skillData.skillType = SkillType.BUFF;
		skillData.targetType = SkillTargetType.己方单体;
		SkillBuff buff = CreateSkillBuff();
		buff.buffTarget = SkillBuffTarget.目标;
		buff.buffType = ObjBuffType.充分准备;
		buff.effectiveRounds = round;
		skillData.skillBuffs.Add(buff);
		return skillData;
	}

	public SkillData 赦免(SkillData skillData)
	{
		int round = 1;
		skillData.describe = $"赦免";
		skillData.skillType = SkillType.BUFF;
		skillData.targetType = SkillTargetType.自身;
		SkillBuff buff = CreateSkillBuff();
		buff.buffTarget = SkillBuffTarget.自身;
		buff.buffType = ObjBuffType.赦免;
		buff.effectiveRounds = round;
		skillData.skillBuffs.Add(buff);
		return skillData;
	}

	public SkillData 保护(SkillData skillData)
	{
		int round = 3;
		skillData.describe = $"保护";
		skillData.skillType = SkillType.BUFF;
		skillData.targetType = SkillTargetType.己方全体;
		SkillBuff 守护 = CreateSkillBuff();
		守护.buffTarget = SkillBuffTarget.自身;
		守护.buffType = ObjBuffType.守护;
		守护.effectiveRounds = round;
		skillData.skillBuffs.Add(守护);
		SkillBuff 被守护 = CreateSkillBuff();
		被守护.buffTarget = SkillBuffTarget.其他队友;
		被守护.buffType = ObjBuffType.被守护;
		被守护.effectiveRounds = round;
		skillData.skillBuffs.Add(被守护);
		return skillData;
	}

	public SkillData 反击(SkillData skillData)
	{
		int round = 3;
		skillData.describe = $"反击";
		skillData.skillType = SkillType.BUFF;
		//技能的命中率
		skillData.rate.level1 = 100;
		skillData.targetType = SkillTargetType.自身;
		SkillBuff buff = CreateSkillBuff();
		buff.buffTarget = SkillBuffTarget.自身;
		buff.buffType = ObjBuffType.反击;
		buff.effectiveRounds = round;
		skillData.skillBuffs.Add(buff);
		return skillData;
	}

	public SkillData 祈祷(SkillData skillData)
	{
		int round = 3;
		skillData.describe = $"祈祷";
		skillData.skillType = SkillType.远程伤害;
		//技能的命中率
		skillData.rate.level1 = 100;
		skillData.targetType = SkillTargetType.敌方单体;
		SkillBuff buff = CreateSkillBuff();
		buff.buffTarget = SkillBuffTarget.目标;
		buff.buffType = ObjBuffType.祈祷;
		buff.valueType = ValueType.加减;
		buff.value.level1 = -3;
		//buff的命中率
		buff.rate.level1 = 90;
		buff.effectiveRounds = round;
		skillData.skillBuffs.Add(buff);
		return skillData;
	}

	public SkillData 濒死(SkillData skillData)
	{
		int round = 3;
		skillData.describe = $"濒死";
		skillData.skillType = SkillType.远程伤害;
		//技能的命中率
		skillData.rate.level1 = 100;
		skillData.targetType = SkillTargetType.敌方单体;
		SkillBuff buff = CreateSkillBuff();
		buff.buffTarget = SkillBuffTarget.目标;
		buff.buffType = ObjBuffType.中毒;
		buff.valueType = ValueType.加减;
		buff.value.level1 = -3;
		//buff的命中率
		buff.rate.level1 = 90;
		buff.effectiveRounds = round;
		skillData.skillBuffs.Add(buff);
		return skillData;
	}

	public SkillData 割礼(SkillData skillData)
	{
		int round = 3;
		skillData.describe = $"割礼";
		skillData.skillType = SkillType.近战伤害;
		//技能的命中率
		skillData.targetType = SkillTargetType.敌方单体;
		setIntLevel(skillData.rate, 100, 100, 100, 100, 100);
		setIntLevel(skillData.atk, 0, 0, 0, 0, 0);
		SkillBuff buff = CreateSkillBuff();
		buff.buffTarget = SkillBuffTarget.目标;
		buff.buffType = ObjBuffType.割礼;
		buff.valueType = ValueType.加减;
		buff.value.level1 = -3;
		//buff的命中率
		setIntLevel(buff.rate, 100, 100, 100, 100, 100);
		buff.effectiveRounds = round;
		skillData.skillBuffs.Add(buff);
		return skillData;
	}

	public SkillData 包裹(SkillData skillData)
	{
		int round = 3;
		skillData.describe = $"包裹";
		skillData.skillType = SkillType.远程伤害;
		//技能的命中率
		skillData.rate.level1 = 100;
		skillData.atk.level1 = -50;
		skillData.targetType = SkillTargetType.敌方单体;
		SkillBuff buff = CreateSkillBuff();
		buff.buffTarget = SkillBuffTarget.目标;
		buff.buffType = ObjBuffType.包裹;
		buff.valueType = ValueType.加减;
		buff.value.level1 = -2;
		//buff的命中率
		buff.rate.level1 = 90;
		buff.effectiveRounds = round;
		skillData.skillBuffs.Add(buff);
		return skillData;
	}

	public SkillData 吞噬(SkillData skillData)
	{
		int round = 2;
		skillData.describe = $"吞噬";
		skillData.skillType = SkillType.远程伤害;
		//技能的命中率
		skillData.rate.level1 = 100;
		skillData.atk.level1 = -80;
		skillData.targetType = SkillTargetType.敌方单体;
		TailValue tail = new TailValue();
		tail.buffTarget = SkillBuffTarget.目标;
		tail.tailType = SkillTailType.吞噬;
		tail.buffType = ObjBuffType.精准;
		tail.valueType = ValueType.系数;
		tail.maxValue = new IntLevel {};
		tail.minValue = new IntLevel {};
		skillData.skillTails.Add(tail);
		SkillBuff buff = CreateSkillBuff();
		buff.buffTarget = SkillBuffTarget.自身;
		buff.buffType = ObjBuffType.吞噬;
		buff.valueType = ValueType.加减;
		buff.value.level1 = -3;
		//buff的命中率
		buff.rate.level1 = 90;
		buff.effectiveRounds = round;
		skillData.skillBuffs.Add(buff);
		return skillData;
	}

	public SkillData 恢复生命(SkillData skillData)
	{
		int round = 2;
		skillData.describe = $"恢复生命";
		skillData.skillType = SkillType.治疗;
		//技能的命中率
		skillData.rate.level1 = 100;
		skillData.targetType = SkillTargetType.己方全体;
		TailValue tail = new TailValue();
		tail.buffTarget = SkillBuffTarget.全体队友;
		tail.tailType = SkillTailType.回复生命;
		tail.buffType = ObjBuffType.精准;
		tail.valueType = ValueType.加减;
		tail.maxValue = new IntLevel { level1 = 3};
		tail.minValue = new IntLevel { level1 = 1 };
		skillData.skillTails.Add(tail);
		return skillData;
	}

	public void ResetSkillData(SkillData skillData)
	{
		skillData.name = testBuffType.ToString();

		skillData.targetRandomNum = 0;
		skillData.position.A = true;
		skillData.position.B = true;
		skillData.position.C = true;
		skillData.position.D = true;
		skillData.position.W = true;
		skillData.position.X = true;
		skillData.position.Y = true;
		skillData.position.Z = true;
		setIntLevel(skillData.rate, 0, 0, 0, 0, 0);
		setIntLevel(skillData.crits, 0, 0, 0, 0, 0);
		setIntLevel(skillData.critsDamage, 0, 0, 0, 0, 0);
		setIntLevel(skillData.atk, 0, 0, 0, 0, 0);
		skillData.skillTails.Clear();
		skillData.skillBuffs.Clear();
		skillData.useLimits.Clear();
		skillData.targetLimits.Clear();
		skillData.additionalDamage.Clear();
		skillData.killToActAgain = false;
		skillData.summon.Clear();
		skillData.cd = 0;
		skillData.cameraMoveData.Clear();
	}

	/// <summary>
	/// 修正
	/// </summary>
	void setIntLevel(IntLevel intLevel, int l1, int l2, int l3, int l4, int l5)
	{
		intLevel.level1 = l1;
		intLevel.level2 = l2;
		intLevel.level3 = l3;
		intLevel.level4 = l4;
		intLevel.level5 = l5;
	}


	SkillBuff CreateSkillBuff()
	{
		SkillBuff skillBuff = new SkillBuff();
		skillBuff.value = new IntLevel();
		skillBuff.rate = new IntLevel();
		return skillBuff;
	}
}