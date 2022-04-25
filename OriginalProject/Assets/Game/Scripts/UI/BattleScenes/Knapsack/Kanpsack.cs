
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Datas;
using UnityEngine.EventSystems;
using System;
using System.Linq;

/// <summary>
/// 背包
/// </summary>
public class Kanpsack : MonoBehaviour
{
    /// <summary>
    /// 物品预制
    /// </summary>
    public GameObject objItem;
    /// <summary>
    /// 背包格子
    /// </summary>
    public List<Transform> boxs;

    public Image objItemOnDrag;
    private Transform objItemOnDragOriginalParent;
    /// <summary>
    /// 物品信息
    /// </summary>
    public ObjItemInfo objItemInfo;
    public HeroEquipmentInfo heroEquipmentInfo;
    
    public Dictionary<int, ObjData> objDataDict = new Dictionary<int, ObjData>();
    /// <summary>
    /// key = 背包格子，value = 物品
    /// </summary>
    Dictionary<Transform, ObjItem> kanpsackDict = new Dictionary<Transform, ObjItem>();
    //根据存档中的数据来读背包中的道
    ModeData modeData;
    private bool onDraging;
    /// <summary>
    /// 背包中鳞片的总量
    /// </summary>
    public int kanpsackMoney{ get; private set; }
    private void Start()
    {
        objItemOnDragOriginalParent = objItemOnDrag.transform.parent;
        SetDict();
        InitKanpsack();
    }
    /// <summary>
    /// 售卖模式
    /// </summary>
    public bool IsSellMode { get; set; }
    #region 背包部分

    //设置字典
    void SetDict()
    {
        modeData = DataManager.Instance.modeData;

        DataSetItem dataSet = DataManager.Instance.GetData("ObjData");
        //物品数据集
        ObjDataSet objData = dataSet.scriptableObject as ObjDataSet;

        foreach (var item in objData.porpDatas)
        {
            objDataDict.Add(item.id, item);
        }

        foreach (var item in objData.ornamentsDatas)
        {
            objDataDict.Add(item.id, item);
        }
        ///宝物数据
        foreach (var item in objData.treasuresDatas)
        {
            objDataDict.Add(item.id, item);
        }

        /////勋章数据
        //dataSet = DataManager.Instance.GetData("MedalData");
        //MedalDataSet MedalData = dataSet.scriptableObject as MedalDataSet;
        //foreach (var item in MedalData.medalDatas)
        //{
        //    objDataDict.Add(item.id, item);
        //}

        ///经文数据
        dataSet = DataManager.Instance.GetData("InteractiveData");
        InteractiveDataSet interactiveData = dataSet.scriptableObject as InteractiveDataSet;
        foreach (var item in interactiveData.interactiveScriptures)
        {
            objDataDict.Add(item.id, item);
        }
        ///圣物数据
        dataSet = DataManager.Instance.GetData("SacredData");
        SacredDataSet sacredData = dataSet.scriptableObject as SacredDataSet;
        for (int i = 0; i < sacredData.sacredDatas.Count; i++)
        {
            objDataDict.Add(sacredData.sacredDatas[i].id, sacredData.sacredDatas[i]);
        }
    }
    
