using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class RelicPanel : BuildPanelBase
{
    public static RelicPanel instance;

    public Transform panelRoot;

    public ReilcItem baseRelicItem;
    public ReilcItem halidom1, halidom2, halidom3;

    public ToggleGroup toggleObj;
    public Text hintText;
    int toggleIndex;
    bool isFading;

    Vector2 originPos;

    List<ReilcToggle> toggleAry;
    Stack<ReilcItem> itemPool = new Stack<ReilcItem>();
    Stack<ReilcItem> itemAry = new Stack<ReilcItem>();

    [HideInInspector]
    public List<ReilcItem> reilcAry = new List<ReilcItem>();

    public Text topTips;
    public Text[] relicTips;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        originPos = panelRoot.GetComponent<RectTransform>().anchoredPosition;
        BuildPanelMag.Instance.addBuild(this);
    }

    public override void open()
    {
        if (!isFading)
        {
            NewbieGuideMag.Instance.triggerGuide(GuideDataSet.guideEnum.relic);
            base.open();
            isFading = true;
            panelRoot.GetComponent<RectTransform>().anchoredPosition = originPos;
            panelRoot.gameObject.SetActive(true);
            panelRoot.localScale = Vector3.zero;
            panelRoot.DOScale(Vector3.one, 0.3f).onComplete = () => { isFading = false; init(); };
        }
    }

    public override void close()
    {
        if (!isFading)
        {
            base.close();
            isFading = true;
            closeAllHover();
            panelRoot.DOScale(Vector3.zero, 0.15f).onComplete = () => { isFading = false; panelRoot.gameObject.SetActive(false); };
        }
    }

    public override void init()
    {
        base.init();

        halidom1.itemType = ReilcItem.itemTypeEnum.halidom1;
        halidom2.itemType = ReilcItem.itemTypeEnum.halidom2;
        halidom3.itemType = ReilcItem.itemTypeEnum.halidom3;

        //itemPool.Push(baseRelicItem.GetComponent<ReilcItem>());
        baseRelicItem.gameObject.SetActive(false);
        toggleInit();
        updateHalidom();
        relicGroupInit();
        updateHint();

        topTips.text = LanguageController.GetValue("葬骨地");
        for(int i=0;i<relicTips.Length;i++)
            relicTips[i].text  = LanguageController.GetValue("放置圣物");
    }

    public void recycleItem(ReilcItem inItem)
    {
        inItem.close();
        itemPool.Push(inItem);
    }

    public ReilcItem getNullhalidom()
    {
        if (halidom1.reilcData == null) return halidom1;
        if (halidom2.reilcData == null) return halidom2;
        if (halidom3.reilcData == null) return halidom3;
        return null;
    }

    public void updateHint()
    {
        SacredObjData tempData = halidom1.reilcData;
        List<int> tempIds = new List<int>();
        if (tempData != null) { tempIds.Add(tempData.GetId()); }
        tempData = halidom2.reilcData;
        if (tempData != null) { tempIds.Add(tempData.GetId()); }
        tempData = halidom3.reilcData;
        if (tempData != null) { tempIds.Add(tempData.GetId()); }

        if (tempIds.Count == 0) { hintText.text = LanguageController.GetValue("力量源自羁绊，真理藏于荒谬"); return; }
        if (tempIds.Count >= 1)
        {
            var tempComb = DataManager.Instance.GetSacredObjAction(tempIds);
            if (tempComb == null) { hintText.text = LanguageController.GetValue("你还未领悟力量的真谛"); return; }
            hintText.text = tempComb.ObjActionsToString();
            BattleInfo.SetSacredObjActions(tempComb);
        }
        else { hintText.text = LanguageController.GetValue("你确定?"); }
    }

    public void removeHalidomItem(ReilcItem inItem)
    {
        if (inItem.reilcData.GetArea() == ((SacredArea)toggleIndex))
        {
            creatorItem(inItem.reilcData);
        }
        inItem.Clear();
    }

    public void relicGroupInit()
    {
        ReilcItem tempItem = null;
        while (itemAry.Count > 0) { tempItem = itemAry.Pop(); if (tempItem.gameObject.activeSelf) recycleItem(tempItem); }

        var tempRelicList = DataManager.Instance.GetSacredFromMode();

        var tempList = tempRelicList.FindAll(s => (s.GetArea() == ((SacredArea)toggleIndex) && !s.GetIsBePut()));
        if (tempList.Count == 0) return;

        for (int i = 0; i < tempList.Count; i++)
        {
            creatorItem(tempList[i]);
        }
    }

    void closeAllHover()
    {
        foreach (var tempReilc in reilcAry) tempReilc.pointExit(tempReilc);
    }

    void creatorItem(SacredObjData inData)
    {
        ReilcItem tempItem;
        if (itemPool.Count > 0) tempItem = itemPool.Pop();
        else { tempItem = Instantiate(baseRelicItem.gameObject, baseRelicItem.transform.parent).GetComponent<ReilcItem>(); tempItem.gameObject.SetActive(true); }

        tempItem.itemType = ReilcItem.itemTypeEnum.bagItem;
        tempItem.setReilcData(inData);
        itemAry.Push(tempItem);
    }


    void updateHalidom()
    {
        var tempRelicList = DataManager.Instance.GetSacredFromMode();
        for (int i = 0; i < tempRelicList.Count; i++)
            if (tempRelicList[i].GetIsBePut())
            {
                switch (tempRelicList[i].GetNum())
                {
                    case 1:
                        halidom1.setReilcData(tempRelicList[i]);
                        break;
                    case 2:
                        halidom2.setReilcData(tempRelicList[i]);
                        break;
                    case 3:
                        halidom3.setReilcData(tempRelicList[i]);
                        break;
                }
            }
    }

    void toggleInit()
    {

        toggleAry = new List<ReilcToggle>(toggleObj.GetComponentsInChildren<ReilcToggle>());

        int tempIndex = 0;
        foreach (var tempToggle in toggleAry)
        {
            if (tempToggle.titleObj == null) tempToggle.titleObj = tempToggle.GetComponentInChildren<RawImage>().gameObject;
            tempToggle.titleObj.SetActive(false);
            tempToggle.index = tempIndex;
            tempToggle.titleObj.GetComponentInChildren<UnityEngine.UI.Text>().text = ((SacredArea)tempIndex).ToString();
            //toggleAry[i].onValueChanged.AddListener(delegate { switchGroup(i); });
            tempToggle.onValueChanged.AddListener(inBool => { if (inBool) { switchGroup(tempToggle); } });
            tempIndex++;
        }
    }

    void switchToggle(int inIndex)
    {
        toggleAry[inIndex].isOn = true;
        toggleIndex = inIndex;
    }

    void switchGroup(ReilcToggle inToggle)
    {
        toggleIndex = inToggle.index;
        relicGroupInit();
    }

    void rootDrag()
    {
        UIEventManager.AddTriggersListener(panelRoot.gameObject);
    }
}
