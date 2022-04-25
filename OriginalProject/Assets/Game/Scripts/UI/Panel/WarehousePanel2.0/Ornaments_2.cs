using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ornaments_2 : interactionBase
{
    public UnityEngine.UI.Image image;
    Datas.ObjData ornamentsData;

    int modesIndex;
    bool isShowHoverInfo = false;

    public System.Action<Ornaments_2> leftClickEvent;


    public override void init()
    {
        ornamentsData = null;
    }

    /// <summary>
    /// 设置格子数据
    /// </summary>
    /// <param name="inData"></param>
    /// <param name="inIndex"></param>
    public void setData(Datas.ObjData inData, int inIndex)
    {
        image.raycastTarget = false;
        ornamentsData = inData;
        modesIndex = inIndex;

        ornamentsData.Icon.LoadAssetAsync<Sprite>().Completed += img =>
        { image.enabled = true; image.sprite = img.Result; isShowHoverInfo = true; };

        refreshHoverData();
    }

    public void clear()
    {
        modesIndex = -1;
        image.sprite = null;
        image.enabled = false;
        ornamentsData = null;
        leftClickEvent = null;
        isShowHoverInfo = false;
    }

    public override RectTransform dragEvent(GameObject inObj, PointerEventData pointerEventData)
    {
        if (ornamentsData == null) return null;
        return image.rectTransform;
    }

    public override void endDragEvent(GameObject go, PointerEventData pointerEventData)
    {
        if (ornamentsData == null) return;
        //base.endDragEvent(go, pointerEventData);
        image.GetComponent<RectTransform>().localPosition = Vector3.zero;
        image.transform.SetAsFirstSibling();

        var tempHover = pointerEventData.pointerEnter.GetComponent<HoverableItem>();
        if (tempHover != null) tempHover.EndDragFunc(go);
    }

    public override void EndDragFunc(GameObject go)
    {
        role2WP(go);
    }

    public override void leftClick(GameObject inGo)
    {
        if (ornamentsData == null) return;
        leftClickEvent?.Invoke(this);
    }

    public override void ReputInfoUI()
    {
        base.ReputInfoUI();
    }

    protected override void PointerEnter(GameObject go)
    {
        if (ornamentsData == null) return;
        base.PointerEnter(go);

        hoverInfoUI.transform.parent = transform.root;
    }

    protected override void PointerExit(GameObject go)
    {
        if (ornamentsData == null) return;
        base.PointerExit(go);
    }

    public Datas.ObjData getData() { return ornamentsData; }

    public int getIndex() { return modesIndex; }

    /// <summary>
    /// 更新悬停面板
    /// </summary>
    void refreshHoverData()
    {
        if (ornamentsData == null) return;
        hoverInfoUI.ClearData();

        hoverInfoUI.AddItem(ornamentsData.describe, 0, Color.white);
    }

    /// <summary>
    /// 角色面板到背包
    /// </summary>
    /// <param name="inGo"></param>
    void role2WP(GameObject inGo)
    {
        var tempItem = inGo.GetComponent<RoleInfoItem>();
        if (tempItem != null)
            if (tempItem.OrnamentData != null)
            {
                if (ornamentsData == null)
                {
                    WarehousePanel_2_O.instance.addData(tempItem.OrnamentData);
                    RoleInfoPanel.instance.RemoveOrnament((int)tempItem.itemType - 1);
                }
                else
                {
                    var tempData = tempItem.OrnamentData;
                    tempItem.setData(ornamentsData);
                    DataManager.Instance.RemoveOrnamentFromMode2(ornamentsData.id);
                    clear();
                    WarehousePanel_2_O.instance.addData(tempData);
                }
            }
    }
}
