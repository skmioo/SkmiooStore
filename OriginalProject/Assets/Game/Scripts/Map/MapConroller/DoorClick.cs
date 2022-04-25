using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static BattleFlowController;
using System.Linq;
using DG.Tweening;
using static FightingCameraCon;

/// <summary>
/// 副本中门的点击事件，由MapController实例化门预制体时挂载
/// </summary>
public class DoorClick : MonoBehaviour, IPointerClickHandler
{
    public MapController mapController;
    public int roomIndex;
    private const float BoxSizeX = 0.16f;
    private const float BoxSizeY = 0.16f;

    public Vector2 BoxSize { get { return new Vector2(BoxSizeX * 22, BoxSizeY * 22); } }

    public void OnPointerClick(PointerEventData eventData)
    {
        mapController.PlayEntryRoomAni(roomIndex, transform.position);
    }



    public void SetDoorClickableTrue()
    {
        gameObject.AddComponent<BoxCollider2D>().size = new Vector2(BoxSizeX, BoxSizeY);
    }

    public void SetDoorClickableFalse()
    {
        Destroy(gameObject.GetComponent<BoxCollider2D>());
    }
    /// <summary>
    /// 响应按键触发
    /// </summary>
    public void IntoRoomOfKeyDown()
    {
        mapController.PlayEntryRoomAni(roomIndex, transform.position);
    }

}