    //初始化背包
    void InitKanpsack()
    {
        ////测试
        //{
        //    for (int i = 0, j = 0; i < modeData.kanpsackModes.Count; i++)
        //    {
        //        if (modeData.kanpsackModes[i].objId == 0)
        //        {
        //            modeData.kanpsackModes[i].objId = modeData.ornamentsModes[j].objId;
        //            modeData.kanpsackModes[i].count = modeData.ornamentsModes[j].count;

        //            j++;
        //            if (j >= modeData.ornamentsModes.Count) break;
        //        }
        //    }

        //}
        ///背包初始化
        modeData.kanpsackModes = new List<KanpsackMode>();
       // modeData.carryBattleMoneyMode = new KanpsackMode() { count = 3500, objId = 7001 };
        int countTemp = 0;
        int maxCount = 0;
        if (modeData.carryBattleMoneyMode.objId > 0 && modeData.carryBattleMoneyMode.count > 0 && objDataDict.ContainsKey(modeData.carryBattleMoneyMode.objId)) {
            countTemp = modeData.carryBattleMoneyMode.count;
            UpdateMoney(countTemp);
            maxCount = objDataDict[modeData.carryBattleMoneyMode.objId].maxCount;
        }
        for (int i = 0; i < boxs.Count; i++)
        {
            KanpsackMode temp =   new KanpsackMode() { objId = 0, count = 0 };
            if (countTemp > 0 && countTemp <= maxCount) {
                temp.objId = modeData.carryBattleMoneyMode.objId;
                temp.count = countTemp;
                countTemp = 0;
            }
            else if (countTemp > 0 && countTemp > maxCount)
            {
                temp.objId = modeData.carryBattleMoneyMode.objId;
                temp.count = maxCount;
                countTemp -= maxCount;
            }
            modeData.kanpsackModes.Add(temp);
        }
        


        
        for (int i = 0; i < modeData.kanpsackModes.Count; i++)
        {
            ObjItem obj = null;
            if (modeData.kanpsackModes[i].objId != 0)
            {
                //此处需要进行浅拷贝
                int nObjId = modeData.kanpsackModes[i].objId;
                if(objDataDict.ContainsKey(nObjId))
                {
                    ObjData objData = objDataDict[nObjId].Clone();
                    GameObject go = Instantiate(objItem, boxs[i]);
                    obj = go.GetComponent<ObjItem>();
                    obj.InitItem(objData,modeData.kanpsackModes[i].count,boxs[i]); 
                    ItemListener(go);
                }
            }
            kanpsackDict.Add(boxs[i], obj);
        }
    }
    public void UpdateMoney(int money, bool isChangeKanpsace = false)
    {
        kanpsackMoney += money;

        if (!isChangeKanpsace) return;
        List<ObjItem> list = new List<ObjItem>();
        foreach (var item in kanpsackDict) if (item.Value != null && kanpsackDict[item.Key] != null && item.Value.objData.id == 7001) list.Add(item.Value);
        int moneyTemp = Mathf.Abs(money);
        int indexOfBoxs = -1;
        if (money < 0)
        {
            //扣除
            if (list.Count <= 0) return;
            list = list.OrderBy(s => s.count).ToList();
            int subTemp = 0;
            for (int i = 0; i < list.Count; ++i)
            {
                if (moneyTemp <= 0) break;
                 subTemp = 0;
                if (list[i].count > moneyTemp)
                {
                    subTemp = moneyTemp;
                    moneyTemp = 0;
                    list[i].Reduce(subTemp);
                }
                else
                {
                    subTemp = list[i].count;
                    moneyTemp -= list[i].count;
                    if (list[i].Reduce(subTemp) <= 0) RemoveValue(list[i].mePos_box);
                }
                //同步背包存档数据
                indexOfBoxs = -1;
                indexOfBoxs = boxs.IndexOf(list[i].mePos_box);
                modeData.kanpsackModes[indexOfBoxs].count -= subTemp;
                if (modeData.kanpsackModes[indexOfBoxs].count <= 0)
                {
                    modeData.kanpsackModes[indexOfBoxs].objId = 0;
                    modeData.kanpsackModes[indexOfBoxs].count = 0;
                }
            }
        }
        else
        {
            //增加
            list = list.OrderBy(s => s.count).ToList();
            for (int i = 0; i < list.Count; ++i)
            {
                if (moneyTemp <= 0) break;
                if (list[i].count >= list[i].objData.maxCount) continue;

                int iTemp = list[i].objData.maxCount - list[i].count;
                int addTemp = iTemp >= moneyTemp ? moneyTemp : iTemp;
                list[i].Add(addTemp);
                moneyTemp -= addTemp;
                //同步背包存档数据
                indexOfBoxs = -1;
                indexOfBoxs = boxs.LastIndexOf(list[i].mePos_box);
                modeData.kanpsackModes[indexOfBoxs].count += addTemp;
            }
            int testNum = 0;
            while (moneyTemp > 0)
            {
                if (testNum > 20000)
                {
                    Debug.LogError("死循环啦。。。。。啦。。。啦。。");
                    break;
                }
                testNum++;
                indexOfBoxs = -1;
                Transform box = GetNullBox(out indexOfBoxs);
                if (box == null)
                {
                    Debug.LogError("背包满了");
                    break;
                }
                int nObjId = 7001;
                if (!objDataDict.ContainsKey(nObjId)) break;
                ObjData objData = objDataDict[nObjId].Clone();
                GameObject go = Instantiate(objItem, box);
                ObjItem obj = go.GetComponent<ObjItem>();
                int count = moneyTemp >= objData.maxCount ? objData.maxCount : moneyTemp;
                moneyTemp -= count;
                obj.InitItem(objData, count, box);
                ItemListener(go);
                kanpsackDict[boxs[indexOfBoxs]] = obj;
                //同步背包存档数据
                modeData.kanpsackModes[indexOfBoxs].objId = obj.objData.id;
                modeData.kanpsackModes[indexOfBoxs].count = obj.count;
            }
        }

    }
    void ItemListener(GameObject item)
    {
        UIEventManager.AddTriggersListener(item).onEnter = go => ItemOnEnter(go);
        UIEventManager.AddTriggersListener(item).onExit = go => ItemOnExit(go);
        UIEventManager.AddTriggersListener(item).onDrag = (go, eventData) => ItemOnDrag(go, eventData);
        UIEventManager.AddTriggersListener(item).onEndDrag = (go, eventData) => ItemEndDrag(go, eventData);

        UIEventManager.AddTriggersListener(item).onLeftClick = go => ItemLeftClick(go);
        UIEventManager.AddTriggersListener(item).onRightClick = go => ItemRightClick(go);

    }

