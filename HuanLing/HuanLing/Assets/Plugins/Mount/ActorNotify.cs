using System;
using UnityEngine;

public class ActorNotify : MonoBehaviour {

    public Action<string> HitNotify;
    public Action<string> eEvents;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void NotifyHit(string actorName )
    {
        if( HitNotify != null )
        {
            HitNotify(actorName);
        }
    }
    /// <summary>
    /// 通用动作事件通知
    /// </summary>
    /// <param name="actor">动作名称</param>
    /// <param name="evt">事件名称</param>
    public void CommonEvent(string evt)
    {
        if(eEvents != null)
        {
            eEvents(evt);
        }
    }
}
