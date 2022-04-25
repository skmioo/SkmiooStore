using Datas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static BattleFlowController;
/// <summary>
/// 队伍数据
/// 战斗基础逻辑通用数据
///  一些ui跟战斗公用的数据都可以放在这个类里
/// </summary>
public class BattleFlowLogicController :  MonoBehaviour
{
	#region 战斗相关数据 一些ui跟战斗公用的数据

	#region 战斗通用数据
	/// <summary>
	/// 回合
	/// </summary>
	protected int round;
	public int GetRoundNum()
	{
		return round;
	}
	protected ObjLife currentObjLife;
	public ObjLife CurrentSelectHero { get { return currentObjLife; } }

	/// <summary>
	/// 是否战斗中
	/// </summary>
	public bool IsBattling { get; set; } = false;

	/// <summary>
	/// 是否战斗失败（已方英雄全部死亡）
	/// </summary>
	public bool IsFightFail { get; set; } = false;
	/// <summary>
	/// 是否 撤退战斗 = true 
	/// </summary>
	protected bool isExitBallte;

	/// <summary>
	/// 战斗改变事件
	/// </summary>
	public static Action<bool> Battle;

	public bool isFightHard;
	public bool isBossRoom = false;
	/// <summary>
	/// 动作速度控制，越大越慢
	/// </summary>
	public const float nTimeScale = 1f;
	#endregion

	#region 队伍数据及处理
	/// <summary>
	/// 战斗开始时各英雄的位置
	/// </summary>
	protected List<ObjLife> posBeginning = new List<ObjLife>();
	/// <summary>
	/// 行动队列
	/// </summary>
	protected List<ObjLife> actionList = new List<ObjLife>();
	public Team herosTeam = new Team();
	public Team monsterTeam = new Team();

	protected Team currentTeam;
	protected Team enemyTeam;

	public List<ObjLifeData> GetHeros()
	{
		return herosTeam.GetObjLifes().Select(s => s.GetObjLifeData()).ToList();
	}

	public List<ObjLife> GetHerosLife()
	{
		return herosTeam.GetObjLifes();
	}

	public List<ObjLife> GetMonsterLife()
	{
		return monsterTeam.GetObjLifes();
	}

	/// <summary>
	/// 重置所有角色
	/// </summary>
	protected void ResetAllRole()
	{
		foreach (var item in herosTeam.GetObjLifes())
		{
			//item.ClearSkillBuff();
			item.CurrentActNum = 0;

			if (item.ExistsSpecialEffect(SpecialEffect.进入战斗后流血))
			{
				item.AddSkillBuff(new ObjSkillBuff(ObjBuffType.流血, ValueType.加减, -3, 3));
			}
		}
		foreach (var item in monsterTeam.GetObjLifes())
		{
			item.ClearSkillBuff();
			item.CurrentActNum = 0;
			item.ResetSkillCd();
		}

		foreach (var item in herosTeam.GetObjLifes())
		{
			item.IsSpy = true;
			item.AniUseGoRole();
			item.dutuskill_stack.Clear();
			item.dupinskill_stack.Clear();
			item.DupinSkill = 0;
			item.DutuSkill = 0;
			jiedutu = false;
			jiedupin = false;
			item.InitTalentData();
			item.ResetSkillCd();
		}
	}

	#endregion

	#region 技能召唤数据
	/// <summary>
	/// 当前英雄被选择可用的技能数据
	/// </summary>
	protected List<SkillData> skillDatas;

	/// <summary>
	/// 当前技能列表是否可用标记
	/// </summary>
	protected List<bool> useables = new List<bool>();
	/// <summary>
	/// 士气技能是否可用标记
	/// </summary>
	protected bool moraleUseable;

	/// <summary>
	/// 能够被选择的角色
	/// </summary>
	public List<ObjLife> canBeSelected = new List<ObjLife>();
	/// <summary>
	/// 被攻击的角色
	/// </summary>
	protected List<ObjLife> attackedObjLifes = new List<ObjLife>();
	/// <summary>
	/// 是否激活换位
	/// </summary>
	protected bool isExchange = false;
	/// <summary>
	/// 战斗技能
	/// </summary>
	public SkillData currentSkill { get; set; }

	/// <summary>
	/// 召唤list
	/// </summary>
	public List<SummonPack> summonList = new List<SummonPack>();

	protected List<DamagePack> damagePacks = new List<DamagePack>();
	protected List<TailPack> tailPacks = new List<TailPack>();
	protected List<BuffPack> buffPacks = new List<BuffPack>();
	protected ObjLife tunshiObj = null;
	public bool Insert = false;
	public ObjLife InsertObj = null;
	public StringBuilder logUser = new StringBuilder();
	public StringBuilder logTarget = new StringBuilder();
	public StringBuilder logTail = new StringBuilder();
	public StringBuilder logBuff = new StringBuilder();
	public bool isSkipRound;
	public bool jiedupin = false;
	public bool jiedutu = false;

	#endregion

	#endregion

	void Start()
	{
		InitData();
	}


	protected virtual void InitData() { }

	#region 战斗流程函数
	protected void onLogicBattleStart()
	{
		ResetAllRole();
		IsBattling = true;
		IsFightFail = false;
		isExitBallte = false;
		Battle?.Invoke(IsBattling);
		actionList.Clear();

		posBeginning.Clear();
		foreach (var item in herosTeam.GetObjLifes())
		{
			item.OnBattleStart();
			posBeginning.Add(item);
		}

		foreach (var item in monsterTeam.GetObjLifes())
		{
			item.OnBattleStart();
			AIBase ai = item.GetComponent<AIBase>();
			if (ai != null)
			{
				ai.StartBattle();
			}
		}
	}

	protected void onLogicBattleNewRound()
	{
		//重置行动队列
		actionList.AddRange(herosTeam.GetObjLifes());
		actionList.AddRange(monsterTeam.GetObjLifes());
		foreach (var obj in monsterTeam.GetObjLifes())
		{
			AIBase ai = obj.gameObject.GetComponent<AIBase>();
			if (ai != null)
			{
				ai.OnNewRound(round);
			}
		}
	}

