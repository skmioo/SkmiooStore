using Datas;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 交互物-地下商城
/// </summary>
public class UndergroundShop : InteractiveTriggerBox
{
    public override InteractiveType m_InteractiveType => InteractiveType.地下游商;
    /// <summary>
    /// key = 物品ID, value = 数量
    /// </summary>
    public Dictionary<int, int> shopItemDataDic;
    public  Dictionary<int, ObjData> shopItemObjDataDic;
    private Dictionary<ObjType, Dictionary<int, ObjData>> shopItemObjDataDicOfType;

    public UndergroundShopMode Mode { get; private set; }

    public override void Start()
    {
        base.Start();

        shopItemDataDic = new Dictionary<int, int>();
        if (modeBase != null)
        {
            Mode = modeBase as UndergroundShopMode;
            foreach (var item in Mode.shopItemDatas)
            {
                shopItemDataDic.Add(item.shopItemId, item.count);
            }
            shopItemObjDataDic = Mode.shopItemObjDataDic;
            return;
        }
        Dictionary<ObjType, int> limmit = null;
        List<ObjLifeData> heros =   BattleFlowController.Instance.GetHeros();
        List< ObjPermanentBuff> buffs = heros.Count <= 0 ? new List < ObjPermanentBuff >(): heros[0].FindPermanentBuff(ObjBuffType.地牢商店商品出现稀有饰品概率,ObjBuffType.地牢商店商品出现圣物概率);
        for (int i = 0; i < buffs.Count; ++i) {
            if (limmit == null) limmit = new Dictionary<ObjType, int>();
            ObjType type = buffs[i].buffType == ObjBuffType.地牢商店商品出现稀有饰品概率 ? ObjType.饰品 :  ObjType.圣物;
            limmit.Add(type, buffs[i].buffValue);
        }
        InitInteractive(DataManager.Instance.GetRandomUndergroundShopDatas(limmit));
        if (Mode == null)
        {
            Mode = new UndergroundShopMode(m_InteractiveType, mapType, roomIndex, routeGroupIndex, routeIndex);
            List<UndergroundShopItemData> shopItemDatas = new List<UndergroundShopItemData>();
            foreach (var item in shopItemDataDic)
            {
                shopItemDatas.Add(new UndergroundShopItemData(item.Key, item.Value));
            }
            Mode.shopItemDatas = shopItemDatas;
            Mode.shopItemObjDataDic = shopItemObjDataDic;
            DataManager.Instance.AddInteractivMode(Mode);
        }
    }

   protected override void InteractiveBtn_OnClick()
    {
        base.InteractiveBtn_OnClick();

        UndergroudShopPanel.Instance.Show(this);
    }

