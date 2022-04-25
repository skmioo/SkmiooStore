
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using Datas;
using System.Reflection;
using System;
using UnityEngine.Events;
using UnityEngine.AddressableAssets;

/// <summary>
/// 角色信息面板，带技能控制
/// </summary>
public class RoleInfoView : MonoBehaviour
{
    //战斗场景中的常驻UI，不进Panel框架故可以单例
    static RoleInfoView _instance;
    public static RoleInfoView Instance
    {
        get { return _instance; }
    }

    public HeroAttribute heroAttribute;
    public HeroHps heroHps;


    //public List<SkillButton> skillButtons;//技能按钮
    public List<GameObject> skillButtons;

    public GameObject otherSkill;

    public GameObject outButton;

    /// <summary>
    /// 换位技能
    /// </summary>
    public GameObject skillMove;
    /// <summary>
    ///hover 技能详情
    /// </summary>
    public SkillInfo skillInfo;

    public GameObject outTips;
    /// <summary>
    /// 正在突出显示哪个角色
    /// </summary>
    //public RoleBattleingData showWho { get; private set; }
    private ObjLifeData CurrentSelectHeroData;
    Dictionary<int, SkillData> skillDict = new Dictionary<int, SkillData>();
    /// <summary>
    /// 士气技能数据
    /// </summary>
    Dictionary<int, SkillData> otherSkillDict = new Dictionary<int, SkillData>();

    /// <summary>
    /// 战斗行动点显示详情
    /// </summary>
    public BattleActNumInfo battleActNumInfo;
    private void Awake()
    {
        _instance = this;
        //RoleUiController.RoleClick += RoleUiController_RoleClick;
        ListenerOutButtonClick();
        ListenerSkillMoveClick();
    }

    private void OnDestroy()
    {
        //RoleUiController.RoleClick -= RoleUiController_RoleClick;
    }

    

    #region 技能按钮与角色UI的互动模块
    //当技能被点击后,技能的信息缓存..可以单独做一个取消选择后,这些值置空
    /*RoleTeamController roleTeamController;
    SkillButton waitSkill;
    //DamagePack damagePack;
    bool[] targetPos = new bool[4];
    bool isMove;*/
    /// <summary>
    /// 技能按钮被按下
    /// </summary>
    /// <param name="button"></param>
    private void skillButtonDwon(GameObject button)
    {
        //如果当前是敌人正在行动,或未在战斗中--，拒绝技能的点击事件
        /*if (BattleFlowController.Instance.whoTheControl || !BattleFlowController.Instance.currentBattleing)
            return;
        waitSkill = button.GetComponent<SkillButton>();
        if (!waitSkill.isOn || waitSkill.skill == null)
            return;


        HerosTeamController.Instance.OffClickTips();
        EnemysTeamController.Instance.OffClickTips();


        foreach (var item in skillButtons)
        {
            item.SelectedOff();
        }
        skillMove.SelectedOff();
        waitSkill.SelectedOn();
        isMove = false;
    
        showWho.objLife.roleUi.SetShow(true);
        //damagePack = new DamagePack(waitSkill.skill, waitSkill.level, waitSkill.skill_roleBingData.objLife);

        switch (waitSkill.skill.targetType)
        {
            case SkillTargetType.自身:
                roleTeamController = HerosTeamController.Instance;
                for (int i = 0; i < targetPos.Length; i++)
                {
                    if (i == showWho.numInTeam)
                    {
                        targetPos[i] = true;
                    }
                    else
                    {
                        targetPos[i] = false;
                    }                    
                }                
                break;
            case SkillTargetType.己方单体:
                roleTeamController = HerosTeamController.Instance;
                for (int i = 0; i < targetPos.Length; i++)
                {
                    targetPos[i] = true;
                }
                break;
            case SkillTargetType.己方单体_不含自身:
                roleTeamController = HerosTeamController.Instance;
                targetPos = waitSkill.startPos;
                for (int i = 0; i < targetPos.Length; i++)
                {
                    if (i == showWho.numInTeam)
                    {
                        targetPos[i] = false;
                    }
                }
                break;
            case SkillTargetType.己方全体:
                roleTeamController = HerosTeamController.Instance;
                for (int i = 0; i < targetPos.Length; i++)
                {
                    targetPos[i] = true;
                }
                break;
            case SkillTargetType.己方全体_不含自身:
                roleTeamController = HerosTeamController.Instance;
                targetPos = waitSkill.startPos;
                for (int i = 0; i < targetPos.Length; i++)
                {
                    if (i == showWho.numInTeam)
                    {
                        targetPos[i] = false;
                    }
                }
                break;
            case SkillTargetType.敌方单体:
                roleTeamController = EnemysTeamController.Instance;
                targetPos = waitSkill.endPos;
                break;
            case SkillTargetType.敌方群体:
                roleTeamController = EnemysTeamController.Instance;
                targetPos = waitSkill.endPos;
                break;
            default:
                break;
        }

        
        roleTeamController.SetClickTips(targetPos, true);*/
    }

