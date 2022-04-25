using System.Collections;
using System.Collections.Generic;
using Datas;
using UnityEngine;

public class Task_JiShaBoss : TaskBase
{
    /// <summary>
    /// 目标
    /// </summary>
    private int bossTotalCount;
    /// <summary>
    /// 当前进度
    /// </summary>
    private int eliminateCount;
    private int index;

    public override void Init(TaskObjData _data, N_MapData mapData)
    {
        data = _data;
        bossTotalCount = GetCurrentBossCount(mapData);
        eliminateCount = 0;
        taskShow.AddToTaskProgress(this);
        taskTips.UpdateTaskTips(SpliceString());
    }

    public override void UpdateTaskStatus(N_MapData mapData)
    {
       
        eliminateCount = bossTotalCount - GetCurrentBossCount(mapData);
        taskTips.UpdateTaskTips(SpliceString());

        if (eliminateCount.Equals(bossTotalCount) && !isFinished)
        {
            isFinished = true;
            taskTips.ShowFinishTip(true);
            taskShow.TaskFinished();
        }
    }

    private string SpliceString()
    {
        string stemp = $"{data.GetTaskDescribe()}";
        return "击杀boss " + eliminateCount.ToString() + "/" + bossTotalCount.ToString();
    }

    private int GetCurrentBossCount(N_MapData mapData)
    {
        return mapData.addRoomList.FindAll(s => s.addType.Equals(N_AddType.怪物) && s.roomIndex.Equals(mapData.rooms.FindIndex(r => r.roomType.Equals(N_MiniMapRoomType.Boss房间)))).Count;
    }
}
