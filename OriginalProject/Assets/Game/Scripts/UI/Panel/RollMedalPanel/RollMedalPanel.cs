using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GEvent;
using Datas;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.AddressableAssets;

public class RollMedalPanel : BuildPanelBase
{
	public static RollMedalPanel instance;

	public GameObject panelRoot;
	public RollItem rollItem;
	public WarehousePanel warehousePanel;
	public GameObject confirmPanel;
	public Text confirmText;
	public RawImage newBGRI;
	public Texture2D[] newBGImages;
	Vector2 originPos;
	public RollConfirm confirmHover;

	bool isFading;
	[Range(0, 1)]
	public float rollValue;

	//------------- 
	public enum awardEnum
	{
		nothing = -1,
		creatorMedal = 0,
		creatorLvUpMedal,
		clearMedal,
		switchToMoney,
		switchToResource
	}
	[System.Serializable]
	public struct awardStruct
	{
		public awardEnum awardType;
		public Vector2 angleValue;
	}
	[System.Serializable]
	public struct icoStruct
	{
		public awardEnum type;
		public Texture2D ico;
	}
	public GameObject pointObj;
	/// <summary>
	/// 原版概率
	/// </summary>
	public awardStruct[] awardAry;
	/// <summary>
	/// 事件后概率
	/// </summary>
	public awardStruct[] awardAry2;
	[Space, Header("----- roll ico ------")]
	public float icoDisMul;
	public icoStruct[] icoAry;
	public RawImage[] icoRI;
	[Space, Header("--------------------")]
	public int angleMul = 1440;
	public float animTime = 8;
	bool isRotate = false;

	List<string> resourceNames = new List<string>() { "影晶", "虫果", "耀石", "星火", "亡骨 " };

	public RawImage maskBG;
	public RawImage rollMaskBG;

	//----------
	public Text topTips;
	public Text button;

	private void Awake() { instance = this; originPos = panelRoot.GetComponent<RectTransform>().anchoredPosition; }
	private void Start()
	{
		BuildPanelMag.Instance.addBuild(this);
	}

	#region dataSet
#if UNITY_EDITOR

	public int tempInAngle;
	public bool isEqualize = false;
	public bool isEqualizePos = false;
	private void OnValidate()
	{
		if (isEqualize)
		{
			int tempAngle = 360 / awardAry.Length;
			for (int i = 0; i < awardAry.Length; i++)
			{
				awardAry[i].angleValue.x = i * tempAngle;
				awardAry[i].angleValue.y = i * tempAngle + tempAngle;
			}

			tempAngle = 360 / awardAry2.Length;
			for (int i = 0; i < awardAry2.Length; i++)
			{
				awardAry2[i].angleValue.x = i * tempAngle;
				awardAry2[i].angleValue.y = i * tempAngle + tempAngle;
			}


			isEqualize = false;
		}
		pointObj.transform.localRotation = Quaternion.Euler(0, 0, -tempInAngle);

		if (isEqualizePos)
		{
			for (int i = 0; i < icoRI.Length; i++)
				icoRI[i].rectTransform.localPosition =
					Quaternion.AngleAxis(180 - (awardAry[0].angleValue.y * i + awardAry[0].angleValue.y / 2), Vector3.forward) *
					new Vector3(0, icoDisMul, 0) +
					pointObj.transform.localPosition;

			isEqualizePos = false;
		}
	}
#endif
	#endregion

	public override void init()
	{
		base.init();

		topTips.text = LanguageController.GetValue("新维加斯");
		button.text = LanguageController.GetValue("转动");
		if (TownInfo.ExistsRescueType(RescueType.老千)) { switchNewBG(1); }
		else switchNewBG();
	}

	public override void mainLoop()
	{
		base.mainLoop();
	}


	public override void open()
	{

		if (!isFading)
		{
			NewbieGuideMag.Instance.triggerGuide(GuideDataSet.guideEnum.rollMedal);
			base.open();
			panelRoot.GetComponent<RectTransform>().anchoredPosition = originPos;
			isFading = true;
			panelRoot.SetActive(true);
			panelRoot.transform.localScale = Vector3.zero;
			panelRoot.transform.DOScale(Vector3.one, 0.3f).onComplete = () =>
			{
				isFading = false;
				WarehousePanel_2_M.instance.open();
				init();
			};
		}
	}


	public override void close()
	{

		if (!isFading)
		{
			base.close();
			clearIco();
			isFading = true;
			panelRoot.transform.DOScale(Vector3.zero, 0.15f).onComplete = () =>
			{
				isFading = false;
				WarehousePanel_2_M.instance.close();
				panelRoot.SetActive(false);
			};
		}
	}

	public override void RefreshData()
	{
		base.RefreshData();
	}

	public void addMedal(MedalObjData inData)
	{
		if (rollItem.medalData != null) return;
		DataManager.Instance.RemoveMedalFromMode(inData);
		rollItem.setRollData(inData);
	}

