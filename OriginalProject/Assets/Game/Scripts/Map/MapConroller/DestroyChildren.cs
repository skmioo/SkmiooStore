using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 副本中所有元素的父节点上挂载，由MapController在初始化地图时为showRooms挂载
/// </summary>
public class DestroyChildren : MonoBehaviour
{
    /// <summary>
    /// 广播销毁消息
    /// </summary>
    public void BroadcastMessageToDestroy()
    {
        BroadcastMessage("DestoryMe", SendMessageOptions.DontRequireReceiver);
    }
}