	protected void onLogicBattleEnd(bool win)
	{
		ResetAllRole();
		summonList.Clear();
		IsFightFail = false;
		IsBattling = false;
		Battle?.Invoke(IsBattling);
		//清除眩晕状态
		foreach (var obj in herosTeam.GetObjLifes())
		{
			obj.RemoveSkillBuff(ObjBuffType.眩晕);
			obj.EndBuff();
		}
		foreach (var item in monsterTeam.GetObjLifes())
		{
			AIBase ai = item.GetComponent<AIBase>();
			if (ai != null)
			{
				ai.EndBattleing();
			}
		}
	}

	#endregion

	#region 角色跟怪物队伍相关
	/// <summary>
	/// 获取角色所在的队伍
	/// </summary>
	/// <param name="obj"></param>
	/// <returns></returns>
	public Team GetTeamFromRole(ObjLife obj)
	{
		return herosTeam.Contains(obj) ? herosTeam : monsterTeam;
	}
	public Team GetTeamFromRole(ObjLife obj, out bool isHeroTeam)
	{
		Team team = herosTeam.Contains(obj) ? herosTeam : monsterTeam;
		isHeroTeam = herosTeam.Contains(obj) ? true : false;
		return team;
	}

	/// <summary>
	/// 使用限制判断
	/// </summary>
	/// <param name="skillData"></param>
	/// <returns></returns>
	protected bool UseLimit(SkillData skillData)
	{
		var enemys = enemyTeam.GetRoleByPosition(skillData.position).ToArray();

		return GetLimitResult(skillData.useLimits, currentObjLife, enemys);
	}

	//判断限制条件 ：1 
	public bool GetLimitResult(Limit limit, ObjLife currentObjLife, ObjLife[] enemys, float value = 0)
	{
		switch (limit.limitType)
		{
			case LimitType.杀戮形态不可用:
			case LimitType.间谍形态不可用:
				return true;
			case LimitType.场上未存在buff:
				if (!(herosTeam.GetObjLifes().Any(s => s.ExistsSkillBuff(ObjBuffType.炸弹)) || monsterTeam.GetObjLifes().Any(s => s.ExistsSkillBuff(ObjBuffType.炸弹))))
				{
					return true;
				}
				break;
			case LimitType.士气:
			case LimitType.生命:
				return LimitContrastValue(limit, limit.target == LimitTarget.自身 ? new ObjLife[] { currentObjLife } : enemys);

			case LimitType.处于什么状态:
				return LimitStatus(limit, limit.target == LimitTarget.自身 ? new ObjLife[] { currentObjLife } : enemys);

			case LimitType.怪物类型:
				return LimitUnitType(limit, limit.target == LimitTarget.自身 ? new ObjLife[] { currentObjLife } : enemys);

			case LimitType.死亡:
				return LimitUnitDeath(limit, limit.target == LimitTarget.自身 ? new ObjLife[] { currentObjLife } : enemys, value);


			case LimitType.具有buff:
				return LimitContainBuff(limit, limit.target == LimitTarget.自身 ? new ObjLife[] { currentObjLife } : enemys);

			case LimitType.未具有buff:
				return !LimitContainBuff(limit, limit.target == LimitTarget.自身 ? new ObjLife[] { currentObjLife } : enemys);

		}


		return false;
	}

	public bool GetLimitResult(List<Limit> limits, ObjLife currentObjLife, ObjLife[] enemys)
	{
		foreach (var limit in limits)
		{
			return GetLimitResult(limit, currentObjLife, enemys);
		}

		return false;
	}

	/// <summary>
	/// 技能目标位置是否有角色
	/// </summary>
	/// <param name="objLife"></param>
	/// <param name="skillData"></param>
	/// <returns></returns>
	protected bool TargetPositionHasRole(ObjLife objLife, SkillData skillData)
	{
		//攻击的队伍
		Team our = GetTeamFromRole(objLife);
		//被攻击的队伍
		Team enemy = our == herosTeam ? monsterTeam : herosTeam;

		switch (skillData.targetType)
		{
			case SkillTargetType.己方全体:
			case SkillTargetType.己方单体:
			case SkillTargetType.自身:
				return true;
			case SkillTargetType.己方全体_不含自身:
			case SkillTargetType.己方单体_不含自身:
				return our.GetCount() > 1;
			case SkillTargetType.敌方单体:
			case SkillTargetType.敌方群体:
				if (skillData.position.W && enemy.GetCount() > 0)
				{
					return true;
				}
				if (skillData.position.X && enemy.GetCount() > 1)
				{
					return true;
				}
				if (skillData.position.Y && enemy.GetCount() > 2)
				{
					return true;
				}
				if (skillData.position.Z && enemy.GetCount() > 3)
				{
					return true;
				}
				return false;
			default:
				Debug.Log("技能目标类型错误");
				return false;
		}
	}


	#endregion



	#region 工具方法

	/// <summary>
	/// 通过UI索引获取技能数据
	/// </summary>
	/// <param name="index"></param>
	/// <returns></returns>
	public SkillData GetSkillDataByIndex(int index)
	{
		if (index >= skillDatas.Count)
		{
			throw new Exception($"index = {index} count = {skillDatas.Count}");
		}
		return index < skillDatas.Count ? skillDatas[index] : null;
	}


	// 判断是否存在BUFF
	protected bool LimitContainBuff(Limit limit, IList<ObjLife> objlifes)
	{
		return objlifes.Any(s => s.ExistsSkillBuff(limit.buffType));
	}



	/// <summary>
	/// 
	/// </summary>
	/// <param name="limit"></param>
	/// <param name="life 目标life"></param>
	/// <param name="isMaxValue 是否是最大生命"></param>
	/// <returns></returns>

