using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Medal_2 : interactionBase
{
    public UnityEngine.UI.Image image;
    public Sprite noneSprite;
    MedalObjData medalData;

    int modesIndex;
    bool isShowHoverInfo = false;

    public System.Action<MedalObjData> leftClickEvent;
	ScrollRect scrollRect;

    public override void init()
    {
        medalData = null;
    }

	private void Start()
	{
		scrollRect = GetComponentInParent<ScrollRect>();
	}

	/// <summary>
	/// 设置格子数据
	/// </summary>
	/// <param name="inData"></param>
	/// <param name="inIndex"></param>
	public void setData(MedalObjData inData, int inIndex)
    {
        image.raycastTarget = false;
        medalData = inData;
        modesIndex = inIndex;

        medalData.GetIcon().LoadAssetAsync<Sprite>().Completed += img =>
        { image.sprite = img.Result; isShowHoverInfo = true; };

        refreshHoverData();
    }

    public void clear()
    {
        modesIndex = -1;
        image.sprite = noneSprite;
        medalData = null;
        isShowHoverInfo = false;
    }

	public override void beginDragEvent(GameObject go, PointerEventData pointerEventData)
	{
		if (medalData == null)
		{
			scrollRect.OnBeginDrag(pointerEventData);
			return;
		}
	}

	public override RectTransform dragEvent(GameObject inObj, PointerEventData pointerEventData)
	{
		if (medalData == null)
		{
			scrollRect.OnDrag(pointerEventData);
			return null;
		}
        return image.rectTransform;
    }

    public override void endDragEvent(GameObject go, PointerEventData pointerEventData)
    {
		if (medalData == null)
		{
			scrollRect.OnEndDrag(pointerEventData);
			return;
		}

        //base.endDragEvent(go, pointerEventData);
        image.GetComponent<RectTransform>().localPosition = Vector3.zero;
        image.transform.SetAsFirstSibling();

        var tempHover = pointerEventData.pointerEnter.GetComponent<HoverableItem>();
        if (tempHover != null) tempHover.EndDragFunc(go);
    }

    public override void EndDragFunc(GameObject go)
    {
        role2WP(go);
        roll2WP(go);
    }

    public override void leftClick(GameObject inGo)
    {
        if (medalData == null) return;
        leftClickEvent?.Invoke(medalData);
    }

    public override void ReputInfoUI()
    {
        base.ReputInfoUI();
    }

    protected override void PointerEnter(GameObject go)
    {
        if (medalData == null) return;
        base.PointerEnter(go);

        hoverInfoUI.transform.parent = transform.root;
    }

    protected override void PointerExit(GameObject go)
    {
        if (medalData == null) return;
        base.PointerExit(go);
    }

    public MedalObjData getData() { return medalData; }

    public int getIndex() { return modesIndex; }


    /// <summary>
    /// 更新悬停面板
    /// </summary>
    void refreshHoverData()
    {
        if (medalData == null) return;
        hoverInfoUI.ClearData();


        hoverInfoUI.AddItem(medalData.GetName(), 0, Color.white);
        hoverInfoUI.AddItem(medalData.GetLevelType().ToString(), 1, Color.white);
        int index = 2;
        for (int i = 0; i < medalData.GetAttribute().Count; ++i)
        {
            ObjPermanentBuff buff = medalData.GetAttribute()[i];
            hoverInfoUI.AddItem(buff.buffType + (buff.buffValue > 0 ? "+" : "") + buff.buffValue + (buff.valueType == ValueType.系数 ? "%" : ""), index + i, Color.white);
        }
        index += medalData.GetAttribute().Count;
        for (int i = 0; i < medalData.GetEntry().Count; ++i)
        {
            ObjPermanentBuff buff = medalData.GetEntry()[i];
            hoverInfoUI.AddItem(buff.buffType + (buff.buffValue > 0 ? "+" : "") + buff.buffValue + (buff.valueType == ValueType.系数 ? "%" : ""), index + i, Color.white);
        }
    }


    /// <summary>
    /// 角色面板到背包
    /// </summary>
    /// <param name="inGo"></param>
    void role2WP(GameObject inGo)
    {
        var tempItem = inGo.GetComponent<RoleInfoItem>();
        if (tempItem != null)
            if (tempItem.medalData != null)
            {
                if (medalData == null)
                {
                    WarehousePanel_2_M.instance.addData(tempItem.medalData);
                    RoleInfoPanel.instance.RemoveMedal();
                }
                else
                {
                    var tempData = tempItem.medalData;
                    tempItem.setData(medalData);
                    DataManager.Instance.RemoveMedalFromMode(modesIndex);
                    clear();
                    WarehousePanel_2_M.instance.addData(tempData);
                }
            }
    }

    /// <summary>
    /// 抽取到背包
    /// </summary>
    /// <param name="inGo"></param>
    void roll2WP(GameObject inGo)
    {
        var tempItem = inGo.GetComponent<RollItem>();
        if (tempItem != null)
            if (tempItem.medalData != null)
            {
                if (medalData == null)
                {
                    WarehousePanel_2_M.instance.addData(tempItem.medalData);
                    tempItem.Clear();
                }
                else
                {
                    var tempData = tempItem.medalData;
                    tempItem.setRollData(medalData);
                    DataManager.Instance.RemoveMedalFromMode(modesIndex);
                    clear();
                    WarehousePanel_2_M.instance.addData(tempData);
                }
            }

    }
}
