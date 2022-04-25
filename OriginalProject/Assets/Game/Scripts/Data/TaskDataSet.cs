using Datas;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Datas
{
    /// <summary>
    /// 任务奖励
    /// </summary>
    [Serializable]
    public class TaskReward : DataBase
    {
        /// <summary>
        /// 关卡难度
        /// </summary>
        public TaskDifficulty taskDifficult;

        /// <summary>
        /// 关卡大小
        /// </summary>
        public MapSizeType mapSize;

        /// <summary>
        /// 进入要求
        /// </summary>
        public int medalLevelLimit;

        /// <summary>
        /// 鳞片
        /// </summary>
        public int money;

        /// <summary>
        /// 资源最小值
        /// </summary>
        public int minResource;

        /// <summary>
        /// 资源最大值
        /// </summary>
        public int maxResource;

        /// <summary>
        /// 饰品奖励
        /// </summary>
        public List<OrnamentReward> ornamentDrops;

        /// <summary>
        /// 勋章奖励
        /// </summary>
        public List<MedalReward> medalDrops;

        /// <summary>
        /// 警戒值增加
        /// </summary>
        public int warningValueAdd;
    }

    [Serializable]
    public class OrnamentReward
    {
        /// <summary>
        /// 等级
        /// </summary>
        public LevelType level;

        /// <summary>
        /// 数量
        /// </summary>
        public int count;

        /// <summary>
        /// 概率
        /// </summary>
        public int probability;
    }

    [Serializable]
    public class MedalReward
    {
        /// <summary>
        /// 等级
        /// </summary>
        public int level;

        /// <summary>
        /// 数量
        /// </summary>
        public int count;

        /// <summary>
        /// 概率
        /// </summary>
        public int probability;
    }

    [Serializable]
    public class Resource
    {
        /// <summary>
        /// 资源id
        /// </summary>
        public int id;

        /// <summary>
        /// 数量
        /// </summary>
        public int count;

    }

    /// <summary>
    /// 资源所属关卡
    /// </summary>
    [Serializable]
    public class TaskRewardResource
    {
        /// <summary>
        /// 关卡名
        /// </summary>
        public MapNameType nameType;

        /// <summary>
        /// 资源列表
        /// </summary>
        public List<TaskResourceInfo> taskResourceInfoList;
        
    }

    /// <summary>
    /// 资源列表
    /// </summary>
    [Serializable]
    public class TaskResourceInfo
    {
        /// <summary>
        /// 可遇难度
        /// </summary>
        public TaskDifficulty difficultiesLimit;

        /// <summary>
        /// 地图大小
        /// </summary>
        public MapSizeType mapSizeLimit;

        /// <summary>
        /// 资源id列表
        /// </summary>
        public List<Resource> resourceIds;
    }

    /// <summary>
    /// 任务数据
    /// </summary>
    [Serializable]
    public class TaskData : DataBase
    {
        /// <summary>
        /// 任务类型
        /// </summary>
        public N_TaskType taskType;

        /// <summary>
        /// 可遇难度
        /// </summary>
        public List<TaskDifficulty> difficultiesLimit;

        /// <summary>
        /// 地图大小
        /// </summary>
        public List<MapSizeType> mapSizeLimit;

        /// <summary>
        /// 权重
        /// </summary>
        public int probability;
    }

    [Serializable]
    public class TaskInformationSet
    {
        public MapNameType mapName;
        public List<TaskInformation> taskInformation;
    }

    /// <summary>
    /// 任务信息
    /// </summary>
    [Serializable]
    public class TaskInformation
    {
        /// <summary>
        /// 任务类型
        /// </summary>
        public List<N_TaskType> taskTypes;

        /// <summary>
        /// 任务名称和描述
        /// </summary>
        public List<TaskInfo> taskInfo;
    }

    [Serializable]
    public class TaskInfo : DataBase
    {
        /// <summary>
        /// 携带的数据 - 目前只有怪物id
        /// </summary>
        public int[] triggerKeys;
    }
    [CreateAssetMenu(menuName = "NewData/TaskData")]
    [Serializable]
    public class TaskDataSet : ScriptableObject
    {
        [Header("任务奖励")]
        [SerializeField] public List<TaskReward> taskRewardDatas = new List<TaskReward>();

        [Header("资源所属关卡")]
        [SerializeField] public List<TaskRewardResource> taskRewardResources = new List<TaskRewardResource>();

        [Header("任务数据")]
        [SerializeField] public List<TaskData> taskDatas = new List<TaskData>();

        [Header("任务信息")]
        [SerializeField] public List<TaskInformationSet> taskInformation = new List<TaskInformationSet>();
    }

}

