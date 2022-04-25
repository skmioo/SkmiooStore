using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Datas;
using GEvent;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.AddressableAssets;

/// <summary>
/// 营地--出征队伍
/// </summary>
public class Camp : MonoBehaviour
{
    static Camp _instance;
    public static Camp Instance { get { return _instance; } }

    #region 准备弃用
    /// <summary>
    /// 从地牢归来标识
    /// </summary>
    public static bool bShowRoleInfo;
    public static bool backFromBattle;
    public RoleInfo roleInfo;

    public GameObject Ready;
    public Transform box;
    public GameObject roleItemObj;
    private BuildingMode buildingMode;
    private HealBuildingMode healBuildMode;
    private ExtendBoxEquip heroStoreData;
    public GameObject[] goBtns;

    Dictionary<int, RoleData> heroDict = new Dictionary<int, RoleData>();
    List<HeroMode> herosModes = new List<HeroMode>();
    public List<RoleItem> heroTeam = new List<RoleItem>();

    public GameObject roleItem_W;
    public Transform[] waitingTeamBox;
    //出征列表--  考虑到战斗进行中的站位不允许有空位置存在，故出征后会自动缩进队列
    //public List<RoleItem_W> waitingTeam = new List<RoleItem_W>();

    public RoleItem_W[] waitingTeams = new RoleItem_W[4];

    [HideInInspector]
    public Transform OnDrag;

    Dictionary<int, ObjData> ornamentsDataDict = new Dictionary<int, ObjData>();
    Dictionary<int, ObjData> medalDataDict = new Dictionary<int, ObjData>();

    public int nCarryBattleMoney = 0; //出征携带鳞片数(用于显示判断)
    public tempIcoHover oGoBattleTipsHover;

    private void Awake()
    {
        OnDrag = GameObject.Find("OnDrag").transform;
        _instance = this;

        //EventHelper.Instance.AddEvent(GEventType.HeroBusy, RemoveBusyHero);
    }

    private void Start()
    {
        /*DataSetItem data = DataManager.Instance.GetData("RoleData");
        RoleDataSet roleData = data.scriptableObject as RoleDataSet;

        foreach (var item in roleData.heroData)
        {
            heroDict.Add(item.id, item);
        }

        ModeData modeData = DataManager.Instance.modeData;
        herosModes = modeData.herosModes;
        //这个列表如果发生改变，需要及时写入

        buildingMode = modeData.recruitBuildingMode;
        if (modeData.recruitBuildingMode.equipLvs.Count < 2)
        {
            buildingMode.equipLvs = new List<int>(new int[2]);
        }

        DataSetItem buildData = DataManager.Instance.GetData("BuildData");
        BuildDataSet buildDataSet = buildData.scriptableObject as BuildDataSet;
        heroStoreData = buildDataSet.recruitEquip2;

        ResetCampInfo();
        ResetWaitingTeam();

        EventHelper.Instance.ExcuteEvent(GEventType.PreparePanelInitial, null);*/
        StartN();
    }

    void SetEquipmentDict()
    {
        DataSetItem dataSet = DataManager.Instance.GetData("ObjData");
        ObjDataSet objData = dataSet.scriptableObject as ObjDataSet;

        /*foreach (var item in objData.medalDatas)
        {
            medalDataDict.Add(item.id, item);
        }*/

        foreach (var item in objData.ornamentsDatas)
        {
            ornamentsDataDict.Add(item.id, item);
        }
    }

    //取英雄的装备
    HeroEquipment GetHeroEquipment(HeroMode herosMode)
    {
        if (ornamentsDataDict.Count < 1 || medalDataDict.Count < 1)
        {
            SetEquipmentDict();
        }


        HeroEquipment equipment = new HeroEquipment();

        /*if (herosMode.medalID != 0)
        {
            equipment.medal = medalDataDict[herosMode.medalID];
        }

        if (herosMode.ornaments1ID != 0)
        {
            equipment.ornaments1 = ornamentsDataDict[herosMode.ornaments1ID];
        }

        if (herosMode.ornaments2ID != 0)
        {
            equipment.ornaments2 = ornamentsDataDict[herosMode.ornaments2ID];
        }*/
        return equipment;
    }



    #region 营地

