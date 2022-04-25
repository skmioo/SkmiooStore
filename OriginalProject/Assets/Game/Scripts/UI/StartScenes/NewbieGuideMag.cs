using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewbieGuideMag : MonoSingleton<NewbieGuideMag>
{
    public GuideDataSet guideData;

    public GameObject originConfirmItem;
    GameObject confirmItem;

    //记录这个教程是否显示过
    Dictionary<GuideDataSet.guideEnum, bool> guideDic = new Dictionary<GuideDataSet.guideEnum, bool>();
    Dictionary<GuideDataSet.guideEnum, GuideDataSet.guideStruct> guideStringDic = new Dictionary<GuideDataSet.guideEnum, GuideDataSet.guideStruct>();

    System.Action confirmEvent;
    bool isGuide = false;

    void Start()
    {
        initGuideDic();

        confirmItem = Instantiate(originConfirmItem);
        confirmItem.transform.parent = transform;
        confirmItem.transform.localPosition = Vector3.zero;
        confirmItem.GetComponentInChildren<UnityEngine.UI.Button>().onClick.AddListener(confirmButton);
        confirmItem.SetActive(false);
    }

    /// <summary>
    /// 开始教程
    /// </summary>
    public void startGuide()
    {
        setMapData();

        GameScenesController.Instance.GoLoadScenes(2);
        Camp.backFromBattle = false;
        GEvent.EventHelper.Instance.ExcuteEvent(GEvent.GEventType.GoBattle, null);
        GEvent.EventHelper.Instance.ClearEvents();
		TestEnemySkillPanel.isTestEnemySkill = false;
        isGuide = true;
    }

    /// <summary>
    /// 触发教程
    /// </summary>
    /// <param name="inType"></param>
    public void triggerGuide(GuideDataSet.guideEnum inType) { if (isGuide) guideLogic(inType); }

    /// <summary>
    /// 教程逻辑
    /// </summary>
    /// <param name="inType"></param>
    void guideLogic(GuideDataSet.guideEnum inType)
    {
        if (guideDic.ContainsKey(inType))
            if (!guideDic[inType])
            {
                confirmItem.SetActive(true);
                var tempText = confirmItem.transform.Find("Back").Find("confirmText").GetComponent<UnityEngine.UI.Text>();
                var tempTitle = confirmItem.transform.Find("TopBack").Find("Top").GetComponent<UnityEngine.UI.Text>();
                var tempImage = confirmItem.transform.Find("Image").GetComponent<UnityEngine.UI.Image>();

                tempText.text = guideStringDic[inType].guideString;
                tempTitle.text = guideStringDic[inType].guideTitle;
                tempImage.sprite = guideStringDic[inType].guideTex == null ? null : guideStringDic[inType].guideTex;
                guideDic[inType] = true;

                //个别行为逻辑
                switch (inType)
                {
                    case GuideDataSet.guideEnum.nothing:
                        break;
                    case GuideDataSet.guideEnum.inMap:
                        break;
                    case GuideDataSet.guideEnum.move:
                        break;
                    case GuideDataSet.guideEnum.selectRoom:
                        break;
                    case GuideDataSet.guideEnum.inBattle:
                        break;
                    case GuideDataSet.guideEnum.trophy:
                        break;
                    case GuideDataSet.guideEnum.missionFinish:
                        break;
                    case GuideDataSet.guideEnum.openRecruitingHeros:
                        confirmEvent = () =>
                        {
                            confirmEvent = null;
                            guideLogic(GuideDataSet.guideEnum.closeRecruitingHeros);
                        };
                        break;
                    case GuideDataSet.guideEnum.closeRecruitingHeros:
                        break;
                    case GuideDataSet.guideEnum.inGoBattle:
                        break;
                    case GuideDataSet.guideEnum.medal:
                        break;
                    case GuideDataSet.guideEnum.skillUp:
                        break;
                    case GuideDataSet.guideEnum.rollMedal:
                        break;
                    case GuideDataSet.guideEnum.heal:
                        break;
                    case GuideDataSet.guideEnum.morale:
                        break;
                    case GuideDataSet.guideEnum.moraleSkill:
                        break;
                    case GuideDataSet.guideEnum.relic:
                        break;
                    case GuideDataSet.guideEnum.interaction:
                        break;
                    case GuideDataSet.guideEnum.RecruitingHeros:
                        break;
                    case GuideDataSet.guideEnum.NearDeath:
                        break;
                    case GuideDataSet.guideEnum.morale100:
                        break;
                    case GuideDataSet.guideEnum.morale10:
                        break;
                    case GuideDataSet.guideEnum.secondGoBattle:
                        break;
                    case GuideDataSet.guideEnum.randomBoss:
                        break;
                    case GuideDataSet.guideEnum.fixedBoss:
                        break;
                }
            }
    }

    /// <summary>
    /// 初始化字典
    /// </summary>
    void initGuideDic()
    {
        for (int i = 0; i < guideData.guideAry.Length; i++)
        {
            guideDic.Add(guideData.guideAry[i].guideType, false);
            guideStringDic.Add(guideData.guideAry[i].guideType, guideData.guideAry[i]);
        }
    }

    /// <summary>
    /// 写教程地图数据
    /// </summary>
    void setMapData()
    {
        setHeroData();
        BattleInfo.MapName = MapNameType.教程关卡;
       // BattleInfo.TaskType.Clear();
       // BattleInfo.TaskType.Add(N_TaskType.固定boss);//BattleInfo.TaskType = N_TaskType.固定boss;
        //BattleInfo.TaskDifficulty = TaskDifficulty.人迹罕至;
        //BattleInfo.TaskType = N_TaskType.侦查;
    }

    /// <summary>
    /// 写英雄数据
    /// </summary>
    void setHeroData()
    {
        List<int> heroIds;
		//heroIds = DataManager.Instance.GetHeroIdRandom(2);
		heroIds = new List<int> { 1002, 1003 };
		ObjLifeData tempData;

        BattleInfo.waitingTeams.Clear();

        for (int i = 0; i < heroIds.Count; i++)
        {
            tempData = DataManager.Instance.GetObjLifeDataById(heroIds[i]);
            tempData.SetTalentMode(DataManager.Instance.CreateTalentMode());
            tempData.SetMorale(ObjLife.FirstMorale);

            if (tempData.GetVocation() == HeroVocation.双面间谍)
            {
                foreach (var skill in tempData.GetSkillModes())
                {
                    skill.isUse = true;
                }
            }
            else
            {
                for (int i2 = 0; i2 < 4; ++i2)
                {
                    tempData.GetSkillModes()[i2].isUse = true;
                }
            }

            tempData.SetNumInTeamWaiting(i);
            BattleInfo.waitingTeams.Add(i, tempData);
        }
    }

    void confirmButton()
    {
        confirmItem.SetActive(false);
        confirmEvent?.Invoke();
    }

}