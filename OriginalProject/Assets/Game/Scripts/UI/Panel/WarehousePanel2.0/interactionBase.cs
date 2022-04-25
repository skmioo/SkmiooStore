using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class interactionBase : MonoBehaviour
{
    public HoverInfoUI hoverInfoUI;
    Vector3 startPos;
    UIEventManager eventMag;

    public abstract void init();

    protected virtual void Awake()
    {
        eventMag = UIEventManager.AddTriggersListener(gameObject);

        eventMag.onEnter = PointerEnter;
        eventMag.onExit = PointerExit;
		eventMag.onBeginDrag = beginDragEvent;
		eventMag.onDrag = dragEvent;
        eventMag.onEndDrag = endDragEvent;
        eventMag.onLeftClick = leftClick;

		init();
    }

    /// <summary>
    /// 鼠标进入事件
    /// </summary>
    /// <param name="go"></param>
    protected virtual void PointerEnter(GameObject go)
    {
        startPos = hoverInfoUI.transform.localPosition;
        hoverInfoUI.Show();
    }

    /// <summary>
    /// 鼠标离开
    /// </summary>
    /// <param name="go"></param>
    protected virtual void PointerExit(GameObject go)
    {
        ReputInfoUI();
        hoverInfoUI.gameObject.SetActive(false);
    }

    public virtual void ReputInfoUI()
    {
        hoverInfoUI.transform.SetParent(transform);
        hoverInfoUI.transform.localPosition = startPos;
    }

	/// <summary>
	/// 开始拖拽事件
	/// </summary>
	/// <param name="go"></param>
	/// <param name="pointerEventData"></param>
	public virtual void beginDragEvent(GameObject go, UnityEngine.EventSystems.PointerEventData pointerEventData) { }

	/// <summary>
	/// 停止拖拽事件
	/// </summary>
	/// <param name="go"></param>
	/// <param name="pointerEventData"></param>
	public virtual void endDragEvent(GameObject go, UnityEngine.EventSystems.PointerEventData pointerEventData) { }

    /// <summary>
    /// 拖拽事件
    /// </summary>
    /// <param name="inObj"></param>
    /// <param name="pointerEventData"></param>
    /// <returns></returns>
    public virtual RectTransform dragEvent(GameObject inObj, UnityEngine.EventSystems.PointerEventData pointerEventData) { return null; }

    /// <summary>
    /// 这里应该是拖拽释放对象(释放时鼠标所在的对象)
    /// </summary>
    /// <param name="inGO">拖拽对象</param>
    public virtual void EndDragFunc(GameObject inGo) { }

    /// <summary>
    /// 拖拽时函数，返回被拖拽对象
    /// </summary>
    /// <param name="inGo"></param>
    /// <returns></returns>
    public virtual RectTransform DragFunc(GameObject inGo) { return null; }

    public virtual void leftClick(GameObject inGo) { }
}
