using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NetObjTickManger : CSharpSingletion<NetObjTickManger> 
{
	GameObject m_NetObjTickMangerObj = null;
	public Dictionary<string, NetObjTick> m_NetObjTicks = new Dictionary<string, NetObjTick>();
	public void RunNetObjTick(string name, float repeatTime, MyAction<object[]> action, object[] param)
	{
		if (repeatTime <= 0)
			return;
		NetObjTick netObjTick = null;
		if (m_NetObjTicks.TryGetValue(name, out netObjTick))
		{
			//Debug.Log("tick " + name + " already running!");
			netObjTick.SetTickActionAndParam(action, param);
			return;
		}

		if (m_NetObjTickMangerObj == null)
		{
			m_NetObjTickMangerObj = new GameObject("NetObjTickManger");
			GameObject.DontDestroyOnLoad(m_NetObjTickMangerObj);
		}

		netObjTick = m_NetObjTickMangerObj.AddComponent<NetObjTick>();
		m_NetObjTicks.Add(name, netObjTick);
		netObjTick.RunTick(repeatTime, action, param);
	}

	public void StopNetObjTick(string name)
	{
		NetObjTick netObjTick = null;
		if (!m_NetObjTicks.TryGetValue(name, out netObjTick))
		{
			//Debug.Log("Did not have tick " + name);
			return;
		}

		m_NetObjTicks.Remove(name);
		if (netObjTick == null)
			return;
		netObjTick.StopAllCoroutines();
		GameObject.Destroy(netObjTick);
		//GameObject.DestroyImmediate(netObjTick);
	}
	
}

public class NetObjTick : MonoBehaviour
{
	private float m_waitSecondTime = 0.2f;
	private WaitForSeconds m_waitSecond = null;
	private MyAction<object[]> m_netTickAction = null;
	private object[] m_param;

	public void RunTick(float waitTime, MyAction<object[]> action, object[] param)
	{
		m_waitSecondTime = waitTime;
		m_waitSecond = new WaitForSeconds(m_waitSecondTime);
		SetTickActionAndParam(action, param);
		StartCoroutine(Tick());
	}

	public void SetTickActionAndParam(MyAction<object[]> action, object[] param)
	{
		m_netTickAction = action;
		m_param = param;
	}

	void Start () 
	{
	}
	
	private IEnumerator Tick()
	{
		while (true)
		{
			if (m_netTickAction != null)
			{
				m_netTickAction(m_param);
				//GameLog.LogCtrl.Info("send move time {0}", FacadeGlobal.TimerCtrl.GetTimeStamp());
			}
			yield return m_waitSecond;
		}
	}
}