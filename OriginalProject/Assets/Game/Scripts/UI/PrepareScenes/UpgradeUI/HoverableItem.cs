using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoverableItem : MonoBehaviour
{
    public HoverInfoUI hoverInfoUI;
    private Vector3 startPos;
    

    protected virtual void Awake()
    {
        UIEventManager.AddTriggersListener(gameObject).onEnter = PointerEnter;
        UIEventManager.AddTriggersListener(gameObject).onExit = PointerExit;
    }

    protected virtual void PointerEnter(GameObject go)
    {
        startPos = hoverInfoUI.transform.localPosition;
    }

    protected virtual void PointerExit(GameObject go)
    {
        
    }

    public virtual void ReputInfoUI()
    {
        hoverInfoUI.transform.SetParent(transform);
        hoverInfoUI.transform.localPosition = startPos;
    }

    /// <summary>
    /// 这里应该是拖拽释放对象(释放时鼠标所在的对象)
    /// </summary>
    /// <param name="inGO">拖拽对象</param>
    public virtual void EndDragFunc(GameObject inObj) { }
}
