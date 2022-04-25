using Datas;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using GEvent;
using UnityEngine.AddressableAssets;

/// <summary>
/// 角色招募功能
/// </summary>
public class RecruitingHeros : BuildPanelBase
{
    public Transform panelRoot;

    #region 旧代码，先留着
    Dictionary<int, RoleData> heroDict = new Dictionary<int, RoleData>();
    List<RoleData> heroDatas = new List<RoleData>();

    //英雄招募建筑信息
    public string buildingName;
    public ExtendBoxEquip heroRecruit, heroStore;
    private List<BuildingLevelGroup> buildingLvGroups;
    private RecruitBuildingMode buildingMode;

    public RoleInfo roleInfoPanel;

    public GameObject roleItem;
    public Transform box;
    //头像
    public Image hero_icon;


    int[] randomTeam = new int[2];
    Dictionary<RoleItem, int> heroIndexDic = new Dictionary<RoleItem, int>();
    List<int> teamsI = new List<int>();
    List<GameObject> heroTeam = new List<GameObject>();

    private RectTransform panelRect;
    private bool isFading;

    //Transform OnDrag;



    private RectTransform PanelRect
    {
        get
        {
            if (panelRect == null)
                panelRect = GetComponent<RectTransform>();
            return panelRect;
        }
    }

    //重置招募信息
    //void ResetRecuitInfo()
    //{
    //    ClearTeam();
    //    heroIndexDic.Clear();
    //    //战斗归来刷新，否则读取存档
    //    if (Camp.backFromBattle)
    //    {
    //        GetRandomSequence(true);
    //        buildingMode.heroModes.Clear();
    //        for (int i = 0; i < randomTeam.Length; i++)
    //        {
    //            if (randomTeam[i] >= heroDatas.Count)
    //                continue;
    //            RoleData heroData = heroDatas[randomTeam[i]];

    //            GameObject go = Instantiate(roleItem, box);
    //            RoleItem _roleItem = go.GetComponent<RoleItem>();
    //            heroTeam.Add(go);

    //            heroIndexDic.Add(_roleItem, i);

    //            HeroMode herosMode = new HeroMode();
    //            herosMode.heroId = heroData.id;

    //            if (heroData.vocation == HeroVocation.双面间谍)
    //            {
    //                herosMode.heroName = heroData.name;
    //            }
    //            else
    //            {

    //            }

    //            List<int> randomSkill = new List<int>(heroData.roleHaveSkill);
    //            int randomCount = randomSkill.Count - 4;

    //            for (int n = 0; n < randomCount; n++)
    //            {
    //                int index = Random.Range(0, randomSkill.Count);

    //                randomSkill.Remove(randomSkill[index]);
    //            }

    //            herosMode.skillModes = new List<SkillMode>();
    //            foreach (var item in heroData.roleHaveSkill)
    //            {
    //                SkillMode skillMode = new SkillMode();
    //                skillMode.skillId = item;


    //                if (heroData.vocation == HeroVocation.双面间谍)
    //                {
    //                    skillMode.level = 1;
    //                    skillMode.isUse = true;
    //                }
    //                else
    //                {
    //                    //取4个不重复的值,将他们设置为level1，其他的0,
    //                    skillMode.level = 0;
    //                    foreach (int t in randomSkill)
    //                    {
    //                        if (t == item)
    //                        {
    //                            skillMode.level = 1;
    //                            skillMode.isUse = true;
    //                        }
    //                    }
    //                }

    //                herosMode.skillModes.Add(skillMode);

    //            }

    //            _roleItem.InitItem(new HeroEquipment(), heroData, herosMode);

    //            buildingMode.heroModes.Add(herosMode);
    //        }
    //    }
    //    else
    //    {
    //        for (int i = 0; i < buildingMode.heroModes.Count; i++)
    //        {

    //            RoleData heroData = heroDatas.Find(h => h.id == buildingMode.heroModes[i].heroId);
    //            if (heroData == null)
    //                continue;

