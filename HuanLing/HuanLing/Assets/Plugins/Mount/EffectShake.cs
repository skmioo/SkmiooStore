using UnityEngine;
using System.Collections;
using UYMO;

public class EffectShake : MonoBehaviour 
{
    public float startTime = 0;
    public float shakeTime = 0.3f;
    public float intensity = 0.5f;
    public float frequency = 20;
    public float decayPow = 4;
    public Vector3 shakeAxial = Vector3.forward;

    private bool _Started = false;
    private bool _Invoked = false;

	void Start () 
    {
        Init();
        _Started = true;
	}

    void OnEnable()
    {
        if (_Started)
        {
            Init();
        }
    }

    void Shake()
    {
        //PlayInterface.InvokeCameraShake(shakeTime, shakeAxial, frequency, decayPow);
        _Invoked = false;
    }

    /// <summary>
    /// 初始化操作
    /// </summary>
    private void Init()
    {
        if (!_Invoked)
        {
            Invoke("Shake", startTime);
            _Invoked = true;
        }
    }
}
