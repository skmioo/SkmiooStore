using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Net;
using System;
using System.Linq;

/// <summary>
/// 单个角色的UI控制
/// </summary>
public class RoleUiController : MonoBehaviour
{
    // public static Action<ObjLife> RoleClick;//被RoleInfoView注册总控,
    //  public static Action<ObjLife> RoleEnter;//被enemyinfo注册,划入时显示角色信息

    public GameObject clickObj;
    public SelectionTips selectionTips;
    //public UpdataHpUI updataHp;
    public HeroHps heroHps;
    public ActionCount actionCount;

    public Transform prop;

    public StatusBox statusBox;

    //public ValueShow valueShow;
    public GameObject valueShowObj;
    public GameObject otherValueShowObj;
    public Transform valueShowBox;

    CanvasGroup clickGrop;


    ObjLife _objLife;
    ObjLife objLife
    {
        get {
            if (_objLife == null)
            {
                _objLife = gameObject.GetComponent<ObjLife>();
            }

            return _objLife;
        }
    }


    /// <summary>
    /// 正在释放技能--?有需要吗？暂时放在这里
    /// </summary>
    public bool go;

    /*private void Awake()
    {
        //EventListener.Get(clickArea).onClick = (go) => statusClick();//status不接收光线投射，
        UIEventManager.AddTriggersListener(clickObj).onClick += statusClick;
        UIEventManager.AddTriggersListener(clickObj).onEnter += statusEnter;
        UIEventManager.AddTriggersListener(clickObj).onRightClick += statusOnRightClick;

        clickGrop = clickObj.GetComponent<CanvasGroup>();
        objLife = GetComponent<ObjLife>();

        //status_img_group = status.GetComponent<CanvasGroup>();
        //status_image = status.GetComponent<Image>();
    }

    private void OnDestroy()
    {
        
    }

    private void Start()
    {
        //updataHp.Init(objLife);      
        heroHps.SetValue(objLife.GetObjLifeData());
    }*/

    /// <summary>
    /// 设置行动点显示
    /// </summary>
    /// <param name="inI"></param>
    public void actionCountSet(int inI)
    {
        actionCount.SetCount(inI);
    }


    /// <summary>
    /// 设置血量显示 
    /// </summary>
    public void SetHp(/*DamagePackType damagePack*/)
    {

        /*if (damagePack == DamagePackType.damage)
        {
            updataHp.ReduceHp();
        }
        else
        {
            updataHp.AddHp();
        }*/
        heroHps.SetValue(objLife.GetObjLifeData());
    }

    public void ShowValue(/*int value, DamagePackType damagePackType*/)
    {
        GameObject go = Instantiate(valueShowObj, valueShowBox);
        //go.GetComponent<ValueShow>().ShowStart(value, damagePackType);
    }

    public void ShowOtherVlue(bool isMorale, int value)
    {
        GameObject go = Instantiate(otherValueShowObj, valueShowBox);
        go.GetComponent<OtherValueShow>().ShowValue(isMorale, value);
    }

    public void ShowOtherValue(/*int value,DamagePackType damagePackType*/)
    {

    }

    #region 点击提示模块

    /// <summary>
    /// 设置角色是否正在行动
    /// </summary>
    /// <param name="setShow"></param>
    public void SetShow(bool setShow)
    {
        if (setShow)
        {
            selectionTips.ActionTpis();
        }
        else
        {
            selectionTips.OffTips();
        }
    }

    /// <summary>
    /// 设置是否可以被选中
    /// </summary>
    /// <param name="on"></param>
    public void SetSelected(bool on, bool heroOrEnemmy, bool attacker)
    {
        if (!on)//关闭提示
        {
            OffClickTips();
            return;
        }

        //提示开
        if (attacker)//英雄发起的
        {
            if (heroOrEnemmy)
            {
                selectionTips.FriendsTips();

            }
            else
            {
                selectionTips.EnemyTips();

            }
            clickGrop.blocksRaycasts = true;
        }
        else//怪物发起的
        {
            if (heroOrEnemmy)
            {
                selectionTips.EnemyTips();

            }
            else
            {
                selectionTips.FriendsTips();
            }
            clickGrop.blocksRaycasts = false;
        }
    }

