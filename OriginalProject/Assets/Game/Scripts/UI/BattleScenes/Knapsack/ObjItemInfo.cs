using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Datas;


/// <summary>
/// 物品信息
/// </summary>
public class ObjItemInfo : MonoBehaviour
{
    public Text objName;
    public Text describe;
    public Text _describe;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void Show(ObjData objData,Vector2 pos)
    {
        InteractiveScripture temp = null;
        if (objData is InteractiveScripture) temp = objData as InteractiveScripture;
        objName.text = objData.name;
        describe.text = temp != null ? temp.knapsackDescribe : objData.describe ;
        _describe.text = temp != null ? temp.knapsackDescribe : objData.describe;

        gameObject.SetActive(true);
        transform.position = pos;
    }

    public void Off()
    {
        gameObject.SetActive(false);
    }
}
