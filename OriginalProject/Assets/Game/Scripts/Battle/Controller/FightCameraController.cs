using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Datas;

public class FightCameraController : MonoBehaviour
{
    private Camera self;

    private static FightCameraController _instance;
    public static FightCameraController Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        self = GetComponent<Camera>();
    }

    public void Play(CameraMoveData[] datas)
    {
        Sequence seq = DOTween.Sequence();

        for (int i = 0; i < datas.Length; i++)
        {
            var d = datas[i];
            switch (d.moveType)
            {
                case CameraMoveType.旋转:
                    if (d.sameTime)
                    {
                        transform.DORotate(d.rotationValue, d.time).SetEase(d.curve).Play();
                    }
                    else
                    {
                        seq.Append(transform.DORotate(d.rotationValue, d.time).SetEase(d.curve));
                    }
                    break;
                case CameraMoveType.缩放:
                    if (d.sameTime)
                    {
						self.DOOrthoSize(d.scaleValue, d.time).SetEase(d.curve).Play();
                    }
                    else
                    {
                        seq.Append(self.DOOrthoSize(d.scaleValue, d.time).SetEase(d.curve));
                    }
                    break;
                case CameraMoveType.震动:
                    if (d.sameTime)
                    {
                        transform.DOShakePosition(d.time, d.shakeValue, d.shakeVabrato, d.radomness, d.snapping).SetEase(d.curve).Play();
                    }
                    else
                    {
                        seq.Append(transform.DOShakePosition(d.time, d.shakeValue).SetEase(d.curve));
                    }
                    break;
                case CameraMoveType.等待:
                    seq.AppendInterval(d.time);
                    break;
                case CameraMoveType.FOV:
                    if (d.sameTime)
                    {
                        self.DOFieldOfView(d.fovValue, d.time).SetEase(d.curve).Play();
                    }
                    else
                    {
                        seq.Append(self.DOFieldOfView(d.fovValue, d.time).SetEase(d.curve));
                    }
                    break;
            }
        }
    }

}
