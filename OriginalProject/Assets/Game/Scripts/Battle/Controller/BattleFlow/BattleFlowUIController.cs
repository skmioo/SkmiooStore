using Datas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// 战斗逻辑ui相关
/// Item 道具
/// 行动点相关
/// 音频
/// 面板点击处理
/// </summary>
public class BattleFlowUIController : BattleFlowLogicController
{
	/// <summary>
	/// 背包
	/// </summary>
	public Kanpsack kanpsack;
	/// <summary>
	/// 任务结算面板
	/// </summary>
	public Settlement settlement;

	/// <summary>
	///  角色信息面板，带技能控制
	/// </summary>
	public RoleInfoView roleInfoView;
	/// <summary>
	/// 角色具体信息展示面板
	/// </summary>
	public RoleInfoPanel roleInfoPanel;
	/// <summary>
	/// 怪物信息面板
	/// </summary>
	public EnemyInfoView enemyInfoview;
	//地图控制器引用
	public MapController mapController;
	public GameObject oExitBattleScenes;
	/// <summary>
	/// 是否响应面板点击事件
	/// </summary>
	public bool IsResponsePanel { get; set; } = true;

	/// <summary>
	/// 是否响应角色点击事件
	/// </summary>
	protected bool IsResponseRole { get; set; } = true;

	public BoxCollider2D Box2D { get; set; }
	protected override void InitData()
	{
		base.InitData();
		Canvas InputCanvas = transform.Find("InputCanvas").GetComponent<Canvas>();
		InputCanvas.worldCamera = FightingCameraCon.Instance.mainCamera;
		Box2D = GetComponent<BoxCollider2D>();
		PlayFightMapBgm();
	}

	#region item道具
	/// <summary>
	/// 肉干
	/// </summary>
	protected int rouganCount;
	/// <summary>
	/// 蘑菇
	/// </summary>
	protected int moguCount;

	/// <summary>
	/// 使用物品
	/// </summary>
	/// <param name="objData"></param>
	/// <returns></returns>
	public bool UseObjData(ObjData objData)
	{
		if (!IsResponsePanel) { return false; }
		if (currentObjLife == null) { return false; }
		switch (objData.id)
		{
			case 6001:
				if (IsBattling)
				{
					if (rouganCount >= 2)
					{
						return false;
					}
					else
					{
						rouganCount++;
					}
				}
				currentObjLife.UpdateHp(objData.objActions[0].value);
				break;
			case 6002:
				if (IsBattling)
				{
					if (moguCount >= 2)
					{
						return false;
					}
					else
					{
						moguCount++;
					}
				}
				currentObjLife.UpdateMorale(objData.objActions[0].value, "UseObjData " + objData.id);

				break;
			case 6003:
			case 6004:
				currentObjLife.RemoveSkillBuff(objData.objActions[0].buffType);
				break;
			case 10001:
				foreach (var item in herosTeam.GetObjLifes())
				{
					item.UpdateHp(objData.objActions[0].value);
				}
				break;
			case 10002:
				foreach (var item in herosTeam.GetObjLifes())
				{
					item.UpdateHp(objData.objActions[0].value);
				}
				break;
			case 10007:
				if (IsBattling) return false;

				foreach (var item in herosTeam.GetObjLifes())
				{
					item.UpdateHp(objData.objActions[0].value);
				}

				break;
			case 10003:
			case 10004:
				if (IsBattling) return false;

				foreach (var item in herosTeam.GetObjLifes())
				{
					item.UpdateMorale(objData.objActions[0].value, "UseObjData " + objData.id);
				}

				break;
			case 10005:
				if (IsBattling) return false;

				foreach (var item in herosTeam.GetObjLifes())
				{
					SkillBuff buff = (objData as InteractiveScripture).skillBuffs[0];
					item.AddSkillBuff(new ObjSkillBuff(buff.buffType, buff.valueType, buff.value.level1, buff.effectiveRounds));
					item.UpdateHp(objData.objActions[0].value);
				}
				break;
			case 10006:
				if (IsBattling) return false;

				foreach (var item in herosTeam.GetObjLifes())
				{
					item.UpdateHp(objData.objActions[0].value);
					item.UpdateMorale(objData.objActions[1].value, "useObjData " + 10006);
				}

				break;
			default:
				Debug.Log("道具id错误/这不是一个可以使用的道具");
				return false;
		}
		PlayUseObjItemAudio(objData.id);
		return true;
	}