    /// <summary>
    /// 关闭点击与提示
    /// </summary>
    public void OffClickTips()
    {
        selectionTips.OffTips();
        OffClick();
    }

    /// <summary>
    /// 关闭可点击
    /// </summary>
    public void OffClick()
    {
        clickGrop.blocksRaycasts = false;

    }

    /// <summary>
    /// 开启可点击
    /// </summary>
    public void OnClick()
    {
        clickGrop.blocksRaycasts = true;
    }

    //public void statusOnRightClick(GameObject go)
    //{      
    //    //objLife.roleTeamController.RoleRightClick(objLife);
    //}

    //监听被点击的事件
    //public void statusClick(GameObject go)
    //{     
    //    RoleClick?.Invoke(objLife);
    //}

    //public void statusEnter(GameObject go)
    //{
    //    RoleEnter?.Invoke(objLife);
    //}
    #endregion





    public GameObject goSelectTips;
    public GameObject goTargetTips;

    Sprite lastSprite;

    /// <summary>
    /// 图片-备选友方
    /// </summary>
    public Sprite spFriend;
    /// <summary>
    /// 图片-备选敌方
    /// </summary>
    public Sprite spEnemy;
    /// <summary>
    /// 图片-敌方hover
    /// </summary>
    public Sprite spEnemyHover;
    public GameObject goTalentNode;
    private GameObject TalentTrigger;
    private Text TalentTip;
    private GameObject TalentEffect;
    private void Awake()
    {
        TalentTrigger = goTalentNode.transform.Find("TalentTrigger").gameObject;
        TalentTip = TalentTrigger.transform.Find("Text").GetComponent<Text>();
        if (TalentTip != null) TalentTip.text = "燃";

        TalentEffect = goTalentNode.transform.Find("TalentEffect").gameObject;
        //添加点击事件
        AddClickEvent(gameObject);
    }

    /// <summary>
    /// 注册点击事件
    /// </summary>
    /// <param name="gameObject"></param>
    private void AddClickEvent(GameObject gameObject)
    {
        UIEventManager.AddTriggersListener(gameObject).onLeftClick = go => BattleFlowController.Instance.RoleBeSelected(gameObject.GetComponent<ObjLife>());
        UIEventManager.AddTriggersListener(gameObject).onRightClick = go => BattleFlowController.Instance.ShowRoleInfoPanel(gameObject.GetComponent<ObjLife>());
    }

    /// <summary>
    /// 显示选中提示
    /// </summary>
    public void ShowSeletionTips()
    {
        if (objLife.GetRoleType() == RoleType.怪物) return;
        goSelectTips.SetActive(true);
        ShowPing();
    }

    /// <summary>
    /// 关闭选中提示
    /// </summary>
    public void CloseSelectionTips()
    {
        try
        {
            goSelectTips.SetActive(false);
        }
        catch (MissingReferenceException e)
        {
            return;
        }
    }

    private void ShowPing()
    {
        goSelectTips.GetComponent<RectTransform>().DOSizeDelta(new Vector2(1, 1), 0.48f).OnComplete(ShowPong);
    }

    private void ShowPong()
    {
        goSelectTips.GetComponent<RectTransform>().DOSizeDelta(new Vector2(0, 1), 0.48f).OnComplete(ShowPing);
    }

