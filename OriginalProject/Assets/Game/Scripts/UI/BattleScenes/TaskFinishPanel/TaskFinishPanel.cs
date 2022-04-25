using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskFinishPanel : MonoBehaviour
{
    public RectTransform panel;
    public Settlement settlementScript;
    public Button backBtn, continuBtn;
    private void Awake()
    {
        backBtn.onClick.AddListener(backBtnClick);
        continuBtn.onClick.AddListener(continuBtnClick);
    }
    void backBtnClick() {
        Hide();
        settlementScript.ShowSettlement(false);
    }
    void continuBtnClick() {
        Hide();
    }
    public void Show()  {
        if (panel.gameObject.activeSelf) return;
        panel.gameObject.SetActive(true);
        BattleFlowController.Instance.IsInteracting = true;
        BattleFlowController.Instance.IsBattling = true;
    }
    public void Hide() {
        if (!panel.gameObject.activeSelf) return;
        panel.gameObject.SetActive(false);
        BattleFlowController.Instance.IsInteracting = false;
        BattleFlowController.Instance.IsBattling = false;
    }
}
