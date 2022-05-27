using UnityEngine;
using System.Collections;
#if UNITY_IOS
using System.Runtime.InteropServices;
#endif

namespace UYMO
{
	public class IPv6Impl
	{
#if UNITY_IOS && !UNITY_EDITOR
		[DllImport("__Internal")]
		public static extern string GetIPv6(string mHost, string mPort); 
#else
		public static string GetIPv6(string mHost, string mPort)
		{
			return mHost + "&&ipv4";
		}
#endif

	}
}