/// <summary>
/// 任务对象类
/// </summary>
public class TaskObjData
{
    private TaskReward taskReward;
    private TaskResourceInfo taskResourceInfo;
    private TaskData taskData;
    private TaskInfo taskInfo;
    private InstanceZoneMode taskMode;

    /// <summary>
    /// 生成任务
    /// </summary>
    /// <param name="warningValue"></param>
    /// <param name="mapName"></param>
    public void Create(int warningValue, MapNameType mapName)
    {
        //TODO 未使用警戒值
        TaskDifficulty taskDifficulty = TaskDifficulty.人迹罕至;
        MapSizeType mapSize = MapSizeType.狭小;
        bool bKillBoss = false;
        taskData = DataManager.Instance.CreateTaskData(taskDifficulty, mapSize, warningValue, bKillBoss);
        taskInfo = DataManager.Instance.CreateTaskInfo(mapName, taskData.taskType);
        taskReward = DataManager.Instance.GetTaskReward(taskDifficulty, mapSize);
        taskResourceInfo = DataManager.Instance.GetTaskRewardResource(mapName, taskDifficulty, mapSize);

        taskMode = new InstanceZoneMode()
        {
            taskType = taskData.taskType,
            taskId = taskInfo.id,
            mapSize = mapSize,
            taskDifficulty = taskDifficulty
        };
    }
    public void Create(int warningValue, MapNameType mapName, bool bKillBoss, int nMaxWarningValue, Dictionary<int, TaskInfo> tCurTaskMap)
    {

        TaskDifficulty taskDifficulty = TaskDifficulty.人迹罕至;
        MapSizeType mapSize = MapSizeType.狭小;
        float tempValue = UnityEngine.Random.Range(0f, 1f);

        if (nMaxWarningValue < 5)
        { if (tempValue < 0.5f) mapSize = MapSizeType.狭小; else mapSize = MapSizeType.宽敞; }
        else if (nMaxWarningValue < 10)
        {
            if (tempValue < 0.3f) mapSize = MapSizeType.狭小;
            else if (tempValue < 0.7f) mapSize = MapSizeType.宽敞;
            else { taskDifficulty = TaskDifficulty.危机四伏; mapSize = MapSizeType.狭小; }
        }
        else if (nMaxWarningValue < 20)
        {
            if (tempValue < 0.15f) mapSize = MapSizeType.狭小;
            else if (tempValue < 0.3f) mapSize = MapSizeType.宽敞;
            else if (tempValue < 0.7f) { taskDifficulty = TaskDifficulty.危机四伏; mapSize = MapSizeType.狭小; }
            else { taskDifficulty = TaskDifficulty.危机四伏; mapSize = MapSizeType.宽敞; }
        }
        else if (nMaxWarningValue < 35)
        {
            taskDifficulty = TaskDifficulty.危机四伏;
            if (tempValue < 0.2f) mapSize = MapSizeType.狭小;
            else if (tempValue < 0.5f) mapSize = MapSizeType.宽敞;
            else { taskDifficulty = TaskDifficulty.艰难险阻; mapSize = MapSizeType.狭小; }
        }
        else
        {
            taskDifficulty = TaskDifficulty.危机四伏;
            if (tempValue < 0.2f) mapSize = MapSizeType.狭小;
            else if (tempValue < 0.5f) mapSize = MapSizeType.宽敞;
            else if (tempValue < 0.8f) { taskDifficulty = TaskDifficulty.艰难险阻; mapSize = MapSizeType.狭小; }
            else { taskDifficulty = TaskDifficulty.艰难险阻; mapSize = MapSizeType.宽敞; }
        }

        taskData = DataManager.Instance.CreateTaskData(taskDifficulty, mapSize, warningValue, bKillBoss);
        // taskInfo = DataManager.Instance.CreateTaskInfo(mapName, taskData.taskType);
        taskInfo = DataManager.Instance.CreateTaskInfoEx(mapName, taskData.taskType, tCurTaskMap);
        taskReward = DataManager.Instance.GetTaskReward(taskDifficulty, mapSize);
        taskResourceInfo = DataManager.Instance.GetTaskRewardResource(mapName, taskDifficulty, mapSize);

        taskMode = new InstanceZoneMode()
        {
            taskType = taskData.taskType,
            taskId = taskInfo.id,
            mapSize = mapSize,
            taskDifficulty = taskDifficulty
        };
    }

