using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


/// <summary>
/// 碰撞触发器
/// </summary>
public class Collider2DTriggreManager : MonoBehaviour
{
    public Action<GameObject,Collider2D> Enter;
    public Action<GameObject, Collider2D> Exit;
    public Action<GameObject, Collider2D> Stay;


    static public Collider2DTriggreManager AddTriggersListener(GameObject go)
    {
        Collider2DTriggreManager listener = go.GetComponent<Collider2DTriggreManager>();
        if (listener == null) listener = go.AddComponent<Collider2DTriggreManager>();

        return listener;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enter?.Invoke(gameObject, collision);       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Exit?.Invoke(gameObject, collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Stay?.Invoke(gameObject, collision);
    }

}
