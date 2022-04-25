using Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// 战斗逻辑中怪物的逻辑
/// </summary>
public class BattleFlowRoleController_Enemy : BattleFlowRoleController
{

	protected override void InitData()
	{
		base.InitData();
		onEnemyDeathDecideWithSummonAct = onEnemyDeathDecideWithSummon;
		onSelectEnemyAutoExcuteAct = onSelectEnemyAutoExcute;
	}

	/// <summary>
	/// 碰到怪物盒子
	/// </summary>
	public void EncounterEnemy(List<ObjLifeData> objLifeDatas)
	{
		if (isBossRoom)
		{
			AudioManager.Instance.PlayMusic(AudioName.BOSSBGM);
		}

		Debug.Log($"测试-EncounterEnemy");
		IsBattling = true;
		Battle?.Invoke(IsBattling);
		IsResponsePanel = false;
		IsResponseRole = false;
		foreach (var item in objLifeDatas)
		{
			item.SetInjuries(0);
		}
		InitRole(objLifeDatas, RoleType.怪物);

	}

	#region SelectRoleInBattle 角色选择处理
	/// <summary>
	/// 选中怪物后，怪物自动执行的行为
	/// </summary>

	protected void onSelectEnemyAutoExcute()
	{
		MonsterGo();
	}

	#endregion

	#region 怪物AI控制模块
	/// <summary>
	/// 怪物开始行动
	/// </summary>
	protected void MonsterGo()
	{
		if (BattleFlowController.Instance.IsEnemySkillTest())
		{
			//怪物测试逻辑，
			onMonsterTestGo();
		}else
		{
			onNormalMonsterGo();
		}
	}

	protected void onMonsterTestGo()
	{
		if (BattleFlowController.Instance.IsEnemySkipRound())
		{
			//测试用,正常逻辑无视该代码
			FindSpeedMaxFromActionList();
			return;
		}

		BattleFlowController.Instance.ShowEnemySkill(currentObjLife, onNormalMonsterGo);
	}

	protected void onNormalMonsterGo()
	{
		AIBase ai = currentObjLife.gameObject.GetComponent<AIBase>();
		// 如果挂载了AI就走AI机制 否则暂时走以前的
		if (ai != null)
		{
			ai.ReGo();
		}
		else
		{
			this.AIUseSkill();
		}
	}


	#endregion


	#region 怪物技能处理
	/// <summary>
	/// 怪物技能释放AI
	/// </summary>
	public void AIUseSkill()
	{
		Debug.Log("测试-AIUseSkill（怪物技能释放AI）");
		// isAttacking = true;
		ObjLife objLife = currentObjLife;

		Debug.Log("测试-AIUseSkill（怪物技能释放AI）- 1");
		List<SkillData> filtrateSkillDatas = FiltrateSkill(objLife);
		//如果没有可用技能，尝试换位
		if (filtrateSkillDatas.Count == 0)
		{
			Debug.Log("测试-AIUseSkill（怪物技能释放AI）- 2");
			Team our = GetTeamFromRole(objLife);
			int index = our.GetIndex(objLife);
			if (objLife.GetPreferMove() == PreferMove.前 && index > 0)
			{
				ExchangeMoveFromButton(our.GetObjLife(index - 1));
				return;
			}
			if (objLife.GetPreferMove() == PreferMove.后 && index < our.GetCount() - 1)
			{
				ExchangeMoveFromButton(our.GetObjLife(index + 1));
				return;
			}

			Debug.Log($"怪物没技能可用，也不能往偏好方向_{objLife.GetPreferMove().ToString()}_换位，只能跳过他的回合");
			DebugLog.Instance.AddLog($"怪物没技能可用，也不能往偏好方向_{objLife.GetPreferMove().ToString()}_换位，只能跳过他的回合");
			DelayAction(ROLE_ACTION_TIME, FindSpeedMaxFromActionList);//   Invoke("FindSpeedMaxFromActionList", ROLE_ACTION_TIME);
			return;
		}
		Debug.Log("测试-AIUseSkill（怪物技能释放AI）- 3");
		List<SkillData> skillDatasTemp = new List<SkillData>(filtrateSkillDatas);
		int testNum = 0;
		while (skillDatasTemp.Count > 0)
		{
			if (testNum > 20000)
			{
				Debug.LogError("死循环啦。。。。。啦。。。啦。。");
				break;
			}
			testNum++;
			//随机一个技能，并获取该技能的可选目标
			currentSkill = skillDatasTemp[UnityEngine.Random.Range(0, skillDatasTemp.Count)];
			Debug.Log($"测试-AIUseSkill（怪物技能释放AI） - {objLife.GetHeroName()} - {currentSkill.name}-{ currentSkill.targetType}");
			AddTargetToCanBeSelected(objLife, currentSkill);
			if (canBeSelected.Count <= 0)
			{
				skillDatasTemp.Remove(currentSkill);
				currentSkill = null;
				continue;
			}
			break;
		}

		if (canBeSelected.Count <= 0)
		{
			Debug.Log("测试-AIUseSkill（怪物技能释放AI）-canBeSelected.Count = 0  currentSkill = null");
			DelayAction(ROLE_ACTION_TIME, FindSpeedMaxFromActionList);//   Invoke("FindSpeedMaxFromActionList", ROLE_ACTION_TIME);;
			return;
		}
		Debug.Log("测试-AIUseSkill（怪物技能释放AI）- 4");
		CloseAllObjTargetTips();
		//随机一个目标
		FightingCalculating(GetSelectedObjLife(canBeSelected, currentSkill));
		objLife.ReleaseSkillEffect(currentSkill);
	}