	private float GetLimitContrastValue(Limit limit, ObjLife life, bool isMaxValue)
	{
		if (limit.limitType == LimitType.生命)
		{
			if (isMaxValue) return life.GetMaxHp();
			else return life.GetHp();
		}
		else if (limit.limitType == LimitType.士气)
		{
			if (isMaxValue) return life.GetMaxMorale();
			else return life.GetMorale();
		}

		return 0;
	}


	// 判断某个值或系数大小
	public bool LimitContrastValue(Limit limit, IList<ObjLife> objlifes)
	{
		if (limit.limitCondition.Equals(LimitCondition.小于) && limit.valueType.Equals(ValueType.系数))
		{
			return objlifes.Any((x) =>
			{
				return
				   //当前生命比系数的要小
				   GetLimitContrastValue(limit, x, false) <

				   GetLimitContrastValue(limit, x, true) * limit.limitValue / 100f;
			});

		}
		if (limit.limitCondition == LimitCondition.小于 && limit.valueType == ValueType.加减)
		{
			return objlifes.Any((x) =>
			{
				return GetLimitContrastValue(limit, x, false) < limit.limitValue;
			});
		}
		if (limit.limitCondition.Equals(LimitCondition.大于) && limit.valueType.Equals(ValueType.系数))
		//如果valuetype是系数的话那么要和生命值百分比做计算
		{
			return objlifes.Any((x) =>
			{
				return
				   //当前生命比系数的要大
				   GetLimitContrastValue(limit, x, false) >
				   GetLimitContrastValue(limit, x, true) *
				   limit.limitValue / 100f;
			});

		}
		if (limit.limitCondition == LimitCondition.大于 && limit.valueType == ValueType.加减)
		{
			return objlifes.Any((x) =>
			{
				return GetLimitContrastValue(limit, x, false) > limit.limitValue;
			});
		}
		return false;
	}
	/// <summary>
	/// 技能释放位置限制判断
	/// </summary>
	/// <param name="objPos"></param>
	/// <param name="position"></param>
	/// <returns></returns>
	protected bool PositionLimit(int objPos, SkillPosition position)
	{
		switch (objPos)
		{
			case 0:
				return position.A;
			case 1:
				return position.B;
			case 2:
				return position.C;
			case 3:
				return position.D;
		}

		Debug.Log("位置错误");
		return false;
	}

	public void DoSummon(SkillSummon skillSummon, ObjLife objLife)
	{
		summonList.Add(BattleCalculating.GetSummon(skillSummon, objLife));
	}

	/// <summary>
	/// 添加到技能可选目标列表
	/// </summary>
	/// <param name="objLife"></param>
	/// <param name="skillData"></param>
	public void AddTargetToCanBeSelected(ObjLife objLife, SkillData skillData)
	{
		Debug.Log("测试-AddTargetToCanBeSelected");
		canBeSelected.Clear();

		switch (skillData.targetType)
		{
			case SkillTargetType.自身:
				AddTarget(objLife, RoleRelationType.友方, skillData);
				break;
			case SkillTargetType.己方单体:
			case SkillTargetType.己方全体:
				foreach (var item in GetTeamFromRole(objLife).GetObjLifes())
				{
					AddTarget(item, RoleRelationType.友方, skillData);
				}
				break;
			case SkillTargetType.己方单体_不含自身:
			case SkillTargetType.己方全体_不含自身:
				foreach (var item in GetTeamFromRole(objLife).GetObjLifes())
				{
					if (item == objLife)
					{
						continue;
					}
					AddTarget(item, RoleRelationType.友方, skillData);
				}
				break;
			case SkillTargetType.敌方单体:
			case SkillTargetType.敌方群体:
				Team enemyTeam = GetTeamFromRole(objLife) == herosTeam ? monsterTeam : herosTeam;
				TryAddEnemyTarget(skillData.position.W, 0, enemyTeam, skillData);
				TryAddEnemyTarget(skillData.position.X, 1, enemyTeam, skillData);
				TryAddEnemyTarget(skillData.position.Y, 2, enemyTeam, skillData);
				TryAddEnemyTarget(skillData.position.Z, 3, enemyTeam, skillData);
				break;
		}
		///Distinct方法不加参数的话，去重的规则是比较对象集合中对象的引用是否相同，如果相同，则去重，否则不去重。
		canBeSelected = canBeSelected.Distinct().ToList();
	}

	/// <summary>
	/// 尝试添加一个敌方目标到可选列表
	/// </summary>
	/// <param name="useable"></param>
	/// <param name="index"></param>
	/// <param name="enemyTeam"></param>
	/// <param name="skillData"></param>
	private void TryAddEnemyTarget(bool useable, int index, Team enemyTeam, SkillData skillData)
	{
		if (useable && enemyTeam.GetObjLife(index) != null)
		{
			AddTarget(enemyTeam.GetObjLife(index), RoleRelationType.敌方, skillData);
		}
	}

	/// <summary>
	/// 添加一个目标到可选列表
	/// </summary>
	/// <param name="obj"></param>
	/// <param name="type"></param>
	/// <param name="targetLimits"></param>
	private void AddTarget(ObjLife obj, RoleRelationType type, SkillData skill)
	{
		if (TargetLimit(skill.targetLimits, obj))
		{
			var guardian = obj.GetBuff(ObjBuffType.被守护);

			if (skill.targetType == SkillTargetType.敌方单体 &&
				(skill.skillType == SkillType.近战伤害 || skill.skillType == SkillType.远程伤害) &&
				guardian.Count > 0 &&
				guardian[0].linkTarget != null)
			{
				canBeSelected.Add(guardian[0].linkTarget);
				IOTools.WriteTxt(Application.dataPath + "/skill_log.txt", $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}添加目标 {obj.name}存在守护者:{guardian[0].linkTarget.name} 目标被转移");
			}
			else
			{
				canBeSelected.Add(obj);
				//IOTools.WriteTxt(Application.dataPath + "/skill_log.txt", $"添加目标 {obj.name}");
			}
			obj.ShowTargetTips(type);
		}
	}

