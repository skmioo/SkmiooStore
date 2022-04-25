using System.Collections;
using System.Collections.Generic;
using Datas;
using UnityEngine;

public class Task_ZhenCha : TaskBase
{
    private int roomTotalCount;
    private int exploreCount;
    private int index;

    public override void Init(TaskObjData _data, N_MapData mapData)
    {
        data = _data;
        roomTotalCount = mapData.rooms.Count;
        exploreCount = GetExploreCount(mapData);
        taskShow.AddToTaskProgress(this);
        taskTips.UpdateTaskTips(SpliceString());
    }

    public override void UpdateTaskStatus(N_MapData mapData)
    {
        exploreCount = GetExploreCount(mapData);
        taskTips.UpdateTaskTips(SpliceString());

        if (exploreCount >= Mathf.FloorToInt(roomTotalCount * 0.9f) && !isFinished)
        {
            isFinished = true;
            taskTips.ShowFinishTip(true);
            taskShow.TaskFinished();
        }
    }

    private string SpliceString()
    {
        string stemp = $"{data.GetTaskDescribe()}";
        return "探索关卡内90%的房间 " + exploreCount.ToString() + "/" + roomTotalCount.ToString();
    }

    private int GetExploreCount(N_MapData mapData)
    {
        return mapData.rooms.FindAll(s => s.isExplore).Count;
    }
}
