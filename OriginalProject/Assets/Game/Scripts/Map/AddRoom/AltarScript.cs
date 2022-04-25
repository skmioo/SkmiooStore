using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Datas;
using System.Linq;
using System;

public class AltarScript : InteractiveTriggerBox
{
    int usedTimes;
    public GameObject interactiveView;

    [Header("祭坛信息")]
    public Text altarTitle;
    public Text altarDescribe;
    public Image altarIcon;
    public GameObject pop;
    public Text warn;
    public Text exit2Txt;
  
    public override InteractiveType m_InteractiveType => InteractiveType.祭坛;
    /// <summary>
    /// 当前祭坛类型
    /// </summary>
    public InteractiveAltar CurAltarData;
    public AltarMode Mode { get; private set; }

    public override void Start()
    {
        base.Start();
        
        if (modeBase != null)
        {
            Mode = modeBase as AltarMode;
            CurAltarData = DataManager.Instance.GetInteractiveAltar( Mode.altarId);
            usedTimes = Mode.interactiveCount;
            InitInteractive();
            return;
        }
        CurAltarData = DataManager.Instance.CreatInteractiveAltarRandom();
        InitInteractive();
        if (Mode == null)
        {
            Mode = new AltarMode(m_InteractiveType, mapType, roomIndex, routeGroupIndex, routeIndex);
            Mode.altarType = CurAltarData.altarType;
            Mode.altarId = CurAltarData.id;
            Mode.interactiveCount = usedTimes;
            DataManager.Instance.AddInteractivMode(Mode);
        }
    }

    public void InitInteractive()
    {
        InteractiveData m_interactieData = DataManager.Instance.GetInteractiveDataByType(m_InteractiveType);
        altarTitle.text = CurAltarData.altarType.ToString();
        altarDescribe.text = CurAltarData.describe;
        m_interactieData.altarIcons.Find(s => s.altarType == CurAltarData.altarType).icon.LoadAssetAsync<Sprite>().Completed += s =>
        {
            altarIcon.sprite = s.Result;
        };
    }
    /// <summary>
    /// 献祭
    /// </summary>
    public void Sacrifice()
    {
        if (!ShowSacrificCountLimitTip())
        {
            AudioManager.Instance.PlayAudio(AudioName.UI_Error_Subtle_Deep_stereo, AudioType.Common); 
            return;
        }

        AudioManager.Instance.PlayAudio(AudioName.POP_Mouth_Darker_mono, AudioType.Common);

        if (BattleFlowController.Instance.kanpsack.getPropPanel.panel.gameObject.activeSelf || pop.activeSelf)
        {
            return;
        }

        if (!BattleFlowController.Instance.IsPassHpLimit(CurAltarData.sacrifices[usedTimes].hpLimit))//usedTimes + 4))
        {
            warn.text = "贪婪者恋生，愚昧者畏死";
            pop.SetActive(true);
            return;
        }

        BattleFlowController.Instance.ReduceHpFromSacrifice(CurAltarData.sacrifices[usedTimes].minHpReduce, CurAltarData.sacrifices[usedTimes].maxHpReduce);// usedTimes + 1, usedTimes + 3);
        AltarReward reward = DataManager.Instance.GetRandomByProbability(CurAltarData.sacrifices[usedTimes].rewards, CurAltarData.sacrifices[usedTimes].rewards.Select(s => s.probability).ToList());
        Debug.Log(reward.rewardType);
        if (reward.rewardType == AltarRewardType.无) 
        {
            warn.text = "付出并不一定能获得回报";
            pop.SetActive(true);
        }
        else if (reward.rewardType == AltarRewardType.上级祝福 || reward.rewardType == AltarRewardType.下级祝福)
        {
            AltarBlessAction action = DataManager.Instance.CreatAltarBlessAction(reward.rewardType);
            List<ObjLifeData> heros = BattleFlowController.Instance.GetHeros();
            bool flag = true;
            foreach (var hero in heros)
            {
                for (int i = 0; i < action.action.Count; ++i)
                {
                  
                    if (action.action[i].buffType == ObjBuffType.充分准备) hero.AddSkillBuff(new ObjSkillBuff(action.action[i].buffType, action.action[i].valueType, action.action[i].value, action.action[i].round));
                    else
                    {
                        hero.AddPermanentBuff(new ObjPermanentBuff(action.action[i].buffType, action.action[i].valueType, action.action[i].value, BuffSourceType.交互物_祭坛));
                    }
                    if (flag)
                    {
                        Buff_Interactive buffTemp = Buff_InteractiveGroup.Instance.NewGet();
                        buffTemp.SetText(action.action[i].ToString());
                    }
                    if (flag) flag = false;
                }
                
            }

           
            string result = $"已获得{action.describe}";
            warn.text = result;
            pop.SetActive(true);
        }
        else {
            List<ObjData> objList = new List<ObjData>();
            switch (reward.rewardType)
            {
                case AltarRewardType.鳞片:
                    objList.Add(DataManager.Instance.GetObjData(7001));
                    break;
                case AltarRewardType.普通饰品:
                    objList.Add(DataManager.Instance.CreateOrnamentData(LevelType.普通));
                    break;
                case AltarRewardType.精良饰品:
                    objList.Add(DataManager.Instance.CreateOrnamentData(LevelType.精良));
                    break;
                case AltarRewardType.稀有饰品:
                    objList.Add(DataManager.Instance.CreateOrnamentData(LevelType.稀有));
                    break;
                case AltarRewardType.起源饰品:
                    objList.Add(DataManager.Instance.CreateOrnamentData(LevelType.起源));
                    break;
            }
            objList[0].Count = reward.count;
            int testNum = 0;
            //超过堆叠数量处理
            while (objList[0].Count > objList[0].maxCount)
            {
                if (testNum > 20000)
                {
                    Debug.LogError("死循环啦。。。。。啦。。。啦。。");
                    break;
                }
                testNum++;
             
                ObjData temp =  objList[0].Clone();
                temp.Count = temp.maxCount;
                objList.Add(temp);
                objList[0].Count -= objList[0].maxCount;
            }
            ShowGetPropPanel(objList.ToArray());
        }

        usedTimes++;
        Mode.interactiveCount = usedTimes;

        if (usedTimes >= interactiveCountMax) Mode.isInteractived = false;
    }


