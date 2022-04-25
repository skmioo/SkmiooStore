using Datas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement;
using UnityEngine.ResourceManagement.AsyncOperations;

/// <summary>
/// 数据管理器取值演示
/// </summary>
public class TestLoadData : MonoBehaviour
{
    public Dictionary<int, RoleData> heroDic = new Dictionary<int, RoleData>();
    public Dictionary<int, RoleData> enemyDic = new Dictionary<int, RoleData>();


    
    private void Start()
    {
        //只要是没有经过场景加载的数据调用,均需要延迟启动
        Invoke("GetRoleData",3);
        //GetRoleData();
    }

    //数据解构
    void GetRoleData()
    {
        DataSetItem _roleData = DataManager.Instance.GetData("RoleData");
        RoleDataSet roleData = _roleData.scriptableObject as RoleDataSet;

        foreach (var item in roleData.heroData)
        {
            Debug.Log($"{item.id}:{item.name}");
            heroDic.Add(item.id, item);
            item.roleMode.InstantiateAsync();
        }
        foreach (var item in roleData.enemyData)
        {
            Debug.Log($"{item.id}:{item.name}");
            enemyDic.Add(item.id, item);
            item.roleMode.LoadAssetAsync().Completed += go =>
            {
                switch (go.Status)
                {
                    case AsyncOperationStatus.None:
                        break;
                    case AsyncOperationStatus.Succeeded:
                        Instantiate(go.Result, transform);
                        break;
                    case AsyncOperationStatus.Failed:
                        break;
                    default:
                        break;
                }
            };
        }

        //DataSetItem _UIPanelData = 

        //打开UI面板
        UIManager.Instance.PushPanel(UIPanelType.MainMenuPanel);        
        //关闭UI面板
        UIManager.Instance.PopPanel();
        


    }

   


}
