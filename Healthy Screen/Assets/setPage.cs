using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class setPage : MonoBehaviour
{
	public Toggle toggle;
	public InputField input;
	public GameObject tip;
	public GameObject tip2;
	public string file = "C:/Windows/System32/drivers/etc/hosts";
	string appendWeb = "127.0.0.1 {0}";
	// Start is called before the first frame update
	void Start()
	{
		string text = System.IO.File.ReadAllText(file);
		//Debug.Log(text);
	}

	private void Update()
	{

		if (Input.GetKey(KeyCode.Z) && Input.GetKey(KeyCode.LeftControl))
		{
			clearWeb();
		}
	}

	public void clearWeb()
	{
		input.text = string.Empty;
	}

	string[] startCheck = { "https://" ,
							"https:/",
							"http://" ,
							"http:/" };
	string[] endCheck = { "com" ,
							"cc",
							};
	public void AddWeb()
	{
		if (input.text.Length < 5)
			return;
		string text = System.IO.File.ReadAllText(file);
		if (text.Contains(input.text))
		{
			showhasPage();
			return;
		}
		string web = input.text;
		for (int i = 0; i < startCheck.Length; i++)
		{
			web = checkStart(web, startCheck[i]);
		}
		string retWeb;
		for (int i = 0; i < endCheck.Length; i++)
		{
			retWeb = checkEnd(web, endCheck[i]);
			if (retWeb != string.Empty)
			{
				web = retWeb;
			}
		}
		
		if (web.EndsWith("/"))
		{
			web = web.Substring(0, web.Length - 1);
		}

		StringBuilder sb = new StringBuilder();
		sb.Append(text);
		sb.AppendLine();
		sb.AppendFormat(appendWeb, web);
		System.IO.File.WriteAllText(file, sb.ToString());
		ShowTip("添加屏蔽网页成功:" + web.ToString());
		tip2.gameObject.SetActive(true);
		if (toggle.isOn)
		{
			clearWeb();
		}
		//ShowTip(web);
	}

	string checkStart(string web, string start)
	{
		if (web.Contains(start))
		{
			return web.Replace(start, "");
		}
		return web;
	}

	public string checkEnd(string str, string key)
	{
		string web = str;
		string[] strs = web.Split('.');
		int findindex = -1;
		for (int i = 0; i < strs.Length; i++)
		{
			if (strs[i].Contains(key))
			{
				findindex = i;
				break;
			}
		}
		if (findindex != -1)
		{
			strs[findindex] = key;
			StringBuilder webSb = new StringBuilder();
			for (int i = 0; i <= findindex; i++)
			{
				webSb.Append(strs[i]);
				webSb.Append(".");
			}

			web = webSb.ToString();
			if (web.EndsWith("."))
			{
				web = web.Substring(0, web.Length - 1);
			}
		}
		else
		{
			return string.Empty;
		}
		return web;
	}


	void showhasPage()
	{
		ShowTip("已屏蔽该网页");
	}

	void ShowTip(string tips)
	{
		tip.GetComponent<Text>().text = tips;
		tip.SetActive(true);
		StartCoroutine(hideTip());
	}

	private IEnumerator hideTip()
	{
		yield return new WaitForSeconds(2.0f);
		tip.SetActive(false);
		tip2.gameObject.SetActive(false);

	}
}