	public void updateWarehouse()
	{
		//old
		//if (warehousePanel == null) return;
		//warehousePanel.MedalBtnClick();

		//new 
		WarehousePanel_2_M.instance.refreshList();
	}

	/// <summary>
	/// 随机
	/// </summary>
	public void RollMedal()
	{
		if (isRotate) return;
		if (rollItem.medalData == null) return;
		isRotate = true;
		AudioManager.Instance.PlayAudio(AudioName.UI_Beep_Double_Alternative_stereo, AudioType.Common);
		var tempValue = Random.Range(0f, 1.0f);

		//tempValue = rollValue;
		updatePointer(tempValue);

		//囚犯事件
		//if (TownInfo.ExistsRescueType(RescueType.老千))
		//{
		//    if (tempValue < 0.1) { creatorMedal(); }
		//    else if (0.1f <= tempValue && tempValue < 0.5f) { creatorLvUpMedal(); }
		//    else if (0.5f <= tempValue && tempValue < 0.6f) { clearMedal(); }
		//    else if (0.6f <= tempValue && tempValue < 0.7f) { switchToMoney(); }
		//    else if (0.7f <= tempValue && tempValue <= 1f) { switchToResource(); }
		//}
		//else
		//{
		//    if (tempValue < 0.25) { creatorMedal(); }
		//    else if (0.25f <= tempValue && tempValue < 0.35f) { creatorLvUpMedal(); }
		//    else if (0.35f <= tempValue && tempValue < 0.45f) { clearMedal(); }
		//    else if (0.45f <= tempValue && tempValue < 0.55f) { switchToMoney(); }
		//    else if (0.55f <= tempValue && tempValue <= 1f) { switchToResource(); }
		//}
	}

	/// <summary>
	/// 创建奖励
	/// </summary>
	/// <param name="inAwardType"></param>
	void creatorAward(awardEnum inAwardType)
	{
		Debug.Log(inAwardType.ToString());
		switch (inAwardType)
		{
			case awardEnum.creatorMedal:
				creatorMedal();
				break;
			case awardEnum.creatorLvUpMedal:
				creatorLvUpMedal();
				break;
			case awardEnum.clearMedal:
				clearMedal();
				break;
			case awardEnum.switchToMoney:
				switchToMoney();
				break;
			case awardEnum.switchToResource:
				switchToResource();
				break;
		}
	}

	/// <summary>
	/// 根据角度拿奖励
	/// </summary>
	/// <param name="inAngle"></param>
	/// <returns></returns>
	awardEnum getAwardType2Angle(int inAngle)
	{
		if (TownInfo.ExistsRescueType(RescueType.老千))
		{
			for (int i = 0; i < awardAry2.Length; i++)
				if (awardAry2[i].angleValue.x <= inAngle && awardAry2[i].angleValue.y > inAngle)
					return awardAry2[i].awardType;
			return awardEnum.nothing;
		}
		else
		{
			for (int i = 0; i < awardAry.Length; i++)
				if (awardAry[i].angleValue.x <= inAngle && awardAry[i].angleValue.y > inAngle)
					return awardAry[i].awardType;
			return awardEnum.nothing;
		}
	}

	void showConfirm(string inString)
	{
		confirmText.text = inString;
		confirmPanel.gameObject.SetActive(true);
		rollMaskBG.gameObject.SetActive(true);
	}

	void showConfirm(string inString, MedalObjData inMedal)
	{
		showConfirm(inString);
		confirmHover.setData(inMedal);
	}
	void showConfirm(string inString, int inIndex)
	{
		showConfirm(inString);
		confirmHover.setData(inIndex);
	}

	/// <summary>
	/// 根据勋章品级播放音效
	/// </summary>
	/// <param name="_type"></param>
	void playAudioByMedalLevelType(LevelType _type)
	{
		switch (_type)
		{
			case LevelType.起源:
			case LevelType.稀有:
				AudioManager.Instance.PlayAudio(AudioName.Casinos_Rare_mono, AudioType.Common); break;
			default: AudioManager.Instance.PlayAudio(AudioName.Casinos_Ordinary_mono, AudioType.Common); break;

		}
	}
	//25
	void creatorMedal()
	{
		var tempLv = rollItem.medalData.GetLevel();
		rollItem.Clear();
		var tempData = DataManager.Instance.CreateMedal(tempLv);
		DataManager.Instance.AddMedalToMode(tempData);
		//showConfirm("获得了" + OneBitNumberToChinese(tempLv.ToString()) + "星勋章");
		showConfirm(LanguageController.GetValue("获得") + tempLv.ToString() + "\"" + LanguageController.GetValue("LV勋章") + "\"", tempData);

		playAudioByMedalLevelType(tempData.GetLevelType());
		updateWarehouse();
	}

