using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Datas;

/// <summary>
/// 敌人触发器盒子
/// </summary>
public class EnemyTriggerBox :AddRoomBase
{
    //触发器只能够触发一次
    private bool triggerOn;
    
    /// <summary>
    /// 房间是否初始化
    /// </summary>
    public bool isInit = false;
    public override void InitAddRoom(AddRoomData _addRoomData)
    {
        base.InitAddRoom(_addRoomData);
        isInit = true;
        if(triggerOn){
            this.OnTrigger();
        }
    }

    //当进入者是怪物，发送一个加载命令    当触发者是英雄发送启动命令
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isInit && !triggerOn){
            this.OnTrigger();
        }
        triggerOn = true;
    }

    private void OnTrigger(){
        if( BattleFlowController.Instance.isTest4)//粘稠圣者专项测试
            {
                //测试
                Debug.Log("==============================触发怪物=================================");
                addRoomData.triggerKeys = new List<int>() { 3301 };
            }


            //BattleFlowController.Instance.StartBattle(addRoomData, this);

            var datas = DataManager.Instance.GetMonsterSeniorDatas(addRoomData.triggerKeys, mapController.GetTaskDifficulty());
            BattleFlowController.Instance.EncounterEnemy(datas);
            //告知地图控制器当前怪物在数据中的索引
            mapController.SetBattleIndex(roomIndex);
            mapController.SetBattleIndex(routeGroupIndex, routeIndex);
    }

    /// <summary>
    /// 撤退成功时专用重置
    /// </summary>
    public void ExitBattleing()
    {
        triggerOn = false;
    }

    //当退出者是怪物，发送一个销毁命令
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "enemyTeamControllers")
        {
            //collision.SendMessage("ExitBattle", SendMessageOptions.DontRequireReceiver);
            
        }
    }
}
