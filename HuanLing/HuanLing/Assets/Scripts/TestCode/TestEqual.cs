using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// ==大部分是比较对象是否相同非值相同
/// Equals一般是比较值是否相同
/// ==的string类型做了修改
/// </summary>
[ExecuteInEditMode]
public class TestEqual : MonoBehaviour
{
	
	/// <summary>
	/// 一、值类型
	///		1.对于值类型来说，两者比较的都是“内容”是否相同，也就是值是否相同（值类型只有存在栈上）。
	///二、引用类型
	///		1.对于引用类型来说，本身的值存在堆中，在栈中存入本身值的引用，可以根据引用找到自己。
	///     对于引用类型来说，==比较的两个变量的”引用“是否一样，也就是“地址”是否一样。而equals比较的是”内容“是否一样。
	///		
	/// </summary>

	///	 总结：
	///  1、对于值类型来说，Equlas和==并没有什么区别，比较的都是值是否相等。
	///  2、对于引用类型来说，==比较的两个变量的”引用“是否一样（也就是“地址”是否一样）。而equals比较的是”内容“是否一样。
	///  3、string是引用类型，俩个值引用不一样，但==值一样，因为string对==做了重写	public static bool operator ==(String a, String b);
	///  4、俩个类的equals值为false因为没有对equals方法重写，此时使用的object里的equals方法,所以不一样
	void Start()
    {

		/*string比较实例,以下都输出true*/
		string s1 = new string(new char[] { 'H', 'e', 'l', 'l', 'o' });
		string s2 = new string(new char[] { 'H', 'e', 'l', 'l', 'o' });
		string s3 = "Hello";
		string s4 = "Hello";
		Debug.Log("s1 == s2" + (s1 == s2));
		Debug.Log("s1.Equals(s2)" + (s1.Equals(s2)));
		Debug.Log("s3 == s4" + (s3 == s4));
		Debug.Log("s3.Equals(s4)" + s3.Equals(s4));
		Debug.Log("s1 == s3" + (s1 == s3));
		Debug.Log("s1.Equals(s3)" + s1.Equals(s3));

		object obj1 = s1;
		object obj2 = s2;
		Debug.Log("obj1 == obj2" + (obj1 == obj2));//false,比较obj1和obj2的指针，即s1和s2的地址
		Debug.Log("obj1.Equals(obj2)" + obj1.Equals(obj2));//true，比较的是s1和s2是否指向同一块内存

		//Vector v1 = new Vector(1);
		//Vector v2 = new Vector(1);
		//Debug.Log(v1 == v2);//false,比较v1和v2指向是否一样
		//Debug.Log(v1.Equals(v2));//false,对于非匿名对象，比较是否指向同一块内存

		var obj3 = new { Name = "abc", Age = 20 };
		var obj4 = new { Name = "abc", Age = 20 };
		var obj5 = new { Name = "abd", Age = 21 };
		Debug.Log("obj3 == obj4" + (obj3 == obj4));//false
		Debug.Log("obj3.Equals(obj4)" + obj3.Equals(obj4));//true,对于匿名对象，比较内容

		int i1 = 10;
		int i2 = 10;
		Debug.Log("i1 == i2" + (i1 == i2));//true
		Debug.Log("i1.Equals(i2)" + i1.Equals(i2));//true
	}

}