    void ShowGetPropPanel(params ObjData[] _datas) {
        List<ObjData> datasList = new List<ObjData>(_datas);
        BattleFlowController.Instance.kanpsack.ShowGetPropPanel(datasList, false);
    }

    void ChangeDescribe()
    {
        switch (usedTimes)
        {
            case 0:
                altarDescribe.text = "献上生命，换取回报，这很公平。";

                break;
            case 1:
                altarDescribe.text = "这就是代价，但没有人真的想停下。";

                break;
            case 2:
                altarDescribe.text = "与回报相比，生命的代价不值一提。";
                exit2Txt.text = "离开";

                break;
            case 3:
                altarDescribe.text = "与回报相比，生命的代价不值一提。";
                warn.text = "贪婪的人终会尝到恶果";
                exit2Txt.text = "离开";

                break;
        }
    }

    protected override void InteractiveBtn_OnClick()
    {
        base.InteractiveBtn_OnClick();

        interactiveBtn.enabled = false;
        interactiveView.SetActive(true);

        ChangeDescribe();
        ShowSacrificCountLimitTip();
    }

    bool ShowSacrificCountLimitTip() 
    {
        if (usedTimes >= interactiveCountMax)
        {
            pop.SetActive(true);
            return false;
        }
        
        return true;
    }

    private void OnEnable()
    {
        ExitBattleScenes.onBeginExitBattleScenes += OnExitBattleScenes;
    }

    protected override void OnDisable()
    {
        ExitBattleScenes.onBeginExitBattleScenes -= OnExitBattleScenes;
        base.OnDisable();
    }

    private void OnExitBattleScenes()
    {
        Exit_OnClick();
    }

    public void Exit_OnClick()
    {
        BattleFlowController.Instance.IsInteracting = false;

        AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);

        interactiveBtn.enabled = true;
        interactiveView.SetActive(false);
    }

    public void Exit2_OnClick()
    {
        ChangeDescribe();

        AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);

        if (usedTimes >= interactiveCountMax)
        {
            BattleFlowController.Instance.IsInteracting = false;

            interactiveBtn.enabled = true;
            interactiveView.SetActive(false);
        }
    }
}
