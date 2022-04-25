using Datas;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 地下游商弹窗
/// </summary>
public class UndergroudShopPanel : MonoSingleton<UndergroudShopPanel>
{
    private UndergroundShop CurInteracive;
    public RectTransform panel;
    public GameObject forSaleView;
    public Text price;
    public GameObject warn;
    public Button CloseBtn;
    public Button SellBtn;
    public GameObject[] itemObj;
    bool isSellMode;
    private StoreGroup storeGroup;
    private int shopSiblingIndexInit;
    private bool isRefresh;
    protected override void Awake()
    {
        base.Awake();
        panel.gameObject.SetActive(false);
        CloseBtn.onClick.AddListener(CloseOnClick);
        SellBtn.onClick.AddListener(SellOnClick);
        shopSiblingIndexInit = transform.GetSiblingIndex();
        isRefresh = false;
    }

    private void OnDisable()
    {
        MapController.Instance.OnIntoRoute -= OnChangeMap;
        ExitBattleScenes.onBeginExitBattleScenes -= OnExitBattleScenes;
    }

    private void OnEnable()
    {
        ExitBattleScenes.onBeginExitBattleScenes += OnExitBattleScenes;
    }


    private void OnExitBattleScenes()
    {
        Exit();
    }

    private void OnChangeMap()
    {
        Exit();
        MapController.Instance.OnIntoRoute -= OnChangeMap;
    }

    void CloseOnClick() { Exit(); }
    void SellOnClick() {
        isSellMode = !isSellMode;
        BattleFlowController.Instance.kanpsack.IsSellMode = isSellMode;
        RefreshSellBtnStatus();
    }
    void RefreshSellBtnStatus()
    {
        forSaleView.SetActive(false);
        SellBtn.image.color = isSellMode ? new Color(1, 1, 0.5f) : Color.white;
        if (isSellMode) transform.SetSiblingIndex(BattleFlowController.Instance.roleInfoView.transform.GetSiblingIndex());
        else transform.SetSiblingIndex(shopSiblingIndexInit);
    }
    public void Exit()
    {
        isSellMode = false;
        isRefresh = false;
        BattleFlowController.Instance.kanpsack.IsSellMode = isSellMode;
        panel.gameObject.SetActive(false);

        BattleFlowController.Instance.IsInteracting = false;

        if(CurInteracive) CurInteracive.Exit();
        Clear();
    }
   
    public void Show(UndergroundShop _interacive)
    {
        if (isRefresh) return;
        isRefresh = true;
        MapController.Instance.OnIntoRoute += OnChangeMap;
        CurInteracive = _interacive;

        if (storeGroup == null)
        {
            storeGroup = GetComponentInChildren<StoreGroup>(true);
            storeGroup.OnBuyItem += OnBuyItem;
        }
        panel.gameObject.SetActive(true);
        for (int i = 0; i < itemObj.Length; i++)
        {
            itemObj[i].SetActive(true);
        }
        RefreshSellBtnStatus();
       
        if (CurInteracive.shopItemDataDic != null)
        {
            storeGroup.InitialGroup(CurInteracive.shopItemObjDataDic, CurInteracive.shopItemDataDic);
            storeGroup.RefreshPrice(BattleFlowController.Instance.kanpsack.kanpsackMoney);
        }
    }
    void Clear() {
        if (CurInteracive && CurInteracive.shopItemDataDic != null)
        {
            storeGroup.Clear();
        }
    }
    private void OnBuyItem(ShopItem shopItem)
    {
        AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
        if (shopItem.price > BattleFlowController.Instance.kanpsack.kanpsackMoney) AudioManager.Instance.PlayAudio(AudioName.COINS_Error_01_mono, AudioType.Common);
        if (shopItem.price <= BattleFlowController.Instance.kanpsack.kanpsackMoney)
        {

            BattleFlowController.Instance.kanpsack.UpdateMoney(-shopItem.price,true);  // ResPanel.Instance.ChangeResource(-shopItem.price);
            //添加到背包
            if (shopItem.Obj != null) {
                ObjData data = shopItem.Obj.Clone();
                data.Count = 1;
                BattleFlowController.Instance.kanpsack.AddOrnamentToKanspsack(data);
                CurInteracive.Buy(data.id);
                storeGroup.RemoveStoreItem(shopItem);
            }
            storeGroup.RefreshPrice(BattleFlowController.Instance.kanpsack.kanpsackMoney);
        }
    }
    
    /// <summary>
    /// 售卖
    /// </summary>
    /// <param name="_data"></param>
    public  void OnSellItem(ObjData _data)
    {
        BattleFlowController.Instance.kanpsack.UpdateMoney(_data.sell,true);//ResPanel.Instance.ChangeResource(shopItem.SellPrice);

        storeGroup.AddStoreItem(_data);
        CurInteracive.Sell(_data.id, _data);
        forSaleView.SetActive(false);
        warn.SetActive(false);
        storeGroup.RefreshPrice(BattleFlowController.Instance.kanpsack.kanpsackMoney);
    }

    public void ShowSalePop(ObjData item)
    {
        price.text = $"售价为 : {item.sell}";
        forSaleView.SetActive(true);
    }

    public void ShowWarn()
    {
        warn.SetActive(true);
    }
}
