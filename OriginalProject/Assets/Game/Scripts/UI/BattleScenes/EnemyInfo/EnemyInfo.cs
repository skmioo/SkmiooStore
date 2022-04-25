using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyInfo : MonoBehaviour
{
    static EnemyInfo _instance;
    public static EnemyInfo Instance
    {
        get { return _instance; }
    }


    #region 基础信息
    [Header("怪物基础属性")]
    public Image roleIcon;
    public Text roleName;
    public Text roleDoge;
    public Text roleSpeed;

    public Image hpp;
    public Text hpv;

    [Header("怪物抗性基础属性")]
    public Text roleVertigo;
    public Text rolePoison;
    public Text roleBleed;
    public Text roleDebuff;
    public Text rolePosition;

    #endregion

    EnemysTeamController enemysTeamController;
    private void Awake()
    {
        _instance = this;
       // BattleFlowController.Battle += BattleFlowController_Battle;
       // RoleUiController.RoleEnter += RoleUiController_RoleEnter;

        enemysTeamController = EnemysTeamController.Instance;
    }

    private void OnDestroy()
    {
        //RoleUiController.RoleEnter -= RoleUiController_RoleEnter;
    }

    private void BattleFlowController_Battle(bool obj)
    {

        //如果退出战斗, 信息面板是否也随之关闭？。。。不然显示会空置
    }


    /// <summary>
    /// 重置信息面板的显示
    /// </summary>
    /// <param name="number"></param>
    public void ResetInfo(int number) 
    {
        /*RoleBattleingData roleBattleingData = enemysTeamController.roleTeam[number];

        ObjLife objLife = roleBattleingData.objLife;

        objLife.roleData.Icon.LoadAssetAsync().Completed += go =>
        {
            roleIcon.sprite = go.Result;
        };
        roleName.text = objLife.roleData.name;
        roleDoge.text = $"闪避：{objLife.roleData.roleLife.dodge}";
        roleSpeed.text = $"速度：{objLife.roleData.roleLife.speed}";
        roleVertigo.text = $"眩晕 ：{objLife.roleData.roleLife.vertigo}";
        rolePoison.text = $"中毒 ：{objLife.roleData.roleLife.poison}";
        roleBleed.text = $"流血 ：{objLife.roleData.roleLife.bleed}";
        roleDebuff.text = $"减益 ：{objLife.roleData.roleLife.debuff}";
        rolePosition.text = $"位移 ：{objLife.roleData.roleLife.position}";

        hpp.fillAmount = objLife.GetNowHp() / objLife.GetHp();
        hpv.text = $"{objLife.GetNowHp()} / {objLife.GetHp()}";*/
    }

    private void RoleUiController_RoleEnter(ObjLife obj)
    {
        /*if (obj.roleData.roleType == RoleType.Hero)
        {
            return;
        }

        //enemyInfo.isOn = true;
        //enemyInfo.onValueChanged.Invoke(true);
        //enemyInfo.Select();
        ResetInfo(obj.battleingData.numInTeam);*/

    }


}
