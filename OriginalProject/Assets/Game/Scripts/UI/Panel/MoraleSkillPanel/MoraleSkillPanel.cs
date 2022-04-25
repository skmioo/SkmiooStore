using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Datas;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
using GEvent;

public class MoraleSkillPanel : BuildPanelBase
{
    public Transform panelRoot;
    public ResourceSaver resSaver;
    public ExtendBoxEquip rollExtend, storeExtend;
    public GameObject confirmPanel;
    public Image skillDragIcon;
    public int maxCost;
    public Text costText;
    public List<HeroMoraleBox> heroMoralBoxes;
    private Dictionary<int, OtherSkillData> otherSkillDic;
    private List<MoraleSkillItem> moraleSkillItems;
    public List<StoredMoraleItem> storedMoraleItems;
    private OtherSkillData previousSkill, currentSkill;
    private StoredMoraleItem currentStoredItem, dragingStoredItem;
    private MoraleSkillItem currentDragItem;
    private List<BuildingLevelGroup> buildingLvGroups;
    private MoraleBuildingMode buildingMode;

    private RectTransform panelRect;
    private bool isFading;
    HoverInfoUI iconHover;
    Vector2 originPos;

    public RawImage tipsPanel;
    bool isShowTips = false;

    public GameObject openBtn;
    public GameObject closeBtn;
    public GameObject budUpBox;
    public GameObject budUpBack;

    List<HoverableItem> hoverablePool = new List<HoverableItem>();

    public Text topTips;
    public Text screenTips;

    private RectTransform PanelRect
    {
        get
        {
            if (panelRect == null)
                panelRect = panelRoot.GetComponent<RectTransform>();
            return panelRect;
        }
    }

    private void Start()
    {
        originPos = panelRoot.GetComponent<RectTransform>().anchoredPosition;
        tipsPanel.gameObject.SetActive(false);
        BuildPanelMag.Instance.addBuild(this);
    }

    /// <summary>
    /// 这里是角色拖进角色栏
    /// </summary>
    /// <param name="heroMoraleBox"></param>
    /// <param name="heroId"></param>
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