	#endregion

	#region 战斗流程函数
	protected void onUIBattleStart()
	{
		NewbieGuideMag.Instance.triggerGuide(GuideDataSet.guideEnum.inBattle);
		round = 0;
		roleInfoView.battleActNumInfo.RefreshCurRoundText(round);
		if (!mapController.isZoomOut)
		{
			mapController.OnMapZoomOut();
		}
		mapController.AllNotClickable();
		AudioManager.Instance.PlayAudio(AudioName.FOOTSTEP_Trainers_Snow_Loose_Walk_Slow_RR1_mono, AudioType.BattleCommon);
		IsResponsePanel = false;
		IsResponseRole = false;
		rouganCount = 0;
		moguCount = 0;
		roleInfoView.battleActNumInfo.Show();
	}

	protected void onUIBattleNewRound()
	{
		++round;
		roleInfoView.battleActNumInfo.RefreshCurRoundText(round);
		bool haveLowHpHero = false;
		//重置行动点
		foreach (var obj in herosTeam.GetObjLifes())
		{
			obj.CurrentActNum += obj.GetActNum();
			if (!haveLowHpHero && obj.GetHp() <= obj.GetMaxHp() * 0.3f)
			{
				haveLowHpHero = true;
			}
		}
		foreach (var obj in monsterTeam.GetObjLifes())
		{
			obj.CurrentActNum += obj.GetActNum();
		}
		//初始化行动点详情
		roleInfoView.battleActNumInfo.Initialized(herosTeam, monsterTeam);
		if (haveLowHpHero)
		{
			isFightHard = true;
			AudioManager.Instance.PlayMusic(AudioName.Fight_Hard_BGM);
		}

	}

	protected void onUIBattleEnd(bool win)
	{
		Debug.Log("测试-EndBattleing");
		roleInfoView.battleActNumInfo.Hide();
		if (isExitBallte)
		{
			mapController.ExitBattle();
			if (isBossRoom)
			{
				AudioManager.Instance.PlayMusic(AudioName.Decisive_Battle_BGM);
			}
			else
			{
				PlayFightMapBgm();
			}
			isFightHard = false;
		}
		else
		{
			if (win)
			{
				mapController.BattleWin();
				List<ObjData> tempList = mapController.GetMapDrop();
				if (tempList != null)
				{
					kanpsack.ShowGetPropPanel(tempList, true);
				}
				if (isBossRoom)
				{
					AudioManager.Instance.PlayMusic(AudioName.Decisive_Battle_BGM);
				}
				else
				{
					PlayFightMapBgm();
				}
				isFightHard = false;
			}
			else
			{
				IsFightFail = true;
				settlement.HeroAllDath();
				//清空所有已获得的解救事件效果
				TownInfo.ClearRescueType();
			}
		}
		rouganCount = 0;
		moguCount = 0;
		IsResponsePanel = true;
		IsResponseRole = true;
		//如果使用调试杀死所有怪，鼠标放在怪物上，战斗结束会显示怪物面板，需要关闭怪物面板
		CloseEnemyInfoPanel(null,true);
		mapController.UpdateClickable();
	}

	#endregion

	#region 面板信息处理

	public void RefreshBattleActNumInfo()
	{
		// if (!IsBattling) return;

		roleInfoView.battleActNumInfo.Refresh();

	}

