using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Datas;

/// <summary>
/// 准备阶段场景需要交给战斗场景的信息
/// </summary>
public static class BattleInfo
{
    //出征--出征的队伍，携带的道具--

    //这个值本身被干掉了--他的内容是gameobject，在场景被销毁时，跟着被销毁了
    //public static RoleItem_W[] roleItem_W;//!!不在用这个值
    //public static GameObject startRoom;

    //public static MapData mapData; //弃用

    //关卡及任务
    public static MapNameType MapName { get; set; } = MapNameType.镂空之地;
    public static TaskDifficulty TaskDifficulty { get; set; } = TaskDifficulty.艰难险阻;
    public static MapSizeType MapSize { get; set; } = MapSizeType.狭小;
    public static List<TaskObjData> TaskObjDatas = new List<TaskObjData>();//public static N_TaskType TaskType { get; set; } = N_TaskType.侦查;
    public static List<ObjData> OrnamentList { get; set; } = new List<ObjData>();

    /// <summary>
    /// 出征角色
    /// </summary>
    public static Dictionary<int, ObjLifeData> waitingTeams = new Dictionary<int, ObjLifeData>();

    /// <summary>
    /// 圣物属性
    /// </summary>
    public static SacredCombination sacredCombination;

    public static void SetSacredObjActions(SacredCombination sacredCombination)
    {
        BattleInfo.sacredCombination = sacredCombination;
    }
}

/// <summary>
/// 战斗场景需要交给城镇场景的信息
/// </summary>
public static class TownInfo
{
    #region 解救事件
    /// <summary>
    /// 解救事件列表
    /// </summary>
    private static List<RescueType> rescueTypes = new List<RescueType>();

    public static void ClearRescueType()
    {
        rescueTypes.Clear();
    }

    public static List<RescueType> GetRescueTypes()
    {
        return rescueTypes;
    }

    public static void AddRescueType(RescueType rescueType)
    {
        rescueTypes.Add(rescueType);
    }
    /// <summary>
    /// 是否存在指定的解救事件
    /// </summary>
    /// <returns></returns>
    public static bool ExistsRescueType(RescueType rescueType)
    {
        bool ishaved = rescueTypes.Exists(s => s == rescueType);
        return ishaved;
    }
    #endregion

    #region 带回的物品 - 已弃用[Obsolete]
    /*
    private static List<ObjData> objDataList = new List<ObjData>();
    public static void ClearObjDataList() { objDataList.Clear(); }
    /// <summary>
    /// 带回城镇的物品数据
    /// </summary>
    /// <returns></returns>
    public static List<ObjData> GetObjDataList()
    {
        return objDataList;
    }
    public static void AddObjDataToList(params ObjData[] datas)
    {
        if (datas == null || datas.Length <= 0) return;
        for(int i = 0;i  < datas.Length;++i) objDataList.Add(datas[i]);
    }
    /// <summary>
    /// 带回城镇物品测试
    /// </summary>
    public static void SaveToTownTest() {
        List<ObjData> data = GetObjDataList();
        for (int i = 0; i < data.Count; ++i)
        {
            switch (data[i].objType)
            {
                case ObjType.饰品: DataManager.Instance.AddOrnamentToMode(data[i]); break;
                case ObjType.圣物: DataManager.Instance.AddSacredToMode(new SacredObjData(new SacredMode() { id = data[i].id, isBePut = false, num = -1 }, data[i] as SacredData)); break;
            }
        }
        ClearObjDataList();
    }
    */
    #endregion
}