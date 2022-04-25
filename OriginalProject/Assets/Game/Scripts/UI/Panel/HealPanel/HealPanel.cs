using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Datas;
using System;
using DG.Tweening;
using GEvent;

public class HealPanel : BuildPanelBase
{
    //public Camp camp;
    public GameObject panelRoot;
    public static HealPanel instance;
    public HealBoxExtend boxExtend;
    public ResourceSaver resSaver;
    public EfficiencyEquip efficiency;
    private List<HealBox> healBoxes;
    private List<HeroMoraleBox> heroMoralBoxes;
    private Dictionary<int, RoleData> heroDataDic;
    private List<BuildingLevelGroup> buildingLvGroups;
    public int maxHealCost;
    private RectTransform panelRect;
    private bool isFading = false;
    private bool initialized;
    private HealBuildingMode buildingMode;
    HoverInfoUI iconHover;
    Vector2 originPos;

    //----------- text
    [Space,Header("text")]
    public Text titleText;
    public Text TopTips;

    private void Awake() { instance = this; }

    private void Start()
    {
        originPos = panelRoot.GetComponent<RectTransform>().anchoredPosition;
        BuildPanelMag.Instance.addBuild(this);
    }

    private RectTransform PanelRect
    {
        get
        {
            if (panelRect == null)
                panelRect = panelRoot.GetComponent<RectTransform>();
            return panelRect;
        }
    }