    /// <summary>
    /// 生成固定Boss任务
    /// </summary>
    /// <param name="mapName"></param>
    public void CreateBoss(MapNameType mapName)
    {
        TaskDifficulty taskDifficulty = TaskDifficulty.危机四伏;
        MapSizeType mapSize = MapSizeType.宽敞;

        taskData = DataManager.Instance.CreateBossTaskData();
        taskInfo = DataManager.Instance.CreateTaskInfo(mapName, taskData.taskType);
        taskReward = DataManager.Instance.GetTaskReward(taskDifficulty, mapSize);
        taskResourceInfo = DataManager.Instance.GetTaskRewardResource(mapName, taskDifficulty, mapSize);

        taskMode = new InstanceZoneMode()
        {
            taskType = taskData.taskType,
            taskId = taskInfo.id,
            mapSize = mapSize,
            taskDifficulty = taskDifficulty
        };
    }

    /// <summary>
    /// 生成随机Boss任务
    /// </summary>
    /// <param name="mapName"></param>
    public void CreateRandomBoss(MapNameType mapName)
    {
        TaskDifficulty taskDifficulty = TaskDifficulty.艰难险阻;
        MapSizeType mapSize = MapSizeType.宽敞;

        taskData = DataManager.Instance.CreateRandomBossTaskData();
        taskInfo = DataManager.Instance.CreateTaskInfo(mapName, taskData.taskType);
        taskReward = DataManager.Instance.GetTaskReward(taskDifficulty, mapSize);
        taskResourceInfo = DataManager.Instance.GetTaskRewardResource(mapName, taskDifficulty, mapSize);

        taskMode = new InstanceZoneMode()
        {
            taskType = taskData.taskType,
            taskId = taskInfo.id,
            mapSize = mapSize,
            taskDifficulty = taskDifficulty
        };
    }

    /// <summary>
    /// 初始化任务
    /// </summary>
    /// <param name="taskMode"></param>
    /// <param name="mapName"></param>
    public void Init(InstanceZoneMode taskMode, MapNameType mapName)
    {
        taskReward = DataManager.Instance.GetTaskReward(taskMode.taskDifficulty, taskMode.mapSize);
        taskResourceInfo = DataManager.Instance.GetTaskRewardResource(mapName, taskMode.taskDifficulty, taskMode.mapSize);
        taskData = DataManager.Instance.GetTaskData(taskMode.taskType);
        taskInfo = DataManager.Instance.GetTaskInfo(taskMode.taskId);
        this.taskMode = taskMode;
    }

    /// <summary>
    /// 获取id
    /// </summary>
    /// <returns></returns>
    public int GetTaskId()
    {
        return taskInfo.id;
    }

