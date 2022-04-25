using Datas;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

/// <summary>
/// 英雄队伍的控制器
/// </summary>
public class HerosTeamController : RoleTeamController
{   
    static HerosTeamController _instance;

    public static HerosTeamController Instance { get { return _instance; } }

    Dictionary<int, RoleData> herosDic = new Dictionary<int, RoleData>();
    //角色存档数据应该在战斗等待界面取出，临时放在这里
    // Dictionary<int, HerosMode> heroMode = new Dictionary<int, HerosMode>();
    //角色队伍信息在战斗等待界面封包，临时放在这里
    
    //int[] testHerosTeam = { 100001, 100002, 100004, 100008 };


    public Dictionary<int, OtherSkillData> otherSkillDict = new Dictionary<int, OtherSkillData>(); 
    private void Awake()
    {
        _instance = this;
        
    }
    
    private void Start()
    {
        //Invoke("ReGo", 3);
        ReGo();      
    }

    #region 战斗相关
    void ReGo()
    {

        //heroOrEnemy = true;
        DataSetItem dataSet = DataManager.Instance.GetData("RoleData");
        RoleDataSet roleData = dataSet.scriptableObject as RoleDataSet;

        foreach (var item in roleData.heroData)
        {
            herosDic.Add(item.id, item);
        }

        ModeData modeData = DataManager.Instance.modeData;


        DataSetItem data = DataManager.Instance.GetData("SkillData");
        SkillDataSet skillData = data.scriptableObject as SkillDataSet;

        foreach (var item in skillData.otherSkills)
        {
            otherSkillDict.Add(item.id, item);
        }


        RestTame();
    }

    //重置队伍
    protected void RestTame()
    {
        //roleTeam.Clear();
        //for (int i = 0; i < testHerosTeam.Length; i++)
        //{
        //    int _id = testHerosTeam[i];
        //    if (!herosDic.ContainsKey(_id))
        //    {
        //        Debug.Log($"提供的英雄存档数据ID{_id}在英雄基础数据中找不到");
        //        return;
        //    }

        //    if (!heroMode.ContainsKey(_id))
        //    {
        //        Debug.Log($"提供的英雄存档数据ID{_id}在英雄存档数据中找不到");
        //        return;
        //    }

        //    CreateRole(heroMode[_id], herosDic[_id], i);
        //}
        //int num = -1;
        //Debug.Log(herosTeam.Length);

        /*for (int i = 0; i < BattleInfo.waitingTeams.Count; i++)
        {
            CreateRole(BattleInfo.waitingTeams[i].heroMode, BattleInfo.waitingTeams[i].heroData, i);
        }*/

    }

    /// <summary>
    /// 队伍中的角色交换位置
    /// </summary>
    public void MoveRoleInTeam(int pos1, int pos2)
    {
        //Move_Role(pos1,pos2);
    }

    /// <summary>
    /// 一定是移动技能调用的此方法，因为这方法写了结束行动
    /// </summary>
    /// <param name="roleBattleingData"></param>
    /// <param name="objlife"></param>
    public void MoveRoleInTeam(/*RoleBattleingData roleBattleingData,ObjLife objlife*/)
    {
        //roleBattleingData.goNum--;
        /*Move_Role(roleBattleingData.numInTeam, objlife.battleingData.numInTeam);

        StartCoroutine(MoveEnd(roleBattleingData));      */ 
    }


    //因为要等待动画播放完，这里先简单让程序暂停使他们同步
    IEnumerator MoveEnd(/*RoleBattleingData roleBattleingData*/)
    {
        yield return new WaitForSeconds(1);
        //EndAction(roleBattleingData.objLife);
    }

    //角色行动
    /*protected override void RoleGoto(RoleBattleingData roleBattleingData)
    {
        //设置显示谁角色UI显示谁
        SetShowHow(roleBattleingData.numInTeam);
    
        RoleInfoView.Instance.ResetInfo(roleBattleingData.numInTeam);
    }*/

    /// <summary>
    /// 当设置显示一个英雄时，其他英雄关闭
    /// </summary>
    void SetShowHow(int num)
    {
        /*for (int i = 0; i < roleTeam.Count; i++)
        {          
            if (num != i)
            {
                roleTeam[i].objLife.roleUi.SetShow(false);
            }
            else
            {
                roleTeam[i].objLife.roleUi.SetShow(true);
            }
        }*/
    }
    #endregion

  
}
