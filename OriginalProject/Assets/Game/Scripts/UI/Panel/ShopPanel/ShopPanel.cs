using Datas;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GEvent;
using DG.Tweening;

public class ShopPanel : BuildPanelBase
{
    public Transform rootPanel;
    public GameObject originItem;
    public GameObject soldOutTip;
    public ResourceSaver resSaver;
    public ExtendBoxEquip extBoxEquip;
    private ShopBuildingMode buildingMode;
    private List<BuildingLevelGroup> buildingLvGroups;
    private List<ShopItem> shopItems;
    private Dictionary<int, ObjData> objDic;
    private List<int> origins, rares, excellents, normals;
    private RectTransform panelRect;
    private bool isFading;
    private bool initialized;
    List<ShopItem> itemList = new List<ShopItem>();
    HoverInfoUI iconHover;
    Vector2 originPos;

    public UnityEngine.UI.Text topTips;
    private float Discount => resSaver.discounts[buildingMode.equipLvs[0]];
    private int StoreCount => extBoxEquip.extendNums[buildingMode.equipLvs[1]];
    private RectTransform PanelRect
    {
        get
        {
            if (panelRect == null)
                panelRect = GetComponent<RectTransform>();
            return panelRect;
        }
    }

    private void Start()
    {
        originPos = rootPanel.GetComponent<RectTransform>().anchoredPosition;
        BuildPanelMag.Instance.addBuild(this);
    }

