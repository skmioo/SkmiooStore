using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class WarehousePanel_2_M : PanelBase
{
    public static WarehousePanel_2_M instance;

    public Transform panelRoot;

    public Medal_2 originMedal;

    List<Medal_2> medalList = new List<Medal_2>();

    bool isFading;
    Vector2 originPos;
    RectTransform PanelRect => panelRoot.GetComponent<RectTransform>();

    public Text topTips;

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
            topTips.text = LanguageController.GetValue("勋章");
            AudioManager.Instance.PlayAudio(AudioName.Open_Knapsack_mono, AudioType.Common);
            isFading = true;
            PanelRect.anchoredPosition = originPos;
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
            PanelRect.DOScale(Vector3.zero, 0.15f).onComplete = () =>
            { isFading = false; panelRoot.gameObject.SetActive(false); };
        }
    }

    /// <summary>
    /// 更新背包
    /// </summary>
    public void refreshList()
    {
        List<MedalObjData> medalObjDatas = DataManager.Instance.GetMedalsFromMode();

        for (int i = 0; i < medalObjDatas.Count; i++)
            if (i >= medalList.Count)
            {
                creatorMedalBox();
                medalList[i].setData(medalObjDatas[i], i);
            }
            else
            {
                medalList[i].setData(medalObjDatas[i], i);
            }

        if (medalObjDatas.Count < medalList.Count)
            clearMedalBox(medalObjDatas.Count);
    }

    public void setData() { }

    public void setEvent() { }

    /// <summary>
    /// 增加数据
    /// </summary>
    /// <param name="inData"></param>
    public void addData(MedalObjData inData)
    {
        DataManager.Instance.AddMedalToMode(inData);
        refreshList();
    }

    /// <summary>
    /// 感觉不应该用这个
    /// </summary>
    /// <param name="inData"></param>
    public void removeData(MedalObjData inData)
    {
        medalList.Remove(medalList.Find(s => s.getData() == inData));
    }

    /// <summary>
    /// 按职业排序(勋章没有职业，直接按星级排序)
    /// </summary>
    public void occupationSort()
    {
        AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);

        medalList.Sort((x, y) =>
        {
            if (x.getData() == null && y.getData() == null) return 0;
            else if (x.getData() == null) return 1;
            else if (y.getData() == null) return -1;
            else
            {
                int tempValue = x.getData().GetLevel().CompareTo(y.getData().GetLevel());
                if (tempValue == 0)
                {
                    tempValue = x.getData().GetLevelType().CompareTo(y.getData().GetLevelType());
                    if (tempValue == 0)
                        return x.getData().GetName().CompareTo(y.getData().GetName());
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
        medalList.Sort((x, y) =>
        {
            if (x.getData() == null && y.getData() == null) return 0;
            else if (x.getData() == null) return 1;
            else if (y.getData() == null) return -1;
            else
            {
                int tempValue = x.getData().GetLevelType().CompareTo(y.getData().GetLevelType());
                if (tempValue == 0)
                {
                    tempValue = x.getData().GetLevel().CompareTo(y.getData().GetLevel());
                    if (tempValue == 0)
                        return x.getData().GetName().CompareTo(y.getData().GetName());
                }
                return tempValue;
            }
        });
        refreshSiblingIndex();
    }

    /// <summary>
    /// 随机添加测试
    /// </summary>
    public void testAddMedal()
    {
        MedalObjData medal = DataManager.Instance.CreateMedal(UnityEngine.Random.Range(1, 7));
        DataManager.Instance.AddMedalToMode(medal);
        refreshList();
    }

    /// <summary>
    /// 创建起始背包格
    /// </summary>
    void creatorList()
    {
        medalList.Add(originMedal);
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
            tempObj = Instantiate(originMedal.gameObject);
            tempObj.transform.parent = originMedal.transform.parent;
            tempObj.transform.localScale = Vector3.one;
            medalList.Add(tempObj.GetComponent<Medal_2>());
        }
    }

    /// <summary>
    /// 清理背包格
    /// </summary>
    /// <param name="inIndex"></param>
    void clearMedalBox(int inIndex = 0)
    {
        for (int i = inIndex; i < medalList.Count; i++)
            medalList[i].clear();
    }

    /// <summary>
    /// 更新背包格位置
    /// </summary>
    void refreshSiblingIndex()
    {
        for (int i = 0; i < medalList.Count; i++)
            medalList[i].transform.SetSiblingIndex(i);
    }
}
