using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static KeyController;

/// <summary>
/// 按键选项控制类
/// </summary>
public class KeyEventController : MonoSingleton<KeyEventController>
{
    protected override bool global => true;

    //esc事件
    public System.Action onEscAction;
    public void GoToTestScene() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Test");
    }
  
    private void Update()
    {
        // if (Input.anyKeyDown)
        // {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            int nStackCount = UIManager.Instance.GetStackCount();
            if (nStackCount > 0)
            {
                UIManager.Instance.PopPanel();
            }
            else
            {
                bool bCanExitOpenVideo = AudioManager.Instance.GetPlayOpenVideo();
                if(bCanExitOpenVideo)
                {
                    VideoPalyControl.Instance.OnClose();
                    return;
                }

                // int nBuildStackCount = UIManager.Instance.GetBuildStackCount();
                // if(nBuildStackCount > 0)
                //     UIManager.Instance.PopBuildPanel();
                // else
                if (onEscAction == null)
                    UIManager.Instance.PushPanel(UIPanelType.SettingPanel);
            }

            //esc广播
            onEscAction?.Invoke();

            return;
        }

        Dictionary<KeyEvent, KeyCode> keyDictionary = KeyController.GetKeyDictionary();
        for (int i = 0; i < keyDictionary.Count; i++)
        {
            KeyEvent nKeyEventIndex = (KeyEvent)i;
            if (Input.GetKeyDown(keyDictionary[nKeyEventIndex]))
            {
                switch (nKeyEventIndex)
                {
                    // case KeyEvent.打开帮助页面:
                    //     OpenHelpPage();
                    //     break;
                    // case KeyEvent.查看英雄人物页:
                    //     ShowRoleInfoPanel();
                    //     break;
                    // case KeyEvent.切换到上一个英雄:
                    //     SwitchLastHero();
                    //     break;
                    // case KeyEvent.切换到下一个英雄:
                    //     SwitchNextHero();
                    //     break;
                    case KeyEvent.向左移动:
                        MoveTo(MoveTeam.MoveDirect.left);
                        break;
                    case KeyEvent.向右移动:
                        MoveTo(MoveTeam.MoveDirect.right);
                        break;
                    case KeyEvent.快速施放第1个技能:
                        UseSkill(0);
                        break;
                    case KeyEvent.快速施放第2个技能:
                        UseSkill(1);
                        break;
                    case KeyEvent.快速施放第3个技能:
                        UseSkill(2);
                        break;
                    case KeyEvent.快速施放第4个技能:
                        UseSkill(3);
                        break;
                    case KeyEvent.快速施放士气技能:
                        UseMoralSkill();
                        break;
                    case KeyEvent.换位:
                        TranspositionSkill();
                        break;
                    case KeyEvent.全部拿走战利品:
                        GetAllSpoils();
                        break;
                    // case KeyEvent.切换地图背包:
                    //     ChangeMapBackpack();
                    //     break;
                    case KeyEvent.进入下一个房间or与交互物互动:
                        IntoNextRoom();
                        break;
                }
                break;
            }
            else if (Input.GetKeyUp(keyDictionary[nKeyEventIndex]))
            {
                switch (nKeyEventIndex)
                {
                    case KeyEvent.向左移动:
                        MoveEnd();
                        break;
                    case KeyEvent.向右移动:
                        MoveEnd();
                        break;
                }
            }
        }
        // }
    }
    /// <summary>
    /// 打开帮助页面
    /// </summary>
    private void OpenHelpPage()
    {
        Debug.Log("打开帮助页面");
    }
    private void ShowRoleInfoPanel()
    {
        if (BattleFlowController.Instance == null) return;
        return;
        BattleFlowController.Instance.ShowRoleInfoPanelOfKeyDown();
    }
    private void SwitchNextHero()
    {
        if (BattleFlowController.Instance == null) return;
        BattleFlowController.Instance.SwitchNextHeroOfKeyDown();
    }
    private void SwitchLastHero()
    {
        if (BattleFlowController.Instance == null) return;
        BattleFlowController.Instance.SwitchLastHeroOfKeyDown();
    }
    private void MoveTo(MoveTeam.MoveDirect direct)
    {
        if (MoveTeam.Instance == null) return;
        MoveTeam.Instance.MoveTo(direct);
    }
    private void MoveEnd()
    {
        if (MoveTeam.Instance == null) return;
        MoveTeam.Instance.MoveEnd();
    }

    private void UseSkill(int skillIndex)
    {
        if (BattleFlowController.Instance == null) return;
        BattleFlowController.Instance.PanelClickEvent(PanelClickType.技能, skillIndex);
    }

    private void UseMoralSkill()
    {
        if (BattleFlowController.Instance == null) return;
        BattleFlowController.Instance.PanelClickEvent(PanelClickType.士气技能);
    }

    private void TranspositionSkill()
    {
        if (BattleFlowController.Instance == null) return;
        BattleFlowController.Instance.TranspositionSkillOfKeyDown();
    }
    private void GetAllSpoils()
    {
        if (BattleFlowController.Instance == null) return;
        BattleFlowController.Instance.kanpsack.GetAllSpoilsOfKeyDown();
    }

    UnityEngine.UI.Toggle backpackToggle;
    UnityEngine.UI.Toggle kanpsackToggle;
    private void ChangeMapBackpack()
    {
        if (BattleFlowController.Instance == null) return;

        if (backpackToggle == null)
        {
            backpackToggle = GameObject.Find("MapT").GetComponent<UnityEngine.UI.Toggle>();
            kanpsackToggle = GameObject.Find("KnapsackT").GetComponent<UnityEngine.UI.Toggle>();
        }

        if (!backpackToggle.isOn) backpackToggle.isOn = true;
        else if (!kanpsackToggle.isOn) kanpsackToggle.isOn = true;
    }

    private void IntoNextRoom()
    {
        if (MapController.Instance == null) return;
        MapController.Instance.IntoRoomOrInteractiveOfKeyDown();
    }

}
