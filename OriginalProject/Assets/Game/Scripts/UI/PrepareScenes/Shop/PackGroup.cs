using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Datas;
using System;

public class PackGroup : MonoBehaviour
{
    public event Action<ShopItem> OnSellItem;
    private List<ShopItem> packItems;
    private List<KanpsackMode> packMode;

    public bool IsFull
    {
        get
        {
            for (int i = 0; i < packItems.Count; i++)
            {
                if (packItems[i].isEmpty || (packItems[i].itemCount < packItems[i].MaxCount))
                    return false;
            }
            return true;
        }
    }

    public List<KanpsackMode> PackMode
    {
        get
        {
            if (packMode == null)
                packMode = new List<KanpsackMode>();
            for (int i = 0; i < packItems.Count; i++)
            {
                if (!packItems[i].isEmpty)
                {
                    if (packMode.Count <= i)
                        packMode.Add(new KanpsackMode());
                    else if (packMode[i] == null)
                        packMode[i] = new KanpsackMode();
                    packMode[i].objId = packItems[i].Obj.id;
                    packMode[i].count = packItems[i].itemCount;
                }
                else
                {
                    if (packMode.Count <= i)
                        packMode.Add(new KanpsackMode());
                    else if (packMode[i] == null)
                        packMode[i] = new KanpsackMode();
                    packMode[i].objId = 0;
                    packMode[i].count = 0;
                }
            }
            return packMode;
        }
    }

    public void InitialGroup()
    {
        if (packItems == null)
        {
            packItems = new List<ShopItem>(GetComponentsInChildren<ShopItem>(true));
            foreach (var item in packItems)
            {
                item.OnLeftClick += OnSell;
                item.OnHoverEnter += HoverEnterItem;
                item.OnHoverExit += HoverExitItem;
                item.Clear();
            }
        }
    }

    private void OnSell(ShopItem shopItem)
    {
        if (!shopItem.Enabled)
            return;
        if (OnSellItem != null)
        {
            OnSellItem(shopItem);
        }
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

    public void AddPackItem(ObjData objData,bool isEnabled=true)
    {
        DataManager.Instance.modeData.kanpsackModes = packMode;
        for (int i = 0; i < packItems.Count; i++)
        {
            if (!packItems[i].isEmpty && packItems[i].Obj.Equals(objData))
            {
                if (packItems[i].AddItem(1) == 0)
                {
                    packItems[i].Enabled = isEnabled;
                    return;
                }
            }
        }
        for (int i = 0; i < packItems.Count; i++)
        {
            if (packItems[i].isEmpty)
            {
                packItems[i].SetItemData(objData, 1,false);
                packItems[i].Enabled = isEnabled;
                return;
            }
        }
    }

    public void RemovePackItem(ShopItem shopItem)
    {
        shopItem.RemoveItem();
    }
}