    /// <summary>
    /// 显示目标提示
    /// </summary>
    public void ShowTargetTips(RoleRelationType roleRelationType, bool isEmemyHover = false)
    {
        lastSprite = goTargetTips.GetComponent<SpriteRenderer>().sprite;

        if (roleRelationType.Equals(RoleRelationType.友方))
        {
            goTargetTips.SetActive(true);
            goTargetTips.GetComponent<SpriteRenderer>().sprite = spFriend;
        }
        else
        {
            if (isEmemyHover) { goSelectTips.SetActive(true); }
            else
            {
                goTargetTips.SetActive(true);
                goTargetTips.GetComponent<SpriteRenderer>().sprite = spEnemy;
            }
        }

        //goTargetTips.GetComponent<SpriteRenderer>().sprite = roleRelationType.Equals(RoleRelationType.友方) ? spFriend : (isEmemyHover ? spEnemyHover : spEnemy);

        if (roleRelationType.Equals(RoleRelationType.友方))
            goTargetTips.GetComponent<Transform>().localPosition = new Vector3(1.01f, 0.7f, 0);
        //else if (isEmemyHover)
        //    goTargetTips.GetComponent<Transform>().localPosition = new Vector3(1.01f, -0.82f, 0);
        else
            goTargetTips.GetComponent<Transform>().localPosition = new Vector3(1.01f, 0.7f, 0);
    }

    /// <summary>
    /// 关闭目标提示
    /// </summary>
    public void CloseTargetTips(bool isClose)
    {
        goSelectTips.SetActive(false);
        if (isClose)
        {
            lastSprite = goTargetTips.GetComponent<SpriteRenderer>().sprite = null;
            goTargetTips.SetActive(false);
        }
        else
        {
            if (lastSprite != null)
            {
                if (lastSprite == spEnemyHover) goTargetTips.SetActive(false);
                goTargetTips.GetComponent<SpriteRenderer>().sprite = lastSprite;
                goTargetTips.GetComponent<Transform>().localPosition = new Vector3(1.01f, 0.7f, 0);
            }
            else
            {
                lastSprite = goTargetTips.GetComponent<SpriteRenderer>().sprite = null;
                goTargetTips.SetActive(false);
            }
        }
    }

    /// <summary>
    /// 更新血条、伤势条、士气条
    /// </summary>
    /// <param name="objLifeData"></param>
    public void UpdateValue(ObjLifeData objLifeData)
    {
        heroHps.SetValue(objLifeData);
    }




    public GameObject goBuffShow;
    private GameObject goBuffInfo;

    private void Start()
    {
        foreach (Transform t in statusBox.transform.GetComponentInChildren<Transform>())
        {
            UIEventManager.AddTriggersListener(t.gameObject).onEnter = go => Show(t.transform, t.GetComponent<BuffType>().buffType);
            UIEventManager.AddTriggersListener(t.gameObject).onExit = go => Hidden();
        }

        goBuffInfo = GameObject.Find("BuffInfo");
        _camera = FightingCameraCon.Instance.mainCamera;// GameObject.Find("Camera")?.GetComponent<Camera>();
        canvas = GameObject.Find("BattleCanvas")?.GetComponent<Canvas>();

    }

    /// <summary>
    /// 结束战斗后才会生效的BUFF
    /// </summary>
    public void EndBuff()
    {
        var perBuffs = objLife.GetPermanentBuff();

        foreach (var item in perBuffs)
        {
            var buffType = item.buffType;
            ObjPermanentBuff buff;
            switch (buffType)
            {
                case ObjBuffType.每次战斗结束回复士气:
                    buff = objLife.GetPermanentBuff().Find(x => x.buffType == ObjBuffType.每次战斗结束回复士气);
                    if (buff != null)
                    {
                        int sqv = objLife.GetMorale() + buff.buffValue;
                        objLife.UpdateMorale(sqv.Clamp(objLife.GetMinMorale(), objLife.GetMaxMorale()), "战斗结束后生效buff 每次战斗结束回复士气");
                    }
                    break;
                case ObjBuffType.每次战斗结束回复生命:
                    buff = objLife.GetPermanentBuff().Find(x => x.buffType == ObjBuffType.每次战斗结束回复生命);
                    if (buff != null)
                    {
                        int hpv = (int)objLife.GetHp() + buff.buffValue;
                        objLife.UpdateHp(hpv.Clamp(0, objLife.GetMaxHp()));
                    }
                    break;
            }
        }
    }

