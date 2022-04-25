using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneFade : MonoBehaviour
{
	//淡入时间
	public float fadeInTime = 2.0f;
	//淡出时间
	public float fadeOutTime = 2.0f;
	/// <summary>
	/// bool值为True代表屏幕由白变黑
	/// bool值为False代表屏幕由黑变白
	/// </summary>
	public Action<bool> blackCompleteAction;
	private Color fadeInColor = new Color(0.01f, 0.01f, 0.01f, 1.0f);
	private Color fadeOutColor = new Color(0.01f, 0.01f, 0.01f, 0.01f);
	private Material fadeMaterial = null;
	private bool isFadingIn = false;
	private bool isFadeOut = false;
	private bool isFade = false;
	private YieldInstruction fadeInstruction = new WaitForEndOfFrame();
	void Awake()
	{
		fadeMaterial = new Material(Shader.Find("Unlit/FadeBlack"));
		CameraOff();
	}

    private void Start()
    {
		Fade(true);
	}

    void OnDisable()
	{
		isFadeOut = false;
		isFadingIn = false;
	}
	void OnDestroy()
	{
		if (fadeMaterial != null)
		{
			isFadeOut = false;
			isFadingIn = false;
			Destroy(fadeMaterial);
		}
	}
	private void OnPostRender()
	{
		if (isFadingIn)
		{
			fadeMaterial.SetPass(0);
			GL.PushMatrix();
			GL.LoadOrtho();
			GL.Color(fadeMaterial.color);
			GL.Begin(GL.QUADS);
			GL.Vertex3(0f, 0f, -12f);
			GL.Vertex3(0f, 1f, -12f);
			GL.Vertex3(1f, 1f, -12f);
			GL.Vertex3(1f, 0f, -12f);
			GL.End();
			GL.PopMatrix();
			//Debug.Log("isfadein");
		}
		if (isFadeOut)
		{
			fadeMaterial.SetPass(0);
			GL.PushMatrix();
			GL.LoadOrtho();
			GL.Color(fadeMaterial.color);
			GL.Begin(GL.QUADS);
			GL.Vertex3(0f, 0f, -12f);
			GL.Vertex3(0f, 1f, -12f);
			GL.Vertex3(1f, 1f, -12f);
			GL.Vertex3(1f, 0f, -12f);
			GL.End();
			GL.PopMatrix();
			//Debug.Log("isfadeout");
		}		
	}
	IEnumerator FadeIEnumator(bool fadeIn)
	{
		float fadeTime = fadeIn ? fadeInTime : fadeOutTime;
		isFadingIn = fadeIn ? true : false;
		isFadeOut = fadeIn ? false : true;
		float elapsedTime = 0.0f;
		Color color = fadeIn ? fadeInColor : fadeOutColor;
		fadeMaterial.color = color;
		while (elapsedTime < fadeTime)
		{
			yield return new WaitForEndOfFrame();
			elapsedTime += Time.deltaTime;
			float a = fadeIn ? 1 - Mathf.Clamp01(elapsedTime / fadeInTime) : Mathf.Clamp01(elapsedTime / fadeOutTime);
			color.a = a;
			fadeMaterial.color = color;
		}
		//isFadeOut = isFadingIn = false;
		if (blackCompleteAction != null)
		{
			blackCompleteAction.Invoke(fadeIn);
		}
	}

	/// <summary>
	/// 场景淡入淡出
	/// </summary>
	/// <param name="isFadeIn"></param>
	public void Fade(bool isFadeIn)
	{
		StartCoroutine(FadeIEnumator(isFadeIn));
	}
	/// <summary>
	/// 关闭相机
	/// </summary>
	public void CameraOff()
    {
		fadeMaterial.color = new Color(0, 0, 0, 0);

	}
#if UNITY_EDITOR
	void Update()
	{
		//if (Input.GetMouseButtonDown(0))
		//{
		//	Debug.Log("淡入：画面由暗变亮");
		//	Fade(true);
		//}
		//if (Input.GetMouseButtonDown(1))
		//{
		//	//表示淡出
		//	Debug.Log("淡出：画面由亮变暗");
		//	Fade(false);
		//}
		//if (Input.GetMouseButtonDown(2))
		//{
		//	isFadingIn = false;
		//	isFadeOut = false;
		//}
	}
#endif
}
