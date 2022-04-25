using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Datas;

/// <summary>
/// 单个任务提示
/// </summary>
public class TaskTipsItem : MonoBehaviour
{
    public Text tipsContent;
    public RectTransform finishTip;
    //[HideInInspector]
    //public TaskKeys taskKeys;
    //public bool onKey
    //{
    //    get; private set;
    //}
    //public void InitTaskTips(TaskKeys _taskKeys)
    //{
    //    taskKeys = _taskKeys;

    //    tipsContent.text = taskKeys.Tips;
    //}
    public void UpdateTaskTips(string _tip)
    {
        tipsContent.text = _tip;
    }
    public void ShowFinishTip(bool isFinish) {
        finishTip.gameObject.SetActive(isFinish);
    }
    ///// <summary>
    ///// 正确的key
    ///// </summary>
    //public void OnKey()
    //{
    //    if (onKey)
    //    {
    //        return;
    //    }


    //    onKey = true;
    //    tipsContent.text = $"<color=#11EE3D>{taskKeys.Tips}</color>";
    //}


}
