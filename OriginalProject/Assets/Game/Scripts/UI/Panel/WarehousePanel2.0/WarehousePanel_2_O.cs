using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WarehousePanel_2_O : PanelBase
{
    public static WarehousePanel_2_O instance;

    public Transform panelRoot;

    public Ornaments_2 originOrnaments;

    public Transform tipsPanel;
    public Transform sellTip;

    List<Ornaments_2> OrnamentsList = new List<Ornaments_2>();

    bool isFading;
    bool isSell = false;
    Vector2 originPos;

    RectTransform PanelRect => panelRoot.GetComponent<RectTransform>();

    public UnityEngine.UI.Text topTips;

    private void Awake() { instance = this; }

    private void Start()
    {
        originPos = PanelRect.anchoredPosition;
        creatorList();
    }

    public override void open()
    {
        if (panelRoot.gameObject.activeSelf) close();
        if (!isFading)
        {
            base.open();
            topTips.text = LanguageController.GetValue("饰品");
            AudioManager.Instance.PlayAudio(AudioName.Open_Knapsack_mono, AudioType.Common);
            isFading = true;
            PanelRect.anchoredPosition = originPos;
            tipsPanel.gameObject.SetActive(false);
            sellTip.gameObject.SetActive(false);
            panelRoot.gameObject.SetActive(true);
            PanelRect.DOScale(Vector3.one, 0.3f).onComplete = () =>
            {
                isFading = false;
                refreshList();
            };
        }
    }

    public override void close()
    {
        if (!isFading)
        {
            base.close();
            isFading = true;
            setSellEvent(true);
            PanelRect.DOScale(Vector3.zero, 0.15f).onComplete = () =>
            { isFading = false; panelRoot.gameObject.SetActive(false); };
        }
    }

    /// <summary>
    /// 更新背包
    /// </summary>
    public void refreshList()
    {
        List<Datas.ObjData> objDatas = DataManager.Instance.GetOrnamentDatasFromMode();

        for (int i = 0; i < objDatas.Count; i++)
        {
            if (i >= OrnamentsList.Count)
            {
                creatorMedalBox();
                OrnamentsList[i].setData(objDatas[i], i);
            }
            else
            {
                OrnamentsList[i].setData(objDatas[i], i);
            }

            if (isSell)
                OrnamentsList[i].leftClickEvent = refreshTips;
        }

        if (objDatas.Count < OrnamentsList.Count)
            clearMedalBox(objDatas.Count);
    }

    public void setData() { }

    public void setEvent() { }

    /// <summary>
    /// 增加数据
    /// </summary>
    /// <param name="inData"></param>
    public void addData(Datas.ObjData inData)
    {
        DataManager.Instance.AddOrnamentToMode(inData);
        refreshList();
    }

    /// <summary>
    /// 感觉不应该用这个
    /// </summary>
    /// <param name="inData"></param>
    public void removeData(Datas.ObjData inData)
    {
        OrnamentsList.Remove(OrnamentsList.Find(s => s.getData() == inData));
    }

    /// <summary>
    /// 按职业排序
    /// </summary>
    public void occupationSort()
    {
        AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
        OrnamentsList.Sort((x, y) =>
        {
            if (x.getData() == null && y.getData() == null) return 0;
            else if (x.getData() == null) return 1;
            else if (y.getData() == null) return -1;
            else
            {
                int tempValue = x.getData().heroVocation.CompareTo(y.getData().heroVocation);
                if (tempValue == 0)
                {
                    tempValue = x.getData().levelType.CompareTo(y.getData().levelType);
                    if (tempValue == 0)
                        return x.getData().name.CompareTo(y.getData().name);
                }
                return tempValue;
            }
        });
        refreshSiblingIndex();
    }


    /// <summary>
    /// 按稀有度排序
    /// </summary>
    public void raritySort()
    {
        AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
        OrnamentsList.Sort((x, y) =>
        {
            if (x.getData() == null && y.getData() == null) return 0;
            else if (x.getData() == null) return 1;
            else if (y.getData() == null) return -1;
            else
            {
                int tempValue = x.getData().levelType.CompareTo(y.getData().levelType);
                if (tempValue == 0)
                {
                    tempValue = x.getData().heroVocation.CompareTo(y.getData().heroVocation);
                    if (tempValue == 0)
                        return x.getData().name.CompareTo(y.getData().name);
                }
                return tempValue;
            }
        });
        refreshSiblingIndex();
    }

    /// <summary>
    /// 出售饰品
    /// </summary>
    public void sellOrnamentsBtn()
    {
        AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
        setSellEvent(isSell);
    }

    void setSellEvent(bool inIsSell)
	{
        if (inIsSell)
        {
            for (int i = 0; i < OrnamentsList.Count; i++)
                OrnamentsList[i].leftClickEvent = null;

            isSell = false;
            sellTip.gameObject.SetActive(false);
            refreshList();
        }
        else
        {
            for (int i = 0; i < OrnamentsList.Count; i++)
                OrnamentsList[i].leftClickEvent = refreshTips;

            isSell = true;
            sellTip.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// 移除所有英雄饰品
    /// </summary>
    public void clearAllHeroOrnaments()
    {

        AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
        var tempList = Camp.Instance.clearAllHeroOrnaments();
        for (int i = 0; i < tempList.Count; i++)
            justAddData(tempList[i]);

        refreshList();
    }

    public void testAddOrnaments()
    {
        DataManager.Instance.AddOrnamentToMode(DataManager.Instance.CreateOrnamentData());
        refreshList();
    }


    /// <summary>
    /// 创建起始背包格
    /// </summary>
    void creatorList()
    {
        OrnamentsList.Add(originOrnaments);
        creatorMedalBox(4);

        for (int i = 0; i < 5; i++)
            creatorMedalBox();

        refreshList();
    }


    /// <summary>
    /// 创建背包格
    /// </summary>
    /// <param name="inCount"></param>
    void creatorMedalBox(int inCount = 5)
    {
        GameObject tempObj = null;
        for (int i = 0; i < inCount; i++)
        {
            tempObj = Instantiate(originOrnaments.gameObject);
            tempObj.transform.parent = originOrnaments.transform.parent;
            tempObj.transform.localScale = Vector3.one;
            OrnamentsList.Add(tempObj.GetComponent<Ornaments_2>());
        }
    }


    /// <summary>
    /// 清理背包格
    /// </summary>
    /// <param name="inIndex"></param>
    void clearMedalBox(int inIndex = 0)
    {
        for (int i = inIndex; i < OrnamentsList.Count; i++)
            OrnamentsList[i].clear();
    }


    /// <summary>
    /// 更新背包格位置
    /// </summary>
    void refreshSiblingIndex()
    {
        for (int i = 0; i < OrnamentsList.Count; i++)
            OrnamentsList[i].transform.SetSiblingIndex(i);
    }

    void justAddData(Datas.ObjData inData) { DataManager.Instance.AddOrnamentToMode(inData); }
    void justAddData(int dataID) { justAddData(DataManager.Instance.GetOrnamentDataById(dataID)); }

    void sellOrnaments(Ornaments_2 inOranament)
    {
        AudioManager.Instance.PlayAudio(AudioName.COINS_Rattle_03_mono, AudioType.Common);
        ResPanel.Instance.ChangeResource(inOranament.getData().sell, 0, 0, 0, 0, 0);
        DataManager.Instance.RemoveOrnamentFromMode2(inOranament.getData().id);
        inOranament.clear();
    }

    /// <summary>
    /// 更新出售提示
    /// </summary>
    /// <param name="inOranament"></param>
    void refreshTips(Ornaments_2 inOranament)
    {
        AudioManager.Instance.PlayAudio(AudioName.POP_Mouth_Darker_mono, AudioType.Common);
        tipsPanel.gameObject.SetActive(true);
        Datas.ObjData tempData = inOranament.getData();
        //tipsPanel.Find("tipsText").GetComponent<UnityEngine.UI.Text>().text = $"是否出售{tempData.name}以换取{tempData.sell}磷片";
        tipsPanel.Find("tipsText").GetComponent<UnityEngine.UI.Text>().text =
            LanguageController.GetValue("是否出售") + tempData.name + LanguageController.GetValue("换取") + tempData.sell + LanguageController.GetValue("鳞片");

        UnityEngine.UI.Button tempButton = tipsPanel.Find("confirm").GetComponent<UnityEngine.UI.Button>();
        tempButton.onClick.RemoveAllListeners();
        tempButton.onClick.AddListener(() =>
        {
            sellOrnaments(inOranament);
            tipsPanel.gameObject.SetActive(false);
        });

        tempButton = tipsPanel.Find("cancel").GetComponent<UnityEngine.UI.Button>();
        tempButton.onClick.RemoveAllListeners();
        tempButton.onClick.AddListener(() =>
        {
            tipsPanel.gameObject.SetActive(false);
        });
    }

    public void OnScrollroling()
    {
        AudioManager.Instance.PlayAudio(AudioName.Default_Button_mono, AudioType.Common);
    }
}