    /// <summary>
    /// 获取任务信息
    /// </summary>
    /// <returns></returns>
    public TaskInfo GetTaskInfo()
    {
        return taskInfo;
    }

    /// <summary>
    /// 获取任务名
    /// </summary>
    /// <returns></returns>
    public string GetTaskName()
    {
        return taskInfo.name;
    }

    /// <summary>
    /// 获取地图大小
    /// </summary>
    /// <returns></returns>
    public MapSizeType GetMapSize()
    {
        return taskMode.mapSize;
    }

    /// <summary>
    /// 获取任务难度
    /// </summary>
    /// <returns></returns>
    public TaskDifficulty GetTaskDifficulty()
    {
        return taskMode.taskDifficulty;
    }

    /// <summary>
    /// 获取任务等级限制
    /// </summary>
    /// <returns></returns>
    public int GetMedalLevelLimit()
    {
        return taskReward.medalLevelLimit;
    }

    /// <summary>
    /// 获取奖励鳞片数
    /// </summary>
    /// <returns></returns>
    public int GetMoney()
    {
        return taskReward.money;
    }

    /// <summary>
    /// 获取资源奖励数
    /// </summary>
    /// <param name="min"></param>
    /// <param name="max"></param>
    public void GetResourceCount(out int min, out int max)
    {
        min = taskReward.minResource;
        max = taskReward.maxResource;
    }

    /// <summary>
    /// 获取饰品奖励
    /// </summary>
    /// <returns></returns>
    public List<OrnamentReward> GetOrnamentDrops()
    {
        return taskReward.ornamentDrops;
    }

    /// <summary>
    /// 获取勋章奖励
    /// </summary>
    /// <returns></returns>
    public List<MedalReward> GetMedalDrops()
    {
        return taskReward.medalDrops;
    }

    /// <summary>
    /// 获取警戒值增加量
    /// </summary>
    /// <returns></returns>
    public int GetWarningValueAdd()
    {
        return taskReward.warningValueAdd;
    }

    /// <summary>
    /// 获取奖励资源id
    /// </summary>
    /// <returns></returns>
    public List<Resource> GetResourcesId()
    {
        return taskResourceInfo.resourceIds;
    }

    /// <summary>
    /// 获取任务目标
    /// </summary>
    /// <returns></returns>
    public string GetTaskTarget()
    {
        if(LanguageController.GetLanguageOption() == LanguageController.LanguageOption.English)
        {
            return taskData.describe_EN;
        }
        else
        {
            return taskData.describe;
        }
    }

    /// <summary>
    /// 获取任务类型
    /// </summary>
    /// <returns></returns>
    public N_TaskType GetTaskType()
    {
        return taskData.taskType;
    }

    /// <summary>
    /// 获取任务描述
    /// </summary>
    /// <returns></returns>
    public string GetTaskDescribe()
    {
        if(LanguageController.GetLanguageOption() == LanguageController.LanguageOption.English)
        {
            return taskInfo.describe_EN;
        }
        else
        {
            return taskInfo.describe;
        }
    }
    public TaskInfo TaskInfoData {
        get {
            return taskInfo;
        }
    }
}

/// <summary>
/// 关卡对象类
/// </summary>
public class ZoneObjData
{
    private InstanceZoneModeSet zoneMode;
    private List<TaskObjData> tasks = new List<TaskObjData>();

    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="zoneMode"></param>
    public void Init(InstanceZoneModeSet zoneMode)
    {
        this.zoneMode = zoneMode;

        if (zoneMode.zones == null)
        {
            zoneMode.zones = new List<InstanceZoneMode>();
        }

        foreach (var zone in zoneMode.zones)
        {
            TaskObjData task = new TaskObjData();
            task.Init(zone, zoneMode.mapName);
            tasks.Add(task);
        }
    }

