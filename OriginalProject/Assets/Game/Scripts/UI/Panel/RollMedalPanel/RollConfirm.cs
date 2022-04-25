using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollConfirm : interactionBase
{
	public UnityEngine.UI.Image image;
	public Sprite[] resourceAry;
	List<string> resourceNames = new List<string>() { "影晶", "虫果", "耀石", "星火", "亡骨 ", "鳞片" };

	public override void init()
	{

	}

	public void setData(MedalObjData inMedal)
	{
		inMedal.GetIcon().LoadAssetAsync().Completed += inGo => { image.sprite = inGo.Result; };
		hoverInfoUI.ClearData();

		hoverInfoUI.AddItem(inMedal.GetName(), 0, Color.white);
		hoverInfoUI.AddItem(inMedal.GetLevelType().ToString(), 1, Color.white);
		int index = 2;
		for (int i = 0; i < inMedal.GetAttribute().Count; ++i)
		{
			ObjPermanentBuff buff = inMedal.GetAttribute()[i];
			hoverInfoUI.AddItem(buff.buffType + (buff.buffValue > 0 ? "+" : "") + buff.buffValue + (buff.valueType == ValueType.系数 ? "%" : ""), index + i, Color.white);
		}
	}
	public void setData(int inIndex)
	{
		hoverInfoUI.ClearData();
		image.sprite = resourceAry[inIndex];
		switch (inIndex)
		{
			case 0:
				hoverInfoUI.AddItem("用来升级城镇建筑形成于幽暗处的水晶，汲取恶念生长，拥有诡异的力量“可用来疗伤，但不过是早死和晚死的区别”", 0, Color.white);
				break;
			case 1:
				hoverInfoUI.AddItem("用来升级城镇建筑异星的特产，无法将其按植物或动物归类“当你抓住它的时候，它也会抓住你……”", 0, Color.white);
				break;
			case 2:
				hoverInfoUI.AddItem("用来升级城镇建筑地底世界的光源和能源哪里有死亡，哪里就有牠闪耀", 0, Color.white);
				break;
			case 3:
				hoverInfoUI.AddItem("用来升级城镇建筑星际时代的电子烟，如今被当作火种和能源使用“这是文明世界的结晶，抽一根，少一根了……”", 0, Color.white);
				break;
			case 4:
				hoverInfoUI.AddItem("用来升级城镇建筑异兽死亡后留下的未知残骸，充满着不祥的气息磨碎后可当作致幻剂和止痛剂使用", 0, Color.white);
				break;
			case 5:
				hoverInfoUI.AddItem("通用货币\n麟甲兽的鳞片，是这个星球唯一的通用货币", 0, Color.white);
				break;
		}
	}
	public void clear() { }

	protected override void PointerEnter(GameObject go)
	{
		base.PointerEnter(go);
	}

	protected override void PointerExit(GameObject go)
	{
		base.PointerExit(go);
	}
}