    //            GameObject go = Instantiate(roleItem, box);
    //            RoleItem _roleItem = go.GetComponent<RoleItem>();
    //            heroTeam.Add(go);

    //            heroIndexDic.Add(_roleItem, i);

    //            _roleItem.InitItem(new HeroEquipment(), heroData, buildingMode.heroModes[i]);
    //        }
    //    }
    //    //ListenerItemClick();
    //}

    //void ListenerItemClick()
    //{
    //    foreach (var item in heroTeam)
    //    {
    //        UIEventManager.AddTriggersListener(item).onLeftClick += ItemLeftClick;
    //        UIEventManager.AddTriggersListener(item).onRightClick += ItemRightClick;
    //        UIEventManager.AddTriggersListener(item).onDrag += ItemOnDrag;
    //        UIEventManager.AddTriggersListener(item).onEndDrag += ItemOnEndDrag;
    //    }
    //}

    //void RemoveListenerItem(GameObject item)
    //{
    //    UIEventManager.AddTriggersListener(item).onLeftClick -= ItemLeftClick;
    //    UIEventManager.AddTriggersListener(item).onRightClick -= ItemRightClick;
    //    UIEventManager.AddTriggersListener(item).onDrag -= ItemOnDrag;
    //    UIEventManager.AddTriggersListener(item).onEndDrag -= ItemOnEndDrag;
    //}

    //显示角色信息--跳转至
    //void ItemLeftClick(GameObject go)
    //{
    //    //点击不处理,只处理拖拽

    //}

    //void ItemRightClick(GameObject go)
    //{
    //    RoleItem role = go.GetComponent<RoleItem>();
    //    roleInfoPanel.ShowMe(role, null);


    //}

    //RectTransform ItemOnDrag(GameObject go, PointerEventData eventData)
    //{

    //    RoleItem onDragRole = go.GetComponent<RoleItem>();
    //    RectTransform rectTransform = onDragRole.Icon.GetComponent<RectTransform>();
    //    //rectTransform.SetParent(OnDrag);
    //    return rectTransform;
    //}

    //void ItemOnEndDrag(GameObject go, PointerEventData eventData)
    //{

    //    RoleItem roleItem = go.GetComponent<RoleItem>();
    //    roleItem.Icon.transform.SetParent(roleItem.iconBox);
    //    roleItem.Icon.transform.localPosition = Vector3.zero;

    //    if (eventData.pointerEnter != null)
    //    {
    //        if (eventData.pointerEnter.tag == "Camp" || eventData.pointerEnter.transform.parent.tag == "Camp")
    //        {

    //            if (Camp.Instance.heroTeam.Count >= heroStore.extendNums[buildingMode.equipLvs[1]])
    //            {
    //                Debug.Log("营地满了");
    //                return;
    //            }

    //            buildingMode.heroModes.RemoveAt(heroIndexDic[roleItem]);
    //            heroIndexDic.Remove(roleItem);

    //            Camp.Instance.ReceiveRole(roleItem);
    //            heroTeam.Remove(roleItem.gameObject);
    //            Destroy(roleItem.gameObject);

    //            //更新酒馆中英雄列表的索引
    //            List<RoleItem> riList = new List<RoleItem>();
    //            foreach (var key in heroIndexDic.Keys)
    //            {
    //                riList.Add(key);
    //            }
    //            for (int i = 0; i < riList.Count; ++i)
    //            {
    //                heroIndexDic[riList[i]] = i;
    //            }
    //        }
    //    }
    //}

    ////清空队伍
    //void ClearTeam()
    //{
    //    foreach (var item in heroTeam)
    //    {
    //        Destroy(item);
    //    }
    //    heroTeam.Clear();
    //}

    //取随机数组--不重复随机
    //void GetRandomSequence(bool repeatable = false)
    //{
    //    for (int i = 0; i < heroDatas.Count; i++)
    //    {
    //        teamsI.Add(i);
    //    }

