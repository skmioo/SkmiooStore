using UnityEngine;
using System.Collections;
#if UNITY_IOS
using System.Runtime.InteropServices;
#endif

namespace UYMO
{
	public class Battery 
	{
#if UNITY_IOS && !UNITY_EDITOR
		[DllImport("__Internal")]
		public static extern int GetBattery();
#else
		public static int GetBattery()
		{
			return 100;
		}
#endif
	}
}
