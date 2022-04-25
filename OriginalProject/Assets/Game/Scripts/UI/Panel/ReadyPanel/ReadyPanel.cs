using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyPanel : MonoBehaviour
{
    public ReadyMapCtrl[] readyMapAry;
    public ReadyTaskCtrl readyTask;
    List<ZoneObjData> zoneAry;
    List<List<TaskObjData>> taskAry;

    bool isInit = false;

    public void open()
    {
        init();
    }

    void init()
    {
        NewbieGuideMag.Instance.triggerGuide(GuideDataSet.guideEnum.inGoBattle);
        if (isInit) return;

        randomTask();
        readyMapAry[0].clickSmall(0);

        TaskObjData tempTask = null;
        for (int i = 0; i < readyMapAry.Length; i++)
        {
            readyMapAry[i].open(i);
            readyMapAry[i].setBigData(zoneAry[i].GetMapName().ToString(), zoneAry[i].GetWarningValue());
            readyMapAry[i].setWarningValue(zoneAry[i].GetWarningValue());

            for (int i2 = 0; i2 < readyMapAry[i].smallMap.Length; i2++)
                if (taskAry[i].Count > i2)
                {
                    tempTask = taskAry[i][i2];
                    readyMapAry[i].setSmallData(i2, tempTask, true, clickTask);
                }
                else { readyMapAry[i].setSmallData(i2, false); }
            //readyMapAry[i].setWarningValue(Random.Range(0, 100));
        }
        readyTask.setData(taskAry[0][0], zoneAry[0]);
        clearOther(0);

        isInit = true;
    }
    /// <summary>
    /// 点击选择任务
    /// </summary>
    /// <param name="inData"></param>
    /// <param name="inIndex"></param>
    void clickTask(TaskObjData inData, int inIndex, int inTaskIndex)
    {
        AudioManager.Instance.PlayAudio(AudioName.Select_Level_mono, AudioType.Common);
        ZoneObjData zoneObjData = null;
        if(zoneAry.Count > inIndex)
            zoneObjData = zoneAry[inIndex];

        readyTask.setData(inData, zoneObjData, inIndex, inTaskIndex);
        clearOther(inIndex);
    }

    void randomTask()
    {
        zoneAry = DataManager.Instance.GetZoneObj();
        if (zoneAry.Count == 0)
        {
            creatorTask(MapNameType.冥河矿洞);
            creatorTask(MapNameType.镂空之地);
            zoneAry = DataManager.Instance.GetZoneObj();
        }
        int nMaxWarningValue = 0;
        for (int i = 0; i < zoneAry.Count; i++)
        {
            int nWarningValue = zoneAry[i].GetWarningValue();
            if(nWarningValue > nMaxWarningValue)
            {
                nMaxWarningValue = nWarningValue;
            }
        }
        
        int nEasyTaskIndex = Random.Range(0,2);
        taskAry = new List<List<TaskObjData>>();
        int nLimitMinTaskCount = 2;
        int nLimitMaxTaskCount = 4;
        int nLimitTotalTaskCount = 6;
        for (int i = 0; i < zoneAry.Count; i++)
        {
            taskAry.Add(zoneAry[i].GetTaskObjDatas());

            if (taskAry[i].Count == 0)
            {
                int nCurTaskCount = 0;
                int nMaxTaskCount = nLimitMaxTaskCount;
                int nMinTaskCount = nLimitMinTaskCount;
                if(zoneAry[i].GetWarningValue() == 100 && !zoneAry[i].IsKillBoss())
                {
                    nCurTaskCount += 1;
                    zoneAry[i].CreateBossTask();
                }
                else if(zoneAry[i].GetWarningValue() >= 50 && !zoneAry[i].IsAtkBoss())
                {
                    nCurTaskCount += 1;
                    zoneAry[i].CreateRandomBossTask();
                    zoneAry[i].UpdateAtkBoss(true);
                }

                if(nEasyTaskIndex == i)
                {
                    zoneAry[i].CreateTask();
                    nCurTaskCount += 1;
                }
                nMaxTaskCount -= nCurTaskCount;
                nMinTaskCount -= nCurTaskCount;
                
                int nRandomTaskCount = 0;
                if(i == zoneAry.Count - 1)
                {
                    nRandomTaskCount = nLimitTotalTaskCount - nCurTaskCount;
                    nRandomTaskCount = Mathf.Max(nRandomTaskCount, nMinTaskCount);
                    nRandomTaskCount = Mathf.Min(nRandomTaskCount, nMaxTaskCount);
                }
                else
                {
                    nRandomTaskCount = Random.Range(nMinTaskCount, nMaxTaskCount + 1);
                }
                nCurTaskCount += nRandomTaskCount;
                bool bCreateFinalBoss = false;
                bool bCreateRandomBoss = false;
                for(int j = 1; j <= nRandomTaskCount; j++)
                {
                    TaskObjData task = zoneAry[i].CreateTask(nMaxWarningValue, bCreateRandomBoss, bCreateFinalBoss);
                    if(task.GetTaskType() == N_TaskType.随机boss)
                    {
                        bCreateRandomBoss = true;
                    }
                    else if(task.GetTaskType() == N_TaskType.固定boss)
                    {
                        bCreateFinalBoss = true;
                    }
                }
                taskAry[i] = zoneAry[i].GetTaskObjDatas();

                nLimitTotalTaskCount -= nCurTaskCount;
            }

        }
    }

    void creatorTask(MapNameType inMapName)
    {
        Datas.InstanceZoneModeSet tempZone = new Datas.InstanceZoneModeSet()
        {
            mapName = inMapName,
            warningValue = 0,
            zones = new List<Datas.InstanceZoneMode>()
        };
        DataManager.Instance.AddZoneMode(tempZone);

        //TaskDifficulty taskDifficulty = TaskDifficulty.人迹罕至;
        //MapSizeType mapSize = MapSizeType.狭小;

        //taskData = DataManager.Instance.CreateTaskData(taskDifficulty, mapSize);
        //taskInfo = DataManager.Instance.CreateTaskInfo(mapName, taskData.taskType);
        //taskReward = DataManager.Instance.GetTaskReward(taskDifficulty, mapSize);
        //taskRewardResource = DataManager.Instance.GetTaskRewardResource(mapName);

        //taskMode = new InstanceZoneMode()
        //{
        //    taskType = taskData.taskType,
        //    taskId = taskInfo.id,
        //    mapSize = mapSize,
        //    taskDifficulty = taskDifficulty
        //};
    }

    void clearOther(int inIndex)
    {
        for (int i = 0; i < readyMapAry.Length; i++)
            if (inIndex != i)
                readyMapAry[i].clearClick();
    }

    //增加警戒值
    public void AddWarning()
    {
        for (int i = 0; i < zoneAry.Count; i++)
        {
            zoneAry[i].UpdateWarningValue(5);
            int nValue = zoneAry[i].GetWarningValue();
            readyMapAry[i].setWarningValue(nValue);
        }
    }

    //刷新任务
    public void RefreshTask()
    {
        for (int i = 0; i < zoneAry.Count; i++)
        {
            zoneAry[i].CleanAllTask();
        }
        isInit = false;
        init();
    }
    
}
