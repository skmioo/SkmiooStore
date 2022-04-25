using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// 房间--- 
/// </summary>
public class RoomSet : MonoBehaviour
{
    public GameObject leftTriggerObj;
    public GameObject rightTriggerObj;

    /// <summary>
    /// 房间是否已被探索
    /// </summary>
    public bool isOn;
    bool onKey;

    [HideInInspector]
    public int key;
    public void InitRoom(int _key)
    {
        key = _key;

    }

    //MiniMapController注册
    public static Action<int> EnterRoom;
    //TaskPropgress 注册
    public static Action _EnterRoom;


    //弃用这个方法
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (onKey)
            return;

        Debug.Log($"检测到{collision.gameObject.name}进入房间");
        if (collision.name == "heroTeamControllers")
        {
            if (EnterRoom != null && _EnterRoom != null)
            {
                isOn = true;
                onKey = true;

                EnterRoom(key);
                _EnterRoom();
            }
        }

    }    

    private void OnTriggerExit2D(Collider2D collision)
    {
        onKey = false;
    }

}