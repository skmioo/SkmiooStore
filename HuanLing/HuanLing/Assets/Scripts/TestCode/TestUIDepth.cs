using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI深度
/// 相对于根Canvas的深度，注意这里的Depth和Camera的Depth没有关系。且在没有开始渲染时为-1
/// https://www.jianshu.com/p/11babd26a4cb
/// </summary>
public class TestUIDepth : MonoBehaviour , ICanvasElement
{
	public Graphic graphic {
		get {
			return GetComponent<Graphic>();
		}
	}
	public void GraphicUpdateComplete()
	{
		//Debug.Log(gameObject.name + " depth:" + graphic.depth + " renderer Depth:" + graphic.gameObject.GetComponent<CanvasRenderer>().absoluteDepth);
	}

	public bool IsDestroyed()
	{
		return false;
	}

	public void LayoutComplete()
	{
		
	}

	public void Rebuild(CanvasUpdate executing)
	{
	
	}

	// Start is called before the first frame update
	void Start()
    {
		//CanvasUpdateRegistry.RegisterCanvasElementForGraphicRebuild(this);
		StartCoroutine(showLog());
    }

	private IEnumerator showLog()
	{
		yield return new WaitForEndOfFrame();
		Debug.Log(gameObject.name + " depth:" + graphic.depth + " renderer Depth:" + graphic.gameObject.GetComponent<CanvasRenderer>().absoluteDepth);
	}



	// Update is called once per frame
	void Update()
    {
        
    }
}
