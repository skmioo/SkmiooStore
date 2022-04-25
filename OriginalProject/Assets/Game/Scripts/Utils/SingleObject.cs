using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleObject<T> : MonoBehaviour where T : MonoBehaviour
{

    private static T m_Instance = null;

    public static T instance
    {
        get
        {
            if (m_Instance == null)
            {              
                m_Instance = FindObjectOfType<T>();
                if (m_Instance == null)
                {
                    GameObject manager = GameObject.Find("[GameUtils]");
                    if (manager == null)
                    {
                        manager = new GameObject("[GameUtils]");
                        DontDestroyOnLoad(manager);
                    }
                    m_Instance = manager.AddComponent<T>();
                }
            }
            return m_Instance;
        }
    }
}