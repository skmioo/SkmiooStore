using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyHoverInfo : HoverInfoUI
{
    [HideInInspector]
    public Transform parent;

    public override void Show()
    {
        gameObject.SetActive(true);
        transform.parent = parent.root;
    }

    public override void Hide()
    {
        gameObject.SetActive(false);
        transform.parent = parent;
    }
}
