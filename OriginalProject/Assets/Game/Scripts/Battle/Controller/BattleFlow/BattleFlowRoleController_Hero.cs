using Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// 编写战斗逻辑中英雄的逻辑
/// </summary>
public class BattleFlowRoleController_Hero : BattleFlowRoleController_Enemy
{
	protected override void InitData()
	{
		base.InitData();
		initHero();
		onSelectHeroRoleAct = onSelectHeroRole;
		onSelectHeroAutoExcuteAct = onSelectHeroAutoExcute;
		onHeroDeathDecideWithBuffAct = onHeroDeathDecideWithBuff;
		calculatingHeroData = initFightingCalculatingHeroData;
	}

	#region 初始化英雄
	/// <summary>
	/// 初始化英雄
	/// </summary>
	void initHero()
	{
		//实例化英雄
		Debug.Log($"测试-{BattleInfo.waitingTeams.Count}");
		//BattleInfo.waitingTeams..OrderBy(s => s.Key);
		List<KeyValuePair<int, ObjLifeData>> tempHeros = new List<KeyValuePair<int, ObjLifeData>>();
		foreach (var item in BattleInfo.waitingTeams) tempHeros.Add(new KeyValuePair<int, ObjLifeData>(item.Key, item.Value));
		tempHeros = tempHeros.OrderBy(s => s.Key).ToList();
		Debug.Log("测试-Start");
		InitRole(tempHeros.Select(s => s.Value).ToList(), RoleType.英雄);  //InitRole(BattleInfo.waitingTeams.Values.ToList(), RoleType.英雄);

	}

	#endregion

	#region SelectRoleInBattle 角色选择处理
	/// <summary>
	/// 选中英雄的时候
	/// </summary>
	/// <param name="objLife"></param>
	protected void onSelectHeroRole(ObjLife objLife)
	{
		if (objLife.GetVocation() == HeroVocation.亡命赌徒)//如果是赌徒，那么进入一个0
		{
			objLife.dutuskill_stack.Push(0);
			objLife.dupinskill_stack.Push(0);
		}
	}
	/// <summary>
	/// 选中英雄后，英雄自动执行的行为
	/// </summary>
	protected void onSelectHeroAutoExcute()
	{
		HeroAiUseSkill();
	}

