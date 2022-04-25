using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Datas;
using System;
using DG.Tweening;
using UnityEngine.UI;

/// <summary>
/// 任务进度，
/// </summary>
public class TaskProgress : MonoBehaviour
{
    static TaskProgress _instance;
    public static TaskProgress Instance
    {
        get { return _instance; }
    }
   
    public GameObject fleeButton;
    /// <summary>
    /// 任务完成 退出按钮
    /// </summary>
    public GameObject exitButton;

    public GameObject taskTipsItem;
    public Transform taskTipsBox;
    public TaskFinishPanel taskFinshPanel;

    //临时调试用
    // int taskID = 1011101;
    // public TaskReward taskData;

    //Dictionary<int, TaskReward> taskDataDict = new Dictionary<int, TaskReward>();
    //Dictionary<int, TaskKeys> taskKeyDict = new Dictionary<int, TaskKeys>();
    public List<TaskBase> tasks = new List<TaskBase>();
   // public  List<TaskTipsItem> taskTipsItems = new List<TaskTipsItem>();

    private void Awake()
    {       
        _instance = this;
        RoomSet._EnterRoom += RoomSet_EnterRoom;
    }

    private void Start()
    {
        SwitchExitButton(false);
        SetDict();
        //LoadTask();
        taskTipsBox.DOScaleY(1, 0.3f);
    }

    public void AddToTaskProgress(TaskBase task)// string str)
    {
        var item = Instantiate(taskTipsItem, taskTipsBox).GetComponent<TaskTipsItem>();
        task.RegistTaskTips(item);
        tasks.Add(task);
         
       // taskTipsItems.Add(item);
       // item.UpdateTaskTips(str);
    }

    //public void UpdateText(int index, string str)
    //{
    //    texts[index].text = str;
    //}
    /// <summary>
    /// 任务完成
    /// </summary>
    public void TaskFinished()
    {
        taskFinshPanel.Show();
        Debug.Log("测试-TaskFinished");
        SwitchExitButton(true);
    }

    void SetDict()
    {
        DataSetItem data = DataManager.Instance.GetData("TaskData");
        TaskDataSet taskDataSet = data.scriptableObject as TaskDataSet;

        foreach (var item in taskDataSet.taskDatas)
        {
            //taskDataDict.Add(item.id, item);
        }

    }

    //装载任务
   // void LoadTask()
    //{
        //taskData = taskDataDict[taskID];

        //foreach (var item in taskData.taskKeys)
        //{      
        //    GameObject go = Instantiate(taskTipsItem, taskTipsBox);
        //    TaskTipsItem _taskTips = go.GetComponent<TaskTipsItem>();
        //    _taskTips.InitTaskTips(item);

        //    taskTipsItems.Add(_taskTips);
        //}
   // }
    
    /// <summary>
    /// 插入一把钥匙
    /// 这个钥匙大部分为AddRoom的ID，在交互完成,或战斗结束时触发,也可以为道具ID
    /// </summary>
    /// <param name="taskKey">任务的钥匙</param>
    public void GetTaskKey(int taskKey)
    {
        //foreach (var item in taskTipsItems)
        //{
        //    if (item.taskKeys.taskKey == taskKey)
        //    {
        //        item.OnKey();
        //        TimiShow();
        //        break;
        //    }
        //}

        //CheckAllOn();
        //CheckExitButton(true);
    }

    /// <summary>
    /// 查所是否已完成所有任务条件
    /// </summary>
    void CheckAllOn()
    {
        //看看还有没有没完成的任务目标
        //foreach (var item in taskTipsItems)
        //{
        //    if (!item.onKey)
        //    {
        //        return;
        //    }
        //}

        //SwitchExitButton(true);
    }

    /// <summary>
    /// 切换退出按钮
    /// </summary>
    /// <param name="isOver">任务是否结束 -- true = 完成，false = 未完成</param>
    void SwitchExitButton(bool isOver)
    {
        fleeButton.SetActive(!isOver);
        exitButton.SetActive(isOver);
    }
    public void SetCanInteracting(bool canInteract)
    {
        if (BattleFlowController.Instance)
        {
            BattleFlowController.Instance.IsInteracting = canInteract;
        }
    }
    #region 探索房间进度监听
    private void RoomSet_EnterRoom()
    {
        //foreach (var item in taskTipsItems)
        //{
        //    if (item.taskKeys.taskKeyType == TaskKeyType.探索进度)
        //    {
        //        if (CheckRoomOnCount() > item.taskKeys.taskKey)
        //        {
        //            item.OnKey();

        //            CheckAllOn();
        //            TimiShow();
        //        }
        //    }
        //}
    }


    /// <summary>
    /// 查有多少房间处于已探索的状态
    /// </summary>
   int CheckRoomOnCount()
   {
        int onCount = 0;
        foreach (var item in MapController.Instance.roomSetDict)
        {
            if (item.Value.isOn)
            {
                onCount++;
            }
        }

        float v = (float)onCount / (float)MapController.Instance.roomSetDict.Count;

        return Mathf.FloorToInt(v * 100);
    }

    #endregion

    void TimiShow()
    {
        TipsShow();
        Invoke("TipsOff", 3);
    }

    public void TipsShow()
    {
        return;
        taskTipsBox.DOScaleY(1, 0.3f);
    }

    public void TipsOff()
    {
        return;
        taskTipsBox.DOScaleY(0, 0.3f);
    }
}


