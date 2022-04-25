//#define LCC_CONVERT_TO_MONEY //所有的都转换成money带回城镇
#define LCC_SAVE_TO_TOWN //部分转换成money 和部分直接带回资源
#define LCC_TASKREWARD1 //任务奖励方案一
//#define LCC_TASKREWARD2 //任务奖励方案二
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Datas;
using System.Linq;

/// <summary>
/// 任务结算面板 
/// </summary>
public class Settlement : MonoBehaviour
{
    private ModeData modeData {
        get {
            return DataManager.Instance.modeData;
        }
    }
    public RectTransform panel;
    public Text tipsName;//弃用
    private bool isPopUpFlag;
    /// <summary>
    /// 打开结算面板
    /// </summary>
    /// <param name="isFlee">true = 逃离，false = 任务成功结算</param>
    public void ShowSettlement(bool isFlee)
    {
        // isFlee = false;

        /// <summary>
        /// if (isFlee)
        ///{
        ///   tipsName.text = "任务未完成";
        ///    AudioManager.Instance.PlayMusic(AudioName.FailedBGM);
        ///}
        ///else
        ///{
        ///    tipsName.text = "任务完成";
        ///    AudioManager.Instance.PlayMusic(AudioName.Finish_Task_BGM);
        ///}
        /// </summary>
        BattleFlowController.Instance.IsBattling = false;
        Heros = BattleFlowController.Instance.GetHeros();
        SetTaskPrize(isFlee);
        SetTreasure();
        SetResource();
        SetSpoils();
        SetRoleInfo(isFlee);
        SetTaskName("");//未完成
        ClearSacredBuffEffect();
        DataManager.Instance.ClearAllInteractiveMode();
        BattleInfo.TaskObjDatas.Clear();
        PopUp();
    }
    public void PopUp() {
        if (panel.gameObject.activeSelf) return;
        if (BattleFlowController.Instance)
        {
            BattleFlowController.Instance.IsInteracting = true;
        }
        panel.gameObject.SetActive(true);
    }
    public void Hide() {
        if (!panel.gameObject.activeSelf) return;
        if (BattleFlowController.Instance)
        {
            BattleFlowController.Instance.IsInteracting = false;
        }
        panel.gameObject.SetActive(false);
    }
    /// <summary>
    /// 清空圣物BUFF效果
    /// </summary>
    void ClearSacredBuffEffect()
    {
        for (int i = 0; i < Heros.Count; ++i) Heros[i].RemovePermanentBuff(BuffSourceType.圣物);
    }
   
    #region 任务奖励

    public GameObject objItem;
    public Transform taskPrizeBoxTransf;
    private List<Transform> taskPrizeBox = new List<Transform>();
    private int taskPrizeBoxIndex;
    Dictionary<int, ObjData> objDataDict = new Dictionary<int, ObjData>();

