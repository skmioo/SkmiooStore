using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using GEvent;
using System.Collections;

public class HeroEquipmentInfo : MonoBehaviour
{
    public Transform medalBox;
    public Transform ornaments1;
    public Transform ornaments2;

    public GameObject objItem;
    public Image objItemOnDrag;
    public ObjItemInfo objItemInfo;

    //拖拽结束时,朝背包里放物品
    public Medal medal;
    public Ornaments ornaments;

    ObjItem medalObj;
    ObjItem ornaments1Obj;
    ObjItem ornaments2Obj;

    ObjLife objLife;
    private bool onDraging;
   
    //用于当装备变化时更新数值 
    public RoleInfo RoleInfo;
    public RoleInfoView roleInfoView;


    /// <summary>
    /// 初始化显示,读存档数据,并改写lifedata
    /// </summary>
    /// <param name="_heroEquipment"></param>
    public void InitEquipment( ObjLife _objLife)
    {
        /*objLife = _objLife;
        print("ini equip");
        if (objLife.equipment.medal != null)
        {
            GameObject go = Instantiate(objItem, medalBox);
            ObjItem obj = go.GetComponent<ObjItem>();
            medalObj = obj;

            obj.InitItem(objLife.equipment.medal, 1, medalBox);

            AddTriggersListener(go);
        }
        else
        {
            DestroyChild(medalBox);
        }
        

        if (objLife.equipment.ornaments1 != null)
        {
            GameObject go = Instantiate(objItem, ornaments1);
            ObjItem obj = go.GetComponent<ObjItem>();
            ornaments1Obj = obj;

            obj.InitItem(objLife.equipment.ornaments1, 1, ornaments1);
            AddTriggersListener(go);
        }
        else
        {
            DestroyChild(ornaments1);
        }
        

        if (objLife.equipment.ornaments2 != null)
        {
            GameObject go = Instantiate(objItem, ornaments2);
            ObjItem obj = go.GetComponent<ObjItem>();
            ornaments2Obj = obj;


            obj.InitItem(objLife.equipment.ornaments2, 1, ornaments2);
            AddTriggersListener(go);
        }
        else
        {
            DestroyChild(ornaments2);
        }

        objLife.RestEquipment();*/
    }

    void AddTriggersListener(GameObject item)
    {
        UIEventManager.AddTriggersListener(item).onEnter += ItemOnEnter;
        UIEventManager.AddTriggersListener(item).onExit  += gItemOnExit;
        UIEventManager.AddTriggersListener(item).onDrag += ItemOndrag;
        UIEventManager.AddTriggersListener(item).onEndDrag += ItemOnEndDrag;


    }

    void RemoveTriggerListener(GameObject go)
    {
        UIEventManager.AddTriggersListener(go).onDrag -= ItemOndrag;
        UIEventManager.AddTriggersListener(go).onEndDrag -= ItemOnEndDrag;
        UIEventManager.AddTriggersListener(go).onEnter -= ItemOnEnter;
        UIEventManager.AddTriggersListener(go).onExit -= gItemOnExit;
    }

    private void gItemOnExit(GameObject go)
    {
        objItemInfo.Off();
    }

    private void ItemOnEnter(GameObject go)
    {
        if (onDraging)
            return;

        ObjItem obj = go.GetComponent<ObjItem>();
        objItemInfo.Show(obj.objData, go.transform.position);
    }


