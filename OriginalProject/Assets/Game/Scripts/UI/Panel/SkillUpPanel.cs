using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Datas;
using UnityEngine.UI;
using DG.Tweening;
using GEvent;

public class SkillUpPanel : BuildPanelBase
{
    public static SkillUpPanel instance;

    public Transform RootPanel;
    public Image heroIcon;
    public Text dragAreaText;
    public Text heroDescribText;
    public ExpEquip expEquip;
    public TrainSkillEquip trainSkillEquip;
    private Sprite defaultHeroIcon;
    private RoleData heroData;
    private HeroMode herosMode;
    private BuildingMode buildingMode;
    private Dictionary<int, SkillData> skillDataDic;
    private List<SkillLevelGroup> skillLvGroups;
    private List<BuildingLevelGroup> buildingLvGroups;
    private RectTransform panelRect;
    private bool isFading;
    private bool initialized = false;
    HoverInfoUI iconHover;
    Vector2 originPos;
    public List<SKillUpButton> skillUpList = new List<SKillUpButton>();

    public Text topTips;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        originPos = RootPanel.GetComponent<RectTransform>().anchoredPosition;
        BuildPanelMag.Instance.addBuild(this);
    }

    private RectTransform PanelRect
    {
        get
        {
            if (panelRect == null)
                panelRect = GetComponent<RectTransform>();
            return panelRect;
        }
    }

    public void Initial()
    {
        DataSetItem buildData = DataManager.Instance.GetData("BuildData");
        BuildDataSet buildDataSet = buildData.scriptableObject as BuildDataSet;
        expEquip = buildDataSet.skillUpEquip1;
        trainSkillEquip = buildDataSet.skillUpEquip2;
        skillDataDic = new Dictionary<int, SkillData>();
        DataSetItem data = DataManager.Instance.GetData("SkillData");
        SkillDataSet skillDataSet = data.scriptableObject as SkillDataSet;
        for (int i = 0; i < skillDataSet.heroSkills.Count; i++)
        {
            skillDataDic.Add(skillDataSet.heroSkills[i].id, skillDataSet.heroSkills[i]);
        }
        ModeData modeData = DataManager.Instance.modeData;
        buildingMode = modeData.skillUpBuildingMode;
        if (modeData.skillUpBuildingMode.equipLvs.Count < 2)
        {
            buildingMode.equipLvs = new List<int>(new int[2]);
        }
        defaultHeroIcon = heroIcon.sprite;
        if (skillLvGroups == null)
        {
            Transform container = RootPanel.transform.Find("skillUpBox");
            skillLvGroups = new List<SkillLevelGroup>(container.GetComponentsInChildren<SkillLevelGroup>(true));
            for (int i = 0; i < skillLvGroups.Count; i++)
            {
                skillLvGroups[i].OnSkillUp += OnSkillUp;
            }
        }
        if (buildingLvGroups == null)
        {
            Transform container = RootPanel.transform.Find("buildingUpBox");
            buildingLvGroups = new List<BuildingLevelGroup>(container.GetComponentsInChildren<BuildingLevelGroup>(true));
            //初始化建筑数据
            for (int i = 0; i < buildingLvGroups.Count; i++)
            {
                buildingLvGroups[i].OnEquipLvUp += EquipLvUp;
                if (buildingLvGroups[i].equipType.Equals(EquipType.Experience))
                {
                    buildingLvGroups[i].InitialLevelGroup(buildingMode.equipLvs[0], ResPanel.Instance.StarFire, ResPanel.Instance.Fruit, expEquip);
                    setLvGroupHover(buildingLvGroups[i], LanguageController.GetValue("解锁更高级的战斗技能"));
                }
                if (buildingLvGroups[i].equipType.Equals(EquipType.TrainSkill))
                {
                    buildingLvGroups[i].InitialLevelGroup(buildingMode.equipLvs[1], ResPanel.Instance.StarFire, ResPanel.Instance.Fruit, trainSkillEquip);
                    setLvGroupHover(buildingLvGroups[i], LanguageController.GetValue("减少升级费用"));
                }
            }
        }
        Transform panel = transform.parent.Find("Panels");
        if (panel != null)
        {
            transform.SetParent(panel);
        }
        topTips.text = LanguageController.GetValue("辉光圣所");
        initialized = true;
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



    private void EquipLvUp(EquipType equipType, int costRes1, int costRes2)
    {
        if (equipType == EquipType.Experience)
            buildingMode.equipLvs[0]++;
        if (equipType == EquipType.TrainSkill)
            buildingMode.equipLvs[1]++;
        ResPanel.Instance.ChangeResource(0, 0, -costRes2, 0, -costRes1);
        //根据现有资源更新显示
        for (int i = 0; i < buildingLvGroups.Count; i++)
        {
            buildingLvGroups[i].UpdateGroup(ResPanel.Instance.StarFire, ResPanel.Instance.Fruit);
        }
        RefreshData();
    }

    private void OnSkillUp(SkillLevelGroup skillLvGroup, int requireRes)
    {
        int cost = (int)((1 - trainSkillEquip.discounts[buildingMode.equipLvs[1]]) * requireRes + 0.5);
        print(cost + "cost");
        if (ResPanel.Instance.Money >= cost)
        {
            AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
            ResPanel.Instance.ChangeResource(-cost);
            skillLvGroup.SkillUp();
            RefreshData();
        }
        else
        {
            AudioManager.Instance.PlayAudio(AudioName.MATERIAL_Error_01_mono, AudioType.Common);
        }
    }

    //英雄拖动到区域内调用，显示英雄技能信息
    public void ShowRoleData(RoleItem roleItem)
    {
        for (int i = 0; i < skillLvGroups.Count; i++)
        {
            skillLvGroups[i].gameObject.SetActive(false);
        }

        var tempData = Camp.Instance.getDateForObj(roleItem.gameObject);

        tempData.GetIcon().LoadAssetAsync<Sprite>().Completed += inGo => { heroIcon.sprite = inGo.Result; };
        heroData = tempData.GetRoleData();
        herosMode = tempData.GetHeroMode();
        dragAreaText.text = heroData.name;
        dragAreaText.alignment = TextAnchor.MiddleLeft;
        heroDescribText.text = heroData.describe;
        //初始化每个技能等级信息
        for (int i = 0; i < skillLvGroups.Count; i++)
        {
            if (herosMode.skillModes.Count <= i)
                break;
            skillLvGroups[i].gameObject.SetActive(true);
            skillLvGroups[i].Initial(skillDataDic[herosMode.skillModes[i].skillId], herosMode.skillModes[i]);
            skillLvGroups[i].RefreshGroup
                (
                expEquip.unlockLevels[buildingMode.equipLvs[0]],
                3,
                ResPanel.Instance.Money,
                trainSkillEquip.discounts[buildingMode.equipLvs[1]]
                );
        }
    }


    public override void init()
    {
        base.init();
    }

    public override void mainLoop()
    {
        base.mainLoop();
    }

    public override void RefreshData()
    {
        base.RefreshData();

        if (herosMode != null)
        {
            foreach (var item in skillLvGroups)
            {
                //item.RefreshResource(resource, exp, trainSkill);
                item.RefreshGroup(expEquip.unlockLevels[buildingMode.equipLvs[0]],
                    3, ResPanel.Instance.Money, trainSkillEquip.discounts[buildingMode.equipLvs[1]]);
            }
        }
    }

    public override void open()
    {

        if (!initialized)
            Initial();

        dragAreaText.alignment = TextAnchor.MiddleCenter;
        dragAreaText.text = LanguageController.GetValue("拖入英雄");
        heroIcon.sprite = defaultHeroIcon;

        //根据现有资源更新显示
        for (int i = 0; i < buildingLvGroups.Count; i++)
        {
            buildingLvGroups[i].UpdateGroup(ResPanel.Instance.StarFire, ResPanel.Instance.Fruit);
        }

        if (!isFading)
        {
            NewbieGuideMag.Instance.triggerGuide(GuideDataSet.guideEnum.skillUp);
            base.open();
            RootPanel.GetComponent<RectTransform>().anchoredPosition = originPos;
            RootPanel.gameObject.SetActive(true);
            isFading = true;
            PanelRect.localScale = Vector3.zero;
            PanelRect.DOScale(Vector3.one, 0.3f).onComplete = () => isFading = false;
        }
    }

    public override void close()
    {
        closeSkillUpHover();
        heroDescribText.text = "";
        if (skillLvGroups != null)
            for (int i = 0; i < skillLvGroups.Count; i++)
            {
                skillLvGroups[i].gameObject.SetActive(false);
            }

        if (!isFading)
        {
            base.close();
            isFading = true;
            PanelRect.DOScale(Vector3.zero, 0.15f).onComplete = () => { isFading = false; RootPanel.gameObject.SetActive(false); };
        }
    }

    void closeSkillUpHover()
    {
        foreach (var tempSkillUp in skillUpList)
        {
            tempSkillUp.hoverInfoUI.Hide();
            tempSkillUp.hoverInfoUI.transform.SetParent(tempSkillUp.transform);
        }
        skillUpList.Clear();
    }
}