    /// <summary>
    /// 当某个角色被点击
    /// </summary>
    /// <param name="obj"></param>
    private void RoleUiController_RoleClick(ObjLife obj)
    {
        if (BattleFlowController.Instance.currentBattleing)
        {
            Skill_Click(obj.GetObjLifeData());
        }
        else
        {
            RoleClick(obj.GetObjLifeData());
        }
    }

    //在非战斗情况下，角色被点击
    private void RoleClick(ObjLifeData objLifeData)
    {
        if (true)
        {
            //ResetInfo(objLifeData);
        }
        else
        {
            //ResetInfo(obj.battleingData.numInTeam);
        }
    }

    //按下技能后，角色被点击/发动攻击
    private void Skill_Click(ObjLifeData objLifeData)
    {
        /*HerosTeamController.Instance.OffClickTips();
        EnemysTeamController.Instance.OffClickTips();

        if (isMove)
        {
            //在战斗中使用技能位移  会调用结束行动
            HerosTeamController.Instance.MoveRoleInTeam(showWho, obj);
            isMove = false;
        }
        else
        {
            waitSkill.skillBattleingData.taskingResCount++;
            waitSkill.skillBattleingData.battleingResCount++;
            waitSkill.skillBattleingData.cdNow = 0;//!!!结束本回合时会统一加1,待观察

            //缓存伤害包,暂时主要用作处理目标为自身的技能尾巴
            List<ObjLife> targets = new List<ObjLife>();
            //完成一个技能释放动作后设置所有英雄技能为不可用
            foreach (var item in skillButtons)
            {
                item.SetButtonOn(false);
            }

                if (waitSkill.skill.targetType.Equals(SkillTargetType.敌方群体))//多个目标
                {
                    for (int i = 0; i < targetPos.Length; i++)
                    {
                        if (i >= roleTeamController.roleTeam.Count)
                            break;

                        if (targetPos[i])
                        {
                            //roleTeamController.roleTeam[i].objLife.DamageNews(damagePack);
                            targets.Add(roleTeamController.roleTeam[i].objLife);
                        }
                    }
                }
                else//单个目标
                {
                    //obj.DamageNews(damagePack);
                    targets.Add(obj);
                }

                //通知攻击者播放动画
                FightingCameraCon.Instance.Fighting();
                //showWho.objLife.roleController.Fighting(true, waitSkill.skill, damagePack.skillLevel, targets);
            
        }*/

        //EndSkill();
    }
    /*private void SkillMoveDwon(GameObject button)
    {
        //如果当前是敌人正在行动，拒绝点击事件
        if (BattleFlowController.Instance.whoTheControl)
            return;

        HerosTeamController.Instance.OffClickTips();
        EnemysTeamController.Instance.OffClickTips();


        //EndSkill();//清除伤害包--

        foreach (var item in skillButtons)
        {
            item.SelectedOff();
        }
        skillMove.SelectedOn();
        isMove = true;

        targetPos = skillMove.startPos;
        showWho.objLife.roleUi.SetShow(true);
        HerosTeamController.Instance.SetClickTips(targetPos, true);
    }*/

    //
    void EndSkill()
    {
        /*roleTeamController = null;
        waitSkill = null;
        //damagePack = null;
        targetPos = null;*/
    }
    #endregion
    
