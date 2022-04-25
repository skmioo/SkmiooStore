using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Datas;
using UnityEngine.Events;

/// <summary>
/// 出征按钮
/// </summary>
public class GoBattle : MonoBehaviour
{
    public GameObject oGetBackGround;
    public GameObject oReadyBackGround;
    public Text txButtonName;
    //MapData mapData;
    private ModeData modeData;

    private void Start()
    {
        DataSetItem data = DataManager.Instance.GetConstData("MapData");
        MapDataSet mapDataSet = data.scriptableObject as MapDataSet;

        txButtonName.text = LanguageController.GetValue("出征");
      //  mapData = mapDataSet.mapData[0];
        //取第0个地图测试用
    }

    //出征的队伍,携带的道具,装载的任务,要去的场景
    public void GoButtonDwon()
    {
		/*BattleInfo.waitingTeams.Clear();
        //BattleInfo.roleItem_W = Camp.Instance.waitingTeams;
        foreach (var item in Camp.Instance.waitingTeams)
        {
            if (item != null)
            {
                ObjLifeData waitingTeam = new ObjLifeData(item.roleItem.heroData.hp, 0, item.roleItem.herosMode, item.roleItem.heroData);
                BattleInfo.waitingTeams.Add(waitingTeam);
            }

        }*/
		AudioManager.Instance.PlayAudio(AudioName.EXPLOSION_Short_Bright_Kickback_stereo, AudioType.Common);
		if (BattleInfo.waitingTeams.Count > 0)
        {
           // BattleInfo.mapData = mapData;

            // 进战斗携带的鳞片
            if(modeData == null)
                modeData = DataManager.Instance.modeData;

            int nCarryBattleMoney = Camp.Instance.nCarryBattleMoney;
            if(nCarryBattleMoney > 0)
            {
                int nLeftMoney = modeData.moneyMode.count - nCarryBattleMoney;
                if(nLeftMoney < 0)
                {
                    nCarryBattleMoney = modeData.moneyMode.count;
                    modeData.moneyMode.count = 0;
                }
                else
                {
                    modeData.moneyMode.count -= nCarryBattleMoney;
                }

                modeData.carryBattleMoneyMode.count = nCarryBattleMoney;
                modeData.carryBattleMoneyMode.objId = 7001;
            }
            SwitchToBattle();
            // }
            // else
            // {
            //     nCarryBattleMoney = 0;

            //     modeData.carryBattleMoneyMode.count = nCarryBattleMoney;
            //     modeData.carryBattleMoneyMode.objId = 7001;

            //     DialogMgr.Instance.onEvOk.AddListener(SwitchToBattle);
            //     DialogMgr.Instance.CreatePanel("是否选择不携带鳞片进入地图？");
            // }
            
        }
    }

    private void SwitchToBattle()
    {
        if (oGetBackGround != null)
        {
            oGetBackGround.SetActive(true);
            oReadyBackGround.SetActive(false);
        }
        UIManager.Instance.PopAllPanel();
        GameScenesController.Instance.GoLoadScenes(2);
        Camp.backFromBattle = false;
        GEvent.EventHelper.Instance.ExcuteEvent(GEvent.GEventType.GoBattle, null);
        GEvent.EventHelper.Instance.ClearEvents();
        // 加载界面
        UIManager.Instance.PushPanel(UIPanelType.EnterGameLoding, true);
    }


	public void BtnClickLoukongzhidi()
    {
		AudioManager.Instance.PlayAudio(AudioName.EXPLOSION_Short_Bright_Kickback_stereo, AudioType.Common);
		AudioManager.Instance.PlayMusic(AudioName.LouKongZhiDiBGM);
        BattleInfo.MapName = MapNameType.镂空之地;
      //  BattleInfo.TaskType.Clear();
        //BattleInfo.TaskType.Add(N_TaskType.固定boss);
    }

    public void BtnClickMinghekuangdong()
    {
		AudioManager.Instance.PlayAudio(AudioName.EXPLOSION_Short_Bright_Kickback_stereo, AudioType.Common);
		AudioManager.Instance.PlayMusic(AudioName.MingHeKuangDongBGM);
        BattleInfo.MapName = MapNameType.冥河矿洞;
       // BattleInfo.TaskType.Clear();
       // BattleInfo.TaskType.Add(N_TaskType.固定boss);
    }
    public void BtnClickGoJiaoChengGuanka() {
        AudioManager.Instance.PlayAudio(AudioName.EXPLOSION_Short_Bright_Kickback_stereo, AudioType.Common);
        BattleInfo.MapName = MapNameType.教程关卡;
       // BattleInfo.TaskType.Clear();
       // BattleInfo.TaskType.Add(N_TaskType.固定boss);
    }
   [System.Obsolete] public void BtnClickRandom()
    {
        if (Random.Range(0f, 1f) > 0.5f)
        {
            BattleInfo.MapName = MapNameType.冥河矿洞;
        }
        else
        {
            BattleInfo.MapName = MapNameType.镂空之地;
        }
    }
}