    void ItemOnEnter(GameObject go)
    {
        if (onDraging)
            return;

        ObjItem obj = go.GetComponent<ObjItem>();
        objItemInfo.Show(obj.objData, go.transform.position);
    }

    void ItemOnExit(GameObject go)
    {
        objItemInfo.Off();
    }

    RectTransform ItemOnDrag(GameObject go, PointerEventData eventData)
    {
        onDraging = true;
        ObjItem obj = go.GetComponent<ObjItem>();
        objItemOnDrag.sprite = obj.icon.sprite;
        RectTransform rectTransform = objItemOnDrag.GetComponent<RectTransform>();
        objItemOnDrag.gameObject.SetActive(true);

        return rectTransform;

    }

    void ItemEndDrag(GameObject go, PointerEventData eventData)
    {
        onDraging = false;
        objItemOnDrag.gameObject.SetActive(false);
        if (eventData.pointerEnter == null)
            return;
        Transform targetBox = eventData.pointerEnter.transform;
       // Debug.Log($"测试-ItemEndDrag-[{go.name},{go.transform.parent.name}]-[{targetBox.name},{targetBox.parent.name}]");
        if (targetBox.tag == "ObjItemBox" && go.transform.parent.tag == "GetPropBox") //拖拽拾取战利品
        {
            RemoveInGetPoropPanel(go);
            if (kanpsackDict[targetBox] == null)//拖拽的目标格子是空格子
            {
                MoveValue(go.transform.parent, targetBox);
            }
            else if (kanpsackDict[targetBox] != null)//拖拽的目标格子不是空格子-暂不做处理
            {  }
        }
        else if (targetBox.tag == "ObjItemBox")//拖拽的目标格子是空格子
        {
           MoveValue(go.transform.parent, targetBox);
        }
        else if (targetBox.parent.tag == "ObjItemBox")//拖拽的目标格子不是空格子
        {
            MoveValue(go.transform.parent, targetBox.parent);
        }
        //出售物品
        else if (targetBox.tag == "UndergroudShop")
        {
            ForSale(go.GetComponent<ObjItem>());
        }
        #region 原始代码

        //if (targetBox.tag == "ObjItemBox")
        //{
        //    Debug.Log("测试-ItemEndDrag-拾取");
        //    //拖拽拾取战利品
        //    if (go.transform.parent.tag == "GetPropBox")
        //    {
        //        //如果是获得道具面板的盒子,那么当物品移除时,关闭显示
        //        RemoveInGetPoropPanel(go);        
        //    }
        //    MoveValue(go.transform.parent, targetBox);
        //}
        /////交换物品
        //else if (targetBox.parent.tag == "ObjItemBox")
        //{
        //    Debug.Log("测试-ItemEndDrag-交换");
        //    MoveValue(go.transform.parent, targetBox.parent);
        //}
        ////出售物品
        //else if (targetBox.tag == "UndergroudShop")
        //{
        //    ForSale(go.GetComponent<ObjItem>());
        //}
        #endregion

    }