    public Image imgOrnament1;
    public Image imgOrnament2;
    public Image imgMedal;
    public Image talentImage;
    private const string SPELL_IMG_NAME = "spell_img";
    private const string SELECTED_IMG_NAME = "selected_img";

    public GameObject goTalent;
    public HoverInfoUI talentHoverInfoUI;
    /// <summary>
    /// 勋章和饰品插槽
    /// </summary>
    public List< RoleInfoEquipmentSlot> EquipmentSlots;
    private void Start()
    {
        //添加移入事件、移出事件、点击事件
        for (int i = 0; i < skillButtons.Count; ++i)
        {
            OnEnterSkillButton(skillButtons[i], i);
            OnExitSkillButton(skillButtons[i]);
            OnClickSkillButton(skillButtons[i], i);
        }
        talentHoverInfoUI.AddItem(string.Empty, 0, Color.red);
        //天赋
        UIEventManager.AddTriggersListener(goTalent).onEnter = g => talentHoverInfoUI.gameObject.SetActive(true);// goTalent.transform.Find("Hover").gameObject.SetActive(true);
        UIEventManager.AddTriggersListener(goTalent).onExit = g => talentHoverInfoUI.gameObject.SetActive(false);//goTalent.transform.Find("Hover").gameObject.SetActive(false);
    }
    public bool AddOrnament(ObjData objData, int index) {
        HeroVocation vocation = DataManager.Instance.GetOrnamentDataById(objData.id).heroVocation;
        if (vocation != HeroVocation.所有 && vocation != CurrentSelectHeroData.GetVocation()) return false;
        if (index == 1 && CurrentSelectHeroData.GetHeroMode().ornaments1ID != 0) return false;
        if (index == 2 && CurrentSelectHeroData.GetHeroMode().ornaments2ID != 0) return false;
        CurrentSelectHeroData.AddOrnament(index, objData);

        return true;
    }
    public void RemoveOrnament(int index)
    {
        CurrentSelectHeroData.RemoveOrnament(index);
        heroAttribute.SetInfo(CurrentSelectHeroData);
    }
    /// <summary>
    /// 显示角色信息
    /// </summary>
    /// <param name="objLifeData"></param>
    /// <param name="skillIcons">技能icon</param>
    /// <param name="useables">是否可用</param>
    /// <param name="moraleUseable">士气技能是否可用</param>
    public void ShowRoleInfo(ObjLifeData objLifeData, List<AssetReferenceSprite> skillIcons, List<bool> useables, bool moraleUseable)
    {
        Debug.Log($"测试-ShowRoleInfo");
        CloseAllSelected();
        this.CurrentSelectHeroData = objLifeData;
        //显示属性
        heroAttribute.SetInfo(objLifeData);

        //显示生命条
        //heroHps.SetValue(objLifeData);

        //显示技能图标
        for (int i = 0; i < skillButtons.Count; i++)
        {
            int iTemp = i;
            if (i < skillIcons.Count)
            {
                Image spell_img = skillButtons[i].transform.Find(SPELL_IMG_NAME).GetComponent<Image>();
                skillIcons[iTemp].LoadAssetAsync().Completed += go => spell_img.sprite = go.Result;
                spell_img.color = new Color(1f, 1f, 1f, useables[i] ? 1f : 0.5f);
                spell_img.gameObject.SetActive(true);
            }
            else
            {
                Image spell_img = skillButtons[i].transform.Find(SPELL_IMG_NAME).GetComponent<Image>();
                spell_img.gameObject.SetActive(false);
                spell_img.color = new Color(1f, 1f, 1f, 0.5f);
            }
        }
        ///显示士气技能图标
        OtherSkillData moraleSkill = DataManager.Instance.GetMoraleSkillById(objLifeData.GetMoraleSkillId());
        Image spell = otherSkill.transform.Find(SPELL_IMG_NAME).GetComponent<Image>();
        if (moraleSkill != null)
        {
            moraleSkill.icon.LoadAssetAsync().Completed += go => spell.sprite = go.Result;
            spell.color = new Color(1f, 1f, 1f, moraleUseable ? 1f : 0.5f);
            spell.gameObject.SetActive(true);
            UIEventManager.AddTriggersListener(spell.gameObject).onEnter = g => skillInfo.ShowInfo(spell.gameObject, moraleSkill);
            UIEventManager.AddTriggersListener(spell.gameObject).onExit = g => skillInfo.ExitShow();
            UIEventManager.AddTriggersListener(spell.gameObject).onClick = g => BattleFlowController.Instance.PanelClickEvent(PanelClickType.士气技能);
        }
        else
        {
            spell.gameObject.SetActive(false);
        }


        //显示饰品和勋章
        //if (objLifeData.GetOrnamentId(1) != 0)
        //{
        //    DataManager.Instance.GetOrnamentDataById(objLifeData.GetOrnamentId(1)).Icon.LoadAssetAsync().Completed += go => imgOrnament1.sprite = go.Result;
        //    imgOrnament1.gameObject.SetActive(true);
        //}
        //else
        //{
        //    imgOrnament1.gameObject.SetActive(false);
        //}
        //if (objLifeData.GetOrnamentId(2) != 0)
        //{
        //    DataManager.Instance.GetOrnamentDataById(objLifeData.GetOrnamentId(2)).Icon.LoadAssetAsync().Completed += go => imgOrnament2.sprite = go.Result;
        //    imgOrnament2.gameObject.SetActive(true);
        //}
        //else
        //{
        //    imgOrnament2.gameObject.SetActive(false);
        //}
        if (objLifeData.GetOrnamentId(1) != 0) EquipmentSlots[1].AddtoSlot(DataManager.Instance.GetOrnamentDataById(objLifeData.GetOrnamentId(1)));
        else EquipmentSlots[1].RemoveForSlot();
        if (objLifeData.GetOrnamentId(2) != 0) EquipmentSlots[2].AddtoSlot(DataManager.Instance.GetOrnamentDataById(objLifeData.GetOrnamentId(2)));
        else EquipmentSlots[2].RemoveForSlot();
        if (objLifeData.GetMedal().objId != 0)
        {
            DataManager.Instance.GetMedalByMode(objLifeData.GetMedal()).GetIcon().LoadAssetAsync().Completed += go => imgMedal.sprite = go.Result;
            imgMedal.gameObject.SetActive(true);
        }
        else
        {
            imgMedal.gameObject.SetActive(false);
        }

        //天赋
        TalentData talentData = objLifeData.GetTalentData();
        if (talentData != null)
        {
            string stmp = talentData.TriggerToString() + "\r\n";
            stmp += talentData.OrderToString() + "\r\n";
            stmp += talentData.ChaosToString() + "\r\n";
            talentHoverInfoUI.GetText(0).text = stmp;//.Show(0, stmp, Vector2.zero);
            //Text text = goTalent.transform.Find("Hover").Find("Descript").GetComponent<Text>();
            //text.text = talentData.TriggerToString() + "\r\n";
            //text.text += talentData.OrderToString() + "\r\n";
            //text.text += talentData.ChaosToString() + "\r\n";
        }
    }
    
