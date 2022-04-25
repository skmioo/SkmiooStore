using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollItem : HoverableItem
{
    public Image itemIcon;
    public GameObject priceObj;
    public Text countText;
    public Text priceText;
    public Text hintText;
    [HideInInspector]
    public int itemCount, price;
    public bool countMax;

    [HideInInspector]
    public bool isBePut = false;
    [HideInInspector]
    public MedalObjData medalData;


    protected override void Awake()
    {
        base.Awake();
        UIEventManager.AddTriggersListener(gameObject).onLeftClick = LeftClick;
        UIEventManager.AddTriggersListener(gameObject).onRightClick = RightClick;
        UIEventManager.OnDragFunc(this.gameObject, (inGo, inEvent) => { return itemIcon.GetComponent<RectTransform>(); });
        UIEventManager.AddTriggersListener(gameObject).onEndDrag = (inGo, inEvent) =>
        {
            itemIcon.GetComponent<RectTransform>().localPosition = Vector3.zero;
            if (inEvent.pointerEnter != null)
            {
                //old
                var tempHover = inEvent.pointerEnter.GetComponent<HoverableItem>();
                if (tempHover != null) tempHover.EndDragFunc(inGo);

                //new
                var tempInteraction = inEvent.pointerEnter.GetComponent<interactionBase>();
                if (tempInteraction != null) tempInteraction.EndDragFunc(inGo);
            }
        };
    }

    protected void LeftClick(GameObject go)
    {
        //if (OnLeftClick != null)
        //{
        //    OnLeftClick(this);
        //}
        if (medalData == null) return;
        DataManager.Instance.AddMedalToMode(medalData);
        //RollMedalPanel.instance.updateWarehouse();
        Clear();
    }

    protected void RightClick(GameObject go)
    {

    }

    protected override void PointerEnter(GameObject go)
    {
        base.PointerEnter(go);

        if (medalData == null) return;

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

    protected override void PointerExit(GameObject go)
    {
        base.PointerExit(go);

        hoverInfoUI.transform.SetParent(transform);
        hoverInfoUI.ClearData();
        hoverInfoUI.Hide();

        //hoverInfoUI.transform.SetParent(transform);
        //hoverInfoUI.gameObject.SetActive(false);
        //if (OnHoverExit != null)
        //    OnHoverExit(this, hoverInfoUI);
    }

    public override void EndDragFunc(GameObject inGO)
    {
        //old
        //shop2Roll(inGO);

        //new 
        wp2Roll(inGO);
    }

    public void setRollData(MedalObjData inData)
    {
        isBePut = true;
        medalData = inData;
        //DataManager.Instance.RemoveMedalFromMode(medalData);
        //RollMedalPanel.instance.updateWarehouse();
        itemIcon.gameObject.SetActive(true);
        medalData.GetIcon().LoadAssetAsync<Sprite>().Completed += inGO => { itemIcon.sprite = inGO.Result; };

        hintText.gameObject.SetActive(false);
    }

    public void close()
    {
        Clear();
        gameObject.SetActive(false);
    }

    public void Clear()
    {
        isBePut = false;
        hintText.gameObject.SetActive(true);
        itemIcon.gameObject.SetActive(false);
        itemIcon.sprite = null;
        medalData = null;
    }

    /// <summary>
    /// 弃用
    /// 就背包到抽取
    /// </summary>
    /// <param name="inGO"></param>
    void shop2Roll(GameObject inGO)
    {
        var tempShop = inGO.GetComponent<ShopItem>();
        if (tempShop == null) return;
        if (tempShop.modeType != ShopItem.modeTypeEnum.medal) return;
        if (isBePut)
        {
            DataManager.Instance.AddMedalToMode(medalData);
            RollMedalPanel.instance.updateWarehouse();
        }

        setRollData(DataManager.Instance.GetMedalsFromMode(tempShop.ModesIndex));
    }

    /// <summary>
    /// 背包到抽取
    /// </summary>
    /// <param name="inGo"></param>
    void wp2Roll(GameObject inGo)
    {
        var tempMedal = inGo.GetComponent<Medal_2>();
        if (tempMedal == null) return;
        if (tempMedal.getData() == null) return;

        var tempData = medalData;

        setRollData(tempMedal.getData());
        DataManager.Instance.RemoveMedalFromMode(tempMedal.getIndex());
        tempMedal.clear();

        if (tempData != null)
            WarehousePanel_2_M.instance.addData(medalData);
        else WarehousePanel_2_M.instance.refreshList();
    }
}
