using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Datas;



public class RoleItem_2 : MonoBehaviour
{
    /// <summary>头像/// </summary>
    public Image icon;
    /// <summary>伤势条（弃用）/// </summary>
    public Image injuriesP;
    /// <summary>伤势数值（弃用）/// </summary>
    public Text injuriesV;
    /// <summary>五格士气条/// </summary>
    public Image[] moraleList;
    /// <summary>无士气图片/// </summary>
    public Sprite moraleFlase;
    /// <summary>有士气图片/// </summary>
    public Sprite moraleTrue;

    //public Text value;
    public void InitRoleItem_2(ObjLifeData objLifeData)
    {
        
        objLifeData.GetIcon().LoadAssetAsync().Completed += go =>
        {
            icon.sprite = go.Result;
        };
        /// <summary>调用的是Hps中的injuries做法/// </summary>
        ///         if (objLifedata.GetMorale() > 0)
        {
            int num = objLifeData.GetMorale() * 5 / objLifeData.GetMaxMorale();
            for (int i = 0; i < moraleList.Length; i++)
            {
                if (i < num)
                {
                    moraleList[i].sprite = moraleTrue;
                }
                else
                {
                    moraleList[i].sprite = moraleFlase;
                }
            }
        }
        //injuriesV.text = $"{objLifeData.GetInjuries()} / {objLifeData.GetMaxInjuries()}";
        //injuriesP.fillAmount = (float)objLifeData.GetInjuries() / (float)objLifeData.GetMaxInjuries();

        /// <summary>
        /// value.text = $"士气：{objLifeData.GetMorale()}";
        /// </summary>
    }



}
