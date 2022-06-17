using System;
using System.Collections;
using System.Collections.Generic;
using SLua;
using UnityEngine;
using UYMO;

public class EventTestEvent : EventBase
{
	public const string TestEventType = "TestEvent";
	public const string Event1 = "Event1";
	public const string Event2 = "Event2";

	public EventTestEvent(string aSubEvent) : base(aSubEvent)
	{
		
	}
}

public class EventTest : MonoBehaviour , IEventBus
{
	private EventBus _EventBus;

	// Start is called before the first frame update
	void Start()
    {
		_EventBus = new EventBus(this);
		_EventBus.AddListener(EventTestEvent.Event1, onEvent1);
		_EventBus.AddListener(EventTestEvent.Event2, onEvent2);
		StartCoroutine(TestEvent());

	}

	private void onEvent2(EventBase evt)
	{
		Debug.Log("onEvent2..." + evt.eventType);
	}

	private void onEvent1(EventBase evt)
	{
		Debug.Log("onEvent1..." + evt.eventType);
	}

	WaitForSeconds sec = new WaitForSeconds(2);
	
	private IEnumerator TestEvent()
	{
		yield return sec;
		DispatchEvent(new EventTestEvent(EventTestEvent.Event1));

		yield return sec;
		DispatchEvent(new EventTestEvent(EventTestEvent.Event2));
	}

	private void OnDestroy()
	{
		_EventBus.RemoveListener(EventTestEvent.Event1, onEvent1);
		_EventBus.RemoveListener(EventTestEvent.Event2, onEvent2);
	}


	public void AddListener(string eventType, EventBusHandle handle)
	{
		_EventBus.AddListener(eventType, handle);
	}
	public void RemoveListener(string eventType, EventBusHandle handle)
	{
		_EventBus.RemoveListener(eventType, handle);
	}
	public bool HasListener(string eventType, EventBusHandle handle)
	{
		return _EventBus.HasListener(eventType, handle);
	}
	public void AddDynamicListener(string eventType, LuaTable lua, LuaEventBusHandle handle)
	{
		_EventBus.AddDynamicListener(eventType, lua, handle);
	}
	public void RemoveDynamicListener(string eventType, LuaTable lua, LuaEventBusHandle handle)
	{
		_EventBus.RemoveDynamicListener(eventType, lua, handle);
	}
	public bool HasDynamicListener(string eventType, LuaTable lua, LuaEventBusHandle handle)
	{
		return _EventBus.HasDynamicListener(eventType, lua, handle);
	}
	public void ClearAllListeners()
	{
		_EventBus.ClearAllListeners();
	}
	public void DispatchEvent(EventBase evt)
	{
		_EventBus.DispatchEvent(evt);
	}

}
