#define Cinemachine
//#define CameraScheme1
//#define CameraScheme2
using Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


/// <summary>
/// 英雄跟怪物通用预处理
/// </summary>
public class BattleFlowRoleController : BattleFlowUIController
{

	#region 英雄跟怪物通用预处理通用参数
	/// <summary>
	/// 怪物技能显示时间
	/// </summary>
	protected float ANI_SKILL_SHOW_TIME = 2f;
	/// <summary>
	/// 战斗攻击动画时间
	/// </summary>
	protected float ANI_FIGHTING_TIME = 1.1f * nTimeScale;
	/// <summary>
	/// 结束动画时间
	/// </summary>
	protected float ANI_END_TIME = 0.35f * nTimeScale;
	/// <summary>
	/// 战斗准备动画时间
	/// </summary>
	protected float ANI_START_TIME = 0.2f * nTimeScale;
	/// <summary>
	/// 死亡裁定时间
	/// </summary>
	protected float DEATH_DECIDE_TIME = 1.5f;

	/// <summary>
	/// 
	/// </summary>
	public float ROLE_ACTION_TIME = 0.5f * nTimeScale;

	/// <summary>
	/// 技能注语动画时间 
	/// </summary>
	private float ANI_SKILL_NOTE_TIME = 0.5f * nTimeScale;
	/// <summary>
	/// 交换动画时间 
	/// </summary>
	private float ANI_EXCHANGE_TIME = 0.5f;

	private float offDistance = 2.5f;

	#endregion

	protected override void InitData()
	{
		base.InitData();
		onJumpRoundAct = doJumpRoundAct;
		onRoleBeSelected = RoleBeSelected;
	}

	#region 角色初始化
	protected RoleType roleType;

	/// <summary>
	/// 初始化完成标记
	/// </summary>
	public bool[] insFinish = new bool[4] { false, false, false, false };
	/// <summary>
	/// 召唤完成标记
	/// </summary>
	public bool[] summonFinish = new bool[4] { false, false, false, false };

	/// <summary>
	/// 实例化角色
	/// </summary>
	/// <param name="objLifeDatas"></param>
	/// <param name="roleType"></param>
	protected void InitRole(List<ObjLifeData> objLifeDatas, RoleType roleType)
	{
		Debug.Log($"测试-InitRole-{roleType}");
		this.roleType = roleType;

		for (int i = 0; i < insFinish.Length; ++i)
		{
			insFinish[i] = true;
		}

		if (roleType.Equals(RoleType.英雄))
		{
			DyingOfLifeTakeCount = 0;
			maxCount = objLifeDatas.Count;
			for (int i = 0; i < objLifeDatas.Count; ++i)
			{
				if (BattleInfo.sacredCombination != null)
				{
					Debug.Log("测试-添加圣物组合效果");
					foreach (var buff in BattleInfo.sacredCombination.objActions)
					{
						objLifeDatas[i].AddPermanentBuff(new ObjPermanentBuff(buff, BuffSourceType.圣物));
					}
				}

				insFinish[i] = false;
				InitImpl(objLifeDatas[i], i);// objLifeDatas[i].GetNumInTeamWaiting());
			}
		}
		else
		{
			for (int i = 0, j = 0; i < objLifeDatas.Count; ++i, ++j)
			{
				insFinish[j] = false;
				InitImpl(objLifeDatas[i], j);

				if (objLifeDatas[i].GetSize() == 2)
				{
					++j;
				}
			}
		}
	}

	private bool isRoleInitOver;

	public bool IsRoleInitOver
	{
		get { return initCount >= maxCount; }
	}
	private int maxCount;
	private int initCount;

	/// <summary>
	/// 实例化角色的实现
	/// </summary>
	/// <param name="objLifeData"></param>
	/// <param name="index"></param>
	/// <param name="isSummon">是否有召唤</param>
	/// <param name="direction">召唤的方向 默认在后方</param>
	public void InitImpl(ObjLifeData objLifeData, int index, bool isSummon = false, bool direction = false)
	{
		Debug.Log($"测试-InitImpl-{objLifeData.GetHeroName()}");
		Team team = objLifeData.GetRoleType() == RoleType.英雄 ? herosTeam : monsterTeam;
		Vector3 pos = RolePosCalculate(team, index, objLifeData.GetSize()) + new Vector3(transform.position.x, 0.7f, 0f);
		objLifeData.GetRoleModel().InstantiateAsync(pos, Quaternion.identity, transform).Completed += go =>
		{
			ObjLife objLife = go.Result.GetComponent<ObjLife>();
			objLife.InitRole(objLifeData);
			objLife.SetHp(objLife.GetMaxHp()); //应当放到任务结算处

			AIBase ai = go.Result.GetComponent<AIBase>();
			if (ai != null)
			{
				ai.InitRole();
			}

			if (isSummon)
			{
				team.Add(objLife, direction, index);
				summonFinish[index] = true;
				objLife.CurrentActNum = objLife.GetActNum();
				actionList.Add(objLife);
			}
			else
			{
				team.Add(index, objLife);
				insFinish[index] = true;
			}

			if (objLife.GetSize() == 2)
			{
				go.Result.transform.localScale = Vector3.one;
			}

			if (objLifeData.GetRoleType() == RoleType.怪物)
			{
				UIEventManager.AddTriggersListener(go.Result).onEnter = s =>
				{
					ObjLife obj = s.GetComponent<ObjLife>();
					if (obj != null) ShowEnemyInfoPanel(obj);
				};
				UIEventManager.AddTriggersListener(go.Result).onExit = s =>
				{
					ObjLife obj = s.GetComponent<ObjLife>();
					if (obj != null) CloseEnemyInfoPanel(obj);
				};
			}
			else
			{
				initCount++;
			}
		};
	}

	#endregion

	#region 角色的选择
	protected int roll;
	protected int roll_test = 0;
	/// <summary>
	/// 角色点击事件处理
	/// </summary>
	/// <param name="targetObjLife"></param>
	public void RoleBeSelected(ObjLife targetObjLife)
	{
		//如果目前不可响应，忽略点击
		if (!IsResponseRole)
		{
			return;
		}

		//非战斗状态下-没有激活换位按钮，则是选中角色
		if (!IsBattling && !isExchange)
		{
			SelectRole(targetObjLife);
			return;
		}

		//如果不是选中角色，那必须点一个可选中目标才做响应
		if (!canBeSelected.Contains(targetObjLife))
		{
			return;
		}
		Debug.Log("测试-RoleBeSelected-英雄技能开始释放");
		/// isAttacking = true;
		IsResponsePanel = false;
		IsResponseRole = false;
		CloseAllObjTargetTips();
		roleInfoView.CloseAllSelected();

		if (currentObjLife.ExistsPermanentBuff(BuffSourceType.负向士气) && UnityEngine.Random.Range(0f, 1f) < 0.5f)
		{
			DelayAction(ROLE_ACTION_TIME, FindSpeedMaxFromActionList);// Invoke("FindSpeedMaxFromActionList", ROLE_ACTION_TIME);
			return;
		}

		if (isMimang && UnityEngine.Random.Range(0f, 1f) > 0.5f)
		{
			currentObjLife.UpdateMorale(-5, "迷茫");
			DelayAction(ROLE_ACTION_TIME, FindSpeedMaxFromActionList);//  Invoke("FindSpeedMaxFromActionList", ROLE_ACTION_TIME);
		}
		else
		{
			if (isExchange)
			{
				isExchange = false;
				ExchangeMoveFromButton(targetObjLife);
				RefreshBattleActNumInfo();
				DelayAction(ROLE_MOVE_TIME, SetResponseTrue);//     Invoke("SetResponseTrue", ROLE_MOVE_TIME);
			}
			else
			{
				roll = roll_test == 0 ? UnityEngine.Random.Range(1, 7) : roll_test;
				//roll = UnityEngine.Random.Range(1, 7);
				//roll = 6;
				FightingCalculating(targetObjLife);
			}
		}
	}

	/// <summary>
	/// 换位按钮导致的角色换位
	/// </summary>
	/// <param name="objLife"></param>
	public void ExchangeMoveFromButton(ObjLife objLife)
	{
		AudioManager.Instance.PlayAudio(AudioName.FOOTSTEP_Trainers_Asphalt_Run_RR8_mono, AudioType.BattleCommon);
		GetTeamFromRole(objLife).Exchange(currentObjLife, objLife);
		MoveAni(currentObjLife, RolePosCalculate(currentObjLife));
		MoveAni(objLife, RolePosCalculate(objLife));
		DelayAction(ROLE_MOVE_TIME, DeathDecide);//  Invoke("DeathDecide", ROLE_MOVE_TIME);
	}

	protected void SetResponseTrue()
	{
		IsResponsePanel = true;
		IsResponseRole = true;
	}

	/// <summary>
	/// 选中一个角色
	/// </summary>
	/// <param name="objLife"></param>
	/// <param name="isBuffTakeEffect">BUFF 是否生效</param>
	protected void SelectRole(ObjLife objLife, bool isBuffTakeEffect = true)
	{
		Debug.Log($"测试-SelectRole-{objLife.GetHeroName()}");
		if (currentObjLife != null)
		{
			currentObjLife.CloseSelectionTips();
		}
		objLife.ShowSeletionTips();
		currentObjLife = objLife;
		currentTeam = GetTeamFromRole(objLife);
		enemyTeam = currentTeam == herosTeam ? monsterTeam : herosTeam;

		if (IsBattling)
		{
			SelectRoleInBattle(objLife, isBuffTakeEffect);
		}
		else
		{
			SelectRoleNotInBattle(objLife);
		}
	}


	/// <summary>
	/// 选中英雄的时候
	/// </summary>
	/// <param name="objLife"></param>
	protected Action<ObjLife> onSelectHeroRoleAct;
	/// <summary>
	/// 选中英雄后，英雄自动执行的行为
	/// </summary>
	protected Action onSelectHeroAutoExcuteAct;
	/// <summary>
	/// 选中怪物后，怪物自动执行的行为
	/// </summary>
	protected Action onSelectEnemyAutoExcuteAct;

