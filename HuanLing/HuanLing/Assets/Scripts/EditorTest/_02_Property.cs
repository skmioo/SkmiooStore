using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class _02_Property : MonoBehaviour
{
	[Space(10)]
	[Tooltip("MaximumHeight")]
	public float MaximumHeight;
	public float MinimumHeight;

	[Header("Safe Frame")]
	[Range(0f, 1f)]
	public float SafeFrameTop;
	[Range(0f, 1f)]
	public float SafeFrameBottom;
}

