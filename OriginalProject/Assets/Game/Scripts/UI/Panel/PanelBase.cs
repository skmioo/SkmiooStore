using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelBase : MonoBehaviour
{
    public virtual void SetPanel(bool isOpen)
    {
        if (isOpen) open();
        else close();
    }

    public virtual void open()
    {
        KeyEventController.Instance.onEscAction += close;
    }

    public virtual void close()
    {
        LoadModeData.Instance.saveData();
        KeyEventController.Instance.onEscAction -= close;
    }
}
