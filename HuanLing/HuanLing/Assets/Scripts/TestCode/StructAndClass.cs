using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

//[ExecuteInEditMode]
public class StructAndClass : MonoBehaviour
{
	[HideInInspector]
	public string tip = "struct 是值类型，struct数值传递时不是靠引用而是靠值复制值类型的数据是连续的，数据清空只需要把尾指针置零，没有数据垃圾Class的类的值是分散的";


}

