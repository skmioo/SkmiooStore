using Datas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System;
using System.Threading;
using LitJson;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
using static LanguageController;
using UnityEngine.Events;

/// <summary>
/// 所有取值写在...中暂停延时3秒启动等待加载数据，因测试时未加载场景，故未提前加载数据
/// </summary>
public class DataManager : MonoSingleton<DataManager>
{
	protected override bool global => true;
	//语言包类数据
	public static DataSet dataSet;
    //常量（排除语言的）包类数据
    public static DataSet constDataSet;

    //独立UI面板数据,因为开始界面会用到,放到总集中会影响加载速度
    public static UIPanelDataSet uIPanelDataSet;
    //public ModeDataSet _modeData { get; set; }外部对单例非静态字段/属性赋值均为空,2012.12.14测试
    public static ModeDataSet modeDataSet;
    //读取的存档号码---  
    public static int modeIndex;
    public ModeData modeData
    {
        get {
            ModeData dataTemp = modeDataSet.modeDatas[modeIndex];
            //Debug.Log($"当前的存档 = {dataTemp.name}");
            return dataTemp; }
        private set { }//
    }

    Dictionary<string, DataSetItem> datasDicS = new Dictionary<string, DataSetItem>();
    Dictionary<int, DataSetItem> datasDicI = new Dictionary<int, DataSetItem>();

    Dictionary<string, DataSetItem> constDataDicS = new Dictionary<string, DataSetItem>();
    Dictionary<int, DataSetItem> constDataDicI = new Dictionary<int, DataSetItem>();

    Action<DataSetItem> loadOk;

    public void init()
    {
        Debug.Log("DataManager ------------");
        //调试阶段允许以挂载该脚本的方式加载数据,后期会将该类变为静态类
        if (dataSet == null)
        {
            Addressables.LoadAssetAsync<DataSet>("Data/Main/ZH_DataSet").Completed += EndLoad;

        }

        if (constDataSet == null)
        {
            Addressables.LoadAssetAsync<DataSet>("Data/Main/ConstDataSet").Completed += EndConstLoad;
        }

        if (modeDataSet == null)
        {
            Addressables.LoadAssetAsync<ModeDataSet>("Data/Main/ModeData").Completed += EndLoadModeData;
        }

        if (uIPanelDataSet == null)
        {
            Addressables.LoadAssetAsync<UIPanelDataSet>("Data/Main/UIPanelData").Completed += EndLoadUIpanelData;
        }
       // SpeculativeParseCSV_Language();
    }

    void SetContDic()
    {
        foreach (var item in constDataSet.scriptableObjects)
        {
            constDataDicS.Add(item.name, item);
            constDataDicI.Add(item.id, item);
        }
    }

    public DataSetItem GetConstData(string dataName)
    {

        if (constDataDicS.Count < 1)
        {
            SetContDic();
        }

        if (!constDataDicS.ContainsKey(dataName))
        {
            Debug.Log($"你提供了一个错误的常量数据名称{dataName}");
            return null;
        }
        return constDataDicS[dataName];
    }

    public DataSetItem GetConstData(int dataID)
    {
        if (constDataDicI.Count < 1)
            SetContDic();

        if (!constDataDicI.ContainsKey(dataID))
        {
            Debug.Log($"你提供了一个错误的常量数据ID{dataID}");
            return null;
        }

        return constDataDicI[dataID];
    }


    void SetDic()
    {
        foreach (var item in dataSet.scriptableObjects)
        {
            datasDicS.Add(item.name, item);
            datasDicI.Add(item.id, item);
        }
    }

    /// <summary>
    /// 通过名称取基础数据,测试阶段若未加载过场景,请在Start或Awker中使用Invoker（）中延时3秒调用
    /// 参考/Game/Test/TestLoadData.cs脚本
    /// </summary>
    /// <param name="dataName">数据的名称,对应Art/</param>
    /// <returns></returns>
    public DataSetItem GetData(string dataName)
    {
        if (datasDicS.Count < 1)
            SetDic();
        if (!datasDicS.ContainsKey(dataName))
        {
            Debug.Log($"提供的名称{dataName}不正确，请检查Main/ZH_DataSet中的值");
            return null;
        }

        return datasDicS[dataName];
    }

    /// <summary>
    /// 通过ID取基础数据,测试阶段若未加载过场景,请在Start或Awker中使用Invoker（）中延时3秒调用
    /// 参考/Game/Test/TestLoadData.cs脚本
    /// </summary>
    /// <param name="dataId">数据的ID</param>
    /// <returns></returns>
    public DataSetItem GetData(int dataId)
    {
        if (datasDicI.Count < 1)
            SetDic();

        if (!datasDicI.ContainsKey(dataId))
        {
            Debug.Log($"提供的Id{dataId}不正确，请检查Main/ZH_DataSet中的值");
            return null;
        }

        return datasDicI[dataId];
    }

    /// <summary>
    /// 异步加载方法暂缓
    /// </summary>
    /// <param name="dataName"></param>
    /// <returns></returns>
    public DataManager GetDataAsync(string dataName)
    {
        return this;
    }



    /// <summary>
    /// 从外部插入\新增一个数据集
    /// </summary>
    public void AddSetItem(DataSetItem dataSetItem)
    {
        datasDicS.Add(dataSetItem.name, dataSetItem);
        datasDicI.Add(dataSetItem.id, dataSetItem);
    }

    //测试阶段使用该方式加载,后期会在场景加载前加载数据,同时加载不同的语言包
    private void EndLoad(AsyncOperationHandle<DataSet> obj)
    {
        switch (obj.Status)
        {
            case AsyncOperationStatus.None:
                break;
            case AsyncOperationStatus.Succeeded:
                dataSet = obj.Result;
                break;
            case AsyncOperationStatus.Failed:
                Debug.Log("基础数据加载失败");
                break;
            default:
                break;
        }
    }


    private void EndConstLoad(AsyncOperationHandle<DataSet> obj)
    {
        switch (obj.Status)
        {
            case AsyncOperationStatus.None:
                break;
            case AsyncOperationStatus.Succeeded:
                constDataSet = obj.Result;
                break;
            case AsyncOperationStatus.Failed:
                Debug.Log("基础数据加载失败");
                break;
            default:
                break;
        }
    }

    private void EndLoadModeData(AsyncOperationHandle<ModeDataSet> obj)
    {
        switch (obj.Status)
        {
            case AsyncOperationStatus.None:
                break;
            case AsyncOperationStatus.Succeeded:
                modeDataSet = obj.Result;
				//TODO:由于数据还处于改动状态，故关停读取
				//if (!GetModeDataSet("quitData"))
				//	GetModeDataSet();
				break;
            case AsyncOperationStatus.Failed:
                break;
            default:
                break;
        }
    }