    //    for (int i = 0; i < randomTeam.Length; i++)
    //    {
    //        int index = Random.Range(0, teamsI.Count);
    //        randomTeam[i] = teamsI[index];
    //        if (!repeatable)
    //            teamsI.Remove(teamsI[index]);
    //    }

    //    teamsI.Clear();
    //}

    #endregion







    public GameObject goRecrultRoleItem;
    public GameObject goBox;

    public RoleInfoPanel roleInfoPanelN;

    public Text hintText;

    private List<GameObject> goHeros = new List<GameObject>();

    Vector3 icoPos;
    Transform icoParent;
    HoverInfoUI iconHover;

    Vector2 originPos;

    /// <summary>
    /// 酒馆英雄刷新数量
    /// </summary>
    private const int REFRESH_COUNT = 2;

    public Text topTips;
    public Text notManTips;

    private void Start()
    {
        originPos = panelRoot.GetComponent<RectTransform>().anchoredPosition;
        BuildPanelMag.Instance.addBuild(this);
        hintText.gameObject.SetActive(false);
        init();

        /*DataSetItem data = DataManager.Instance.GetData("RoleData");
        RoleDataSet roleData = data.scriptableObject as RoleDataSet;
        heroDatas = roleData.heroData;

        foreach (var item in heroDatas)
        {
            heroDict.Add(item.id, item);
        }

        ResetRecuitInfo();*/
    }

    private void EquipLvUp(EquipType equipType, int costRes1, int costRes2)
    {
        if (equipType == EquipType.HeroRecruiting)
        {
            buildingMode.equipLvs[0]++;
        }
        if (equipType == EquipType.HeroStore)
        {
            buildingMode.equipLvs[1]++;
            Camp.Instance.setHeroCount(heroStore.extendNums[buildingMode.equipLvs[1]]);
        }
        ResPanel.Instance.ChangeResource(0, 0, -costRes1, -costRes2);
        for (int i = 0; i < buildingLvGroups.Count; i++)
        {
            buildingLvGroups[i].UpdateGroup(ResPanel.Instance.Fruit, ResPanel.Instance.LightStone);
        }
        //randomTeam = new int[heroRecruit.extendNums[buildingMode.equipLvs[0]]];
    }

    /// <summary>
    /// 弃用
    /// 随机刷新英雄
    /// </summary>
    private void RefreshRandomHeros()
    {
        Debug.Log("=============================================");
        hintText.gameObject.SetActive(false);
        foreach (var item in goHeros)
        {
            Destroy(item);
        }
        goHeros.Clear();

        List<int> heroIds;
        Debug.Log(Camp.Instance);
        Debug.Log(Camp.Instance.getObjLifeData());
        if (Camp.Instance.getObjLifeData().Count > 0)
            heroIds = DataManager.Instance.GetHeroIdRandom(heroRecruit.extendNums[buildingMode.equipLvs[0]]);
        else
            heroIds = DataManager.Instance.GetHeroIdRandom(4);

        buildingMode.heroIds = heroIds;
        List<ObjLifeData> objLifeDatas = DataManager.Instance.GetObjLifeDatasByIds(heroIds);

        foreach (var obj in objLifeDatas)
        {
            obj.SetMorale(ObjLife.FirstMorale);
            obj.SetTalentMode(DataManager.Instance.CreateTalentMode());

            if (obj.GetVocation() == HeroVocation.双面间谍)
            {
                foreach (var skill in obj.GetSkillModes())
                {
                    skill.isUse = true;
                }
            }
            else
            {
                for (int i = 0; i < 4; ++i)
                {
                    obj.GetSkillModes()[i].isUse = true;
                }
            }

            InitHero(obj);
        }
    }


