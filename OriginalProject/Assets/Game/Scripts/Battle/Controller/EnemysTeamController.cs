using Datas;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// 敌人队伍控制器
/// </summary>
public class EnemysTeamController : RoleTeamController
{
    static EnemysTeamController _instance;
    public static EnemysTeamController Instance { get { return _instance; } }

    Dictionary<int, RoleData> enemyDic = new Dictionary<int, RoleData>();
    public Dictionary<int, SkillData> skillDic = new Dictionary<int, SkillData>();

    //这个信息之后可以放在预制体中，临时在这里生成
    //int[] enemysTeam;

    public AddRoomData addRoomData;


    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        //heroOrEnemy = false;
      
        //Invoke("ReGo", 3);
        ReGo();
    }

    //由EnemyTriggerBox的触发器通知启动
    void ReGo()
    {
        DataSetItem dataSet = DataManager.Instance.GetData("RoleData");
        RoleDataSet roleData = dataSet.scriptableObject as RoleDataSet;

        foreach (var item in roleData.enemyData)
        {
            enemyDic.Add(item.id, item);
        }

        DataSetItem data = DataManager.Instance.GetData("SkillData");
        SkillDataSet skillData = data.scriptableObject as SkillDataSet;

        foreach (var item in skillData.enemySkills)
        {
            skillDic.Add(item.id, item);
        }


        //！初始化队伍待考虑,做两个触发？提前生成角色，战斗时激活显示
        //RestTame();
    }

    /// <summary>
    /// 退出或取消战斗
    /// EnemyTriggerBox退出触发器会通知取消
    /// </summary>
    public void ExitBattle()
    {
        /*foreach (var item in roleTeam)
        {
            Destroy(item.objLife.gameObject);
        }
        roleTeam.Clear();*/
    }

    /// <summary>
    /// 开始战斗
    /// </summary>
    public void StartBattle(AddRoomData _addRoomData,EnemyTriggerBox enemyTriggerBox)
    {
        ////激活显示
        //foreach (var item in roleTeam)
        //{
        //    item.objLife.gameObject.SetActive(true);
        //}

        RestTame(_addRoomData);
    }
  

    //接收触发器的消息
    void RestTame(AddRoomData _addRoomData)
    {
        /*addRoomData = _addRoomData;//缓存附加房间的值--因为有奖励品

        roleTeam.Clear();
        for (int i = 0; i < addRoomData.triggerKeys.Count; i++)
        {
            int _id = addRoomData.triggerKeys[i];
            if (!enemyDic.ContainsKey(_id))
            {
                Debug.Log($"提供的怪物存档数据ID{_id}在英雄基础数据中找不到");
                return;
            }

            CreateRole(null, enemyDic[_id], i);
        }*/
    }


    #region 怪物的AI控制部分

    /*protected override void RoleGoto(RoleBattleingData roleBattleingData)
    {
        roleBattleingData.objLife.roleUi.SetShow(true);//显示正在行动的角色
       

        AIBase roleAI = roleBattleingData.objLife.GetComponent<AIBase>();
        if (roleAI == null)
        {
            Debug.Log($"[{roleBattleingData.objLife.roleData.name}]是个智障，请给该角色挂载AI脚本---程序跳过了它的行动");
            EndAction(roleBattleingData.objLife);
            return;
        }

        roleAI.ReGo(this, roleBattleingData);
    }*/
    #endregion
}