    private void EndLoadUIpanelData(AsyncOperationHandle<UIPanelDataSet> obj)
    {
        switch (obj.Status)
        {
            case AsyncOperationStatus.None:
                Debug.LogError("没有找到Data/Main/UIPanelData数据");
                break;
            case AsyncOperationStatus.Succeeded:
                uIPanelDataSet = obj.Result;
                break;
            case AsyncOperationStatus.Failed:
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 写本地文件
    /// </summary>
    /// <param name="obj"></param>
    public void SetJson(object obj)
    {
        string json = JsonMapper.ToJson(obj);
        //Application.persistentDataPath 目录文件会存在
        //C: \Users\用户名\AppData\LocalLow\DefaultCompany\dark\originProjectSave
        //找不到留意看debug,注意显示隐藏文件夹

        //系统盘路径
        //string tempPath = Application.persistentDataPath;
        //程序目录路径
        string tempPath = Application.dataPath;

        //编辑器先创建在Resources目录下
        FileInfo file = null;
        //if (Application.platform == RuntimePlatform.WindowsEditor)
        //    file = new FileInfo(Application.dataPath + "/Game/Resources/json/" + "ModeData1.json");
        //else
        {
            if (!Directory.Exists(tempPath + "/originProjectSave"))
                Directory.CreateDirectory(tempPath + "/originProjectSave");

            if (Application.platform == RuntimePlatform.WindowsPlayer)
            {
                file = new FileInfo(tempPath + "/originProjectSave/" + "ModeData1.json");
            }
            else
            {
                file = new FileInfo(tempPath + "/originProjectSave/" + "ModeData1.json");
            }
        }

        StreamWriter sw = file.CreateText();
        Regex reg = new Regex(@"(?i)\\[uU]([0-9a-f]{4})");
        json = reg.Replace(json, delegate (Match m) { return ((char)Convert.ToInt32(m.Groups[1].Value, 16)).ToString(); });
        sw.WriteLine(json);

        sw.Close();
        sw.Dispose();
    }

    /// <summary>
    /// 退出时写本地文件
    /// </summary>
    /// <param name="obj"></param>
    public void SetJson(object obj,string inFileName)
    {
        string json = JsonMapper.ToJson(obj);
        string tempPath = Application.dataPath + "/originProjectSave";
        string tempFileName = tempPath + "/" + inFileName;

        if (!Directory.Exists(tempPath))
            Directory.CreateDirectory(tempPath);

        Regex reg = new Regex(@"(?i)\\[uU]([0-9a-f]{4})");
        json = reg.Replace(json, delegate (Match m) { return ((char)Convert.ToInt32(m.Groups[1].Value, 16)).ToString(); });
        File.WriteAllText(tempFileName, json);
    }


    /// <summary>
    /// 用于加载本地存档
    /// 由于ModeDataSet目前还处于改动状态，故存档保存在目录下，随工程删除
    /// </summary>
    /// <returns></returns>
    public ModeDataSet GetModeDataSet()
    {
       
        //if (modeDataSet == null)
        {
            //系统盘路径
            //string tempPath = Application.persistentDataPath;
            //程序目录路径
            string tempPath = Application.dataPath;

            //if (Application.platform == RuntimePlatform.WindowsEditor)
            //    tempPath = Application.dataPath + "/Game/Resources/json/" + "ModeData1.json";
            //else
            {
                if (!Directory.Exists(tempPath + "/originProjectSave"))
                {
                    Debug.Log("加载失败，目录不存在");
                    return null;
                }

                if (Application.platform == RuntimePlatform.WindowsPlayer)
                {
                    tempPath = tempPath + "/originProjectSave/" + "ModeData1.json";
                    //Debug.Log("load WindowsPlayer");
                }
                else
                {
                    tempPath = tempPath + "/originProjectSave/" + "ModeData1.json";
                    //Debug.Log("load else");
                }
            }

            //判断文件是否存在
            if (File.Exists(tempPath))
            {
                string ft = File.ReadAllText(tempPath);
                ModeDataSet t = JsonMapper.ToObject<ModeDataSet>(ft);

                modeDataSet = t;
            }
            else { Debug.Log("文件不存在，停在读取"); return null; }
        }
        return modeDataSet;
    }

    /// <summary>
    /// 测试性加载强退存档
    /// </summary>
    /// <returns></returns>
    public bool GetModeDataSet(string inFileName)
    {
        
        string tempPath = Application.dataPath + "/originProjectSave";
        string tempFilePath = tempPath + "/" + inFileName;

        if (!Directory.Exists(tempPath))
        {
            Debug.Log("加载失败，目录不存在");
            return false;
        }


        //判断文件是否存在
        if (File.Exists(tempFilePath))
        {
            string ft = File.ReadAllText(tempFilePath);
            ModeDataSet t = JsonMapper.ToObject<ModeDataSet>(ft);

            modeDataSet = t;
        }
        else { Debug.Log("Not Quit File"); return false; }
        Debug.Log("Load Quit File");
        return true;
    }
    #region 技能相关

    /// <summary>
    /// 英雄技能，敌人技能
    /// </summary>
    private static Dictionary<int, SkillData> skillDic = new Dictionary<int, SkillData>();
    private void LoadSkillData()
    {
        if (skillDic.Count.Equals(0))
        {
            SkillDataSet skillDataSet = GetData("SkillData").scriptableObject as SkillDataSet;
            List<SkillData> skillDatas = skillDataSet.heroSkills;
            foreach (var sd in skillDatas)
            {
                if (skillDic.ContainsKey(sd.id))
                {
                    Debug.Log("技能id重复！");
                    continue;
                }
                skillDic.Add(sd.id, sd);
            }

            skillDatas = skillDataSet.enemySkills;
            foreach (var sd in skillDatas)
            {
                if (skillDic.ContainsKey(sd.id))
                {
                    Debug.Log("技能id重复！");
                    continue;
                }
                skillDic.Add(sd.id, sd);
            }
        }
    }

	SkillBuffTest skillBuffTest = new SkillBuffTest();
	/// <summary>
	/// 获取技能数据
	/// </summary>
	/// <param name="skillId"></param>
	/// <returns></returns>
	public SkillData GetSkillDataById(int skillId)
    {
        LoadSkillData();
        SkillData result = null;
        bool isHave = skillDic.TryGetValue(skillId, out result);
		if (skillBuffTest.IsTestBuff)
		{
			return skillBuffTest.GetSkillDataById(result);
		}
		return result;
    }

    /// <summary>
    /// 获取技能数据
    /// </summary>
    /// <param name="skillIds"></param>
    /// <returns></returns>
    public List<SkillData> GetSkillDatasByIds(List<int> skillIds)
    {
        List<SkillData> skillDatas = new List<SkillData>();
        foreach (var i in skillIds)
        {
            skillDatas.Add(GetSkillDataById(i));
        }
		if (skillBuffTest.IsTestBuff)
		{
			return skillBuffTest.GetSkillDatasByIds(skillDatas);
		}
		return skillDatas;
    }

    /// <summary>
    /// 获取当前被选择使用的技能数据（角色详情面板中选择使用）
    /// </summary>
    /// <param name="skillModes"></param>
    /// <returns></returns>
    public List<SkillData> GetSkillDatasWhereUse(List<SkillMode> skillModes)
    {
        if (skillModes == null) { return new List<SkillData>(); }
        List<int> ids = new List<int>();
        foreach (var sm in skillModes)
        {
            if (!sm.isUse) continue;
            ids.Add(sm.skillId);
        }
        return GetSkillDatasByIds(ids);
    }

    #endregion

    #region 士气技能相关

    private static Dictionary<int, OtherSkillData> moraleSkillDic = new Dictionary<int, OtherSkillData>();

    private void LoadMoraleSkill()
    {
        if (moraleSkillDic.Count == 0)
        {
            SkillDataSet skillDataSet = GetData("SkillData").scriptableObject as SkillDataSet;
            List<OtherSkillData> skillDatas = skillDataSet.otherSkills;
            foreach (var item in skillDatas)
            {
                moraleSkillDic.Add(item.id, item);
            }
        }
    }

    public OtherSkillData GetMoraleSkillById(int id)
    {
        LoadMoraleSkill();
        if (moraleSkillDic.ContainsKey(id))
        {
            return moraleSkillDic[id];
        }
        else
        {
            return null;
        }
    }

    #endregion
    #region 士气技能异化 - 异化词条表数据
    private static Dictionary<int, AlienatedEntryData> moraleSkillEntryDic = new Dictionary<int, AlienatedEntryData>();

    private void LoadSkillEntry()
    {
        if (moraleSkillEntryDic.Count == 0)
        {
            SkillDataSet skillDataSet = GetData("SkillData").scriptableObject as SkillDataSet;
            List<AlienatedEntryData> skillDatas = skillDataSet.entryDatas;

            foreach (var item in skillDatas)
            {
                moraleSkillEntryDic.Add(item.id, item);
            }
        }
    }
    public List<AlienatedEntryData> GetEntryDataById(params int[] _ids) {
        LoadSkillEntry();
        List<AlienatedEntryData> result = new List<AlienatedEntryData>();
        AlienatedEntryData temp = null;

        for (int i = 0; i < _ids.Length; ++i)
        {
            moraleSkillEntryDic.TryGetValue(_ids[i], out temp);
            if (temp == null) continue;
            result.Add(temp);
        }
        return result;
    }
    /// <summary>
    /// 根据id 获取异化词条
    /// </summary>
    /// <param name="_id"></param>
    /// <returns></returns>
    public AlienatedEntryData GetEntryDataById(int _id)
    {
        LoadSkillEntry();
        AlienatedEntryData temp = null;
        moraleSkillEntryDic.TryGetValue(_id, out temp);
        return temp;
    }
    #endregion 
    #region 角色相关

    private static Dictionary<int, ObjLifeData> objLifeDataDic = new Dictionary<int, ObjLifeData>();

    /// <summary>
    /// 通过角色id获取角色数据
    /// </summary>
    /// <param name="roleId"></param>
    /// <returns></returns>
    public ObjLifeData GetObjLifeDataById(int roleId)
    {
        if (objLifeDataDic.Count.Equals(0))
        {
            RoleDataSet roleDataSet = GetData("RoleData").scriptableObject as RoleDataSet;

            List<RoleData> enemyDatas = roleDataSet.enemyData;
            AddRoleDataToDic(enemyDatas);

            List<RoleData> herosDatas = roleDataSet.heroData;
            AddRoleDataToDic(herosDatas);
        }

        return objLifeDataDic[roleId].Clone();
    }

    private void AddRoleDataToDic(List<RoleData> roleDatas)
    {
        foreach (var rd in roleDatas)
        {
            if (objLifeDataDic.ContainsKey(rd.id))
            {
                Debug.Log("角色id重复！");
                continue;
            }

            List<SkillMode> skillModes = new List<SkillMode>();
            foreach (var item in rd.roleHaveSkill)
            {
                skillModes.Add(new SkillMode()
                {
                    skillId = item,
                    level = 1,
                    isUse = false
                });
            }
            HeroMode heroMode = new HeroMode
            {
                heroName = rd.vocation.ToString(),
                readyStart = false,
                numInTeam_Waiting = 0,
                isHealing = false,
                healBoxIndex = 0,
                heroId = rd.id,
                injuries = 0,
                skillModes = skillModes,
                medal = new MedalMode(),
                ornaments1ID = 0,
                ornaments2ID = 0
            };
            objLifeDataDic.Add(rd.id, new ObjLifeData(rd.hp, 50, heroMode, rd));
        }
    }

    /// <summary>
    /// 通过角色id获取角色数据
    /// </summary>
    /// <param name="roleIds"></param>
    /// <returns></returns>
    public List<ObjLifeData> GetObjLifeDatasByIds(List<int> roleIds)
    {
        List<ObjLifeData> objLifeDatas = new List<ObjLifeData>();
        foreach (var i in roleIds)
        {
            objLifeDatas.Add(GetObjLifeDataById(i));
        }
        return objLifeDatas;
    }

    /// <summary>
    /// 根据难度获取怪物数据
    /// </summary>
    /// <param name="roleIds"></param>
    /// <param name="taskDifficulty"></param>
    /// <returns></returns>
    public List<ObjLifeData> GetMonsterSeniorDatas(List<int> roleIds, TaskDifficulty taskDifficulty)
    {
        var dataSet = GetData("RoleData").scriptableObject as RoleDataSet;
        var datas = dataSet.enemySeniorData;
        var result = GetObjLifeDatasByIds(roleIds);
        foreach (var obj in result)
        {
            var data = datas.Find(s => s.roleData.id == obj.GetId() && s.taskDifficulty == taskDifficulty);
            if (data == null) { Debug.Log("怪物数据错误"); return null; }
            obj.ImportSeniorData(data.roleData);
        }
        return result;
    }

    /// <summary>
    /// 随机获取几个不重复的英雄角色id
    /// </summary>
    /// <param name="count"></param>
    /// <returns></returns>
    public List<int> GetHeroIdRandom(int count)
    {
        //解救事件-猎头
        if (TownInfo.ExistsRescueType(RescueType.猎头)) {
            count *= 2;
        }
        RoleDataSet roleDataSet = GetData("RoleData").scriptableObject as RoleDataSet;
        List<RoleData> heroDatas = roleDataSet.heroData;

        List<int> result = heroDatas.Select(s => s.id).ToList();
        for (int i = 0; i < heroDatas.Count - count; ++i)
        {
            int roll = UnityEngine.Random.Range(0, result.Count);
            result.RemoveAt(roll);
        }

        return result;
    }

    /// <summary>
    /// 获取英雄存档数据
    /// </summary>
    /// <returns></returns>
    public List<ObjLifeData> GetHeroModeData()
    {
        List<HeroMode> heroModes = modeData.herosModes;

        List<ObjLifeData> objLifeDatas = GetObjLifeDatasByIds(heroModes.Select(s => s.heroId).ToList());
        for (int i = 0; i < heroModes.Count; ++i)
        {
            objLifeDatas[i].SetHeroMode(heroModes[i]);
        }

        return objLifeDatas;
    }

    /// <summary>
    /// 添加英雄到存档
    /// </summary>
    /// <param name="objLifeData"></param>
    public void AddHeroToMode(ObjLifeData objLifeData)
    {
        modeData.herosModes.Add(objLifeData.GetHeroMode());
    }

    /// <summary>
    /// 从存档中移除英雄
    /// </summary>
    /// <param name="objLifeData"></param>
    public void RemoveHeroFromMode(ObjLifeData objLifeData)
    {
        modeData.herosModes.Remove(objLifeData.GetHeroMode());
    }

    #endregion

    #region 饰品相关

    private static Dictionary<int, ObjData> ornamentDic = new Dictionary<int, ObjData>();

    private void LoadOrnamentData()
    {
        if (ornamentDic.Count == 0)
        {
            ObjDataSet objDataSet = GetData("ObjData").scriptableObject as ObjDataSet;
            List<ObjData> objDatas = objDataSet.ornamentsDatas;
            foreach (var obj in objDatas)
            {
                ornamentDic.Add(obj.id, obj);
            }
        }
    }

    /// <summary>
    /// 随机生成一个饰品（目前仅有污浊的眼罩）
    /// </summary>
    /// <returns></returns>
    public ObjData CreateOrnamentData()
    {
        LoadOrnamentData();
        return GetOrnamentDataById(UnityEngine.Random.Range(4001, 4029));
    }

    public ObjData CreateOrnamentData(LevelType levelType)
    {
        LoadOrnamentData();
        List<ObjData> objDatas = ornamentDic.Values.Where(s => s.levelType == levelType).ToList();
        return objDatas[UnityEngine.Random.Range(0, objDatas.Count)];
    }

    /// <summary>
    /// 获取饰品属性
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public ObjData GetOrnamentDataById(int id)
    {
        LoadOrnamentData();
        return ornamentDic.ContainsKey(id) ? ornamentDic[id].Clone() : null;
    }

    /// <summary>
    /// 获取饰品属性
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    public List<ObjData> GetOrnamentDatasByIds(List<int> ids)
    {
        LoadOrnamentData();
        List<ObjData> objDatas = new List<ObjData>();
        foreach (var id in ids)
        {
            ObjData obj = GetOrnamentDataById(id);
            if (obj != null)
            {
                objDatas.Add(obj);
            }
        }

        return objDatas;
    }

    /// <summary>
    /// 从背包存档中读取饰品数据
    /// </summary>
    /// <returns></returns>
    public List<ObjData> GetOrnamentDatasFromMode()
    {
        LoadOrnamentData();
        List<int> ids = modeData.ornamentsModes.Where(s => s.count > 0).Select(s => s.objId).ToList();
        return GetOrnamentDatasByIds(ids);
    }

    public ObjData GetOrnamentDatasFromMode(int inIndex)
    {
        LoadOrnamentData();
        List<int> ids = modeData.ornamentsModes.Where(s => s.count > 0).Select(s => s.objId).ToList();
        return GetOrnamentDataById(ids[inIndex]);
    }

    /// <summary>
    /// 添加饰品到背包存档
    /// </summary>
    /// <param name="id"></param>
    public void AddOrnamentToMode(ObjData objData)
    {
        List<KanpsackMode> ornaments = modeData.ornamentsModes;
        for (int i = 0; i < ornaments.Count; ++i)
        {
            if (ornaments[i].count == 0)
            {
                ornaments[i].objId = objData.id;
                ornaments[i].count = 1;
                return;
            }
        }
        ornaments.Add(new KanpsackMode { objId = objData.id, count = 1 });
    }

    /// <summary>
    /// 从背包存档中移除饰品
    /// 这里，因为获取队列得时候不是实际ornamentsModes的index,你移除的时候很大几率就是错的
    /// </summary>
    /// <param name="index">饰品在背包中的索引</param>
    public void RemoveOrnamentFromMode(int index)
    {
        modeData.ornamentsModes[index].count = 0;
    }

    public void RemoveOrnamentFromMode2(int inID)
    {
        for (int i = 0; i < modeData.ornamentsModes.Count; i++)
            if (modeData.ornamentsModes[i].count > 0 && modeData.ornamentsModes[i].objId == inID)
            {
                modeData.ornamentsModes[i].count = 0;
                return;
            }
    }

    #endregion

    #region 勋章相关

    private static List<MedalAttribute> medalAttributes = new List<MedalAttribute>();
    private static List<MedalEntry> medalEntries = new List<MedalEntry>();
    private static Dictionary<int, MedalData> medalDataDic = new Dictionary<int, MedalData>();

    private void LoadMedalData()
    {
        if (medalDataDic.Count == 0)
        {
            MedalDataSet medalDataSet = GetData("MedalData").scriptableObject as MedalDataSet;
            foreach (var item in medalDataSet.medalDatas)
            {
                medalDataDic.Add(item.id, item);
            }
        }
    }

    /// <summary>
    /// 获取勋章数据，一般不用
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public MedalData GetMedalDataById(int id)
    {
        LoadMedalData();
        if (medalDataDic.ContainsKey(id))
        {
            return medalDataDic[id];
        }
        else
        {
            Debug.Log($"没有这个 id= {id} 的勋章");
            return null;
        }
    }

    /// <summary>
    /// 获取勋章对象数据
    /// </summary>
    /// <param name="medalMode"></param>
    /// <returns></returns>
    public MedalObjData GetMedalByMode(MedalMode medalMode)
    {
        LoadMedalData();
        return new MedalObjData(GetMedalDataById(medalMode.objId), medalMode, GetMedalAttribute(medalMode), GetMedalEntry(medalMode));
    }

    /// <summary>
    /// 生成一个勋章
    /// </summary>
    /// <param name="levelType"></param>
    /// <returns></returns>
    public MedalObjData CreateMedal(int level)
    {
        LoadMedalData();
        List<MedalData> medalDatas = medalDataDic.Values.ToList().FindAll(s => s.level == level);
        if (medalDatas != null && medalDatas.Count > 0)
        {
            MedalData medalData = medalDatas[UnityEngine.Random.Range(0, medalDatas.Count)];

            List<int> attributeRoll = new List<int>();
            for (int i = 0; i < medalData.attributeRollCount; ++i)
            {
                attributeRoll.Add(UnityEngine.Random.Range(0, 101));
            }

            List<int> entryRoll = new List<int>();
            if (medalData.entryRollRange != null && medalData.entryRollRange.Count > 0)
                for (int i = 0; i < medalData.entryRollCount; ++i)
                {
                    entryRoll.Add(medalData.entryRollRange[UnityEngine.Random.Range(0, medalData.entryRollRange.Count)]);
                }

            MedalMode medalMode = new MedalMode
            {
                objId = medalData.id,
                count = 1,
                attributeRoll = attributeRoll,
                entryRoll = entryRoll
            };
            return GetMedalByMode(medalMode);
        }
        else
        {
            Debug.Log("没有这个等级的勋章");
            return null;
        }
    }

    /// <summary>
    /// 获取勋章随机到的属性
    /// </summary>
    /// <param name="medalMode"></param>
    /// <returns></returns>
    public List<ObjPermanentBuff> GetMedalAttribute(MedalMode medalMode)
    {
        if (medalAttributes.Count == 0)
        {
            MedalDataSet medalDataSet = GetData("MedalData").scriptableObject as MedalDataSet;
            medalAttributes = medalDataSet.medalAttributes;
        }

        List<ObjPermanentBuff> result = new List<ObjPermanentBuff>();
        foreach (var attribute in medalAttributes)
        {
            if (attribute.initValue != 0)
            {
                result.Add(new ObjPermanentBuff(attribute.buffType, attribute.valueType, attribute.addValue, BuffSourceType.勋章));
            }
        }
        foreach (var roll in medalMode.attributeRoll)
        {
            foreach (var attribute in medalAttributes)
            {
                if (roll >= attribute.rollMin && roll <= attribute.rollMax)
                {
                    result.Add(new ObjPermanentBuff(attribute.buffType, attribute.valueType, attribute.addValue, BuffSourceType.勋章));
                }
            }
        }

        return result;
    }

    /// <summary>
    /// 获取勋章随机到的词条属性
    /// </summary>
    /// <param name="medalMode"></param>
    /// <returns></returns>
    public List<ObjPermanentBuff> GetMedalEntry(MedalMode medalMode)
    {
        if (medalEntries.Count == 0)
        {
            MedalDataSet medalDataSet = GetData("MedalData").scriptableObject as MedalDataSet;
            medalEntries = medalDataSet.medalEntries;
        }

        List<ObjPermanentBuff> result = new List<ObjPermanentBuff>();
        foreach (var roll in medalMode.entryRoll)
        {
            MedalEntry medalEntry = medalEntries.Find(s => s.id == roll);
            if (medalEntry == null)
            {
                Debug.Log("没有这个词条");
                return null;
            }

            foreach (var objAction in medalEntry.objActions)
            {
                result.Add(new ObjPermanentBuff(objAction, BuffSourceType.勋章));
            }
        }

        return result;
    }

    /// <summary>
    /// 从背包存档中读取勋章数据
    /// </summary>
    /// <returns></returns>
    public List<MedalObjData> GetMedalsFromMode()
    {
        List<MedalObjData> result = new List<MedalObjData>();
        foreach (var item in modeData.medalModes)
        {
            result.Add(GetMedalByMode(item));
        }
        return result;
    }

    public MedalObjData GetMedalsFromMode(int inIndex)
    {
        return GetMedalByMode(modeData.medalModes[inIndex]);
    }

    /// <summary>
    /// 添加勋章到背包存档
    /// </summary>
    /// <param name="medalMode"></param>
    public void AddMedalToMode(MedalObjData medal)
    {
        List<MedalMode> medals = modeData.medalModes;
        for (int i = 0; i < medals.Count; ++i)
        {
            if (medals[i].count == 0)
            {
                medals[i] = medal.GetMedalMode();
                return;
            }
        }
        medals.Add(medal.GetMedalMode());
    }


    /// <summary>
    /// 从背包存档中移除勋章
    /// </summary>
    /// <param name="medalMode"></param>
    public void RemoveMedalFromMode(MedalObjData medal)
    {
        modeData.medalModes.Remove(medal.GetMedalMode());
    }

    public void RemoveMedalFromMode(int index)
    {
        modeData.medalModes.RemoveAt(index);
    }

    #endregion

    #region 圣物相关
    /// <summary>
    /// 圣物数据 key = id
    /// </summary>
    private static Dictionary<int, SacredData> sacredDatas = new Dictionary<int, SacredData>();
    /// <summary>
    /// 圣物组合数据
    /// </summary>
    private static List<SacredCombination> sacredCombinations = new List<SacredCombination>();

    /// <summary>
    /// 生成一个圣物
    /// </summary>
    /// <returns></returns>
    public SacredObjData CreateSacredData()
    {
        LoadSacredDatas();
        return null;
    }

    /// <summary>
    /// 从存档中读取圣物数据
    /// </summary>
    /// <returns></returns>
    public List<SacredObjData> GetSacredFromMode()
    {
        LoadSacredDatas();
        List<SacredObjData> objDatas = new List<SacredObjData>();
        foreach (var sacred in modeData.sacredModes)
        {
            objDatas.Add(new SacredObjData(sacred, GetSacredDataById(sacred.id)));
        }
        return objDatas;
    }
    public void AddSacredToMode(SacredObjData _data) {
        //List<SacredMode> sacreds = modeData.sacredModes;
        modeData.sacredModes.Add(_data.GetSacredMode());
    }
    public void RemoveSacredFormMode(SacredObjData _data) {
        modeData.sacredModes.Remove(_data.GetSacredMode());
    }
    /// <summary>
    /// 获取圣物组合效果，如果该组合不存在则返回null
    /// </summary>
    /// <param name="group"></param>
    /// <returns></returns>
    public SacredCombination GetSacredObjAction(List<int> group)
    {
        LoadSacredDatas();
        if (group == null || group.Count == 0)
        {
            return null;
        }

        List<SacredCombination> combinations = sacredCombinations.FindAll(s => s.combinationIds.Count == group.Count);
        group.Sort();
        foreach (var combination in combinations)
        {
            combination.combinationIds.Sort();

            bool success = true;
            for (int i = 0; i < group.Count; ++i)
            {
                if (group[i] != combination.combinationIds[i])
                {
                    success = false;
                    break;
                }
            }
            if (success)
            {
                return combination;
            }
        }

        return null;
    }

    private SacredData GetSacredDataById(int id)
    {
        LoadSacredDatas();
        if (sacredDatas.ContainsKey(id))
        {
            return sacredDatas[id];
        }
        else
        {
            Debug.Log("圣物id不存在");
            return null;
        }
    }

    private void LoadSacredDatas()
    {
        if (sacredDatas.Count == 0)
        {
            SacredDataSet sacredDataSet = GetData("SacredData").scriptableObject as SacredDataSet;
            foreach (var sacred in sacredDataSet.sacredDatas)
            {
                sacredDatas.Add(sacred.id, sacred);
            }
            sacredCombinations = sacredDataSet.sacredCombinations;
        }
    }

    #endregion

    #region 道具相关
    /// <summary>
    /// 道具数据列表
    /// </summary>
    private static List<ObjData> propList = new List<ObjData>();
    /// <summary>
    /// 加载道具列表
    /// </summary>
    private void LoadPropList()
    {
        if (propList.Count == 0)
        {
            ObjDataSet objDataSet = GetData("ObjData").scriptableObject as ObjDataSet;
            propList = objDataSet.porpDatas;
        }
    }

    public ObjData GetObjData(int id)
    {
        LoadPropList();
        ObjData objData = propList.Find(s => s.id == id);
        if (objData != null)
            return objData.Clone();

        return null;
    }

    public ObjData GetObjData(string name)
    {
        LoadPropList();
        if (propList.Find(s => s.name == name) == null) { return null; }
        return propList.Find(s => s.name == name).Clone();
    }

    public List<ObjData> GetObjDatas()
    {
        LoadPropList();
        return propList;
    }

    public List<ObjData> GetKanpsackData()
    {
        LoadPropList();
        LoadOrnamentData();
        LoadSacredDatas();
        List<KanpsackMode> kanpsackModes = modeData.kanpsackModes;
        List<ObjData> result = new List<ObjData>();
        foreach (var item in kanpsackModes)
        {
            if (item.objId == 0) { continue; }
            ObjData objData = GetOrnamentDataById(item.objId);
            if (objData == null) { objData = GetObjData(item.objId); }
            if (objData == null) { objData = GetSacredDataById(item.objId); }
            if (objData == null) { Debug.Log("物品id错误" + item.objId); continue; }
            objData.Count = item.count;
            result.Add(objData);
        }
        return result;
    }

    #endregion
    #region 宝物掉落相关

    private static List<TreasureData> TreasureList = new List<TreasureData>();

    private void LoadTreasureList()
    {
        if (TreasureList.Count == 0)
        {
            ObjDataSet objDataSet = GetData("ObjData").scriptableObject as ObjDataSet;
            TreasureList = objDataSet.treasuresDatas;
        }
    }
    public TreasureData CreatRandomTreasure(MapNameType nameType)
    {
        LoadTreasureList();
        List<TreasureData> list = TreasureList.FindAll(s => s.ownerMapArea == nameType);
        if (list == null || list.Count <= 0) throw new Exception($"地图[ {nameType} ] 没有宝物数据，请检查宝物数据配置");
        return list[UnityEngine.Random.Range(0, list.Count)];
    }
    public TreasureData GetTreasureByName(string _name) {
        LoadTreasureList();
        TreasureData result = TreasureList.Find(s => s.name == _name);
        return result;
    }
    #endregion
    #region 怪物掉落相关

    public List<ObjData> GetMapDrop(MapNameType nameType, N_MiniMapRoomType roomType, TaskDifficulty taskDifficulty)
    {
        MapDataSet mapDataSet = GetData("MapData").scriptableObject as MapDataSet;

        var md = mapDataSet.mapDroppings.Find(s => s.nameType == nameType);
        if (md == null)
        {
            Debug.Log($"没找到地图掉落数据 {nameType} - {roomType} - {taskDifficulty}");
            return null;
        }
        var rd = md.roomDroppings.Find(s => s.roomType == roomType);
        if (rd == null)
        {
            Debug.Log($"没找到道路掉落数据 {nameType} - {roomType} - {taskDifficulty}");
            return null;
        }
        var mapDropping = rd.mapDroppings.Find(s => s.taskDifficulty == taskDifficulty);
        if (mapDropping == null)
        {
            Debug.Log($"没找到地图掉落数据 {nameType} - {roomType} - {taskDifficulty}");
            return null;
        }

        //MapDropping mapDropping = 
        //    mapDataSet.mapDroppings.Find(s => s.nameType == nameType).
        //    roomDroppings.Find(s => s.roomType == roomType).
        //    mapDroppings.Find(s => s.taskDifficulty == taskDifficulty);

        return GetMapDrop(mapDropping);
    }

    public List<ObjData> GetMapDrop(MapNameType nameType, N_MiniMapRouteType routeType, TaskDifficulty taskDifficulty)
    {
        MapDataSet mapDataSet = GetData("MapData").scriptableObject as MapDataSet;
        //MapDropping mapDropping = 
        //    mapDataSet.mapDroppings.Find(s => s.nameType == nameType).
        //    routeDroppings.Find(s => s.routeType == routeType).
        //    mapDroppings.Find(s => s.taskDifficulty == taskDifficulty);

        var mapDroppings = mapDataSet.mapDroppings.Find(s => s.nameType == nameType);
        if (mapDroppings == null)
        {
            Debug.Log($"没找到地图掉落数据 {nameType} - {routeType} - {taskDifficulty}");
            return null;
        }
        var routeDroppings = mapDroppings.routeDroppings.Find(s => s.routeType == routeType);
        if (routeDroppings == null)
        {
            Debug.Log($"没找到路线掉落数据 {nameType} - {routeType} - {taskDifficulty}");
            return null;
        }
        var droppings = routeDroppings.mapDroppings.Find(s => s.taskDifficulty == taskDifficulty);
        if (routeDroppings == null)
        {
            Debug.Log($"没找到掉落数据 {nameType} - {routeType} - {taskDifficulty}");
            return null;
        }
        return GetMapDrop(droppings);
    }

    private List<ObjData> GetMapDrop(MapDropping mapDropping)
    {
        var drops = mapDropping.CreateDrop();
        List<ObjData> result = new List<ObjData>();

        LevelType levelType = LevelType.普通;
        foreach (var drop in drops)
        {
            string dropKeyTemp = drop.Key;
            ObjType type = ObjType.物品;
            switch (dropKeyTemp)
            {
                case "鳞片":
                case "肉干":
                case "地锦草":
                case "影晶":
                case "虫果":
                case "耀石":
                case "星火":
                case "亡骨":
                    type = ObjType.物品;
                    break;
                case "蘑菇":
                    type = ObjType.物品;
                    dropKeyTemp = "低语蘑菇";
                    break;
                case "蛆虫唾液":
                    type = ObjType.物品;
                    dropKeyTemp = "食腐蛆虫的唾液";
                    break;
                case "通用":
                case "普通":
                    type = ObjType.饰品;
                    levelType = LevelType.普通;
                    break;
                case "精良":
                    type = ObjType.饰品;
                    levelType = LevelType.精良;
                    break;
                case "稀有":
                    type = ObjType.饰品;
                    levelType = LevelType.稀有;
                    break;
                case "起源":
                    type = ObjType.饰品;
                    levelType = LevelType.起源;
                    break;
                case "圣物":
                    type = ObjType.圣物;
                    break;
                case "萤石":
                    dropKeyTemp = "惨白萤石";
                    type = ObjType.宝物;
                    break;
                case "石板":
                    dropKeyTemp = "苦痛石板";
                    type = ObjType.宝物;
                    break;
                case "孤本":
                    dropKeyTemp = "圣经孤本";
                    type = ObjType.宝物;
                    break;
                case "黯晶":
                    dropKeyTemp = "黯影结晶";
                    type = ObjType.宝物;
                    break;
                case "宝钻":
                    dropKeyTemp = "冥河宝钻";
                    type = ObjType.宝物;
                    break;
                case "刚玉":
                    dropKeyTemp = "寒潭刚玉";
                    type = ObjType.宝物;
                    break;
            }
            ObjData objData = null;

            switch (type)
            {
                case ObjType.物品:
                    objData = GetObjData(dropKeyTemp);
                    if (objData == null) Debug.Log("测试：" + drop.Key);
                    break;
                case ObjType.饰品:
                    objData = CreateOrnamentData(levelType);
                    break;
                case ObjType.圣物:
                    ///未完善

                    break;
                case ObjType.宝物:
                    objData = GetTreasureByName(dropKeyTemp);
                    break;
            }

            if (objData == null) continue;//  throw new Exception("is NULL");
            objData.Count = drop.Value;
            result.Add(objData);
        }
        return result;
    }

    #endregion

    #region 天赋相关

    /// <summary>
    /// 生成天赋存档数据
    /// </summary>
    /// <returns></returns>
    public TalentMode CreateTalentMode()
    {
        var data = LoadTalentGroupData();
        var group = data[UnityEngine.Random.Range(0, data.Count)];
        return new TalentMode()
        {
            typeId = group.id,
            triggerId = group.trigger[UnityEngine.Random.Range(0, group.trigger.Count)].id,
            orderId = group.orderEffect[UnityEngine.Random.Range(0, group.orderEffect.Count)].id,
            chaosId = group.chaosEffect[UnityEngine.Random.Range(0, group.chaosEffect.Count)].id
        };
    }

    /// <summary>
    /// 获取天赋数据
    /// </summary>
    /// <param name="talentMode"></param>
    /// <returns></returns>
    public TalentData GetTalentData(TalentMode talentMode)
    {
        if (talentMode == null) { return null; }
        return new TalentData()
        {
            TypeId = talentMode.typeId,
            Trigger = GetTalentTrigger(talentMode.typeId, talentMode.triggerId),
            Order = GetTalentOrderEffect(talentMode.typeId, talentMode.orderId),
            Chaos = GetTalentChaosEffect(talentMode.typeId, talentMode.chaosId)
        };
    }

    private List<TalentGroup> LoadTalentGroupData()
    {
        TalentDataSet talentDataSet = GetData("TalentData").scriptableObject as TalentDataSet;
        return talentDataSet.talentGroups;
    }

    private TalentTrigger GetTalentTrigger(int typeId, int triggerId)
    {
        var data = LoadTalentGroupData();
        var tg = data.Find(s => s.id == typeId);
        if (tg == null) { return null; }
        var result = tg.trigger.Find(s => s.id == triggerId);
        if (result == null) { Debug.Log("天赋id不存在"); }
        return result;
    }

    private TalentEffect GetTalentOrderEffect(int typeId, int orderId)
    {
        var data = LoadTalentGroupData();
        var tg = data.Find(s => s.id == typeId);
        if (tg == null) { return null; }
        var result = tg.orderEffect.Find(s => s.id == orderId);
        if (result == null) { Debug.Log("天赋id不存在"); }
        return result;
    }

    private TalentEffect GetTalentChaosEffect(int typeId, int chaosId)
    {
        var data = LoadTalentGroupData();
        var tg = data.Find(s => s.id == typeId);
        if (tg == null) { return null; }
        var result = tg.chaosEffect.Find(s => s.id == chaosId);
        if (result == null) { Debug.Log("天赋id不存在"); }
        return result;
    }

    #endregion

    #region 关卡及任务相关

    private TaskDataSet LoadTaskDataSet()
    {
        return GetData("TaskData").scriptableObject as TaskDataSet;
    }

    /// <summary>
    /// 获取任务奖励数据
    /// </summary>
    /// <param name="taskDifficulty"></param>
    /// <param name="mapSize"></param>
    /// <returns></returns>
    public TaskReward GetTaskReward(TaskDifficulty taskDifficulty, MapSizeType mapSize)
    {
        return LoadTaskDataSet().taskRewardDatas.Find(s => s.taskDifficult == taskDifficulty && s.mapSize == mapSize);
    }

    /// <summary>
    /// 获取任务奖励资源数据
    /// </summary>
    /// <param name="mapName"></param>
    /// <returns></returns>
    public TaskResourceInfo GetTaskRewardResource(MapNameType mapName, TaskDifficulty taskDifficulty, MapSizeType mapSize)
    {
        TaskRewardResource taskRewardResources = LoadTaskDataSet().taskRewardResources.Find(s => s.nameType == mapName);
        if (taskRewardResources == null) { Debug.Log("地图不存在, mapName = " + mapName); return null; }
        TaskResourceInfo taskResourceInfoList = taskRewardResources.taskResourceInfoList.Find(s => s.difficultiesLimit == taskDifficulty && s.mapSizeLimit == mapSize);
        if (taskResourceInfoList == null) { Debug.Log("资源不存在, taskDifficulty = " + taskDifficulty + ", mapSize = " + mapSize); return null; }

        return taskResourceInfoList;
    }

    /// <summary>
    /// 生成任务数据，TODO（未使用权重，无法生成固定任务）
    /// </summary>
    /// <returns></returns>
    public TaskData CreateTaskData(TaskDifficulty taskDifficulty, MapSizeType mapSize, int warningValue, bool bKillBoss)
    {
        List<TaskData> taskDatas;
        if(warningValue >= 100 && bKillBoss)
        {
            taskDatas = LoadTaskDataSet().taskDatas.FindAll(s => s.difficultiesLimit.Contains(taskDifficulty) && s.mapSizeLimit.Contains(mapSize));
            
        }
        else if((warningValue >= 50 && bKillBoss) || warningValue >= 100)
        {
            taskDatas = LoadTaskDataSet().taskDatas.FindAll(
                s => s.difficultiesLimit.Contains(taskDifficulty) && s.mapSizeLimit.Contains(mapSize) && (s.taskType != N_TaskType.固定boss));
        }
        else
        {
            taskDatas = LoadTaskDataSet().taskDatas.FindAll(
                s => s.difficultiesLimit.Contains(taskDifficulty) && s.mapSizeLimit.Contains(mapSize) && (s.taskType != N_TaskType.随机boss && s.taskType != N_TaskType.固定boss));
        }
        int nTotalCount = 0;
        for(int i = 0; i < taskDatas.Count; i++)
        {
            TaskData tTaskData = taskDatas[i];
            nTotalCount += tTaskData.probability;
        }
        int nRandomIndex = 0;
        int nRandomCount = UnityEngine.Random.Range(0, nTotalCount);
        int nCurCount = 0;
        for(int i = 0; i < taskDatas.Count; i++)
        {
            TaskData tTaskData = taskDatas[i];
            nCurCount += tTaskData.probability;
            if(nRandomCount < nCurCount)
            {
                nRandomIndex = i;
                break;
            }
        }

        if(nRandomIndex >= 0)
            return taskDatas[nRandomIndex];
        // return taskDatas.Count > 0 ? taskDatas[0] : null;
        return null;
    }

    /// <summary>
    /// 生成固定boss任务数据
    /// </summary>
    /// <returns></returns>
    public TaskData CreateBossTaskData()
    {
        TaskData taskDatas = LoadTaskDataSet().taskDatas.Find(s => s.taskType == N_TaskType.固定boss);
        
        return taskDatas;
    }

    /// <summary>
    /// 生成随机boss任务数据
    /// </summary>
    /// <returns></returns>
    public TaskData CreateRandomBossTaskData()
    {
        TaskData taskDatas = LoadTaskDataSet().taskDatas.Find(s => s.taskType == N_TaskType.随机boss);
        
        return taskDatas;
    }

    /// <summary>
    /// 获取任务数据
    /// </summary>
    /// <param name="taskType"></param>
    /// <returns></returns>
    public TaskData GetTaskData(N_TaskType taskType)
    {
        return LoadTaskDataSet().taskDatas.Find(s => s.taskType == taskType);
    }

    /// <summary>
    /// 生成任务信息（随机）
    /// </summary>
    /// <param name="mapName"></param>
    /// <param name="taskType"></param>
    /// <returns></returns>
    public TaskInfo CreateTaskInfo(MapNameType mapName, N_TaskType taskType)
    {
        TaskInformationSet taskInformationSet = LoadTaskDataSet().taskInformation.Find(s => s.mapName == mapName);
        if (taskInformationSet == null) { Debug.Log("地图不存在"); return null; }
        TaskInformation taskInformation = taskInformationSet.taskInformation.Find(s => s.taskTypes.Contains(taskType));
        if (taskInformation == null) { Debug.Log("任务不存在"); return null; }
        return taskInformation.taskInfo[UnityEngine.Random.Range(0, taskInformation.taskInfo.Count)];
    }

    /// <summary>
    /// 生成任务信息(id不重复)
    /// </summary>
    /// <param name="mapName"></param>
    /// <param name="taskType"></param>
    /// <returns></returns>
    public TaskInfo CreateTaskInfoEx(MapNameType mapName, N_TaskType taskType, Dictionary<int, TaskInfo> tCurTaskMap)
    {
        TaskInformationSet taskInformationSet = LoadTaskDataSet().taskInformation.Find(s => s.mapName == mapName);
        if (taskInformationSet == null) { Debug.Log("地图不存在"); return null; }
        TaskInformation taskInformation = taskInformationSet.taskInformation.Find(s => s.taskTypes.Contains(taskType));
        if (taskInformation == null) { Debug.Log("任务不存在"); return null; }

        List<TaskInfo> datas = new List<TaskInfo>();
        foreach (var t in taskInformation.taskInfo)
        {
            if(!tCurTaskMap.ContainsKey(t.id))
                datas.Add(t);
        }

        return datas[UnityEngine.Random.Range(0, datas.Count)];
    }

    /// <summary>
    /// 获取任务信息
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public TaskInfo GetTaskInfo(int id)
    {
        List<TaskInfo> datas = new List<TaskInfo>();
        foreach (var task in LoadTaskDataSet().taskInformation)
        {
            foreach (var t in task.taskInformation)
            {
                datas.AddRange(t.taskInfo);
            }
        }
        return datas.Find(s => s.id == id);
    }

    /// <summary>
    /// 添加关卡到存档
    /// </summary>
    /// <param name="instanceZoneModeSet"></param>
    public void AddZoneMode(InstanceZoneModeSet instanceZoneModeSet)
    {
        if (modeData.instanceZoneMode == null)
        {
            modeData.instanceZoneMode = new List<InstanceZoneModeSet>();
        }
        modeData.instanceZoneMode.Add(instanceZoneModeSet);
    }

    /// <summary>
    /// 获取关卡对象并进行初始化（源于存档）
    /// </summary>
    /// <returns></returns>
    public List<ZoneObjData> GetZoneObj()
    {
        List<ZoneObjData> results = new List<ZoneObjData>();
        if (modeData.instanceZoneMode != null)
        {
            foreach (var zone in modeData.instanceZoneMode)
            {
                ZoneObjData zoneObjData = new ZoneObjData();
                zoneObjData.Init(zone);
                results.Add(zoneObjData);
            }
        }
        return results;
    }

    #endregion

    #region 地图

    private MapDataSet LoadMapDataSet()
    {
        var dataSet = GetData("MapData");
        if (dataSet == null || dataSet.scriptableObject == null) { Debug.Log("地图数据错误"); return null; }
        return dataSet.scriptableObject as MapDataSet;
    }

    public N_MapData GetMapData(MapNameType mapName)
    {
        var data = LoadMapDataSet();
        if (data == null || data.nMapData == null) { Debug.Log("地图数据错误"); return null; }
        return data.nMapData.Find(s => s.name == mapName.ToString());
    }

    public List<int> GetMonsterIdsRandom(MapNameType mapName)
    {
        var data = LoadMapDataSet();
        var map = data.mapMonsterGroups.Find(s => s.nameType == mapName);
        if (map == null) { Debug.Log("地图怪物数据错误"); return null; }
        var monsters = map.roomMonsters.Find(s => s.roomType == N_MiniMapRoomType.精英房间);
        if (monsters == null || monsters.monsterGroups == null || monsters.monsterGroups.Count <= 0) { Debug.Log("地图怪物数据错误"); return null; }
        return monsters.monsterGroups[UnityEngine.Random.Range(0, monsters.monsterGroups.Count)].monsterGroup;
    }

    #endregion

    #region 系统设置相关 
    private SettingDataSet GetSettingDataSet()
    {
        DataSetItem item = GetData("SettingDataSet");
        if (item == null || item.scriptableObject == null) return null;
        return item.scriptableObject as SettingDataSet;
    }
    public AudioSettingData GetAudioSettingData()
    {
        SettingDataSet temp = GetSettingDataSet();
        if (temp == null) return null;
        return temp.audioSettingData;
    }
    #endregion
    #region 音效资源加载相关 --- 测试
    private AudioClipDataSet GetAudioClipDataSet()
    {
        DataSetItem item = GetData("AudioClipData");
        if (item == null || item.scriptableObject == null) return null;
        return item.scriptableObject as AudioClipDataSet;
    }
    public List<AudioClipData> GetAudioClipData() {
        AudioClipDataSet temp = GetAudioClipDataSet();
        if (temp == null) return null;
        return temp.audioClipDatas;
    }
    #endregion
    #region 交互物

    public InteractiveDataSet LoadInteractiveDataSet()
    {
        var data = GetData("InteractiveData");
        if (data == null || data.scriptableObject == null) { Debug.Log("交互物数据错误"); return null; }
        return data.scriptableObject as InteractiveDataSet;
    }
    /// <summary>
    /// 获取交互物存档 
    /// </summary>
    /// <param name="_type"></param>
    /// <returns></returns>
    public InteractiveMode GetInteractiveMode(InteractiveType _type, MapType _mapType, int _roomIndex, int _routeGroupIndex, int _routeIndex)
    {
        Debug.Log(modeData);
        Debug.Log(modeData.scriptureModes);
        InteractiveMode temp = null;
        switch (_type)
        {
            case InteractiveType.经文:
                if (_mapType == MapType.房间) temp = modeData.scriptureModes.Find(s => s.mapType == _mapType && s.roomIndex == _roomIndex);
                else if (_mapType == MapType.道路) temp = modeData.scriptureModes.Find(s => s.mapType == _mapType && s.routeGroupIndex == _routeGroupIndex && s.routeIndex == _routeIndex);
                break;
            case InteractiveType.冥想台:
                if (_mapType == MapType.房间) temp = modeData.meditationPlatformModes.Find(s => s.mapType == _mapType && s.roomIndex == _roomIndex);
                else if (_mapType == MapType.道路) temp = modeData.meditationPlatformModes.Find(s => s.mapType == _mapType && s.routeGroupIndex == _routeGroupIndex && s.routeIndex == _routeIndex);
                break;
            case InteractiveType.祭坛:
                if (_mapType == MapType.房间) temp = modeData.altarModeModes.Find(s => s.mapType == _mapType && s.roomIndex == _roomIndex);
                else if (_mapType == MapType.道路) temp = modeData.altarModeModes.Find(s => s.mapType == _mapType && s.routeGroupIndex == _routeGroupIndex && s.routeIndex == _routeIndex);
                break;
            case InteractiveType.解救:
                if (_mapType == MapType.房间) temp = modeData.rescueModes.Find(s => s.mapType == _mapType && s.roomIndex == _roomIndex);
                else if (_mapType == MapType.道路) temp = modeData.rescueModes.Find(s => s.mapType == _mapType && s.routeGroupIndex == _routeGroupIndex && s.routeIndex == _routeIndex);
                break;
            case InteractiveType.地下游商:
                if (_mapType == MapType.房间) temp = modeData.undergroundShopModes.Find(s => s.mapType == _mapType && s.roomIndex == _roomIndex);
                else if (_mapType == MapType.道路) temp = modeData.undergroundShopModes.Find(s => s.mapType == _mapType && s.routeGroupIndex == _routeGroupIndex && s.routeIndex == _routeIndex);
                break;
        }
        return temp;
    }
    public void AddInteractivMode<T>(T _mode) where T : InteractiveMode {
        switch (_mode.interactiveType)
        {
            case InteractiveType.经文:
                modeData.scriptureModes.Add(_mode as ScriptureMode); break;
            case InteractiveType.冥想台:
                modeData.meditationPlatformModes.Add(_mode as MeditationPlatformMode); break;
            case InteractiveType.祭坛:
                modeData.altarModeModes.Add(_mode as AltarMode); break;
            case InteractiveType.解救:
                modeData.rescueModes.Add(_mode as RescueMode); break;
            case InteractiveType.地下游商:
                modeData.undergroundShopModes.Add(_mode as UndergroundShopMode); break;
        }
    }
    public void ClearAllInteractiveMode()
    {
        try
        {
            modeData.scriptureModes.Clear();
            modeData.meditationPlatformModes.Clear();
            modeData.altarModeModes.Clear();
            modeData.rescueModes.Clear();
            modeData.undergroundShopModes.Clear();
        }
        catch (Exception e) {
            if (modeData == null) Debug.Log("存档覆盖问题，删掉存档");
            Debug.Log(e);
        }
    }
    /// <summary>
    /// 获取交互物数据表
    /// </summary>
    /// <returns></returns>
    public List<InteractiveData> GetInteractiveDatas()
    {
        var dataSet = LoadInteractiveDataSet();
        if (dataSet == null || dataSet.interactiveDatas == null) { Debug.Log("交互物数据错误"); return null; }
        return dataSet.interactiveDatas;
    }
    public InteractiveData GetInteractiveDataByType(InteractiveType _type) {
        List<InteractiveData> data = GetInteractiveDatas();
        if (data == null) { Debug.Log("交互物数据错误"); return null; }
        return data.Find(s => s.interactiveType == _type);
    }
    /// <summary>
    /// 获取交互物刷新数量
    /// </summary>
    /// <param name="taskDifficulty"></param>
    /// <param name="mapSize"></param>
    /// <returns></returns>
    public InteractiveNumberData GetInteractiveNumberData(TaskDifficulty taskDifficulty, MapSizeType mapSize)
    {
        var dataSet = LoadInteractiveDataSet();
        if (dataSet == null || dataSet.interactiveNumberDatas == null) { Debug.Log("交互物刷新数量数据错误"); return null; }
        return dataSet.interactiveNumberDatas.Find(s => s.taskDifficulty == taskDifficulty && s.mapSize == mapSize);
    }

    /// <summary>
    /// 根据概率随机生成一个经文效果
    /// </summary>
    /// <returns></returns>
    public InteractiveScripture CreateScriptureRandom()
    {
        var dataSet = LoadInteractiveDataSet();
        if (dataSet == null || dataSet.interactiveScriptures == null) { Debug.Log("经文数据错误"); return null; }
        List<InteractiveScripture> data = new List<InteractiveScripture>();
        InteractiveScripture tempScripture = null;
        for (int i = 0; i < dataSet.interactiveScriptures.Count; ++i)
        {
            tempScripture = data.Find(s => s.scriptureType == dataSet.interactiveScriptures[i].scriptureType);
            if (tempScripture != null) continue;
            data.Add(dataSet.interactiveScriptures[i]);
        }
        tempScripture = GetRandomByProbability(data, data.Select(s => s.ScriptureTypeProbability).ToList());
        List<InteractiveScripture> effectData = dataSet.interactiveScriptures.FindAll(s => s.scriptureType == tempScripture.scriptureType);
        InteractiveScripture result = GetRandomByProbability(effectData, effectData.Select(s => s.probability).ToList());
        return result;
    }

    /// <summary>
    /// 通过id获取经文数据
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public InteractiveScripture GetScriptureById(int id)
    {
        var dataSet = LoadInteractiveDataSet();
        if (dataSet == null || dataSet.interactiveScriptures == null) { Debug.Log("经文数据错误"); return null; }
        var data = dataSet.interactiveScriptures;
        return data.Find(s => s.id == id);
    }


    /// <summary>
    /// 根据权重随机生成祝福效果
    /// </summary>
    /// <param name="_type"></param>
    /// <returns></returns>
    public AltarBlessAction CreatAltarBlessAction(AltarRewardType _type) {
        if (_type != AltarRewardType.上级祝福 && _type != AltarRewardType.下级祝福) throw new Exception($"祭坛祝福数据 {_type} is error");
        AltarBless bless = GetAltarBlessByType(_type);
        return GetRandomByProbability(bless.actions, bless.actions.Select(s => s.probability).ToList());
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="_type"></param>
    /// <returns></returns>
    public AltarBless GetAltarBlessByType(AltarRewardType _type)
    {
        if (_type != AltarRewardType.上级祝福 && _type != AltarRewardType.下级祝福) throw new Exception($"祭坛祝福数据 {_type} is error");
        InteractiveDataSet dataset = LoadInteractiveDataSet();
        if (dataset == null || dataset.altarBlesses == null) { Debug.Log("祭坛祝福数据错误"); return null; }
        AltarBless temp = null;
        for (int i = 0; i < dataset.altarBlesses.Count; ++i)
        {
            if (_type == dataset.altarBlesses[i].rewardType)
            {
                temp = dataset.altarBlesses[i];
                break;
            }
        }
        if (temp == null)
        {
            throw new Exception($"祭坛祝福数据 {_type} == NULL");
        }
        return temp;
    }
    /// <summary>
    /// 根据id 获取祭坛
    /// </summary>
    /// <param name="_id"></param>
    /// <returns></returns>
    public InteractiveAltar GetInteractiveAltar(int _id) {
        InteractiveDataSet dataset = LoadInteractiveDataSet();
        if (dataset == null || dataset.altarBlesses == null) { Debug.Log("祭坛数据错误"); return null; }
        InteractiveAltar temp = dataset.interactiveAltars.Find(i => i.id == _id);
        return temp;
    }
    /// <summary>
    ///根据权重生成祭坛献祭数据
    /// </summary>
    /// <returns></returns>
    public InteractiveAltar CreatInteractiveAltarRandom() {
        InteractiveDataSet dataset = LoadInteractiveDataSet();
        if (dataset == null || dataset.altarBlesses == null) { Debug.Log("祭坛数据错误"); return null; }
        InteractiveAltar temp = GetRandomByProbability(dataset.interactiveAltars, dataset.interactiveAltars.Select(s => s.probability).ToList());
        return temp;
    }
    /// <summary>
    /// 根据权重生成解救-囚徒数据
    /// </summary>
    /// <returns></returns>
    public InteractiveRescue CreatInteractiveRescueRandom() {
        InteractiveDataSet dataset = LoadInteractiveDataSet();
        if (dataset == null || dataset.interactiveRescues == null) { Debug.Log("囚徒数据错误"); return null; }
        InteractiveRescue temp = GetRandomByProbability(dataset.interactiveRescues, dataset.interactiveRescues.Select(s => s.probability).ToList());
        return temp;
    }
    public InteractiveRescue GetInteractiveRescueByID(int _id) {
        InteractiveDataSet dataset = LoadInteractiveDataSet();
        if (dataset == null || dataset.interactiveRescues == null) { Debug.Log("囚徒数据错误"); return null; }
        InteractiveRescue temp = dataset.interactiveRescues.Find(s => s.id == _id);
        return temp;
    }

    public Dictionary<ObjType, InteractiveShop> GetRandomUndergroundShopDatas(Dictionary<ObjType, int> limmit = null)
    {
        InteractiveDataSet dataset = LoadInteractiveDataSet();
        if (dataset == null || dataset.interactiveShops == null) { Debug.Log("地下商城 数据错误"); return null; }
        Dictionary<ObjType, InteractiveShop> result = new Dictionary<ObjType, InteractiveShop>();

        int tempprobability = 0;
        for (int i = 0; i < dataset.interactiveShops.Count; ++i) {
            tempprobability = limmit == null || !limmit.ContainsKey(dataset.interactiveShops[i].objType) ? 0 : limmit[dataset.interactiveShops[i].objType];
            if (UnityEngine.Random.Range(0, 100) < dataset.interactiveShops[i].probability + tempprobability) {
                result.Add(dataset.interactiveShops[i].objType, dataset.interactiveShops[i]);
            }
        }

        return result;
    }
    public Dictionary<ObjType, InteractiveShop> GetUndergroundShopDatasByType(params ObjType[] _types)
    {
        InteractiveDataSet dataset = LoadInteractiveDataSet();
        if (dataset == null || dataset.interactiveShops == null) { Debug.Log("地下商城 数据错误"); return null; }
        Dictionary<ObjType, InteractiveShop> result = new Dictionary<ObjType, InteractiveShop>();
        for (int i = 0; i < _types.Length; ++i) {
            InteractiveShop temp = dataset.interactiveShops.Find(s => s.objType == _types[i]);
            if (temp == null) continue;
            result.Add(temp.objType, temp);
        }
        return result;
    }
    public InteractiveShop GetInteractiveShopDataByType(ObjType _type) {
        InteractiveDataSet dataset = LoadInteractiveDataSet();
        if (dataset == null || dataset.interactiveShops == null) { Debug.Log("地下商城 数据错误"); return null; }
        return dataset.interactiveShops.Find(s => s.objType == _type);
    }
    #endregion
    #region 多语言
    /// <summary>
    /// key = id
    /// </summary>
    private static Dictionary<int, LanguageData> LanguageDataDic = new Dictionary<int, LanguageData>();
    /// <summary>
    /// key = 技能ID
    /// </summary>
    private static Dictionary<int, Dictionary<int, LanguageData>> SkilDataLanguageDataDic = new Dictionary<int, Dictionary<int, LanguageData>>();
    private void LoadLanguageData()
    {
        if (LanguageDataDic.Count > 0 && SkilDataLanguageDataDic.Count > 0) return;

        LanguageDataSet languageDataSet = GetData("LanguageData").scriptableObject as LanguageDataSet;
        List<LanguageData> languageDatas = languageDataSet.LanguageDatas;
        if (LanguageDataDic.Count <= 0)
        {
            foreach (var sd in languageDatas)
            {
                if (LanguageDataDic.ContainsKey(sd.id))
                {
                    Debug.Log("id重复！");
                    continue;
                }
                LanguageDataDic.Add(sd.id, sd);
            }
        }
        if (SkilDataLanguageDataDic.Count <= 0)
        {
            foreach (var sd in languageDatas)
            {
                if (sd.skillID == -1) continue;
                if (!SkilDataLanguageDataDic.ContainsKey(sd.skillID)) SkilDataLanguageDataDic.Add(sd.skillID, new Dictionary<int, LanguageData>());
                if(SkilDataLanguageDataDic[sd.skillID].ContainsKey(sd.id))
                {
                    Debug.Log("id重复！");
                    continue;
                }
                SkilDataLanguageDataDic[sd.skillID].Add(sd.id, sd);
            }
        }
       
    }
    public LanguageData GetLanguageData(int _id)
    {
        LoadLanguageData();
        if (!LanguageDataDic.ContainsKey(_id)) return null;
        return  LanguageDataDic[_id];
    }
    public string GetLanguageData(int _id,LanguageOption? option = null)
    {
        LoadLanguageData();
        LanguageData data =  GetLanguageData(_id);
        string result = string.Empty;
        if (data == null) return result;
        LanguageOption tempOption = option.HasValue ? option.Value : LanguageController.GetLanguageOption();
        switch (tempOption) {
            case LanguageOption.简体中文:  result = data.cn;break;
            case LanguageOption.English: result = data.en; break;
        }
        return result;
    }
    public Dictionary<int, LanguageData> GetLanguageDataBySkillID(int _skillID) {

        LoadLanguageData();
        if (!SkilDataLanguageDataDic.ContainsKey(_skillID)) return null;
        return SkilDataLanguageDataDic[_skillID];
    }
    public  LanguageData GetLanguageDataBySkillID(int _id,int _skillID)
    {
        LoadLanguageData();
        if (!SkilDataLanguageDataDic.ContainsKey(_skillID)) return null;
        if (!SkilDataLanguageDataDic[_skillID].ContainsKey(_id)) return null;
        return SkilDataLanguageDataDic[_skillID][_id];
    }
    public string GetLanguageDataBySkillID(int _id, int _skillID, LanguageOption? option = null)
    {
        LoadLanguageData();
        LanguageData data = GetLanguageDataBySkillID(_id, _skillID);
        string result = string.Empty;
        if (data == null) return result;
        LanguageOption tempOption = option.HasValue ? option.Value : LanguageController.GetLanguageOption();
        switch (tempOption)
        {
            case LanguageOption.简体中文: result = data.cn; break;
            case LanguageOption.English: result = data.en; break;
        }
        return result;
    }
    ///// <summary>
    ///// 仅作测试使用 未完善
    ///// </summary>
    //public void SpeculativeParseCSV_Language()
    //{
    //    SpeculativeParseCSV("CsvData/多语言配置", (CSVTable csvTable) =>
    //    {

    //        LanguageDataSet dataset = Resources.Load("TargetTemp/LanguageDataSet") as LanguageDataSet;
    //        LanguageMap = new Dictionary<string, Dictionary<LanguageOption, string>>();
    //        for (int i = 0; i < csvTable.Records.Count; ++i)
    //        {
    //            int i_index = i;
    //            CSVRecord record = csvTable.GetRecord(i_index);
    //            string Id = record.GetField("id").StringValue;
    //            Debug.Log($"----------------开始赋值 [language = {Id}]的数据----------------------------");
    //            LanguageMap.Add(Id, new Dictionary<LanguageOption, string>());
    //            LanguageData languageData = new LanguageData();
    //            for (int j = 0; j < csvTable.Headers.Count; ++j)
    //            {
    //                int j_index = j;
    //                CSVRecordData tempData = record.GetField(csvTable.Headers[j_index]);
    //                switch (csvTable.Headers[j_index])
    //                {
    //                    case "id":
    //                        languageData.id = tempData.StringValue;
    //                        break;
    //                    case "model":
    //                        languageData.model = tempData.StringValue;
    //                        break;
    //                    case "type":
    //                        languageData.type = tempData.StringValue;
    //                        break;
    //                    case "cn":
    //                        languageData.cn = tempData.StringValue;
    //                        LanguageMap[Id].Add(LanguageOption.简体中文, tempData.StringValue);
    //                        break;
    //                    case "en":
    //                        languageData.en = tempData.StringValue;
    //                        LanguageMap[Id].Add(LanguageOption.English, tempData.StringValue);
    //                        break;
    //                }
    //            }
    //            dataset.LanguageDatas.Add(languageData);
    //            Debug.Log($"----------------[language = {Id}]的数据赋值完成----------------------------");
    //        }

    //    });
    //}
    #endregion
    /// <summary>
    /// 根据权重随机选取一个数据
    /// </summary>
    /// <typeparam name="T">数据类型</typeparam>
    /// <param name="datas">数据列表</param>
    /// <param name="proList">概率列表</param>
    /// <returns></returns>
    public T GetRandomByProbability<T>(List<T> datas, List<int> proList)
    {
        if (datas.Count != proList.Count || datas.Count == 0) { Debug.Log("概率获取错误"); return default; }      
        int sum = proList.Sum();
        int roll = UnityEngine.Random.Range(0, sum);// datas.Count);
        for (int i = 0; i < datas.Count; ++i)//, roll -= proList[i])
        {
            if (roll < proList[i])
                return datas[i];
            roll -= proList[i];
        }
        Debug.Log("概率获取错误");
        return default;
    }
    /// <summary>
    /// 解析CSV
    /// </summary>
    /// <param name="curCSVPath"></param>
    /// <param name="complete"></param>
    //public void SpeculativeParseCSV(string curCSVPath, UnityAction<CSVTable> complete)
    //{
    //    CSVLoader CsvLoader = new CSVLoader();
    //    CSVTable csvTable = CsvLoader.LoadCSV(curCSVPath);
    //    complete.Invoke(csvTable);
    //}
    //所有数据从这个脚本加载取出,,,取值时会此脚本记录一次数据,可防止重复加载
}
