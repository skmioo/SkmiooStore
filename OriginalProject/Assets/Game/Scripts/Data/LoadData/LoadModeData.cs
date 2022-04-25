using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement;
using UnityEngine.AddressableAssets;
using System;
using Datas;
using UnityEngine.ResourceManagement.AsyncOperations;
using DG.Tweening;

public class LoadModeData : MonoSingleton<LoadModeData>
{
	protected override bool global => true;

	public ModeDataSet modeDataSet;//是否需要将这个做成全局的？

	public UIPanelDataSet uipanelSet;

	public UnityEngine.UI.Text textObj;
	Sequence seq;

	private void Start()
	{
		//Addressables.LoadAssetAsync<UIPanelDataSet>("Data/Main/UIPanelData").Completed += EndLoadUIpanelData;
		//Addressables.LoadAssetAsync<ModeDataSet>("Data/Main/ModeData").Completed += EndLoadModeData;

		//StartCoroutine(delayedLoad());
		loadData();
	}

	//待删除UI框架结构
	//private void EndLoadUIpanelData(AsyncOperationHandle<UIPanelDataSet> obj)
	//{
	//    switch (obj.Status)
	//    {
	//        case AsyncOperationStatus.None:
	//            Debug.LogError("没有找到Data/Main/UIPanelData数据");
	//            break;
	//        case AsyncOperationStatus.Succeeded:

	//            uipanelSet = obj.Result;
	//            DataManager.uIPanelDataSet = obj.Result;
	//            break;
	//        case AsyncOperationStatus.Failed:
	//            break;
	//        default:
	//            break;
	//    }
	//}

	//private void EndLoadModeData(AsyncOperationHandle<ModeDataSet> obj)
	//{
	//    switch (obj.Status)
	//    {
	//        case AsyncOperationStatus.None:
	//            Debug.LogError("没有找到Data/Main/ModeData数据");
	//            break;
	//        case AsyncOperationStatus.Succeeded:
	//            modeDataSet = obj.Result;
	//            DataManager.modeDataSet = modeDataSet;

	//            break;
	//        case AsyncOperationStatus.Failed:
	//            break;
	//        default:
	//            break;
	//    }
	//}

	/// <summary>
	/// save在需要的时候手动调用一下
	/// </summary>
	public void saveData()
	{
		modeDataSet = DataManager.modeDataSet;
		DataManager.Instance.SetJson(modeDataSet);
		shouLoadText("save ......");
	}

	/// <summary>
	/// load存档应该只在游戏运行后load一次，运行中不应该再load
	/// </summary>
	private void loadData()
	{
		DataManager.Instance.init();
		shouLoadText("load ......");
	}

	/// <summary>
	/// 延时加载存档保证能覆盖调asset
	/// 后面应该在DataManage初始化后执行以保证覆盖asset
	/// </summary>
	/// <returns></returns>
	IEnumerator delayedLoad()
	{
		yield return new WaitForSeconds(1);
		loadData();
	}

	void shouLoadText(string inString)
	{
		seq.Kill();
		seq = DOTween.Sequence();

		Color tempColor = Color.white;
		Color tempColor2 = Color.white;
		float tempShowTime = 0.8f;
		tempColor2.a = 0;

		textObj.text = inString;

		seq.Append(textObj.DOColor(tempColor, tempShowTime)).
			Append(textObj.DOColor(tempColor2, tempShowTime)).
			Append(textObj.DOColor(tempColor, tempShowTime)).
			Append(textObj.DOColor(tempColor2, tempShowTime));
	}

	private void OnApplicationQuit()
	{
		modeDataSet = DataManager.modeDataSet;
		DataManager.Instance.SetJson(modeDataSet, "quitData");
	}
}