    //增加一个数据
    void AddValue(ObjData objData, int count)
    {
        foreach (var item in kanpsackDict)
        {
            if (item.Value == null)
            {
                GameObject go = Instantiate(objItem, item.Key);
                ObjItem obj = go.GetComponent<ObjItem>();

                obj.InitItem(objData, count,item.Key);
                kanpsackDict[item.Key] = obj;

                ItemListener(go);
                return;
            }
        }

        Debug.Log("一个空格子都没找到,包满了");
    }

    //一个格子为空时,删除item
    void RemoveValue(Transform key)
    {
        GameObject go = kanpsackDict[key].gameObject;
        objItemOnDrag.transform.SetParent(objItemOnDragOriginalParent);
        ItemOnExit(go);
        Destroy(go);

        kanpsackDict[key] = null;

    }
    
    /// <summary>
    /// 移动物品
    /// </summary>
    /// <param name="source"></param>
    /// <param name="target"></param>
    void MoveValue(Transform source, Transform target,bool isUpdate=  true)
    {
        if (source == target) return;
        ObjItem targetItem = kanpsackDict[target];
        ObjItem sourceItem = kanpsackDict[source];
        //同一物品id,数量堆叠
        if (targetItem != null && targetItem.objData.id == sourceItem.objData.id 
            && targetItem.count < targetItem.objData.maxCount && sourceItem.count < sourceItem.objData.maxCount)
        {
            int index_source = boxs.IndexOf(source);
            int index_target = boxs.IndexOf(target);
            KanpsackMode temp_source = modeData.kanpsackModes[index_source];
            KanpsackMode temp_target = modeData.kanpsackModes[index_target];
            int subValue = targetItem.objData.maxCount - targetItem.count;
            if (subValue < sourceItem.count)
            {
                temp_target.count += subValue;
                targetItem.objData.Count += subValue;
                targetItem.count = targetItem.objData.Count;
                targetItem.countT.text = targetItem.count.ToString();

                temp_source.count -= subValue;
                sourceItem.objData.Count -= subValue;
                sourceItem.count = sourceItem.objData.Count;
                sourceItem.countT.text = sourceItem.count.ToString();
            }
            else
            {
                temp_target.count += sourceItem.count;
                targetItem.objData.Count += sourceItem.count;
                targetItem.count = targetItem.objData.Count;
                targetItem.countT.text = targetItem.count.ToString();

                temp_source.count = 0;
                temp_source.objId = 0;
                sourceItem.objData.Count = 0;
                sourceItem.count = sourceItem.objData.Count;
                sourceItem.countT.text = sourceItem.count.ToString();
                RemoveValue(source);
            }
            modeData.kanpsackModes[index_source] = temp_source;
            modeData.kanpsackModes[index_target] = temp_target;
            return;
        }

        sourceItem.transform.SetParent(target);
        sourceItem.transform.localPosition = Vector3.zero;
        sourceItem.RectTrans.offsetMin = Vector2.zero;
        sourceItem.RectTrans.offsetMax = Vector2.zero;
        sourceItem.mePos_box = target;
        kanpsackDict[target] = sourceItem;

        //目标点有可能不是空的
        if (targetItem != null)
        {
            targetItem.transform.SetParent(source);
            targetItem.transform.localPosition = Vector3.zero;
            targetItem.RectTrans.offsetMin = Vector2.zero;
            targetItem.RectTrans.offsetMax = Vector2.zero;
            targetItem.mePos_box = source;
        }
        kanpsackDict[source] = targetItem;
       if(isUpdate) KanpsackModesChangeElement(source,target);
    }
    /// <summary>
    /// 背包存档数据列表更新
    /// </summary>
    /// <param name="source"></param>
    /// <param name="target"></param>
    private void KanpsackModesChangeElement(Transform source, Transform target) {
        int index_source = boxs.IndexOf(source);
        int index_target = boxs.IndexOf(target);
        //Debug.Log(index_source + "," + index_target + "," + modeData.kanpsackModes.Count);
        KanpsackMode temp_source = modeData.kanpsackModes[index_source];
        modeData.kanpsackModes[index_source] = modeData.kanpsackModes[index_target];
        modeData.kanpsackModes[index_target] = temp_source;
    }
  