    /// <summary>
    /// 刷新角色详情
    /// </summary>
    public void RefreshRoleInfo(ObjLifeData objLifeData = null)
    {
        Debug.Log($"测试-RefreshRoleInfo");
        if (objLifeData == null) objLifeData = CurrentSelectHeroData;
        //显示属性
        heroAttribute.SetInfo(objLifeData);

        //显示生命条
        //heroHps.SetValue(objLifeData);

        //显示勋章
        //if (objLifeData.GetMedal().objId != 0) EquipmentSlots[0].AddtoSlot(DataManager.Instance.GetOrnamentDataById(objLifeData.GetMedal().objId));
        //else EquipmentSlots[0].RemoveForSlot();

        //显示饰品
        if (objLifeData.GetOrnamentId(1) != 0) EquipmentSlots[1].AddtoSlot(DataManager.Instance.GetOrnamentDataById(objLifeData.GetOrnamentId(1)));
        else EquipmentSlots[1].RemoveForSlot();
        if (objLifeData.GetOrnamentId(2) != 0) EquipmentSlots[2].AddtoSlot(DataManager.Instance.GetOrnamentDataById(objLifeData.GetOrnamentId(2)));
        else EquipmentSlots[2].RemoveForSlot();
       

        //天赋
        TalentData talentData = objLifeData.GetTalentData();
        Text text = goTalent.transform.Find("Hover")?.Find("Descript")?.GetComponent<Text>();
        if (text)
        {
            text.text = talentData.TriggerToString() + "\r\n";
            text.text += talentData.OrderToString() + "\r\n";
            text.text += talentData.ChaosToString() + "\r\n";
        }

    }
    /// <summary>
    /// 注册鼠标进入技能事件
    /// </summary>
    /// <param name="gameObject"></param>
    /// <param name="skillButtonsIndex"></param>
    private void OnEnterSkillButton(GameObject gameObject, int skillButtonsIndex)
    {
        UIEventManager.AddTriggersListener(gameObject).onEnter = go => skillInfo.ShowInfo(gameObject, skillButtonsIndex);
    }

