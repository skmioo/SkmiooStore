using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class BuildPanelMag : MonoSingleton<BuildPanelMag>
{
	public AssetReferenceSprite tempRilcIco;

	public GameObject touchBox;
	public List<BuildPanelBase> buildAry = new List<BuildPanelBase>();

	bool isInReadyPanel = false;

	private void Start()
	{
		StartCoroutine(startRefresh());
		AudioManager.Instance.PlayMusic(AudioName.TownBGM);
	}

	public void refreshBuild()
	{
		//for (int i = 0; i < buildAry.Count; i++) buildAry[i].RefreshData();
		foreach (var tempBuild in buildAry)
		{
			if (tempBuild is HealPanel) tempBuild.RefreshData();
			if (tempBuild is RecruitingHeros) tempBuild.RefreshData();
		}
	}

	public void addBuild(BuildPanelBase inBuild)
	{
		if (!buildAry.Equals(inBuild)) buildAry.Add(inBuild);
	}

	public void onOpenRelicPanel()
	{
		AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
		foreach (var tempBuild in buildAry) { if (tempBuild is RelicPanel) tempBuild.open(); }
	}

	public void onCloseAllBuild() { for (int i = 0; i < buildAry.Count; i++) buildAry[i].close(); }

	public void onReadyPanel(bool isIn)
	{
		isInReadyPanel = isIn;
		if (isIn)
			onCloseAllBuild();
	}

	public void setTouchBox(bool inBool = false)
	{
		if (isInReadyPanel) return;
		if (inBool) { touchBox.SetActive(true); }
		else { touchBox.SetActive(false); }

		//return;
		//if (inBool)
		//{
		//    if (touchBox != null)
		//    {
		//        touchBox.SetActive(true);
		//    }
		//}
		//else
		//{
		//    if (touchBox != null)
		//    {
		//        foreach (Transform temp in touchBox.transform)
		//        {
		//            temp.GetChild(0).gameObject.SetActive(false);
		//        }
		//        touchBox.SetActive(false);
		//    }
		//}
	}

	IEnumerator startRefresh()
	{
		yield return new WaitForSeconds(0.1f);
		refreshBuild();
		yield return null;
		LoadModeData.Instance.saveData();
	}
}
