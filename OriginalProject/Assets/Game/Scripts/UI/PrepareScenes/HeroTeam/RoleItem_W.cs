using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoleItem_W : MonoBehaviour
{
    public RoleItem roleItem;
    public Image icon;
    public Transform iconBox;

    /// <summary>
    /// 初始化项目-- ,在出征队伍中增加一个角色
    /// </summary>
    /// <param name="_roleItem"></param>
    public void InitItem(RoleItem _roleItem,int num)
    {
        //roleItem.numInteam = num;        
        roleItem = _roleItem;

        iconBox = transform;
        roleItem.herosMode.numInTeam_Waiting = num;       
        if (_roleItem.Icon.sprite ==null)
        {
            _roleItem.heroData.icon.LoadAssetAsync().Completed += go =>
            {
                icon.sprite = go.Result;
            };
        }
        else
        {
            icon.sprite = _roleItem.Icon.sprite;
        }

        //roleItem.SetObjlife();
    }

    //objlif拟态,只使用其中的值,不参与任何计算或使用其方法！！！暂时这样处理,有时间重写
    //void SetObjlife()
    //{
    //    roleItem.objLife = GetComponent<ObjLife>();

    //    roleItem.objLife.InitRole(roleItem.herosMode, roleItem.heroData, null, null);
    //}

}