    public void UpdateBuff()
    {
        bool ishave = false;
        for (int i = 0; i < statusBox.transform.childCount; ++i)
        {
            GameObject goBuff = statusBox.transform.GetChild(i).gameObject;
            ObjBuffType buffType = goBuff.GetComponent<BuffType>().buffType;
            List<ObjSkillBuff> skillBuffs = objLife.GetSkillBuffs();
            switch (buffType)
            {
                case ObjBuffType.标记:
                case ObjBuffType.流血:
                case ObjBuffType.陷阱:
                case ObjBuffType.眩晕:
                case ObjBuffType.中毒:
                case ObjBuffType.炸弹:
                case ObjBuffType.充分准备:
                case ObjBuffType.增减益:
                case ObjBuffType.赦免:
                case ObjBuffType.割礼:
                case ObjBuffType.包裹:
                case ObjBuffType.吞噬:
                case ObjBuffType.延迟召唤:
                case ObjBuffType.死亡召唤:
                //case ObjBuffType.伤害修正:
                case ObjBuffType.守护:
                case ObjBuffType.被守护:
                case ObjBuffType.反击:
                    goBuff.SetActive(objLife.ExistsSkillBuff(buffType));
                    break;
                case ObjBuffType.持续回复生命:
                    goBuff.SetActive(objLife.ExistsSkillBuff(ObjBuffType.持续回复生命));
                    break;
                case ObjBuffType.增益:
                    goBuff.SetActive(objLife.ExistsSkillBuff(ObjBuffType.增益) && !objLife.ExistsSkillBuff(ObjBuffType.减益));
                    break;
                case ObjBuffType.减益:
                    goBuff.SetActive(!objLife.ExistsSkillBuff(ObjBuffType.增益) && objLife.ExistsSkillBuff(ObjBuffType.减益));
                    break;
                case ObjBuffType.人心惶惶:
                    goBuff.SetActive(objLife.ExistsPermanentBuff(ObjBuffType.人心惶惶));
                    break;
                case ObjBuffType.祈祷:
                    goBuff.SetActive(objLife.ExistsPermanentBuff(ObjBuffType.祈祷));
                    break;
                case ObjBuffType.正向士气:
                    ishave = false;
                    if (objLife.ExistsSkillBuff(ObjBuffType.持续回复士气) && skillBuffs.Count > 0)
                    {
						var ienumater = skillBuffs.Where(s => s.buffType == ObjBuffType.持续回复士气 && s.buffValue > 0);
						int round = ienumater.Count() > 0 ? ienumater.Min(s => s.round) : 0;
						int value = ienumater.Count() > 0 ? ienumater.Sum(s => s.buffValue) : 0;
						if (round > 0 && value > 0) ishave = true;
					}
					goBuff.SetActive(ishave);
					break;
                case ObjBuffType.负向士气:
                    ishave = false;
                    if (objLife.ExistsPermanentBuff(ObjBuffType.血灌瞳人)) ishave = true;
                    if (objLife.ExistsPermanentBuff(ObjBuffType.心力憔悴)) ishave = true;
                    if (objLife.ExistsSkillBuff(ObjBuffType.持续回复士气) && skillBuffs.Count > 0)
                    {
                        var ienumater = skillBuffs.Where(s => s.buffType == ObjBuffType.持续回复士气 && s.buffValue < 0);
                        int round = ienumater.Count() > 0 ? ienumater.Min(s => s.round) : 0;
                        int value = ienumater.Count() > 0 ? ienumater.Sum(s => s.buffValue) : 0;
                        if (round > 0 && value < 0) ishave = true;
                    }
                    if (objLife.ExistsPermanentBuff(ObjBuffType.恐惧之心)) ishave = true;
					goBuff.SetActive(ishave);
					break;
                case ObjBuffType.每次战斗结束回复士气:
                    goBuff.SetActive(objLife.ExistsPermanentBuff(ObjBuffType.每次战斗结束回复士气));
                    break;
                case ObjBuffType.每次战斗结束回复生命:
                    goBuff.SetActive(objLife.ExistsPermanentBuff(ObjBuffType.每次战斗结束回复生命));
                    break;
                case ObjBuffType.濒死:
                    if (!goBuff.activeSelf && objLife.ExistsPermanentBuff(ObjBuffType.濒死))
                    {
                        AudioManager.Instance.PlayAudio(AudioName.MAGIC_SPELL_Distinct_Thrust_Bright_Pad_stereo, AudioType.BattleCommon);
                    }
					goBuff.SetActive(objLife.ExistsPermanentBuff(ObjBuffType.濒死));
					break;

            }
        }
    }