    /// <summary>
    /// 随机刷新英雄
    /// </summary>
    private void RefreshLoadHeros()
    {
        Debug.Log("RefreshLoadHeros -----------");
        hintText.gameObject.SetActive(false);
        foreach (var item in goHeros)
        {
            Destroy(item);
        }
        goHeros.Clear();

        List<int> heroIds = buildingMode.heroIds;
        Debug.Log("heroIds = " + heroIds.Count);
        for (int i = 0; i < heroIds.Count; i++)
            Debug.Log("" + heroIds[i]);

        Debug.Log("heroIds  else  -----------");
        if (Camp.backFromBattle)
        {
            Debug.Log("Camp.backFromBattle -----------");
            if (Camp.Instance.getObjLifeData().Count > 0)
                heroIds = DataManager.Instance.GetHeroIdRandom(heroRecruit.extendNums[buildingMode.equipLvs[0]]);
            else
                heroIds = DataManager.Instance.GetHeroIdRandom(4);

            buildingMode.heroIds = heroIds;
        }
        else if (Camp.Instance.getObjLifeData().Count == 0)
        {
            heroIds = DataManager.Instance.GetHeroIdRandom(4);
            buildingMode.heroIds = heroIds;
        }

        List<ObjLifeData> objLifeDatas = DataManager.Instance.GetObjLifeDatasByIds(heroIds);

        foreach (var obj in objLifeDatas)
        {
            obj.SetMorale(ObjLife.FirstMorale);
            obj.SetTalentMode(DataManager.Instance.CreateTalentMode());

            if (obj.GetVocation() == HeroVocation.双面间谍)
            {
                foreach (var skill in obj.GetSkillModes())
                {
                    skill.isUse = true;
                }
            }
            else
            {
                for (int i = 0; i < 4; ++i)
                {
                    obj.GetSkillModes()[i].isUse = true;
                }
            }

            InitHero(obj);
        }
    }

    private void InitHero(ObjLifeData objLifeData)
    {
        GameObject goHero = Instantiate(goRecrultRoleItem, goBox.transform);
        objLifeData.GetIcon().LoadAssetAsync().Completed += go => goHero.GetComponent<RoleItem>().Icon.sprite = go.Result;
        goHero.GetComponent<RoleItem>()._name.text = objLifeData.GetVocation().ToString();
        goHeros.Add(goHero);

        UIEventManager.AddTriggersListener(goHero).onRightClick = go => roleInfoPanelN.Show(objLifeData, false, false, false, true);
        UIEventManager.AddTriggersListener(goHero).onLeftClick = go => RecruitHero(objLifeData, goHero);
        UIEventManager.OnDragFunc(goHero, (inGo, inEvent) =>
        {
            icoPos = goHero.GetComponent<RoleItem>().Icon.GetComponent<RectTransform>().localPosition;
            icoParent = goHero.GetComponent<RoleItem>().Icon.transform.parent;
            return goHero.GetComponent<RoleItem>().Icon.GetComponent<RectTransform>();
        });
        UIEventManager.AddTriggersListener(goHero).onEndDrag = (inGo, inEvent) =>
        {
            goHero.GetComponent<RoleItem>().Icon.transform.parent = icoParent;
            goHero.GetComponent<RoleItem>().Icon.GetComponent<RectTransform>().localPosition = icoPos;
            if (inEvent.pointerEnter != null)
            {
                if (inEvent.pointerEnter.tag == "Camp" || inEvent.pointerEnter.transform.parent.tag == "Camp")
                {
                    RecruitHero(objLifeData, goHero);
                }
            }
        };
    }

    /// <summary>
    /// 招募英雄
    /// </summary>
    /// <param name="objLifeData"></param>
    /// <param name="goHero"></param>
    private void RecruitHero(ObjLifeData objLifeData, GameObject goHero)
    {
        if (Camp.Instance.RecruitHero(objLifeData))
        {
            NewbieGuideMag.Instance.triggerGuide(GuideDataSet.guideEnum.RecruitingHeros);
            AudioManager.Instance.PlayAudio(AudioName.Drag_Recruit_Hero_mono, AudioType.Common);
            goHeros.Remove(goHero);
            Destroy(goHero);

            if (goHeros.Count == 0) hintText.gameObject.SetActive(true);
            Debug.Log("" + objLifeData.GetId());
            buildingMode.heroIds.Remove(objLifeData.GetId());
        }
    }


