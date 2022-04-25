using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragPanelBase : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerDownHandler
{
    public RectTransform dragTarget;
    Vector2 posOffset;

    public void OnBeginDrag(PointerEventData eventData)
    {
        posOffset = eventData.position - dragTarget.anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        dragTarget.anchoredPosition = eventData.position - posOffset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        dragTarget.parent.SetAsLastSibling();
    }
}
