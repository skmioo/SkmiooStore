using Datas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 英雄角色装备插槽 （勋章，饰品）
/// </summary>
public class RoleInfoEquipmentSlot : HoverableItem
{
    public Image itemIcon;
    Vector3 itemIcoPos;
    public ObjData curObjData { get; private set; }
    public enum SlotType {
        Ornament,Medal
    }
    public SlotType slotType;
    protected override void Awake()
    {
        base.Awake();
        curObjData = null;
        UIEventManager.AddTriggersListener(gameObject).onLeftClick = LeftClick;
        UIEventManager.AddTriggersListener(gameObject).onRightClick = RightClick;
        UIEventManager.OnDragFunc(this.gameObject, (inGo, inEvent) =>
        {
            itemIcoPos = itemIcon.GetComponent<RectTransform>().localPosition;
            return itemIcon.GetComponent<RectTransform>();
        });
        UIEventManager.AddTriggersListener(gameObject).onEndDrag = (inGo, inEvent) =>
        {
            itemIcon.GetComponent<RectTransform>().localPosition = itemIcoPos;
            if (inEvent.pointerEnter != null)
            {
                var tempHover = inEvent.pointerEnter.GetComponent<HoverableItem>();
                if (tempHover != null) tempHover.EndDragFunc(inGo);
            }
        };
    }
    public void AddtoSlot(ObjData _data)
    {
        curObjData = _data;
        curObjData.Count = 1;
        curObjData.Icon.LoadAssetAsync().Completed += (go) => {
            itemIcon.sprite = go.Result;
            itemIcon.gameObject.SetActive(true);

        };
    }
  
    public void RemoveForSlot() {
        curObjData = null;
        itemIcon.gameObject.SetActive(false);
    }
    protected override void PointerEnter(GameObject go)
    {
        base.PointerEnter(go);
        if (curObjData == null) return;
      
        if (slotType == SlotType.Ornament)
        {
            hoverInfoUI.AddItem(curObjData.describe, 0, Color.white);
            hoverInfoUI.transform.SetParent(transform.root.transform);
            hoverInfoUI.transform.SetAsLastSibling();
        }
        hoverInfoUI.Show();
    }

    protected override void PointerExit(GameObject go)
    {
        base.PointerExit(go);
        hoverInfoUI.transform.SetParent(transform);
        hoverInfoUI.Hide();
    }
    void LeftClick(GameObject go)
    {
      
    }
    void RightClick(GameObject go)
    {
      
        if (BattleFlowController.Instance == null) return;  Debug.Log("测试-RightClick");
        if (curObjData == null)   return;
        if (slotType == SlotType.Ornament)
        {
            BattleFlowController.Instance.kanpsack.AddOrnamentToKanspsack(curObjData);
            int index = RoleInfoView.Instance.EquipmentSlots.IndexOf(this);
            if (index == 1)
            {
                RoleInfoView.Instance.RemoveOrnament(1);
                RoleInfoPanel.instance.RemoveOrnament(1);
            }
            else if (index == 2)
            {
                RoleInfoView.Instance.RemoveOrnament(2);
                RoleInfoPanel.instance.RemoveOrnament(2);
            }
            clear();
            RoleInfoView.Instance.RefreshRoleInfo();
        }
    }
    public void clear()
    {
        hoverInfoUI.Hide();
        itemIcon.gameObject.SetActive(false);
    }
}
