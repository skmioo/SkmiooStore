using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 副本中的地图元素需要挂载该脚本用于销毁元素，由MapController动态实例化时挂载
/// </summary>
public class Child : MonoBehaviour
{
    public void DestoryMe()
    {
        Destroy(gameObject);
    }
}