	/// <summary>
	/// 从可以挑选的对象中选择一个对象
	/// </summary>
	/// <param name="canBeSelected"></param>
	/// <returns></returns>
	protected ObjLife GetSelectedObjLife(List<ObjLife> canBeSelected, SkillData skillData)
	{
		switch (skillData.targetType)
		{
			case SkillTargetType.自身:
				break;
			case SkillTargetType.己方单体:
			case SkillTargetType.己方全体:
				break;
			case SkillTargetType.己方单体_不含自身:
			case SkillTargetType.己方全体_不含自身:
				break;
			case SkillTargetType.敌方单体:
				if (canBeSelected.Any(s => s.ExistsSkillBuff(ObjBuffType.标记)))
				{
					return GetSelectedObjLifeFrom标记(canBeSelected);
				}
				break;
			case SkillTargetType.敌方群体:
				break;
		}
		return canBeSelected[UnityEngine.Random.Range(0, canBeSelected.Count)];
	}

	protected ObjLife GetSelectedObjLifeFrom标记(List<ObjLife> canBeSelected)
	{
		RandomUnRatio randomUnRatio = new RandomUnRatio();
		foreach (ObjLife objLife in canBeSelected)
		{
			int ratio = 100;
			if (objLife.ExistsSkillBuff(ObjBuffType.标记))
			{
				List<ObjSkillBuff> buffs = objLife.GetSkillBuffs().Where(s => s.buffType == ObjBuffType.标记).ToList();
				int addValue = 0;
				foreach (var buff in buffs)
				{
					if (buff.round > 0)
					{
						addValue = Mathf.Max(addValue, buff.buffValue);
					}
				}
				if (addValue != 0)
				{
					//默认按照配置
					ratio += addValue;
				}
				else
				{
					//策划文档上被标记的玩家英雄，受到攻击的概率增加50%
					ratio += 50;
				}
			}
			randomUnRatio.AddMember(objLife, ratio);
		}
		ObjLife select = randomUnRatio.GetRandom();
		if (select != null)
			return select;
		return canBeSelected[UnityEngine.Random.Range(0, canBeSelected.Count)];
	}

	/// <summary>
	/// 筛选怪物可用的技能
	/// </summary>
	public List<SkillData> FiltrateSkill(ObjLife objLife)
	{
		//筛选出可以使用的技能
		List<SkillData> filtrateSkillDatas = DataManager.Instance.GetSkillDatasByIds(objLife.GetHaveSkill());
		for (int i = filtrateSkillDatas.Count - 1; i >= 0; --i)
		{
			if (!CanUseSkill(objLife, filtrateSkillDatas[i]))
			{
				filtrateSkillDatas.RemoveAt(i);
				continue;
			}
		}
		return filtrateSkillDatas;
	}

	/// <summary>
	///怪物吞噬技能 
	/// </summary>
	/// <param name="objLife"></param>
	public void Tunshi_Tuchu(ObjLife objLife)
	{
		GetTeamFromRole(tunshiObj).Add(tunshiObj);
		GetTeamFromRole(tunshiObj).OnTunshiRelease(tunshiObj);
		tunshiObj.gameObject.SetActive(true);
		tunshiObj.SetPosition(RolePosCalculate(GetTeamFromRole(tunshiObj), GetTeamFromRole(tunshiObj).GetIndex(tunshiObj), tunshiObj.GetSize()));
		objLife.UpdateHp((int)tunshiObj.GetHp());
		tunshiObj.UpdateHp(-(int)tunshiObj.GetHp());
	}

	#endregion

	#region 怪物死亡处理
	protected bool onEnemyDeathDecideWithSummon()
	{
		bool IsSummon = false;
		foreach (var item in DeathDecideList)
		{
			// 通知AI 死亡
			AIBase ai = item.gameObject.GetComponent<AIBase>();
			if (ai != null)
			{
				ai.OnDeath();
			}
			if (SummonDeathTakeEffect(item))
			{
				IsSummon = true;
				item.RemoveSkillBuff(ObjBuffType.死亡召唤);
			}
		}
		return IsSummon;
	}
	#endregion

	#region 怪物召唤