        foreach (var tempSMI in storedMoraleItems)
        {
            if (tempSMI.heroMoraleBox == heroMoraleBox)
            {
                tempSMI.Clear();
                if (heroMoraleBox.herosMode.moraleSkillId != 0)
                    foreach (var tempData in otherSkillDic)
                        if (tempData.Value.id == heroMoraleBox.herosMode.moraleSkillId)
                        {
                            MoraleSkillItem tempMSI = new MoraleSkillItem();
                            tempMSI.InitialData(tempData.Value, false);
                            tempSMI.InitialData(tempMSI.MoraleSkillData);
                            break;
                        }

                //士气技能改了，没用了
                {
                    //tempSMI.Clear();
                    //var tempSkill = heroMoraleBox.herosMode.skillModes;
                    //if (tempSkill.Count > 0)
                    //{
                    //    //if (heroMoraleBox.herosMode.skillModes[0] == null) S_debug.showDebug("skillModes[0] = null");
                    //    foreach (var tempData in otherSkillDic)
                    //    {
                    //        if (tempData.Value.id == heroMoraleBox.herosMode.skillModes[0].skillId)
                    //        {
                    //            MoraleSkillItem tempMSI = new MoraleSkillItem();
                    //            tempMSI.InitialData(tempData.Value);
                    //            tempSMI.InitialData(tempMSI.MoraleSkillData);
                    //        }
                    //    }
                    //}
                }
            }
            tempSMI.SetSkill();
        }
    }

    private void EquipLvUp(EquipType equipType, int costRes1, int costRes2)
    {
        if (equipType == EquipType.ResourceSaver)
            buildingMode.equipLvs[0]++;
        if (equipType == EquipType.RollNum)
            buildingMode.equipLvs[1]++;
        //if (equipType == EquipType.RollStoreBox)
        //    buildingMode.equipLvs[2]++;
        ResPanel.Instance.ChangeResource(0, -costRes1, 0, -costRes2);
        //根据现有资源更新显示
        for (int i = 0; i < buildingLvGroups.Count; i++)
        {
            buildingLvGroups[i].UpdateGroup(ResPanel.Instance.Crystal, ResPanel.Instance.LightStone);
        }
        RefreshUpgrade();
    }

    private void RefreshUpgrade()
    {
        //for (int i = 0; i < storedMoraleItems.Count; i++)
        //{
        //    if (storedMoraleItems[i].isLocked)
        //    {
        //        if (storeExtend.extendNums[buildingMode.equipLvs[2]] >= i + 1)
        //        {
        //            storedMoraleItems[i].Unlock();
        //        }
        //    }
        //}

        int cost = (int)(maxCost * (1 - resSaver.discounts[buildingMode.equipLvs[0]]) + 0.5);
        costText.text = cost.ToString();
        if (ResPanel.Instance.Money >= cost)
            costText.color = Color.green;
        else
            costText.color = Color.red;
    }

    #region 拖拽功能
    //抽取技能开始拖拽
    private RectTransform ItemOnDrag(GameObject go, PointerEventData eventData)
    {
        currentDragItem = go.GetComponent<MoraleSkillItem>();
        if (!currentDragItem.isActive)
            return null;
        RectTransform rectTransform = skillDragIcon.rectTransform;
        skillDragIcon.sprite = currentDragItem.skillIcon.sprite;
        skillDragIcon.gameObject.SetActive(true);
        currentDragItem.skillIcon.enabled = false;

        return rectTransform;
    }

    //抽取技能结束拖拽
    private void ItemOnEndDrag(GameObject go, PointerEventData eventData)
    {
        if (!currentDragItem.isActive) return;
        skillDragIcon.gameObject.SetActive(false);
        if (eventData.pointerEnter != null)
        {
            if (eventData.pointerEnter.name.Equals("storedSkill"))
            {
                StoredMoraleItem storedItem = eventData.pointerEnter.GetComponent<StoredMoraleItem>();
                if (storedItem != null)
                {
                    if (storedItem.heroMoraleBox.herosMode != null)
                    {
                        buildingMode.moraleSkillIDs[storedItem.index] = currentDragItem.MoraleSkillData.id;
                        storedItem.InitialData(currentDragItem.MoraleSkillData);
                    }
                    else currentDragItem.skillIcon.enabled = true;
                }
            }
            else
            {
                currentDragItem.skillIcon.enabled = true;

            }
        }
    }
    //储备栏技能开始拖拽
    private RectTransform StoreItemDrag(GameObject go, PointerEventData eventData)
    {
        dragingStoredItem = go.GetComponent<StoredMoraleItem>();
        RectTransform rectTransform = skillDragIcon.rectTransform;
        skillDragIcon.sprite = dragingStoredItem.skillIcon.sprite;
        skillDragIcon.gameObject.SetActive(true);
        dragingStoredItem.skillIcon.gameObject.SetActive(false);
        Vector3 globalMousePos;

        return rectTransform;
    }
    //储备栏技能结束拖拽
    private void StoreItemEndDrag(GameObject go, PointerEventData eventData)
    {
        skillDragIcon.gameObject.SetActive(false);
        if (eventData.pointerEnter != null)
        {
            if (eventData.pointerEnter.name.Equals("storedSkill"))
            {
                StoredMoraleItem storedItem = eventData.pointerEnter.GetComponent<StoredMoraleItem>();
                if (storedItem != null)
                {
                    if (storedItem.Equals(dragingStoredItem))
                    {
                        dragingStoredItem.skillIcon.gameObject.SetActive(true);
                        return;
                    }
                    if (storedItem.skillIcon.gameObject.activeSelf)
                    {
                        Sprite tempIcon = storedItem.skillIcon.sprite;
                        OtherSkillData skillData = storedItem.SkillData;
                        storedItem.ReplaceSkill(dragingStoredItem.skillIcon.sprite, dragingStoredItem.SkillData);
                        buildingMode.moraleSkillIDs[storedItem.index] = dragingStoredItem.SkillData.id;
                        dragingStoredItem.ReplaceSkill(tempIcon, skillData, false);
                        buildingMode.moraleSkillIDs[dragingStoredItem.index] = skillData.id;
                    }
                    else
                    {
                        buildingMode.moraleSkillIDs[dragingStoredItem.index] = 0;
                        storedItem.ReplaceSkill(dragingStoredItem.skillIcon.sprite, dragingStoredItem.SkillData);
                        buildingMode.moraleSkillIDs[storedItem.index] = dragingStoredItem.SkillData.id;
                        dragingStoredItem.Clear();
                    }
                }
            }
            else
            {
                dragingStoredItem.skillIcon.gameObject.SetActive(true);
            }
        }
    }
    #endregion

    private void OnReplaceSkill(OtherSkillData previous, OtherSkillData current, StoredMoraleItem storedItem)
    {
        if (previous != null)
        {
            previousSkill = previous;
            currentSkill = current;
            currentStoredItem = storedItem;
            confirmPanel.SetActive(true);
            Transform textObj = confirmPanel.transform.Find("Text");
            Text t = textObj.GetComponent<Text>();
            //string confirmText = string.Format("被替换技能将消失，确定用“{0}”替换“{1}”？", current.name, previous.name);
            string confirmText =
                LanguageController.GetValue("被替换技能将消失") + "," + LanguageController.GetValue("确定替换") + current.name + LanguageController.GetValue("为") + previous.name;
            t.text = confirmText;
        }
        else
        {
            foreach (var skillBox in storedMoraleItems)
            {
                skillBox.SetSkill();
            }
            foreach (var skill in moraleSkillItems)
            {
                skill.DisableItem();
            }
            if (currentDragItem != null)
            {
                currentDragItem.ClearItem();
                currentDragItem = null;
            }
        }
    }

    private void Item_OnHoverEnter(HoverableItem hoverItem)
    {
        var tempSkillLtem = hoverItem as MoraleSkillItem;
        if (tempSkillLtem != null) if (!tempSkillLtem.isActive) return;
        hoverItem.hoverInfoUI.Show();
        hoverItem.hoverInfoUI.transform.SetParent(panelRoot, true);
        hoverItem.hoverInfoUI.transform.SetAsLastSibling();
        hoverablePool.Add(hoverItem);
    }

    private void Item_OnHoverExit(HoverableItem hoverItem)
    {
        hoverItem.hoverInfoUI.Hide();
        hoverItem.hoverInfoUI.transform.SetParent(hoverItem.transform, true);
        if (hoverablePool.Equals(hoverItem))
            hoverablePool.Remove(hoverItem);
    }

    void closeBuild()
    {
        emptyItem();
        closeHover();
        onCloseBuildUp();
    }

    void emptyItem()
    {
        if (moraleSkillItems != null)
            for (int i = 0; i < moraleSkillItems.Count; i++)
            {
                moraleSkillItems[i].ClearItem();
            }
        if (heroMoralBoxes != null)
            for (int i = 0; i < heroMoralBoxes.Count; i++)
            {
                heroMoralBoxes[i].Clear();
            }
        if (storedMoraleItems != null)
            for (int i = 0; i < storedMoraleItems.Count; i++)
            {
                storedMoraleItems[i].Clear();
            }
    }

    void closeHover()
    {
        foreach (var tempHover in hoverablePool)
            Item_OnHoverExit(tempHover);
    }

    /// <summary>
    /// 随机产生技能
    /// </summary>
    public void RollMoraleSkill()
    {
        AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
        int cost = (int)(maxCost * (1 - resSaver.discounts[buildingMode.equipLvs[0]]) + 0.5);
        if (ResPanel.Instance.Money < cost)
        {
            AudioManager.Instance.PlayAudio(AudioName.MATERIAL_Error_01_mono, AudioType.Common);
            return;
        }
        ResPanel.Instance.ChangeResource(-cost);
        for (int i = 0; i < moraleSkillItems.Count; i++)
        {
            moraleSkillItems[i].ClearItem();
        }
        List<MoraleSkillItem> skillItemBoxes = new List<MoraleSkillItem>(moraleSkillItems);
        List<OtherSkillData> rollItems = new List<OtherSkillData>(otherSkillDic.Values);
        //{
        //    int skillIndex = Random.Range(0, rollItems.Count - 1);
        //    skillItemBoxes[10].InitialData(rollItems[skillIndex]);
        //    skillItemBoxes[10].Active(); print(skillItemBoxes[10].name);
        //    skillItemBoxes.RemoveAt(10);
        //    rollItems.RemoveAt(skillIndex);
        //}
        for (int i = 0; i < rollExtend.extendNums[buildingMode.equipLvs[1]]; i++)
        {
            int boxIndex = Random.Range(0, skillItemBoxes.Count);
            int skillIndex = Random.Range(0, rollItems.Count);
            skillItemBoxes[boxIndex].InitialData(rollItems[skillIndex], true);
            skillItemBoxes[boxIndex].Active();
            print(skillItemBoxes[boxIndex].name);
            skillItemBoxes.RemoveAt(boxIndex);
            rollItems.RemoveAt(skillIndex);
        }
        RefreshUpgrade();
    }

    public void ConfirmSkillReplace(bool isConfirm)
    {
        if (isConfirm)
        {
            currentDragItem.ClearItem();
            currentStoredItem.ReplaceSkill(currentSkill);
            foreach (var skillBox in storedMoraleItems)
            {
                skillBox.SetSkill();
            }
            //将所有士气技能disable
            foreach (var item in moraleSkillItems)
            {
                item.DisableItem();
            }
            currentDragItem = null;
        }
        else
        {
            currentDragItem.skillIcon.enabled = true;
            currentDragItem = null;
        }
    }

    public void onOpenBuildUp() {
        openBtn.SetActive(false);
        closeBtn.SetActive(true);
        budUpBox.SetActive(true);
        budUpBack.SetActive(true);
    }

    public void onCloseBuildUp() {
        openBtn.SetActive(true);
        closeBtn.SetActive(false);
        budUpBox.SetActive(false);
        budUpBack.SetActive(false);
    }

    /// <summary>
    /// 打开建筑时加载角色
    /// </summary>
    void putHeroToBox()
    {
        var tempBattleAry = Camp.Instance.getBattleBoxData();
        int tempBattleValue = 0;
        for (int i = 0; i < tempBattleAry.Length; i++)
            if (tempBattleAry[i] != null)
                tempBattleValue++;


        //如果出征栏为空，拿队列栏
        if (tempBattleValue != 0)
        {
            int tempHeroIndex = 0;
            for (int i = 0; i < heroMoralBoxes.Count; i++)
            {
                if (!heroMoralBoxes[i].lockIcon.IsActive())
                {
                    if (tempBattleAry[i] != null)
                        heroMoralBoxes[i].OnPutHeroIn(tempBattleAry[i]);
                    tempHeroIndex++;
                }
            }
        }
        else
        {
            int tempHeroIndex = 0;
            var tempObjList = Camp.Instance.getLifeDateValues();
            for (int i = 0; i < heroMoralBoxes.Count; i++)
            {
                if (!heroMoralBoxes[i].lockIcon.IsActive())
                {
                    RoleItem tempItem = tempObjList[tempHeroIndex].GetComponent<RoleItem>();
                    if (tempItem != null)
                        heroMoralBoxes[i].OnPutHeroIn(tempItem);
                    if (tempHeroIndex + 1 < tempObjList.Count) tempHeroIndex++;
                    else return;
                }
            }
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


    public override void SetPanel(bool isActive)
    {
        //gameObject.SetActive(isActive);
        if (Camp.Instance.getObjLifeData().Count < 1) { showTipsPanel(); return; }
        if (isActive)
        {
            UIManager.Instance.PushBuildPanel(this);
            open();
        }
        else
        {
            close();
        }
    }

    public override void init()
    {
        base.init();
        DataSetItem buildData = DataManager.Instance.GetData("BuildData");
        BuildDataSet buildDataSet = buildData.scriptableObject as BuildDataSet;
        resSaver = buildDataSet.moraleSkillEquip1;
        rollExtend = buildDataSet.moraleSkillEquip2;
        storeExtend = buildDataSet.moraleSkillEquip3;
        ModeData modeData = DataManager.Instance.modeData;
        buildingMode = modeData.moraleBuildingMode;
        if (modeData.moraleBuildingMode.equipLvs.Count < 3)
        {
            buildingMode.equipLvs = new List<int>(new int[3]);
        }
        otherSkillDic = new Dictionary<int, OtherSkillData>();
        DataSetItem data = DataManager.Instance.GetData("SkillData");
        SkillDataSet skillDataSet = data.scriptableObject as SkillDataSet;
        for (int i = 0; i < skillDataSet.otherSkills.Count; i++)
        {
            otherSkillDic.Add(skillDataSet.otherSkills[i].id, skillDataSet.otherSkills[i]);
        }
        moraleSkillItems = new List<MoraleSkillItem>(panelRect.GetComponentsInChildren<MoraleSkillItem>(true));
        foreach (var item in moraleSkillItems)
        {

            item.OnHoverEnter += Item_OnHoverEnter;
            item.OnHoverExit += Item_OnHoverExit;
            UIEventManager.AddTriggersListener(item.gameObject).onDrag = (go, eventData) => ItemOnDrag(go, eventData);
            UIEventManager.AddTriggersListener(item.gameObject).onEndDrag = (go, eventData) => ItemOnEndDrag(go, eventData);
        }
        int index = 0;
        foreach (var item in storedMoraleItems)
        {
            item.index = index++;
            item.OnHoverEnter += Item_OnHoverEnter;
            item.OnHoverExit += Item_OnHoverExit;
            item.OnReplaceSkill += OnReplaceSkill;
            //UIEventManager.AddTriggersListener(item.gameObject).onDrag = StoreItemDrag;
            //UIEventManager.AddTriggersListener(item.gameObject).onEndDrag = StoreItemEndDrag;
        }
        //heroMoralBoxes = new List<HeroMoraleBox>(panelRoot.GetComponentsInChildren<HeroMoraleBox>());
        for (int i = 0; i < heroMoralBoxes.Count; i++)
        {
            heroMoralBoxes[i].OnPutHero += OnPutHero;
            heroMoralBoxes[i].Clear();
        }
        if (buildingLvGroups == null)
        {
            Transform container = panelRoot.Find("buildingUpBox");
            buildingLvGroups = new List<BuildingLevelGroup>(container.GetComponentsInChildren<BuildingLevelGroup>(true));
            //初始化建筑数据
            for (int i = 0; i < buildingLvGroups.Count; i++)
            {
                buildingLvGroups[i].OnEquipLvUp += EquipLvUp;
                if (buildingLvGroups[i].equipType.Equals(EquipType.ResourceSaver))
                {
                    buildingLvGroups[i].InitialLevelGroup(buildingMode.equipLvs[0], ResPanel.Instance.Crystal, ResPanel.Instance.LightStone, resSaver);
                    setLvGroupHover(buildingLvGroups[i], LanguageController.GetValue("减少抽取费用"));
                }
                if (buildingLvGroups[i].equipType.Equals(EquipType.RollNum))
                {
                    buildingLvGroups[i].InitialLevelGroup(buildingMode.equipLvs[1], ResPanel.Instance.Crystal, ResPanel.Instance.LightStone, rollExtend);
                    setLvGroupHover(buildingLvGroups[i], LanguageController.GetValue("增加抽取技能数"));
                }
                //if (buildingLvGroups[i].equipType.Equals(EquipType.RollStoreBox))
                //{
                //    buildingLvGroups[i].InitialLevelGroup(buildingMode.equipLvs[2], ResPanel.Instance.Crystal, ResPanel.Instance.LightStone, storeExtend);
                //}
            }
        }
        RefreshUpgrade();
        if (buildingMode.moraleSkillIDs == null || buildingMode.moraleSkillIDs.Count < 7)
        {
            buildingMode.moraleSkillIDs = new List<int>();
            for (int i = 0; i < 7; i++)
            {
                buildingMode.moraleSkillIDs.Add(0);
            }
        }
        //这里是进建筑的时候加载上次的技能
        //for (int i = 0; i < buildingMode.moraleSkillIDs.Count; i++)
        //{
        //    OtherSkillData moraleSkillData;
        //    if(otherSkillDic.TryGetValue(buildingMode.moraleSkillIDs[i],out moraleSkillData))
        //    {
        //        storedMoraleItems[i].InitialData(moraleSkillData);
        //    }
        //}

        for (int i = 0; i < storedMoraleItems.Count; i++)
        {
            if (storedMoraleItems[i].heroMoraleBox != null && storedMoraleItems[i].SkillData != null)
            {
                //RoleItem equipedHero = Camp.Instance.heroTeam.Find(r => r.herosMode.equipmentOtherSkill.skillId == storedMoraleItems[i].SkillData.id);
                //if(equipedHero!=null)
                //    storedMoraleItems[i].heroMoraleBox.LoadHeroData(equipedHero);
            }
        }

        topTips.text = LanguageController.GetValue("起源神树");
        screenTips.text = LanguageController.GetValue("请招募英雄");
    }

    public override void mainLoop()
    {
        base.mainLoop();
    }

    public override void RefreshData()
    {
        base.RefreshData();
    }

    public override void open()
    {


        if (!isFading)
        {
            NewbieGuideMag.Instance.triggerGuide(GuideDataSet.guideEnum.moraleSkill);
            base.open();
            isFading = true;
            panelRoot.GetComponent<RectTransform>().anchoredPosition = originPos;
            panelRoot.gameObject.SetActive(true);
            PanelRect.localScale = Vector3.zero;
            PanelRect.DOScale(Vector3.one, 0.3f).onComplete = () => isFading = false;
            init();
            putHeroToBox();
        }
    }

    public override void close()
    {

        if (!isFading)
        {
            base.close();
            isFading = true;
            closeBuild();
            PanelRect.DOScale(Vector3.zero, 0.15f).onComplete = () => { isFading = false; panelRoot.gameObject.SetActive(false); };
        }
    }

    void showTipsPanel()
    {
        if (isShowTips) return;
        isShowTips = true;
        Color tempColor = Color.white;
        Text tempText = tipsPanel.GetComponentInChildren<Text>();

        tipsPanel.gameObject.SetActive(true);
        tipsPanel.color = tempColor;
        tempText.color = tempColor;

        tempColor.a = 0;
        Sequence tempSeq = DOTween.Sequence();
        tempSeq.AppendInterval(1).Append(tipsPanel.DOColor(tempColor, 2)).Join(tempText.DOColor(tempColor, 2))
            .onComplete += () => { isShowTips = false; tipsPanel.gameObject.SetActive(false); };
    }
}
