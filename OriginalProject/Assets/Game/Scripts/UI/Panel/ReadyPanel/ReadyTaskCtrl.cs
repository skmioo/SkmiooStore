using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Datas;

public class ReadyTaskCtrl : MonoBehaviour
{
    public GoBattle goBattle;
    public Text taskName, mapSize, mapDifficulty, taskTarget, taskDescribe, taskTitle;
    public Image[] itemAry;
    public GameObject[] ornamentItemList;
    ReadyHoverInfo[] hoverAry;
    Dictionary<int, ObjData> OrnamentDataMap = new Dictionary<int, ObjData>();
    Dictionary<int, ObjData> OrnamentDataMap2 = new Dictionary<int, ObjData>();

    public void setData(TaskObjData inData, ZoneObjData zoneData, int inIndex = 0, int inTaskIndex = 0)
    {
        taskName.text = LanguageController.GetValue(inData.GetTaskName());
        mapSize.text = LanguageController.GetValue("地图大小") + "：" + LanguageController.GetValue(inData.GetMapSize().ToString());
        mapDifficulty.text = LanguageController.GetValue("地图难度") + "：" + LanguageController.GetValue(inData.GetTaskDifficulty().ToString());
        taskTarget.text = LanguageController.GetValue(inData.GetTaskTarget());
        taskDescribe.text = LanguageController.GetValue(inData.GetTaskDescribe());
        taskTitle.text = LanguageController.GetValue("奖励");

        // 刷新战斗信息
        BattleInfo.MapSize = inData.GetMapSize();
        BattleInfo.TaskDifficulty = inData.GetTaskDifficulty();
        BattleInfo.TaskObjDatas.Clear();
        BattleInfo.TaskObjDatas.Add(inData);
        if (zoneData != null)
            BattleInfo.MapName = zoneData.GetMapName();

        if (hoverAry == null || hoverAry.Length < itemAry.Length)
            creatorHover();

        //勋章
        var tempMedal = inData.GetMedalDrops();
        // DataManager.Instance.GetMedalDataById(5001).icon.LoadAssetAsync().Completed += inGo => { itemAry[0].sprite = inGo.Result; };
        Text itemText = itemAry[0].GetComponentInChildren<Text>();
        if(itemText != null)
            itemText.text = tempMedal.Count.ToString();
        hoverAry[0].ClearData();
        for (int i = 0; i < tempMedal.Count; i++)
        {
            Debug.Log(tempMedal[i].level);
            hoverAry[0].AddItem($"有{tempMedal[i].probability}概率掉落{tempMedal[i].count}个{(MedalType)(tempMedal[i].level - 1)}", i + 1, Color.white);
        }


        //饰品
        BattleInfo.OrnamentList.Clear();
        DataSetItem dataSet = DataManager.Instance.GetData("ObjData");
        ObjDataSet objData = dataSet.scriptableObject as ObjDataSet;

        var tempOrnament = inData.GetOrnamentDrops();

        int nTaskId = inIndex * 10000 + inTaskIndex;
        ObjData OrnamentData = OrnamentDataMap.TryGetValue(nTaskId);
        if(OrnamentData == null)
        {
            LevelType nNeedOrnamentLevel = tempOrnament[0].level;
            List<ObjData> tOrnamentLevelData = new List<ObjData>();
            foreach (var item in objData.ornamentsDatas)
            {
                if(item.levelType == nNeedOrnamentLevel)
                    tOrnamentLevelData.Add(item);
            }
            OrnamentData = tOrnamentLevelData[UnityEngine.Random.Range(0, tOrnamentLevelData.Count - 1)];
            OrnamentDataMap.Add(nTaskId, OrnamentData);
        }
        DataManager.Instance.GetOrnamentDataById(OrnamentData.id).Icon.LoadAssetAsync().Completed += inGo => { itemAry[1].sprite = inGo.Result; };
        itemText = itemAry[1].GetComponentInChildren<Text>();
        if(itemText != null)
            itemText.text = tempOrnament.Count.ToString();
        hoverAry[1].ClearData();
        hoverAry[1].AddItem(LanguageController.GetDescribe(OrnamentData), 0, Color.white);
        BattleInfo.OrnamentList.Add(OrnamentData);
        // hoverAry[1].AddItem($"有{tempOrnament[0].probability}概率掉落{tempOrnament[0].level}等级饰品", 1, Color.white);
        // for (int i = 0; i < tempOrnament.Count; i++)
        //     hoverAry[1].AddItem($"有{tempOrnament[i].probability}概率掉落{tempOrnament[i].level}等级饰品", i + 1, Color.white);

        //饰品2
        if(tempOrnament.Count > 1)
        {
            ornamentItemList[1].gameObject.SetActive(true);
            ObjData OrnamentData2 = OrnamentDataMap2.TryGetValue(nTaskId);
            if(OrnamentData2 == null)
            {
                LevelType nNeedOrnamentLevel = tempOrnament[1].level;
                List<ObjData> tOrnamentLevelData = new List<ObjData>();
                foreach (var item in objData.ornamentsDatas)
                {
                    if(item.levelType == nNeedOrnamentLevel)
                        tOrnamentLevelData.Add(item);
                }
                OrnamentData2 = tOrnamentLevelData[UnityEngine.Random.Range(0, tOrnamentLevelData.Count - 1)];
                OrnamentDataMap2.Add(nTaskId, OrnamentData2);
            }
            
            DataManager.Instance.GetOrnamentDataById(OrnamentData2.id).Icon.LoadAssetAsync().Completed += inGo => { itemAry[2].sprite = inGo.Result; };
            itemText = itemAry[2].GetComponentInChildren<Text>();
            if(itemText != null)
                itemText.text = tempOrnament.Count.ToString();
            hoverAry[2].ClearData();
            hoverAry[2].AddItem(LanguageController.GetDescribe(OrnamentData2), 0, Color.white);
            BattleInfo.OrnamentList.Add(OrnamentData2);
            // hoverAry[2].AddItem($"有{tempOrnament[1].probability}概率掉落{tempOrnament[1].level}等级饰品", 2, Color.white);
        }
        else
        {
            ornamentItemList[1].gameObject.SetActive(false);
        }

        //资源
        // DataManager.Instance.GetObjData(7001).Icon.LoadAssetAsync().Completed += inGo => { itemAry[2].sprite = inGo.Result; };
        // itemAry[2].GetComponentInChildren<Text>().text = inData.GetMoney().ToString();
        // hoverAry[2].ClearData();
        // hoverAry[2].AddItem(DataManager.Instance.GetObjData(7001).describe, 1, Color.white);

        // int resourcesMin = 0, resourcesMax = 0;
        // inData.GetResourceCount(out resourcesMin, out resourcesMax);
        // resourcesMin = UnityEngine.Random.Range(resourcesMin, resourcesMax);
        var tempRes = inData.GetResourcesId();
        for (int i = 3, i2 = 0; i < 7; i++, i2++)
        {
            ObjData oResData = DataManager.Instance.GetObjData(tempRes[i2].id);
            loadItemIco(itemAry[i], oResData.Icon);
            itemAry[i].GetComponentInChildren<Text>().text = tempRes[i2].count.ToString();
            hoverAry[i].ClearData();
            hoverAry[i].AddItem(LanguageController.GetDescribe(oResData), 1, Color.white);
        }
        //if (inData.GetTaskName() == (MapNameType.冥河矿洞).ToString()) goBattle.BtnClickMinghekuangdong();
        //if (inData.GetTaskName() == (MapNameType.镂空之地).ToString()) goBattle.BtnClickLoukongzhidi();
    }

    void creatorHover()
    {
        hoverAry = new ReadyHoverInfo[itemAry.Length];
        for (int i = 0; i < itemAry.Length; i++)
        {
            hoverAry[i] = itemAry[i].gameObject.GetComponentInChildren<ReadyHoverInfo>();
            hoverAry[i].parent = itemAry[i].transform;
            addEvent(itemAry[i].gameObject, hoverAry[i].Show, hoverAry[i].Hide);
            hoverAry[i].Hide();
        }
    }

    void loadItemIco(Image inItem, UnityEngine.AddressableAssets.AssetReferenceSprite inSprite)
    {
        inSprite.LoadAssetAsync().Completed += inGo => { inItem.sprite = inGo.Result; };
    }

    void addEvent(GameObject inGo, System.Action inEnterFunc, System.Action inExitFunc)
    {
        UIEventManager.AddTriggersListener(inGo).onEnter = inGp => { inEnterFunc(); };
        UIEventManager.AddTriggersListener(inGo).onExit = inGp => { inExitFunc(); };
    }
}
