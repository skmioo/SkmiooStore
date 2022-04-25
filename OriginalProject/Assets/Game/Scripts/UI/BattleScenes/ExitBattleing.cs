using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ExitBattleing : MonoBehaviour
{
    //在战斗中  ---撤退按钮显示,若未在战斗中 -- 退出按钮显示
    public Button exitBattleingBtn;
    public GameObject exitTips;

    ObjLife actionObjlife;
    private void Start()
    {
        BattleFlowController.Battle += CheckedBattleStatus;
        //HerosTeamController.Instance.roleGoAction += RoleAction;
        //HerosTeamController.Instance.roleEndAction += RoleEndAction;
    }

    private void OnDestroy()
    {
        BattleFlowController.Battle -= CheckedBattleStatus;
        //HerosTeamController.Instance.roleGoAction -= RoleAction;
        //HerosTeamController.Instance.roleEndAction -= RoleEndAction;
    }

    //切换了战斗状态
    private void CheckedBattleStatus(bool obj)
    {
        exitBattleingBtn.gameObject.SetActive(obj);
        exitTips.SetActive(false);
    }



    /// <summary>
    /// 撤离按钮被按下---  按钮注册
    /// </summary>
    public void exitBtnDwon()
    {
        Debug.Log("exitBtnDwon");
        if (!BattleFlowController.Instance.IsResponsePanel)
        {
            return;
        }
        AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
        bool exitSuccess = AnalysisProbability(50,100);
        if (exitSuccess)
        {
            //MapController.Instance.BackMapGroud();
            //MapController.Instance.Retreat();

            //EnemysTeamController.Instance.RemoveAll();

            BattleFlowController.Instance.ExitBattle();
           BattleFlowController.Instance.DelayAction(1f,DamageMorale);
            //退出战斗状态，通知删除角色
        }
        else
        {
            //撤退失败
            exitTips.SetActive(true);
            BattleFlowController.Instance.DelayAction(1f,OffTips);

            BattleFlowController.Instance.ExitBattleFail();
        }
    }

    /// <summary>
    /// 退出后对角色减少士气
    /// </summary>
    void DamageMorale()
    {
        /*foreach (var item in HerosTeamController.Instance.roleTeam)
        {
            //item.objLife.DamageSettlement(-20, DamagePackType.morale);
        }*/
    }

    void OffTips()
    {
        exitTips.SetActive(false);
    }

    bool AnalysisProbability(int bValue, int cValue)
    {
        float vr = Random.Range(0, cValue);
        if (bValue > vr)
        {
            return true;
        }
        return false;
    }


    private void RoleEndAction(ObjLife obj)
    {
        exitBattleingBtn.interactable = false;
    }

    private void RoleAction(ObjLife obj)
    {
        exitBattleingBtn.interactable = true;
        actionObjlife = obj;
    }
}