    private void ItemRightClick(GameObject go)
    {
        AddOrnament(go);
    }
    /// <summary>
    /// 装备饰品
    /// </summary>
    /// <param name="item"></param>
    public void AddOrnament(GameObject item)
    {
      if (BattleFlowController.Instance.IsBattling) return;
        ObjItem _item = item.GetComponent<ObjItem>();
        if (_item.objData.objType != ObjType.饰品 && _item.objData.objType != ObjType.勋章) return;
        ObjData objData = _item.objData.Clone();
        objData.Count = 1;
        ObjLife curhero = BattleFlowController.Instance.CurrentSelectHero;
        //优先装备角色详情面板。
        if (RoleInfoPanel.instance != null && RoleInfoPanel.instance.panelRoot.activeSelf)
        {
            if (objData.objType == ObjType.饰品)
            {
               
                if (!RoleInfoPanel.instance.AddOrnament(objData, 1))
                    if (!RoleInfoPanel.instance.AddOrnament(objData, 2)) return;
                //背包数据同步
                RemoveOrnamentForKanspsack(_item);
            }
            else if (objData.objType == ObjType.勋章) {
                // RoleInfoPanel.instance.AddMedal(_item., false);
                //   DataManager.Instance.RemoveMedalFromMode(medalData);
            }
        }
        else if (curhero != null && curhero.GetRoleType() == RoleType.英雄)
        {
            if (!RoleInfoView.Instance.AddOrnament(objData, 1))
                if (!RoleInfoView.Instance.AddOrnament(objData, 2)) return;
            //背包数据同步
            RemoveOrnamentForKanspsack(_item);
        }
       RoleInfoView.Instance.RefreshRoleInfo(curhero.GetObjLifeData());
    }
    /// <summary>
    /// 添加数据到背包
    /// </summary>
    /// <param name="data"></param>
    public void AddOrnamentToKanspsack(ObjData data) {
        Debug.Log($"测试-AddOrnamentToKanspsack-data.Count = {data.Count}");
        foreach (var item in kanpsackDict) {
            if (item.Value != null && item.Value.objData.id == data.id && item.Value.objData.Count < item.Value.objData.maxCount) {
                int subvalue = item.Value.objData.maxCount - item.Value.objData.Count;
                if (subvalue < data.Count)
                {
                    item.Value.objData.Count += subvalue;
                    item.Value.count += subvalue;
                    data.Count -= subvalue;
                }
                else if (subvalue >= data.Count) {
                   
                    item.Value.objData.Count += data.Count;
                    item.Value.count += data.Count;
                    data.Count = 0;
                }
                item.Value.countT.text = item.Value.count.ToString();
                int indexof = boxs.IndexOf(item.Key);
                modeData.kanpsackModes[indexof].objId = item.Value.objData.id;
                modeData.kanpsackModes[indexof].count = item.Value.count;
            }
        }
        if (data.Count <= 0) return;
        Transform box = GetNullBox(out int index);
        if (box == null) return;
       
        ObjData objData = objDataDict[data.id].Clone();
        GameObject go = Instantiate(objItem);
        ObjItem obj = go.GetComponent<ObjItem>();
        kanpsackDict[box] = obj;
        go.transform.SetParent(box);
        go.transform.localPosition = Vector3.zero;
        obj.RectTrans.offsetMin = Vector2.zero;
        obj.RectTrans.offsetMax = Vector2.zero;
        obj.RectTrans.localScale = Vector3.one;
        obj.InitItem(objData, data.Count, box);
        ItemListener(go);
        int idex = boxs.IndexOf(box);
        modeData.kanpsackModes[idex].objId = objData.id;
        modeData.kanpsackModes[idex].count = objData.Count;
    }
    /// <summary>
    /// 从背包中删除饰品或减少数量
    /// </summary>
    /// <param name="inId"></param>
    public void RemoveOrnamentForKanspsack(ObjItem _item) {
        Transform tempBox = _item.mePos_box;
        if (_item.Reduce() <= 0)   RemoveValue(_item.mePos_box);
        //同步背包存档数据
        int index = boxs.IndexOf(tempBox);
        modeData.kanpsackModes[index].count--;
        if (modeData.kanpsackModes[index].count <= 0)
        {
            modeData.kanpsackModes[index].objId = 0;
            modeData.kanpsackModes[index].count = 0;
        }
    }

