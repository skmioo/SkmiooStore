using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Numerical
{
	public int Atk;
	public int Def;
}

//职业
public enum Profression
{
	Warrior = 0,
	Wizard = 1
}

public class SimpleInspector : MonoBehaviour
{
	//公有变量，检视面板不可见
	[HideInInspector]
	public int id = 99;

	//私有变量，检视面板可见
	[SerializeField]
	private string name;
	
	//留50像素的空白区
	[Space(50)]
	//检视面板显示对象 Serializable
	public Numerical Num;

	//给数值添加范围
	[Header("年龄")]
	[Tooltip("提示提示提示提示提示提示")]
	[Range(0,100)]
	public int Age;

	//超过10行以滚动条显示
	[TextArea(5,10)]
	public string NickName;

	[Multiline(5)]
	public string Address;

	public Color Flag;

	public Texture tex;

	public List<string> tags;

	public Profression profression;

	//点击脚本的小齿轮 执行函数
	[ContextMenu("输出攻防比")]
	public void PrintADProportion()
	{
		if (Num.Def != 0)
		{
			Debug.Log("当前角色的攻防比:" + Num.Atk * 1.0f / Num.Def);
		}
		else
		{
			Debug.Log("当前角色的攻防比 0");
		}
	}

	//给成员变量添加右键菜单
	[ContextMenuItem("输出国家", "OutCountry")]
	[Tooltip("右击看看")]
	public string Country;
	public void OutCountry()
	{
		Debug.Log("OutCountry:" + Country);
	}
}
