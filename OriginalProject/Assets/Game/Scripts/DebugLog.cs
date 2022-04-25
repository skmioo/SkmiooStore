using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugLog : MonoBehaviour
{
    public static DebugLog Instance { get; private set; }

    public GameObject goScrollView;
    public Text txtLog;

    private void Awake()
    {
        Instance = this;
    }

    public void BtnClickDebugLog()
    {
        goScrollView.SetActive(!goScrollView.activeSelf);
    }

    public void BtnClickClear()
    {
        txtLog.text = string.Empty;
    }

    public void AddLog(string str)
    {
        txtLog.text += str;
    }
}