	/// <summary>
	/// 显示怪物信息面板
	/// </summary>
	/// <param name="objLifeData"></param>
	public void ShowEnemyInfoPanel(ObjLife objLife)
	{
		if (IsBattling && !IsResponsePanel) return;
		//if (objLife == null) return;
		objLife.ShowTargetTips(RoleRelationType.敌方, true);
		enemyInfoview.gameObject.SetActive(true);
		enemyInfoview.Refresh(objLife);
		if (closeEnemyInfoPanelCor != null)
		{
			StopCoroutine(closeEnemyInfoPanelCor);
			closeEnemyInfoPanelCor = null;
			if (enemyLife != null)
			{
				enemyLife.CloseTargetTips(false);
				enemyLife = null;
			}
		}
	}
	Coroutine closeEnemyInfoPanelCor;
	ObjLife enemyLife;
	/// <summary>
	/// 通过协程0.15秒后检测是否关闭怪物信息面板，这样快速显示不同怪物时可以不用关闭打开怪物信息，更友好一些
	/// </summary>
	/// <param name="objLife"></param>
	/// <param name="isImmediate"></param>
	public void CloseEnemyInfoPanel(ObjLife objLife, bool isImmediate = false)
	{
		if (isImmediate)
		{
			if (objLife != null)
			{
				objLife.CloseTargetTips(false);
			}
			enemyInfoview.gameObject.SetActive(false);
		}
		else {
			enemyLife = objLife;
			closeEnemyInfoPanelCor = StartCoroutine(doCloseEnemyInfoPanel(objLife));
		}
	}

	IEnumerator doCloseEnemyInfoPanel(ObjLife objLife)
	{
		yield return new WaitForSeconds(0.15f);
		if (objLife != null)
		{
			objLife.CloseTargetTips(false);
		}
		enemyInfoview.gameObject.SetActive(false);
		closeEnemyInfoPanelCor = null;
		enemyLife = null;
	}

	/// <summary>
	/// 重置战斗信息面板（战斗中）
	/// </summary>
	/// <param name="objLife"></param>
	/// <param name="lastObjLife"></param>
	protected void ResetPanelInBattle(ObjLife objLife)
	{
		//获取当前技能
		skillDatas = DataManager.Instance.GetSkillDatasWhereUse(objLife.GetSkillModes());
		if (objLife.GetVocation().Equals(HeroVocation.双面间谍))
		{
			if (objLife.IsSpy)
			{
				skillDatas.RemoveAll(s => s.useLimits.Count > 0 && s.useLimits[0].limitType.Equals(LimitType.间谍形态不可用));
			}
			else
			{
				skillDatas.RemoveAll(s => s.useLimits.Count > 0 && s.useLimits[0].limitType.Equals(LimitType.杀戮形态不可用));
			}
		}

		//计算当前技能是否可用
		useables.Clear();
		foreach (var item in skillDatas)
		{
			bool useable = true;
			if (useable)
			{
				useable = PositionLimit(GetTeamFromRole(objLife).GetIndex(objLife), item.position);
			}

			if (useable)
			{
				useable = TargetPositionHasRole(objLife, item);
			}

			if (useable && item.useLimits.Count > 0)
			{
				useable = UseLimit(item);
			}

			if (useable && item.targetLimits.Count > 0)
			{
				useable = TargetLimit(item);
			}

			if (useable)
			{
				useable = OtherLimit(item);
			}

			if (useable)
			{
				useable = objLife.IsUseSkillForCd(item.id);
			}

			if (objLife.GetVocation() == HeroVocation.亡命赌徒)
			{
				if (item.id == 1077)///戒断
				{

					if (objLife.dutuskill_stack.Count != 0 && objLife.dutuskill_stack.Count != 0)
					{
						objLife.dutuskill_stack.Pop();//判断的时候把选择入栈的取出来
						objLife.dupinskill_stack.Pop();
						List<int> dututemp = new List<int>();
						List<int> dupintemp = new List<int>();
						if (objLife.dutuskill_stack.Count < 3 && objLife.dupinskill_stack.Count < 3)
						{
							useable = false;
						}
						else
						{
							dututemp.Add(objLife.dutuskill_stack.Pop());
							dututemp.Add(objLife.dutuskill_stack.Pop());
							dututemp.Add(objLife.dutuskill_stack.Pop());


							dupintemp.Add(objLife.dupinskill_stack.Pop());
							dupintemp.Add(objLife.dupinskill_stack.Pop());
							dupintemp.Add(objLife.dupinskill_stack.Pop());
							//取得栈顶的三个元素


							useable = dututemp.All(s => s == 0) || dupintemp.All(s => s == 0);//判断是否满足条件

							for (int i = 2; i >= 0; i--)//入栈
							{
								objLife.dutuskill_stack.Push(dututemp[i]);
								objLife.dupinskill_stack.Push(dupintemp[i]);
							}

						}
						objLife.dutuskill_stack.Push(0);//判断之后再加入进去
						objLife.dupinskill_stack.Push(0);
					}

				}

			}
			useables.Add(useable);
		}

		moraleUseable = objLife.GetMorale() >= 100;

		{
			//测试
			bool isAll = true;
			for (int i = 0; i < useables.Count; ++i)
			{
				if (useables[i]) isAll = false;
			}
			if (isAll) Debug.Log("所有的技能都不可用");
		}

		roleInfoView.ShowRoleInfo(objLife.GetObjLifeData(), skillDatas.Select(s => s.icon).ToList(), useables, moraleUseable);

	}

