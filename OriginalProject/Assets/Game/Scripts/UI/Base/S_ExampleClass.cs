using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_ExampleClass : MonoBehaviour
{
	public GameObject debugTextObj;
	public Text debugText;
	public string output = "";
	public string stack = "";

	bool isShowTextUI = false;

	float tempTime = 0;

	private void Start()
	{
		debugTextObj.SetActive(false);
	}

	private void Update()
	{
		if (Input.GetKey(KeyCode.I) && Input.GetKey(KeyCode.O) && Input.GetKeyDown(KeyCode.P))
		{
			isShowTextUI = isShowTextUI ? false : true;
			debugTextObj.SetActive(isShowTextUI);
		}
	}

	void OnEnable()
	{
		Application.logMessageReceived += HandleLog;
	}

	void OnDisable()
	{
		Application.logMessageReceived -= HandleLog;
	}

	void HandleLog(string logString, string stackTrace, LogType type)
	{
		if (output.Length > 15000) { output = output.Remove(output.IndexOf('\n', 1000)); }
		if (type == LogType.Log || type == LogType.Assert)
		{
			output = "\n ------------------------------------------------" + output;
			output = $"\n <color=white>{logString}</color>" + output;
		}
		else if (type == LogType.Error || type == LogType.Exception)
		{
			output = "\n ------------------------------------------------" + output;
			output = $"\n <color=red>{logString}</color>" + output;
		}

		debugText.text = output;
	}
}