	/// <summary>
	/// 目标限制判断——技能是否可用
	/// </summary>
	/// <param name="skillData"></param>
	/// <returns></returns>
	protected bool TargetLimit(SkillData skillData)
	{
		foreach (var limit in skillData.targetLimits)
		{
			List<ObjLife> targets = enemyTeam.GetRoleByPosition(skillData.position);
			switch (limit.limitType)
			{
				case LimitType.具有buff:

					foreach (var target in targets)
					{
						if (target.ExistsSkillBuff(limit.buffType))
						{
							return true;
						}
					}
					break;
				case LimitType.不可对boss使用:
					List<ObjLife> tars = enemyTeam.GetRoleByPosition(skillData.position);
					foreach (var target in tars)
					{
						if (target.GetVocation() != HeroVocation.boss)
						{
							return true;
						}
					}
					break;
				case LimitType.未具有buff:
					targets = enemyTeam.GetRoleByPosition(skillData.position);
					foreach (var target in targets)
					{
						if (!target.ExistsSkillBuff(limit.buffType))
						{
							return true;
						}
					}
					break;
				case LimitType.生命:
					targets = enemyTeam.GetRoleByPosition(skillData.position);
					return LimitContrastValue(limit, targets);
			}
		}

		return false;
	}

	/// <summary>
	/// 目标限制判断——当前目标是否可选
	/// </summary>
	/// <param name="limit"></param>
	/// <param name="target"></param>
	/// <returns></returns>
	protected bool TargetLimit(List<Limit> limits, ObjLife target)
	{

		foreach (var limit in limits)
		{
			switch (limit.limitType)
			{
				case LimitType.具有buff:
					if (!target.ExistsSkillBuff(limit.buffType))
					{
						return false;
					}
					break;
				case LimitType.未具有buff:
					if (target.ExistsSkillBuff(limit.buffType))
					{
						return false;
					}
					break;
			}
		}

		return true;
	}

	/// <summary>
	/// 其他限制判断
	/// </summary>
	/// <param name="skillData"></param>
	/// <returns></returns>
	protected bool OtherLimit(SkillData skillData)
	{
		if (skillData.id == 1086)
		{
			if (DataManager.Instance.modeData.moneyMode.count < 100)
			{
				return false;
			}
		}

		return true;
	}


	/// <summary>
	/// 判断技能是否能释放
	/// </summary>
	public bool CanUseSkill(ObjLife objLife, SkillData skillData)
	{
		if (Instance.IsEnemySkillTest())
		{
			return Instance.EnemyCanUseSkill(objLife, skillData);
		}
		if (!PositionLimit(GetTeamFromRole(objLife).GetIndex(objLife), skillData.position))
		{
			return false;
		}
		if (!TargetPositionHasRole(objLife, skillData))
		{
			return false;
		}
		if (!objLife.IsUseSkillForCd(skillData.id))
		{
			return false;
		}
		if (skillData.useLimits.Count > 0)
		{
			if (!UseLimit(skillData))
			{
				return false;
			}
		}
		if (skillData.targetLimits.Count > 0)
		{
			if (!TargetLimit(skillData))
			{
				return false;
			}
		}
		if (!OtherLimit(skillData))
		{
			return false;
		}
		return true;
	}


	public void CureAddTeamMemeberMoral(ObjLife currentObjLife)
	{
		List<ObjLife> timeObjLifes = GetTeamFromRole(currentObjLife).GetObjLifes();
		foreach (var objLife in timeObjLifes)
		{
			if (currentObjLife != objLife)
			{

				//objLife.UpdateMorale(-10);
				//objLife.UpdateMorale(2);
			}
		}
	}

	/// <summary>
	/// buff计算
	/// </summary>
	/// <param name="user"></param>
	/// <param name="targets"></param>
	/// <param name="skill"></param>
	protected void BuffCalculating(ObjLife user, List<ObjLife> targets, SkillData skill)
	{
		Debug.Log("测试-计算buff-BuffCalculating");
		int level = user.GetSkillLevel(skill);
		bool EntryAdditional = false;//判断额外buff是否已经进入
		foreach (var item in skill.skillBuffs)
		{
			switch (item.buffTarget)
			{
				case SkillBuffTarget.自身:
					buffPacks.Add(BattleCalculating.GetBuff(user, user, item, level, false));
					if (!EntryAdditional)
					{
						AddAdditionalBuff(user, new List<ObjLife>() { user }, skill);

					}
					break;
				case SkillBuffTarget.目标:
					bool isCalDodge;
					foreach (var it in targets)
					{
						isCalDodge = !(GetTeamFromRole(user) == GetTeamFromRole(it));//对自身释放，不能闪避，对怪物，可以
						if (skill.id == 1082)
						{
							SkillBuff buff = GetBuffData1082(it);
							if (buff != null)
							{

								buffPacks.Add(BattleCalculating.GetBuff(user, it, buff, level, isCalDodge));
							}
						}
						else
						{
							BuffPack pack = BattleCalculating.GetBuff(user, it, item, level, isCalDodge);
							if (pack.IsDodge == false && EntryAdditional == false)
							{
								EntryAdditional = true;
								AddAdditionalBuff(user, new List<ObjLife>() { it }, skill);
							}
							buffPacks.Add(pack);
						}
					}
					break;
				case SkillBuffTarget.全体敌人:
					foreach (var it in enemyTeam.GetObjLifes())
					{
						BuffPack pack = BattleCalculating.GetBuff(user, it, item, level, true);
						if (pack.IsDodge == false && EntryAdditional == false)
						{
							AddAdditionalBuff(user, new List<ObjLife>() { it }, skill);
						}
						buffPacks.Add(pack);
					}
					break;
				case SkillBuffTarget.其他敌人:
					foreach (var it in enemyTeam.GetObjLifes())
					{
						if (targets.Contains(it))
						{
							continue;
						}
						BuffPack pack = BattleCalculating.GetBuff(user, it, item, level, true);
						if (pack.IsDodge == false && EntryAdditional == false)
						{
							EntryAdditional = true;
							AddAdditionalBuff(user, new List<ObjLife>() { it }, skill);
						}
						buffPacks.Add(pack);
					}
					break;
				case SkillBuffTarget.全体队友:
					foreach (var it in currentTeam.GetObjLifes())
					{
						buffPacks.Add(BattleCalculating.GetBuff(user, it, item, level, false));
					}
					break;
				case SkillBuffTarget.其他队友:
					foreach (var it in currentTeam.GetObjLifes())
					{
						if (it == user)
						{
							continue;
						}
						buffPacks.Add(BattleCalculating.GetBuff(user, it, item, level, false));
					}
					break;

			}
			EntryAdditional = true;
		}

	}