    public void Initial()
    {
        var tempCoonfirm = panelRoot.transform.Find("ConfirmPlan");

        ModeData modeData = DataManager.Instance.modeData;
        buildingMode = modeData.healBuildingMode;

        titleText.text = LanguageController.GetValue("箴戒酒馆");
        TopTips.text = LanguageController.GetValue("疗伤介绍");
        //setSaveDate(ref modeData);

        if (modeData.healBuildingMode.equipLvs.Count < 3)
        {
            buildingMode.equipLvs = new List<int>(new int[3]);
        }
        heroDataDic = new Dictionary<int, RoleData>();
        DataSetItem data = DataManager.Instance.GetData("RoleData");
        RoleDataSet roleData = data.scriptableObject as RoleDataSet;
        for (int i = 0; i < roleData.heroData.Count; i++)
        {
            heroDataDic.Add(roleData.heroData[i].id, roleData.heroData[i]);
        }
        healBoxes = new List<HealBox>(panelRoot.GetComponentsInChildren<HealBox>());

        if (buildingLvGroups == null)
        {
            Transform container = panelRoot.transform.Find("buildingUpBox");
            buildingLvGroups = new List<BuildingLevelGroup>(container.GetComponentsInChildren<BuildingLevelGroup>(true));
            //初始化建筑数据
            for (int i = 0; i < buildingLvGroups.Count; i++)
            {
                buildingLvGroups[i].OnEquipLvUp += EquipLvUp;
                if (buildingLvGroups[i].equipType.Equals(EquipType.BoxExtend))
                {
                    buildingLvGroups[i].InitialLevelGroup(buildingMode.equipLvs[0], ResPanel.Instance.Crystal, ResPanel.Instance.LightStone, boxExtend);
                    setLvGroupHover(buildingLvGroups[i], LanguageController.GetValue("增加更多恢复栏位"));
                }
                if (buildingLvGroups[i].equipType.Equals(EquipType.ResourceSaver))
                {
                    buildingLvGroups[i].InitialLevelGroup(buildingMode.equipLvs[1], ResPanel.Instance.Crystal, ResPanel.Instance.LightStone, resSaver);
                    setLvGroupHover(buildingLvGroups[i], LanguageController.GetValue("减少花费的资源"));
                }
                if (buildingLvGroups[i].equipType.Equals(EquipType.EfficiencyEquip))
                {
                    buildingLvGroups[i].InitialLevelGroup(buildingMode.equipLvs[2], ResPanel.Instance.Crystal, ResPanel.Instance.LightStone, efficiency);
                    setLvGroupHover(buildingLvGroups[i], LanguageController.GetValue("增加恢复的士气数值"));
                }
            }
        }

        for (int i = 0; i < healBoxes.Count; i++)
        {
            //if (i < 3) healBoxes[i].UnLock();
            if (buildingMode.equipLvs[0] + 3 > i) healBoxes[i].UnLock();
            //else if (boxExtend.unlockBoxNum[buildingMode.equipLvs[0]] >= i + 1)
            //{
            //    healBoxes[i].UnLock();
            //}
            else
            {
                healBoxes[i].isLocked = true;
            }
            healBoxes[i].boxIndex = i;
            healBoxes[i].level = i;
            healBoxes[i].OnPutHero += OnPutHeroIn;
            healBoxes[i].OnConfirmHeal += OnConfirmHeal;
            healBoxes[i].OnCancelHeal += OnCancelHeal;

            healBoxes[i].OnHoverEnter += OnHoverEnter;
            healBoxes[i].OnHoverExit += OnHoverExit;

            healBoxes[i].confirmPlan = tempCoonfirm;
            healBoxes[i].setConfinButton();
        }

        if (Camp.backFromBattle)
            HealFinish();
        else
        {
            foreach (var heroItem in Camp.Instance.heroTeam)
            {
                if (heroItem.herosMode.isHealing)
                {
                    healBoxes[heroItem.herosMode.healBoxIndex].LoadHero(heroItem);
                }
            }
        }

        tempCoonfirm.gameObject.SetActive(false);
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

    private void OnPutHero(HeroMoraleBox heroMoraleBox, int heroId)
    {
        for (int i = 0; i < heroMoralBoxes.Count; i++)
        {
            if (heroMoraleBox != heroMoralBoxes[i])
            {
                if (heroMoraleBox.herosMode.Equals(heroMoralBoxes[i].herosMode))
                {
                    heroMoralBoxes[i].Clear();
                }
            }
        }
    }

    private void EquipLvUp(EquipType equipType, int costRes1, int costRes2)
    {
        if (equipType == EquipType.BoxExtend)
        {
            buildingMode.equipLvs[0]++;
        }
        if (equipType == EquipType.ResourceSaver)
        {
            buildingMode.equipLvs[1]++;
        }
        if (equipType == EquipType.EfficiencyEquip)
        {
            buildingMode.equipLvs[2]++;
        }
        ResPanel.Instance.ChangeResource(0, -costRes1, 0, -costRes2);
        for (int i = 0; i < buildingLvGroups.Count; i++)
        {
            buildingLvGroups[i].UpdateGroup(ResPanel.Instance.Crystal, ResPanel.Instance.LightStone);
        }
        updateBoxLocl();
    }

    private void OnConfirmHeal(HealBox healBox, int heroId)
    {
        int cost = (int)(maxHealCost * (1 - resSaver.discounts[buildingMode.equipLvs[1]]) + 0.5);
        ResPanel.Instance.ChangeResource(-cost);
        updateBoxLocl();
    }

    private void OnCancelHeal(HealBox healBox, ObjLifeData inOLD)
    {
        healBox.ResetBox();
    }

    /// <summary>
    /// 拖进英雄的数据
    /// </summary>
    /// <param name="healBox"></param>
    /// <param name="heroId"></param>
    private void OnPutHeroIn(HealBox healBox, ObjLifeData inOLD)
    {
        if (inOLD.GetIsHealing()) return;
        if (inOLD.GetMorale() > 50) return;
        foreach (var box in healBoxes)
        {
            if (healBox != box)
            {
                if (box.roleItem != null && box.roleItem.Equals(healBox.roleItem))
                    box.ResetBox();
            }
        }

        //
        SetHealBox(healBox, inOLD.GetRoleData());
        if (inOLD.GetReadyStart()) Camp.Instance.RemoveHeroFromBattle(inOLD, Camp.Instance.getIndexForData(inOLD));
    }

    //设置治疗栏数据
    private void SetHealBox(HealBox healBox, RoleData heroData)
    {
        healBox.SetHero(heroData);
        updateBoxLocl();
    }

    public void HealFinish()
    {
        Debug.Log("=========== HealFinish ===========");

        foreach (var hero in Camp.Instance.getObjLifeData())
        {
            if (hero.Key.GetIsHealing())
            {
                var tempHeroMode = hero.Key.GetHeroMode();

                //伤势
                {
                    //healBoxes[tempHeroMode.healBoxIndex].ResetBox();
                    //int healNum = efficiency.efficiencies[buildingMode.equipLvs[2]];
                    //if (tempHeroMode.injuries > healNum)
                    //{
                    //    tempHeroMode.injuries -= healNum;
                    //}
                    //else
                    //{
                    //    tempHeroMode.injuries = 0;
                    //}
                }

                //士气
                {
                    healBoxes[tempHeroMode.healBoxIndex].ResetBox();
                    int healNum = efficiency.efficiencies[buildingMode.equipLvs[2]];
                    hero.Key.UpdateMorale(healNum);
                }
                tempHeroMode.isHealing = false;
                hero.Value.GetComponent<RoleItem>().SetHeal(false);
            }
            else hero.Key.UpdateMorale(10);
        }

        Camp.Instance.refreshAllHeroData();
    }

    private void OnHoverEnter(HealBox equipItem, HoverInfoUI infoUI)
    {
        UnityEngine.UI.Text text;
        if (equipItem.isLocked && equipItem.level > 2)
        {
            text = infoUI.AddItem(LanguageController.GetValue("先决条件:"), 0, Color.white);
            text.color = Color.white;
            text = infoUI.AddItem(LanguageController.GetValue("需要开源等级") +
                boxExtend.limitations[equipItem.level - 3].value, 1, Color.red);

            infoUI.Show();
            infoUI.transform.SetParent(transform.parent, true);
            infoUI.transform.SetAsLastSibling();
        }

    }

    private void OnHoverExit(HealBox equipItem, HoverInfoUI infoUI)
    {
        infoUI.Hide();
        infoUI.transform.SetParent(equipItem.transform, true);
    }

    void setSaveDate(ref ModeData inModeData)
    {
        //inModeData.healBuildingMode.equipLvs[0] = 0;
    }

    void updateBoxLocl()
    {
        for (int i = 0; i < healBoxes.Count; i++)
        {
            if (healBoxes[i].isLocked)
            {
                int unlockNum = buildingMode.equipLvs[0];
                if (unlockNum != 0)
                {
                    unlockNum -= 1;
                    if (unlockNum > 3) unlockNum = 3;
                    if (unlockNum < 0) unlockNum = 0;
                    if (boxExtend.unlockBoxNum[unlockNum] > i)
                    {
                        healBoxes[i].UnLock();
                    }
                }
            }
            else
            {
                int cost = (int)(maxHealCost * (1 - resSaver.discounts[buildingMode.equipLvs[1]]) + 0.5);
                healBoxes[i].RefreshBox(cost, ResPanel.Instance.Money >= cost);
            }
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
        panelRoot.SetActive(true);
        Initial();
        panelRoot.SetActive(false);
    }

    public override void open()
    {

        if (!initialized)
            Initial();
        //_OnEnter();

        if (!isFading)
        {
            NewbieGuideMag.Instance.triggerGuide(GuideDataSet.guideEnum.heal);
            base.open();
            isFading = true;
            panelRoot.GetComponent<RectTransform>().anchoredPosition = originPos;
            panelRoot.SetActive(true);
            PanelRect.localScale = Vector3.zero;
            PanelRect.DOScale(Vector3.one, 0.3f).onComplete = () => isFading = false;
        }
    }

    public override void close()
    {


        foreach (var healBox in healBoxes)
        {
            if (!healBox.isOccupied && !healBox.isLocked)
            {
                healBox.ResetBox();
            }
        }
        //_OnExit();

        if (!isFading)
        {
            base.close();
            isFading = true;
            PanelRect.DOScale(Vector3.zero, 0.15f).onComplete = () => { isFading = false; panelRoot.SetActive(false); };
        }
    }
}