    /// <summary>
    /// 生成关卡，当存档数据中未包含关卡时使用
    /// </summary>
    /// <param name="mapName"></param>
    public void Create(MapNameType mapName)
    {
        zoneMode = new InstanceZoneModeSet()
        {
            mapName = mapName,
            warningValue = 0,
            zones = new List<InstanceZoneMode>()
        };
        DataManager.Instance.AddZoneMode(zoneMode);
    }

    /// <summary>
    /// 更新50警戒值攻击boss记录
    /// </summary>
    public void UpdateAtkBoss(bool bAtkBoss)
    {
        zoneMode.bAtkBoss = bAtkBoss;
    }

    /// <summary>
    /// 获取50警戒值攻击boss记录
    /// </summary>
    public bool IsAtkBoss()
    {
        return zoneMode.bAtkBoss;
    }

    /// <summary>
    /// 更新100警戒值击杀boss记录
    /// </summary>
    public void UpdateKillBoss(bool bKillBoss)
    {
        zoneMode.bKillBoss = bKillBoss;
    }

    /// <summary>
    /// 获取100警戒值击杀boss记录
    /// </summary>
    public bool IsKillBoss()
    {
        return zoneMode.bKillBoss;
    }
    

    /// <summary>
    /// 更新警戒值
    /// </summary>
    /// <param name="addValue"></param>
    public void UpdateWarningValue(int addValue)
    {
        zoneMode.warningValue += addValue;
        if (zoneMode.warningValue > 100)
        {
            zoneMode.warningValue = 100;
        }
    }
    /// <summary>
    /// 关卡存档
    /// </summary>
    /// <returns></returns>
    public InstanceZoneModeSet GetZoneMode{
        get {
            return zoneMode;
        }
    }
    /// <summary>
    /// 生成一个任务
    /// </summary>
    public void CreateTask()
    {
        TaskObjData task = new TaskObjData();
        task.Create(zoneMode.warningValue, zoneMode.mapName);
        tasks.Add(task);
    }

    public TaskObjData CreateTask(int nMaxWarningValue, bool bCreateRandomBoss, bool bCreateFinalBoss)
    {
        TaskObjData task = new TaskObjData();
        bool bKillBoss = false;
        if(zoneMode.warningValue >= 100 && !bCreateFinalBoss)
        {
            if(zoneMode.bKillBoss)
                bKillBoss = true;
        }
        else if(zoneMode.warningValue >= 50 && !bCreateRandomBoss)
        {
            if(zoneMode.bAtkBoss)
                bKillBoss = true;
        }

        Dictionary<int, TaskInfo> tCurTaskMap = new Dictionary<int, TaskInfo>();
        foreach(TaskObjData t in tasks)
        {
            tCurTaskMap.Add(t.GetTaskId(), t.GetTaskInfo());
        }
        task.Create(zoneMode.warningValue, zoneMode.mapName, bKillBoss, nMaxWarningValue, tCurTaskMap);
        tasks.Add(task);

        return task;
    }

    public void CreateBossTask()
    {
        TaskObjData task = new TaskObjData();
        task.CreateBoss(zoneMode.mapName);
        tasks.Add(task);
    }

    public void CreateRandomBossTask()
    {
        TaskObjData task = new TaskObjData();
        task.CreateRandomBoss(zoneMode.mapName);
        tasks.Add(task);
    }

    /// <summary>
    /// 获取关卡中的所有任务
    /// </summary>
    /// <returns></returns>
    public List<TaskObjData> GetTaskObjDatas()
    {
        return tasks;
    }

    /// <summary>
    /// 清除关卡中的所有任务
    /// </summary>
    /// <returns></returns>
    public void CleanAllTask()
    {
        tasks.Clear();
    }

    /// <summary>
    /// 获取关卡名
    /// </summary>
    /// <returns></returns>
    public MapNameType GetMapName()
    {
        return zoneMode.mapName;
    }

    /// <summary>
    /// 获取警戒值
    /// </summary>
    /// <returns></returns>
    public int GetWarningValue()
    {
        return zoneMode.warningValue;
    }
}