	/// <summary>
	/// 延迟召唤生效
	/// </summary>
	protected bool SummonDelayTakeEffect()
	{
		bool result = false;

		//获取本回合的召唤
		List<SummonPack> currentSummon = new List<SummonPack>();
		Debug.Log(summonList.Count);
		for (int i = summonList.Count - 1; i >= 0; --i)
		{
			SummonPack summon = summonList[i];
			if (summon != null)
			{
				switch (summon.Type)
				{
					case ObjBuffType.延迟召唤:
						summon.Round--;
						if (summonList[i].Round <= 0)
						{
							summon.Source.RemoveSkillBuff(ObjBuffType.延迟召唤);
							currentSummon.Add(summon);
							summonList.RemoveAt(i);
						}
						break;
				}
			}
		}

		//判断是否可以召唤
		int summonCount = Mathf.Min(4 - monsterTeam.GetCount(), currentSummon.Count);
		if (summonCount > 0)
		{
			for (int i = 0; i < summonFinish.Length; ++i)
			{
				summonFinish[i] = true;
			}
			result = true;
		}

		//召唤
		int teamCount = monsterTeam.GetCount();
		for (int i = 0; i < summonCount; ++i)
		{
			ObjLifeData target = DataManager.Instance.GetObjLifeDataById(currentSummon[i].Target);

			summonFinish[teamCount + i] = false;
			InitImpl(target, teamCount + i, true);
		}
		return result;
	}

	/// <summary>
	/// 死亡召唤生效
	/// </summary>
	/// <param name="deathObj"></param>
	/// <returns></returns>
	protected bool SummonDeathTakeEffect(ObjLife deathObj)
	{
		summonList.RemoveAll(x => x == null);

		List<SummonPack> currentSummons = summonList.FindAll(s => s.Source == deathObj);
		if (currentSummons == null || currentSummons.Count == 0)
		{
			return false;
		}

		int summonCount = Mathf.Min(4 - monsterTeam.GetCount(), currentSummons.Count);
		if (summonCount > 0)
		{
			for (int i = 0; i < summonFinish.Length; ++i)
			{
				summonFinish[i] = true;
			}
		}

		int teamCount = monsterTeam.GetCount();
		for (int i = 0; i < summonCount; ++i)
		{
			ObjLifeData target = DataManager.Instance.GetObjLifeDataById(currentSummons[i].Target);

			summonFinish[teamCount + i] = false;
			InitImpl(target, teamCount + i, true);
		}
		return true;
	}

	/// <summary>
	/// 即时召唤生效
	/// </summary>
	/// <returns></returns>
	protected bool SummonImmediateTakeEffect()
	{
		bool result = false;

		//获取召唤
		List<SummonPack> currentSummon = new List<SummonPack>();
		for (int i = summonList.Count - 1; i >= 0; --i)
		{
			if (summonList[i] != null && summonList[i].Type == ObjBuffType.即时召唤在前面)
			{
				currentSummon.Add(summonList[i]);
				summonList.RemoveAt(i);
			}
		}

		//判断是否可以召唤
		int summonCount = Mathf.Min(4 - monsterTeam.GetCount(), currentSummon.Count);
		if (summonCount > 0)
		{
			for (int i = 0; i < summonFinish.Length; ++i)
			{
				summonFinish[i] = true;
			}
			result = true;
		}

		//召唤
		int teamCount = monsterTeam.GetCount();
		for (int i = 0; i < summonCount; ++i)
		{
			ObjLifeData target = DataManager.Instance.GetObjLifeDataById(currentSummon[i].Target);

			if (currentSummon[i].Type == ObjBuffType.即时召唤在前面)
			{
				summonFinish[i] = false;
				InitImpl(target, teamCount + i, true, true);
			}
		}
		return result;
	}

	#endregion

	#region 公用函数
	protected List<ObjLife> MonsterListExeptSelf(ObjLife obj)
	{
		List<ObjLife> monsters = monsterTeam.GetObjLifes();
		List<ObjLife> monsterElse = new List<ObjLife>();
		foreach (var a in monsters)
		{
			if (a == obj)
			{
				continue;
			}
			monsterElse.Add(a);
		}
		return monsterElse;
	}

	#endregion
}

/// <summary>
/// 不等比例随机
/// </summary>
public class RandomUnRatio
{
	public struct RandomUnRatioMember
	{
		public ObjLife obj;
		public int ratio;
		public int startIndex;
		public int endIndex;
	}
	List<RandomUnRatioMember> members = new List<RandomUnRatioMember>();
	public void AddMember(ObjLife obj, int ratio)
	{
		RandomUnRatioMember member;
		member.obj = obj;
		member.ratio = ratio;
		if (members.Count == 0)
		{
			member.startIndex = 0;
		}
		else
		{
			member.startIndex = members[members.Count - 1].endIndex;
		}

		member.endIndex = member.startIndex + member.ratio;
		members.Add(member);
	}

	public ObjLife GetRandom()
	{
		int value = UnityEngine.Random.Range(0, members[members.Count - 1].endIndex);
		foreach (RandomUnRatioMember member in members)
		{
			if (member.startIndex <= value && value < member.endIndex)
			{
				return member.obj;
			}
		}

		return null;
	}
}