    public void InitialPanel()
    {
        DataSetItem buildData = DataManager.Instance.GetData("BuildData");
        BuildDataSet buildDataSet = buildData.scriptableObject as BuildDataSet;
        resSaver = buildDataSet.shopEquip1;
        extBoxEquip = buildDataSet.shopEquip2;
        ModeData modeData = DataManager.Instance.modeData;
        buildingMode = modeData.shopBuildingMode;
        if (modeData.shopBuildingMode.equipLvs.Count < 2)
        {
            buildingMode.equipLvs = new List<int>(new int[2]);
        }
        if (buildingLvGroups == null)
        {
            Transform container = rootPanel.transform.Find("buildingUpBox");
            buildingLvGroups = new List<BuildingLevelGroup>(container.GetComponentsInChildren<BuildingLevelGroup>(true));
            //初始化建筑数据
            for (int i = 0; i < buildingLvGroups.Count; i++)
            {
                buildingLvGroups[i].OnEquipLvUp += EquipLvUp;
                if (buildingLvGroups[i].equipType.Equals(EquipType.ResourceSaver))
                {
                    buildingLvGroups[i].InitialLevelGroup(buildingMode.equipLvs[0], ResPanel.Instance.StarFire, ResPanel.Instance.Bone, resSaver);
                    setLvGroupHover(buildingLvGroups[i], LanguageController.GetValue("减少购买饰品花费的资源"));
                }
                if (buildingLvGroups[i].equipType.Equals(EquipType.BoxExtend))
                {
                    buildingLvGroups[i].InitialLevelGroup(buildingMode.equipLvs[1], ResPanel.Instance.StarFire, ResPanel.Instance.Bone, extBoxEquip);
                    setLvGroupHover(buildingLvGroups[i], LanguageController.GetValue("增加饰品刷新数量"));
                }
            }
        }
        DataSetItem dataItem = DataManager.Instance.GetData("ObjData");
        ObjDataSet objData = dataItem.scriptableObject as ObjDataSet;
        objDic = new Dictionary<int, ObjData>();
        origins = new List<int>(); rares = new List<int>(); excellents = new List<int>(); normals = new List<int>();
        for (int i = 0; i < objData.ornamentsDatas.Count; i++)
        {
            //Debug.Log(objData.ornamentsDatas[i].id);
            objDic.Add(objData.ornamentsDatas[i].id, objData.ornamentsDatas[i]);
            if (objData.ornamentsDatas[i].levelType.Equals(LevelType.起源))
                origins.Add(objData.ornamentsDatas[i].id);
            if (objData.ornamentsDatas[i].levelType.Equals(LevelType.稀有))
                rares.Add(objData.ornamentsDatas[i].id);
            if (objData.ornamentsDatas[i].levelType.Equals(LevelType.精良))
                excellents.Add(objData.ornamentsDatas[i].id);
            if (objData.ornamentsDatas[i].levelType.Equals(LevelType.残缺))
                normals.Add(objData.ornamentsDatas[i].id);
        }




        //Debug.Log(origins.Count);
        //Debug.Log(rares.Count);
        //Debug.Log(excellents.Count);
        //Debug.Log(normals.Count);
        itemList.Add(originItem.GetComponent<ShopItem>());
        setItemEvent(itemList[0]);


        if (StoreCount > itemList.Count)
            for (int i = 0; i < StoreCount - itemList.Count; i++)
                creatorItem();

        //shopItems = new List<ShopItem>(GetComponentsInChildren<ShopItem>(true));
        //for (int i = 0; i < shopItems.Count; i++)
        //{
        //    shopItems[i].OnLeftClick += BuyItem;
        //    shopItems[i].OnHoverEnter += HoverEnterItem;
        //    shopItems[i].OnHoverExit += HoverExitItem;
        //}
        if (Camp.backFromBattle)
        {
            print("返回刷新商店");
            //RefreshShop();
            RefreshData();

        }
        else
        {
            if (buildingMode.goods.Count == 0)
            {
                print("无商品刷新商店");
                //RefreshShop();
                RefreshData();
            }
            else
            {

                if (buildingMode.goods.Count > itemList.Count)
                {
                    int tempValue = buildingMode.goods.Count - itemList.Count;
                    for (int i = 0; i < tempValue; i++)
                        creatorItem();
                }

                print("存档刷新商店");
                Debug.Log("itemList.Count = " + itemList.Count);
                Debug.Log("buildingMode.goods.Count = " + buildingMode.goods.Count);
                ObjData goodData;
                for (int i = 0; i < itemList.Count; i++)
                {
                    if (buildingMode.goods.Count > i)
                    {
                        Debug.Log("id = " + buildingMode.goods[i]);
                        if (objDic.TryGetValue(buildingMode.goods[i], out goodData))
                        {
                            itemList[i].SetItemData(goodData, i, 0);
                            ResetPrice();
                        }
                        else
                        {
                            itemList[i].close();
                        }
                    }
                    else itemList[i].close();
                }

            }
        }

        topTips.text = LanguageController.GetValue("黑市");
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


    /// <summary>
    /// 购买饰品
    /// </summary>
    /// <param name="item"></param>
    private void BuyItem(ShopItem item)
    {
        {
            //if (item.price <= ResPanel.Instance.Money)
            //{
            //    Hashtable args = new Hashtable();
            //    args["ObjData"] = item.Obj;
            //    EventHelper.Instance.ExcuteEvent(GEventType.AddItem, args);
            //    for (int i = 0; i < shopItems.Count; i++)
            //    {
            //        if (shopItems[i].Equals(item))
            //        {
            //            buildingMode.goods[i] = -1;
            //        }
            //    }
            //    item.hoverInfoUI.Hide();
            //    item.ReputInfoUI();
            //    item.RemoveItem();
            //    ResPanel.Instance.ChangeResource(-item.price);
            //}
            //soldOutTip.SetActive(true);
            //for (int i = 0; i < shopItems.Count; i++)
            //{
            //    if (!shopItems[i].isEmpty)
            //    {
            //        soldOutTip.SetActive(false); break;
            //    }
            //}
        }
        AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
        if (item.price <= ResPanel.Instance.Money)
        {
            DataManager.Instance.AddOrnamentToMode(item.Obj);
            buildingMode.goods[item.ModesIndex] = -1;
            item.close();
            ResPanel.Instance.ChangeResource(-item.price);
        }
        else AudioManager.Instance.PlayAudio(AudioName.COINS_Error_01_mono, AudioType.Common);
        ResetPrice();
        refreshOutTips();
        WarehousePanel_2_O.instance.refreshList();
    }

    void creatorItem()
    {
        itemList.Add(Instantiate(originItem, originItem.transform.parent).GetComponent<ShopItem>());
        setItemEvent(itemList[itemList.Count - 1]);
    }

    void setItemEvent(ShopItem inItem)
    {
        inItem.OnLeftClick += BuyItem;
        //inItem.OnHoverEnter += HoverEnterItem;
        //inItem.OnHoverExit += HoverExitItem;
    }

    private void HoverEnterItem(ShopItem shipItem, HoverInfoUI infoUI)
    {
        infoUI.Show();
        infoUI.transform.SetParent(transform.parent, true);
        infoUI.transform.SetAsLastSibling();
    }

    private void HoverExitItem(ShopItem shipItem, HoverInfoUI infoUI)
    {
        infoUI.Hide();
        infoUI.transform.SetParent(shipItem.transform, true);
    }

    private void EquipLvUp(EquipType equipType, int costRes1, int costRes2)
    {
        if (equipType.Equals(EquipType.ResourceSaver))
            buildingMode.equipLvs[0]++;
        if (equipType.Equals(EquipType.BoxExtend))
            buildingMode.equipLvs[1]++;
        ResPanel.Instance.ChangeResource(0, 0, 0, 0, -costRes1, -costRes2);
        for (int i = 0; i < buildingLvGroups.Count; i++)
        {
            buildingLvGroups[i].UpdateGroup(ResPanel.Instance.StarFire, ResPanel.Instance.Bone);
        }
        ResetPrice();
    }

    /// <summary>
    /// 更新价格显示
    /// </summary>
    private void ResetPrice()
    {
        for (int i = 0; i < itemList.Count; i++)
            itemList[i].RefreshPrice(ResPanel.Instance.Money, Discount);
    }

    public void RefreshShop()
    {
        soldOutTip.SetActive(false);
        int id = 0;
        for (int i = 0; i < StoreCount; i++)
        {

            float r = UnityEngine.Random.value;
            if (r <= 0.05)
            {
                if (origins.Count > 0)
                {
                    id = origins[UnityEngine.Random.Range(0, origins.Count - 1)];
                }
            }
            else if (r <= 0.15)
            {
                if (rares.Count > 0)
                {
                    id = rares[UnityEngine.Random.Range(0, rares.Count - 1)];
                }
            }
            else if (r <= 1)
            {
                if (excellents.Count > 0)
                {
                    id = excellents[UnityEngine.Random.Range(0, excellents.Count - 1)];
                }
            }
            //else if (r <= 1)
            //{
            //    if (normals.Count > 0)
            //    {
            //        id = normals[UnityEngine.Random.Range(0, normals.Count - 1)];
            //    }
            //}

            Debug.Log("id:" + id);
            if (id != 0)
            {
                Debug.Log(objDic[id]);
                shopItems[i].SetItemData(objDic[id], 1);

                if (buildingMode.goods.Count < i + 1)
                {
                    buildingMode.goods.Add(id);
                }
                else
                {
                    buildingMode.goods[i] = id;
                }
            }
            else
            {
                shopItems[i].SetItemData(null, 1);
            }

        }
        ResetPrice();
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

        soldOutTip.SetActive(false);
        int id = 0;

        if (StoreCount > itemList.Count)
        {
            int tempValue = StoreCount - itemList.Count;
            for (int i = 0; i < tempValue; i++)
                creatorItem();
        }
        bool isSale30 = TownInfo.ExistsRescueType(RescueType.商人);
        int tempGoodIndex;
        for (int i = 0; i < StoreCount; i++)
        {
            if (i == 0)
            {
                //囚犯事件
                if (TownInfo.ExistsRescueType(RescueType.饰品贩子))
                    id = rares[UnityEngine.Random.Range(0, rares.Count - 1)];
                else id = randomOrnamentsID();
            }
            else
                id = randomOrnamentsID();


            if (buildingMode.goods.Count < i + 1)
            {
                buildingMode.goods.Add(id);
                tempGoodIndex = buildingMode.goods.Count - 1;
            }
            else
            {
                buildingMode.goods[i] = id;
                tempGoodIndex = i;
            }
            ObjData temp = objDic[id].Clone();
            if(isSale30) temp.buy = Mathf.RoundToInt(temp.buy * (1 - 0.3f));
            itemList[i].SetItemData(temp, tempGoodIndex, 0);
        }
        ResetPrice();
    }

    public override void open()
    {
        if (!initialized)
        {
            InitialPanel();
        }
        if (!isFading)
        {
            base.open();
            isFading = true;
            rootPanel.GetComponent<RectTransform>().anchoredPosition = originPos;
            rootPanel.gameObject.SetActive(true);
            PanelRect.localScale = Vector3.zero;
            PanelRect.DOScale(Vector3.one, 0.3f).onComplete = () => isFading = false;
        }
    }

    public override void close()
    {

        if (!isFading)
        {
            base.close();
            isFading = true;
            PanelRect.DOScale(Vector3.zero, 0.15f).onComplete = () => { isFading = false; rootPanel.gameObject.SetActive(false); };
        }

    }

    int randomOrnamentsID()
    {
        //return UnityEngine.Random.Range(4001, 4029);
        float r = UnityEngine.Random.value;
        if (r <= 0.05) { if (origins.Count > 0) return origins[UnityEngine.Random.Range(0, origins.Count - 1)]; }
        else if (r <= 0.15) { if (rares.Count > 0) return rares[UnityEngine.Random.Range(0, rares.Count - 1)]; }
        else if (r <= 1) { if (excellents.Count > 0) return excellents[UnityEngine.Random.Range(0, excellents.Count - 1)]; }
        return randomOrnamentsID();
    }

    /// <summary>
    /// 更新提示显示
    /// </summary>
    void refreshOutTips()
    {
        for (int i = 0; i < itemList.Count; i++)
            if (itemList[i].gameObject.activeSelf)
            { soldOutTip.SetActive(false); return; }
        soldOutTip.SetActive(true);
    }

    public void onTestButton()
    {
        RefreshData();
    }
}