    /// <summary>
    /// 注册鼠标移出技能事件
    /// </summary>
    /// <param name="gameObject"></param>
    private void OnExitSkillButton(GameObject gameObject)
    {
        UIEventManager.AddTriggersListener(gameObject).onExit = go => skillInfo.ExitShow();
    }

    /// <summary>
    /// 注册鼠标点击技能事件
    /// </summary>
    /// <param name="gameObject"></param>
    /// <param name="skillButtonsIndex"></param>
    private void OnClickSkillButton(GameObject gameObject, int skillButtonsIndex)
    {
        UIEventManager.AddTriggersListener(gameObject).onClick = go => BattleFlowController.Instance.PanelClickEvent(PanelClickType.技能, skillButtonsIndex);
    }

    /// <summary>
    /// 换位事件监听
    /// </summary>
    void ListenerSkillMoveClick()
    {
        UIEventManager.AddTriggersListener(skillMove.gameObject).onClick = go => BattleFlowController.Instance.PanelClickEvent(PanelClickType.换位);
    }

    /// <summary>
    /// 跳过回合事件监听
    /// </summary>
    void ListenerOutButtonClick()
    {
        UIEventManager.AddTriggersListener(outButton).onClick = go => BattleFlowController.Instance.PanelClickEvent(PanelClickType.跳过回合);
    }

    public void OutRoundSure()
    {
        AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
        BattleFlowController.Instance.PanelClickEvent(PanelClickType.跳过回合确定);
    }

    public void OutRoundCancel()
    {
        AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
        BattleFlowController.Instance.PanelClickEvent(PanelClickType.跳过回合取消);
    }

    /// <summary>
    /// 黄色框的显隐
    /// </summary>
    /// <param name="type"></param>
    /// <param name="index"></param>
    public void TriggerSelectedImg(PanelClickType type, bool active = false, int index = 0)
    {
        CloseAllSelected();
        switch (type)
        {
            case PanelClickType.技能:
                skillButtons[index].transform.Find(SELECTED_IMG_NAME)?.gameObject.SetActive(active);
                break;
            case PanelClickType.换位:
                skillMove.transform.Find(SELECTED_IMG_NAME).gameObject.SetActive(active);
                break;
            case PanelClickType.跳过回合:
                outButton.transform.Find(SELECTED_IMG_NAME).gameObject.SetActive(active);
                outTips.SetActive(true);
                break;
            case PanelClickType.跳过回合确定:
            case PanelClickType.跳过回合取消:
                outTips.SetActive(false);
                break;
            case PanelClickType.士气技能:
                otherSkill.transform.Find(SELECTED_IMG_NAME).gameObject.SetActive(active);
                break;
            default:
                break;
        }
    }

    public void CloseAllSelected()
    {
        foreach (var sb in skillButtons)
        {
            sb.transform.Find(SELECTED_IMG_NAME).gameObject.SetActive(false);
        }
        otherSkill.transform.Find(SELECTED_IMG_NAME).gameObject.SetActive(false);
        skillMove.transform.Find(SELECTED_IMG_NAME).gameObject.SetActive(false);
        outButton.transform.Find(SELECTED_IMG_NAME).gameObject.SetActive(false);
    }

    /// <summary>
    /// 解救的效果
    /// </summary>
    public Text buff;
    public void RescueBuff(string text)
    {
        buff.text += text + "\n";
    }
}