	/// <summary>
	/// 技能额外buff
	/// </summary>
	/// <param name="user"></param>
	/// <param name="targets"></param>
	/// <param name="skill"></param>
	protected void AddAdditionalBuff(ObjLife user, List<ObjLife> targets, SkillData skill)
	{
		int level = user.GetSkillLevel(skill);
		foreach (var target in targets)
		{
			Action<ExtraDamage.Data> func = (data) =>
			{
				switch (data.key)
				{
					case ExtraDamage.Keys.增加Buff种类:
						SkillBuff buff = data.buff;

						AddBuff(buff, user, target, level);
						logUser.AppendLine($"[额外效果] 增加Buff {buff.buffType} ");
						break;
					case ExtraDamage.Keys.自身士气:
						int selfMoraleAdd = BattleCalculating.AnalysisLevel(data.value, level);
						user.UpdateMorale(selfMoraleAdd, "额外buff 自身士气");
						logUser.AppendLine($"[额外效果] 自身士气增加 {selfMoraleAdd}");
						break;

				}

			};
			foreach (var item in skill.additionalDamage)
			{

				if (GetLimitResult(item.limit, user, new ObjLife[] { target }))
				{
					foreach (var data in item.kv)
					{
						func(data);
					}
				}

			}

		}
	}



	/// <summary>
	/// 添加buff
	/// </summary>
	/// <param name="buff"></param>
	/// <param name="self"></param>
	/// <param name="target"></param>
	/// <param name="level"></param>
	public void AddBuff(SkillBuff buff, ObjLife self, ObjLife target, int level)
	{
		int effectiveRounds = buff.EffectiveRoundsOrRandom();
		switch (buff.buffTarget)
		{
			case SkillBuffTarget.自身:
				self.AddSkillBuff(new ObjSkillBuff(
						buff.buffType,
						buff.valueType,
						BattleCalculating.AnalysisLevel(buff.value, level),
						effectiveRounds));
				break;
			case SkillBuffTarget.目标:
				target.AddSkillBuff(new ObjSkillBuff(
					  buff.buffType,
					  buff.valueType,
					  BattleCalculating.AnalysisLevel(buff.value, level),
					  effectiveRounds));
				break;
			case SkillBuffTarget.全体队友:
			case SkillBuffTarget.全体敌人:
			case SkillBuffTarget.其他队友:
			case SkillBuffTarget.其他敌人:
				var obj = (buff.buffTarget == SkillBuffTarget.全体队友 || buff.buffTarget == SkillBuffTarget.其他队友) ?
					self : target;
				List<ObjLife> objlifes = null;
				if (herosTeam.Contains(obj))
				{
					objlifes = GetHerosLife();
				}
				else
				{
					objlifes = GetMonsterLife();
				}

				if (buff.buffTarget == SkillBuffTarget.其他队友 || buff.buffTarget == SkillBuffTarget.其他敌人)
				{
					objlifes.Remove(obj);
				}

				foreach (var item in objlifes)
				{
					item.AddSkillBuff(new ObjSkillBuff(
					 buff.buffType,
					 buff.valueType,
					 BattleCalculating.AnalysisLevel(buff.value, level),
					 effectiveRounds));
				}

				break;
		}
	}


	/// <summary>
	/// 计算异化词条buff
	/// </summary>
	/// <param name="user"></param>
	/// <param name="targets"></param>
	/// <param name="skill"></param>
	protected void BuffCalculating(ObjLife user, List<ObjLife> targets, List<SkillBuff> skillBuffs)
	{
		Debug.Log("测试-计算buff-词条额外buff");
		int level = 1;
		foreach (var item in skillBuffs)
		{
			switch (item.buffTarget)
			{
				case SkillBuffTarget.自身:
					buffPacks.Add(BattleCalculating.GetBuff(user, user, item, level, false));
					break;
				case SkillBuffTarget.目标:
					bool isCalDodge;
					foreach (var it in targets)
					{
						isCalDodge = !(GetTeamFromRole(user) == GetTeamFromRole(it));

						{
							buffPacks.Add(BattleCalculating.GetBuff(user, it, item, level, isCalDodge));
						}
					}
					break;
				case SkillBuffTarget.全体敌人:
					foreach (var it in enemyTeam.GetObjLifes())
					{
						buffPacks.Add(BattleCalculating.GetBuff(user, it, item, level, true));
					}
					break;
				case SkillBuffTarget.其他敌人:
					foreach (var it in enemyTeam.GetObjLifes())
					{
						if (targets.Contains(it))
						{
							continue;
						}
						buffPacks.Add(BattleCalculating.GetBuff(user, it, item, level, true));
					}
					break;
				case SkillBuffTarget.全体队友:
					foreach (var it in currentTeam.GetObjLifes())
					{
						buffPacks.Add(BattleCalculating.GetBuff(user, it, item, level, false));
					}
					break;
				case SkillBuffTarget.其他队友:
					foreach (var it in currentTeam.GetObjLifes())
					{
						if (it == user)
						{
							continue;
						}
						buffPacks.Add(BattleCalculating.GetBuff(user, it, item, level, false));
					}
					break;
			}
		}
	}

