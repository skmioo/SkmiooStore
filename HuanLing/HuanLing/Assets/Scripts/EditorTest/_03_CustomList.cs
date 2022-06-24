using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

//[System.Serializable]告诉unity序列化这个类，如果
//它用于公共数组或组件中的公共变量
[System.Serializable]
public class PistonState
{
	public string Name;
	public Vector3 Position;
}

public class _03_CustomList : MonoBehaviour
{
	[Header("Header")]
	public float Speed;
	public Vector3 AddForceWhenHittingPlayer;
	//我们将其隐藏在检查器中，因为我们想绘制自己的自定义
	//检查器。
	[HideInInspector]
	public List<PistonState> States = new List<PistonState>();

}