    void setLvGroupHover(BuildingLevelGroup inLvGroup, string inString)
    {
        var tempEvent = UIEventManager.AddTriggersListener(inLvGroup.transform.Find("Icon").gameObject);
        tempEvent.onEnter = (inGo) =>
        {
            iconHover = inLvGroup.transform.Find("Icon").GetComponentInChildren<HoverInfoUI>(true);
            iconHover.AddItem(inString, 0, Color.white);
            iconHover.Show();
            iconHover.transform.SetParent(transform.root, true);
            iconHover.transform.SetAsLastSibling();
        };

        tempEvent.onExit = (inGo) =>
        {
            iconHover.Hide();
            iconHover.transform.SetParent(inLvGroup.transform.Find("Icon"), true);
        };
    }


    public override void init()
    {
        base.init();

        DataSetItem buildData = DataManager.Instance.GetData("BuildData");
        BuildDataSet buildDataSet = buildData.scriptableObject as BuildDataSet;
        heroRecruit = buildDataSet.recruitEquip1;
        heroStore = buildDataSet.recruitEquip2;
        ModeData modeData = DataManager.Instance.modeData;
        buildingMode = modeData.recruitBuildingMode;
        if (modeData.recruitBuildingMode.equipLvs.Count < 2)
        {
            buildingMode.equipLvs = new List<int>(new int[2]);
        }
        //OnDrag = GameObject.Find("OnDrag").transform;
        if (buildingLvGroups == null)
        {
            Transform container = panelRoot.Find("buildingUpBox");
            buildingLvGroups = new List<BuildingLevelGroup>(container.GetComponentsInChildren<BuildingLevelGroup>(true));
            //初始化建筑数据
            for (int i = 0; i < buildingLvGroups.Count; i++)
            {
                buildingLvGroups[i].OnEquipLvUp += EquipLvUp;
                if (buildingLvGroups[i].equipType.Equals(EquipType.HeroRecruiting))
                {
                    buildingLvGroups[i].InitialLevelGroup(buildingMode.equipLvs[0], ResPanel.Instance.Fruit, ResPanel.Instance.LightStone, heroRecruit);
                    setLvGroupHover(buildingLvGroups[i], LanguageController.GetValue("增加英雄列表上限"));
                }
                if (buildingLvGroups[i].equipType.Equals(EquipType.HeroStore))
                {
                    buildingLvGroups[i].InitialLevelGroup(buildingMode.equipLvs[1], ResPanel.Instance.Fruit, ResPanel.Instance.LightStone, heroStore);
                    setLvGroupHover(buildingLvGroups[i], LanguageController.GetValue("增加可招募英雄数量，该增加将在下次任务结束后生效"));
                }
            }
            Camp.Instance.setHeroCount(heroStore.extendNums[buildingMode.equipLvs[1]]);
        }

        topTips.text = LanguageController.GetValue("残骸旅社");
        notManTips.text = LanguageController.GetValue("营地已无可招募人员，等到下一次放逐后再来进行招募吧");
    }

    public override void mainLoop()
    {
        base.mainLoop();
    }

    public override void RefreshData()
    {
        base.RefreshData();
        //RefreshRandomHeros();
        RefreshLoadHeros();
    }

    public override void open()
    {
        if (!isFading)
        {
            NewbieGuideMag.Instance.triggerGuide(GuideDataSet.guideEnum.openRecruitingHeros);
            base.open();
            isFading = true;
            panelRoot.GetComponent<RectTransform>().anchoredPosition = originPos;
            panelRoot.gameObject.SetActive(true);
            PanelRect.localScale = Vector3.zero;
            PanelRect.DOScale(Vector3.one, 0.3f).onComplete = () => isFading = false;
            //init();
            //RefreshRandomHeros();
        }

    }

    public override void close()
    {
        if (!isFading)
        {
            base.close();
            isFading = true;
            PanelRect.DOScale(Vector3.zero, 0.15f).onComplete = () => { isFading = false; panelRoot.gameObject.SetActive(false); };
        }
    }
}