	protected int heroAiActionIndex;
	/// <summary>
	/// 是否是"迷茫" BUFF
	/// </summary>
	protected bool isMimang;
	/// <summary>
	/// 选中一个角色（战斗中）
	/// </summary>
	/// <param name="objLife"></param>
	/// <param name="isBuffTakeEffect">BUFF 是否生效</param>
	private void SelectRoleInBattle(ObjLife objLife, bool isBuffTakeEffect)
	{
		Debug.Log($"测试-SelectRoleInBattle-{objLife.GetHeroName()}-开始攻击");

		objLife.CurrentActNum--;
		onSelectHeroRoleAct?.Invoke(objLife);
		//处理有跳过效果的BUFF
		bool isSkip = objLife.ExistsSkillBuff(ObjBuffType.眩晕) || objLife.ExistsSkillBuff(ObjBuffType.包裹);
		isMimang = objLife.ExistsSkillBuff(ObjBuffType.迷茫);
		if (isBuffTakeEffect)
		{
			objLife.BuffTakeEffect();
		}

		if (objLife.GetHp() == 0)
		{
			if (DeathDecide(false))
			{
				return;
			}
		}

		if (isSkip)
		{
			Debug.Log($"测试-SelectRoleInBattle-{objLife.GetHeroName()}-跳过回合");
			RefreshBattleActNumInfo();
			DelayAction(ROLE_ACTION_TIME, FindSpeedMaxFromActionList);//  Invoke("FindSpeedMaxFromActionList", ROLE_ACTION_TIME);
		}
		else
		{
			if (objLife.ExistsPermanentBuff(BuffSourceType.负向士气))
			{

				int heroAiActionIndex = GetHeroAiUseSkillActionIndex();
				if (heroAiActionIndex > 0)
				{
					this.heroAiActionIndex = heroAiActionIndex;
					DelayAction(ROLE_ACTION_TIME, onSelectHeroAutoExcuteAct);//Invoke("HeroAiUseSkill", ROLE_ACTION_TIME);
					return;
				}
			}

			currentSkill = null;
			canBeSelected.Clear();
			UpdateOrnamentTakeEffect(objLife);
			UpdateSacredTakeEffect(objLife);
			if (objLife.GetRoleType() == RoleType.英雄)
			{
				Debug.Log("测试-SelectRoleInBattle-英雄");
				ResetPanelInBattle(objLife);
				IsResponsePanel = true;
			}
			else
			{
				DelayAction(ROLE_ACTION_TIME, onSelectEnemyAutoExcuteAct);// Invoke("AIUseSkill", ROLE_ACTION_TIME);
			}

		}
	}

	/// <summary>
	/// 某个角色行动结束时调用
	/// </summary>
	public void onSelectRoleInBattleActOver(ObjLife objLife, bool isNewRound)
	{
		int round = isNewRound ? GetRoundNum() - 1 : GetRoundNum();
		if (objLife != null && objLife.UpdateRoundEndAct(round))
		{
			Debug.LogError("Round:" + round + objLife.name);
			objLife.HandleWaitHandleBuff();
		}
	}

	/// <summary>
	/// 选中一个角色（非战斗中）
	/// </summary>
	/// <param name="objLife"></param>
	private void SelectRoleNotInBattle(ObjLife objLife)
	{
		Debug.Log($"测试-SelectRoleNotInBattle-{objLife.GetHeroName()}");
		ResetPanelNotInBattle(objLife);
	}
	/// <summary>
	/// 人心惶惶状态时触发
	/// </summary>


	protected int GetHeroAiUseSkillActionIndex()
	{

		int[] 人心惶惶每回合动作触发概率 = new int[] { 25, 2, 5, 2, 5, 5, 0, 5 };

		int roundNum = this.round - currentObjLife.renxinghuanghuangRound;
		人心惶惶每回合动作触发概率[2] += roundNum;
		人心惶惶每回合动作触发概率[4] += roundNum;
		人心惶惶每回合动作触发概率[5] += roundNum;
		人心惶惶每回合动作触发概率[6] += Math.Min(roundNum, 10);
		人心惶惶每回合动作触发概率[7] += roundNum;

		int totalWeight = 0;
		for (int i = 0; i < 人心惶惶每回合动作触发概率.Length; i++)
		{
			totalWeight += 人心惶惶每回合动作触发概率[i];
		}

		int d = UnityEngine.Random.Range(0, totalWeight - 1);
		int s = 0;
		string log = "回合:" + roundNum;
		log += " | 权重:";
		for (int i = 0; i < 人心惶惶每回合动作触发概率.Length; i++)
		{
			s += 人心惶惶每回合动作触发概率[i];
			log += s + ",";
		}
		log += " | 随机值:" + d;


		int foundActionIndex = -1;
		for (int i = 0; i < 人心惶惶每回合动作触发概率.Length; i++)
		{
			if (d < 人心惶惶每回合动作触发概率[i])
			{
				foundActionIndex = i;
				break;
			}

			d -= 人心惶惶每回合动作触发概率[i];
		}


		log += " |  选中的动作值:" + foundActionIndex;

		FileLog.Log("renxinghuanghuang", currentObjLife.GetHeroName() + ": " + log);



		//int roundNum = round >= 人心惶惶每回合动作触发概率.Length ? (人心惶惶每回合动作触发概率.Length - 1) : round;

		//int roll = UnityEngine.Random.Range(0, 100);


		//int foundActionIndex = 0;
		//for (int i = 0; i < 人心惶惶每回合动作触发概率[roundNum].Length; i++)
		//{

		//    if (roll >= 人心惶惶每回合动作触发概率[roundNum][i])
		//    {

		//        roll -= 人心惶惶每回合动作触发概率[roundNum][i];
		//    }
		//    else
		//    {

		//        foundActionIndex = i;
		//        break;
		//    }
		//}



		// foundActionIndex = 0;
		// UnityEngine.Debug.LogError("test GetHeroAiUseSkillActionIndex " + roundNum + "  " + foundActionIndex);

		return foundActionIndex;
	}


	#region 饰品效果动态控制模块
	/// <summary>
	/// 更新饰品效果
	/// </summary>
	/// <param name="objLife"></param>
	protected void UpdateOrnamentTakeEffect(ObjLife objLife)
	{
		objLife.SetBuffIsTakeEffect(ObjLimitType.回合数等于1, round == 1);
	}

	#endregion

	#region 圣物效果处理模块
	/// <summary>
	/// 角色濒死时恢复触发的次数
	/// </summary>
	protected int DyingOfLifeTakeCount;

	protected void UpdateSacredTakeEffect(ObjLife objLife)
	{
		objLife.SetBuffIsTakeEffect(ObjLimitType.每次任务仅生效一次, DyingOfLifeTakeCount == 0);
	}
	#endregion

	#endregion


	#region 游戏逻辑
	/// <summary>
	/// 跳过战斗处理
	/// </summary>
	void doJumpRoundAct()
	{
		NotUseMoralSkill(currentObjLife);
		RefreshBattleActNumInfo();
		FindSpeedMaxFromActionList();
	}

	#region 指定行动角色
	private ObjLife lastObjLife;
	/// <summary>
	/// 是否忽略行动点
	/// </summary>
	protected bool isIgnoreActNum;
	protected Action newRound;
	/// <summary>
	/// 找行动列表中速度最大的角色，将他从行动列表中移除并指定他行动，如果没有列表则会启动新的回合
	/// </summary>
	public void FindSpeedMaxFromActionList()
	{
		FindSpeedMaxFromActionList(false);
	}

	/// <summary>
	/// 找行动列表中速度最大的角色，将他从行动列表中移除并指定他行动，如果没有列表则会启动新的回合
	/// </summary>
	public void FindSpeedMaxFromActionList(bool isNewRound)
	{
		if (!isIgnoreActNum && currentSkill != null && currentSkill.killToActAgain && lastObjLife != null && IsDeath) //击杀可再次行动
		{
			Debug.Log("测试-FindSpeedMaxFromActionList-1");
			SelectRole(lastObjLife, false);
		}
		else if (!isIgnoreActNum && lastObjLife != null && lastObjLife.CurrentActNum > 0) //多行动点
		{
			Debug.Log("测试-FindSpeedMaxFromActionList-2");
			SelectRole(lastObjLife, false);
		}
		else
		{
			if (actionList.Count.Equals(0)) //新回合
			{
				Debug.Log("测试-FindSpeedMaxFromActionList-3");
				isIgnoreActNum = true;
				newRound?.Invoke();
			}
			else
			{
				Debug.Log("测试-FindSpeedMaxFromActionList-4");
				isIgnoreActNum = false;
				int maxSpeed = actionList.Max(s => s.GetSpeed());
				List<ObjLife> objs = actionList.FindAll(s => s.GetSpeed().Equals(maxSpeed));
				ObjLife objLife = objs[UnityEngine.Random.Range(0, objs.Count)];
				if (round == 1)
				{
					foreach (var obj in actionList)
					{
						if (obj.ExistsSpecialEffect(SpecialEffect.首回合优先行动))
						{
							objLife = obj;
						}
					}
				}
				checkRoleInBattleActOver(isNewRound);
				lastObjLife = objLife;
				actionList.Remove(objLife);
				SelectRole(objLife);
			}
		}
	}

	protected void checkRoleInBattleActOver(bool isNewRound)
	{
		if (lastObjLife != null)
		{
			onSelectRoleInBattleActOver(lastObjLife, isNewRound);
		}
	}

	#endregion

	#endregion


	#region 角色死亡处理

