using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoleInfoItem : HoverableItem
{
    public Image itemIcon;
    public GameObject priceObj;
    public Text countText;
    public Text priceText;
    public Text hintText;
    public RoleInfoPanel rolePanel;

    [HideInInspector]
    public MedalObjData medalData;

    [HideInInspector]
    public Datas.ObjData OrnamentData = null;
    public int ModesIndex;

    [HideInInspector]
    public bool isBePut = false;

    public event System.Action<RoleInfoItem> OnLeftClick, OnRightClick;
    public event System.Action<RoleInfoItem, HoverInfoUI> OnHoverEnter, OnHoverExit;


    public enum itemTypeEnum { bagItem = 0, roleInfo1, roleInfo2, roleInfo3 }
    public itemTypeEnum itemType;

    public enum modeTypeEnum { nothing = -1, medal = 0, Ornament }
    [HideInInspector]
    public modeTypeEnum modeType;

    Vector3 itemIcoPos;


    protected override void Awake()
    {
        base.Awake();
        UIEventManager.AddTriggersListener(gameObject).onLeftClick = LeftClick;
        UIEventManager.AddTriggersListener(gameObject).onRightClick = RightClick;
        UIEventManager.AddTriggersListener(gameObject).onRightClick += RightClick_BattleScene;
        UIEventManager.OnDragFunc(this.gameObject, (inGo, inEvent) =>
        {
            itemIcoPos = itemIcon.GetComponent<RectTransform>().localPosition;
            return itemIcon.GetComponent<RectTransform>();
        });
        UIEventManager.AddTriggersListener(gameObject).onEndDrag = (inGo, inEvent) =>
        {
            itemIcon.GetComponent<RectTransform>().localPosition = itemIcoPos;
            if (inEvent.pointerEnter != null)
            {
                var tempHover = inEvent.pointerEnter.GetComponent<HoverableItem>();
                if (tempHover != null) tempHover.EndDragFunc(inGo);

                //拖拽进新背包格
                var tempInteraction = inEvent.pointerEnter.GetComponent<interactionBase>();
                if (tempInteraction != null) tempInteraction.EndDragFunc(inGo);
            }
        };
    }

    public bool setData(ShopItem inItem)
    {
        if (inItem.modeType == ShopItem.modeTypeEnum.medal)
        {
            OrnamentData = null;
            modeType = modeTypeEnum.medal;
            medalData = DataManager.Instance.GetMedalsFromMode(inItem.ModesIndex);
            DataManager.Instance.RemoveMedalFromMode(inItem.ModesIndex);
            itemIcon.gameObject.SetActive(true);
            medalData.GetIcon().LoadAssetAsync<Sprite>().Completed += inGO => { itemIcon.sprite = inGO.Result; };

            hintText.gameObject.SetActive(false);
            rolePanel.AddMedal(medalData, true);
            isBePut = true;
        }
        else if (inItem.modeType == ShopItem.modeTypeEnum.Ornament)
        {
            bool isCanUp = false;

            var tempData = DataManager.Instance.GetOrnamentDatasFromMode(inItem.ModesIndex);
            if (itemType == itemTypeEnum.roleInfo2) if (rolePanel.AddOrnament(tempData, 1, true)) isCanUp = true;
            if (itemType == itemTypeEnum.roleInfo3) if (rolePanel.AddOrnament(tempData, 2, true)) isCanUp = true;
            if (!isCanUp) { return false; }

            OrnamentData = tempData;
            medalData = null;
            modeType = modeTypeEnum.Ornament;
            DataManager.Instance.RemoveOrnamentFromMode2(OrnamentData.id);
            itemIcon.gameObject.SetActive(true);
            OrnamentData.Icon.LoadAssetAsync<Sprite>().Completed += inGO => { itemIcon.sprite = inGO.Result; };

            hintText.gameObject.SetActive(false);
            isBePut = true;

        }
        return true;
    }

    public void setData(Datas.ObjData inData)
    {
      
        medalData = null;
        OrnamentData = null;
        modeType = modeTypeEnum.Ornament;
        OrnamentData = inData;
        itemIcon.gameObject.SetActive(true);
        OrnamentData.Icon.LoadAssetAsync<Sprite>().Completed += inGO => { itemIcon.sprite = inGO.Result; };
        isBePut = true;
        hintText.gameObject.SetActive(false);
    }

    public void setData(MedalObjData inData)
    {
        OrnamentData = null;
        modeType = modeTypeEnum.medal;
        medalData = inData;
        itemIcon.gameObject.SetActive(true);
        medalData.GetIcon().LoadAssetAsync<Sprite>().Completed += inGO => { itemIcon.sprite = inGO.Result; };
        isBePut = true;
        hintText.gameObject.SetActive(false);
    }

    public void clear()
    {
        isBePut = false;
        hoverInfoUI.Hide();
        itemIcon.gameObject.SetActive(false);
        countText.gameObject.SetActive(false);
        priceObj.SetActive(false);
        ModesIndex = -1;
        modeType = modeTypeEnum.nothing;

        medalData = null;
        OrnamentData = null;
    }

    public override void EndDragFunc(GameObject inGO)
    {
        base.EndDragFunc(inGO);

        //old
        {
            /*
            var tempItem = inGO.GetComponent<ShopItem>();
            if (tempItem != null)
            {
                if (tempItem.modeType == ShopItem.modeTypeEnum.nothing) return;
                if (tempItem.modeType == ShopItem.modeTypeEnum.medal && itemType != itemTypeEnum.roleInfo1) return;
                if (tempItem.modeType == ShopItem.modeTypeEnum.Ornament && itemType == itemTypeEnum.roleInfo1) return;

                MedalObjData tempMedal = medalData;
                Datas.ObjData tempOrnament = OrnamentData;

            if (setData(tempItem))
            {
                tempItem.Clear();
                if (tempMedal != null) DataManager.Instance.AddMedalToMode(tempMedal);
                if (tempOrnament != null) DataManager.Instance.AddOrnamentToMode(tempOrnament);
            }

                if (modeType == modeTypeEnum.medal) WarehousePanel.instance.MedalBtnClick();
                if (modeType == modeTypeEnum.Ornament) WarehousePanel.instance.OrnamentBtnClick();
            }
            */
        }

        //new
        var tempInMedal = inGO.GetComponent<Medal_2>();
        var tempInOrnament = inGO.GetComponent<Ornaments_2>();

        if (tempInMedal != null)
        {
            if (itemType == itemTypeEnum.roleInfo1)
            {
                MedalObjData tempMedal = medalData;
                if (!rolePanel.AddMedal(tempInMedal.getData(), true)) return;
                setData(tempInMedal.getData());
                DataManager.Instance.RemoveMedalFromMode(tempInMedal.getIndex());
                tempInMedal.clear();

                if (tempMedal != null)
                    WarehousePanel_2_M.instance.addData(tempMedal);
                else WarehousePanel_2_M.instance.refreshList();
            }
        }
        else if (tempInOrnament != null)
            if (itemType != itemTypeEnum.roleInfo1)
            {
                Datas.ObjData tempOrnament = OrnamentData;

                bool isCanUp = false;
                if (itemType == itemTypeEnum.roleInfo2) if (rolePanel.AddOrnament(tempInOrnament.getData(), 1, true)) isCanUp = true;
                if (itemType == itemTypeEnum.roleInfo3) if (rolePanel.AddOrnament(tempInOrnament.getData(), 2, true)) isCanUp = true;
                if (!isCanUp) return;

                setData(tempInOrnament.getData());
                DataManager.Instance.RemoveOrnamentFromMode2(tempInOrnament.getData().id);
                tempInOrnament.clear();

                if (tempOrnament != null)
                    WarehousePanel_2_O.instance.addData(tempOrnament);
                else WarehousePanel_2_O.instance.refreshList();
            }
    }

    public override void ReputInfoUI()
    {
        base.ReputInfoUI();
    }

    protected override void PointerEnter(GameObject go)
    {
        base.PointerEnter(go);
        if (itemType == itemTypeEnum.roleInfo1)
        {
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
        }
        else
        {
            if (OrnamentData == null) return;
            hoverInfoUI.AddItem(OrnamentData.describe, 0, Color.white);
            hoverInfoUI.transform.SetParent(transform.root.transform);
            hoverInfoUI.transform.SetAsLastSibling();
        }
        hoverInfoUI.Show();
    }

    protected override void PointerExit(GameObject go)
    {
        base.PointerExit(go);
        hoverInfoUI.transform.SetParent(transform);
        hoverInfoUI.Hide();
    }


    void LeftClick(GameObject go)
    {
        if (OnLeftClick != null)
        {
            OnLeftClick(this);
        }
    }

    void RightClick(GameObject go)
    {
        if (OnRightClick != null) OnRightClick(this);
        //else if (RoleInfoPanel.instance.gameObject.activeSelf && WarehousePanel.instance.gameObject.activeSelf)
        else
        {
            if (RoleInfoPanel.instance == null) return;
            else if (!RoleInfoPanel.instance.gameObject.activeSelf) return;
            if (WarehousePanel.instance == null) return;
            else if (!WarehousePanel.instance.gameObject.activeSelf) return;
            if (medalData != null)
            {
                DataManager.Instance.AddMedalToMode(medalData);
                WarehousePanel.instance.MedalBtnClick();
                RoleInfoPanel.instance.RemoveMedal();
                clear();
            }
            if (OrnamentData != null)
            {
                Debug.Log(OrnamentData.Count);
                DataManager.Instance.AddOrnamentToMode(OrnamentData);
                WarehousePanel.instance.OrnamentBtnClick();

                if (itemType == itemTypeEnum.roleInfo2) RoleInfoPanel.instance.RemoveOrnament(1);
                else if (itemType == itemTypeEnum.roleInfo3) RoleInfoPanel.instance.RemoveOrnament(2);
                clear();
            }
        }
    }
    /// <summary>
    ///战斗场景非战斗状态
    /// </summary>
    /// <param name="go"></param>
    void RightClick_BattleScene(GameObject go)
    {
        if (OnRightClick != null) OnRightClick(this);
        //else if (RoleInfoPanel.instance.gameObject.activeSelf && WarehousePanel.instance.gameObject.activeSelf)
        else
        {
            if (RoleInfoPanel.instance == null) return;
            else if (!RoleInfoPanel.instance.gameObject.activeSelf) return;
            Debug.Log("RightClick_BattleScene");
            if (BattleFlowController.Instance == null) return;
            if (OrnamentData != null)
            {
                Debug.Log("RightClick_BattleScene -OrnamentData " + OrnamentData.Count);
                OrnamentData.Count = 1;
                BattleFlowController.Instance.kanpsack.AddOrnamentToKanspsack(OrnamentData);         
                if (itemType == itemTypeEnum.roleInfo2) RoleInfoPanel.instance.RemoveOrnament(1);
                else if (itemType == itemTypeEnum.roleInfo3) RoleInfoPanel.instance.RemoveOrnament(2);
                clear();
                RoleInfoView.Instance.RefreshRoleInfo(rolePanel.CurrentSelectHeroData);
            }
        }
    }

    void setOrnamentData() { }
}