	protected void HeroAiUseSkill()
	{
		int foundActionIndex = this.heroAiActionIndex;
		this.heroAiActionIndex = -1;

		// UnityEngine.Debug.LogError("test HeroAiUseSkill " + "  " + foundActionIndex);

		damagePacks.Clear();
		tailPacks.Clear();
		buffPacks.Clear();

		switch (foundActionIndex)
		{

			case 1: //殊死一搏
				{
					FileLog.Log("renxinghuanghuang", currentObjLife.GetHeroName() + " 动作 " + "殊死一搏");

					currentObjLife.UpdateMorale(50, "殊死一搏");
					DelayAction(ROLE_ACTION_TIME, FindSpeedMaxFromActionList);

				}
				break;
			case 2: //麻木
				{
					FileLog.Log("renxinghuanghuang", currentObjLife.GetHeroName() + " 动作 " + "麻木");

					DelayAction(ROLE_ACTION_TIME, FindSpeedMaxFromActionList);
				}
				break;
			case 3: //狂热
				{
					FileLog.Log("renxinghuanghuang", currentObjLife.GetHeroName() + " 动作 " + "狂热");

					currentObjLife.AddSkillBuff(new ObjSkillBuff(ObjBuffType.伤害, ValueType.系数, 25, 1));
				}
				break;
			case 4: //猜忌
				{
					FileLog.Log("renxinghuanghuang", currentObjLife.GetHeroName() + " 动作 " + "猜忌");

					List<ObjLife> candidates = new List<ObjLife>();
					List<ObjLife> objLifes = herosTeam.GetObjLifes();
					foreach (var obj in objLifes)
					{
						if (obj != currentObjLife && obj.GetHp() > 0)
						//if (obj.GetHp() > 0)
						{
							candidates.Add(obj);
						}
					}

					if (candidates.Count > 0)
					{
						//攻击随机队友，并跳过回合（精准修正：100|伤害修正：-15%）

						var target = candidates[UnityEngine.Random.Range(0, candidates.Count)];
						damagePacks.Add(new DamagePack(false, false, 5, "猜忌"));
						Team team = GetTeamFromRole(currentObjLife);
						PlayFightingAni(SkillType.远程伤害, currentObjLife, new List<ObjLife> { target });
					}
					else
					{
						DelayAction(ROLE_ACTION_TIME, FindSpeedMaxFromActionList);
					}
				}
				break;
			case 5: //绝望
				{
					FileLog.Log("renxinghuanghuang", currentObjLife.GetHeroName() + " 动作 " + "绝望");

					List<ObjLife> objLifes = herosTeam.GetObjLifes();
					foreach (var obj in objLifes)
					{
						obj.UpdateMorale(UnityEngine.Random.Range(-3, -6), "绝望");
					}

					DelayAction(ROLE_ACTION_TIME, FindSpeedMaxFromActionList);
				}
				break;
			case 6: //暴死
				{
					FileLog.Log("renxinghuanghuang", currentObjLife.GetHeroName() + " 动作 " + "暴死");

					if (currentObjLife.ExistsPermanentBuff(ObjBuffType.濒死))
					{
						currentObjLife.SetHp(0);
						currentObjLife.AddPermanentBuff(new ObjPermanentBuff(ObjBuffType.死亡抗性, ValueType.系数, -100, BuffSourceType.生命));
						AddRoleToDeathDecideList(currentObjLife);
					}
					else
					{
						currentObjLife.SetHp(0);
						AddRoleToDeathDecideList(currentObjLife);
					}

					DelayAction(ROLE_ACTION_TIME, FindSpeedMaxFromActionList);
				}
				break;
			case 7: //泄气
				{
					FileLog.Log("renxinghuanghuang", currentObjLife.GetHeroName() + " 动作 " + "泄气");

					currentObjLife.UpdateMorale(UnityEngine.Random.Range(-5, -11), "泄气-本人");

					List<ObjLife> candidates = new List<ObjLife>();
					List<ObjLife> objLifes = herosTeam.GetObjLifes();
					foreach (var obj in objLifes)
					{
						if (obj != currentObjLife && obj.GetHp() > 0)
						//if (obj.GetHp() > 0)
						{
							candidates.Add(obj);
						}
					}

					if (candidates.Count > 0)
					{
						var target = candidates[UnityEngine.Random.Range(0, candidates.Count)];
						target.UpdateMorale(UnityEngine.Random.Range(-5, -11), "泄气-队友");
					}

					DelayAction(ROLE_ACTION_TIME, FindSpeedMaxFromActionList);
				}
				break;
			default:
				{
					FileLog.Log("renxinghuanghuang", currentObjLife.GetHeroName() + " 动作 " + "无");

					DelayAction(ROLE_ACTION_TIME, FindSpeedMaxFromActionList);
				}
				break;

		}
	}
	
	#endregion

	#region 角色死亡处理

