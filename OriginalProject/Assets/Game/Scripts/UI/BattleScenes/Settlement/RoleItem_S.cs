using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Datas;



public class RoleItem_S : MonoBehaviour
{
    public Image icon;

    public Text value;
    public void InitRoleItem_S(ObjLifeData objLifeData)
    {
        objLifeData.GetIcon().LoadAssetAsync().Completed += go =>
        {
            icon.sprite = go.Result;
        };

        value.text = $"士气：{objLifeData.GetMorale()}";
    }



}
