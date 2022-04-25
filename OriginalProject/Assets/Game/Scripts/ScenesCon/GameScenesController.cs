using Datas;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Events;
using UnityEngine.ResourceManagement;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

public enum GameSceneName
{
    Z_Start_0, // 开始场景
    Z_PrepareScenes, // 城镇和出征场景
    Z_battle_T, // 战斗场景
}

/// <summary>
/// 场景跳转控制器，每个场景挂一个此脚本，方便调试 ----不删除方式待考虑
/// </summary>
public class GameScenesController : MonoBehaviour
{
    static GameScenesController _instance;
    public static GameScenesController Instance
    {
        get
        {
            return _instance;
        }
    }

    /// <summary>
    /// 准备跳转新的场景
    /// </summary>
    public  UnityEvent goScenes;
    /// <summary>
    /// 到达新的场景
    /// </summary>
    public  UnityEvent toScenes;

    AsyncOperationHandle<SceneInstance> nowScenes;
    AsyncOperationHandle<DataSet> dataSet;

    private void Awake()
    {
        _instance = this;
    }

    /// <summary>
    /// 场景跳转--重新加载基础数据包
    /// </summary>
    /// <param name="scenesName">场景的名称</param>
    /// <param name="dataName">加载新的场景提供需要加载的数据名称--以语言为基础的数据包</param>
    public void GoLoadScenes(int scenesNum, string dataName)
    {
        goScenes.Invoke();
        StartCoroutine(LoadBaseData(scenesNum, dataName));
    }


    /// <summary>
    /// 场景跳转
    /// </summary>
    /// <param name="scenesName">场景的名称</param>
    public void GoLoadScenes(int scenesNum)
    {
        goScenes.Invoke();

        StartCoroutine(GoScenes(scenesNum));
    }


    IEnumerator LoadBaseData(int scenesNum, string dataName)
    {
        
        yield return dataSet = Addressables.LoadAssetAsync<DataSet>(dataName);//要加载的数据名称
        if (dataSet.Result == null)
        {
            Debug.Log("提供的名称未取到数据");
        }
        else
        {
            DataManager.dataSet = dataSet.Result;
        }

        //第一次取数据同时取一下常量数据集,暂时不用在场景加载完成前加载,故先不做等待
        if (DataManager.constDataSet == null)
        {
            Addressables.LoadAssetAsync<DataSet>("Data/Main/ConstDataSet").Completed += go => {
                DataManager.constDataSet = go.Result;
            };
        }

        StartCoroutine(GoScenes(scenesNum));
    }

    IEnumerator GoScenes(int scenesNum)
    {
        //场景调整后清空一下UIPanel堆栈
        UIManager.Instance.ClearStack();
        yield return nowScenes = Addressables.LoadSceneAsync(scenesNum, LoadSceneMode.Single);
       

    }

	/// <summary>
	/// 检测当前是否处于场景跳转的状态
	/// </summary>
	/// <returns></returns>
	public bool CheckIsLoadingScene()
	{
		if (!dataSet.IsDone || !nowScenes.IsDone)
			return true;
		return false;
	}


    private void OnDestroy()
    {      
        toScenes.Invoke();
    }
}