	protected bool IsDeath { get; set; } = false;
	protected List<ObjLife> DeathDecideList = new List<ObjLife>();
	protected Action<int> onHeroDeathDecideWithBuffAct;
	protected Func<bool> onEnemyDeathDecideWithSummonAct;
	protected Action<bool> endBattleAct;
	/// <summary>
	/// 死亡判定
	/// </summary>
	public bool DeathDecide(bool isNextRole)
	{
		DeathDecideList = DeathDecideList.Distinct().ToList();
		IsDeath = false;
		Debug.Log("测试-DeathDecide-1");
		//生命值不为0则不需要进行死亡判定
		for (int i = DeathDecideList.Count - 1; i >= 0; --i)
		{
			if (DeathDecideList[i].GetHp() > 0)
			{
				DeathDecideList.RemoveAt(i);
			}
		}
		Debug.Log("测试-DeathDecide-2");
		//附加濒死buff或者判定是否抵抗死亡
		for (int i = DeathDecideList.Count - 1; i >= 0; --i)
		{
			if (DeathDecideList[i].GetRoleType() == RoleType.英雄)
			{
				onHeroDeathDecideWithBuffAct?.Invoke(i);
			}
		}
		Debug.Log("测试-DeathDecide-3");
		//这是真死了，处理后事
		bool IsSummon = false;
		if (DeathDecideList.Count > 0)
		{
			IsDeath = true;

			Team team = GetTeamFromRole(DeathDecideList[0]);
			foreach (var item in DeathDecideList)
			{
				Debug.Log(item);
				ObjLife temp = item;

				ChangeMoralWhenDeath(item);

				DataManager.Instance.RemoveHeroFromMode(temp.GetObjLifeData());
				team.Death(temp);
				actionList.Remove(temp);

				List<ObjPermanentBuff> buff = temp.GetObjLifeData().FindPermanentBuff(ObjBuffType.角色阵亡时其他角色增加伤害);
				if (buff.Count > 0)
				{
					List<ObjLifeData> heros = GetHeros();
					for (int i = 0; i < heros.Count; ++i)
					{
						ObjPermanentBuff tempBuff = new ObjPermanentBuff(ObjBuffType.伤害, buff[0].valueType, buff[0].buffValue, BuffSourceType.角色阵亡时其他角色增加伤害);
						heros[i].AddPermanentBuff(tempBuff);
					}
				}

				DelayAction(DEATH_DECIDE_TIME, () =>
				{
					Debug.Log("----------------Destroy------------");
					temp.isDestroyed = true;
					Destroy(temp.gameObject);
				});
				if (temp.GetRoleData().roleType == RoleType.英雄)
				{
					AudioManager.Instance.PlayAudio(AudioName.MUSIC_EFFECT_Orchestral_Battle_Negative_stereo, AudioType.BattleCommon);
					if (temp.GetRoleData().roleSex == roleSex.男)
					{
						AudioManager.Instance.PlayAudio(AudioName.MUSIC_EFFECT_Battle_Death_Men, AudioType.BattleCommon);
					}
					else if (temp.GetRoleData().roleSex == roleSex.女)
					{
						AudioManager.Instance.PlayAudio(AudioName.MUSIC_EFFECT_Battle_Death_Women, AudioType.BattleCommon);
					}
					if (IsBattling && !isFightHard)
					{
						isFightHard = true;
						AudioManager.Instance.PlayMusic(AudioName.Fight_Hard_BGM);
					}
				}
				if (temp.GetRoleData().roleType == RoleType.怪物)
				{
					AudioManager.Instance.PlayAudio(AudioName.MUSIC_EFFECT_ENEMY_DEATH, AudioType.BattleCommon);
				}

				temp.OnDeath();
			}

			waitingMove = team.GetObjLifes();
			DelayAction(DEATH_DECIDE_TIME, DeathDecideMove);//   Invoke("DeathDecideMove", DEATH_DECIDE_TIME);
			if (onEnemyDeathDecideWithSummonAct == null)
			{
				IsSummon = false;
			}
			else
			{
				IsSummon = onEnemyDeathDecideWithSummonAct.Invoke();
			}

			DeathDecideList.Clear();
			if (GameObject.Find("BuffInfo") != null)
			{
				GameObject.Find("BuffInfo").transform.localScale = Vector3.zero;
			}
		}
		Debug.Log("测试-DeathDecide-4");
		if (IsBattling)
		{
			DelayAction(DEATH_DECIDE_TIME, () =>
			{
				if (herosTeam.GetCount().Equals(0))
				{
					Debug.Log("测试-DeathDecide-4-1");
					endBattleAct?.Invoke(false);
				}
				if (monsterTeam.GetCount().Equals(0))
				{
					Debug.Log("测试-DeathDecide-4-2");
					endBattleAct?.Invoke(true);
				}
				if (!IsSummon)
				{
					if (IsDeath)
					{
						DelayAction(DEATH_DECIDE_TIME + ROLE_MOVE_TIME, FindSpeedMaxFromActionList);//    Invoke("FindSpeedMaxFromActionList", DEATH_DECIDE_TIME + ROLE_MOVE_TIME);
					}
					else
					{
						if (isNextRole)
						{
							FindSpeedMaxFromActionList();
						}
					}
				}
				Debug.Log("测试-DeathDecide-4-3");
			});
		}
		else
		{
			/// <summary>
			/// 包里的角色加载是异步的，工程内是同步的这里要加 IsRoleInitOver 判断
			/// </summary>
			if (IsRoleInitOver && herosTeam.GetCount().Equals(0))
			{
				Debug.Log("测试-DeathDecide-4-4");
				endBattleAct?.Invoke(false);
				return true;
			}
		}
		Debug.Log("测试-DeathDecide-5");
		return IsDeath;
	}

	/// <summary>
	/// 角色死亡导致其他角色移动
	/// </summary>
	protected void DeathDecideMove()
	{
		foreach (var item in waitingMove)
		{
			MoveAni(item, RolePosCalculate(item));
		}
	}


	protected void DeathDecide()
	{
		DeathDecide(true);
	}


	/// <summary>
	/// 死亡时士气变化
	/// </summary>
	/// <param name="item"></param>
	void ChangeMoralWhenDeath(ObjLife item)
	{
		if (herosTeam.Contains(item)) //死亡英雄
		{
			ReduceTeamMememberMoral(item);

		}
		else  //击杀敌人
		{
			for (int i = 0; i < herosTeam.GetObjLifes().Count; i++)
			{
				if (currentObjLife == herosTeam.GetObjLifes()[i])
				{
					currentObjLife.UpdateMorale(10, "击杀-本人");
				}
				else
				{
					currentObjLife.UpdateMorale(3, "击杀-队友");
				}
			}


		}
	}

	/// <summary>
	/// 死亡时减少队友士气
	/// </summary>
	/// <param name="item"></param>
	private void ReduceTeamMememberMoral(ObjLife item)
	{
		List<ObjLife> timeObjLifes = GetTeamFromRole(item).GetObjLifes();
		foreach (var objLife in timeObjLifes)
		{
			if (item != objLife)
			{
				objLife.UpdateMorale(-10, "队友死亡");
			}
		}
	}

	/// <summary>
	/// 添加角色到死亡判定列表
	/// </summary>
	/// <param name="objLife"></param>
	public void AddRoleToDeathDecideList(ObjLife objLife)
	{
		DeathDecideList.Add(objLife);
	}

	/// <summary>
	/// 添加角色到死亡判定列表
	/// </summary>
	/// <param name="objLives"></param>
	public void AddRoleToDeathDecideList(List<ObjLife> objLives)
	{
		foreach (var obj in objLives)
		{
			AddRoleToDeathDecideList(obj);
		}
	}



	#endregion


	#region 角色移动

	/// <summary>
	/// 计算角色的位置
	/// </summary>
	/// <param name="objLife"></param>
	/// <returns></returns>
	protected Vector3 RolePosCalculate(ObjLife objLife)
	{
		Team team = GetTeamFromRole(objLife);
		int index = team.GetIndex(objLife);
		return RolePosCalculate(team, index, objLife.GetSize());
	}

	/// <summary>
	/// 队伍中角色的位置偏移 = 1.8
	/// </summary>
	protected const float OFFSET_POSITION_X = 1.8f;

	/// <summary>
	/// 根据角色在队伍中的索引计算角色的位置
	/// </summary>
	/// <param name="team"></param>
	/// <param name="index"></param>
	/// <returns></returns>
	protected Vector3 RolePosCalculate(Team team, int index, int size)
	{
		int direction = team == herosTeam ? -1 : 1;
		if (size == 2)
		{
			return new Vector3(direction * ((index + 0.5f) * OFFSET_POSITION_X + 1.5f), 0.5f, 0f);
		}
		else
		{
			return new Vector3(direction * (index * OFFSET_POSITION_X + 1.5f), 0f, 0f);
		}
	}


	protected List<ObjLife> waitingMove;



	/// <summary>
	/// 技能即时效果导致的角色移动
	/// </summary>
	/// <param name="team"></param>
	/// <param name="objLife"></param>
	/// <param name="value"></param>
	protected void RoleMove(Team team, ObjLife objLife, int value)
	{
		if (value.Equals(0))
		{
			Debug.Log("移动数值异常");
			return;
		}
		List<ObjLife> objs = value < 0 ? team.MoveBackword(objLife, -value) : team.MoveForward(objLife, value);
		foreach (var item in objs)
		{
			MoveAni(item, RolePosCalculate(item));
		}
	}



	/// <summary>
	/// 技能导致的角色换位
	/// </summary>
	/// <param name="obj1"></param>
	/// <param name="obj2"></param>
	private void ExchangeMoveFromSkill(ObjLife obj1, ObjLife obj2, Team team)
	{
		AudioManager.Instance.PlayAudio(AudioName.FOOTSTEP_Trainers_Asphalt_Run_RR8_mono, AudioType.BattleCommon);
		team.Exchange(obj1, obj2);
		MoveAni(obj1, RolePosCalculate(obj1));
		MoveAni(obj2, RolePosCalculate(obj2));
	}

	/// <summary>
	/// 回归初始站位
	/// </summary>
	/// <param name="team"></param>
	protected void BackToBeginning(Team team)
	{
		posBeginning.RemoveAll(s => s == null);
		team.Init(posBeginning);
		for (int i = 0; i < team.GetCount(); ++i)
		{
			MoveAni(team.GetObjLife(i), RolePosCalculate(team, i, team.GetObjLife(i).GetSize()));
		}
	}

	/// <summary>
	/// 完成移动角色所需要的时间 = 0.8
	/// </summary>
	protected const float ROLE_MOVE_TIME = 0.8f;


	/// <summary>
	/// 播放角色移动动画
	/// </summary>
	/// <param name="target"></param>
	protected void MoveAni(ObjLife objLife, Vector3 target)
	{
		objLife.RoleMove(ROLE_MOVE_TIME, target);

		if (Mathf.Abs(objLife.transform.position.x - target.x) > 0.5f)
		{
			PositionDamage(objLife);

			if (IsBattling && ++objLife.BePositionCount >= 2)
			{
				objLife.BePositionCount = 0;
				objLife.TalentTrigger(TalentTriggerType.位移2次);
			}
		}

	}


