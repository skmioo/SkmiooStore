using Datas;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReilcItem : HoverableItem
{
	public event Action<ReilcItem> OnLeftClick, OnRightClick;
	public event Action<ReilcItem, HoverInfoUI> OnHoverEnter, OnHoverExit;
	public Image itemIcon;
	public GameObject priceObj;
	public Text countText;
	public Text priceText;
	public Text hintText;
	protected ObjData objData;
	[HideInInspector]
	public int itemCount, price;
	public bool countMax;

	private bool _enabled;

	public enum itemTypeEnum { bagItem = 0, halidom1, halidom2, halidom3 }
	public itemTypeEnum itemType;

	// [HideInInspector]
	public SacredObjData reilcData = null;

	protected override void Awake()
	{
		base.Awake();
		UIEventManager.AddTriggersListener(gameObject).onLeftClick = LeftClick;
		UIEventManager.AddTriggersListener(gameObject).onRightClick = RightClick;

		UIEventManager.OnDragFunc(this.gameObject, (inGo, inEvent) => { return inGo.GetComponent<ReilcItem>()?.itemIcon.GetComponent<RectTransform>(); });
		UIEventManager.AddTriggersListener(gameObject).onEndDrag = (inGo, inEvent) =>
		{
			inGo.GetComponent<ReilcItem>().itemIcon.GetComponent<RectTransform>().localPosition = Vector3.zero;
			if (inEvent.pointerEnter != null)
			{
				var tempHover = inEvent.pointerEnter.GetComponent<HoverableItem>();
				if (tempHover != null) tempHover.EndDragFunc(inGo);
				else if (inEvent.pointerEnter.name == "Viewport")
				{
					setDataBePut(itemTypeEnum.bagItem);
					RelicPanel.instance.removeHalidomItem(this);
					RelicPanel.instance.updateHint();
					RelicPanel.instance.relicGroupInit();
				}
			}
		};
	}


	public void setReilcData(SacredObjData inDate)
	{
		gameObject.SetActive(true);
		hintText.gameObject.SetActive(false);
		reilcData = inDate;
		setDataBePut(itemType);
		var tempIco = inDate.GetIcon();
		//if (tempIco.editorAsset == null) tempIco = BuildPanelMag.Instance.tempRilcIco;
		tempIco.LoadAssetAsync().Completed += inGO =>
		{
			itemIcon.gameObject.SetActive(true);
			itemIcon.sprite = inGO.Result;
		};
	}

	protected void LeftClick(GameObject go)
	{
		if (OnLeftClick != null)
		{
			OnLeftClick(this);
		}
	}

	protected void RightClick(GameObject go)
	{
		if (reilcData == null) return;
		if (itemType == itemTypeEnum.bagItem)
		{
			//OnRightClick(this);
			var tempItem = RelicPanel.instance.getNullhalidom();
			if (tempItem == null) return;
			tempItem.switchData(this);
		}
		else
		{
			setDataBePut(itemTypeEnum.bagItem);
			RelicPanel.instance.removeHalidomItem(this);
			RelicPanel.instance.updateHint();
		}
		pointExit(this);
	}

	protected override void PointerEnter(GameObject go)
	{
		base.PointerEnter(go);
		if (reilcData == null) return;
		hoverInfoUI.AddItem(reilcData.GetDescribe(), 0, Color.white);
		hoverInfoUI.gameObject.SetActive(true);
		hoverInfoUI.transform.SetParent(transform.root);
		hoverInfoUI.transform.SetAsLastSibling();
		RelicPanel.instance.reilcAry.Add(this);
		if (OnHoverEnter != null) OnHoverEnter(this, hoverInfoUI);
	}

	protected override void PointerExit(GameObject go)
	{
		base.PointerExit(go);
		hoverInfoUI.transform.SetParent(go.transform);
		hoverInfoUI.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
		hoverInfoUI.gameObject.SetActive(false);
		if (RelicPanel.instance.reilcAry.Equals(this))
			RelicPanel.instance.reilcAry.Remove(this);
		if (OnHoverExit != null)
			OnHoverExit(this, hoverInfoUI);
	}

	public override void EndDragFunc(GameObject inGO)
	{
		base.EndDragFunc(inGO);

		var tempItem = inGO.GetComponent<ReilcItem>();
		if (tempItem != null)
		{
			if (itemType != itemTypeEnum.bagItem)
			{
				if (tempItem.itemType == itemTypeEnum.bagItem)
				{
					switchData(tempItem);
					return;
				}
			}
			else
			{
				if (tempItem.itemType != itemTypeEnum.bagItem)
				{
					tempItem.setDataBePut(itemTypeEnum.bagItem);
					RelicPanel.instance.removeHalidomItem(tempItem);
					tempItem.switchData(this);
					return;
				}
			}
		}
	}

	public void pointExit(ReilcItem inReilc) { PointerExit(inReilc.gameObject); }

	public void close()
	{
		Clear();
		gameObject.SetActive(false);
	}

	public void Clear()
	{
		hintText.gameObject.SetActive(true);
		itemIcon.gameObject.SetActive(false);
		reilcData = null;
	}

	/// <summary>
	/// 替换自己数据，同时回收写入对象
	/// </summary>
	/// <param name="inItem"></param>
	public void switchData(ReilcItem inItem)
	{
		if (reilcData != null)
		{
			setDataBePut(itemTypeEnum.bagItem);
			Clear();
		}
		setReilcData(inItem.reilcData);
		RelicPanel.instance.recycleItem(inItem);
		RelicPanel.instance.updateHint();
		RelicPanel.instance.relicGroupInit();
	}

	public void setDataBePut(itemTypeEnum inType)
	{
		if (inType == itemTypeEnum.bagItem) reilcData.SetIsBePut(false);
		else reilcData.SetIsBePut(true);
		reilcData.SetNum((int)itemType);
	}
}