	/// <summary>
	/// 附加濒死buff或者判定是否抵抗死亡
	/// </summary>
	protected void onHeroDeathDecideWithBuff(int i)
	{
		if (!DeathDecideList[i].ExistsPermanentBuff(BuffSourceType.生命))
		{
			NewbieGuideMag.Instance.triggerGuide(GuideDataSet.guideEnum.NearDeath);
			if (DeathDecideList[i].ExistsPermanentBuff(ObjBuffType.角色濒死时恢复生命值) && DyingOfLifeTakeCount == 0)
			{
				DyingOfLifeTakeCount += 1;
				List<ObjPermanentBuff> buffs = DeathDecideList[i].GetObjLifeData().FindPermanentBuff(ObjBuffType.角色濒死时恢复生命值);
				ObjPermanentBuff buffTemp = buffs.Count > 0 ? buffs[0] : null;

				DeathDecideList[i].UpdateHp(Mathf.RoundToInt(DeathDecideList[i].GetMaxHpExceptBuff() * (buffTemp != null ? (buffTemp.buffValue / 100f) : 1)));
			}

			if (DeathDecideList[i].GetHp() <= 0)
			{
				DeathDecideList[i].AddPermanentBuff(new ObjPermanentBuff(ObjBuffType.濒死, ValueType.加减, 0, BuffSourceType.生命));
				DeathDecideList[i].AddPermanentBuff(new ObjPermanentBuff(ObjBuffType.中毒抗性, ValueType.系数, -30, BuffSourceType.生命));
				DeathDecideList[i].AddPermanentBuff(new ObjPermanentBuff(ObjBuffType.位移抗性, ValueType.系数, -30, BuffSourceType.生命));
				DeathDecideList[i].AddPermanentBuff(new ObjPermanentBuff(ObjBuffType.减益抗性, ValueType.系数, -30, BuffSourceType.生命));
				DeathDecideList[i].AddPermanentBuff(new ObjPermanentBuff(ObjBuffType.死亡抗性, ValueType.系数, -30, BuffSourceType.生命));
				DeathDecideList[i].AddPermanentBuff(new ObjPermanentBuff(ObjBuffType.流血抗性, ValueType.系数, -30, BuffSourceType.生命));
				DeathDecideList[i].AddPermanentBuff(new ObjPermanentBuff(ObjBuffType.眩晕抗性, ValueType.系数, -30, BuffSourceType.生命));
				DeathDecideList[i].AddPermanentBuff(new ObjPermanentBuff(ObjBuffType.持续回复士气, ValueType.加减, -3, BuffSourceType.生命));
			}
			AudioManager.Instance.PlayAudio(AudioName.Default_Dying_mono, AudioType.BattleCommon);
			DeathDecideList[i].On_neardeath();
			DeathDecideList.RemoveAt(i);

		}
		else
		{
			if (UnityEngine.Random.Range(0, 101) <= DeathDecideList[i].GetDeath())
			{
				DeathDecideList.RemoveAt(i);
			}
		}
	}

	#endregion

	#region 角色技能

	protected void initFightingCalculatingHeroData(ObjLife currUser, SkillData currSkill,ref ObjLife target)
	{
	
		if (currUser.GetVocation() == HeroVocation.亡命赌徒)
		{
			switch (currSkill.id)
			{
				case 1071:
				case 1072:

				case 1073://如果是赌徒技能或者毒品技能，把头元素的变成1
					currUser.dutuskill_stack.Pop();
					currUser.dutuskill_stack.Push(1);
					break;

				case 1074:
				case 1075:
				case 1076:

					currUser.dupinskill_stack.Pop();
					currUser.dupinskill_stack.Push(1);

					break;

				case 1077:

					currUser.dupinskill_stack.Pop();
					currUser.dutuskill_stack.Pop();

					List<int> dututemp = new List<int>();
					List<int> dupintemp = new List<int>();

					dututemp.Add(currUser.dutuskill_stack.Pop());
					dututemp.Add(currUser.dutuskill_stack.Pop());
					dututemp.Add(currUser.dutuskill_stack.Pop());
					dupintemp.Add(currUser.dupinskill_stack.Pop());
					dupintemp.Add(currUser.dupinskill_stack.Pop());
					dupintemp.Add(currUser.dupinskill_stack.Pop());



					jiedutu = dututemp.All(s => s == 0);
					jiedupin = dupintemp.All(s => s == 0);

					for (int i = 2; i >= 0; i--)
					{
						currUser.dutuskill_stack.Push(dututemp[i]);
						currUser.dupinskill_stack.Push(dupintemp[i]);
					}

					currUser.dutuskill_stack.Push(1);
					currUser.dupinskill_stack.Push(1);
					break;


				default:
					currUser.DutuSkill++;
					currUser.DupinSkill++;
					break;
			}
			//使用的毒品类技能 和 赌类技能

			if (currSkill.id != 1077)
			{


				DebugLog.Instance.AddLog(roll.ToString() + "\n");
				SkillData tempSkill = currSkill;

				isSkipRound = DutuGetSkillData(ref tempSkill, roll, ref target);
				currSkill = tempSkill;
				if (isSkipRound)//跳过回合
				{
					IsResponsePanel = false;
					IsResponseRole = false;
					roleInfoView.CloseAllSelected();
					FindSpeedMaxFromActionList();
					return;
				}
			}
		}
		//if (currSkill.id == 1067)//邪恶发明家 - 增强实验
		//{
		//    currSkill = GetSkillData1067(currSkill.Clone());
		//}

		if (currSkill.id == 1062 && currSkill.skillBuffs.Count > 0)//邪恶发明家 - 粗制炸弹
		{
			currSkill.skillBuffs[0] = GetBuffData1062(currSkill.skillBuffs[0].Clone());
		}

		if (currSkill.id == 1086)//奴隶商人-强买强卖
		{
			DataManager.Instance.modeData.moneyMode.count -= 100;
		}
	}

