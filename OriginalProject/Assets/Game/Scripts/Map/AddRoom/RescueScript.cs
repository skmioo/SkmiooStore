using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Datas;
using System.Linq;

public class RescueScript : InteractiveTriggerBox
{
    InteractiveRescue rescue;
    RescueInteractiveResltData rescueResult;
    public GameObject interactiveView;
    public GameObject sureBtn;
    public GameObject exitBtn;
    public Button pickBtn;

    [Header("解救信息")]
    public Text rescueTitle;
    public Image rescureImage;
    public GameObject pop;
    public Text warn;

    public override InteractiveType m_InteractiveType => InteractiveType.解救;
    public RescueMode Mode { get; private set; }

    public override void Start()
    {
        base.Start();

        if (modeBase != null)
        {
            Mode = modeBase as RescueMode;
            rescue = DataManager.Instance.GetInteractiveRescueByID(Mode.rescueId);
            rescue.rescueType = Mode.rescueType;
            rescueResult = DataManager.Instance.GetRandomByProbability(rescue.interactiveResultDatas, rescue.interactiveResultDatas.Select(s => s.probability).ToList());
            InitInteractive();
            return;
        }
        rescue = DataManager.Instance.CreatInteractiveRescueRandom();
        rescueResult = DataManager.Instance.GetRandomByProbability(rescue.interactiveResultDatas, rescue.interactiveResultDatas.Select(s => s.probability).ToList());
        InitInteractive();
        if (Mode == null)
        {
            Mode = new RescueMode(m_InteractiveType, mapType, roomIndex, routeGroupIndex, routeIndex);
            Mode.rescueType = rescue.rescueType;
            Mode.rescueId = rescue.id;
            DataManager.Instance.AddInteractivMode(Mode);
        }
    }

    private void InitInteractive()
    {
        NewbieGuideMag.Instance.triggerGuide(GuideDataSet.guideEnum.interaction);
        InteractiveData m_interactieData = DataManager.Instance.GetInteractiveDataByType(m_InteractiveType);
        rescueTitle.text = m_interactieData.tip+ rescue.rescueType;
        rescue.icon.LoadAssetAsync<Sprite>().Completed += s =>
        {
            rescureImage.sprite = s.Result;
        };
       
    }

    public void Pick_OnClick()
    {
        AudioManager.Instance.PlayAudio(AudioName.POP_Mouth_Darker_mono, AudioType.Common);

        pickBtn.enabled = false;
        warn.text = "耐心等待命运的回馈，亦或恶报。";
        pop.SetActive(true);
    }

    protected override void InteractiveBtn_OnClick()
    {
        base.InteractiveBtn_OnClick();

        interactiveBtn.enabled = false;
        interactiveView.SetActive(true);

        if (!Mode.isInteractived)
        {
            warn.text = "善举？亦或是愚行？ 即使足迹遍布星空， 人类也终逃不过心底的牢笼。";

            pickBtn.enabled = false;
            pop.SetActive(true);
            sureBtn.SetActive(false);
            exitBtn.SetActive(true);
        }
    }

    public void Sure_OnClick()
    {
        sureBtn.SetActive(false);
        exitBtn.SetActive(true);

        AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);

        if (rescueResult.resultType == RescueResultType.fight)
        {
            warn.text = "卑劣的人性让你的善行变得一文不值";

            var camPos = FightingCameraCon.Instance.transform.position;
            camPos.x = transform.position.x;
            FightingCameraCon.Instance.transform.position = camPos;
            var btPos = BattleFlowController.Instance.transform.position;
            btPos.x = transform.position.x;
            BattleFlowController.Instance.transform.position = btPos;
        }
        else if (rescueResult.resultType == RescueResultType.reward)
        {
            warn.text = $"善行终得好报-'{rescue.describe}'";
        }
    }

    public void RescueTrigger()
    {
        if (!Mode.isInteractived) return;

        if (rescueResult.resultType == RescueResultType.fight)
        {
            BattleFlowController.Instance.RescueTrigger(rescue, true);
        }
        else if (rescueResult.resultType == RescueResultType.reward)
        {
            BattleFlowController.Instance.RescueTrigger(rescue, false);
        }

        Mode.isInteractived = false;
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
}