    void SetObjDataDict()
    {
        DataSetItem dataSet = DataManager.Instance.GetData("ObjData");
        ObjDataSet objData = dataSet.scriptableObject as ObjDataSet;

        foreach (var item in objData.porpDatas)
        {
            objDataDict.Add(item.id, item);
        }

        //foreach (var item in objData.medalDatas)
        //{
        //    objDataDict.Add(item.id, item);
        //}

        foreach (var item in objData.ornamentsDatas)
        {
            objDataDict.Add(item.id, item);
        }
    }
    /// <summary>
    /// 任务奖励
    /// </summary>
    /// <param name="isFlee"></param>
    void SetTaskPrize(bool isFlee)
    {
        if (isFlee) return;
        if (BattleInfo.MapName == MapNameType.教程关卡) return;
        if (objDataDict.Count < 1)
        {
            SetObjDataDict();
        }

        //TaskData taskData = TaskProgress.Instance.taskData;
        //for (int i = 0; i < taskData.rewardObjitem.Count; i++)
        //{
        //    taskPrizeBox[i].gameObject.SetActive(true);
        //    ObjData objData = objDataDict[taskData.rewardObjitem[i]];
        //    GameObject go = Instantiate(objItem, taskPrizeBox[i]);

        //    ObjItem _obj = go.GetComponent<ObjItem>();
        //    _obj.InitItem(objData, 1, taskPrizeBox[i]);
        //    prizes.Add(objData);
        //}

#if LCC_TASKREWARD1
        List<ZoneObjData> levels = DataManager.Instance.GetZoneObj();
        ZoneObjData levelTemp = levels.Find(s => s.GetMapName() == BattleInfo.MapName);

        TaskReward taskReward = DataManager.Instance.GetTaskReward(BattleInfo.TaskDifficulty, BattleInfo.MapSize);
        //Debug.Log(taskReward.id);
        TaskResourceInfo taskResourceInfo = DataManager.Instance.GetTaskRewardResource(BattleInfo.MapName, BattleInfo.TaskDifficulty, BattleInfo.MapSize);

        ///key = id,value = count
        Dictionary<int, int> Result = new Dictionary<int, int>();
        
        //鳞甲
        int money = 0;
        #region 方案一
        ////资源
        //int resourcesMinCount = taskReward.minResource, resourcesMaxCount = taskReward.maxResource;
        //int resiurcesCount = Random.Range(resourcesMinCount, resourcesMaxCount + 1);
        //List<int> resourcesIds = taskRewardResource.resourceIds;

        //for (int i = 0; i < resiurcesCount; ++i)
        //{
        //    int idTemp = resourcesIds[Random.Range(0, resourcesIds.Count)];
        //    if (!Result.ContainsKey(idTemp)) Result.Add(idTemp, 0);
        //    Result[idTemp] += 1;
        //    if (idTemp == 7002) ChangeResource(0, 1);
        //    if (idTemp == 7003) ChangeResource(0, 0, 1);
        //    if (idTemp == 7004) ChangeResource(0, 0, 0, 1);
        //    if (idTemp == 7005) ChangeResource(0, 0, 0, 0, 1);
        //    if (idTemp == 7006) ChangeResource(0, 0, 0, 0, 0, 1);
        //}
        ////饰品
        //List<OrnamentReward> ornamentRewardList = taskReward.ornamentDrops;
        //OrnamentReward ornamentReward = DataManager.Instance.GetRandomByProbability(ornamentRewardList, ornamentRewardList.Select(s => s.probability).ToList());
        //List<ObjData> ornamentList = new List<ObjData>();
        //foreach (var item in objDataDict)
        //{
        //    if (item.Value.objType == ObjType.饰品 && item.Value.levelType == ornamentReward.level) ornamentList.Add(item.Value);
        //}

        //for (int i = 0; i < ornamentReward.count; ++i)
        //{
        //ObjData idTemp = ornamentList[Random.Range(0, ornamentList.Count)];
        //if (!Result.ContainsKey(idTemp.id)) Result.Add(idTemp.id, 0);
        //Result[idTemp.id] += 1;
        //DataManager.Instance.AddOrnamentToMode(idTemp);
        //}
        #endregion
        #region 方案二
        //资源
        List<Resource> resourcesIds = taskResourceInfo.resourceIds;
        for (int i = 0; i < resourcesIds.Count; ++i)
        {
            Resource resource = resourcesIds[i];
            int idTemp = resource.id;
            if (!Result.ContainsKey(idTemp)) Result.Add(idTemp, 0);
            Result[idTemp] += resource.count;
            if (idTemp == 7001) money = resource.count;
            else if (idTemp == 7002) ChangeResource(0, resource.count);
            else if (idTemp == 7003) ChangeResource(0, 0, resource.count);
            else if (idTemp == 7004) ChangeResource(0, 0, 0, resource.count);
            else if (idTemp == 7005) ChangeResource(0, 0, 0, 0, resource.count);
            else if (idTemp == 7006) ChangeResource(0, 0, 0, 0, 0, resource.count);
        }

        //饰品
        List<ObjData> ornamentList = new List<ObjData>(BattleInfo.OrnamentList);
        for (int i = 0; i < ornamentList.Count; ++i)
        {
            ObjData idTemp = ornamentList[Random.Range(0, ornamentList.Count)];
            if (!Result.ContainsKey(idTemp.id)) Result.Add(idTemp.id, 0);
            Result[idTemp.id] += 1;
            DataManager.Instance.AddOrnamentToMode(idTemp);
        }
        #endregion

        List<ObjPermanentBuff> buff = Heros.Count <= 0 ? new List<ObjPermanentBuff>() : Heros[0].FindPermanentBuff(ObjBuffType.结算时鳞甲增加);
        if (buff.Count > 0) money = Mathf.RoundToInt(money * (1 + (buff[0].buffValue / 100f)));

        ChangeResource(money);

        ///鳞甲，资源，饰品显示
        foreach (var item in Result) AddObjDataToTaskPrizeBox(item.Key, item.Value);

        //勋章
        List<MedalReward> medalRewardList = taskReward.medalDrops;
        MedalReward medalReward = DataManager.Instance.GetRandomByProbability(medalRewardList, medalRewardList.Select(s => s.probability).ToList());
        Dictionary<MedalObjData, int> medalResult = new Dictionary<MedalObjData, int>();

        for (int i = 0; i < medalReward.count; ++i)
        {
            MedalObjData medal = DataManager.Instance.CreateMedal(medalReward.level);
            if (!medalResult.ContainsKey(medal)) medalResult.Add(medal, 0);
            medalResult[medal] += 1;
            //勋章带回城镇
            DataManager.Instance.AddMedalToMode(medal);
        }
        //勋章显示
        foreach (var item in medalResult) AddMedalDataToTaskPrizeBox(item.Key, item.Value);
        //警戒值
        levelTemp.UpdateWarningValue(taskReward.warningValueAdd);

        // 击杀boss记录
        if(BattleInfo.TaskObjDatas.Count > 0)
        {
            TaskObjData task = BattleInfo.TaskObjDatas[0];
            if(task.GetTaskType() == N_TaskType.固定boss)
                levelTemp.UpdateKillBoss(true);
        }
#elif LCC_TASKREWARD2
        List<ZoneObjData> levels = DataManager.Instance.GetZoneObj();
        ZoneObjData levelTemp = levels.Find(s => s.GetMapName() == BattleInfo.MapName);
        List<TaskObjData> tasks = levelTemp.GetTaskObjDatas();
        TaskObjData task = tasks.Find(s => s.GetTaskDifficulty() == BattleInfo.TaskDifficulty && s.GetMapSize() == BattleInfo.MapSize);
        if (task == null)
        {
            Debug.Log("没有任务数据");
            {
                //测试-勋章带回城镇
                MedalObjData medal = DataManager.Instance.CreateMedal(Random.Range(1, 7));
                AddMedalDataToTaskPrizeBox(medal, 1);
                DataManager.Instance.AddMedalToMode(medal);
            }
            return;
        }
        ///key = id,value = count
        Dictionary<int, int> Result = new Dictionary<int, int>();

        //资源
        // int resourcesMinCount, resourcesMaxCount = 0;
        // task.GetResourceCount(out resourcesMinCount, out resourcesMaxCount);
        // int resiurcesCount = Random.Range(resourcesMinCount, resourcesMaxCount + 1);
        // List<int> resourcesIds = taskRewardResource.resourceIds;
        List<Resource> resourcesIds = task.GetResourcesId();
        
        for (int i = 0; i < resourcesIds.Count; ++i) {
            Resource resource = resourcesIds[i];
            int idTemp = resource.id;
            if (!Result.ContainsKey(idTemp)) Result.Add(idTemp, 0);
            Result[idTemp] += resource.count;
            if (idTemp == 7001)  ChangeResource(resource.count);
            else if (idTemp == 7002)  ChangeResource(0,resource.count);
            else if (idTemp == 7003) ChangeResource(0,0, resource.count);
            else if (idTemp == 7004) ChangeResource(0,0,0, resource.count);
            else if (idTemp == 7005) ChangeResource(0,0,0,0, resource.count);
            else if (idTemp == 7006) ChangeResource(0,0,0,0,0,resource.count);
        }
        //饰品
        List<OrnamentReward> ornamentRewardList = task.GetOrnamentDrops();
        OrnamentReward ornamentReward = DataManager.Instance.GetRandomByProbability(ornamentRewardList, ornamentRewardList.Select(s => s.probability).ToList());
        List<ObjData> ornamentList = new List<ObjData>();
        foreach (var item in objDataDict) {
            if (item.Value.objType == ObjType.饰品 && item.Value.levelType == ornamentReward.level) ornamentList.Add(item.Value);
        }
    
        for (int i = 0; i < ornamentReward.count; ++i)
        {
           ObjData idTemp = ornamentList[Random.Range(0, ornamentList.Count)];
            if (!Result.ContainsKey(idTemp.id)) Result.Add(idTemp.id, 0);
            Result[idTemp.id] += 1;
            DataManager.Instance.AddOrnamentToMode(idTemp);
        }
        ///鳞甲，资源，饰品显示
        foreach (var item in Result)  AddObjDataToTaskPrizeBox(item.Key, item.Value);
        
        //勋章
        List<MedalReward> medalRewardList = task.GetMedalDrops();
        MedalReward medalReward = DataManager.Instance.GetRandomByProbability(medalRewardList, medalRewardList.Select(s => s.probability).ToList());
        Dictionary<MedalObjData, int> medalResult = new Dictionary<MedalObjData, int>();

        for (int i = 0; i < medalReward.count; ++i)
        {
            MedalObjData medal = DataManager.Instance.CreateMedal(medalReward.level);
            if (!medalResult.ContainsKey(medal)) medalResult.Add(medal, 0);
            medalResult[medal] += 1;
            //勋章带回城镇
            DataManager.Instance.AddMedalToMode(medal);
        }
        //勋章显示
         foreach (var item in medalResult) AddMedalDataToTaskPrizeBox(item.Key,item.Value);
        //警戒值
        levelTemp.UpdateWarningValue( task.GetWarningValueAdd());
        
        // 击杀boss记录
        if(task.GetTaskType() == N_TaskType.固定boss)
            levelTemp.UpdateKillBoss(true);
#endif

    }
    /// <summary>
    /// 增减资源
    /// </summary>
    /// <param name="money">鳞片</param>
    /// <param name="crystal">影晶</param>
    /// <param name="fruit">虫果</param>
    /// <param name="lightStone">耀石</param>
    /// <param name="starFire">星火</param>
    /// <param name="bone">亡骨</param>
    public void ChangeResource(int money = 0, int crystal = 0, int fruit = 0, int lightStone = 0, int starFire = 0, int bone = 0)
    {
        if (money < 0) AudioManager.Instance.PlayAudio(AudioName.COINS_Rattle_01_mono, AudioType.Common);

        modeData.moneyMode.count += money;
        modeData.crystalMode.count += crystal;
        modeData.fruitMode.count += fruit;
        modeData.lightStoneMode.count += lightStone;
        modeData.starFireMode.count += starFire;
        modeData.boneMode.count += bone;
    }
    void AddObjDataToTaskPrizeBox(int _iD, int count)
    {
        if (taskPrizeBox.Count <= 0)
        {
            for (int i = 0; i < taskPrizeBoxTransf.childCount; ++i)
                taskPrizeBox.Add(taskPrizeBoxTransf.GetChild(i));
            taskPrizeBoxIndex = 0;
        }

        if (!objDataDict.ContainsKey(_iD)) throw new System.Exception($"ID {_iD} 不存在 ");
        taskPrizeBox[taskPrizeBoxIndex].gameObject.SetActive(true);
        ObjData objData = objDataDict[_iD];
        GameObject go = Instantiate(objItem, taskPrizeBox[taskPrizeBoxIndex]);
        ObjItem _obj = go.GetComponent<ObjItem>();
        _obj.InitItem(objData, count, taskPrizeBox[taskPrizeBoxIndex]);
        taskPrizeBoxIndex++;

    }
    void AddMedalDataToTaskPrizeBox(MedalObjData data, int count)
    {
        if (taskPrizeBox.Count <= 0)
        {
            for (int i = 0; i < taskPrizeBoxTransf.childCount; ++i)
                taskPrizeBox.Add(taskPrizeBoxTransf.GetChild(i));
            taskPrizeBoxIndex = 0;
        }
        taskPrizeBox[taskPrizeBoxIndex].gameObject.SetActive(true);
        GameObject go = Instantiate(objItem, taskPrizeBox[taskPrizeBoxIndex]);
        ObjItem _obj = go.GetComponent<ObjItem>();
        _obj.mePos_box = taskPrizeBox[taskPrizeBoxIndex];
        _obj.count = count;
        _obj.countT.text = count.ToString();
        data.GetIcon().LoadAssetAsync<Sprite>().Completed += s =>
       {
           _obj.icon.sprite = s.Result;
       };
        taskPrizeBoxIndex++;
    }
    #endregion
    #region 战利品
    public Transform spoilsBox;
    void SetSpoils() {
        int count = spoilsBox.childCount;
        Transform[] items = new Transform[count];
        for (int i = 0; i < count; ++i)
        {
            items[i] = spoilsBox.GetChild(i);
        }  
        ///饰品,圣物 带回城镇
        List<ObjData>   objDatas = DataManager.Instance.GetKanpsackData().FindAll(s => s.objType == ObjType.饰品 || s.objType == ObjType.圣物);

        for (int i = 0; i < Mathf.Min(objDatas.Count, items.Length); ++i)
        {
            items[i].gameObject.SetActive(true);
            GameObject go = Instantiate(objItem, items[i]);
            ObjItem obj = go.GetComponent<ObjItem>();
            obj.InitItem(objDatas[i], objDatas[i].Count, items[i]);
        }
        SaveTreasureToTown(objDatas);
    }
    