    public Camera _camera;
    public Canvas canvas;

    public void Show(Transform transform, ObjBuffType buffType)
    {
        string str = "";
        int round, value;
        List<ObjSkillBuff> skillBuffs = objLife.GetSkillBuffs();
        List<ObjSkillBuff> guardians = null;
        ObjLife link = null;
        switch (buffType)
        {
            case ObjBuffType.反击:
                round = skillBuffs.Where(s => s.buffType == buffType).Max(s => s.round);
                str = $"反击\n持续{round}回合\n准备就绪，随时反击";
                break;
            case ObjBuffType.守护:
                round = skillBuffs.Where(s => s.buffType == buffType).Max(s => s.round);
                guardians = skillBuffs.Where(s => s.buffType == buffType).ToList();
                if (guardians != null && guardians.Count > 0)
                {
                    link = guardians[0].linkTarget;
                }
                str += $"保护（{(link == null ? "未知" : link.GetHeroName())}）(持续{round}回合)";
                break;
            case ObjBuffType.被守护:
                round = skillBuffs.Where(s => s.buffType == buffType).Max(s => s.round);
                guardians = skillBuffs.Where(s => s.buffType == buffType).ToList();
                if (guardians != null && guardians.Count > 0)
                {
                    link = guardians[0].linkTarget;
                }
                str += $"被保护者（{objLife.GetHeroName()}）(持续{round}回合) \n 受到‘{(link == null ? "未知" : link.GetHeroName())}’的守护";
                break;
            //case ObjBuffType.伤害修正:
            //    round = skillBuffs.Where(s => s.buffType == buffType).Max(s => s.round);
            //    value = skillBuffs.Where(s => s.buffType == buffType).Sum(s => s.buffValue);
            //    str += $"增加伤害\"{value}%\"持续\"{round}\"回合";
            //    break;
            //case ObjBuffType.暴击伤害:
            //    round = skillBuffs.Where(s => s.buffType == buffType).Max(s => s.round);
            //    value = skillBuffs.Where(s => s.buffType == buffType).Sum(s => s.buffValue);
            //    str += $"增加暴击伤害\"{value}%\"持续\"{round}\"回合";
            //    break;
            case ObjBuffType.死亡召唤:
                var deathSummon = BattleFlowController.Instance.GetRoleSummon(objLife, ObjBuffType.延迟召唤);
                if (deathSummon.Length > 0)
                {
                    var deathSummonData = DataManager.Instance.GetObjLifeDataById(deathSummon[0].Target);
                    str += $"召唤怪物\"{deathSummonData.GetHeroName()}\"";
                }
                break;
            case ObjBuffType.延迟召唤:
                var delaySummon = BattleFlowController.Instance.GetRoleSummon(objLife, ObjBuffType.延迟召唤);
                if (delaySummon.Length > 0)
                {
                    var delaySummonData = DataManager.Instance.GetObjLifeDataById(delaySummon[0].Target);
                    str += $"还有\"{delaySummon[0].Round}\"回合后召唤怪物\"{delaySummonData.GetHeroName()}\"";
                }
                break;
            case ObjBuffType.充分准备:
                str += $"下个技能必定命中且暴击";
                break;
            case ObjBuffType.标记:
                round = skillBuffs.Where(s => s.buffType == buffType).Max(s => s.round);
                str += $"被标记（{round}回合）";
                break;
            case ObjBuffType.眩晕:
                round = skillBuffs.Where(s => s.buffType == buffType).Max(s => s.round);
                str += $"无法行动（{round}回合）";
                break;
            case ObjBuffType.赦免:
                if (objLife.ExistsSkillBuff(ObjBuffType.赦免) && skillBuffs.Count > 0)
                {
                    round = skillBuffs.Where(s => s.buffType == buffType).Max(s => s.round);
                    str += $"抵挡所有伤害（{round}回合）$";
                }
                break;
            case ObjBuffType.流血:
                List<ObjSkillBuff> liuxuebuff = objLife.GetSkillBuffs().Where(s => s.buffType == ObjBuffType.流血加重).ToList();
                value = 0;
                foreach (var buff in liuxuebuff)
                {
                    if(buff.round>0)
                    {
                        value += buff.buffValue;
                    }

                }
                round = skillBuffs.Where(s => s.buffType == buffType).Min(s => s.round);
                value += skillBuffs.Where(s => s.buffType == buffType).Sum(s => s.buffValue);
                str += $"{-value}伤害下次行动（{round}回合）";
                break;
            case ObjBuffType.中毒:
                round = skillBuffs.Where(s => s.buffType == buffType).Min(s => s.round);
                value = skillBuffs.Where(s => s.buffType == buffType).Sum(s => s.buffValue);
                str += $"{-value}伤害下次行动（{round}回合）";
                break;
            case ObjBuffType.持续回复生命:
                if (objLife.ExistsSkillBuff(ObjBuffType.持续回复生命) && skillBuffs.Count > 0)
                {
                    round = skillBuffs.Where(s => s.buffType == ObjBuffType.持续回复生命).Min(s => s.round);
                    value = skillBuffs.Where(s => s.buffType == ObjBuffType.持续回复生命).Sum(s => s.buffValue);
                    str += $"{value}生命回复下次行动（{round}回合）";
                }
                break;
            case ObjBuffType.陷阱:
                round = skillBuffs.Where(s => s.buffType == buffType).Min(s => s.round);
                value = skillBuffs.Where(s => s.buffType == buffType).Sum(s => s.buffValue);
                str += $"位移后造成{-value}点伤害（{round}回合）";
                break;
            case ObjBuffType.炸弹:
                round = skillBuffs.Where(s => s.buffType == buffType).Min(s => s.round);
                value = skillBuffs.Where(s => s.buffType == buffType).Sum(s => s.buffValue);
                str += $"{round}回合后爆炸，造成{-value}点伤害）";
                break;
            case ObjBuffType.暴击伤害:
            case ObjBuffType.伤害修正:
            case ObjBuffType.增益:
            case ObjBuffType.减益:
            case ObjBuffType.增减益:
                //合并buff
                List<ObjSkillBuff> buffs = skillBuffs.FindAll(s => BattleCalculating.IsDebuff(s.buffType));
                List<ObjSkillBuff> result = new List<ObjSkillBuff>();
                foreach (var buff in buffs)
                {
                    if (!result.Exists(s => s.buffType == buff.buffType))
                    {
                        result.Add(new ObjSkillBuff(buff));
                    }
                    else
                    {
                        ObjSkillBuff osb = result.Find(s => s.buffType == buff.buffType);
                        osb.round = buff.round > osb.round ? osb.round : buff.round;
                        osb.buffValue += buff.buffValue;
                    }
                }
                //拼接字符串
                foreach (var buff in result)
                {
                    if (buff.buffValue > 0)
                    {
                        str += buff.ToString() + "$";
                    }
                }
                foreach (var buff in result)
                {
                    if (buff.buffValue <= 0)
                    {
                        str += buff.ToString() + "$";
                    }
                }
                break;
            case ObjBuffType.人心惶惶:
                str += $"人心惶惶$预感到了不好的事情即将发生$士气大于15时恢复$";
                break;
            case ObjBuffType.祈祷:
                str += $"祈祷$xxxxxxxxxxxxx";
                break;
            case ObjBuffType.正向士气:
                if (objLife.ExistsSkillBuff(ObjBuffType.持续回复士气) && skillBuffs.Count > 0)
                {
                    for (int i = 0; i < skillBuffs.Count; ++i) Debug.Log("测试-SillBusffs:" + skillBuffs[i].buffType);
                    round = skillBuffs.Where(s => s.buffType == ObjBuffType.持续回复士气 && s.buffValue > 0).Min(s => s.round);
                    value = skillBuffs.Where(s => s.buffType == ObjBuffType.持续回复士气 && s.buffValue > 0).Sum(s => s.buffValue);
                    str += $"{value}士气回复下次行动（{round}回合）";
                }
                break;
            case ObjBuffType.负向士气:
                if (objLife.ExistsPermanentBuff(ObjBuffType.血灌瞳人))
                {
                    str += $"血灌瞳人$士气无法增长$";
                }
                if (objLife.ExistsPermanentBuff(ObjBuffType.心力憔悴))
                {
                    str += $"心力憔悴$";
                }
                if (objLife.ExistsSkillBuff(ObjBuffType.持续回复士气) && skillBuffs.Count > 0)
                {
                    round = skillBuffs.Where(s => s.buffType == ObjBuffType.持续回复士气 && s.buffValue < 0).Min(s => s.round);
                    value = skillBuffs.Where(s => s.buffType == ObjBuffType.持续回复士气 && s.buffValue < 0).Sum(s => s.buffValue);
                    str += $"{-value}士气减少下次行动（{round}回合）";
                }
                if (objLife.ExistsPermanentBuff(ObjBuffType.恐惧之心))
                {
                    str += $"恐惧之心$50%概率释放技能失败$持续3回合$";
                }
                break;
            case ObjBuffType.濒死:
                str += $"听到了教宗的低语...";
                break;

            case ObjBuffType.割礼:
				if (objLife.ExistsSkillBuff(ObjBuffType.割礼))
				{
					if (objLife.GetHp() / objLife.GetMaxHp() >= 0.3f)
					{
						round = skillBuffs.Where(s => s.buffType == ObjBuffType.割礼 && s.buffValue < 0).Min(s => s.round);
						value = skillBuffs.Where(s => s.buffType == ObjBuffType.割礼 && s.buffValue < 0).Sum(s => s.buffValue);
						str = $"{-value}士气减少下次行动（{round}回合）";
					}
					else
					{
						str += $"……所有人都要受礼……";
					}
				} 
                break;
            case ObjBuffType.包裹:
                round = skillBuffs.Where(s => s.buffType == buffType).Max(s => s.round);
                str += $"无法行动（{round}回合）";
                break;
            case ObjBuffType.吞噬:
				round = skillBuffs.Where(s => s.buffType == buffType).Max(s => s.round);
				str += $"吞噬被包裹的英雄，{round}回合后吐出 ,吐出的时候吸收该英雄所有的生命值，该英雄生命值为0";
                break;
        }

        //显示
        if (goBuffInfo != null && goBuffInfo.GetComponent<RectTransform>() != null && str != string.Empty)
        {
            goBuffInfo.GetComponentInChildren<Text>().text = str.Replace("$", "\n");
            Vector3 pos = _camera.WorldToScreenPoint(transform.position);
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, pos, canvas.worldCamera, out Vector2 res);
            res += new Vector2(goBuffInfo.GetComponent<RectTransform>().rect.width - 200f, -goBuffInfo.GetComponent<RectTransform>().rect.height - 80f) / 2f;
            goBuffInfo.transform.localPosition = res;

            goBuffInfo.transform.localScale = Vector3.one;
        }
    }

    public void Hidden()
    {
        goBuffInfo.transform.localScale = Vector3.zero;
    }

    public void ShowTalentTrigger()
    {
        TalentTrigger.SetActive(true);
        Invoke("HiddenTalentTrigger", 2f);
    }

    public void HiddenTalentTrigger()
    {
        TalentTrigger.SetActive(false);
    }
}
