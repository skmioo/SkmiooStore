using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/// <summary>
/// UI事件管理系统  ,
/// </summary>
public class UIEventManager : EventTrigger
{
    public delegate void VoidDelegate(GameObject go);
    public delegate void VectorDelegate(GameObject go, Vector2 delta);
    public delegate RectTransform VectorPointer(GameObject go, PointerEventData pointerEventData);
    public delegate void VectorPointer2(GameObject go, PointerEventData pointerEventData);

    public VectorPointer2 onBeginDrag;
    public VoidDelegate onCancel;
    public VectorPointer onDrag;
    public VectorPointer2 onEndDrag;

    public VoidDelegate onEnter;
    public VoidDelegate onExit;
    public VoidDelegate onClick;

    public VoidDelegate onLeftClick;
    public VoidDelegate onRightClick;


    public VoidDelegate onClickDwon;
    public VoidDelegate onClickUp;

    bool isOnDrag;

    RectTransform dragTran = null;

    static public UIEventManager AddTriggersListener(GameObject go)
    {
        UIEventManager listener = go.GetComponent<UIEventManager>();
        if (listener == null) listener = go.AddComponent<UIEventManager>();
        return listener;
    }

    public override void OnPointerExit(PointerEventData eventData)
    {

        if (onExit != null)
        {
            onExit(gameObject);
        }
    }
    public override void OnPointerEnter(PointerEventData eventData)
    {

        if (onEnter != null)
        {
            onEnter(gameObject);
        }
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (isOnDrag)
            return;

        if (onClick != null)
        {
            onClick(gameObject);
        }

        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (onLeftClick != null)
            {
                onLeftClick(gameObject);
            }
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (onRightClick != null)
            {
                onRightClick(gameObject);
            }
        }
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);
        if (onBeginDrag != null) onBeginDrag.Invoke(gameObject, eventData);
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        isOnDrag = false;
        dragTran?.SetParent(transform);
        onEndDrag?.Invoke(gameObject, eventData);
        dragTran = null;
    }

    public static void OnDragFunc(GameObject inGo, VectorPointer inEvent)
    {
        UIEventManager listener = inGo.GetComponent<UIEventManager>();
        if (listener == null) listener = inGo.AddComponent<UIEventManager>();

        listener.onDrag = (go, eventData) => inEvent(go, eventData);
    }

    public override void OnDrag(PointerEventData eventData)
    {
        //正在拖拽的不出发其他事件
        isOnDrag = true;
        if (onDrag != null)
        {
            if (dragTran == null)
            {
                dragTran = onDrag(gameObject, eventData);
                if (dragTran == null) return;
                dragTran.SetParent(dragTran.root.transform);
            }

            Vector3 globalMousePos;
            if (RectTransformUtility.ScreenPointToWorldPointInRectangle(dragTran, eventData.position, eventData.pressEventCamera, out globalMousePos))
            {
                dragTran.position = globalMousePos;
            }
        }
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        onClickUp?.Invoke(gameObject);
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        onClickDwon?.Invoke(gameObject);
    }
}
