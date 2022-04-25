using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Datas;

/// <summary>
/// 交互物-冥想台
/// </summary>
public class MeditationPlatform : InteractiveTriggerBox
{
    List<OtherSkillData> datas;
    int currentIndex;

    public GameObject interactiveView;
    public GameObject describeObj;
    public GameObject popObj;
    public GameObject sureBtnObj;
    public GameObject cancelBtnObj;
    public GameObject exitBtnObj;
    public Button pickBtn;

    [Header("冥想台信息")]
    public Text title;
    public Text describe;
    public Text[] heroName;
    public Image[] skillIcon;
    public Text skillDescribe;
    public Text warn;
    List<ObjLifeData> heroDatas;
    List<OtherSkillData> MoralSkillDatas;
    public override InteractiveType m_InteractiveType =>  InteractiveType.冥想台;
    public MeditationPlatformMode Mode { get; private set; }

    public override void Start()
    {
        base.Start();
        UpdateData();
        List<ObjLifeData> heros = BattleFlowController.Instance.GetHeros();
        List<ObjPermanentBuff> buff = heros.Count <= 0 ? new List<ObjPermanentBuff>() : heros[0].FindPermanentBuff(ObjBuffType.冥想台士气技能词条刷新次数增加);
        if (modeBase != null)
        {
            Mode = modeBase as MeditationPlatformMode;
            interactiveCountMax = buff.Count > 0 ? interactiveCountMax + buff[0].buffValue : interactiveCountMax;
            InitInteractive(MoralSkillDatas);
            return;
        }
        InitInteractive(MoralSkillDatas);
        if (Mode == null)
        {
            Debug.Log("------------------MeditationPlatform-------------");
            Mode = new MeditationPlatformMode(m_InteractiveType, mapType, roomIndex, routeGroupIndex, routeIndex);
            interactiveCountMax = buff.Count > 0 ? interactiveCountMax + buff[0].buffValue : interactiveCountMax;
            DataManager.Instance.AddInteractivMode(Mode);
        }
      
    }
  
    public void InitInteractive(List<OtherSkillData> _datas)
    {
      
        datas = _datas;
        InteractiveData m_interactieData = DataManager.Instance.GetInteractiveDataByType(m_InteractiveType);
        title.text = m_interactieData.tip;
        describe.text = m_interactieData.describe;

        for (int i = 0; i < datas.Count; i++)
        {
            int iTemp = i;
            heroName[iTemp].text = heroDatas[iTemp].GetHeroName();

            if (datas[iTemp] != null)
            {
                datas[iTemp].icon.LoadAssetAsync<Sprite>().Completed += s =>
                {
                    skillIcon[iTemp].sprite = s.Result;
                };

                UIEventManager.AddTriggersListener(skillIcon[iTemp].gameObject).onEnter = go => ShowSkillDescribe(iTemp);
                UIEventManager.AddTriggersListener(skillIcon[iTemp].gameObject).onExit = go => Off();
                UIEventManager.AddTriggersListener(skillIcon[iTemp].gameObject).onLeftClick = go => ChoiceSkill(iTemp);
            }
            else
            {
                skillIcon[iTemp].sprite = null;
            }
        }
    }

    public void ChoiceSkill(int index)
    {
        if (!Mode.isInteractived) return;
        currentIndex = index;

        for (int i = 0; i < skillIcon.Length; i++)
        {
            if(i == currentIndex)
            {
                skillIcon[i].color = Color.red;
            }
            else
            {
                skillIcon[i].color = Color.white;
            }
        }
    }

    void ShowSkillDescribe(int index)
    {
        //技能hover有问题
        if (datas[index] == null) return;
        skillDescribe.gameObject.SetActive(true);
        title.gameObject.SetActive(false);
        skillDescribe.text = datas[index].describe;
    }

    void Off()
    {
        skillDescribe.gameObject.SetActive(false);
        title.gameObject.SetActive(true);
    }

    public void Pick_OnClick()
    {
        if (!Mode.isInteractived) return;
        if (currentIndex < 0) return;
        if (datas[currentIndex] == null) return;
        //pickBtn.enabled = false;
        if (datas[currentIndex].IsEntryReachLimit())
        {
            popObj.SetActive(true);

            AudioManager.Instance.PlayAudio(AudioName.POP_Mouth_Darker_mono, AudioType.Common);

            warn.text = "随机异变效果将被替换，确定异变吗？";
        }
        else
        {
            popObj.SetActive(true);

            AudioManager.Instance.PlayAudio(AudioName.POP_Mouth_Darker_mono, AudioType.Common);

            datas[currentIndex].AddOrUpdateOneEntry();
            warn.text = $"{datas[currentIndex].name}获得{datas[currentIndex].GetEntry()[0].describe}";
            Mode.interactiveCount++;
            Debug.Log("------------------" + Mode.interactiveCount);
            if (Mode.interactiveCount >= interactiveCountMax) Mode.isInteractived = false;
            sureBtnObj.SetActive(false);
            cancelBtnObj.SetActive(false);
            exitBtnObj.SetActive(true);
        }
    }

    public void Sure_OnClick()
    {
        if (!Mode.isInteractived) return;

        AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);

        datas[currentIndex].AddOrUpdateOneEntry();
        warn.text = $"{datas[currentIndex].name}获得{datas[currentIndex].GetEntry()[0].describe}";
        Mode.interactiveCount++;
        Debug.Log("------------------" + Mode.interactiveCount);
        if (Mode.interactiveCount >= interactiveCountMax) Mode.isInteractived = false;
        sureBtnObj.SetActive(false);
        cancelBtnObj.SetActive(false);
        exitBtnObj.SetActive(true);
    }
    
    void  UpdateData()
    {
        heroDatas = BattleFlowController.Instance.GetHeros();
        MoralSkillDatas = new List<OtherSkillData>();
        for (int i = 0; i < heroDatas.Count; ++i) MoralSkillDatas.Add(heroDatas[i].GetMoraleSkill()); 
    }

    protected override void InteractiveBtn_OnClick()
    {
        base.InteractiveBtn_OnClick();

        interactiveBtn.enabled = false;
        interactiveView.SetActive(true);

        currentIndex = -1;

        for (int i = 0; i < skillIcon.Length; i++)
        {
            skillIcon[i].color = Color.white;
        }

        if (!Mode.isInteractived)
        {
            popObj.SetActive(true);
            warn.text = "此处的神秘气息消散了，无法冥想";

            pickBtn.enabled = false;
            sureBtnObj.SetActive(false);
            cancelBtnObj.SetActive(false);
            exitBtnObj.SetActive(true);
        }
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
        popObj.SetActive(false);
    }
}