	/// <summary>
	/// 动态获取赌徒技能
	/// </summary>
	/// <param name="skill">技能数据</param>
	/// <param name="roll">点数</param>
	/// <param name="target">目标</param>
	/// <returns>是否跳过回合</returns>
	List<SkillBuff> DutuSkill1074 = new List<SkillBuff>();
	List<TailValue> DutuTrailBuff1074 = new List<TailValue>();
	bool isFirstEntry = true;
	private bool DutuGetSkillData(ref SkillData skill, int roll, ref ObjLife target)
	{
		Debug.Log("-------------------------------" + roll + "roll的点数-------------------------");
		logTarget.AppendLine($"========================赌徒roll的点数为（{roll})================================");

		int skillLevel = currentObjLife.GetSkillLevel(skill);
		switch (skill.id)
		{
			case 1071:
				#region 1071
				canBeSelected.Clear();
				List<ObjLife> TARGETS = new List<ObjLife>();
				switch (roll)
				{
					case 1:

						if (!currentObjLife.HaveSkillCorrent())
						{
							currentObjLife.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.精准, ValueType.加减, BattleCalculating.AnalysisLevel(skill.rate ?? new IntLevel(), skillLevel)));
							currentObjLife.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.暴击, ValueType.加减, BattleCalculating.AnalysisLevel(skill.crits ?? new IntLevel(), skillLevel)));
							currentObjLife.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.暴击伤害, ValueType.加减, BattleCalculating.AnalysisLevel(skill.critsDamage ?? new IntLevel(), skillLevel)));
							currentObjLife.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.伤害, ValueType.系数, BattleCalculating.AnalysisLevel(skill.atk ?? new IntLevel(), skillLevel) - 70));
						}

						skill.skillType = SkillType.远程伤害;
						skill.targetType = SkillTargetType.敌方单体;
						canBeSelected.Add(target);
						currentObjLife.UpdateMorale(-6, "赌徒技能 " + skill.id + " " + roll);
						break;
					case 2:

						if (!currentObjLife.HaveSkillCorrent())
						{
							currentObjLife.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.精准, ValueType.加减, BattleCalculating.AnalysisLevel(skill.rate ?? new IntLevel(), skillLevel)));
							currentObjLife.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.暴击, ValueType.加减, BattleCalculating.AnalysisLevel(skill.crits ?? new IntLevel(), skillLevel)));
							currentObjLife.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.暴击伤害, ValueType.加减, BattleCalculating.AnalysisLevel(skill.critsDamage ?? new IntLevel(), skillLevel)));
							currentObjLife.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.伤害, ValueType.系数, BattleCalculating.AnalysisLevel(skill.atk ?? new IntLevel(), skillLevel) - 30));
						}

						skill.skillType = SkillType.远程伤害;
						skill.targetType = SkillTargetType.敌方单体;
						canBeSelected.Add(target);

						break;
					case 3:

					case 4:

						if (enemyTeam.GetCount() < roll)
						{
							return true;
						}
						else
						{
							if (!currentObjLife.HaveSkillCorrent())
							{
								currentObjLife.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.精准, ValueType.加减, BattleCalculating.AnalysisLevel(skill.rate ?? new IntLevel(), skillLevel)));
								currentObjLife.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.暴击, ValueType.加减, BattleCalculating.AnalysisLevel(skill.crits ?? new IntLevel(), skillLevel)));
								currentObjLife.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.暴击伤害, ValueType.加减, BattleCalculating.AnalysisLevel(skill.critsDamage ?? new IntLevel(), skillLevel)));
								currentObjLife.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.伤害, ValueType.系数, BattleCalculating.AnalysisLevel(skill.atk ?? new IntLevel(), skillLevel)));
							}
							skill.skillType = SkillType.远程伤害;
							skill.targetType = SkillTargetType.敌方单体;
							target = enemyTeam.GetObjLife(roll - 1);
							canBeSelected.Add(target);
						}
						break;

					case 5:

						if (!currentObjLife.HaveSkillCorrent())
						{
							currentObjLife.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.精准, ValueType.加减, BattleCalculating.AnalysisLevel(skill.rate ?? new IntLevel(), skillLevel)));
							currentObjLife.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.暴击, ValueType.加减, BattleCalculating.AnalysisLevel(skill.crits ?? new IntLevel(), skillLevel)));
							currentObjLife.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.暴击伤害, ValueType.加减, BattleCalculating.AnalysisLevel(skill.critsDamage ?? new IntLevel(), skillLevel)));
							currentObjLife.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.伤害, ValueType.系数, BattleCalculating.AnalysisLevel(skill.atk ?? new IntLevel(), skillLevel) - 30));
						}
						skill.skillType = SkillType.远程伤害;
						skill.targetType = SkillTargetType.敌方群体;
						canBeSelected.Add(target);
						List<ObjLife> MonsterElse = MonsterListExeptSelf(target);
						if (MonsterElse.Count > 0) canBeSelected.Add(MonsterElse[UnityEngine.Random.Range(0, MonsterElse.Count())]);
						break;

					case 6:

						if (!currentObjLife.HaveSkillCorrent())
						{
							currentObjLife.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.精准, ValueType.加减, BattleCalculating.AnalysisLevel(skill.rate ?? new IntLevel(), skillLevel)));
							currentObjLife.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.暴击, ValueType.加减, BattleCalculating.AnalysisLevel(skill.crits ?? new IntLevel(), skillLevel)));
							currentObjLife.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.暴击伤害, ValueType.加减, BattleCalculating.AnalysisLevel(skill.critsDamage ?? new IntLevel(), skillLevel)));
							currentObjLife.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.伤害, ValueType.系数, BattleCalculating.AnalysisLevel(skill.atk ?? new IntLevel(), skillLevel) - 30));
						}
						skill.skillType = SkillType.远程伤害;
						skill.targetType = SkillTargetType.敌方群体;
						target = enemyTeam.GetObjLife(0);
						foreach (var item in enemyTeam.GetObjLifes())
						{
							canBeSelected.Add(item);
						}

						break;
				}
				AddDuanjieSkillBuff(currentObjLife, canBeSelected, GamblerSkillType.戒赌);
				break;
			#endregion
			case 1072:

				#region 1072
				canBeSelected.Clear();
				switch (roll)
				{
					case 1:
						if (!currentObjLife.HaveSkillCorrent())
						{
							currentObjLife.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.精准, ValueType.加减, BattleCalculating.AnalysisLevel(skill.rate ?? new IntLevel(), skillLevel)));
							currentObjLife.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.暴击, ValueType.加减, BattleCalculating.AnalysisLevel(skill.crits ?? new IntLevel(), skillLevel)));
							currentObjLife.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.暴击伤害, ValueType.加减, BattleCalculating.AnalysisLevel(skill.critsDamage ?? new IntLevel(), skillLevel)));
							currentObjLife.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.伤害, ValueType.系数, BattleCalculating.AnalysisLevel(skill.atk ?? new IntLevel(), skillLevel) - 50));
						}

						skill.skillType = SkillType.远程伤害;
						skill.targetType = SkillTargetType.敌方单体;
						canBeSelected.Add(target);
						currentObjLife.UpdateMorale(-6, "赌徒技能 " + skill.id + " " + roll);
						logBuff.AppendLine(currentObjLife + "roll点数1：士气下降 -6");
						skill.skillBuffs[0].effectiveRounds = 1;
						skill.skillBuffs[0].rate.level1 = 100;
						break;
					case 2:
						if (!currentObjLife.HaveSkillCorrent())
						{
							currentObjLife.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.精准, ValueType.加减, BattleCalculating.AnalysisLevel(skill.rate ?? new IntLevel(), skillLevel)));
							currentObjLife.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.暴击, ValueType.加减, BattleCalculating.AnalysisLevel(skill.crits ?? new IntLevel(), skillLevel)));
							currentObjLife.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.暴击伤害, ValueType.加减, BattleCalculating.AnalysisLevel(skill.critsDamage ?? new IntLevel(), skillLevel)));
							currentObjLife.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.伤害, ValueType.系数, BattleCalculating.AnalysisLevel(skill.atk ?? new IntLevel(), skillLevel) - 50));
						}

						skill.skillType = SkillType.远程伤害;
						skill.targetType = SkillTargetType.敌方单体;
						canBeSelected.Add(target);
						skill.skillBuffs[0].effectiveRounds = 1;
						skill.skillBuffs[0].rate.level1 = 100;

						break;
					case 3:
					case 4:
						if (!currentObjLife.HaveSkillCorrent())
						{
							currentObjLife.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.精准, ValueType.加减, BattleCalculating.AnalysisLevel(skill.rate ?? new IntLevel(), skillLevel)));
							currentObjLife.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.暴击, ValueType.加减, BattleCalculating.AnalysisLevel(skill.crits ?? new IntLevel(), skillLevel)));
							currentObjLife.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.暴击伤害, ValueType.加减, BattleCalculating.AnalysisLevel(skill.critsDamage ?? new IntLevel(), skillLevel)));
							currentObjLife.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.伤害, ValueType.系数, BattleCalculating.AnalysisLevel(skill.atk ?? new IntLevel(), skillLevel)));
						}
						skill.skillType = SkillType.远程伤害;
						skill.targetType = SkillTargetType.敌方单体;
						canBeSelected.Add(target);
						skill.skillBuffs[0].effectiveRounds = 1;
						skill.skillBuffs[0].rate.level1 = 100;

						break;
					case 5:
						if (!currentObjLife.HaveSkillCorrent())
						{
							currentObjLife.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.精准, ValueType.加减, BattleCalculating.AnalysisLevel(skill.rate ?? new IntLevel(), skillLevel)));
							currentObjLife.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.暴击, ValueType.加减, BattleCalculating.AnalysisLevel(skill.crits ?? new IntLevel(), skillLevel)));
							currentObjLife.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.暴击伤害, ValueType.加减, BattleCalculating.AnalysisLevel(skill.critsDamage ?? new IntLevel(), skillLevel)));
							currentObjLife.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.伤害, ValueType.系数, BattleCalculating.AnalysisLevel(skill.atk ?? new IntLevel(), skillLevel)));
						}
						skill.skillType = SkillType.远程伤害;
						skill.targetType = SkillTargetType.敌方群体;
						canBeSelected.Add(target);
						List<ObjLife> MonsterElse = MonsterListExeptSelf(target);
						if (MonsterElse.Count > 0) canBeSelected.Add(MonsterElse[UnityEngine.Random.Range(0, MonsterElse.Count())]);
						skill.skillBuffs[0].effectiveRounds = 1;
						skill.skillBuffs[0].rate.level1 = 100;
						break;
					case 6:
						if (!currentObjLife.HaveSkillCorrent())
						{
							currentObjLife.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.精准, ValueType.加减, BattleCalculating.AnalysisLevel(skill.rate ?? new IntLevel(), skillLevel)));
							currentObjLife.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.暴击, ValueType.加减, BattleCalculating.AnalysisLevel(skill.crits ?? new IntLevel(), skillLevel)));
							currentObjLife.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.暴击伤害, ValueType.加减, BattleCalculating.AnalysisLevel(skill.critsDamage ?? new IntLevel(), skillLevel)));
							currentObjLife.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.伤害, ValueType.系数, BattleCalculating.AnalysisLevel(skill.atk ?? new IntLevel(), skillLevel) + 30));
						}
						skill.skillType = SkillType.远程伤害;
						skill.targetType = SkillTargetType.敌方群体;
						canBeSelected.Add(target);
						skill.skillBuffs[0].effectiveRounds = 2;
						skill.skillBuffs[0].rate.level1 = 125;
						break;
				}


				AddDuanjieSkillBuff(currentObjLife, canBeSelected, GamblerSkillType.戒赌);
				break;

			#endregion
			case 1074:

				AddDuanjieSkillBuff(currentObjLife, new List<ObjLife>() { target }, GamblerSkillType.戒毒);
				break;
			case 1075:
				if (isFirstEntry)
				{
					//1 buff0
					//2 buff1
					//3 tail0
					//4 buff 2,3
					//5 tail 1buff4
					//6 roll3+roll4+buff5



					TailValue[] temp = new TailValue[skill.skillTails.Count];
					skill.skillTails.CopyTo(temp);
					DutuTrailBuff1074 = temp.ToList();

					SkillBuff[] bufftemp = new SkillBuff[skill.skillBuffs.Count];
					skill.skillBuffs.CopyTo(bufftemp);
					DutuSkill1074 = bufftemp.ToList();
					skill.skillBuffs.Clear();//清除技能所有buff
					skill.skillTails.Clear();

					isFirstEntry = false;

				}


				switch (roll)
				{
					case 1:

						skill.skillBuffs.Add(DutuSkill1074[0]);
						break;
					case 2:

						skill.skillBuffs.Add(DutuSkill1074[1]);
						break;
					case 3:

						skill.skillTails.Add(DutuTrailBuff1074[0]);
						break;
					case 4:

						skill.skillBuffs.Add(DutuSkill1074[2]);
						skill.skillBuffs.Add(DutuSkill1074[3]);
						break;
					case 5:

						skill.skillTails.Add(DutuTrailBuff1074[1]);
						skill.skillBuffs.Add(DutuSkill1074[4]);
						break;
					case 6:

						skill.skillBuffs.Add(DutuSkill1074[2]);
						skill.skillBuffs.Add(DutuSkill1074[3]);
						skill.skillTails.Add(DutuTrailBuff1074[1]);
						skill.skillBuffs.Add(DutuSkill1074[4]);
						skill.skillBuffs.Add(DutuSkill1074[5]);
						break;
				}
				AddDuanjieSkillBuff(currentObjLife, new List<ObjLife>() { target }, GamblerSkillType.戒毒);
				break;
			case 1076:

				AddDuanjieSkillBuff(currentObjLife, new List<ObjLife>() { target }, GamblerSkillType.戒毒);
				break;
			case 1077:

			case 1073:

				switch (roll)
				{
					case 1:
						if (!currentObjLife.HaveSkillCorrent())
						{
							currentObjLife.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.精准, ValueType.加减, BattleCalculating.AnalysisLevel(skill.rate ?? new IntLevel(), skillLevel)));
							currentObjLife.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.暴击, ValueType.加减, BattleCalculating.AnalysisLevel(skill.crits ?? new IntLevel(), skillLevel)));
							currentObjLife.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.暴击伤害, ValueType.加减, BattleCalculating.AnalysisLevel(skill.critsDamage ?? new IntLevel(), skillLevel)));
							currentObjLife.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.伤害, ValueType.系数, BattleCalculating.AnalysisLevel(skill.atk ?? new IntLevel(), skillLevel) - 95));
						}
						skill.skillType = SkillType.远程伤害;
						skill.targetType = SkillTargetType.敌方单体;
						canBeSelected.Add(target);
						currentObjLife.UpdateMorale(-3, "赌徒技能 " + skill.id + " " + roll);
						logBuff.AppendLine(currentObjLife + "roll点数1：士气下降 -3");
						break;
					case 2:
					case 3:
						if (!currentObjLife.HaveSkillCorrent())
						{
							currentObjLife.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.精准, ValueType.加减, BattleCalculating.AnalysisLevel(skill.rate ?? new IntLevel(), skillLevel)));
							currentObjLife.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.暴击, ValueType.加减, BattleCalculating.AnalysisLevel(skill.crits ?? new IntLevel(), skillLevel)));
							currentObjLife.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.暴击伤害, ValueType.加减, BattleCalculating.AnalysisLevel(skill.critsDamage ?? new IntLevel(), skillLevel)));
							currentObjLife.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.伤害, ValueType.系数, BattleCalculating.AnalysisLevel(skill.atk ?? new IntLevel(), skillLevel) - 50));
						}
						skill.skillType = SkillType.远程伤害;
						skill.targetType = SkillTargetType.敌方单体;
						canBeSelected.Add(target);
						break;
					case 4:
					case 5:
						if (!currentObjLife.HaveSkillCorrent())
						{
							currentObjLife.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.精准, ValueType.加减, BattleCalculating.AnalysisLevel(skill.rate ?? new IntLevel(), skillLevel)));
							currentObjLife.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.暴击, ValueType.加减, BattleCalculating.AnalysisLevel(skill.crits ?? new IntLevel(), skillLevel)));
							currentObjLife.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.暴击伤害, ValueType.加减, BattleCalculating.AnalysisLevel(skill.critsDamage ?? new IntLevel(), skillLevel)));
							currentObjLife.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.伤害, ValueType.系数, BattleCalculating.AnalysisLevel(skill.atk ?? new IntLevel(), skillLevel) + 50));
						}
						skill.skillType = SkillType.远程伤害;
						skill.targetType = SkillTargetType.敌方单体;
						canBeSelected.Add(target);
						break;
					case 6:
						if (!currentObjLife.HaveSkillCorrent())
						{
							currentObjLife.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.精准, ValueType.加减, BattleCalculating.AnalysisLevel(skill.rate ?? new IntLevel(), skillLevel)));
							currentObjLife.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.暴击, ValueType.加减, BattleCalculating.AnalysisLevel(skill.crits ?? new IntLevel(), skillLevel)));
							currentObjLife.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.暴击伤害, ValueType.加减, BattleCalculating.AnalysisLevel(skill.critsDamage ?? new IntLevel(), skillLevel)));
							currentObjLife.AddSkillCorrect(new ObjSkillCorrect(ObjBuffType.伤害, ValueType.系数, BattleCalculating.AnalysisLevel(skill.atk ?? new IntLevel(), skillLevel) + 100));
						}
						skill.skillType = SkillType.远程伤害;
						skill.targetType = SkillTargetType.敌方单体;
						canBeSelected.Add(target);
						currentObjLife.UpdateMorale(+3, "赌徒技能 " + skill.id + " " + roll);
						logBuff.AppendLine(currentObjLife + "roll点数6：士气下降 +3");
						break;

				}

				AddDuanjieSkillBuff(currentObjLife, canBeSelected, GamblerSkillType.戒赌);
				break;
			default:
				Debug.Log("技能id错误");
				break;
		}

		return false;
	}



	#endregion
}

