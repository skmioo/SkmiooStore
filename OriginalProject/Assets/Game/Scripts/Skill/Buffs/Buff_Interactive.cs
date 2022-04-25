using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff_Interactive : MonoBehaviour
{
    public RectTransform rectTrans { get { return transform as RectTransform; } }
    [HideInInspector] public Buff_InteractiveGroup group;
    [HideInInspector] public BuffInfo goBuffInfo;
    int indexofGroup;
    string text;
    public void Initialized(BuffInfo _info, Buff_InteractiveGroup _group,int _indexof)
    {
        goBuffInfo = _info;
        group = _group;
        indexofGroup = _indexof;
        UIEventManager.AddTriggersListener(gameObject).onEnter = go => Show();
        UIEventManager.AddTriggersListener(gameObject).onExit = go => Hidden();
    }
    private void Show()
    {
        goBuffInfo.Show(text, () =>
        {
            goBuffInfo.rectTrans.anchoredPosition = new Vector2(group.rectTrans.anchoredPosition.x + ( rectTrans.sizeDelta.x + group.groupComponent.spacing) * indexofGroup, group.rectTrans.anchoredPosition.y) + new Vector2(goBuffInfo.rectTrans.sizeDelta.x / 2 + rectTrans.sizeDelta.x / 2, -goBuffInfo.rectTrans.sizeDelta.y / 2 - rectTrans.sizeDelta.y / 2);
            goBuffInfo.transform.localScale = Vector3.one;
        });
    }
    public void SetText(string str)
    {
        text = str;
    }
    private void Hidden()
    {
        goBuffInfo.Hidden(() =>
        {
            goBuffInfo.transform.localScale = Vector3.zero;
        });
    }
}
