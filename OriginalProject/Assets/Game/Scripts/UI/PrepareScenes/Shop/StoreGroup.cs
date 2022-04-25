using Datas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 商店物品集
/// </summary>
public class StoreGroup : MonoBehaviour
{
    public event Action<ShopItem> OnBuyItem;
    private List<ShopItem> storeItems;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="objDic"></param>
    /// <param name="_data">key = 物品ID, value = 数量 </param>
    public void InitialGroup(Dictionary<int, ObjData> objDic, Dictionary<int, int> _data) {
        if (storeItems == null)
        {
            storeItems = new List<ShopItem>(GetComponentsInChildren<ShopItem>(true));
            foreach (var item in storeItems)
            {
                item.Clear();
                item.countMax = true;
                item.OnLeftClick += OnBuy;
                item.OnHoverEnter += HoverEnterItem;
                item.OnHoverExit += HoverExitItem;
            }
        }
        foreach(var item in _data)
        {
            if (objDic.ContainsKey(item.Key))
            {
                for (int j = 0; j < storeItems.Count; ++j)
                {
                    if (storeItems[j].isHaveItemData) continue;
                    storeItems[j].SetItemData(objDic[item.Key], item.Value);
                    break;
                }
            }
            else
            {
                Debug.LogError("找不到消耗品：" + item.Key);
            }
        }
    }
    public void InitialGroup(Dictionary<int,ObjData> objDic,List<int> itemIds)
    {
        if (storeItems == null)
        {
            storeItems = new List<ShopItem>(GetComponentsInChildren<ShopItem>(true));
            foreach (var item in storeItems)
            {
                item.Clear();
                item.countMax = true;
                item.OnLeftClick += OnBuy;
                item.OnHoverEnter += HoverEnterItem;
                item.OnHoverExit += HoverExitItem;
            }
        }
        for (int i = 0; i < itemIds.Count; i++)
        {
            if (objDic.ContainsKey(itemIds[i]))
            {
                for (int j = 0; j < storeItems.Count; ++j)
                {
                    if (storeItems[j].isHaveItemData) continue;
                    storeItems[j].SetItemData(objDic[itemIds[i]], 99);
                    break;
                }
            }
            else
            {
                Debug.LogError("找不到消耗品：" + itemIds);
            }
        }
    }
 
    private void OnBuy(ShopItem shopItem)
    {
        if (OnBuyItem != null)
        {
            OnBuyItem(shopItem);
        }
    }

    private void HoverEnterItem(ShopItem shipItem, HoverInfoUI infoUI)
    {
        infoUI.ClearData();
        infoUI.AddItem(shipItem.Obj.describe, 0, Color.white);
        infoUI.Show();
        infoUI.transform.SetParent(transform.parent, true);
        infoUI.transform.SetAsLastSibling();
    }

    private void HoverExitItem(ShopItem shipItem, HoverInfoUI infoUI)
    {
        infoUI.Hide();
        infoUI.transform.SetParent(shipItem.transform, true);
    }

    public void AddStoreItem(ObjData objData)
    {
        for (int i = 0; i < storeItems.Count; i++)
        {
            //此处判断改为id 判断
            //if (!storeItems[i].isEmpty&&storeItems[i].Obj.Equals(objData))
            if (!storeItems[i].isEmpty && storeItems[i].Obj.id == objData.id)
            {
                if (storeItems[i].AddItem(1) == 0)
                    return;
            }
        }
        for (int i = 0; i < storeItems.Count; i++)
        {
            if (storeItems[i].isEmpty)
            {
                storeItems[i].SetItemData(objData, 1);
                return;
            }
        }
    }

    public void RemoveStoreItem(ShopItem shopItem)
    {
        shopItem.RemoveItem();
    }
    public void Clear() {
        for (int i = 0; i < storeItems.Count; i++)
            storeItems[i].close();
    }
    public void RefreshPrice(int money)
    {
        foreach (var item in storeItems)
        {
            item.RefreshPrice(money, 0);
        }
    }
}
