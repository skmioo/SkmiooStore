using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActNumItem : MonoBehaviour
{
    public RectTransform RectTrans { get { return transform as RectTransform; } }
    public RoleType mRoleType;
    /// <summary>
    /// 已行动
    /// </summary>
    [HideInInspector] public RectTransform Acted;
    /// <summary>
    /// 未行动
    /// </summary>
    [HideInInspector] public RectTransform UnActedRect;
    /// <summary>
    /// 未行动点列表
    /// </summary>
    public List<RectTransform> UnActedNumList;
    private int initSiblingIndex;
    public void Validate(BattleActNumInfo info, RoleType _type) {
        mRoleType = _type;
        Acted = transform.Find("Acted") as RectTransform;
        UnActedRect = transform.Find("UnActed") as RectTransform;
        UnActedNumList = new List<RectTransform>();
        for (int i = 0; i < UnActedRect.childCount; ++i)
        {
            UnActedNumList.Add(UnActedRect.GetChild(i) as RectTransform);
            if (mRoleType == RoleType.英雄) UnActedNumList[i].GetComponent<Image>().sprite = i % 2 == 0 ? info.heroSprite : info.enemySprite;
            if (mRoleType == RoleType.怪物) UnActedNumList[i].GetComponent<Image>().sprite = i % 2 == 0 ? info.enemySprite : info.heroSprite;
            UnActedNumList[i].gameObject.SetActive(i == 0 ? true : false);
        }
        initSiblingIndex = RectTrans.GetSiblingIndex();
    }
    public void Initialized(ObjLife _objlife)
    {
        Acted.gameObject.SetActive(false);
        UnActedRect.gameObject.SetActive(true);
        //显示角色行动点
        _objlife.getRoleUiCon.actionCountSet(1);
        for (int i = 0; i < UnActedNumList.Count; ++i)
        {
            if (i >= _objlife.GetActNum()) {
                UnActedNumList[i].gameObject.SetActive(false);
                continue;
            }
            UnActedNumList[i].gameObject.SetActive(true);
        }
    }
    public void Refresh(ObjLife _objlife)
    {
        if (_objlife.CurrentActNum <= 0)
        {
            Acted.gameObject.SetActive(true);
            UnActedRect.gameObject.SetActive(false);
            _objlife.getRoleUiCon.actionCountSet(0);
        }
        else
        {
            _objlife.getRoleUiCon.actionCountSet(1);
            Acted.gameObject.SetActive(false);
            UnActedRect.gameObject.SetActive(true);
            for (int i = 0; i < UnActedNumList.Count; ++i)
            {
                if (i >= _objlife.CurrentActNum)
                {
                    UnActedNumList[i].gameObject.SetActive(false);
                    continue;
                }
                UnActedNumList[i].gameObject.SetActive(true);
            }
        }
    }
    public void Show()
    {
        if (gameObject.activeSelf) return;
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        if (!gameObject.activeSelf) return;
        gameObject.SetActive(false);
    }
}
