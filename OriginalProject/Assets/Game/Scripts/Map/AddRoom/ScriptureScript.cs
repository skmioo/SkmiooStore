using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Datas;

/// <summary>
/// 交互物-经文
/// </summary>
public class ScriptureScript : InteractiveTriggerBox
{
    InteractiveScripture datas;

    public GameObject interactiveView;
    public RectTransform exitButton;

    public GameObject pickBtnObj;
    public GameObject tipObj;
    public GameObject describeObj;

    [Header("经文信息")]
    public Text scriptureTitle;
    public Text scriptureDescribe;
    public Text scriptureName;
    public Image scriptureIcon;

    public override InteractiveType m_InteractiveType => InteractiveType.经文;
    public ScriptureMode Mode { get;private set; }
    /// <summary>
    /// 暂时 这样处理
    /// </summary>
  public override void Start()
    {
        base.Start();

        if (modeBase != null)
        {
            Mode = modeBase as ScriptureMode;
            InitInteractive(DataManager.Instance.GetScriptureById(Mode.ScriptureId));
            return;
        }
        InitInteractive(DataManager.Instance.CreateScriptureRandom());
        if (Mode == null)
        {
            Mode = new ScriptureMode(m_InteractiveType, mapType, roomIndex, routeGroupIndex, routeIndex);
            Mode.ScriptureId = datas.id;
            DataManager.Instance.AddInteractivMode(Mode);
        }
    }

    public void InitInteractive(ObjData _datas)
    {
        datas = _datas as InteractiveScripture;
        
        InteractiveData m_interactieData =  DataManager.Instance.GetInteractiveDataByType(m_InteractiveType);
        scriptureTitle.text = datas.name;// "title";
        scriptureDescribe.text = m_interactieData.describe;//  "describe";
        scriptureName.text = datas.name;// "name";
        datas.Icon.LoadAssetAsync<Sprite>().Completed += s =>
        {
            scriptureIcon.sprite = s.Result;//=  null;
        };
    }

    public void Pick_OnClick()
    {
        List<ObjLifeData> heros = BattleFlowController.Instance.GetHeros();
        List< ObjPermanentBuff> buff = heros.Count <= 0 ? new List<ObjPermanentBuff>(): heros[0].FindPermanentBuff(ObjBuffType.经文效果翻倍);
        if (buff.Count > 0) {
            for (int i = 0; i < datas.skillBuffs.Count; ++i)
            {
                float fTemp = (1 + buff[0].buffValue / 100f);
                datas.skillBuffs[i].value.level1 = Mathf.RoundToInt(datas.skillBuffs[i].value.level1 * fTemp);
                datas.skillBuffs[i].value.level2 = Mathf.RoundToInt(datas.skillBuffs[i].value.level2 * fTemp);
                datas.skillBuffs[i].value.level3 = Mathf.RoundToInt(datas.skillBuffs[i].value.level3 * fTemp);
                datas.skillBuffs[i].value.level4 = Mathf.RoundToInt(datas.skillBuffs[i].value.level4 * fTemp);
                datas.skillBuffs[i].value.level5 = Mathf.RoundToInt(datas.skillBuffs[i].value.level5 * fTemp);
            }
        }
       // buff = heros[0].GetPermanentBuff().Find(s => s.buffType == ObjBuffType.未知经文可以看到效果);未接入
        datas.Count = 1;
        List<ObjData> datasList = new List<ObjData>();
        datasList.Add(datas);

        BattleFlowController.Instance.kanpsack.ShowGetPropPanel(datasList, false);
        Mode.isInteractived = false;

        AudioManager.Instance.PlayAudio(AudioName.POP_Mouth_Darker_mono, AudioType.Common);

        exitButton.localPosition = new Vector2(0, exitButton.localPosition.y);

        //BattleFlowController.Instance.IsInteracting = false;

        interactiveBtn.enabled = true;
        interactiveView.SetActive(false);

        pickBtnObj.SetActive(false);
        tipObj.SetActive(true);
        describeObj.SetActive(false);
        scriptureIcon.gameObject.SetActive(false);
    }

    protected override void InteractiveBtn_OnClick()
    {
        base.InteractiveBtn_OnClick();
        BattleFlowController.Instance.IsInteracting = true;
        interactiveBtn.enabled = false;
        interactiveView.SetActive(true);

        if (!Mode.isInteractived)
        {
            exitButton.localPosition = new Vector2(0, exitButton.localPosition.y);

            pickBtnObj.SetActive(false);
            tipObj.SetActive(true);
            describeObj.SetActive(false);
            scriptureIcon.gameObject.SetActive(false);
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
    }
}
