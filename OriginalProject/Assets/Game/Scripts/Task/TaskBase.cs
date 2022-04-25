using Datas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 任务基类
/// </summary>
public abstract class TaskBase : MonoBehaviour
{
    public TaskProgress taskShow;
    public TaskObjData data;
    public TaskTipsItem taskTips;
    protected bool isFinished;
    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="mapData"></param>
    public abstract void Init(TaskObjData _data, N_MapData mapData);
    public void RegistTaskTips(TaskTipsItem _item) {
        taskTips = _item;
    }
    /// <summary>
    /// 更新任务状态
    /// </summary>
    /// <param name="mapData"></param>
    public abstract void UpdateTaskStatus(N_MapData mapData);
}
