using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 单例基类
/// </summary>
/// <typeparam name="T"></typeparam>
public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    /// <summary>
    /// 是否为常驻节点 默认false
    /// </summary>
    protected virtual bool global { get; }
    /// <summary>
    /// 是否需要新建一个GameObject来装载脚本
    /// </summary>
  //protected virtual bool IsNeedNewGameObject { get; }
    static T instance = null;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (T)FindObjectOfType<T>();
                //if (instance == null) {
                //    //获取T类的类型信息
                //    Type t = Type.GetType(typeof(T).FullName);
                //    GameObject gTmp = new GameObject(t.Name);
                //    instance = gTmp.AddComponent<T>();
                //}
            }
            return instance;
        }
    }
    protected virtual void Awake()
    {
        if (global)
        {
            if (instance != null && instance != gameObject.GetComponent<T>())
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
            instance = gameObject.GetComponent<T>();
        }
    }
}