    //技能等级的初始化还没做
    void ResetCampInfo()
    {
        //先把盒子下的角色全部删除
        foreach (Transform item in box)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in herosModes)
        {
            RoleData heroData = heroDict[item.heroId];
            GameObject go = Instantiate(roleItemObj, box);
            RoleItem roleItem = go.GetComponent<RoleItem>();
            roleItem.InitItem(GetHeroEquipment(item), heroData, item);
            heroTeam.Add(roleItem);
            ListenerItemClick(go);

            if (item.isHealing)
            {
                roleItem.SetHeal(true);
            }
            else if (item.readyStart)
            {
                roleItem.SetInTeam(true);
            }
        }
    }

    /// <summary>
    /// 一个角色被招募到营地
    /// </summary>
    /// <param name="_heroData"></param>
    public void ReceiveRole(RoleItem roleItem)
    {
        if (herosModes.Count >= heroStoreData.extendNums[buildingMode.equipLvs[0]])
        {
            Debug.Log("队伍满了--");
            return;
        }

        //将招募列表样式替换为英雄列表样式
        GameObject go = Instantiate(roleItemObj, box);
        RoleItem campRoleItem = go.GetComponent<RoleItem>();
        campRoleItem.InitItem(new HeroEquipment(), roleItem.heroData, roleItem.herosMode);

        herosModes.Add(roleItem.herosMode);
        heroTeam.Add(campRoleItem);

        ListenerItemClick(campRoleItem.gameObject);
    }

    void ListenerItemClick(GameObject _go)
    {

        UIEventManager.AddTriggersListener(_go).onLeftClick = go => ItemLeftClick(go);
        UIEventManager.AddTriggersListener(_go).onRightClick = go => ItemRightClick(go);

        UIEventManager.AddTriggersListener(_go).onDrag = (go, eventData) => ItemOnDrag(go, eventData);
        UIEventManager.AddTriggersListener(_go).onEndDrag = (go, eventData) => ItemOnEndDrag(go, eventData);
    }

    /// <summary>
    /// 拖拽时的行为，返回拖拽对象rect
    /// </summary>
    /// <param name="go"></param>
    /// <param name="eventData"></param>
    RectTransform ItemOnDrag(GameObject go, PointerEventData eventData)
    {
        RoleItem onDragRole = go.GetComponent<RoleItem>();
        if (onDragRole.iconBox == null) onDragRole.iconBox = onDragRole.Icon.transform.parent;

        if (onDragRole.isBusy)
            return null;


        RectTransform rectTransform = onDragRole.Icon.GetComponent<RectTransform>();
        //rectTransform.SetParent(Camp.Instance.OnDrag);//拖拽时提高显示层级

        return rectTransform;
    }


    /// <summary>
    /// 结束拖拽
    /// </summary>
    /// <param name="go"></param>
    /// <param name="eventData"></param>
    /// <returns></returns>
    bool ItemOnEndDrag(GameObject go, PointerEventData eventData)
    {

        RoleItem onDragRole = go.GetComponent<RoleItem>();
        onDragRole.Icon.transform.SetParent(onDragRole.iconBox);
        onDragRole.Icon.transform.localPosition = Vector3.zero;


        //两种情况, 一种是拖入后 格子中没有角色, 另外一种是 拖入后格子中有角色
        if (eventData.pointerEnter != null)
        {
            //S_bug.showDebug(eventData.pointerEnter.name, debugColorEnum.yellow);
            if (eventData.pointerEnter.transform.parent.tag == "Team_WaitingStart")
            {
                //onDragRole.Icon.transform.SetAsFirstSibling();
                RemoveRoleInWaitingTeam(eventData.pointerEnter);
                //AddRoleToWaiting(go, eventData.pointerEnter.transform.parent);
            }
            else if (eventData.pointerEnter.tag == "Team_WaitingStart")
            {
                //onDragRole.Icon.transform.SetAsFirstSibling();
                //旧版的头像拖入出征
                //AddRoleToWaiting(go, eventData.pointerEnter.transform);
            }

            if (eventData.pointerEnter.name.Equals("heroBox"))
            {
                SkillUpPanel skillUpPanel = eventData.pointerEnter.GetComponentInParent<SkillUpPanel>();
                //onDragRole.Icon.transform.SetAsFirstSibling();
                if (skillUpPanel != null)
                {
                    skillUpPanel.ShowRoleData(onDragRole);
                }
            }
            if (eventData.pointerEnter.name.Equals("healBox"))
            {
                HealBox healBox = eventData.pointerEnter.GetComponent<HealBox>();
                //onDragRole.Icon.transform.SetAsFirstSibling();
                if (healBox != null)
                {
                    healBox.OnPutHeroIn(onDragRole);
                }
            }
            if (eventData.pointerEnter.name.Equals("heroMoraleBox"))
            {
                HeroMoraleBox heroMoraleBox = eventData.pointerEnter.GetComponent<HeroMoraleBox>();
                //onDragRole.Icon.transform.SetAsFirstSibling();
                if (heroMoraleBox != null)
                {
                    heroMoraleBox.OnPutHeroIn(onDragRole);
                }
            }
            if (eventData.pointerEnter.name.Equals("RoleItem(Clone)"))
            {
                var tempRole = eventData.pointerEnter.GetComponent<RoleItem>();
                if (tempRole != null)
                {
                    switchCampHero(onDragRole, tempRole);
                }
            }
            onDragRole.Icon.transform.SetAsFirstSibling();
        }
        else
        {
            onDragRole.Icon.transform.SetAsFirstSibling();
            //如果拖入空处，且角色正在出征状态

            //RemoveRoleInWaitingTeam(go);
        }

        return false;
    }

    //Action<BasePanel> getPanel;

    private void ItemRightClick(GameObject go)
    {
        RoleItem roleItem = go.GetComponent<RoleItem>();
        //右键点击显示角色信息面板
        roleInfo.ShowMe(roleItem, this);

        //UIManager.Instance.GetpanelAndPushAsync(UIPanelType.RoleInfoPanel).GetPanelComleted = panel =>
        //{
        //    RoleInfoPanel roleInfoPanel = panel as RoleInfoPanel;
        //    roleInfoPanel.ShowMe(roleItem, this);
        //    roleInfo = roleInfoPanel.roleInfo;
        //};
    }

    private void ItemLeftClick(GameObject go)
    {
        if (Ready.activeSelf)
        {
            AudioManager.Instance.PlayAudio(AudioName.Chick_Camp_Hero_mono, AudioType.Common);
            AddRoleToWaiting(go, null);
        }
        //左键点击角色后，角色进入出征队列---并将角色标注为出征状态     
    }

    /// <summary>
    /// 从营地中移除一个角色
    /// </summary>
    /// <param name="go"></param>
    public void ReMoveRoleCamp(RoleItem roleItem)
    {
        if (roleItem.herosMode.readyStart)
        {
            Debug.Log("当前角色正在出征状态,请让他回到营地再解雇");
            return;
        }



        herosModes.Remove(roleItem.herosMode);
        heroTeam.Remove(roleItem);
        Destroy(roleItem.gameObject);
    }


    #endregion

    #region 出征队伍
    //重置等待出征的队伍
    void ResetWaitingTeam()
    {
        //waitingTeam.Clear();

        foreach (var item in heroTeam)
        {
            if (item.herosMode.readyStart)
            {
                GameObject go = Instantiate(roleItem_W, waitingTeamBox[item.herosMode.numInTeam_Waiting]);
                RoleItem_W roleItemW = go.GetComponent<RoleItem_W>();

                roleItemW.InitItem(item, item.herosMode.numInTeam_Waiting);
                //waitingTeam.Add(roleItemW);

                waitingTeams[item.herosMode.numInTeam_Waiting] = roleItemW;
                ListenerItem_WClick(go);
            }
        }

        CheckWaitTeam();
    }

    /// <summary>
    /// 旧添加角色到出征
    /// </summary>
    /// <param name="go"></param>
    /// <param name="box"></param>
    void AddRoleToWaiting(GameObject go, Transform box)
    {
        int num = 0;
        Transform checkBox = null;

        if (box == null)
        {
            checkBox = CheckNullBox(out num);
        }
        else
        {
            checkBox = box;
            for (int i = 0; i < waitingTeamBox.Length; i++)
            {
                if (waitingTeamBox[i] == checkBox)
                {
                    num = i;
                }
            }
        }
        if (checkBox == null)
        {
            Debug.Log("出征队伍满了");
            return;
        }

        RoleItem roleItem = go.GetComponent<RoleItem>();

        if (roleItem.herosMode.readyStart)
        {
            return;
        }

        //创建角色，把信息加入队伍
        GameObject _go = Instantiate(roleItem_W, checkBox);
        RoleItem_W _rolteItem = _go.GetComponent<RoleItem_W>();
        _rolteItem.InitItem(roleItem, num);
        roleItem.herosMode.readyStart = true;
        roleItem.SetInTeam(true);

        //waitingTeam.Add(_rolteItem);
        waitingTeams[num] = _rolteItem;

        ListenerItem_WClick(_go);

        CheckWaitTeam();
    }

    //在出征队伍中移除一个角色
    void RemoveRoleInWaitingTeam(GameObject go)
    {
        AudioManager.Instance.PlayAudio(AudioName.Delete_Hero_mono, AudioType.Common);
        RoleItem_W roleItem_W = go.GetComponent<RoleItem_W>();

        //waitingTeam.Remove(roleItem_W);//移除列表
        for (int i = 0; i < waitingTeams.Length; i++)
        {
            if (waitingTeams[i] == roleItem_W)
            {
                waitingTeams[i] = null;
            }
        }


        roleItem_W.roleItem.herosMode.readyStart = false;
        roleItem_W.roleItem.SetInTeam(false);

        RemoveListenerItem(roleItem_W.gameObject);
        Destroy(roleItem_W.gameObject);

        CheckWaitTeam();
    }


    void ListenerItem_WClick(GameObject _go)
    {
        UIEventManager.AddTriggersListener(_go).onLeftClick += Item_WLeftClick;
        UIEventManager.AddTriggersListener(_go).onRightClick += Item_WRightClick;

        UIEventManager.AddTriggersListener(_go).onDrag += Item_WOnDrag;
        UIEventManager.AddTriggersListener(_go).onEndDrag += Item_WEndDarg;
    }

    void RemoveListenerItem(GameObject _go)
    {
        UIEventManager.AddTriggersListener(_go).onLeftClick -= Item_WLeftClick;
        UIEventManager.AddTriggersListener(_go).onRightClick -= Item_WRightClick;

        UIEventManager.AddTriggersListener(_go).onDrag -= Item_WOnDrag;
        UIEventManager.AddTriggersListener(_go).onEndDrag -= Item_WEndDarg;
    }

    void Item_WRightClick(GameObject go)
    {
        RoleItem_W roleItemW = go.GetComponent<RoleItem_W>();
        //右键点击显示角色信息面板
        roleInfo.ShowMe(roleItemW.roleItem, null);

        //UIManager.Instance.GetpanelAndPushAsync(UIPanelType.RoleInfoPanel).GetPanelComleted = panel =>
        //{
        //    RoleInfoPanel roleInfoPanel = panel as RoleInfoPanel;
        //    roleInfoPanel.ShowMe(roleItemW.roleItem, null);

        //    roleInfo = roleInfoPanel.roleInfo;
        //};
    }

    void Item_WLeftClick(GameObject go)
    {

    }

    RectTransform Item_WOnDrag(GameObject go, PointerEventData eventData)
    {
        RoleItem_W roleItem_W = go.GetComponent<RoleItem_W>();
        RectTransform rectTransform = roleItem_W.icon.GetComponent<RectTransform>();
        roleItem_W.icon.transform.SetParent(OnDrag);

        return rectTransform;
    }

    void Item_WEndDarg(GameObject go, PointerEventData eventData)
    {
        RoleItem_W roleItem_W = go.GetComponent<RoleItem_W>();

        roleItem_W.icon.transform.SetParent(roleItem_W.iconBox);

        roleItem_W.icon.transform.localPosition = Vector3.zero;


        if (eventData.pointerEnter == null)
        {
            ;
            RemoveRoleInWaitingTeam(go);

        }



        //只要不拖拽不在这个里面就移除
        if (eventData.pointerEnter.tag == "Team_WaitingStart" || eventData.pointerEnter.transform.parent.tag == "Team_WaitingStart")
        {
            int num = 0;

            Transform targetBox = eventData.pointerEnter.transform;

            //目标位置中有角色
            if (eventData.pointerEnter.tag != "Team_WaitingStart")
            {
                //改目标盒子
                targetBox = targetBox.parent;
                RoleItem_W roleItem_W1 = eventData.pointerEnter.GetComponent<RoleItem_W>();
                roleItem_W1.roleItem.herosMode.numInTeam_Waiting = roleItem_W.roleItem.herosMode.numInTeam_Waiting;

                eventData.pointerEnter.transform.SetParent(go.transform.parent);
                eventData.pointerEnter.transform.localPosition = Vector3.zero;
            }

            for (int i = 0; i < waitingTeamBox.Length; i++)
            {
                if (waitingTeamBox[i] == targetBox)//目标点的格子号码
                {
                    num = i;
                }
            }

            //调整数组位置,出征后站位用
            waitingTeams[roleItem_W.roleItem.herosMode.numInTeam_Waiting] = waitingTeams[num];//原位置=目标位置

            waitingTeams[num] = roleItem_W;//目标位置，等于拿起的角色

            roleItem_W.roleItem.herosMode.numInTeam_Waiting = num;
            go.transform.SetParent(targetBox);
            go.transform.localPosition = Vector3.zero;

        }
        else
        {
            RemoveRoleInWaitingTeam(go);
        }

        CheckWaitTeam();

    }


    Transform CheckNullBox(out int num)
    {

        for (int i = 0; i < waitingTeamBox.Length; i++)
        {
            if (waitingTeamBox[i].childCount < 1)
            {
                num = i;
                return waitingTeamBox[i];
            }
        }
        num = 0;
        return null;
    }

    void RemoveBusyHero(Hashtable args)
    {
        RoleItem roleItem;
        if (args["HeroItem"] != null)
        {
            roleItem = args["HeroItem"] as RoleItem;
            for (int i = 0; i < waitingTeams.Length; i++)
            {
                if (waitingTeams[i] != null)
                {
                    if (roleItem.Equals(waitingTeams[i].roleItem))
                    {
                        RemoveRoleInWaitingTeam(waitingTeams[i].gameObject);
                        break;
                    }
                }
            }
        }
    }

    /// <summary>
    /// 检查出征队伍中是否有角色--若没有角色,关闭补给与出征按钮
    /// </summary>
    void CheckWaitTeam()
    {

        bool isshow = false;
        foreach (var item in BattleInfo.waitingTeams)
        {
            isshow = true;
            break;
        }

        foreach (var item in goBtns)
        {
            item.SetActive(isshow);
        }

        CheckGoBattleTipsShow();
    }

    /// <summary>
    /// 设置出征携带鳞片记录
    /// </summary>
    public void SetCarryBattleMoney(int nValue)
    {
        nCarryBattleMoney = nValue;
        CheckGoBattleTipsShow();
    }

    /// <summary>
    /// 检查是否需要显示出征提示
    /// </summary>
    public void CheckGoBattleTipsShow()
    {
        if(BattleInfo.waitingTeams.Count != 0 && ((BattleInfo.waitingTeams.Count >= 1 && BattleInfo.waitingTeams.Count < 4) || nCarryBattleMoney == 0))
        {
            oGoBattleTipsHover.gameObject.SetActive(true);
            string sTips = "";
            if(BattleInfo.waitingTeams.Count >= 1 && BattleInfo.waitingTeams.Count < 4)
            {
                sTips = LanguageController.GetValue("小队人数不足可继续添加");
                if(nCarryBattleMoney == 0)
                {
                    sTips = sTips + "\n\n" + LanguageController.GetValue("未携带鳞片无法购买道具");
                }
            }
            else
            {
                sTips = LanguageController.GetValue("未携带鳞片无法购买道具");
            }
            oGoBattleTipsHover.UpdateText(sTips);
        }
        else
        {
            oGoBattleTipsHover.gameObject.SetActive(false);
        }
    }

    #endregion
    #endregion


    public GameObject goRoleItem;
    public GameObject goBox;

    public RoleInfoPanel roleInfoPanel;

    public GameObject[] gosToBattle;
    private bool[] isOiccupied = new bool[4] { false, false, false, false };
    private ObjLifeData[] battleBoxDatas = new ObjLifeData[4];
    private Sprite sprNotOiccupied;

    private int maxHeroCount = 8;

    private Dictionary<ObjLifeData, GameObject> objLifeDataDic = new Dictionary<ObjLifeData, GameObject>();

    Vector3 battleIcoPos = Vector3.zero;
    Transform battleIcoParent;

    public Text campHeroText;

    /// <summary>
    /// 这里偷懒先这样了
    /// 排序类型
    /// 1 勋章
    /// 2 士气
    /// 3 职业
    /// </summary>
    int sortType = -1;

    private void StartN()
    {
        ResetAll();
    }

    public void setHeroCount(int inCount)
    {
        if (inCount < maxHeroCount) return;
        if (inCount > 28) maxHeroCount = 28;
        else maxHeroCount = inCount;
        campHeroText.text = objLifeDataDic.Count + "/" + maxHeroCount;
    }

    public Dictionary<ObjLifeData, GameObject> getObjLifeData() { return objLifeDataDic; }

    public ObjLifeData[] getBattleBoxData() { return battleBoxDatas; }

    public void ComeBack()
    {
        backFromBattle = true;
        ResetAll();
    }

    public void ResetAll()
    {
        Debug.Log("camp ResetAll");
        nCarryBattleMoney = DataManager.Instance.modeData.carryBattleMoneyMode.count;

        objLifeDataDic.Clear();
        List<ObjLifeData> objLifeDatas = DataManager.Instance.GetHeroModeData();
        foreach (var obj in objLifeDatas)
        {
            InitHero(obj);
        }

        BattleInfo.waitingTeams.Clear();
        for (int i = 0; i < isOiccupied.Length; ++i)
        {
            isOiccupied[i] = false;
        }
        sprNotOiccupied = gosToBattle[0].GetComponent<Image>().sprite;
        CheckWaitTeam();

    }

    /// <summary>
    /// 刷新所有角色数据
    /// </summary>
    public void refreshAllHeroData()
    {
        RoleItem tempItem;
        foreach (var tempData in objLifeDataDic)
        {
            tempItem = tempData.Value.GetComponent<RoleItem>();
            tempItem.refreshData();
        }

        //被砍掉了
        //RoleItem tempItem = null;
        //foreach (var tempGo in objLifeDataDic)
        //{
        //    tempItem = tempGo.Value.GetComponent<RoleItem>();
        //    tempItem.injuries.text = $"伤势：{tempGo.Key.GetInjuries()}";
        //    tempItem.morale.text = $"士气：{tempGo.Key.GetMorale()}";
        //}
    }
    /// <summary>
    /// 招募英雄
    /// </summary>
    /// <param name="objLifeData"></param>
    /// <returns></returns>
    public bool RecruitHero(ObjLifeData objLifeData)
    {
        if (objLifeDataDic.Count < maxHeroCount)
        {
            InitHero(objLifeData);
            DataManager.Instance.AddHeroToMode(objLifeData);
            campHeroText.text = objLifeDataDic.Count + "/" + maxHeroCount;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Expel(ObjLifeData objLifeData)
    {
        var tempIndex = getIndexForData(objLifeData);
        RemoveHeroFromBattle(objLifeData, tempIndex);
        Destroy(objLifeDataDic[objLifeData]);
        objLifeDataDic.Remove(objLifeData);
        DataManager.Instance.RemoveHeroFromMode(objLifeData);
        campHeroText.text = objLifeDataDic.Count + "/" + maxHeroCount;
    }

    public void Rename(ObjLifeData objLifeData)
    {      
        objLifeDataDic[objLifeData].GetComponent<RoleItem>()._name.text = objLifeData.GetHeroName();
    }

    public ObjLifeData getDateForObj(GameObject inGo)
    {
        foreach (var temp in objLifeDataDic)
            if (temp.Value == inGo) return temp.Key;
        return null;
    }

    public List<GameObject> getLifeDateValues() { return objLifeDataDic.Values.ToList(); }

    public int getIndexForData(ObjLifeData inData)
    {
        for (int i = 0; i < battleBoxDatas.Length; i++)
            if (battleBoxDatas[i] == inData) return i;
        return -1;
    }

    /// <summary>
    /// 勋章排序
    /// </summary>
    public void medalSort()
    {
        AudioManager.Instance.PlayAudio(AudioName.Hore_Sort, AudioType.Common);
        MedalData tempMedal, tempMedal2;
        int tempValue;

        var tempList = objLifeDataDic.ToList();
        tempList.Sort((x, y) =>
        {
            tempMedal = DataManager.Instance.GetMedalDataById(x.Key.GetMedal().objId);
            tempMedal2 = DataManager.Instance.GetMedalDataById(y.Key.GetMedal().objId);

            if (tempMedal == null && tempMedal2 == null) return 0;
            else if (tempMedal == null) return 1;
            else if (tempMedal2 == null) return -1;
            else
            {
                tempValue = tempMedal.level.CompareTo(tempMedal2.level);
                if (tempValue == 0)
                {
                    tempValue = tempMedal.levelType.CompareTo(tempMedal2.levelType);
                    if (tempValue == 0)
                        return tempMedal.name.CompareTo(tempMedal2.name);
                }
                return tempValue;
            }
        });

        if (sortType == 1)
        {
            for (int i = 0; i < tempList.Count; i++)
                tempList[i].Value.transform.SetAsFirstSibling();
            sortType = -1;
        }
        else
        {
            for (int i = 0; i < tempList.Count; i++)
                tempList[i].Value.transform.SetAsLastSibling();
            sortType = 1;
        }
    }

    /// <summary>
    /// 士气排序
    /// </summary>
    public void moraleSort()
    {
        ObjLifeData tempData, tempData2;
        int tempValue;
        AudioManager.Instance.PlayAudio(AudioName.Hore_Sort, AudioType.Common);
        var tempList = objLifeDataDic.ToList();
        tempList.Sort((x, y) =>
        {
            tempData = x.Key;
            tempData2 = y.Key;

            tempValue = tempData.GetMorale().CompareTo(tempData2.GetMorale());
            if (tempValue == 0)
                return tempData.GetHeroName().CompareTo(tempData2.GetHeroName());

            return tempValue;
        });


        if (sortType == 2)
        {
            for (int i = 0; i < tempList.Count; i++)
                tempList[i].Value.transform.SetAsLastSibling();
            sortType = -1;
        }
        else
        {
            for (int i = 0; i < tempList.Count; i++)
                tempList[i].Value.transform.SetAsFirstSibling();
            sortType = 2;
        }
    }

    /// <summary>
    /// 职业排序
    /// </summary>
    public void occupationSort()
    {
        ObjLifeData tempData, tempData2;
        int tempValue;
        AudioManager.Instance.PlayAudio(AudioName.Hore_Sort, AudioType.Common);
        var tempList = objLifeDataDic.ToList();
        tempList.Sort((x, y) =>
        {
            tempData = x.Key;
            tempData2 = y.Key;

            tempValue = tempData.GetVocation().CompareTo(tempData2.GetVocation());
            if (tempValue == 0)
                return tempData.GetHeroName().CompareTo(tempData2.GetHeroName());

            return tempValue;
        });


        if (sortType == 3)
        {
            for (int i = 0; i < tempList.Count; i++)
                tempList[i].Value.transform.SetAsLastSibling();
            sortType = -1;
        }
        else
        {
            for (int i = 0; i < tempList.Count; i++)
                tempList[i].Value.transform.SetAsFirstSibling();
            sortType = 3;
        }
    }

    /// <summary>
    /// 自动添加角色到出征
    /// </summary>
    public void AutoFillBattleBox()
    {
        StartCoroutine(FillBattle());
    }

    /// <summary>
    /// 移除所有角色饰品
    /// </summary>
    /// <returns></returns>
    public List<int> clearAllHeroOrnaments()
    {
        int tempID = 0;
        List<int> tempIDAry = new List<int>();
        foreach (var tempData in objLifeDataDic)
        {
            tempID = 0;
            tempID = tempData.Key.GetOrnamentId(1);
            if (tempID != 0) { tempIDAry.Add(tempID); tempData.Key.RemoveOrnament(1); }

            tempID = 0;
            tempID = tempData.Key.GetOrnamentId(2);
            if (tempID != 0) { tempIDAry.Add(tempID); tempData.Key.RemoveOrnament(2); }
        }

        roleInfoPanel.clearOrnament();
        return tempIDAry;
    }

    /// <summary>
    /// 延时添加角色到出征
    /// </summary>
    /// <returns></returns>
    IEnumerator FillBattle()
    {
        yield return new WaitForSeconds(0.5f);

        var tempList = objLifeDataDic.Keys.ToArray();
        for (int i = 0; i < tempList.Length; i++)
            if (tempList[i].GetReadyStart())
            {
                //S_debug.showDebug("" + i);
                int nLastIndex = tempList[i].GetNumInTeamWaiting();
                AddHeroToBattle(tempList[i], nLastIndex);
            }
    }

    /// <summary>
    /// 判断角色是否在出征
    /// </summary>
    /// <param name="inData"></param>
    /// <returns></returns>
    bool isHeroInBox(ObjLifeData inData)
    {
        for (int i = 0; i < battleBoxDatas.Length; i++)
            if (battleBoxDatas[i] == inData) return true;
        return false;
    }

    int getHeroIndexByData(ObjLifeData inData)
    {
        for (int i = 0; i < battleBoxDatas.Length; i++)
            if (battleBoxDatas[i] == inData) return i;
        return -1;
    }

    /// <summary>
    /// 初始化英雄实体
    /// </summary>
    /// <param name="objLifeData"></param>
    private void InitHero(ObjLifeData objLifeData)
    {
        GameObject goHero = Instantiate(goRoleItem, goBox.transform);
        RoleItem roleItem = goHero.GetComponent<RoleItem>();
        roleItem._name.text = objLifeData.GetHeroName();
        objLifeData.GetIcon().LoadAssetAsync().Completed += go => roleItem.Icon.sprite = go.Result;
        roleItem.objLifeData = objLifeData;
        roleItem.refreshData();

        objLifeDataDic.Add(objLifeData, goHero);

        {
            //UIEventManager.AddTriggersListener(goHero).onRightClick = go => roleInfoPanel.Show(objLifeData, true, true, true);
            //UIEventManager.AddTriggersListener(goHero).onLeftClick = go =>
            //{
            //    if (Ready.activeSelf && isOiccupied.Any(s => !s))
            //    {
            //        AddHeroToBattle(objLifeData);
            //    }
            //};

            ////UIEventManager.AddTriggersListener(goHero).onDrag = (go, eventData) => ItemOnDrag(go, eventData);
            //UIEventManager.OnDragFunc(goHero, ItemOnDrag);
            //UIEventManager.AddTriggersListener(goHero).onEndDrag = (go, eventData) => ItemOnEndDrag(go, eventData);
            //UIEventManager.AddTriggersListener(goHero).onEndDrag += (go, eventData) =>
            //{
            //    if (Ready.activeSelf && isOiccupied.Any(s => !s))
            //    {
            //        AddHeroToBattle(objLifeData);
            //    }
            //};
        }

        initHeroEvent(goHero, objLifeData);
    }

    void initHeroEvent(GameObject inGO, ObjLifeData inObjData)
    {

        UIEventManager.AddTriggersListener(inGO).onRightClick = go => roleInfoPanel.Show(inObjData, true, true, true);
        UIEventManager.AddTriggersListener(inGO).onLeftClick = go =>
        {
            if (Ready.activeSelf && isOiccupied.Any(s => !s))
            {
                AddHeroToBattle(inObjData);
            }
        };

        //UIEventManager.AddTriggersListener(goHero).onDrag = (go, eventData) => ItemOnDrag(go, eventData);
        UIEventManager.OnDragFunc(inGO, ItemOnDrag);
        UIEventManager.AddTriggersListener(inGO).onEndDrag = (go, eventData) => ItemOnEndDrag(go, eventData);
        UIEventManager.AddTriggersListener(inGO).onEndDrag += (go, eventData) =>
        {
            if (Ready.activeSelf && isOiccupied.Any(s => !s) && !Camp.bShowRoleInfo)
            {
                int nDragIndex = -1;
                Transform targetBox = eventData.pointerEnter.transform;

                //目标位置中有角色
                if (eventData.pointerEnter.tag != "Team_WaitingStart")
                {
                    //改目标盒子
                    targetBox = targetBox.parent;
                }

                for (int i = 0; i < waitingTeamBox.Length; i++)
                {
                    if (waitingTeamBox[i] == targetBox)//目标点的格子号码
                    {
                        nDragIndex = i;
                    }
                }

                ObjLifeData objLifeData = null;
                if(nDragIndex >= 0)
                    objLifeData = battleBoxDatas[nDragIndex];
                if(objLifeData != null)
                    RemoveHeroFromBattle(objLifeData, nDragIndex);

                var tempIndex = getIndexForData(inObjData);
                if(tempIndex >= 0)
                    RemoveHeroFromBattle(inObjData, tempIndex);
                
                AddHeroToBattle(inObjData, nDragIndex);
            }
        };
    }

    /// <summary>
    /// 添加角色到出征
    /// </summary>
    /// <param name="objLifeData"></param>
    private void AddHeroToBattle(ObjLifeData objLifeData, int nIndex = -1)
    {
        if (isHeroInBox(objLifeData)) return;
        if (nIndex == -1)
        {
            for (int i = 0; i < isOiccupied.Length; i++)
                if (!isOiccupied[i])
                {
                    nIndex = i;
                    break;
                }
        }

        if (nIndex == -1) return;
        else
        {
            if (objLifeData.GetIsHealing())
            {
                objLifeData.SetNumInTeamWaiting(-1);
                objLifeData.SetReadyStart(false);
                return;
            }
            isOiccupied[nIndex] = true;
            battleBoxDatas[nIndex] = objLifeData;
            objLifeData.SetReadyStart(true);
            objLifeData.SetNumInTeamWaiting(nIndex);
            objLifeDataDic[objLifeData].GetComponent<RoleItem>().SetInTeam(true);
            Debug.Log($"测试-AddHeroToBattle-{nIndex}");
            BattleInfo.waitingTeams.Add(nIndex, objLifeData);

            InitHeroToBattle(objLifeData.GetIcon(), gosToBattle[nIndex].GetComponent<Image>());
            AddClickEvent(gosToBattle[nIndex], objLifeData, nIndex);
        }
        CheckWaitTeam();
    }

    private void InitHeroToBattle(AssetReferenceSprite ars, Image image)
    {
        ars.LoadAssetAsync().Completed += go => image.sprite = go.Result;
    }

    private void AddClickEvent(GameObject go, ObjLifeData objLifeData, int index)
    {
        UIEventManager.AddTriggersListener(go).onRightClick = g =>
        {
            if (isOiccupied[index])
            {
                roleInfoPanel.Show(objLifeData, true, false, true);
            }
        };
        UIEventManager.AddTriggersListener(go).onLeftClick = g =>
        {
            if (isOiccupied[index])
            {
                RemoveHeroFromBattle(objLifeData, index);
            }
        };

        UIEventManager.OnDragFunc(go, battleIcoDrag);
        UIEventManager.AddTriggersListener(go).onEndDrag = battleIcoEndDrag;
    }

    /// <summary>
    /// 从出征移除
    /// </summary>
    /// <param name="objLifeData"></param>
    /// <param name="index"></param>
    public void RemoveHeroFromBattle(ObjLifeData objLifeData, int index)
    {
        objLifeData.SetReadyStart(false);
        objLifeData.SetNumInTeamWaiting(-1);
        objLifeDataDic[objLifeData].GetComponent<RoleItem>().SetInTeam(false);


        if (index != -1)
        {
            Debug.Log($"测试-RemoveHeroFromBattle");
            isOiccupied[index] = false;
            battleBoxDatas[index] = null;
            BattleInfo.waitingTeams.Remove(index);
            gosToBattle[index].GetComponent<Image>().sprite = sprNotOiccupied;
        }

        CheckWaitTeam();
    }

    /// <summary>
    /// 列表角色互换
    /// 要交互动画就重写把....
    /// </summary>
    /// <param name="inRole"></param>
    /// <param name="inRole2"></param>
    void switchCampHero(RoleItem inRole, RoleItem inRole2)
    {
        ObjLifeData tempObjData = inRole.objLifeData;
        ObjLifeData tempObjData2 = inRole2.objLifeData;
        Sprite tempSprite = inRole.Icon.sprite;
        Sprite tempSprite2 = inRole2.Icon.sprite;
        bool tempInTeam = inRole.isInTeam();
        bool tempInTeam2 = inRole2.isInTeam();

        inRole._name.text = tempObjData2.GetHeroName();
        inRole.Icon.sprite = tempSprite2;
        inRole.objLifeData = tempObjData2;
        inRole.refreshData();
        inRole.SetInTeam(tempInTeam2 ? true : false);
        objLifeDataDic[inRole.objLifeData] = inRole.gameObject;
        initHeroEvent(inRole.gameObject, inRole.objLifeData);

        inRole2._name.text = tempObjData.GetHeroName();
        inRole2.Icon.sprite = tempSprite;
        inRole2.objLifeData = tempObjData;
        inRole2.refreshData();
        inRole2.SetInTeam(tempInTeam ? true : false);
        objLifeDataDic[inRole2.objLifeData] = inRole2.gameObject;
        initHeroEvent(inRole2.gameObject, inRole2.objLifeData);

    }

    /// <summary>
    /// 队列与出征交换
    /// </summary>
    /// <param name="inData"></param>
    /// <param name="outData"></param>
    /// <param name="inIndex"></param>
    void switchHeroToBattle(ObjLifeData inData, ObjLifeData outData, int inIndex)
    {
        if (isHeroInBox(inData)) return;
        if (inData.GetIsHealing())
        {
            inData.SetNumInTeamWaiting(-1);
            inData.SetReadyStart(false);
            return;
        }

        //remove ---------------------
        isOiccupied[inIndex] = false;
        outData.SetReadyStart(false);
        outData.SetNumInTeamWaiting(-1);
        BattleInfo.waitingTeams.Remove(inIndex);
        objLifeDataDic[outData].GetComponent<RoleItem>().SetInTeam(false);

        //add ---------------------
        isOiccupied[inIndex] = true;
        battleBoxDatas[inIndex] = inData;
        inData.SetReadyStart(true);
        inData.SetNumInTeamWaiting(inIndex);
        BattleInfo.waitingTeams.Add(inIndex, inData);
        objLifeDataDic[inData].GetComponent<RoleItem>().SetInTeam(true);


        inData.GetIcon().LoadAssetAsync().Completed += go => gosToBattle[inIndex].GetComponent<Image>().sprite = go.Result;
        AddClickEvent(gosToBattle[inIndex], inData, inIndex);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="inIndex1">拖拽</param>
    /// <param name="inIndex2">释放</param>
    void switchHeroToBox(int inIndex1, int inIndex2)
    {
        var indexData1 = battleBoxDatas[inIndex1];
        var indexData2 = battleBoxDatas[inIndex2];

        battleBoxDatas[inIndex2] = indexData1;
        indexData1.SetNumInTeamWaiting(inIndex2);
        BattleInfo.waitingTeams[inIndex2] = indexData1;
        indexData1.GetIcon().LoadAssetAsync().Completed += go => gosToBattle[inIndex2].GetComponent<Image>().sprite = go.Result;
        AddClickEvent(gosToBattle[inIndex2], indexData1, inIndex2);

        if (!isOiccupied[inIndex2])
        {
            isOiccupied[inIndex1] = false;
            isOiccupied[inIndex2] = true;
            battleBoxDatas[inIndex1] = null;
            BattleInfo.waitingTeams.Remove(inIndex1);
            gosToBattle[inIndex1].GetComponent<Image>().sprite = sprNotOiccupied;
        }
        else
        {
            isOiccupied[inIndex2] = true;
            battleBoxDatas[inIndex1] = indexData2;
            indexData2.SetNumInTeamWaiting(inIndex1);
            BattleInfo.waitingTeams[inIndex1] = indexData2;
            indexData2.GetIcon().LoadAssetAsync().Completed += go => gosToBattle[inIndex1].GetComponent<Image>().sprite = go.Result;
            AddClickEvent(gosToBattle[inIndex1], indexData2, inIndex1);
        }
    }

    /// <summary>
    /// 拖拽出征角色
    /// </summary>
    /// <param name="go"></param>
    /// <param name="eventData"></param>
    /// <returns></returns>
    RectTransform battleIcoDrag(GameObject go, PointerEventData eventData)
    {
        for (int i = 0; i < gosToBattle.Length; i++)
            if (gosToBattle[i] == go)
                if (isOiccupied[i])
                {
                    var tempRect = gosToBattle[i].GetComponent<RectTransform>();
                    tempRect.GetComponent<Image>().raycastTarget = false;
                    battleIcoPos = tempRect.localPosition;
                    battleIcoParent = go.transform.parent;
                    return tempRect;
                }
        return null;
    }

    /// <summary>
    /// 出征角色拖拽结束
    /// </summary>
    /// <param name="go"></param>
    /// <param name="pointerEventData"></param>
    void battleIcoEndDrag(GameObject go, PointerEventData pointerEventData)
    {
        for (int i = 0; i < gosToBattle.Length; i++)
            if (gosToBattle[i] == go)
                if (isOiccupied[i])
                {
                    go.transform.parent = battleIcoParent;
                    go.GetComponent<RectTransform>().localPosition = battleIcoPos;
                    go.GetComponent<Image>().raycastTarget = true;

                    var inGo = pointerEventData.pointerEnter;

                    var tempRole = inGo.GetComponent<RoleItem>();
                    if (tempRole != null)
                    {
                        //出征到列表

                        var tempData = getDateForObj(inGo);
                        var tempData2 = battleBoxDatas[i];
                        switchHeroToBattle(tempData, tempData2, i);
                    }
                    else
                    {
                        //出征到出征
                        for (int i2 = 0; i2 < gosToBattle.Length; i2++)
                            if (gosToBattle[i2] == inGo)
                                switchHeroToBox(i, i2);
                    }
                }
    }
}
