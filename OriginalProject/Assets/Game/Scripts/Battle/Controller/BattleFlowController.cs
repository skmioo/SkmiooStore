#define Cinemachine
//#define CameraScheme1
//#define CameraScheme2
using Datas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// 战斗流程控制器
/// 战斗逻辑及测试相关
public class BattleFlowController : BattleFlowRoleController_Hero
/// </summary>
{
	static BattleFlowController _instance;
	public static BattleFlowController Instance { get { return _instance; } }
	private void Awake()
	{
		_instance = this;
		initTestTimeData();
		TownInfo.ClearRescueType();
		newRound = NewRound;
		onFightAnimEndAct = Next;
		endBattleAct = EndBattleing;
	}

	/// <summary>
	/// 检测是否开始战斗以及检测存在怪物召唤的情况下角色的切换
	/// </summary>
	private void Update()
	{
		//  if (Input.GetKeyDown(KeyCode.M)) RoleTeamBoxSizeCalculate();
		if (insFinish.All(s => s)) ///所有都为true
		{
			Debug.Log($"测试-Update-insFinish-{roleType}");
			CheckBattleStart();
		}

		if (summonFinish.All(s => s))
		{
			for (int i = 0; i < summonFinish.Length; ++i)
			{
				summonFinish[i] = false;
			}
			FindSpeedMaxFromActionList();
		}

	}

	#region 战斗主要逻辑

	/// <summary>
	/// 检测战斗是否开始
	/// </summary>
	private void CheckBattleStart()
	{
		if (roleType.Equals(RoleType.英雄))
		{

			for (int i = 0; i < insFinish.Length; ++i)
			{
				insFinish[i] = false;
			}
			herosTeam.InitFinish();
			SelectRole(herosTeam.GetObjLife(0), false);
		}
		else
		{
			for (int i = 0; i < insFinish.Length; ++i)
			{
				insFinish[i] = false;
			}
			monsterTeam.InitFinish();
			StartBattle();
		}
	}


	/// <summary>
	/// 是否在攻击中
	/// </summary>
	// private bool isAttacking = false;
	/// <summary>
	/// 开始战斗
	/// </summary>
	private void StartBattle()
	{
		Debug.Log("测试-StartBattle");
		onBattleStart();
		//开始第一个回合
		FindSpeedMaxFromActionList();

#if CameraScheme1 || Cinemachine
#elif CameraScheme2
        List<ObjLife> list = herosTeam.GetObjLifes();
        list.AddRange(herosTeam.GetObjLifes());
        for (int i = 0; i < list.Count; ++i) list[i].UpdateSortingLayer(FightingCameraCon.FightingCameraLayerName);
#endif

	}

	#region 开始战斗
	/// <summary>
	/// 调用的函数必须继承BattleFlowUIController
	/// </summary>
	protected void onBattleStart()
	{
		onLogicBattleStart();
		onUIBattleStart();
	}

	#endregion

	#region 战斗新回合 NewRound

	/// <summary>
	/// 调用的函数必须继承BattleFlowUIController
	/// </summary>
	protected void onBattleNewRound()
	{
		onLogicBattleNewRound();
		onUIBattleNewRound();
	}

	#endregion
	#region 结束战斗
	/// <summary>
	/// 调用的函数必须继承BattleFlowUIController
	/// </summary>
	protected void EndBattleing(bool win)
	{
		onLogicBattleEnd(win);
		onUIBattleEnd(win);
	}
	#endregion

	#endregion


	#region 部分弃用的旧逻辑

	/// <summary>
	/// 谁正在控制,true = 怪物正在控制
	/// </summary>
	public bool whoTheControl;

    /// <summary>
    /// 是否在战斗中，true = 在战斗中
    /// </summary>
    bool battleing;


    /// <summary>
    /// 战斗中状态
    /// </summary>
    public bool currentBattleing
    {
        get { return battleing; }
        set
        {
            if (value != battleing)
            {
                battleing = value;
                Battle?.Invoke(battleing);
            }
        }
    }


	#endregion

	#region 回合

	/// <summary>
	/// 新的回合
	/// </summary>
	void NewRound()
	{
		Debug.Log("测试-NewRound");
		//新回合的行动点更新 
		//新回合的actionList更新
		onBattleNewRound();

		if (!SummonDelayTakeEffect()) //如果有召唤，则等待角色加载完成后由Update调用
		{
			FindSpeedMaxFromActionList(true);
		}
	}

	protected void Next()
	{
		Debug.Log("测试-AniEnd");
		if (IsBattling)
		{
			SummonImmediateTakeEffect();
			TailTakeEffect(tailPacks);
			BuffTakeEffect(buffPacks);
			//xl 303 释放治疗技能
			if (currentSkill != null && currentSkill.skillType == SkillType.治疗)
			{
				currentObjLife.TalentTrigger(TalentTriggerType.释放治疗技能);
			}
			DeathDecide();
		}
		else
		{
			IsResponsePanel = true;
			IsResponseRole = true;
			DeathDecide();
		}
		//isAttacking = false;

		RefreshBattleActNumInfo();
	}
	#endregion

	//public float YTest = 1f;
	#region 战斗开始结束控制模块

	/// <summary>
	/// 撤退
	/// </summary>
	public void ExitBattle()
    {
        isExitBallte = true;

        foreach (var obj in monsterTeam.GetObjLifes())
        {
            obj.SetHp(0);
        }
        //  if (!isAttacking)
        DeathDecide();
    }

    /// <summary>
    /// 撤退失败
    /// </summary>
    public void ExitBattleFail()
    {
        IsResponsePanel = false;
        IsResponseRole = false;

        roleInfoView.CloseAllSelected();
        NotUseMoralSkill(currentObjLife);
        FindSpeedMaxFromActionList();
    }

    /// <summary>
    /// 是否允许移动
    /// </summary>
    public bool CheckCanMove()
    {
        if (IsBattling || IsInteracting || IsFightFail)
            return false;

        return true;
    }


	#endregion

	#region 指定角色行动模块
	
    /// <summary>
    /// 非战斗状态下回合更新
    /// </summary>
    public void UpdateRound()
    {
        foreach (var obj in herosTeam.GetObjLifes())
        {
            obj.BuffTakeEffect();
        }
        DeathDecide(false);
    }

	#endregion

	#region 按键响应
	/// <summary>
	/// 按键响应  切换到下一个英雄
	/// </summary>
	public void SwitchNextHeroOfKeyDown()
	{
		if (currentObjLife == null) return;
		if (IsBattling) return;
		int curIndex = herosTeam.GetIndex(currentObjLife);
		int count = herosTeam.GetCount();
		curIndex++;
		if (curIndex >= count) curIndex = 0;
		SelectRole(herosTeam.GetObjLife(curIndex), false);
	}
	/// <summary>
	/// 按键响应  切换到上一个英雄
	/// </summary>
	public void SwitchLastHeroOfKeyDown()
	{
		if (currentObjLife == null) return;
		if (IsBattling) return;
		int curIndex = herosTeam.GetIndex(currentObjLife);
		int count = herosTeam.GetCount();
		curIndex--;
		if (curIndex < 0) curIndex = count - 1;
		SelectRole(herosTeam.GetObjLife(curIndex), false);
	}

	#endregion


    #region 交互物处理模块

    /// <summary>
    /// 是否交互中
    /// </summary>
    public bool IsInteracting { get; set; } = false;

    /// <summary>
    /// 营救事件触发
    /// </summary>
    /// <param name="rescue"></param>
    public void RescueTrigger(InteractiveRescue rescue, bool isFight)
    {
        if (isFight)
        {
            List<int> monsterIds;
            if (rescue.monsterIds == null || rescue.monsterIds.Count <= 0)
            {
                monsterIds = DataManager.Instance.GetMonsterIdsRandom(MapController.Instance.GetMapName());
            }
            else
            {
                monsterIds = rescue.monsterIds;
            }
            var datas = DataManager.Instance.GetMonsterSeniorDatas(monsterIds, MapController.Instance.GetTaskDifficulty());

            List<ObjLifeData> heros = GetHeros();
            List<ObjPermanentBuff> buff = heros.Count <= 0 ? new List<ObjPermanentBuff>() : heros[0].FindPermanentBuff(ObjBuffType.解救的战斗胜利后也可获得增益效果);
            if (buff.Count > 0) TownInfo.AddRescueType(rescue.rescueType);
            EncounterEnemy(datas);
        }
        else
        {
            if (rescue.rescueType == RescueType.矿工)
            {
                mapController.UnlockMiniMap();
            }
            else
            {
                TownInfo.AddRescueType(rescue.rescueType);
            }

            roleInfoView.RescueBuff(rescue.describe);
        }


    }

    /// <summary>
    /// 生命限制判断
    /// </summary>
    /// <returns></returns>
    public bool IsPassHpLimit(int hpLimit)
    {
        foreach (var obj in herosTeam.GetObjLifes())
        {
            if (obj.GetHp() < hpLimit)
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// 献祭减少生命
    /// </summary>
    /// <param name="min"></param>
    /// <param name="max"></param>
    public void ReduceHpFromSacrifice(int min, int max)
    {
        foreach (var obj in herosTeam.GetObjLifes())
        {
            int roll = UnityEngine.Random.Range(min, max + 1);
            obj.UpdateHp(-roll);
        }
    }

    #endregion


	#region 测试代码


    public void Test1()
    {
		currentObjLife.UpdateMorale(10, "手动");
    }

    public void Test5()
    {
        List<ObjLife> heros = herosTeam.GetObjLifes();
        foreach(var hero in heros)
        {
            UnityEngine.Debug.Log("test get moral: " + hero.GetHeroName() + "  " + hero.GetMorale());
        }
    }

    public void Test2()
    {
		currentObjLife.UpdateMorale(-10, "手动");
    }
    /// <summary>
    /// 调试面板-杀死所有的怪物
    /// </summary>
    public void Test3()
    {
        foreach (var obj in monsterTeam.GetObjLifes())
        {
            obj.SetHp(0);
        }
        //if (!isAttacking)
        DeathDecide();
    }
    public bool isTest4 = false;
    /// <summary>
    /// 关于粘稠圣者 技能释放卡死专项测试
    /// </summary>
    public void Test4()
    {
        isTest4 = !isTest4;
        if (isTest4) Debug.Log("必定遇到粘稠圣者");
    }

	public void TestAddHP()
	{
		currentObjLife.UpdateHp(5);
	}

	public void TestDelHP()
	{
		currentObjLife.UpdateHp(-5);
	}

	public TestEnemySkillPanel testEnemySkillPanel;
	/// <summary>
	/// 怪物boss测试
	/// </summary>
	public void TestEnemySkill()
	{
		testEnemySkillPanel.gameObject.SetActive(true);
	}

	/// <summary>
	/// 测试用 boss是否跳过回合
	/// </summary>
	/// <returns></returns>
	public bool IsEnemySkipRound()
	{
		return testEnemySkillPanel.IsSkipRound();
	}

	/// <summary>
	/// 显示怪物的技能
	/// </summary>
	/// <param name="objLife"></param>
	public void ShowEnemySkill(ObjLife objLife, Action onNormalMonsterGo)
	{
		testEnemySkillPanel.ShowEnemySkill(objLife, onNormalMonsterGo);
	}

	/// <summary>
	/// 技能是否可用
	/// </summary>
	/// <param name="objLife"></param>
	/// <param name="skillData"></param>
	/// <returns></returns>
	public bool EnemyCanUseSkill(ObjLife objLife, SkillData skillData)
	{
		return testEnemySkillPanel.EnemyCanUseSkill(objLife, skillData);
	}

	public bool IsEnemySkillTest()
	{
		return testEnemySkillPanel && TestEnemySkillPanel.isTestEnemySkill;
	}

	#endregion

	#region 测试gui

	float show;
	float fight;
	float end;
	float start;
	float endtime;
	/// <summary>
	/// 测试时间数值
	/// </summary>
	void initTestTimeData()
	{
		show = ANI_SKILL_SHOW_TIME;
		fight = ANI_FIGHTING_TIME;
		end = ANI_END_TIME;
		start = ANI_START_TIME;
		endtime = DEATH_DECIDE_TIME;
	}

	//测试gui
	bool openwindow = false;
	bool jiakuai_btn = false;
	float jiakuai = 0.2f;
	int hp;
	string roll_str = "";

	private void OnGUI()
	{
		string name = "";


		if (currentObjLife != null)
		{
			name = currentObjLife.name;

		}
		if (GUI.Button(new Rect(100, 100, 100, 20), "测试"))
		{
			openwindow = !openwindow;
		}
		if (openwindow)
		{
			GUI.Label(new Rect(100, 130, 100, 20), "当前英雄是:");
			GUI.Label(new Rect(200, 130, 100, 20), name);
			if (GUI.Button(new Rect(100, 150, 100, 20), "加快/还原"))
			{
				jiakuai_btn = !jiakuai_btn;
				if (jiakuai_btn)
				{
					ANI_SKILL_SHOW_TIME = jiakuai;
					ANI_FIGHTING_TIME = jiakuai;
					ANI_END_TIME = jiakuai;
					ANI_START_TIME = jiakuai;
					DEATH_DECIDE_TIME = jiakuai;
				}
				else
				{
					ANI_SKILL_SHOW_TIME = show;
					ANI_FIGHTING_TIME = fight;
					ANI_END_TIME = end;
					ANI_START_TIME = start;
					DEATH_DECIDE_TIME = endtime;
				}

			}
			GUI.Label(new Rect(100, 170, 300, 20), "设置当前英雄血量");

			hp = (int)GUI.HorizontalSlider(new Rect(120, 190, 100, 20), hp, 0, currentObjLife.GetMaxHp());
			GUI.Label(new Rect(100, 190, 20, 20), hp.ToString());
			if (GUI.Button(new Rect(100, 210, 100, 20), "确认"))
			{
				currentObjLife.SetHp((int)hp);
				ResetPanelInBattle(currentObjLife);
			}
			roll_str = GUI.TextField(new Rect(200, 240, 100, 20), roll_str);
			if (GUI.Button(new Rect(100, 240, 100, 20), "设置roll值"))
			{
				roll_test = int.Parse(roll_str);
			}

		}

	}
	#endregion
}