	public SummonPack[] GetRoleSummon(ObjLife unit, ObjBuffType summonType)
	{
		var target = summonList.Where(x => x.Source.GetHashCode().Equals(unit.GetHashCode()) && x.Type == summonType);

		return target.ToArray();
	}

	/// <summary>
	/// 计算召唤
	/// </summary>
	/// <param name="skillData"></param>
	protected void SummonCalculating(SkillData skillData)
	{
		Debug.Log("测试-计算召唤-SummonCalculating");
		foreach (var summon in skillData.summon)
		{
			summonList.Add(BattleCalculating.GetSummon(summon, currentObjLife));
		}
	}


	/// <summary>
	/// 伤害生效
	/// </summary>
	/// <param name="attackeds"></param>
	/// <param name="values"></param>
	protected void DamageTakeEffect(List<ObjLife> attackeds, List<DamagePack> damagePacks, ObjLife user)
	{
		Debug.Log("测试-伤害生效-DamageTakeEffect");
		bool IsCrits = false;
		bool IsDodge = true;
		for (int i = 0; i < attackeds.Count; ++i)
		{
			Debug.Log("测试-伤害生效-DamageTakeEffect-1");

			if (damagePacks[i].IsDodge)
			{
				attackeds[i].OnDodge();
			}
			else
			{
				IsDodge = false;
			}

			attackeds[i].UpdateHp(-damagePacks[i].Value, damagePacks[i].IsDodge);
			if (currentSkill.id == 9020)//士气技能-鳞甲箭
			{
				DataManager.Instance.modeData.moneyMode.count += damagePacks[i].Value * 10;
			}
			Debug.Log("测试-伤害生效-DamageTakeEffect-2");

			if (damagePacks[i].IsCrits && !IsCrits)
			{
				IsCrits = damagePacks[i].IsCrits;

				//user.ShowCrits();
			}

			if (!damagePacks[i].IsDodge) attackeds[i].ShowValue(-damagePacks[i].Value, 0, damagePacks[i].IsCrits);

			if (IsBattling && damagePacks[i].IsCrits)
			{
				canBeSelected[i].TalentTrigger(TalentTriggerType.被暴击);
			}

			Debug.Log("测试-伤害生效-DamageTakeEffect-3");
		}

		if (IsDodge)
		{
			user.OnMiss();
		}
	}

