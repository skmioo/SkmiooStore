using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class MiniRoom : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerClickHandler
{
    //房间号码,必须和存档一致
    public int roomNum;
    //链接的房间
    public List<int> linkRooms;


    //MapController注册,点击后直接切换场景。  MiniMapController注册,点击后关闭所有房间可点击
    public static Action<MiniRoom> OnClickMiniRoom;
    //控制可点击的开关
    [HideInInspector]    
    public bool onClick;


    public void OnPointerClick(PointerEventData eventData)
    {
        if (onClick)
        {
            OnClickMiniRoom?.Invoke(this);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }
}
