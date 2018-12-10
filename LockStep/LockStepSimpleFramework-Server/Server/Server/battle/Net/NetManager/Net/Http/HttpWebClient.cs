using UnityEngine;
using System.Collections;
using System.Net;
/**********************************************
* @说明: http
* @作者：ZHM --- 海鸣不骑猪 
* @版本号：V1.00
**********************************************/ 
public class HttpWebClient : WebClient 
{		
	private CookieContainer mCookieContainer;
	
	public HttpWebClient()
	{
		mCookieContainer = new CookieContainer();
	}
	
	protected override WebRequest GetWebRequest (System.Uri address)
	{
		 WebRequest request = base.GetWebRequest(address);
		if ( request is HttpWebRequest )
		{
			HttpWebRequest httprequest = request as HttpWebRequest;
			httprequest.CookieContainer = mCookieContainer;
		}
		return request;
	}
}