	/// <summary>
	/// 添加戒断技能buff
	/// </summary>
	/// <param name="user"></param>
	/// <param name="targets"></param>
	/// <param name="skillType"></param>
	protected void AddDuanjieSkillBuff(ObjLife user, List<ObjLife> targets, GamblerSkillType skillType)
	{
		if (skillType == GamblerSkillType.戒赌 && jiedutu == true)
		{
			logTarget.AppendLine($"戒断技能生效，自身增加50伤害");
			user.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.伤害, ValueType.系数, 50));
			jiedutu = false;
		}
		if (skillType == GamblerSkillType.戒毒 && jiedupin == true)
		{
			foreach (ObjLife item in targets)
			{
				item.UpdateMorale(+5, "戒断");
				jiedupin = false;
				logTarget.AppendLine($"戒断技能生效，{item.GetHeroName()}士气增加5");
			}
		}
	}

	/// <summary>
	/// 回复生命生效
	/// </summary>
	/// <param name="tailPacks"></param>
	protected void CureHpTakeEffect(List<TailPack> tailPacks)
	{
		List<TailPack> tails = tailPacks.FindAll(s => s.Type == SkillTailType.回复生命);
		foreach (var item in tails)
		{
			item.Target.UpdateHp(item.Value);
			CureAddTeamMemeberMoral(item.Target);
			item.Target.ShowValue(item.Value, 0, false);
			//xl 264 治疗三次bug
			if (++item.Target.BeCureCount >= 3)
			{
				item.Target.TalentTrigger(TalentTriggerType.被治疗3次);
				item.Target.BeCureCount = 0;
			}
		}

		tails = tailPacks.FindAll(s => s.Type == SkillTailType.吸血);
		foreach (var item in tails)
		{
			int damageSum = damagePacks.Where(s => !s.IsDodge).Sum(s => s.Value);
			var v = Mathf.RoundToInt(damageSum * item.Value / 100f);
			item.Target.UpdateHp(v);
			item.Target.ShowValue(v, 0, false);
		}

		tails = tailPacks.FindAll(s => s.Type == SkillTailType.回复生命至上限);
		foreach (var item in tails)
		{
			CureAddTeamMemeberMoral(item.Target);
			var v = item.Target.GetMaxHp() - (int)item.Target.GetHp();
			item.Target.UpdateHp(v);
			item.Target.ShowValue(v, 0, false);
		}
	}



	#region 英雄士气相关
	/// <summary>
	/// 减少被攻击对象士气
	/// </summary>
	/// <param name="attackedObjLifes"></param>
	protected void ReduceAttackedObjLifesMoral(List<ObjLife> attackedObjLifes)
	{
		if (attackedObjLifes == null || attackedObjLifes.Count == 0)
		{
			return;
		}
	}
	/// <summary>
	/// 随机减少某个成员士气
	/// </summary>
	/// <returns></returns>
	public bool ReduceRandomMemeberMoralWhenEnterNewRoom()
	{
		bool haveChance = UnityEngine.Random.Range(0, 100) < 50 ? true : false;
		if (haveChance)
		{
			herosTeam.GetObjLifes()[UnityEngine.Random.Range(0, herosTeam.GetObjLifes().Count)].UpdateMorale(-5, "进后新房间后");
		}

		return haveChance;
	}

	/// <summary>
	/// 每倒退2格道路，有50%概率士气-5
	/// </summary>
	public bool ReduceMoralWhenGoBack2Road()
	{
		bool haveChance = UnityEngine.Random.Range(0, 100) < 30 ? true : false;
		if (haveChance)
		{
			for (int i = 0; i < herosTeam.GetObjLifes().Count; i++)
			{
				herosTeam.GetObjLifes()[i].UpdateMorale(-2, "退2格后");
			}
		}

		return haveChance;
	}
	/// <summary>
	/// 每前进8格道路，有35%概率随机一名英雄士气-3
	/// </summary>
	public void AddMoralWhenGoForword8Road()
	{
		bool haveChance = UnityEngine.Random.Range(0, 100) < 35 ? true : false;
		if (haveChance)
		{
			herosTeam.GetObjLifes()[UnityEngine.Random.Range(0, herosTeam.GetObjLifes().Count)].UpdateMorale(-3, "每前进8格道路");
		}
	}
	/// <summary>
	/// 每前进18格道路，有35%概率全队士气-2
	/// </summary>
	public void AddMoralWhenGoForword18Road()
	{
		bool haveChance = UnityEngine.Random.Range(0, 100) < 35 ? true : false;
		for (int i = 0; i < herosTeam.GetObjLifes().Count; i++)
		{
			if (haveChance)
			{
				herosTeam.GetObjLifes()[i].UpdateMorale(-2, "每前进18格道路");
			}
		}
	}

	int stepN = 0;

	/// <summary>
	/// 前进0格之后,每格检查,有80%概率全队士气-3
	/// </summary>
	public bool AddMoralWhenGoForword0Road()
	{
		float d = 0.1f * Mathf.Pow(1.1f, stepN) * 100;

		bool haveChance = UnityEngine.Random.Range(0, 100) < d ? true : false;
		if (haveChance)
		{
			stepN = 0;
			herosTeam.GetObjLifes()[UnityEngine.Random.Range(0, herosTeam.GetObjLifes().Count)].UpdateMorale(-3, "前进0格后");
		}
		else
		{
			stepN++;
		}

		return haveChance;
	}

	/// <summary>
	/// 前进10格之后,每格检查,有80%概率全队士气-2
	/// </summary>
	public bool AddMoralWhenGoForword10Road()
	{
		bool haveChance = UnityEngine.Random.Range(0, 100) < 80 ? true : false;
		if (haveChance)
		{
			for (int i = 0; i < herosTeam.GetObjLifes().Count; i++)
			{
				herosTeam.GetObjLifes()[i].UpdateMorale(-2, "前进10格后");
			}
		}

		return haveChance;
	}

	/// <summary>
	/// 崩溃，0/10
	/// </summary>
	/// <param name="threshold"></param>
	/// <param name="objLife"></param>

	//public void MoraleUpdateToThreshold(int threshold, ObjLife objLife)
	//{
	//    if (objLife.GetRoleType() == RoleType.怪物) { return; }
	//    switch (threshold)
	//    {
	//        case 0:
	//            NewbieGuideMag.Instance.triggerGuide(GuideDataSet.guideEnum.morale0);
	//            objLife.AddPermanentBuff(new ObjPermanentBuff(ObjBuffType.最大生命, ValueType.系数, -25, BuffSourceType.负向士气));
	//            objLife.AddPermanentBuff(new ObjPermanentBuff(ObjBuffType.人心惶惶, ValueType.加减, 0, BuffSourceType.负向士气));
	//            float probability = UnityEngine.Random.Range(0, 101);
	//            int deathStateTimes = objLife.ExistsPermanentBuff(ObjBuffType.濒死) ? objLife.GetPermanentBuff(ObjBuffType.濒死).Count : 0;
	//            if (probability <= 10 + deathStateTimes * 5)
	//            {
	//                objLife.AddPermanentBuff(new ObjPermanentBuff(ObjBuffType.濒死, ValueType.加减, 0, BuffSourceType.生命));
	//                objLife.SetHp(0);
	//            }
	//            //objLife.SetHp(0);
	//            break;
	//        case 10:
	//            NewbieGuideMag.Instance.triggerGuide(GuideDataSet.guideEnum.morale10);
	//            if (UnityEngine.Random.Range(0f, 1f) < 0.2f)
	//            {
	//                objLife.AddSkillBuff(new ObjSkillBuff(ObjBuffType.持续回复士气, ValueType.加减, 10, 3));
	//            }
	//            else
	//            {
	//                objLife.AddSkillBuff(new ObjSkillBuff(ObjBuffType.恐惧之心, ValueType.加减, 0, 3));
	//            }
	//            break;
	//        default:
	//            Debug.Log("士气临界值错误");
	//            break;
	//    }
	//}


	/// <summary>
	/// 逃跑队员士气减少20
	/// </summary>
	public void FleeReduceTeamMemeberMoral()
	{
		foreach (var item in herosTeam.GetObjLifes())
		{
			item.UpdateMorale(-20, "逃跑队员士气减少");
		}
	}
	#endregion


	#endregion

	#region Buff和Tail数据

	protected SkillBuff GetBuffData1062(SkillBuff skillBuff)
	{
		skillBuff.effectiveRounds = UnityEngine.Random.Range(1, 4);
		return skillBuff;
	}

	protected TailValue GetTailData1082(ObjLife target)
	{
		if (target.ExistsSkillBuff(ObjBuffType.流血))
		{
			TailValue tail = new TailValue
			{
				buffTarget = SkillBuffTarget.目标,
				tailType = SkillTailType.流血加重,
				valueType = ValueType.加减,
				maxValue = new IntLevel { level1 = -2 },
				minValue = new IntLevel { level1 = -2 }
			};

			return tail;
		}
		else
		{
			return null;
		}
	}

	protected SkillBuff GetBuffData1082(ObjLife target)
	{
		if (!target.ExistsSkillBuff(ObjBuffType.流血))
		{
			SkillBuff buff = new SkillBuff
			{
				buffTarget = SkillBuffTarget.目标,
				buffType = ObjBuffType.流血抗性,
				valueType = ValueType.系数,
				value = new IntLevel { level1 = -30 },
				effectiveRounds = 3,
				rate = new IntLevel { level1 = 120 }
			};

			return buff;
		}
		else
		{
			return null;
		}
	}

	protected SkillData GetSkillData1067(SkillData skillData)
	{
		skillData.skillTails = new List<TailValue>();
		skillData.skillBuffs = new List<SkillBuff>();

		float roll = UnityEngine.Random.Range(0f, 1f);
		if (roll > 0.5f)
		{
			DebugLog.Instance.AddLog("增强实验成功\n");
			skillData.skillTails.Add(new TailValue
			{
				buffTarget = SkillBuffTarget.目标,
				tailType = SkillTailType.行动点,
				maxValue = new IntLevel { level1 = 1 },
				minValue = new IntLevel { level1 = 1 },
				rate = new IntLevel { level1 = 0 }
			});
		}
		else
		{
			DebugLog.Instance.AddLog("增强实验失败\n");
			skillData.skillBuffs.Add(new SkillBuff
			{
				buffTarget = SkillBuffTarget.目标,
				buffType = ObjBuffType.眩晕,
				effectiveRounds = 1,
				value = new IntLevel { level1 = 0 },
				rate = new IntLevel { level1 = 0 }
			});
		}

		skillData.skillTails.Add(new TailValue
		{
			buffTarget = SkillBuffTarget.自身,
			tailType = SkillTailType.士气,
			valueType = ValueType.加减,
			maxValue = new IntLevel { level1 = 3 },
			minValue = new IntLevel { level1 = 3 },
			rate = new IntLevel { level1 = 0 }
		});

		return skillData;
	}

	#endregion



	#region 战斗逻辑公用代码

	/// <summary>
	///  判断角色形态 双面间谍_间谍形态
	/// </summary>
	/// <param name="limit"></param>
	/// <param name="objlifes"></param>
	/// <returns></returns>
	protected bool LimitStatus(Limit limit, IList<ObjLife> objlifes)
	{
		return objlifes.Any((s) =>
		{
			if (s.IsSpy && limit.limitTargetStatus == LimitTargetStatus.双面间谍_间谍形态)
			{
				return true;
			}
			else if (!s.IsSpy && limit.limitTargetStatus == LimitTargetStatus.双面间谍_杀戮形态)
			{
				return true;
			}
			return false;
		});
	}

	/// <summary>
	/// 判断单位类型
	/// </summary>
	/// <param name="limit"></param>
	/// <param name="objlifes"></param>
	/// <returns></returns>
	protected bool LimitUnitType(Limit limit, IList<ObjLife> objlifes)
	{
		return objlifes.Any((s) =>
		{
			return s.TheUnitType == limit.limitUnitType;
		});
	}

	/// <summary>
	/// 判定死亡
	/// </summary>
	/// <param name="limit"></param>
	/// <param name="objlifes"></param>
	/// <param name="value"></param>
	/// <returns></returns>
	protected bool LimitUnitDeath(Limit limit, IList<ObjLife> objlifes, float value)
	{
		return objlifes.Any((s) =>
		{
			return s.isDestroyed || (s.GetHp() - value) <= 0;
		});
	}

	#endregion


	#region 公用代码
	public IEnumerator IEDelayAction(float dTime, Action callback)
	{
		yield return new WaitForSeconds(dTime);
		callback();
		yield break;
	}

	public void DelayAction(float dTime, Action callback)
	{
		StartCoroutine(IEDelayAction(dTime, callback));
	}

	#endregion

}