    private void ItemOnEndDrag(GameObject go, PointerEventData eventData)
    {
        /*onDraging = false;
        objItemOnDrag.gameObject.SetActive(false);
        if (eventData.pointerEnter == null)
            return;

        Transform goBox = go.transform.parent;
        ObjItem _obj = go.GetComponent<ObjItem>();
        GameObject target = eventData.pointerEnter.gameObject;
        if (_obj.objData.objType == ObjType.勋章)
        {
            if (target.tag != "W_MedalBox")
                return;

            
            RemoveTriggerListener(go);
            //medal.AddMoveItem(_obj,target.transform);
            Hashtable args = new Hashtable();
            args["ObjData"] = _obj.objData;
            args["medalInfo"] = (_obj as MedalObjItem).medalMode;
            EventHelper.Instance.ExcuteEvent(GEventType.AddItem, args);
            Destroy(_obj.gameObject);

            objLife.equipment.medal = null;
            medalObj = null;

            objLife.RestEquipment();
        }
        else if (_obj.objData.objType == ObjType.饰品)
        {
            if (target.tag != "W_OrnamentsBox")
                return;

            RemoveTriggerListener(go);

            if (goBox == ornaments1)
            {
                objLife.equipment.ornaments1 = null;
                ornaments1Obj = null;
            }
            else
            {
                objLife.equipment.ornaments2 = null;
                ornaments2Obj = null;
            }

            //ornaments.AddMoveItem(_obj,target.transform);
            Hashtable args = new Hashtable();
            args["ObjData"] = _obj.objData;
            EventHelper.Instance.ExcuteEvent(GEventType.AddItem, args);
            Destroy(_obj.gameObject);

            UpdateEquip();     
        }*/

    }

    private RectTransform ItemOndrag(GameObject go, PointerEventData eventData)
    {
        onDraging = true;
        ObjItem obj = go.GetComponent<ObjItem>();
        objItemOnDrag.sprite = obj.icon.sprite;
        RectTransform rectTransform = objItemOnDrag.GetComponent<RectTransform>();
        objItemOnDrag.gameObject.SetActive(true);

        return rectTransform;
    }

    /// <summary>
    /// 一个装备加入---
    /// </summary>
    public ObjItem AddMedalItem(GameObject go ,Transform target)
    {
        return null;
        /*AddTriggersListener(go);
        ObjItem _objitem;

        ObjItem goObjItem = go.GetComponent<ObjItem>();
        goObjItem.transform.SetParent(medalBox);
        goObjItem.transform.localPosition = Vector3.zero;

        objLife.equipment.medal = goObjItem.objData;

        UpdateEquip();


        if (objLife.equipment.medal == null)
        {
            _objitem = null;
        }
        else
        {
            _objitem = medalObj;                          
        }

        medalObj = goObjItem;

        return _objitem;*/
    }

    public ObjItem AddOrnamentsItem(GameObject go, Transform targetBox)
    {
        return null;
        /*RemoveTriggerListener(go);
        AddTriggersListener(go);

        ObjItem _objitem;

        ObjItem goObjItem = go.GetComponent<ObjItem>();


        if (targetBox == ornaments1)
        {
            goObjItem.transform.SetParent(ornaments1);
           
            objLife.equipment.ornaments1 = goObjItem.objData;
            if (objLife.equipment.ornaments1 == null)
            {
                _objitem = null;
            }
            else
            {
                _objitem = ornaments1Obj;
            }
            ornaments1Obj = goObjItem;

            objLife.GetHerosMode().ornaments1ID = ornaments1Obj.objData.id;
        }
        else
        {
            goObjItem.transform.SetParent(ornaments2);
            objLife.equipment.ornaments2 = goObjItem.objData;
            if (objLife.equipment.ornaments2 == null)
            {
                _objitem = null;
            }
            else
            {
                _objitem = ornaments2Obj;
            }
            ornaments2Obj = goObjItem;

            objLife.GetHerosMode().ornaments2ID = ornaments2Obj.objData.id;
        }

        goObjItem.transform.localPosition = Vector3.zero;

        UpdateEquip();

        return _objitem;*/
    }


    //更新角色装备信息及更新角色属性显示
    void UpdateEquip()
    {
        /*objLife.RestEquipment();
       
        //战斗中与准备界面
        if (roleInfoView == null)
        {
            RoleInfo.UpdateValue();
        }
        else
        {
            //roleInfoView.ResetInfo(roleInfoView.showWho.numInTeam);
        }*/
    }


    /// <summary>
    /// 删除子物体
    /// </summary>
    void DestroyChild(Transform box)
    {
        foreach (Transform item in box)
        {
            Destroy(item.gameObject);
        }
    }



}