    void InitInteractive(Dictionary<ObjType, InteractiveShop> shopDatas)
    {
        loadShopItemObjDataDic();
        foreach (var tempShop in shopDatas) {
            switch (tempShop.Key)
            {
                case ObjType.物品:
                    foreach (var item in shopItemObjDataDicOfType[tempShop.Key])
                        shopItemDataDic.Add(item.Key, Random.Range(tempShop.Value.minCount, tempShop.Value.maxCount + 1));
                    break;
                case ObjType.饰品:
                    int count =  Random.Range(tempShop.Value.minCount, tempShop.Value.maxCount + 1);
                    InteractiveShopOrnament temp = null;
                    List<int> list = new List<int>();
                    int keyTemp = -1;
                    for (int i = 0; i < count; ++i) {
                        temp = DataManager.Instance.GetRandomByProbability(tempShop.Value.levels, tempShop.Value.levels.Select(s => s.probability).ToList());
                        list.Clear();
                        foreach (var item in shopItemObjDataDicOfType[tempShop.Key]){
                            if (item.Value.levelType == temp.levelType) list.Add(item.Key);
                        }
                        keyTemp = list[Random.Range(0, list.Count)];
                        if (!shopItemDataDic.ContainsKey(keyTemp)) shopItemDataDic.Add(keyTemp, 0);
                        shopItemDataDic[keyTemp] += 1;
                    }
                    break;
                case ObjType.圣物:
                    foreach (var item in shopItemObjDataDicOfType[tempShop.Key]) {
                           if(!CheckIsHaveSacred(item.Key))
                            shopItemDataDic.Add(item.Key, Random.Range(tempShop.Value.minCount, tempShop.Value.maxCount + 1));
                    }
                    break;
            }
           
        }
        
    }
    /// <summary>
    /// 检测是否拥有圣物
    /// </summary>
    /// <param name="_id"></param>
    /// <returns></returns>
    bool CheckIsHaveSacred(int _id)
    {
       List< SacredObjData> list = DataManager.Instance.GetSacredFromMode();
        SacredObjData temp = list.Find(s => s.GetId() == _id);
        return temp != null;
    }
    void loadShopItemObjDataDic() {
        if (shopItemObjDataDic != null) return;
        DataSetItem dataItem = DataManager.Instance.GetData("ObjData");
        ObjDataSet objData = dataItem.scriptableObject as ObjDataSet;
        shopItemObjDataDic = new Dictionary<int, ObjData>();
        shopItemObjDataDicOfType = new Dictionary<ObjType, Dictionary<int, ObjData>>();
        shopItemObjDataDicOfType.Add(ObjType.物品, new Dictionary<int, ObjData>());
        shopItemObjDataDicOfType.Add(ObjType.饰品, new Dictionary<int, ObjData>());
        shopItemObjDataDicOfType.Add(ObjType.圣物, new Dictionary<int, ObjData>());
        for (int i = 0; i < objData.porpDatas.Count; i++)
        {
            if (objData.porpDatas[i].levelType.Equals(LevelType.消耗品))
            {
                shopItemObjDataDic.Add(objData.porpDatas[i].id, objData.porpDatas[i]);
                shopItemObjDataDicOfType[objData.porpDatas[i].objType].Add(objData.porpDatas[i].id, objData.porpDatas[i]);
            } 
        }
        for (int i = 0; i < objData.ornamentsDatas.Count; i++)
        {
            shopItemObjDataDic.Add(objData.ornamentsDatas[i].id, objData.ornamentsDatas[i]);
            shopItemObjDataDicOfType[objData.ornamentsDatas[i].objType].Add(objData.ornamentsDatas[i].id, objData.ornamentsDatas[i]);
        }

        dataItem = DataManager.Instance.GetData("SacredData");
        SacredDataSet sacredData = dataItem.scriptableObject as SacredDataSet;
        for (int i = 0; i < sacredData.sacredDatas.Count; i++)
        {
            shopItemObjDataDic.Add(sacredData.sacredDatas[i].id, sacredData.sacredDatas[i]);
            shopItemObjDataDicOfType[sacredData.sacredDatas[i].objType].Add(sacredData.sacredDatas[i].id, sacredData.sacredDatas[i]);
        }
    }
    public void Sell(int _id, ObjData item)
    {
        if (!shopItemDataDic.ContainsKey(_id))
        {
            shopItemDataDic.Add(_id, 0);
            shopItemDataDic[_id] += 1;

            if (!shopItemObjDataDic.ContainsKey(_id))
            {
                shopItemObjDataDic.Add(_id, item);
            }
        }
    }
    public void Buy(int _id) {
        if (!shopItemDataDic.ContainsKey(_id))
        {
            AudioManager.Instance.PlayAudio(AudioName.COINS_Error_01_mono, AudioType.Common);
            return; 
        }
        shopItemDataDic[_id] -= 1;
        if (shopItemDataDic[_id] <= 0) shopItemDataDic.Remove(_id);

        AudioManager.Instance.PlayAudio(AudioName.COINS_Rattle_01_mono, AudioType.Common);
    }

    private void OnEnable()
    {
        ExitBattleScenes.onBeginExitBattleScenes += OnExitBattleScenes;
    }

    protected override void OnDisable()
    {
        ExitBattleScenes.onBeginExitBattleScenes -= OnExitBattleScenes;
        base.OnDisable();
    }

    private void OnExitBattleScenes()
    {
        Exit();
    }

    public void Exit()
    {
        List<UndergroundShopItemData> shopItemDatas = new List<UndergroundShopItemData>();
        foreach (var item in shopItemDataDic)
        {
            shopItemDatas.Add(new UndergroundShopItemData(item.Key, item.Value));
        }
        Mode.shopItemDatas = shopItemDatas;
        Mode.shopItemObjDataDic = shopItemObjDataDic;
    }
}