    /// <summary>
       /// 物品带回城镇
       /// </summary>
    void SaveTreasureToTown(List<ObjData> data)
    {
        for (int i = 0; i < data.Count; ++i)
        {
            switch (data[i].objType)
            {
                case ObjType.饰品: DataManager.Instance.AddOrnamentToMode(data[i]); break;
                case ObjType.圣物: DataManager.Instance.AddSacredToMode(new SacredObjData(new SacredMode() { id = data[i].id, isBePut = false, num = -1 }, data[i] as SacredData)); break;
            }
        }
    }

    #endregion
    #region 收藏的宝物
    public Transform treasureBox;
    public Text countText;
    /// <summary>
    /// 收集的宝物 - 消耗品、宝物、鳞片 均换算为鳞片
    /// </summary>
    void SetTreasure()
    {
#if LCC_CONVERT_TO_MONEY
        int count = treasureBox.childCount;
        Transform[] items = new Transform[count];
        for (int i = 0; i < count; ++i)
        {
            items[i] = treasureBox.GetChild(i);
        }

        List<ObjData> objDatas = DataManager.Instance.GetKanpsackData().FindAll(s => s.levelType == LevelType.消耗品 || s.objType == ObjType.饰品);
        int sum = 0;
        for (int i = 0; i < Mathf.Min(objDatas.Count, items.Length); ++i)
        {
            items[i].gameObject.SetActive(true);
            GameObject go = Instantiate(objItem, items[i]);
            ObjItem obj = go.GetComponent<ObjItem>();
            obj.InitItem(objDatas[i], objDatas[i].Count, items[i]);

            sum += objDatas[i].settlement * objDatas[i].Count;
        }
        countText.text = sum.ToString();

       modeData.moneyMode.count += sum;
#elif LCC_SAVE_TO_TOWN
        int count = treasureBox.childCount;
        Transform[] items = new Transform[count];
        for (int i = 0; i < count; ++i)
        {
            items[i] = treasureBox.GetChild(i);
        }
        ///消耗品直接转换成money
        List<ObjData> objDatas = DataManager.Instance.GetKanpsackData().FindAll(s => s.objType == ObjType.宝物 || s.levelType == LevelType.消耗品 || (s.levelType == LevelType.消耗品 && s.objType == ObjType.物品 && s.ownerType == OwnerType.交互));
        int sum = 0;
        for (int i = 0; i < Mathf.Min(objDatas.Count, items.Length); ++i)
        {
            Debug.Log(objDatas[i].name);
            items[i].gameObject.SetActive(true);
            GameObject go = Instantiate(objItem, items[i]);
            ObjItem obj = go.GetComponent<ObjItem>();
            obj.InitItem(objDatas[i], objDatas[i].Count, items[i]);
            sum += objDatas[i].settlement * objDatas[i].Count;
        }
        countText.text = sum.ToString();
        modeData.moneyMode.count += sum;
#endif
    }
  
