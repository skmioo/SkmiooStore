using System.Collections;
using System.Collections.Generic;
using Datas;
using UnityEngine;

/// <summary>
/// 扫荡
/// </summary>
public class Task_SaoDang : TaskBase
{
    private int enemyTotalCount;
    private int eliminateCount;
    private int index;

    public override void Init(TaskObjData _data, N_MapData mapData)
    {
        data = _data;
        enemyTotalCount = GetCurrentEnemyCount(mapData);
        eliminateCount = 0;
        taskShow.AddToTaskProgress(this);
        taskTips.UpdateTaskTips(SpliceString());
    }

    public override void UpdateTaskStatus(N_MapData mapData)
    {
        eliminateCount = enemyTotalCount - GetCurrentEnemyCount(mapData);
        taskTips.UpdateTaskTips(SpliceString());

        if (eliminateCount.Equals(enemyTotalCount) && !isFinished)
        {
            isFinished = true;
            taskTips.ShowFinishTip(true);
            taskShow.TaskFinished();
        }
    }

    private string SpliceString()
    {
        string stemp = $"{data.GetTaskDescribe()}";
        return  "消灭所有房间内的敌人 " + eliminateCount.ToString() + "/" + enemyTotalCount.ToString();
    }

    private int GetCurrentEnemyCount(N_MapData mapData)
    {
        return mapData.addRoomList.FindAll(s => s.addType.Equals(N_AddType.怪物)).Count;
    }
}
