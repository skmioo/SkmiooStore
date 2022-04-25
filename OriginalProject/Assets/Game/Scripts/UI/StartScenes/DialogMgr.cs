using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DialogMgr
{
    private static DialogMgr _instance;
    public static DialogMgr Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new DialogMgr();
            }
            return _instance;
        }
    }
    public UnityEvent onEvOk = new UnityEvent();
    public UnityEvent onEvCancel = new UnityEvent();
    public string m_sDesc = "";

    public void OnBtnOk()
    {
        onEvOk.Invoke();
        ClearEvents();
    }

    public void OnBtnNot()
    {
        onEvCancel.Invoke();
        ClearEvents();
    }

    public string GetDesc()
    {
        return m_sDesc;
    }

    public void ClearEvents()
    {
        onEvOk.RemoveAllListeners();
        onEvCancel.RemoveAllListeners();
    }

    public void CreatePanel(string sDesc)
    {
        m_sDesc = sDesc;
        UIManager.Instance.PushPanel(UIPanelType.Dialog);

    }
}
