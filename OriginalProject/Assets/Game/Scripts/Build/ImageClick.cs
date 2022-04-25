using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ImageClick : MonoBehaviour
{
	public Image bgImage;
	public Text bgText;
	public string buildName;
	public BuildPanelBase buildBase;
	Sequence seq;

	void Start()
	{
		//transform.GetComponent<Image>().alphaHitTestMinimumThreshold = 1;
		setData();
	}

	void Update()
	{

	}

	void setData()
	{
		if (buildBase == null) return;
		gameObject.AddComponent<Button>().onClick.AddListener(() => { buildBase.SetPanel(true); onPointOut(); });
		var tempTri = gameObject.AddComponent<EventTrigger>();

		UnityAction<BaseEventData> pointIn = new UnityAction<BaseEventData>(inGo => { onPointIn(); });
		var tempEntry = new EventTrigger.Entry();
		tempEntry.eventID = EventTriggerType.PointerEnter;
		tempEntry.callback.AddListener(pointIn);

		UnityAction<BaseEventData> pointOut = new UnityAction<BaseEventData>(inGo => { onPointOut(); });
		var tempEntry2 = new EventTrigger.Entry();
		tempEntry2.eventID = EventTriggerType.PointerExit;
		tempEntry2.callback.AddListener(pointOut);

		tempTri.triggers.Add(tempEntry);
		tempTri.triggers.Add(tempEntry2);

		bgText.text = LanguageController.GetValue(buildName);
	}

	public void onPointIn()
	{
		seq.Kill();
		seq = DOTween.Sequence();
		seq.Append(bgImage.DOColor(Color.white, 0.5f))
			.Append(bgText.DOColor(Color.white, 0.5f));
	}

	public void onPointOut()
	{
		seq.Kill();
		seq = DOTween.Sequence();
		seq.Append(bgText.DOColor(Color.clear, 0.5f))
			.Append(bgImage.DOColor(Color.clear, 0.5f));
	}
}
