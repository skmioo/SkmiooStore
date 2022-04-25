using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 预制体不会主动监听摄像机事件
/// </summary>
public class RoleCanvasSetCamera : MonoBehaviour
{
    private void Awake()
    {
        Canvas canvas = GetComponent<Canvas>();
        canvas.worldCamera = FightingCameraCon.Instance.mainCamera;
        //GameObject gtemp = GameObject.Find("Camera");
        //Camera camera = gtemp.GetComponent<Camera>();
        //if (camera != null)
        //{
        //    canvas.worldCamera = camera;
        //}
       
    }
}