	/// <summary>
	/// 移动伤害判定（目前只有陷阱）
	/// </summary>
	/// <param name="objLife"></param>
	public void PositionDamage(ObjLife objLife)
	{
		if (objLife.ExistsSkillBuff(ObjBuffType.陷阱))
		{
			objLife.UpdateHp(objLife.GetSkillBuffs().Where(s => s.buffType.Equals(ObjBuffType.陷阱)).Sum(s => s.buffValue));
			objLife.RemoveSkillBuff(ObjBuffType.陷阱);
			DebugLog.Instance.AddLog("陷阱伤害:" + objLife.GetSkillBuffs().Where(s => s.buffType.Equals(ObjBuffType.陷阱)).Sum(s => s.buffValue) + "\n");

			DeathDecide(false);
		}
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="index">-4 , -3 , -2 , -1 , 0 , 1 ,2 , 3 , 4</param>
	/// <param name="size"></param>
	/// <returns></returns>
	private Vector3 RolePosCalculate(int index, int size = 1)
	{
		if (size == 2)
		{
			return new Vector3(index * (OFFSET_POSITION_X + 1.5f), 0.5f, 0f);
		}
		else
		{
			return new Vector3(index * OFFSET_POSITION_X, 0f, 0f);
		}
	}


	/// <summary>
	/// TODO
	/// 计算更新队伍的碰撞盒子大小 - 未完善
	/// </summary>
	private void RoleTeamBoxSizeCalculate()
	{
		List<ObjLife> heros = herosTeam.GetObjLifes();
		if (heros.Count <= 0) return;
		for (int i = 0; i < heros.Count; ++i)
		{

		}
	}


	#endregion


	#region 战斗动画
	/// <summary>
	/// 动画显示的层级 = 30
	/// </summary>
	private const int ANI_HIGH_ORDER = 30;
	/// <summary>
	///动画显示的层级 = 5
	/// </summary>
	private const int ANI_LOW_ORDER = 5;
	/// <summary>
	/// 攻击者 - 动画
	/// </summary>
	private ObjLife aniUser;
	/// <summary>
	/// 被攻击者 - 动画
	/// </summary>
	private List<ObjLife> aniTargets;
	public MoralSkillEffect moralSkillEffect;
	private readonly Vector3 HERO_SKILL_EFFECT_OFFSET = Vector3.zero;// new Vector3(2.24f, 0.57f);
	private readonly Vector3 MONSTER_SKILL_EFFECT_OFFSET = Vector3.zero;// new Vector3(-2.24f, 0.57f);

	/// <summary>
	///远战动画偏移量-自己
	/// </summary>
	private const float ANI_ATTACK_FAR_SELF_OFFSET_X = 0.3f;
	/// <summary>
	///远战动画偏移量-对手
	/// </summary>
	private const float ANI_ATTACK_FAR_TARGET_OFFSET_X = 0.3f;
	/// <summary>
	///远战动画偏移量-摄像头
	/// </summary>
	private const float ANI_ATTACK_FAR_CAMERA_OFFSET_X = 0.2f;

	/// <summary>
	/// 近战动画偏移量-自己
	/// </summary>
	private const float ANI_ATTACK_NEAR_SELF_OFFSET_X = ANI_ATTACK_FAR_SELF_OFFSET_X * 2;
	private const float ANI_ATTACK_NEAR_SELF_OFFSET_Y = 0.1f;
	/// <summary>
	/// 近战动画偏移量-对手
	/// </summary>
	private const float ANI_ATTACK_NEAR_TARGET_OFFSET_X = ANI_ATTACK_FAR_TARGET_OFFSET_X * 2;
	private const float ANI_ATTACK_NEAR_TARGET_OFFSET_Y = 0.1f;
	/// <summary>
	/// 近战动画偏移量-摄像头
	/// </summary>
	private const float ANI_ATTACK_NEAR_CAMERA_OFFSET_X = ANI_ATTACK_FAR_CAMERA_OFFSET_X * 2;

	/// <summary>
	/// 开始战斗，使用战斗相机、提高渲染层级
	/// </summary>
	private void StartFighting()
	{
		if (oExitBattleScenes == null)
			oExitBattleScenes = GameObject.Find("ExitBattleScenes");

		oExitBattleScenes.SetActive(false);
		roleInfoView.battleActNumInfo.gameObject.SetActive(false);
		FightingCameraCon.Instance.Fighting();

		aniUser.UpdateSortingOrder(ANI_HIGH_ORDER);

		// foreach (var item in aniTargets)
		// {
		//     item.UpdateSortingOrder(ANI_HIGH_ORDER);
		// }

#if CameraScheme1 || Cinemachine
		aniUser.UpdateSortingLayer(FightingCameraCon.FightingCameraLayerName);
        // foreach (var item in aniTargets)
        // {
        //     item.UpdateSortingLayer(FightingCameraCon.FightingCameraLayerName);
        // }
#elif CameraScheme2
        foreach (var item in aniTargets)
        {
            item.UpdateSortingOrder(ANI_HIGH_ORDER);
        }

        aniUser.UpdateSortingLayer(FightingCameraCon.FightingRoundCameraLayerName);

        foreach (var item in aniTargets)
        {
            item.UpdateSortingLayer(FightingCameraCon.FightingRoundCameraLayerName);
        }
#endif
	}

	[Tooltip("间距")] public float RoleSpace = -1.0f;
	[Tooltip("角色宽度")] public float RoleWight = 1.5f;
	[Tooltip("角色显示半身Y方向偏移量")] private float RoleHeightOff = -0.1f;
	[Tooltip("释放者X偏移")] public float RoleOffsetX = -3f;
	/// <summary>
	/// 播放开始战斗动画，放大人物
	/// </summary>
	private void AniStartFighting()
	{

		//使用释放侧姿势图
		if (currentSkill != null)
		{
			if (aniType.Equals(SkillType.自残))
			{
				aniUser.AniUseGoAttacked();
			}
			else
			{
				aniUser.AniUseGoAttack(currentSkill.useRoleSprite);
			}
		}

		aniUser.AniStartFighting(ANI_START_TIME, nTimeScale);
		// foreach (var item in aniTargets)
		// {
		//     item.AniStartFighting(ANI_START_TIME);
		// }
#if CameraScheme1 || Cinemachine
		bool isHeroTeam_User = true;
        Team team_User = GetTeamFromRole(aniUser, out isHeroTeam_User);
        int index_User = team_User.GetIndex(aniUser);
        if (aniTargets != null && aniTargets.Count <= 0)
        {
            aniUser.transform.localPosition = new Vector3(0, aniUser.transform.localPosition.y + RoleHeightOff, aniUser.transform.localPosition.z);
        }
        else
        {
            bool isHeroTeam_AniTarget = true;
            Team team_AniTarget = GetTeamFromRole(aniTargets[0], out isHeroTeam_AniTarget);
            int index_AniTarget = team_AniTarget.GetIndex(aniTargets[0]);
            List<ObjLife> list = new List<ObjLife>();
            list.AddRange(aniTargets);
            float nTeamOffsetX = 0f;
            if (isHeroTeam_User && isHeroTeam_AniTarget)
            {
                // 己方buff
                list.OrderByDescending(s => team_AniTarget.GetIndex(s));

                // 施法者在最左侧
                list.Remove(aniUser);
                // 加一个角色位置距离，防止太近
                list.Insert(0, null);
                list.Insert(0, aniUser);
            }
            else if (!isHeroTeam_User && !isHeroTeam_AniTarget)
            {
                // 敌方buff
                list.OrderBy(s => team_AniTarget.GetIndex(s));
                // list.Add(null);

                // 施法者在最右侧
                list.Remove(aniUser);
                // 加一个角色位置距离，防止太近
                list.Add(null);
                list.Add(aniUser);
            }
            else if (isHeroTeam_User && !isHeroTeam_AniTarget)
            {
                // 己方攻击
                list.OrderByDescending(s => team_AniTarget.GetIndex(s));
                // list.Insert(0, null);
                // list.Insert(0, aniUser);

                // 左侧中间位置
                aniUser.transform.localPosition = new Vector3(RoleOffsetX, aniUser.transform.localPosition.y + RoleHeightOff, aniUser.transform.localPosition.z);
                nTeamOffsetX = -RoleOffsetX;
            }
            else if (!isHeroTeam_User && isHeroTeam_AniTarget)
            {
                // 敌方攻击
                list.OrderBy(s => team_AniTarget.GetIndex(s));
                // list.Add(null);
                // list.Add(aniUser);

                // 右侧中间位置
                aniUser.transform.localPosition = new Vector3(-RoleOffsetX, aniUser.transform.localPosition.y + RoleHeightOff, aniUser.transform.localPosition.z);
                nTeamOffsetX = RoleOffsetX;
            }

            List<float> listTemp = new List<float>();
            listTemp.Add(nTeamOffsetX);
            for (int i = 1; i < list.Count; ++i)
            {
                float temp = listTemp[i - 1];
                temp += list[i] == null ? RoleWight : list[i].GetSize() * RoleWight;
                temp += RoleSpace;
                listTemp.Add(temp);
            }
            float allWight = Mathf.Abs(listTemp[listTemp.Count - 1] - listTemp[0]);

            for (int i = 0; i < listTemp.Count; ++i)
            {
                if (list[i] == aniUser)
                {
                    list[i].transform.localPosition = new Vector3(listTemp[i] - allWight / 2, list[i].transform.localPosition.y + RoleHeightOff, list[i].transform.localPosition.z);
                    break;
                }
            }
        }


#elif CameraScheme2
        foreach (var item in aniTargets)
        {
            item.AniStartFighting(ANI_START_TIME);
        }
#endif


	}


	/// <summary>
	/// 目标被攻击，使用战斗相机、提高渲染层级
	/// </summary>
	private void AniBeHit()
	{
#if CameraScheme1 || Cinemachine
		foreach (var item in aniTargets)
        {
            item.UpdateSortingOrder(ANI_HIGH_ORDER);
        }

        foreach (var item in aniTargets)
        {
            item.UpdateSortingLayer(FightingCameraCon.FightingCameraLayerName);
        }

        foreach (var item in aniTargets)
        {
            item.AniTargetStartFighting(0f, nTimeScale);
        }

        bool isHeroTeam_User = true;
        Team team_User = GetTeamFromRole(aniUser, out isHeroTeam_User);
        int index_User = team_User.GetIndex(aniUser);
        if (aniTargets != null && aniTargets.Count <= 0)
        {
            aniUser.transform.localPosition = new Vector3(0, aniUser.transform.localPosition.y + RoleHeightOff, aniUser.transform.localPosition.z);
        }
        else
        {
            bool isHeroTeam_AniTarget = true;
            Team team_AniTarget = GetTeamFromRole(aniTargets[0], out isHeroTeam_AniTarget);
            int index_AniTarget = team_AniTarget.GetIndex(aniTargets[0]);
            List<ObjLife> list = new List<ObjLife>();
            list.AddRange(aniTargets);
            float nTeamOffsetX = 0f;
            if (isHeroTeam_User && isHeroTeam_AniTarget)
            {
                // 己方buff
                list.OrderByDescending(s => team_AniTarget.GetIndex(s));

                // 施法者在最左侧
                list.Remove(aniUser);
                // 加一个角色位置距离，防止太近
                list.Insert(0, null);
                list.Insert(0, aniUser);
            }
            else if (!isHeroTeam_User && !isHeroTeam_AniTarget)
            {
                // 敌方buff
                list.OrderBy(s => team_AniTarget.GetIndex(s));
                // list.Add(null);

                // 施法者在最右侧
                list.Remove(aniUser);
                // 加一个角色位置距离，防止太近
                list.Add(null);
                list.Add(aniUser);
            }
            else if (isHeroTeam_User && !isHeroTeam_AniTarget)
            {
                // 己方攻击
                list.OrderByDescending(s => team_AniTarget.GetIndex(s));
                // list.Insert(0, null);
                // list.Insert(0, aniUser);

                // 左侧中间位置
                aniUser.transform.localPosition = new Vector3(RoleOffsetX, aniUser.transform.localPosition.y + RoleHeightOff, aniUser.transform.localPosition.z);
                nTeamOffsetX = -RoleOffsetX;
            }
            else if (!isHeroTeam_User && isHeroTeam_AniTarget)
            {
                // 敌方攻击
                list.OrderBy(s => team_AniTarget.GetIndex(s));
                // list.Add(null);
                // list.Add(aniUser);

                // 右侧中间位置
                aniUser.transform.localPosition = new Vector3(-RoleOffsetX, aniUser.transform.localPosition.y + RoleHeightOff, aniUser.transform.localPosition.z);
                nTeamOffsetX = RoleOffsetX;
            }

            List<float> listTemp = new List<float>();
            listTemp.Add(nTeamOffsetX);
            for (int i = 1; i < list.Count; ++i)
            {
                float temp = listTemp[i - 1];
                temp += list[i] == null ? RoleWight : list[i].GetSize() * RoleWight;
                temp += RoleSpace;
                listTemp.Add(temp);
            }
            float allWight = Mathf.Abs(listTemp[listTemp.Count - 1] - listTemp[0]);

            for (int i = 0; i < listTemp.Count; ++i)
            {
                if (list[i] != null) list[i].transform.localPosition = new Vector3(listTemp[i] - allWight / 2, list[i].transform.localPosition.y + RoleHeightOff, list[i].transform.localPosition.z);
            }
        }
#endif
	}


	/// <summary>
	/// 播放技能注语动画
	/// </summary>
	private void AniSkillNotes()
	{
		Debug.Log("测试-AniSkillNotes");
		aniUser.AniSkillNote(ANI_SKILL_NOTE_TIME);
	}

	/// <summary>
	/// 播放攻击动画，使用相应贴图、攻击者前移 被击者后移，同时令伤害生效、回复生命生效
	/// </summary>
	private void AniAttack()
	{
		Debug.Log("测试-AniAttack:" + currentSkill);
		if (currentSkill == null)
		{
			Debug.Log("测试-AniAttack1:技能为空");
			return;
		}

		// 目标受击移动位置
		float fTargetOffsetX = 0f;
		float fTargetOffsetY = 0f;
		float fTargetCameraOffsetX = 0f;

		//使用释放侧姿势图
		if (currentSkill != null)
		{
			if (aniType.Equals(SkillType.自残))
			{
				aniUser.AniUseGoAttacked();
			}
			else
			{
				aniUser.AniUseGoAttack(currentSkill.useRoleSprite);
			}
		}

		if (currentSkill.IsMoralSkill)
		{
			//aniUser.AniUseMoralSkill();
			AniUseMoralSkillAttack();
		}
		else
		{

			//近战攻击前移
			if (aniType.Equals(SkillType.远程伤害))
			{
				// aniUser.AniMoveForward(ANI_FIGHTING_TIME);
				float fOffsetX = 0f;
				if (aniUser.GetRoleType() == RoleType.英雄)
				{
					fOffsetX = ANI_ATTACK_FAR_SELF_OFFSET_X;

					fTargetOffsetX = ANI_ATTACK_FAR_TARGET_OFFSET_X;
					fTargetCameraOffsetX = ANI_ATTACK_FAR_CAMERA_OFFSET_X;
				}
				else if (aniUser.GetRoleType() == RoleType.怪物)
				{
					fOffsetX = -ANI_ATTACK_FAR_SELF_OFFSET_X;

					fTargetOffsetX = -ANI_ATTACK_FAR_TARGET_OFFSET_X;
					fTargetCameraOffsetX = -ANI_ATTACK_FAR_CAMERA_OFFSET_X;
				}
				aniUser.AniMoveForward(aniUser.transform.localPosition.x + fOffsetX * offDistance, ANI_FIGHTING_TIME);
			}
			else if (aniType.Equals(SkillType.近战伤害))
			{
				float fOffsetX = 0f;
				float fOffsetY = 0f;
				if (aniUser.GetRoleType() == RoleType.英雄)
				{
					fOffsetX = ANI_ATTACK_NEAR_SELF_OFFSET_X;
					fOffsetY = -ANI_ATTACK_NEAR_SELF_OFFSET_Y;

					fTargetOffsetX = ANI_ATTACK_NEAR_TARGET_OFFSET_X;
					fTargetCameraOffsetX = ANI_ATTACK_NEAR_CAMERA_OFFSET_X;
					fTargetOffsetY = -ANI_ATTACK_NEAR_TARGET_OFFSET_Y;


				}
				else if (aniUser.GetRoleType() == RoleType.怪物)
				{
					fOffsetX = -ANI_ATTACK_NEAR_SELF_OFFSET_X;
					fOffsetY = -ANI_ATTACK_NEAR_SELF_OFFSET_Y;

					fTargetOffsetX = -ANI_ATTACK_NEAR_TARGET_OFFSET_X;
					fTargetCameraOffsetX = -ANI_ATTACK_NEAR_CAMERA_OFFSET_X;
					fTargetOffsetY = -ANI_ATTACK_NEAR_TARGET_OFFSET_Y;
				}
				if (aniTargets.Count > 0)
				{
					aniUser.AniMoveForward(aniUser.transform.localPosition.x + fOffsetX * offDistance, aniTargets[0].transform.localPosition.y + fOffsetY * offDistance, ANI_FIGHTING_TIME);
				}
			}

			if (currentSkill.cameraMoveData != null && currentSkill.cameraMoveData.Count > 0 && FightCameraController.Instance)
			{
				FightCameraController.Instance.Play(currentSkill.cameraMoveData.ToArray());
			}

			//使用攻击侧资源
			Vector3 offset = aniUser.GetRoleType() == RoleType.英雄 ? HERO_SKILL_EFFECT_OFFSET : MONSTER_SKILL_EFFECT_OFFSET;
			Debug.Log("测试-currentSill:" + currentSkill);
			if (currentSkill.useEffectSprite.RuntimeKey.ToString() != string.Empty)
			{
				aniUser.AniShowSkillEffect(currentSkill.useEffectSprite, ANI_FIGHTING_TIME, Vector3.zero);
			}
			else if (currentSkill.useEffectSpine.RuntimeKey.ToString() != string.Empty)
			{
				aniUser.AniShowSkillEffect(currentSkill.useEffectSpine, ANI_FIGHTING_TIME, offset, aniUser);
			}
		}

		//如果技能目标为自身，则对自身使用被击侧资源；否则对目标使用被击侧资源
		if (aniTargets.Count == 0)
		{
			if (currentSkill.targetEffectSprite.RuntimeKey.ToString() != string.Empty)
			{
				aniUser.AniShowSkillEffect(currentSkill.targetEffectSprite, ANI_FIGHTING_TIME, Vector3.zero);
			}
			else if (currentSkill.targetEffectSpine.RuntimeKey.ToString() != string.Empty)
			{
				aniUser.AniShowSkillEffect(currentSkill.targetEffectSpine, ANI_FIGHTING_TIME, Vector3.zero, aniUser);
			}
		}
		else
		{
			foreach (var item in aniTargets)
			{
				int i = 0;
				if (aniType.Equals(SkillType.近战伤害) || aniType.Equals(SkillType.远程伤害))
				{
					item.AniUseGoAttacked();

					if (!damagePacks[i].IsDodge)
					{
						item.ShowBloodExplosionEffect();//如果被攻击对象没有闪避，那么播放血爆特效
					}

					item.AniMoveForward(item.transform.localPosition.x + fTargetOffsetX * offDistance, item.transform.localPosition.y + fTargetOffsetY * offDistance, ANI_FIGHTING_TIME);
					// item.AniMoveBackward(ANI_FIGHTING_TIME, item.GetRoleType());
				}
				if (damagePacks.Any(s => s.IsDodge == false))//如果有其中一个没有闪避，那么引起血爆，如果都闪避，那么返回false
				{
					item.ShowXuewu();
				}

				if (currentSkill.targetEffectSprite.RuntimeKey.ToString() != string.Empty)
				{
					item.AniShowSkillEffect(currentSkill.targetEffectSprite, ANI_FIGHTING_TIME, Vector3.zero);
				}
				else if (currentSkill.targetEffectSpine.RuntimeKey.ToString() != string.Empty)
				{
					item.AniShowSkillEffect(currentSkill.targetEffectSpine, ANI_FIGHTING_TIME, Vector3.zero, aniUser);
				}

				i++;
			}

		}

		if (audioName == string.Empty) AudioManager.Instance.PlayAudio(audioName, AudioType.Skill);

		if (aniType == SkillType.自残)
		{
			DamageTakeEffect(new List<ObjLife> { aniUser }, damagePacks, aniUser);
			FightingCameraCon.Instance.DoShake(nTimeScale);
		}
		else
		{
			switch (aniType)
			{
				case SkillType.近战伤害:
				case SkillType.远程伤害:
					DamageTakeEffect(aniTargets, damagePacks, aniUser);
					FightingCameraCon.Instance.DoShake(nTimeScale);
					FightingCameraCon.Instance.DoCameraAni(fTargetCameraOffsetX, ANI_FIGHTING_TIME, ANI_END_TIME);
					break;
			}
		}

		CureHpTakeEffect(tailPacks);
	}

	/// <summary>
	/// 士气技能动画
	/// </summary>
	private void AniUseMoralSkillAttack()
	{
		if (aniUser == null) return;
		Debug.Log(aniUser.GetHeroName() + "------------------------------------");
		moralSkillEffect.Play(aniUser.GetMoralSkillEffect());

	}
	/// <summary>
	/// 播放结束战斗动画，使用骨骼动画、缩小人物
	/// </summary>
	private void AniEndFighting()
	{
		aniUser.AniEndFighting(ANI_END_TIME);
		foreach (var item in aniTargets)
		{
			item.AniEndFighting(ANI_END_TIME);
		}

		FightingCameraCon.Instance.ExitFight(ANI_END_TIME);
	}

	/// <summary>
	/// 结束战斗，关闭战斗相机、降低渲染层级、即时效果和buff生效、进行后续逻辑
	/// </summary>
	private void EndFighting()
	{
		aniUser.AniUseGoRole();
		foreach (var item in aniTargets)
		{
			item.AniUseGoRole();
		}
		aniUser.UpdateSortingOrder(ANI_LOW_ORDER);
		foreach (var item in aniTargets)
		{
			item.UpdateSortingOrder(ANI_LOW_ORDER);
		}
#if CameraScheme1 || Cinemachine
		aniUser.UpdateSortingLayer(FightingCameraCon.DefaultLayerName);
        foreach (var item in aniTargets)
        {
            item.UpdateSortingLayer(FightingCameraCon.DefaultLayerName);
        }
#elif CameraScheme2
        aniUser.UpdateSortingLayer(FightingCameraCon.FightingCameraLayerName);
        foreach (var item in aniTargets)
        {
            item.UpdateSortingLayer(FightingCameraCon.FightingCameraLayerName);
        }
#endif

		AniEnd();
		roleInfoView.battleActNumInfo.gameObject.SetActive(true);
		if (oExitBattleScenes == null)
			oExitBattleScenes = GameObject.Find("ExitBattleScenes");

		oExitBattleScenes.SetActive(true);
	}


	/// <summary>
	/// 技能类型 - 动画
	/// </summary>
	private SkillType aniType;
	/// <summary>
	/// 播放战斗动画
	/// </summary>
	/// <param name="type">技能类型</param>
	/// <param name="user"></param>
	/// <param name="targets"></param>
	protected void PlayFightingAni(SkillType type, ObjLife user, List<ObjLife> targets, RoleRelationType roleType = RoleRelationType.敌方, bool notCheck = false)
	{
		Debug.Log("测试-PlayFightingAni-" + currentSkill);
		aniType = type;
		aniUser = user;
		aniTargets = targets;
		audioName = null;
		switch (type)
		{
			case SkillType.近战伤害:
				switch (user.GetVocation())
				{
					case HeroVocation.星际战犯:
						audioName = AudioName.Attack_Fist_mono;
						break;
					case HeroVocation.雇佣杀手:
						audioName = AudioName.Attack_Dagger_mono;
						break;
					case HeroVocation.行星劫匪:
						audioName = AudioName.Attack_Adze_mono;
						break;
					case HeroVocation.奴隶商人:
						audioName = AudioName.Attack_Chain_mono;
						break;
					default:
						audioName = AudioName.Skill_Melee_mono;
						break;
				}
				break;
			case SkillType.远程伤害:
				switch (user.GetVocation())
				{
					case HeroVocation.双面间谍:
					case HeroVocation.雇佣杀手:
						audioName = AudioName.Attack_Dagger_mono;
						break;
					case HeroVocation.神秘学者:
						audioName = AudioName.Attack_Scriptures_mono;
						break;
					case HeroVocation.亡命赌徒:
						audioName = AudioName.Attack_Dice_mono;
						break;
					case HeroVocation.邪恶发明家:
						audioName = AudioName.Attack_Muskets_mono;
						break;
					default:
						audioName = AudioName.Skill_LongRange_mono;
						break;
				}
				break;
			case SkillType.召唤:
				audioName = AudioName.Skill_Conjuration_mono;
				break;
			case SkillType.形态切换:
			case SkillType.治疗:
				audioName = AudioName.Skill_Treatment_mono;
				break;
			case SkillType.综合:
				break;
			case SkillType.BUFF:
				audioName = AudioName.Skill_Buff_mono;
				break;
			case SkillType.自残:
				break;
		}

		if (aniTargets != null && aniTargets.Contains(user) && !notCheck)
		{
			aniTargets.Remove(user);
		}
		RefreshBattleActNumInfo();
		// bool isPlayAnimSkillNote = UnityEngine.Random.Range(0, 2) == 1 ? true:false;
		bool isPlayAnimSkillNote = false;
		float fSkillNoteTime = 0;
		if (isPlayAnimSkillNote && currentSkill != null && currentSkill.IsHaveTips)
		{
			fSkillNoteTime = ANI_SKILL_NOTE_TIME;
			DelayAction(0, AniSkillNotes);
		}

		bool isHeroTeam_User = true;
		GetTeamFromRole(aniUser, out isHeroTeam_User);
		if (!isHeroTeam_User)
		{
			fSkillNoteTime += ANI_SKILL_SHOW_TIME;
		}

		DelayAction(fSkillNoteTime, StartFighting); //Invoke("StartFighting", 0f);
		DelayAction(fSkillNoteTime, AniStartFighting);// Invoke("AniStartFighting", 0f);

		DelayAction(ANI_START_TIME + fSkillNoteTime, AniBeHit); //Invoke("AniBeHit", ANI_START_TIME + fSkillNoteTime);
		DelayAction(ANI_START_TIME + fSkillNoteTime, AniAttack);// Invoke("AniAttack", ANI_START_TIME + fSkillNoteTime);
		DelayAction(ANI_START_TIME + fSkillNoteTime + ANI_FIGHTING_TIME, AniEndFighting);// Invoke("AniEndFighting", ANI_START_TIME + fSkillNoteTime + ANI_FIGHTING_TIME);
		DelayAction(ANI_START_TIME + fSkillNoteTime + ANI_FIGHTING_TIME + ANI_END_TIME, EndFighting);// Invoke("EndFighting", ANI_START_TIME + fSkillNoteTime + ANI_FIGHTING_TIME + ANI_END_TIME);
	}


	protected Action onFightAnimEndAct;
	/// <summary>
	/// 动画结束
	/// </summary>
	protected void AniEnd()
	{

		if (Insert)
		{
			var hurtBack = InsertObj.GetBuff(ObjBuffType.反击);
			if (hurtBack != null && hurtBack.Count > 0)
			{
				currentSkill = hurtBack[0].nextSkill;
				currentObjLife = InsertObj;
				InsertObj.RemoveSkillBuff(ObjBuffType.反击);
				FightingCalculating(hurtBack[0].linkTarget, null, null, true, false, false);
				buffPacks.RemoveAll(x => x.BuffType == ObjBuffType.反击);
			}
			else
			{
				//RefreshBattleActNumInfo 刷新行动点
				onFightAnimEndAct?.Invoke();
			}
		}
		else
		{
			//RefreshBattleActNumInfo 刷新行动点
			onFightAnimEndAct?.Invoke();
		}
	}

	#endregion

	#region 战斗计算 
	/// <summary>
	/// 战斗计算
	/// </summary>
	/// <param name="target"></param>
	public void FightingCalculating(ObjLife target, ObjLife user = null, SkillData userSkill = null, bool notCheck = false, bool calculateTail = true, bool calculateBuff = true)
	{
		Insert = false;
		InsertObj = null;
		Debug.Log("测试-FightingCalculating");
		DebugLog.Instance.AddLog(currentSkill.name + "\n");
		damagePacks.Clear();
		tailPacks.Clear();
		buffPacks.Clear();
		RoleRelationType roleType = RoleRelationType.敌方;

		ObjLife currUser = user == null ? currentObjLife : user;
		SkillData currSkill = userSkill == null ? currentSkill : userSkill;

		currUser.UpdateSkillCd(currSkill.id);
		logUser.Clear();
		logTarget.Clear();
		logTail.Clear();
		logBuff.Clear();
		logUser.AppendLine("--------------------------------------------------------------------------------------------------------------------------------------------");
		logUser.AppendLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
		Debug.LogWarning(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "         " + logUser.ToString());
		logUser.AppendLine($"技能使用者 {currUser.GetHeroName()}");
		logUser.AppendLine($"技能名称 {currSkill.name}");
		logUser.AppendLine($"=========当前属性（除技能外的所有属性加成后的值）=========");
		logUser.AppendLine($"当前生命值 : {currUser.GetHp()}、当前士气 ：{currUser.GetMorale()}、伤害：{currUser.GetAtkBeforeLog()}、精准值:{currUser.GetRate()}、暴击率:{currUser.GetCrits()}、闪避:{currUser.GetDodge()}、减伤:{currUser.GetDefence()}、速度:{currUser.GetSpeed()}、眩晕:{currUser.GetVertigo()}、位移:{currUser.GetPosition()}、减益:{currUser.GetDebuff()}、流血:{currUser.GetBleed()}、中毒{currUser.GetPoison()}");

		calculatingHeroData(currUser, currSkill, ref target);


		List<ObjLife> objsNotDodge = new List<ObjLife>();//没有闪避的角色


		attackedObjLifes.Clear();
		switch (currSkill.targetType)
		{
			case SkillTargetType.自身:
			case SkillTargetType.己方全体:
			case SkillTargetType.己方全体_不含自身:
				roleType = RoleRelationType.友方;
				foreach (var item in canBeSelected)
				{
					attackedObjLifes.Add(item);
				}
				break;
			case SkillTargetType.敌方群体:
				roleType = RoleRelationType.敌方;
				if (currSkill.targetRandomNum > 0)
				{
					if (canBeSelected.Count <= currSkill.targetRandomNum)
					{
						foreach (var item in canBeSelected)
						{
							attackedObjLifes.Add(item);
						}
					}
					else
					{
						var nums = CommonHelper.RandomNums(canBeSelected.Count, currSkill.targetRandomNum);
						for (int i = 0; i < nums.Length; i++)
						{
							attackedObjLifes.Add(canBeSelected[nums[i]]);
						}
					}
				}
				else
				{
					foreach (var item in canBeSelected)
					{
						attackedObjLifes.Add(item);
					}
				}
				break;
			case SkillTargetType.己方单体:
			case SkillTargetType.己方单体_不含自身:
				roleType = RoleRelationType.友方;
				attackedObjLifes.Add(target);
				break;
			case SkillTargetType.敌方单体:
				roleType = RoleRelationType.敌方;
				attackedObjLifes.Add(target);
				break;
		}
		switch (currSkill.skillType)
		{
			case SkillType.自残:
			case SkillType.近战伤害:
			case SkillType.远程伤害:
				DamageCalculating(currUser, attackedObjLifes, currSkill);
				currUser.RemoveSkillBuff(ObjBuffType.充分准备);
				foreach (var item in damagePacks)
				{
					DebugLog.Instance.AddLog(item.DebugLog);
				}

				for (int i = 0; i < Mathf.Min(attackedObjLifes.Count, damagePacks.Count); ++i)
				{
					if (!damagePacks[i].IsDodge)
					{
						objsNotDodge.Add(attackedObjLifes[i]);
					}
				}
				break;
			case SkillType.治疗:
				//CureAddTeamMemeberMoral(currUser);
				objsNotDodge.AddRange(attackedObjLifes);
				//damagePacks.Add(new DamagePack(false,false,0,""));
				break;
			case SkillType.BUFF:
			case SkillType.召唤:
			case SkillType.形态切换:
				for (int i = 0; i < attackedObjLifes.Count; ++i)
				{
					objsNotDodge.Add(attackedObjLifes[i]);
				}
				break;
		}

		ReduceAttackedObjLifesMoral(attackedObjLifes);
		if (calculateTail)
			TailCalculating(currUser, objsNotDodge, currSkill);
		foreach (var item in tailPacks)
		{
			//DebugLog.Instance.AddLog(item.DebugLog);
			logTail.AppendLine(item.DebugLog);
		}
		if (calculateBuff)
			BuffCalculating(currUser, objsNotDodge, currSkill);
		foreach (var item in buffPacks)
		{
			//DebugLog.Instance.AddLog(item.DebugLog);
			logBuff.AppendLine(item.DebugLog);
		}

		SummonCalculating(currSkill);

		//xl
		if (currSkill.IsMoralSkill)
		{
			UseMoralSkill(currUser);

			OtherSkillData otherSkillData = currSkill as OtherSkillData;
			List<AlienatedEntryData> entryList = otherSkillData.GetEntry();
			foreach (var entry in entryList)
			{
				BuffCalculating(currUser, objsNotDodge, entry.skillBuffs);
				TailCalculating(currUser, objsNotDodge, entry.skillTails);
				if (entry.killToActAgain) currSkill.killToActAgain = true;
			}
		}
		else
		{
			NotUseMoralSkill(currUser);
		}


		logUser.AppendLine($"=========技能使用加成后该角色属性=========");
		logUser.AppendLine($"当前生命值 : {currUser.GetHp()}、当前士气 ：{currUser.GetMorale()}、伤害：{currUser.GetAtkAfterLog()}、精准值:{currUser.GetRate()}、暴击率:{currUser.GetCrits()}、闪避:{currUser.GetDodge()}、减伤:{currUser.GetDefence()}、速度:{currUser.GetSpeed()}、眩晕:{currUser.GetVertigo()}、位移:{currUser.GetPosition()}、减益:{currUser.GetDebuff()}、流血:{currUser.GetBleed()}、中毒{currUser.GetPoison()}、死亡抗性{currUser.GetDeath()}");

		IOTools.WriteTxt(Application.dataPath + "/skill_log.txt", logUser.ToString());
		IOTools.WriteTxt(Application.dataPath + "/skill_log.txt", logTarget.ToString());
		IOTools.WriteTxt(Application.dataPath + "/skill_log.txt", logTail.ToString());
		IOTools.WriteTxt(Application.dataPath + "/skill_log.txt", logBuff.ToString());
		if (currentSkill.id == 1071)
		{
			currentSkill.targetType = SkillTargetType.敌方单体;
		}
		PlayFightingAni(currSkill.skillType, currUser, notCheck ? new List<ObjLife> { target } : attackedObjLifes, roleType, notCheck);
	}

	protected delegate void fightingCalculatingHeroData(ObjLife currUser, SkillData currSkill, ref ObjLife target);
	protected fightingCalculatingHeroData calculatingHeroData;
	/// <summary>
	/// 计算伤害
	/// </summary>
	/// <param name="attacker"></param>
	/// <param name="attackeds"></param>
	private void DamageCalculating(ObjLife attacker, List<ObjLife> attackeds, SkillData skill)
	{
		foreach (var item in attackeds)
		{
			var damage = BattleCalculating.GetDamage(attacker, item, skill);
			damagePacks.Add(damage);
		}
	}

	/// <summary>
	/// 计算即时效果
	/// </summary>
	/// <param name="user"></param>
	/// <param name="targets"></param>
	private void TailCalculating(ObjLife user, List<ObjLife> targets, SkillData skill)
	{
		Debug.Log("测试-计算即时效果-TailCalculating");
		int level = user.GetSkillLevel(skill);
		foreach (var item in skill.skillTails)
		{
			switch (item.buffTarget)
			{
				case SkillBuffTarget.自身:
					tailPacks.Add(BattleCalculating.GetTail(user, user, item, level, false));
					break;
				case SkillBuffTarget.目标:
					foreach (var it in targets)
					{
						bool isCalDodge = !(GetTeamFromRole(user) == GetTeamFromRole(it));
						if (skill.id == 1082)//努力商人-感染
						{
							TailValue tail = GetTailData1082(it);
							if (tail != null)
							{
								tailPacks.Add(BattleCalculating.GetTail(user, it, tail, level, isCalDodge));
							}
						}
						else
						{
							tailPacks.Add(BattleCalculating.GetTail(user, it, item, level, isCalDodge));
						}
					}
					break;
				case SkillBuffTarget.全体敌人:
					foreach (var it in enemyTeam.GetObjLifes())
					{
						tailPacks.Add(BattleCalculating.GetTail(user, it, item, level, true));
					}
					break;
				case SkillBuffTarget.其他敌人:
					foreach (var it in enemyTeam.GetObjLifes())
					{
						if (targets.Contains(it))
						{
							continue;
						}
						tailPacks.Add(BattleCalculating.GetTail(user, it, item, level, true));
					}
					break;
				case SkillBuffTarget.全体队友:
					foreach (var it in currentTeam.GetObjLifes())
					{
						tailPacks.Add(BattleCalculating.GetTail(user, it, item, level, false));
					}
					break;
				case SkillBuffTarget.其他队友:
					foreach (var it in currentTeam.GetObjLifes())
					{
						if (it == user)
						{
							continue;
						}
						tailPacks.Add(BattleCalculating.GetTail(user, it, item, level, false));
					}
					break;
			}
		}
	} /// <summary>
	  /// 计算异化词条即时效果
	  /// </summary>
	  /// <param name="user"></param>
	  /// <param name="targets"></param>
	private void TailCalculating(ObjLife user, List<ObjLife> targets, List<TailValue> skillTails)
	{
		Debug.Log("测试-计算即时效果-异化词条");
		int level = 1;
		foreach (var item in skillTails)
		{
			switch (item.buffTarget)
			{
				case SkillBuffTarget.自身:
					tailPacks.Add(BattleCalculating.GetTail(user, user, item, level, false));
					break;
				case SkillBuffTarget.目标:
					foreach (var it in targets)
					{
						bool isCalDodge = !(GetTeamFromRole(user) == GetTeamFromRole(it));
						{
							tailPacks.Add(BattleCalculating.GetTail(user, it, item, level, isCalDodge));
						}
					}
					break;
				case SkillBuffTarget.全体敌人:
					foreach (var it in enemyTeam.GetObjLifes())
					{
						tailPacks.Add(BattleCalculating.GetTail(user, it, item, level, true));
					}
					break;
				case SkillBuffTarget.其他敌人:
					foreach (var it in enemyTeam.GetObjLifes())
					{
						if (targets.Contains(it))
						{
							continue;
						}
						tailPacks.Add(BattleCalculating.GetTail(user, it, item, level, true));
					}
					break;
				case SkillBuffTarget.全体队友:
					foreach (var it in currentTeam.GetObjLifes())
					{
						tailPacks.Add(BattleCalculating.GetTail(user, it, item, level, false));
					}
					break;
				case SkillBuffTarget.其他队友:
					foreach (var it in currentTeam.GetObjLifes())
					{
						if (it == user)
						{
							continue;
						}
						tailPacks.Add(BattleCalculating.GetTail(user, it, item, level, false));
					}
					break;
			}
		}
	}

	/// <summary>
	/// 有使用士气技能
	/// </summary>
	/// <param name="objLife"></param>
	public void UseMoralSkill(ObjLife objLife)
	{
		Debug.Log($"测试-{objLife.GetHeroName()} - UseMoralSkill");
		objLife.UpdateMorale(-50, "士气技能");

		if (UnityEngine.Random.Range(0f, 1f) < 0.8f)
		{
			ObjSkillBuff osb = new ObjSkillBuff(ObjBuffType.持续回复士气, ValueType.加减, 5, 3);
			foreach (var obj in GetTeamFromRole(objLife).GetObjLifes())
			{
				obj.AddSkillBuff(osb);
			}
		}
		else
		{
			objLife.AddSkillBuff(new ObjSkillBuff(ObjBuffType.血灌瞳人, ValueType.加减, 0, 3));
			objLife.AddSkillBuff(new ObjSkillBuff(ObjBuffType.流血, ValueType.加减, -5, 3));
		}
	}

	/// <summary>
	/// 没有使用士气技能
	/// </summary>
	/// <param name="objLife"></param>
	public void NotUseMoralSkill(ObjLife objLife)
	{
		Debug.Log($"测试-{objLife.GetHeroName()} - NotUseMoralSkill");
		if (objLife.GetMorale() >= 100)
		{
			objLife.MoraleBurstNum++;
			if (objLife.MoraleBurstNum >= 3)
			{
				objLife.AddSkillBuff(new ObjSkillBuff(ObjBuffType.持续回复士气, ValueType.加减, -10, 3));
			}
		}
		else
		{
			objLife.MoraleBurstNum = 0;
		}
	}


	#endregion

	#region 伤害计算与技能效果处理模块

	/// <summary>
	/// 除回复生命外的其他即时效果生效
	/// </summary>
	/// <param name="tailPacks"></param>
	protected void TailTakeEffect(List<TailPack> tailPacks)
	{
		List<ObjLife> tonghunTargets = new List<ObjLife>();
		foreach (var item in tailPacks)
		{
			if (item.IsDodge)
			{
				// 被抵抗
				if (item.Target)
				{
					item.Target.OnResist();
				}
				continue;
			}


			switch (item.Type)
			{
				case SkillTailType.士气:
					item.Target.UpdateMorale(item.Value, "即时效果 士气");
					break;
				case SkillTailType.伤势:
					item.Target.UpdateInjuries(item.Value);
					item.Target.UpdateMorale(-2, "即时效果 伤势");
					break;
				case SkillTailType.位移:

					RoleMove(GetTeamFromRole(item.Target), item.Target, item.Value);
					AudioManager.Instance.PlayAudio(AudioName.Skill_Position_mono, AudioType.Skill);
					break;
				case SkillTailType.移除buff:
					item.Target.RemoveSkillBuff(item.BuffType);
					break;
				case SkillTailType.获得BUFF:
					item.Target.AddSkillBuff(new ObjSkillBuff(item.BuffType, ValueType.加减, 0, 1));
					break;
				case SkillTailType.切换形态:
					item.Target.IsSpy ^= true;
					if (item.Target.IsSpy)
					{
						item.Target.AniUseGoRole();
					}
					else
					{
						item.Target.AniUseGoShalu();
					}
					break;
				case SkillTailType.随机交换位置:
					Team team = GetTeamFromRole(item.Target);
					List<ObjLife> canExchange = team.GetObjLifes();
					canExchange.Remove(item.Target);
					if (canExchange.Count > 0)
					{
						ObjLife exTarget = canBeSelected[UnityEngine.Random.Range(0, canExchange.Count)];
						ExchangeMoveFromSkill(item.Target, exTarget, team);
					}
					AudioManager.Instance.PlayAudio(AudioName.Skill_Position_mono, AudioType.Skill);
					break;
				case SkillTailType.流血加重:
					List<ObjSkillBuff> buffs = item.Target.GetSkillBuffs().Where(s => s.buffType == ObjBuffType.流血).ToList();
					foreach (var buff in buffs)
					{
						buff.buffValue += item.Value;
					}
					item.Target.UpdateBuff();
					break;
				case SkillTailType.回归初始站位:
					BackToBeginning(GetTeamFromRole(item.Target));
					break;
				case SkillTailType.极速恶化:
					List<ObjSkillBuff> bufs = item.Target.GetSkillBuffs().Where(s => s.buffType == ObjBuffType.流血 || s.buffType == ObjBuffType.中毒 || s.buffType == ObjBuffType.炸弹).ToList();
					int sum = 0;
					foreach (var buf in bufs)
					{
						if (buf.buffType == ObjBuffType.炸弹)
						{
							sum += buf.buffValue;
							item.Target.RemoveSkillBuff(buf);
							continue;
						}
						sum += buf.buffValue * buf.round;
						item.Target.RemoveSkillBuff(buf);
					}
					item.Target.ShowValue(sum, 0, false);
					item.Target.UpdateHp(sum);
					DebugLog.Instance.AddLog("极速恶化:" + sum + "\n");
					break;
				case SkillTailType.即死:
					item.Target.SetHp(0);
					List<ObjLife> timeObjLifes = GetTeamFromRole(item.Target).GetObjLifes();
					foreach (var objLife in timeObjLifes)
					{
						if (item.Target != objLife)
						{
							objLife.UpdateMorale(-10, "即时效果 即死");
						}
					}
					break;
				case SkillTailType.生命强化:
					item.Target.SetMaxHp(item.Target.GetMaxHpExceptBuff() * 2);
					item.Target.UpdateHp(item.Target.GetMaxHp() - Mathf.RoundToInt(item.Target.GetHp()));
					List<ObjLife> timeObjLifes2 = GetTeamFromRole(item.Target).GetObjLifes();
					foreach (var objLife in timeObjLifes2)
					{
						if (item.Target != objLife)
						{
							objLife.UpdateMorale(2, "即时效果 生命强化");
						}
					}
					break;
				case SkillTailType.行动点:
					item.Target.CurrentActNum += item.Value;
					break;

				case SkillTailType.同魂:
					tonghunTargets.Add(item.Target);
					break;
				case SkillTailType.吞噬:
					tunshiObj = item.Target;
					GetTeamFromRole(item.Target).OnTunshi(item.Target);
					GetTeamFromRole(item.Target).Death(item.Target);
					actionList.Remove(item.Target);
					item.Target.gameObject.SetActive(false);
					waitingMove = GetTeamFromRole(item.Target).GetObjLifes();
					DelayAction(DEATH_DECIDE_TIME, DeathDecideMove);//    Invoke("DeathDecideMove", DEATH_DECIDE_TIME);
					break;
				case SkillTailType.当前生命百分比:
					item.Target.UpdateHp(Mathf.RoundToInt(item.Target.GetHp() * (1f + item.Value / 100f)));
					break;
			}
		}

		if (tonghunTargets.Count > 0)
		{
			int hpAvg = Mathf.RoundToInt(tonghunTargets.Sum(s => s.GetHp()) * 1.0f / tonghunTargets.Count);
			int moraleAvg = Mathf.RoundToInt(tonghunTargets.Sum(s => s.GetMorale()) * 1.0f / tonghunTargets.Count);

			foreach (var obj in tonghunTargets)
			{
				obj.UpdateHp(hpAvg - Mathf.RoundToInt(obj.GetHp()), false, 0.3f);
				obj.UpdateMorale(moraleAvg - obj.GetMorale(), "即时效果 同魂");
			}
		}
	}

	/// <summary>
	/// buff生效（赋予角色buff）
	/// </summary>
	/// <param name="buffPacks"></param>
	protected void BuffTakeEffect(List<BuffPack> buffPacks)
	{
		//计算buff击中概率

		foreach (var item in buffPacks)
		{
			if (item.IsDodge)
			{
				// 被抵抗
				if (item.Target)
				{
					item.Target.OnResist();
				}
				continue;
			}
			//播放音效以及头部提示
			switch (item.BuffType)
			{
				case ObjBuffType.中毒:
					AudioManager.Instance.PlayAudio(AudioName.Skill_Poisoning_mono, AudioType.Skill);
					break;
				case ObjBuffType.流血:
					AudioManager.Instance.PlayAudio(AudioName.Skill_Bleeding_mono, AudioType.Skill);

					break;
				case ObjBuffType.眩晕:
					AudioManager.Instance.PlayAudio(AudioName.Skill_Vertigo_mono, AudioType.Skill);


					break;
				default:
					if (BattleCalculating.IsDebuff(item.BuffType) && item.Value <= 0)
					{
						AudioManager.Instance.PlayAudio(AudioName.Skill_Buff_mono, AudioType.Skill);

					}
					else if (BattleCalculating.IsDebuff(item.BuffType) && item.Value > 0)
					{
						AudioManager.Instance.PlayAudio(AudioName.Skill_Buff_mono, AudioType.Skill);
					}

					break;


			}
			if (buffPacks.Any(buff => { return buff.BuffType == ObjBuffType.吞噬; }))
			{
				if (!tailPacks.Any(tail => { return tail.Type == SkillTailType.吞噬; }))
				{
					Debug.Log("即时效果中没有吞噬，吞噬失败!自身吞噬buff失效");
					return;
				}
			}
			item.Target.AddSkillBuff(new ObjSkillBuff(item.BuffType, item.ValueType, item.Value, item.Round));
		}
	}

	/// <summary>
	/// 触发天赋
	/// </summary>
	/// <param name="objLife"></param>
	/// <param name="talentEffect"></param>
	public void TalentTrigger(ObjLife objLife, TalentEffect talentEffect)
	{
		List<ObjLife> targets = new List<ObjLife>();
		switch (talentEffect.target)
		{
			case SkillTargetType.自身:
				targets.Add(objLife);
				break;
			case SkillTargetType.随机敌方:
				List<ObjLife> monsters = monsterTeam.GetObjLifes();
				if (monsters.Count > 0) targets.Add(monsters[UnityEngine.Random.Range(0, monsterTeam.GetCount())]);
				break;
			case SkillTargetType.相邻队友:
				int index = herosTeam.GetIndex(objLife);
				if (herosTeam.GetObjLife(index - 1) != null)
				{
					targets.Add(herosTeam.GetObjLife(index - 1));
				}
				if (herosTeam.GetObjLife(index + 1) != null)
				{
					targets.Add(herosTeam.GetObjLife(index + 1));
				}
				break;
			default:
				Debug.Log("未实现的目标选择");
				break;
		}

		foreach (var obj in targets)
		{
			switch (talentEffect.type)
			{
				case TalentEffectType.获得buff:
					foreach (var buff in talentEffect.buff)
					{
						BuffPack buffPack = BattleCalculating.GetBuff(objLife, obj, buff);
						BuffTakeEffect(new List<BuffPack>() { buffPack });
					}
					break;
				case TalentEffectType.获得行动点:
					++obj.CurrentActNum;
					break;
				case TalentEffectType.造成伤害:
					obj.UpdateHp(-Mathf.Abs(talentEffect.damageValue));
					obj.UpdateMorale(-2, "触发天赋 造成伤害");
					break;
				case TalentEffectType.造成即时效果:
					foreach (var tail in talentEffect.tail)
					{
						TailPack tailPack = BattleCalculating.GetTail(objLife, obj, tail);
						TailTakeEffect(new List<TailPack>() { tailPack });
					}
					break;
				default:
					Debug.Log("未实现的天赋");
					break;
			}
		}

	}

	#endregion

}