    public ObjItem forSale;
    bool sureSell;

    void ForSale(ObjItem item)
    {
        if (item.objData.id == 70001 || item.objData.levelType == LevelType.资源)
        {
            return;
        }

        sureSell = false;
        forSale = item;
        AudioManager.Instance.PlayAudio(AudioName.POP_Mouth_Darker_mono, AudioType.Common);
        UndergroudShopPanel.Instance.ShowSalePop(item.objData);
    }

    public void SureSell()
    {
        sureSell = true;
    }

    /// <summary>
    /// 售卖
    /// </summary>
    public void OnSellItem() {
        ObjData temp = forSale.objData.Clone();
        temp.Count = 1;

        //if (!sureSell)//是鳞甲并且没空格子
        //{
        //    UndergroudShopPanel.Instance.ShowWarn();
        //    return;
        //}

        if (forSale.Reduce() < 1)
        {
            RemoveValue(forSale.mePos_box);
        }
        //同步背包存档数据
        Transform tempBox = forSale.transform.parent;
        int index = boxs.IndexOf(tempBox);
        modeData.kanpsackModes[index].count--;
        if (modeData.kanpsackModes[index].count <= 0)
        {
            modeData.kanpsackModes[index].objId = 0;
            modeData.kanpsackModes[index].count = 0;
        }
        UndergroudShopPanel.Instance.OnSellItem(temp);
        AudioManager.Instance.PlayAudio(AudioName.Sell_mono, AudioType.Common);
    }
    //左键点击使用
    private void ItemLeftClick(GameObject go)
    {
        //ItemOnExit(go);

        //ObjItem objItem = go.GetComponent<ObjItem>();

        //ObjLife objLife = RoleInfoView.Instance.showWho.objLife;
        //objItem.objData.showModle.InstantiateAsync(objLife.roleUi.prop).Completed += _go =>
        //{
        //    PropBase prop = _go.Result.GetComponent<PropBase>();
        //    prop.InitProp(objItem.objData, objLife);
        //};

        //int count = objItem.Reduce();
        //if (count < 1)
        //{
        //    RemoveValue(objItem.mePos_box);
        //}

        ItemOnExit(go);
        ObjItem objItem = go.GetComponent<ObjItem>();
        if (IsSellMode) {
            ///售卖物品
            ForSale(objItem);
        }
        else {
            //如果是在战利品列表中，则是拿取道具；否则是在背包里，是使用道具。通过父对象名字判断——这个判断方法不好
            if (objItem.transform.parent.tag == "GetPropBox")// if (objItem.transform.parent.parent.name == "box")
            {
                Debug.Log("拾取道具");
                GetObjData(objItem.transform.parent);
            }
            else
            {
                Debug.Log("使用道具");
                if (BattleFlowController.Instance.UseObjData(objItem.objData))
                {

                    if (objItem.Reduce() < 1)
                    {
                        RemoveValue(objItem.mePos_box);
                    }
                    //同步背包存档数据
                    Transform tempBox = go.transform.parent;
                    int index = boxs.IndexOf(tempBox);
                    modeData.kanpsackModes[index].count--;
                    if (modeData.kanpsackModes[index].count <= 0)
                    {
                        modeData.kanpsackModes[index].objId = 0;
                        modeData.kanpsackModes[index].count = 0;
                    }
                    //for (int i = 0; i < boxs.Count; ++i)
                    //{
                    //    if (boxs[i].childCount > 0 && boxs[i].GetChild(0).gameObject == go)
                    //    {
                    //        Debug.Log(boxs[i].name  + "," + i);
                    //        modeData.kanpsackModes[i].count--;
                    //        if (modeData.kanpsackModes[i].count <= 0)
                    //        {
                    //            modeData.kanpsackModes[i].objId = 0;
                    //        }
                    //    }
                    //}
                }
            }
        }
     
    }

