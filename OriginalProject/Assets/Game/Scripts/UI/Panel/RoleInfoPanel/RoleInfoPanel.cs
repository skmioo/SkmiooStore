using Datas;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class RoleInfoPanel : BasePanel
{
    public static RoleInfoPanel instance;
    public GameObject panelRoot;
    public GameObject rolePanelBG;
    public Slider sliderHP;
    public Text txtNowHP;
    public RawImage[] imgMoraleAry;
    public Text txtNowMorale;
    public Color[] colorMoraleAry;
    public Image imgIcon;
    public Text txtHeroName;
    public Text txtVocation;
    public Image imgModel;
    public Image topImgModel;
    public GameObject fadeBg;

    public Text txtMaxHp;
    public Text txtRate;
    public Text txtCrits;
    public Text txtDodge;
    public Text txtDefence;
    public Text txtSpeed;
    public Text txtAttack;

    public Text txtVertigo;
    public Text txtPoison;
    public Text txtBleed;
    public Text txtPosition;
    public Text txtDebuff;
    public Text txtDeath;

    public Button btnRename;
    public Button btnExpel;

    public List<GameObject> goSkills;
    public GameObject goOtherSkill;
    public SkillInfo skillInfo;

    public GameObject goRenameTip;
    public GameObject goExpelTip;
    public InputField inpName;

    public Image imgOrnament1;
    public Image imgOrnament2;
    public Image imgMedal;
    public Image imgTalent;
    Text talentText;
    GameObject talentBackImage;

    private const string SPELL_IMG = "spell_img";
    private const string SELECTED_IMG = "selected_img";

    public Image[] heroPosImage;
    public Image[] enemyPosImage;

    private int[] heroPos = new int[4];
    private int[] enemyPos = new int[4];

    private ObjLifeData objLifeData;
    private bool allowUpdate;

    private HoverInfoUI hover;
    private const string STR_HOVER = "HoverInfoUI";

    public RoleInfoItem[] itemAry;
    Vector2 originPos;

    RoleImageDataSet roleImageRerence;

    Color selectedColor;
    Color selectedColor2;

    bool isFromRecruiting;

    public ObjLifeData CurrentSelectHeroData { get { return objLifeData; } }
    private void Start()
    {
        instance = this;
        originPos = panelRoot.GetComponent<RectTransform>().anchoredPosition;
        inpName.onValueChanged.AddListener((s) => { AudioManager.Instance.PlayAudio(AudioName.TABLE_TENNIS_Ball_Table_Hit_02_mono, AudioType.Common); });
        Addressables.LoadAssetAsync<RoleImageDataSet>("roleData/roleImageData").Completed += inGo =>
        {
            roleImageRerence = inGo.Result;
        };

        ColorUtility.TryParseHtmlString("#F3C56B", out selectedColor);
        ColorUtility.TryParseHtmlString("#131313", out selectedColor2);
    }

    public void Show(ObjLifeData objLifeData, bool allowRename, bool allowExpel, bool allowUpdate)
    {
        if (BattleFlowController.Instance)
        {
            BattleFlowController.Instance.IsInteracting = true;
        }     
        CloseRenameTip();
        CloseExpelTip();
        panelRoot.GetComponent<RectTransform>().anchoredPosition = originPos;
        objLifeData.GetIcon().LoadAssetAsync().Completed += go => imgIcon.sprite = go.Result;
        txtHeroName.text = objLifeData.GetHeroName();
        txtVocation.text = objLifeData.GetVocation().ToString();
        //objLifeData.GetRoleImage().LoadAssetAsync().Completed += go => imgModel.sprite = go.Result;
        refreshRoleModeImage(objLifeData.GetId());

        ResetText(objLifeData);
        ResetOrnament(objLifeData);
        ResetMedal(objLifeData);

        List<SkillData> skillDatas = DataManager.Instance.GetSkillDatasByIds(objLifeData.GetSkillModes().Select(s => s.skillId).ToList());
        for (int i = 0; i < Mathf.Min(goSkills.Count, skillDatas.Count); ++i)
        {
            ShowSkillIcon(skillDatas[i].icon, goSkills[i].transform.Find(SPELL_IMG).GetComponent<Image>());

            if (objLifeData.GetSkillModes()[i].isUse)
                goSkills[i].transform.Find(SELECTED_IMG).GetComponent<Image>().color = selectedColor;
            else
                goSkills[i].transform.Find(SELECTED_IMG).GetComponent<Image>().color = selectedColor2;

            AddHoverEvent(goSkills[i], skillDatas[i]);
            if (allowUpdate)
            {
                AddClickEvent(goSkills[i], objLifeData.GetSkillModes()[i]);
            }
        }

        OtherSkillData otherSkillData = DataManager.Instance.GetMoraleSkillById(objLifeData.GetMoraleSkillId());
        if (otherSkillData != null)
        {
            ShowSkillIcon(otherSkillData.icon, goOtherSkill.transform.Find(SPELL_IMG).GetComponent<Image>());
            goOtherSkill.transform.Find(SELECTED_IMG).GetComponent<Image>().color = selectedColor;
            goOtherSkill.transform.Find(SPELL_IMG).gameObject.SetActive(true);
            //AddHoverEvent(goOtherSkill.transform.Find(SPELL_IMG).gameObject, otherSkillData);
            AddHoverEvent(goOtherSkill, otherSkillData);
        }
        else
        {
            goOtherSkill.transform.Find(SELECTED_IMG).GetComponent<Image>().color = selectedColor2;
            goOtherSkill.transform.Find(SPELL_IMG).gameObject.SetActive(false);
        }


        {
            var talentData = objLifeData.GetTalentData();
            string tempString = talentData.TriggerToString();
            tempString += "\n " + talentData.OrderToString();
            tempString += "\n " + talentData.ChaosToString();
            talentBackImage = imgTalent.transform.Find("RawImage").gameObject;
            talentText = talentBackImage.transform.Find("TalentText").GetComponent<Text>();
            talentText.text = tempString;
            talentBackImage.SetActive(false);
            AddHoverEvent(imgTalent.gameObject);

        }

        ResetPreferPosition(objLifeData);

        btnRename.gameObject.SetActive(allowRename);
        btnExpel.gameObject.SetActive(allowExpel);

        panelRoot.SetActive(true);
        this.objLifeData = objLifeData;
        this.allowUpdate = allowUpdate;

        BuildPanelMag.Instance?.onCloseAllBuild();
        BuildPanelMag.Instance?.setTouchBox(false);

        KeyEventController.Instance.onEscAction += Close;
        if (fadeBg != null)
            fadeBg.SetActive(true);

        Camp.bShowRoleInfo = true;

        isFromRecruiting = false;
    }

    /// <summary>
    /// 来自招募的面板
    /// </summary>
    /// <param name="objLifeData"></param>
    /// <param name="allowRename"></param>
    /// <param name="allowExpel"></param>
    /// <param name="allowUpdate"></param>
    /// <param name="fromRecruiting"></param>
    public void Show(ObjLifeData objLifeData, bool allowRename, bool allowExpel, bool allowUpdate,bool fromRecruiting)
    { Show(objLifeData, allowRename, allowExpel, allowUpdate); isFromRecruiting = true; }

    /// <summary>
    /// 清空饰品格
    /// </summary>
    /// <param name="inIndex"></param>
    public void clearOrnament(int inIndex = -1)
    {
        if (inIndex == 1)
            itemAry[1].clear();

        if (inIndex == 2)
            itemAry[2].clear();

        if (inIndex == -1)
        {
            itemAry[1].clear();
            itemAry[2].clear();
        }
    }

    /// <summary>
    /// 清空勋章格
    /// </summary>
    public void clearMedal() { itemAry[0].clear(); }

    /// <summary>
    /// 更新属性
    /// </summary>
    /// <param name="objLifeData"></param>
    private void ResetText(ObjLifeData objLifeData)
    {
        txtMaxHp.text = $"最大生命 ：{objLifeData.GetMaxHp()}";
        txtRate.text = $"精准 ：{objLifeData.GetRate()}";
        txtCrits.text = $"暴击 ：{objLifeData.GetCrits()}";
        txtDodge.text = $"闪避 ：{objLifeData.GetDodge()}";
        txtDefence.text = $"减伤 ：{objLifeData.GetDefence()}";
        txtSpeed.text = $"速度 ：{objLifeData.GetSpeed()}";
        txtAttack.text = $"攻击 ：{objLifeData.GetMinAtk()} - {objLifeData.GetMaxAtk()}";

        txtVertigo.text = $"眩晕 ：{objLifeData.GetVertigo()}";
        txtPoison.text = $"中毒 ：{objLifeData.GetPoison()}";
        txtBleed.text = $"流血 ：{objLifeData.GetBleed()}";
        txtPosition.text = $"位移 ：{objLifeData.GetPosition()}";
        txtDebuff.text = $"减益 ：{objLifeData.GetDebuff()}";
        txtDeath.text = $"即死 ：{objLifeData.GetDeath()}";

        ResetHP(objLifeData);
        ResetMorale(objLifeData);
    }

    /// <summary>
    /// 更新hp显示
    /// </summary>
    /// <param name="objLifeData"></param>
    private void ResetHP(ObjLifeData objLifeData)
    {
        objLifeData.SetHp(objLifeData.GetMaxHp());
        sliderHP.value = objLifeData.GetHp() / objLifeData.GetMaxHp();
        txtNowHP.text = $"{objLifeData.GetHp() }/{objLifeData.GetMaxHp()}";
    }

    /// <summary>
    /// 更新士气显示
    /// </summary>
    /// <param name="objLifeData"></param>
    private void ResetMorale(ObjLifeData objLifeData)
    {
        float tempValue = (float)objLifeData.GetMaxMorale() / (float)imgMoraleAry.Length;
        float tempMorale = (float)objLifeData.GetMorale() / (float)objLifeData.GetMaxMorale();
        float tempValue2 = 0;

        for (int i = 0; i < imgMoraleAry.Length; i++)
        {
            tempValue2 = ((float)i * tempValue) / (float)objLifeData.GetMaxMorale();
            if (tempValue2 < tempMorale)
                imgMoraleAry[i].color = colorMoraleAry[0];
            else
                imgMoraleAry[i].color = colorMoraleAry[1];
        }

        txtNowMorale.text = $"{objLifeData.GetMorale() }/{objLifeData.GetMaxMorale()}";
    }

    private void ResetPreferPosition(ObjLifeData objLifeData)
    {
        List<SkillData> skillDatas = DataManager.Instance.GetSkillDatasWhereUse(objLifeData.GetSkillModes());
        for (int i = 0; i < heroPos.Length; i++)
        {
            heroPos[i] = 0;
        }
        for (int i = 0; i < enemyPos.Length; i++)
        {
            enemyPos[i] = 0;
        }

        foreach (var item in skillDatas)
        {
            SkillPosition position = item.position;
            if (position.A) { heroPos[0]++; }
            if (position.B) { heroPos[1]++; }
            if (position.C) { heroPos[2]++; }
            if (position.D) { heroPos[3]++; }
            if (position.W) { enemyPos[0]++; }
            if (position.X) { enemyPos[1]++; }
            if (position.Y) { enemyPos[2]++; }
            if (position.Z) { enemyPos[3]++; }
        }

        for (int i = 0; i < heroPosImage.Length; i++)
        {
            heroPosImage[i].fillAmount = heroPos[i] * 0.25f;
        }
        for (int i = 0; i < enemyPosImage.Length; i++)
        {
            enemyPosImage[i].fillAmount = enemyPos[i] * 0.25f;
        }
    }

    /// <summary>
    /// 更新饰品格
    /// </summary>
    /// <param name="objLifeData"></param>
    private void ResetOrnament(ObjLifeData objLifeData)
    {
        //旧加载
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


        //------ new
        if (objLifeData.GetOrnamentId(1) != 0)
            itemAry[1].setData(DataManager.Instance.GetOrnamentDataById(objLifeData.GetOrnamentId(1)));
        else itemAry[1].clear();
        if (objLifeData.GetOrnamentId(2) != 0)
            itemAry[2].setData(DataManager.Instance.GetOrnamentDataById(objLifeData.GetOrnamentId(2)));
        else itemAry[2].clear();
    }

    /// <summary>
    /// 更新勋章格
    /// </summary>
    /// <param name="objLifeData"></param>
    private void ResetMedal(ObjLifeData objLifeData)
    {
        //旧加载
        //if (objLifeData.GetMedal().objId != 0)
        //{
        //    MedalObjData objData = DataManager.Instance.GetMedalByMode(objLifeData.GetMedal());
        //    objData.GetIcon().LoadAssetAsync().Completed += go => imgMedal.sprite = go.Result;
        //    imgMedal.gameObject.SetActive(true);
        //}
        //else
        //{
        //    imgMedal.gameObject.SetActive(false);
        //}

        //------ new
        itemAry[0].clear();
        if (objLifeData.GetMedal().objId != 0)
            itemAry[0].setData(DataManager.Instance.GetMedalByMode(objLifeData.GetMedal()));
    }

    private void ShowSkillIcon(AssetReferenceSprite ars, Image image)
    {
        ars.LoadAssetAsync().Completed += go => image.sprite = go.Result;
    }

    private void AddHoverEvent(GameObject go, SkillData skillData)
    {
        UIEventManager.AddTriggersListener(go).onEnter = g => skillInfo.ShowInfo(go, skillData);
        UIEventManager.AddTriggersListener(go).onExit = g => skillInfo.ExitShow();
    }

    private void AddHoverEvent(GameObject go)
    {
        UIEventManager.AddTriggersListener(go).onEnter = g =>
        { talentBackImage.SetActive(true); talentBackImage.transform.SetParent(imgTalent.transform.root); };
        UIEventManager.AddTriggersListener(go).onExit = g =>
        { talentBackImage.transform.SetParent(imgTalent.transform); talentBackImage.SetActive(false); };
    }

    private void AddClickEvent(GameObject go, SkillMode skillMode)
    {
        UIEventManager.AddTriggersListener(go).onRightClick = g => SkillRightClick(go, skillMode);
        UIEventManager.AddTriggersListener(go).onLeftClick = g => SkillLeftClick(go, skillMode);
    }

    public void Close()
    {
        //if (objLifeData.GetSkillModes().Count(s => s.isUse) < 4)
        //{
        //    int count = 4 - objLifeData.GetSkillModes().Count(s => s.isUse);
        //    for (int i = 0; i < 7 && count > 0; ++i)
        //    {
        //        if (!objLifeData.GetSkillModes()[i].isUse)
        //        {
        //            objLifeData.GetSkillModes()[i].isUse = true;
        //            --count;
        //        }
        //    }
        //}
      
        if (BattleFlowController.Instance != null)
        {
            BattleFlowController.Instance.IsInteracting = false;
            BattleFlowController.Instance.BeCloseRoleInfoPanerl();
        }
        for (int i = 0; i < itemAry.Length; i++) itemAry[i].clear();

        CloseRenameTip();
        CloseExpelTip();
        BuildPanelMag.Instance?.setTouchBox(true);
        panelRoot.SetActive(false);

        KeyEventController.Instance.onEscAction -= Close;
        if (fadeBg != null)
            fadeBg.SetActive(false);

        
        skillInfo.ExitShow();
        talentBackImage.transform.SetParent(imgTalent.transform); 
        talentBackImage.SetActive(false);

        Camp.bShowRoleInfo = false;
    }

    public void Rename()
    {
        string name = inpName.text;
        objLifeData.SetHeroName(name);
        txtHeroName.text = name;       
        CloseRenameTip();
    }

    public void Expel()
    {
        AudioManager.Instance.PlayAudio(AudioName.Delete_Hero_mono, AudioType.Common);
        Camp.Instance.Expel(objLifeData);
        CloseExpelTip();
        Close();
    }

    public void ShowRenameTip()
    {
        goRenameTip.SetActive(true);
        inpName.text = "";
        AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
    }

    public void CloseRenameTip()
    {
        goRenameTip.SetActive(false);
    }

    public void ShowExpelTip()
    {
        goExpelTip.SetActive(true);
        AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
    }

    public void CloseExpelTip()
    {
        goExpelTip.SetActive(false);
    }

    private void SkillRightClick(GameObject go, SkillMode skillMode)
    {
        Debug.Log("测试-SkillRightClick");
        
        if (skillMode.isUse)
        {
            // 战斗中不能换技能
            if (BattleFlowController.Instance != null)
                if (BattleFlowController.Instance.IsBattling) return;

            if (objLifeData.GetVocation() == HeroVocation.双面间谍)
            {
                return;
            }

            skillMode.isUse = false;
            go.transform.Find(SELECTED_IMG).GetComponent<Image>().color = selectedColor2;

            ResetPreferPosition(objLifeData);
        }
    }

    private void SkillLeftClick(GameObject go, SkillMode skillMode)
    {
        Debug.Log("测试-SkillLeftClick");
        
        if (!skillMode.isUse && objLifeData.GetSkillModes().Count(s => s.isUse) < 4)
        {
            // 战斗中不能换技能
            if (BattleFlowController.Instance != null)
                if (BattleFlowController.Instance.IsBattling) return;

            skillMode.isUse = true;
            go.transform.Find(SELECTED_IMG).GetComponent<Image>().color = selectedColor;

            ResetPreferPosition(objLifeData);
        }
    }

    /// <summary>
    /// 穿上饰品
    /// </summary>
    /// <param name="objData"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public bool AddOrnament(ObjData objData, int index, bool isFormItem = false)
    {
        if (isFromRecruiting) return false;

        if (allowUpdate)
        {
            HeroVocation vocation = DataManager.Instance.GetOrnamentDataById(objData.id).heroVocation;
            if (vocation != HeroVocation.所有 && vocation != objLifeData.GetVocation())
            {
                return false;
            }

            if (!isFormItem)
            {
                if (index == 0) return false;
                if (itemAry[index].isBePut) return false;
                itemAry[index].setData(objData);
            }

            objLifeData.AddOrnament(index, objData);
            ResetText(objLifeData);
            //ResetOrnament(objLifeData);
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// 脱下饰品
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public void RemoveOrnament(int index = -1)
    {
        if (allowUpdate)
        {
            if (index == -1)
            {
                objLifeData.RemoveOrnament(1);
                objLifeData.RemoveOrnament(2);

                clearOrnament(1);
                clearOrnament(2);
            }
            else if (index == 1)
            {
                objLifeData.RemoveOrnament(1);
                clearOrnament(1);
            }
            else if (index == 2)
            {
                objLifeData.RemoveOrnament(2);
                clearOrnament(2);
            }
            ResetText(objLifeData);
        }
    }

    /// <summary>
    /// 穿上勋章
    /// </summary>
    /// <param name="objData"></param>
    /// <returns></returns>
    public bool AddMedal(MedalObjData objData, bool isFormItem = false)
    {
        if (isFromRecruiting) return false;

        if (allowUpdate)
        {
            if (!isFormItem)
            {
                if (itemAry[0].isBePut) return false;
                itemAry[0].setData(objData);
            }

            objLifeData.AddMedal(objData);
            ResetText(objLifeData);
            Camp.Instance.refreshAllHeroData();
            //ResetMedal(objLifeData);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void RemoveMedal()
    {
        if (allowUpdate)
        {
            objLifeData.RemoveMedal();
            clearMedal();
            ResetText(objLifeData);
            Camp.Instance.refreshAllHeroData();
        }
    }

    /// <summary>
    /// 更新英雄详情图片
    /// </summary>
    /// <param name="inID"></param>
    void refreshRoleModeImage(int inID)
    {
        for (int i = 0; i < roleImageRerence.roleImageAry.Length; i++)
            if (roleImageRerence.roleImageAry[i].ID == inID)
            {
                roleImageRerence.roleImageAry[i].roleBottomImage.LoadAssetAsync().Completed += go => imgModel.sprite = go.Result;
                roleImageRerence.roleImageAry[i].roleTopImage.LoadAssetAsync().Completed += go => topImgModel.sprite = go.Result;
                return;
            }
    }
}
