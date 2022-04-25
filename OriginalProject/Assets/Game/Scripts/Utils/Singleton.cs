using UnityEngine;
using System.Collections;
/// <summary>
///单例基类 
/// </summary>
public class Singleton<T> where T :  new()
{
    protected static T m_instance = new T();
    public static T Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = new T();
            }
            return m_instance;
        }
    }
}
