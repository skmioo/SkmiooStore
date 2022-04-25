using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ReilcToggle : Toggle
{
    public GameObject titleObj;
    public int index;

    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
        titleObj.SetActive(true);
        titleObj.transform.SetParent(transform.root);
        titleObj.transform.SetAsLastSibling();
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);
        titleObj.transform.SetParent(transform);
        titleObj.SetActive(false);
    }
}
