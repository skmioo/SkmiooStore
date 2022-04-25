using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buff_Sacred : MonoBehaviour
{
    public BuffInfo goBuffInfo;
    public RectTransform rectTrans { get { return transform as RectTransform; } }
    private void Start()
    {
        if (BattleInfo.sacredCombination == null || BattleInfo.sacredCombination.objActions == null || BattleInfo.sacredCombination.objActions.Count == 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            UIEventManager.AddTriggersListener(gameObject).onEnter = go => Show();
            UIEventManager.AddTriggersListener(gameObject).onExit = go => Hidden();
        }
    }

    private void Show()
    {
        string str = $"祈祷生效中\n" + BattleInfo.sacredCombination.ObjActionsToString();
        str = str.Replace("$", "\n");
        goBuffInfo.Show(str, () => {
            goBuffInfo.rectTrans.anchoredPosition = rectTrans.anchoredPosition + new Vector2(goBuffInfo.rectTrans.sizeDelta.x/2 + rectTrans.sizeDelta.x/2, -goBuffInfo.rectTrans.sizeDelta.y/2 - rectTrans.sizeDelta.y / 2);
           // goBuffInfo.transform.localPosition = new Vector3(-638, 258);
            goBuffInfo.transform.localScale = Vector3.one;
        });
    }

    private void Hidden()
    {
        goBuffInfo.Hidden(()=> {
            goBuffInfo.transform.localScale = Vector3.zero;
        });
    }
}
