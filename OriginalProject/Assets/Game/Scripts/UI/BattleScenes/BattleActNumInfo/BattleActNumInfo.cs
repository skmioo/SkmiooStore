using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleActNumInfo : MonoBehaviour
{
    public RectTransform RectTrans { get { return transform as RectTransform; } }
    public RectTransform panel;
    public RectTransform heroTeamActNumGroupRectTrans;
    public RectTransform curRoundRectTrans;
    public RectTransform enemyTeamActNumGroupRectTrans;
    public Sprite heroSprite, enemySprite;
    private List<ActNumItem> heroTeamActNumList;
    private Text curRoundText;
    private List<ActNumItem> enemyTeamActNumList;
    private const int ACTNUM_ITEM_WIDTH = 26;
    private const int ACTNUM_ITEM_HIGHT = 26;
    private const int ACTNUM_ITEM_GROUP_OFFWDITH = 10;
    public Team heroTeam;
    public Team enemyTeam;
    /// <summary>
    /// 头顶显示的技能名称
    /// </summary>
    public SkillReleaseInfo goSkillInfo;

    void Awake()
    {
        Validate();
        Hide();
    }
    private void Validate()
    {
       
        curRoundText = curRoundRectTrans.Find("Text").GetComponent<Text>();
        curRoundText.text = string.Empty;

        heroTeamActNumList = new List<ActNumItem>();
        heroTeamActNumGroupRectTrans.sizeDelta = new Vector2(ACTNUM_ITEM_WIDTH, ACTNUM_ITEM_HIGHT);
        heroTeamActNumGroupRectTrans.anchoredPosition = curRoundRectTrans.anchoredPosition - new Vector2(curRoundRectTrans.sizeDelta.x/2 + ACTNUM_ITEM_GROUP_OFFWDITH + heroTeamActNumGroupRectTrans.sizeDelta.x/2,0);
        for (int i = 0; i < heroTeamActNumGroupRectTrans.childCount; ++i)
        {
            int itemp = i;
            heroTeamActNumList.Add(heroTeamActNumGroupRectTrans.GetChild(itemp).GetComponent<ActNumItem>());
            heroTeamActNumList[itemp].Validate(this, RoleType.英雄);
            heroTeamActNumList[itemp].RectTrans.sizeDelta = new Vector2(ACTNUM_ITEM_WIDTH, ACTNUM_ITEM_HIGHT);
            heroTeamActNumList[itemp].RectTrans.anchoredPosition = itemp <= 0 ? Vector2.zero : heroTeamActNumList[itemp - 1].RectTrans.anchoredPosition - new Vector2(heroTeamActNumList[itemp - 1].RectTrans.sizeDelta.x / 2 + ACTNUM_ITEM_GROUP_OFFWDITH + heroTeamActNumList[itemp].RectTrans.sizeDelta.x / 2, 0);
        }
        enemyTeamActNumList = new List<ActNumItem>();
        enemyTeamActNumGroupRectTrans.sizeDelta = new Vector2(ACTNUM_ITEM_WIDTH, ACTNUM_ITEM_HIGHT);
        enemyTeamActNumGroupRectTrans.anchoredPosition = curRoundRectTrans.anchoredPosition + new Vector2(curRoundRectTrans.sizeDelta.x / 2 + ACTNUM_ITEM_GROUP_OFFWDITH + enemyTeamActNumGroupRectTrans.sizeDelta.x / 2, 0);
        for (int i = 0; i < enemyTeamActNumGroupRectTrans.childCount; ++i)
        {
            int itemp = i;
            enemyTeamActNumList.Add(enemyTeamActNumGroupRectTrans.GetChild(itemp).GetComponent<ActNumItem>());
            enemyTeamActNumList[itemp].Validate(this, RoleType.怪物);
            enemyTeamActNumList[itemp].RectTrans.sizeDelta = new Vector2(ACTNUM_ITEM_WIDTH, ACTNUM_ITEM_HIGHT);
            enemyTeamActNumList[itemp].RectTrans.anchoredPosition = itemp <= 0? Vector2.zero : enemyTeamActNumList[itemp-1].RectTrans.anchoredPosition + new Vector2(enemyTeamActNumList[itemp -1].RectTrans.sizeDelta.x / 2+ ACTNUM_ITEM_GROUP_OFFWDITH + enemyTeamActNumList[itemp].RectTrans.sizeDelta.x / 2, 0);
        }
     
    }
   
    public void Initialized(Team _heroTeam, Team _enemyTeam)
    {
        heroTeam = _heroTeam;
        enemyTeam = _enemyTeam;
        List<ObjLife> heros = heroTeam.GetObjLifes();
        List<ObjLife> enemys = enemyTeam.GetObjLifes();

        for (int i = 0; i < heroTeamActNumList.Count; ++i) {
            int itemp = i;
            if (itemp >= heros.Count)
            {
                heroTeamActNumList[itemp].Hide();
                continue;
            }
            if (heros[itemp].GetSize() > 1)
            {
                heroTeamActNumList[itemp].RectTrans.sizeDelta = new Vector2(ACTNUM_ITEM_WIDTH, ACTNUM_ITEM_HIGHT) * heros[itemp].GetSize();
                heroTeamActNumList[itemp].RectTrans.anchoredPosition = itemp <= 0 ? Vector2.zero : heroTeamActNumList[itemp - 1].RectTrans.anchoredPosition - new Vector2(heroTeamActNumList[itemp - 1].RectTrans.sizeDelta.x / 2 + ACTNUM_ITEM_GROUP_OFFWDITH + heroTeamActNumList[itemp].RectTrans.sizeDelta.x / 2, 0);
            }
            heroTeamActNumList[itemp].Initialized(heros[itemp]);
            heroTeamActNumList[itemp].Show();
        }

        for (int i = 0; i < enemyTeamActNumList.Count; ++i)
        {
            int itemp = i;
            if (itemp >= enemys.Count)
            {
                enemyTeamActNumList[itemp].Hide();
                continue;
            }
            //if (enemys[itemp].GetSize() > 1)
            {
                enemyTeamActNumList[itemp].RectTrans.sizeDelta = new Vector2(ACTNUM_ITEM_WIDTH, ACTNUM_ITEM_HIGHT) * enemys[itemp].GetSize();
                enemyTeamActNumList[itemp].RectTrans.anchoredPosition = itemp <= 0 ? Vector2.zero : enemyTeamActNumList[itemp - 1].RectTrans.anchoredPosition + new Vector2(enemyTeamActNumList[itemp - 1].RectTrans.sizeDelta.x / 2 + ACTNUM_ITEM_GROUP_OFFWDITH + enemyTeamActNumList[itemp].RectTrans.sizeDelta.x / 2, 0);
            }
            enemyTeamActNumList[itemp].Initialized(enemys[itemp]);
            enemyTeamActNumList[itemp].Show();
        }
    }
    public void Refresh() {
        //if (!panel.gameObject.activeSelf) return;
        List<ObjLife> heros = heroTeam.GetObjLifes();
        List<ObjLife> enemys = enemyTeam.GetObjLifes();
        for (int i = 0; i < heroTeamActNumList.Count; ++i)
        {
            int itemp = i;
            if (itemp >= heros.Count)
            {
                heroTeamActNumList[itemp].Hide();
                continue;
            }
            // if (heros[itemp].GetSize() > 1)
            {
                heroTeamActNumList[itemp].RectTrans.sizeDelta = new Vector2(ACTNUM_ITEM_WIDTH, ACTNUM_ITEM_HIGHT) * heros[itemp].GetSize();
                heroTeamActNumList[itemp].RectTrans.anchoredPosition = itemp <= 0 ? Vector2.zero : heroTeamActNumList[itemp - 1].RectTrans.anchoredPosition - new Vector2(heroTeamActNumList[itemp - 1].RectTrans.sizeDelta.x / 2 + ACTNUM_ITEM_GROUP_OFFWDITH + heroTeamActNumList[itemp].RectTrans.sizeDelta.x / 2, 0);
            }
            heroTeamActNumList[itemp].Refresh(heros[itemp]);
            heroTeamActNumList[itemp].Show();
        }

        for (int i = 0; i < enemyTeamActNumList.Count; ++i)
        {
            int itemp = i;
            if (itemp >= enemys.Count)
            {
                enemyTeamActNumList[itemp].Hide();
                continue;
            }
           // if (enemys[itemp].GetSize() > 1)
            {
                enemyTeamActNumList[itemp].RectTrans.sizeDelta = new Vector2(ACTNUM_ITEM_WIDTH, ACTNUM_ITEM_HIGHT) * enemys[itemp].GetSize();
                enemyTeamActNumList[itemp].RectTrans.anchoredPosition = itemp <= 0 ? Vector2.zero : enemyTeamActNumList[itemp - 1].RectTrans.anchoredPosition + new Vector2(enemyTeamActNumList[itemp - 1].RectTrans.sizeDelta.x / 2 + ACTNUM_ITEM_GROUP_OFFWDITH + enemyTeamActNumList[itemp].RectTrans.sizeDelta.x / 2, 0);
            }
            enemyTeamActNumList[itemp].Refresh(enemys[itemp]);
            enemyTeamActNumList[itemp].Show();
        }
    }
    public void RefreshCurRoundText(int round) {
        curRoundText.text = round.ToString();
    }
    public void Show() {
        if (panel.gameObject.activeSelf) return;
        panel.gameObject.SetActive(true);
    }
    public void Hide() {
        if (!panel.gameObject.activeSelf) return;
        panel.gameObject.SetActive(false);
    }
 
}
