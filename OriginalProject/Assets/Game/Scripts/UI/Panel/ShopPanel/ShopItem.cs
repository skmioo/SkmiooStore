using Datas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ShopItem : HoverableItem
{
    public event Action<ShopItem> OnLeftClick, OnRightClick;
    public event Action<ShopItem, HoverInfoUI> OnHoverEnter, OnHoverExit;
    public Image itemIcon;
    public GameObject priceObj;
    public Text countText;
    public Text priceText;
    protected ObjData OrnamentData;
    protected MedalObjData medalData;
   
    [HideInInspector]
    public int itemCount, price;
    public bool countMax;
    [HideInInspector]
    public WarehousePanel panelInst;
    /// <summary>
    /// 存档的下标
    /// </summary>
    [HideInInspector]
    public int ModesIndex;
    public enum modeTypeEnum { nothing = -1, medal = 0, Ornament }
    [HideInInspector]
    public modeTypeEnum modeType;

    private bool _enabled;

    public bool isEmpty => OrnamentData == null;
    public ObjData Obj => OrnamentData;
    public int SellPrice
    {
        get
        {
            if (OrnamentData != null)
                return OrnamentData.sell;
            else
                return 0;
        }
    }
    public int MaxCount
    {
        get
        {
            if (countMax)
                return 99;
            else if (OrnamentData != null)
                return OrnamentData.maxCount;
            else
                return 0;
        }
    }

    public bool Enabled
    {
        get => _enabled;
        set
        {
            _enabled = value;
            if (_enabled)
            {
                itemIcon.color = Color.white;
            }
            else
            {
                itemIcon.color = Color.gray;
            }
        }
    }
    /// <summary>
     /// 是否有商品数据
     /// </summary>
    public bool isHaveItemData { get; private set; }
    protected override void Awake()
    {
        base.Awake();
        UIEventManager.AddTriggersListener(gameObject).onLeftClick = LeftClick;
        UIEventManager.AddTriggersListener(gameObject).onRightClick = RightClick;
        UIEventManager.OnDragFunc(gameObject, (inGo, inEvent) => { return itemIcon.GetComponent<RectTransform>(); });
        UIEventManager.AddTriggersListener(gameObject).onEndDrag = (inGo, inEvent) =>
        {
            itemIcon.GetComponent<RectTransform>().localPosition = Vector3.zero;
            if (inEvent.pointerEnter != null)
            {
                var tempHover = inEvent.pointerEnter.GetComponent<HoverableItem>();
                if (tempHover != null) tempHover.EndDragFunc(inGo);
                //else S_debug.showDebug($"{inEvent.pointerEnter.name}");
                //else dragToRoleInfo(inEvent.pointerEnter);
            }
        };
    }

    public void SetItemData(ObjData inData, int inIndex, int nothing)
    {
        isHaveItemData = true;
        gameObject.GetComponent<Image>().raycastTarget = true;
        itemIcon.raycastTarget = false;
        OrnamentData = inData;
        medalData = null;
        ModesIndex = inIndex;
        price = inData.buy;
        modeType = modeTypeEnum.Ornament;

        inData.Icon.LoadAssetAsync<Sprite>().Completed += img =>
        { itemIcon.sprite = img.Result; itemIcon.gameObject.SetActive(true); };
    }
  
    public void SetItemData(MedalObjData inData, int inIndex, int nothing)
    {
        isHaveItemData = true;
        gameObject.GetComponent<Image>().raycastTarget = true;
        itemIcon.raycastTarget = false;
        medalData = inData;
        OrnamentData = null;
        ModesIndex = inIndex;
        price = 0;
        modeType = modeTypeEnum.medal;

        medalData.GetIcon().LoadAssetAsync<Sprite>().Completed += img =>
        { itemIcon.sprite = img.Result; itemIcon.gameObject.SetActive(true); };
    }

    public void SetItemData(ObjData objData, int count, bool showPrice = true)
    {
        isHaveItemData = true;
        gameObject.SetActive(true);
        gameObject.GetComponent<Image>().raycastTarget = true;
        itemIcon.raycastTarget = false;
        if (objData == null)
        {
            itemIcon.sprite = null;
            itemIcon.gameObject.SetActive(false);
            Destroy(itemIcon.transform.parent.gameObject);
            //itemIcon.transform.parent.gameObject
            return;
        }
        this.OrnamentData = objData;
        objData.Icon.LoadAssetAsync<Sprite>().Completed += img =>
        { itemIcon.sprite = img.Result; itemIcon.gameObject.SetActive(true); /*Debug.Log(img.Result);*/ };

        itemCount = count;
        if (itemCount > 1)
        {
            countText.text = itemCount.ToString();
            countText.gameObject.SetActive(true);
        }
        else
        {
            countText.gameObject.SetActive(false);
        }
        price = objData.buy;
        priceObj.SetActive(showPrice);
    }
    public int AddItem(int num)
    {
        if (OrnamentData != null)
        {
            if (itemCount + num <= MaxCount)
            {
                itemCount += num;
                if (itemCount > 1)
                {
                    countText.text = itemCount.ToString();
                    countText.gameObject.SetActive(true);
                }
            }
            else
            {
                itemCount = MaxCount;
                if (itemCount > 1)
                {
                    countText.text = itemCount.ToString();
                    countText.gameObject.SetActive(true);
                }

                return itemCount + num - MaxCount;
            }
        }
        return 0;
    }

    public void RemoveItem()
    {
        itemCount--;
        if (itemCount > 1)
        {
            countText.text = itemCount.ToString();
        }
        if (itemCount == 1)
        {
            countText.gameObject.SetActive(false);
        }
        if (itemCount < 1)
        {
            Clear();
        }
    }

    public void RefreshPrice(int money, float discount)
    {
        if (OrnamentData != null)
        {
            price = (int)(OrnamentData.buy * (1 - discount) + 0.5);
            ///解救事件 - 商人
            //if (TownInfo.ExistsRescueType(RescueType.商人)) {
            //    price =(int)(price * (1 - 0.3f));
            //}
            priceText.text = price.ToString();
            if (price > money)
            {
                priceText.color = Color.red;
            }
            else
            {
                priceText.color = Color.green;
            }
        }
    }

    public void close()
    {
        Clear();
        gameObject.SetActive(false);
    }
  
    public void Clear()
    {
        isHaveItemData = false;
        GetComponent<Image>().raycastTarget = false;
        hoverInfoUI.Hide();
        itemIcon.gameObject.SetActive(false);
        countText.gameObject.SetActive(false);
        priceObj.SetActive(false);
        ModesIndex = -1;
        modeType = modeTypeEnum.nothing;
        medalData = null;
        OrnamentData = null;
    }

    public void SetBoxRaycast(bool enable)
    {
        GetComponent<Image>().raycastTarget = enable;
    }

    protected void LeftClick(GameObject go)
    {
        if (OnLeftClick != null)
        {
            OnLeftClick(this);
        }

    }

    protected void RightClick(GameObject go)
    {
        if (OnRightClick != null)
        {
            Debug.Log("OnRightClick.Invok");
            OnRightClick(this);
        }
        //else if (RoleInfoPanel.instance != null)
        //    if (RoleInfoPanel.instance.gameObject.activeSelf && WarehousePanel.instance.gameObject.activeSelf)
        else
        {
            Debug.Log("OnRightClick.NotInvok");
            if (RoleInfoPanel.instance == null) return;
            else if (!RoleInfoPanel.instance.gameObject.activeSelf) return;
            if (WarehousePanel.instance == null) return;
            else if (!WarehousePanel.instance.gameObject.activeSelf) return;


            if (medalData != null)
            {
                RoleInfoPanel.instance.AddMedal(medalData, false);
                DataManager.Instance.RemoveMedalFromMode(medalData);
                Clear();
                WarehousePanel.instance.MedalBtnClick();
            }
            if (OrnamentData != null)
            {
                if (!RoleInfoPanel.instance.AddOrnament(OrnamentData, 1, false))
                    if (!RoleInfoPanel.instance.AddOrnament(OrnamentData, 2, false)) return;

                DataManager.Instance.RemoveOrnamentFromMode2(OrnamentData.id);
                Clear();
                WarehousePanel.instance.OrnamentBtnClick();
            }
        }
    }

    protected override void PointerEnter(GameObject go)
    {
        base.PointerEnter(go);
        if (OnHoverEnter != null)
            OnHoverEnter(this, hoverInfoUI);
        else
        {
            if (medalData != null)
            {
                hoverInfoUI.transform.SetParent(transform.root.transform);
                hoverInfoUI.transform.SetAsLastSibling();

                hoverInfoUI.AddItem(medalData.GetName(), 0, Color.white);
                hoverInfoUI.AddItem(medalData.GetLevelType().ToString(), 1, Color.white);
                int index = 2;
                for (int i = 0; i < medalData.GetAttribute().Count; ++i)
                {
                    ObjPermanentBuff buff = medalData.GetAttribute()[i];
                    hoverInfoUI.AddItem(buff.buffType + (buff.buffValue > 0 ? "+" : "") + buff.buffValue + (buff.valueType == ValueType.系数 ? "%" : ""), index + i, Color.white);
                }
                index += medalData.GetAttribute().Count;
                for (int i = 0; i < medalData.GetEntry().Count; ++i)
                {
                    ObjPermanentBuff buff = medalData.GetEntry()[i];
                    hoverInfoUI.AddItem(buff.buffType + (buff.buffValue > 0 ? "+" : "") + buff.buffValue + (buff.valueType == ValueType.系数 ? "%" : ""), index + i, Color.white);
                }
                hoverInfoUI.Show();
            }
            else if (OrnamentData != null)
            {
                hoverInfoUI.AddItem(OrnamentData.describe, 0, Color.white);
                hoverInfoUI.transform.SetParent(transform.root.transform);
                hoverInfoUI.transform.SetAsLastSibling();
                hoverInfoUI.Show();
            }
        }
    }

    protected override void PointerExit(GameObject go)
    {
        base.PointerExit(go);
        if (OnHoverExit != null)
            OnHoverExit(this, hoverInfoUI);
        else
        {
            base.PointerExit(go);
            hoverInfoUI.transform.SetParent(transform);
            hoverInfoUI.Hide();
        }
    }

    public override void EndDragFunc(GameObject inGO)
    {
        base.EndDragFunc(inGO);
        
        rollToShop(inGO);
        roleToShop(inGO);
    }

    void roleToShop(GameObject inGo)
    {
        
        var tempItem = inGo.GetComponent<RoleInfoItem>();
        if (tempItem == null) return;
        if (tempItem.modeType == RoleInfoItem.modeTypeEnum.medal)
        {
            if (modeType == modeTypeEnum.Ornament) return;
            var tempData = tempItem.medalData;
            tempItem.clear();

            if (modeType == modeTypeEnum.medal)
                if (tempItem.setData(this))
                    Clear();

            DataManager.Instance.AddMedalToMode(tempData);
            WarehousePanel.instance.MedalBtnClick();
        }
        else if (tempItem.modeType == RoleInfoItem.modeTypeEnum.Ornament)
        {
            if (modeType == modeTypeEnum.medal) return;

            var tempData = tempItem.OrnamentData;
            //tempItem.clear();

            if (modeType == modeTypeEnum.Ornament)
                if (tempItem.setData(this))
                {
                    Clear();
                    DataManager.Instance.AddOrnamentToMode(tempData);
                    WarehousePanel.instance.OrnamentBtnClick();
                }
        }
    }

    void rollToShop(GameObject inGo)
    {
        if (modeType != modeTypeEnum.medal) return;
        
        var tempItem = inGo.GetComponent<RollItem>();
        if (tempItem != null)
        {
            DataManager.Instance.AddMedalToMode(tempItem.medalData);
            tempItem.Clear();
            tempItem.setRollData(DataManager.Instance.GetMedalsFromMode(ModesIndex));
        }
    }

    void dragToRoleInfo(GameObject inGo)
    {
        bool isCanDrag = false;
        if (modeType == modeTypeEnum.Ornament)
        {
            if (inGo.name == "Image") if (inGo.transform.parent.tag == "OrnamentsBox") isCanDrag = true;
            if (!isCanDrag) if (inGo.tag == "OrnamentsBox") isCanDrag = true;
            if (isCanDrag) { panelInst.OrnamentObjClick(gameObject, DataManager.Instance.GetOrnamentDatasFromMode(ModesIndex), ModesIndex); };
        }
        else if (modeType == modeTypeEnum.medal)
        {
            if (inGo.name == "Image") if (inGo.transform.parent.tag == "MedalBox") isCanDrag = true;
            if (!isCanDrag) if (inGo.tag == "MedalBox") isCanDrag = true;
            if (isCanDrag) { panelInst.MedalObjClick(gameObject, DataManager.Instance.GetMedalsFromMode(ModesIndex)); };
        }
    }
}