	//10
	void creatorLvUpMedal()
	{
		var tempLv = rollItem.medalData.GetLevel();
		rollItem.Clear();
		if (tempLv + 1 > 6) tempLv = 6; else tempLv += 1;
		var tempData = DataManager.Instance.CreateMedal(tempLv);
		DataManager.Instance.AddMedalToMode(tempData);
		//showConfirm("获得了" + OneBitNumberToChinese(tempLv.ToString()) + "星勋章");
		showConfirm(LanguageController.GetValue("获得") + tempLv.ToString() + "\"" + LanguageController.GetValue("LV勋章") + "\"", tempData);
		playAudioByMedalLevelType(tempData.GetLevelType());
		updateWarehouse();
	}

	//10
	void clearMedal()
	{
		AudioManager.Instance.PlayAudio(AudioName.UI_Error_Orchestral_Brass_stereo, AudioType.Common);
		rollItem.Clear();
		showConfirm(LanguageController.GetValue("没获得任何奖励"));
	}

	//45
	void switchToMoney()
	{
		AudioManager.Instance.PlayAudio(AudioName.Casinos_Ordinary_mono, AudioType.Common);
		rollItem.Clear();
		var tempValue = Random.Range(150, 750);
		ResPanel.Instance.ChangeResource(tempValue);
		//showConfirm("获得了" + OneBitNumberToChinese(tempValue.ToString()) + "鳞片");
		showConfirm(LanguageController.GetValue("获得") + tempValue.ToString() + "\"" + LanguageController.GetValue("鳞片") + "\"", 5);
	}

	//10
	void switchToResource()
	{
		AudioManager.Instance.PlayAudio(AudioName.Casinos_Ordinary_mono, AudioType.Common);
		rollItem.Clear();
		var tempValue = Random.Range(1, 5);
		if (tempValue == 1) ResPanel.Instance.ChangeResource(0, 1);
		else if (tempValue == 2) ResPanel.Instance.ChangeResource(0, 0, 1);
		else if (tempValue == 3) ResPanel.Instance.ChangeResource(0, 0, 0, 1);
		else if (tempValue == 4) ResPanel.Instance.ChangeResource(0, 0, 0, 0, 1);
		else if (tempValue == 5) ResPanel.Instance.ChangeResource(0, 0, 0, 0, 0, 1);
		//showConfirm("获得了" + OneBitNumberToChinese(1.ToString()) + "份" + resourceNames[tempValue - 1]);
		showConfirm(LanguageController.GetValue("获得") + 1.ToString() + LanguageController.GetValue("份\"") + resourceNames[tempValue - 1]+"\"", tempValue - 1);
		Debug.Log("Resource = " + tempValue);
	}

	/// <summary>
	/// 切换转盘底图
	/// </summary>
	void switchNewBG(int inImageIndex = 0)
	{
		if (inImageIndex >= newBGImages.Length) return;
		//newBGRI.texture = newBGImages[inImageIndex];
		switchIco(inImageIndex);
	}

	void switchIco(int inIndex)
	{
		clearIco();

		awardEnum tempType = awardEnum.clearMedal;
		for (int i = 0; i < icoRI.Length; i++)
		{
			if (inIndex == 0)
				tempType = awardAry[i].awardType;
			else if (inIndex == 1)
				tempType = awardAry2[i].awardType;

			if (tempType == awardEnum.clearMedal) continue;

			for (int i1 = 0; i1 < icoAry.Length; i1++)
				if (icoAry[i1].type == tempType)
					icoRI[i].texture = icoAry[i1].ico;

			icoRI[i].DOColor(Color.white, 0.8f);
		}
	}

	void clearIco()
	{
		for (int i = 0; i < icoRI.Length; i++)
		{
			icoRI[i].texture = null;
			icoRI[i].color = Color.clear;
		}
	}

	/// <summary>
	/// 旋转指针
	/// </summary>
	/// <param name="inValue"></param>
	void updatePointer(float inValue)
	{
		maskBG.gameObject.SetActive(true);
		rollMaskBG.gameObject.SetActive(true);
		int tempAngle = (int)(inValue * 360);
		pointObj.transform.DOLocalRotate(new Vector3(0, 0, -(tempAngle + angleMul)), animTime, RotateMode.FastBeyond360)
			.SetEase(Ease.OutCubic).onComplete += () =>
			 {
				 creatorAward(getAwardType2Angle(tempAngle));
				 isRotate = false;
				 maskBG.gameObject.SetActive(false);
				 rollMaskBG.gameObject.SetActive(false);
			 };
	}

	string OneBitNumberToChinese(string num)
	{
		string numStr = "123456789";
		string chineseStr = "一二三四五六七八九";
		string result = "";
		int numIndex = numStr.IndexOf(num);
		if (numIndex > -1)
		{
			result = chineseStr.Substring(numIndex, 1);
		}
		return result;
	}
}
