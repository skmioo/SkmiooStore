using UnityEngine;
using System.Collections;

public class Delay : MonoBehaviour {
	
	public float delayTime = 1.0f;

    // «∑Ò≥ı ºªØ
    private bool _Invoked = false;
    private bool _Started = false;

	// Use this for initialization
	void Start () {
        Init();
        _Started = true;
	}

    void OnEnable()
    {
        if(_Started)
        {
            Init();
        }
    }

	void DelayFunc()
	{
        gameObject.SetActive(true);
        _Invoked = false;
	}

    private void Init()
    {
        if (!_Invoked)
        {
            gameObject.SetActive(false);
            Invoke("DelayFunc", delayTime);
            _Invoked = true;
        } 
    }
	
}
