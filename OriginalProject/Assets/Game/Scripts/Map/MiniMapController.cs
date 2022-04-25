using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MiniMapController : MonoBehaviour
{
    
    public RectTransform mePos;
    public MiniRoom[] miniRooms;
    public MiniRouteSet[] miniRouteSets;

    Dictionary<int, MiniRouteSet> miniMapRouteDict = new Dictionary<int, MiniRouteSet>();
    Dictionary<int, MiniRoom> miniRoomDict = new Dictionary<int, MiniRoom>();


    //当前房间
    int meRoomNum;
    const float moveTiemer = 1;

    
    //这个被加载后,是不显示状态,故Awake与Start都不会启动
    public void InitMiniMap()
    {

        Route.EnterRoute += Route_EnterRoute;
        RoomSet.EnterRoom += RoomSet_EnterRoom;

        MiniRoom.OnClickMiniRoom += MiniRoom_OnClickMiniRoom;

        foreach (var item in miniRouteSets)
        {
            miniMapRouteDict.Add(item.setKey, item);
        }

        foreach (var item in miniRooms)
        {
            miniRoomDict.Add(item.roomNum, item);
        }

    }

    private void OnDestroy()
    {
        Route.EnterRoute -= Route_EnterRoute;
        RoomSet.EnterRoom -= RoomSet_EnterRoom;
    }


    private void RoomSet_EnterRoom(int obj)
    {
        //Test();
        Debug.Log("房间进入检测");
        MiniRoom room = miniRoomDict[obj];
        if (room == null)
        {
            miniRoomDict.Clear();
            //场景切换后报空,先这样处理一下
            foreach (var item in miniRooms)
            {
                miniRoomDict.Add(item.roomNum, item);
            }
        }
        try
        {
            mePos.SetParent(room.transform);
            mePos.DOLocalMove(Vector3.zero, moveTiemer);
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
        }
      

        meRoomNum = obj;
        OpenRommClick(room);

    }

    void OpenRommClick(MiniRoom room)
    {
        //打开房间的可点击
        foreach (var item in room.linkRooms)
        {
            miniRoomDict[item].onClick = true;
        }

        //加入点击提示？
    }

    private void Route_EnterRoute(int key,int num)
    {
        //所以这个道路key  大概会是  231  232 233 234  这样
        MiniRouteSet miniRouteSet = miniMapRouteDict[key];

        Transform miniRoute = miniRouteSet.GetRoute(num);
        if (miniRoute == null)
        {
            return;
        }
        mePos.SetParent(miniRoute);
        mePos.DOLocalMove(Vector3.zero, moveTiemer);
      
    }

    private void MiniRoom_OnClickMiniRoom(MiniRoom obj)
    {
        foreach (var item in miniRoomDict)
        {
            item.Value.onClick = false;
        }
        MapController.Instance.MiniRoom_OnClickMiniRoom(obj, meRoomNum);
    }

}

