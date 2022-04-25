using Datas;
using GEvent;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 补给面板
/// </summary>
public class SupplyPanel : MonoBehaviour
{
    public List<int> supplyItemIds;
    public List<int> givenItemIds;
    public GameObject confirmPanel,fakeBtn;
    private StoreGroup storeGroup;
    private PackGroup packGroup;
    private Dictionary<int, ObjData> objDic;
    private ModeData modeData;

    private bool HasBuy
    {
        get
        {
            foreach (var item in packGroup.PackMode)
            {
                if (item != null && !givenItemIds.Contains(item.objId))
                {
                    return true;
                }
            }
            return false;
        }
    }

    public void InitialPanel()
    {
        modeData = DataManager.Instance.modeData;
        if (objDic == null)
        {
            DataSetItem dataItem = DataManager.Instance.GetData("ObjData");
            ObjDataSet objData = dataItem.scriptableObject as ObjDataSet;
            objDic = new Dictionary<int, ObjData>();
            for (int i = 0; i < objData.porpDatas.Count; i++)
            {
                if (objData.porpDatas[i].levelType.Equals(LevelType.消耗品))
                    objDic.Add(objData.porpDatas[i].id, objData.porpDatas[i]);
            }
        }
        if (storeGroup == null)
        {
            storeGroup = GetComponentInChildren<StoreGroup>(true);
            storeGroup.OnBuyItem += OnBuyItem;
        }
        if (packGroup == null)
        {
            packGroup = GetComponentInChildren<PackGroup>(true);
            packGroup.InitialGroup();
            packGroup.OnSellItem += OnSellItem;
        }
        givenItemIds = new List<int>();
        if (givenItemIds != null)
        {
            for (int i = 0; i < givenItemIds.Count; i++)
            {
                if (objDic.ContainsKey(givenItemIds[i]))
                {
                    packGroup.AddPackItem(objDic[givenItemIds[i]], false);
                }
                else
                    Debug.LogError("找不到消耗品：" + givenItemIds[i]);
            }
        }
        supplyItemIds = new List<int>() { 6001, 6002, 6003, 6004 };
        if (supplyItemIds != null)
        {
            storeGroup.InitialGroup(objDic,supplyItemIds);
            storeGroup.RefreshPrice(ResPanel.Instance.Money);
        }

        EventHelper.Instance.AddEvent(GEventType.GoBattle, ComfirmPack);
    }

    private void OnBuyItem(ShopItem shopItem)
    {
        AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
        if (shopItem.price > ResPanel.Instance.Money) AudioManager.Instance.PlayAudio(AudioName.COINS_Error_01_mono, AudioType.Common);
        if (shopItem.price <= ResPanel.Instance.Money&&!packGroup.IsFull)
        {
            storeGroup.RemoveStoreItem(shopItem);
            ResPanel.Instance.ChangeResource(-shopItem.price);
            packGroup.AddPackItem(shopItem.Obj, !givenItemIds.Contains(shopItem.Obj.id));
            CheckBuy();
        }
        
    }

    private void OnSellItem(ShopItem shopItem)
    {
        ResPanel.Instance.ChangeResource(shopItem.SellPrice);
        storeGroup.AddStoreItem(shopItem.Obj);
        packGroup.RemovePackItem(shopItem);
        CheckBuy();
    }

    public void SetSupplyItems(List<int> itemIDs)
    {
        supplyItemIds = itemIDs;
    }

    public void SetPanel(bool isOpen)
    {
        if (isOpen)
        {
            AudioManager.Instance.PlayAudio(AudioName.DOOR_Metal_Open_Creak_stereo, AudioType.Common);
            InitialPanel();
            gameObject.SetActive(true);
        }
        else
        {
            AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
            gameObject.SetActive(false);
        }
    }

    private void CheckBuy()
    {
        if (HasBuy)
        {
            fakeBtn.SetActive(false);
        }
        else
        {
            fakeBtn.SetActive(true);
        }
    }

    void ComfirmPack(Hashtable args)
    {
        modeData.kanpsackModes = packGroup.PackMode;
        Debug.Log("get pack data");
    }
}