	/// <summary>
	/// 重置战斗信息面板（非战斗中）
	/// </summary>
	/// <param name="objLife"></param>
	protected void ResetPanelNotInBattle(ObjLife objLife)
	{
		Debug.Log($"测试-ResetPanelNotInBattle-{objLife.GetHeroName()}");
		//获取当前技能
		skillDatas = DataManager.Instance.GetSkillDatasWhereUse(objLife.GetSkillModes());
		if (objLife.GetVocation().Equals(HeroVocation.双面间谍))
		{
			if (objLife.IsSpy)
			{
				skillDatas.RemoveAll(s => s.useLimits.Count > 0 && s.useLimits[0].limitType.Equals(LimitType.间谍形态不可用));
			}
			else
			{
				skillDatas.RemoveAll(s => s.useLimits.Count > 0 && s.useLimits[0].limitType.Equals(LimitType.杀戮形态不可用));
			}
		}

		useables.Clear();
		foreach (var skill in skillDatas)
		{
			useables.Add(false);
		}

		moraleUseable = false;

		roleInfoView.ShowRoleInfo(objLife.GetObjLifeData(), skillDatas.Select(s => s.icon).ToList(), useables, moraleUseable);

	}
	protected Action<ObjLife> onRoleBeSelected;
	/// <summary>
	/// 显示角色信息面板
	/// </summary>
	/// <param name="objLifeData"></param>
	public void ShowRoleInfoPanel(ObjLife objLife)
	{
		if (IsResponsePanel)
		{
			onRoleBeSelected?.Invoke(objLife);
			IsResponsePanel = false;
			IsResponseRole = false;
			ObjLifeData objLifeData = objLife.GetObjLifeData();
			if (objLifeData.GetRoleType() == RoleType.英雄)
			{
				AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
				roleInfoPanel.Show(objLifeData, true, false, true);
			}
		}
	}
	/// <summary>
	/// 显示角色信息面板  按键响应
	/// </summary>
	public void ShowRoleInfoPanelOfKeyDown()
	{
		ShowRoleInfoPanel(CurrentSelectHero);
	}
	/// <summary>
	/// 角色信息面板被关闭了
	/// </summary>
	/// <param name="objLifeData"></param>
	public void BeCloseRoleInfoPanerl()
	{

		if (IsBattling)
		{
			ResetPanelInBattle(CurrentSelectHero);
		}
		else
		{
			ResetPanelNotInBattle(CurrentSelectHero);
		}
		IsResponsePanel = true;
		IsResponseRole = true;
	}



	/// <summary>
	/// 关闭所有角色的目标提示
	/// </summary>
	public void CloseAllObjTargetTips()
	{
		foreach (var hero in herosTeam.GetObjLifes())
		{
			hero.CloseTargetTips(true);
		}
		foreach (var enemy in monsterTeam.GetObjLifes())
		{
			enemy.CloseTargetTips(true);
		}
	}
	#endregion