#region 结构类

/// <summary>
/// 伤害包结构类
/// </summary>
public class DamagePack
{
	/// <summary>
	/// 闪避
	/// </summary>
	public bool IsDodge { get; }
	/// <summary>
	/// 暴击
	/// </summary>
	public bool IsCrits { get; }
	/// <summary>
	/// 伤害值
	/// </summary>
	public int Value { get; }
	public string DebugLog { get; }

	public DamagePack(bool isDodge, bool isCrits, int value, string debugLog)
	{
		IsDodge = isDodge;
		IsCrits = isCrits;
		Value = value;
		DebugLog = debugLog;
	}
}

/// <summary>
/// 即时效果包结构类
/// </summary>
public class TailPack
{
	public ObjLife Target { get; }
	/// <summary>
	/// 是否闪避
	/// </summary>
	public bool IsDodge { get; }
	public SkillTailType Type { get; }
	public int Value { get; }
	public ObjBuffType BuffType { get; }
	public string DebugLog { get; }

	public TailPack(ObjLife target, bool isDodge, SkillTailType type, int value, string debugLog)
	{
		Target = target;
		IsDodge = isDodge;
		Type = type;
		Value = value;
		DebugLog = debugLog;
	}

	public TailPack(ObjLife target, SkillTailType type, ObjBuffType buffType, string debugLog)
	{
		Target = target;
		Type = type;
		BuffType = buffType;
		DebugLog = debugLog;
	}
}

/// <summary>
/// buff包结构类
/// </summary>
public class BuffPack
{
	public ObjLife Target { get; }
	public bool IsDodge { get; }
	public ObjBuffType BuffType { get; }
	public int Value { get; }
	public ValueType ValueType { get; }
	public int Round { get; }
	public string DebugLog { get; }

	public BuffPack(ObjLife target, bool isDodge, ObjBuffType buffType, int value, ValueType valueType, int round, string debugLog)
	{
		Target = target;
		IsDodge = isDodge;
		BuffType = buffType;
		Value = value;
		ValueType = valueType;
		Round = round;
		DebugLog = debugLog;
	}
}

/// <summary>
/// 召唤包结构类
/// </summary>
public class SummonPack
{
	public ObjBuffType Type { get; }
	public int Round { get; set; }
	public int Target { get; }
	public ObjLife Source { get; }

	public SummonPack(ObjBuffType type, int round, int target, ObjLife source)
	{
		Type = type;
		Round = round;
		Target = target;
		Source = source;
	}

	public SummonPack(ObjBuffType type, int target, ObjLife source)
	{
		Type = type;
		Target = target;
		Source = source;
	}
}

#endregion
