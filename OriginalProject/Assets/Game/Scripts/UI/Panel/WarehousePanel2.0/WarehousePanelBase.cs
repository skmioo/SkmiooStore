using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WarehousePanelBase : PanelBase
{
    public Transform panelRoot;

    bool isFading;
    RectTransform PanelRect => panelRoot.GetComponent<RectTransform>();

    public void open()
    {
        if (!isFading)
        {
            isFading = true;
            panelRoot.gameObject.SetActive(true);
            PanelRect.DOScale(Vector3.one, 0.3f).onComplete = () =>
            {
                isFading = false;
                
            };
        }
    }

    public void close()
    {
        if (!isFading)
        {
            isFading = true;
            PanelRect.DOScale(Vector3.zero, 0.15f).onComplete = () =>
            { isFading = false; panelRoot.gameObject.SetActive(false); };
        }
    }
}