	#region 面板点击事件处理
	protected Action onJumpRoundAct;
	/// <summary>
	/// 面板点击事件处理
	/// </summary>
	/// <param name="panelClickType"></param>
	/// <param name="skillButtonsIndex">RoleInfoView.skillButtons</param>
	public void PanelClickEvent(PanelClickType panelClickType, int skillButtonsIndex = 0)
	{
		if (!IsResponsePanel)
		{
			return;
		}

		if (audioName != null)
		{
			AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
		}

		switch (panelClickType)
		{
			case PanelClickType.技能:
				// suchy
				if (skillDatas.Count <= skillButtonsIndex || !useables[skillButtonsIndex]) //如果技能不可用，忽略点击
				{
					Debug.Log("测试-PanelClickEvent-技能不可用");
					return;
				}
				isExchange = false;
				IsResponseRole = true;

				roleInfoView.TriggerSelectedImg(PanelClickType.技能, true, skillButtonsIndex);
				CloseAllObjTargetTips();
				currentSkill = GetSkillDataByIndex(skillButtonsIndex);
				AddTargetToCanBeSelected(currentObjLife, currentSkill);
				break;
			case PanelClickType.士气技能:
				if (!moraleUseable)
				{
					return;
				}
				isExchange = false;
				IsResponseRole = true;

				roleInfoView.TriggerSelectedImg(PanelClickType.士气技能, true);
				CloseAllObjTargetTips();
				currentSkill = DataManager.Instance.GetMoraleSkillById(currentObjLife.GetMoraleSkillId());
				AddTargetToCanBeSelected(currentObjLife, currentSkill);
				break;
			case PanelClickType.换位:
				isExchange = !isExchange;
				IsResponseRole = true;

				roleInfoView.TriggerSelectedImg(PanelClickType.换位, isExchange);
				CloseAllObjTargetTips();
				canBeSelected.Clear();
				if (isExchange)
				{
					List<ObjLife> targets = herosTeam.GetCanBeExchange(currentObjLife);
					foreach (var item in targets)
					{
						canBeSelected.Add(item);
						item.ShowTargetTips(RoleRelationType.友方);
					}
				}
				break;
			case PanelClickType.跳过回合:
				if (IsBattling)
				{
					isExchange = false;
					IsResponseRole = false;

					roleInfoView.TriggerSelectedImg(PanelClickType.跳过回合, true);
					CloseAllObjTargetTips();
				}
				break;
			case PanelClickType.跳过回合确定:
				IsResponsePanel = false;
				IsResponseRole = false;

				roleInfoView.TriggerSelectedImg(PanelClickType.跳过回合确定);
				roleInfoView.CloseAllSelected();
				onJumpRoundAct?.Invoke();
				
				break;
			case PanelClickType.跳过回合取消:
				roleInfoView.TriggerSelectedImg(PanelClickType.跳过回合取消);
				roleInfoView.CloseAllSelected();
				break;
		}
	}
	/// <summary>
	/// 换位技能响应按键
	/// </summary>
	public void TranspositionSkillOfKeyDown()
	{
		PanelClickEvent(PanelClickType.换位);
	}


	#endregion


	#region 音频
	/// <summary>
	/// 音频
	/// </summary>
	protected string audioName;
	public void PlayUseObjItemAudio(int objId)
	{
		switch (objId)
		{
			case 6001: AudioManager.Instance.PlayAudio(AudioName.EAT_Apple_Chewing_Closed_Mouth_x4_loop_mono, AudioType.BattleCommon); break;
			case 6002:
			case 6003: AudioManager.Instance.PlayAudio(AudioName.EAT_Chew_3_Times_mono, AudioType.BattleCommon); break;
			case 6004: AudioManager.Instance.PlayAudio(AudioName.EAT_Swallow_mono, AudioType.BattleCommon); break;
			case 10001:
			case 10002:
			case 10003:
			case 10004:
			case 10005:
			case 10006:
			case 10007:
				AudioManager.Instance.PlayAudio(AudioName.EAT_Chew_3_Times_mono, AudioType.BattleCommon); break;
			default: AudioManager.Instance.PlayAudio(AudioName.EAT_Chew_3_Times_mono, AudioType.BattleCommon); break;
		}
	}

	public void PlayFightMapBgm()
	{
		switch (BattleInfo.MapName)
		{
			case MapNameType.镂空之地:
				AudioManager.Instance.PlayMusic(AudioName.LouKongZhiDiBGM);
				break;
			case MapNameType.冥河矿洞:
				AudioManager.Instance.PlayMusic(AudioName.MingHeKuangDongBGM);
				break;
			case MapNameType.教程关卡:
				AudioManager.Instance.PlayMusic(AudioName.MazeBGM);
				break;
		}
	}

	#endregion

}