    #endregion

    #region 获得道具面板部分
    
    public GetProp getPropPanel;

    //战斗胜利与搜索获得都用同一个面板,但他们的名称与提示不同
    public Text panelName;
    public Text tips;

    [HideInInspector]
    public List<ObjItem> getProps = new List<ObjItem>();

    /// <summary>
    /// 显示获取面板
    /// </summary>
    /// <param name="propKeys">奖励的道具keys</param>
    /// <param name="isB">是否是战斗结算 --  true = 是战斗,false = 是宝藏</param>
    public void ShowGetPropPanel(List<ObjData> _objDatas,bool isB)
    {
        if (isB) {
            Debug.Log("测试-ShowGetPropPanel");
        }
        NewbieGuideMag.Instance.triggerGuide(GuideDataSet.guideEnum.trophy);
        //gameObject.SetActive(true);

        List<ObjData> objDatas = new List<ObjData>();
        foreach (var obj in _objDatas)
        {
            if (obj.Count <= obj.maxCount)
            {
                objDatas.Add(obj.Clone());
            }
            else
            {
                int count = obj.Count;
                int testNum = 0;
                while (count > 0)
                {
                    if (testNum > 20000)
                    {
                        Debug.LogError("死循环啦。。。。。啦。。。啦。。");
                        break;
                    }
                    testNum++;
                    ObjData objData = obj.Clone();
                    if (count > obj.maxCount)
                    {
                        objData.Count = objData.maxCount;
                        count -= obj.maxCount;
                    }
                    else
                    {
                        objData.Count = count;
                        count = 0;
                    }
                    objDatas.Add(objData);
                }
            }
        }

        if (objDatas.Count > 0)
        {
            for (int i = 0; i < objDatas.Count; i++)
            {
                GameObject go = Instantiate(objItem, getPropPanel.PropBoxs[i]);
                ObjItem _obj = go.GetComponent<ObjItem>();

                getProps.Add(_obj);
                if (!objDataDict.ContainsKey(objDatas[i].id))
                {
                    Debug.Log("提供的ID在基础数据中找不到：" + objDatas[i].id);
                    //return;
                }
                _obj.InitItem(objDatas[i], objDatas[i].Count, getPropPanel.PropBoxs[i]);

                ItemListener(go);
                getPropPanel.PropBoxs[i].gameObject.SetActive(true);

                if (kanpsackDict.ContainsKey(getPropPanel.PropBoxs[i]))
                {
                    kanpsackDict[getPropPanel.PropBoxs[i]] = _obj;
                }
                else
                {
                    kanpsackDict.Add(getPropPanel.PropBoxs[i], _obj);
                }
            }
        }
             
        SetValue(isB);
        getPropPanel.Show();
    }

