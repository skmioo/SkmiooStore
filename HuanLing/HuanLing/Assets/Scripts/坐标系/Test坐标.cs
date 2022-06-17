using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test坐标 : MonoBehaviour
{
	public Camera camera;

	private void OnGUI()
	{
		GUI.Label(new Rect(10, 10, 250, 20), "世界坐标" + transform.position);
		GUI.Label(new Rect(10, 30, 250, 20), "局部坐标" + transform.localPosition);
		GUI.Label(new Rect(10, 50, 250, 20), "屏幕宽高" + Screen.width + " x " + Screen.height);
		GUI.Label(new Rect(10, 70, 250, 20), "鼠标位置" + Input.mousePosition);
		GUI.Label(new Rect(10, 90, 250, 20), "鼠标位置(视口位置)" + camera.ScreenToViewportPoint(Input.mousePosition));

		GUI.Label(new Rect(10, 110, 250, 20), "屏幕转世界,转换后" + ToWorldPos(transform, Input.mousePosition));

	}


	void Update()
    {
		transform.position = ToWorldPos(transform, Input.mousePosition);

	}

	Vector3 ToWorldPos(Transform target, Vector3 screenPos)
	{
		Vector3 targetScreenPos = camera.WorldToScreenPoint(target.position);
		screenPos.z = targetScreenPos.z;
		return camera.ScreenToWorldPoint(screenPos);
	}
}