    #endregion
    #region 角色的信息
    List<ObjLifeData> Heros;
    public Transform roleInfoBox;
    public GameObject roleItem_2;
    /// <summary>
    /// 角色阵亡数据
    /// </summary>
    /// <param name="isFlee"></param>
    void SetRoleInfo(bool isFlee)
    {
        //foreach (var item in HerosTeamController.Instance.roleTeam)
        //{
        //    if (isFlee)
        //    {
        //        item.objLife.UpdateInjuries(20);
        //        if (item.objLife.GetInjuries() > item.objLife.GetMaxInjuries())
        //        {
        //            item.objLife.SetInjuries(item.objLife.GetMaxInjuries());
        //        }
        //        item.objLife.UpdateMorale(-20);
        //        if (item.objLife.GetMorale() < item.objLife.GetMinMorale())
        //        {
        //            item.objLife.SetMorale(item.objLife.GetMinMorale());
        //        }
        //    }

        //    GameObject go = Instantiate(roleItem_s, roleInfoBox);//如何对应他们的存档呢
        //    RoleItem_S roleItem_S = go.GetComponent<RoleItem_S>();
        //    roleItem_S.InitRoleItem_S(item.objLife);
        //}

        foreach (var item in Heros)
        {
            if (isFlee)
            {
                //item.UpdateInjuries(20);
                //if (item.GetInjuries() > item.GetMaxInjuries())
                //{
                //    item.SetInjuries(item.GetMaxInjuries());
                //}
                if (!item.ExistsPermanentBuff(ObjBuffType.逃离副本不损失士气)) item.UpdateMorale(-20);
                //if (item.GetMorale() < item.GetMinMorale())
                //{
                //    item.SetMorale(item.GetMinMorale());
                //}
            }
            GameObject go = Instantiate(roleItem_2, roleInfoBox);//如何对应他们的存档呢
            RoleItem_2 roleItem_two = go.GetComponent<RoleItem_2>();
            roleItem_two.InitRoleItem_2(item);
        }
    }
    /// <summary>
    /// 所有英雄阵亡
    /// </summary>
    public void HeroAllDath()
    {
        /// <summary>
        /// tipsName.text = "任务失败";
        /// </summary>
        //要获得奖励吗?
        // if (!isPopUpFlag)
        // {
        //     isPopUpFlag = true;
        //     return;
        // }
        PopUp();// gameObject.SetActive(true);
    }
    #endregion
    #region 收藏的资源
    public Transform resourceBox;