    void SetValue(bool b)
    {
        if (b)
        {
            panelName.text = "胜利";
            tips.text = "搜索尸骸发现";
        }
        else
        {
            panelName.text = "宝藏";
            tips.text = "搜索尸骸发现";
        }
    }

    /// <summary>
    /// 获取列表中所有的道具
    /// </summary>
    public void GetAll()
    {
        AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
        List<ObjItem> objItems = new List<ObjItem>();
        foreach (var item in getProps)
        {
            objItems.Add(item);
        }
        foreach (var item in objItems)
        {
            GetObjData(item.transform.parent);        
        }
        OffPanel();
    }
    /// <summary>
    /// 获取所有战利品 按键响应
    /// </summary>
    public void GetAllSpoilsOfKeyDown() {
        if (getProps.Count <= 0) return;
        AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
        List<ObjItem> objItems = new List<ObjItem>();
        foreach (var item in getProps)
        {
            objItems.Add(item);
        }
        foreach (var item in objItems)
        {
            GetObjData(item.transform.parent);
        }
        OffPanel();
    }
    /// <summary>
    /// 拿取道具
    /// </summary>
    /// <param name="objData"></param>
    public void GetObjData(Transform transform)
    {
        if (kanpsackDict.ContainsKey(transform))
        {
            if (kanpsackDict[transform] != null)
            {
                ObjItem _obj = kanpsackDict[transform];

                int count = _obj.count;
                //尝试叠加
                foreach (var item in kanpsackDict)
                {
                    if (item.Value != null && kanpsackDict[transform] != null
                        && item.Value.objData.id == kanpsackDict[transform].objData.id 
                        && item.Key != transform
                        && item.Value.count + count <= item.Value.objData.maxCount)
                    {
                        item.Value.count += count;
                        item.Value.objData.Count = item.Value.count;
                        item.Value.countT.text = item.Value.count.ToString();
                        if (item.Value.objData.id == 7001) UpdateMoney(count);
                        count = 0;
                        //同步背包存档数据
                        int _index = boxs.IndexOf(item.Key);
                        modeData.kanpsackModes[_index].count = item.Value.count;
                        break;
                    }
                }

                //未能叠加，占个新坑
                if (count > 0)
                {
                    Transform box = GetNullBox(out int index);
                  
                    if (box != null)
                    {
                        count = 0;
                        MoveValue(transform, box,false);
                      //同步背包存档数据
                        modeData.kanpsackModes[index].objId = _obj.objData.id;
                        modeData.kanpsackModes[index].count = _obj.count;
                        if (_obj.objData.id == 7001) UpdateMoney(_obj.count);
                    }
                }

                if (count == 0)
                {
                    transform.gameObject.SetActive(false);
                    getProps.Remove(_obj);

                    Transform parent = transform;
                    for (int i = parent.childCount - 1; i >= 0; --i)
                    {
                        Destroy(parent.GetChild(i).gameObject);
                    }
                }
            }
        }

        if (getProps.Count == 0)
        {
            OffPanel();
        }
    }

    /// <summary>
    /// 在背包中找空格子，如果没有空格子，返回null
    /// </summary>
    /// <returns></returns>
    Transform GetNullBox(out int index)
    {
        for (int i = 0; i < boxs.Count; ++i)
        {
            if (kanpsackDict[boxs[i]] == null)
            {
                index = i;
                return boxs[i];
            }
        }
        index = -1;
        return null;
    }

    /// <summary>
    /// 放弃
    /// </summary>
    public void GiveUp()
    {
        AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
        OffPanel();
    }

    void OffPanel()
    {
        foreach (var item in getProps)
        {
            Destroy(item.gameObject);
        }
        foreach (var item in getPropPanel.PropBoxs)
        {
            item.gameObject.SetActive(false);
            kanpsackDict[item] = null;
        }

        getProps.Clear();
        getPropPanel.Exit();
    }

    void RemoveInGetPoropPanel(GameObject go)
    {
        go.transform.parent.gameObject.SetActive(false);
        ObjItem _obj = go.GetComponent<ObjItem>();

        getProps.Remove(_obj);
    }

    #endregion
}