    /// <summary>
    /// 鳞片
    /// </summary>
    public Text text_money;
    /// <summary>
    /// 影晶
    /// </summary>
    public Text text_crystal;
    /// <summary>
    /// 虫果
    /// </summary>
    public Text text_fruit;
    /// <summary>
    /// lightStone
    /// </summary>
    public Text text_lightStone;
    /// <summary>
    /// starFire
    /// </summary>
    public Text text_starFire;
    /// <summary>
    /// bone
    /// </summary>
    public Text text_bone;
    /// <summary>
    /// 获得的资源
    /// </summary>
    void SetResource()
    {
        int count = resourceBox.childCount;
        Transform[] items = new Transform[count];
        for (int i = 0; i < count; ++i)
        {
            items[i] = resourceBox.GetChild(i);
        }

        List<ObjData> objDatas = DataManager.Instance.GetKanpsackData().FindAll(s => s.levelType == LevelType.资源);
        for (int i = 0; i < Mathf.Min(objDatas.Count, items.Length); ++i)
        {
            items[i].gameObject.SetActive(true);
            GameObject go = Instantiate(objItem, items[i]);
            ObjItem obj = go.GetComponent<ObjItem>();
            obj.InitItem(objDatas[i], objDatas[i].Count, items[i]);
        }

        int i_money = objDatas.Where(s => s.id == 7001).Sum(s => s.Count);
        int i_crystal = objDatas.Where(s => s.id == 7002).Sum(s => s.Count);
        int i_fruit = objDatas.Where(s => s.id == 7003).Sum(s => s.Count);
        int i_lightStone = objDatas.Where(s => s.id == 7004).Sum(s => s.Count);
        int i_starFire = objDatas.Where(s => s.id == 7005).Sum(s => s.Count);
        int i_bone = objDatas.Where(s => s.id == 7006).Sum(s => s.Count);

         // text_money.text = i_money.ToString();
         text_crystal.text = i_crystal.ToString();
         text_fruit.text = i_fruit.ToString();
         text_lightStone.text = i_lightStone.ToString();
         text_starFire.text = i_starFire.ToString();
         text_bone.text = i_bone.ToString();

        modeData.moneyMode.count += i_money;
        modeData.crystalMode.count += i_crystal;
        modeData.fruitMode.count += i_fruit;
        modeData.lightStoneMode.count += i_lightStone;
        modeData.starFireMode.count += i_starFire;
        modeData.boneMode.count += i_bone;
    }

    #endregion
    #region 设置任务名称
    /// <summary>
    /// 任务名称
    /// </summary>
    public Text taskName;

    void SetTaskName(string name)
    {

        taskName.text = name;
    }
    #endregion


}
