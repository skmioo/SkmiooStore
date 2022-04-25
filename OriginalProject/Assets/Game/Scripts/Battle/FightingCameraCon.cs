#define Cinemachine
//#define CameraScheme1
//#define CameraScheme2
using Cinemachine;
using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 战斗中摄像机控制--待优化
/// </summary>
public class FightingCameraCon : MonoBehaviour
{
    static FightingCameraCon _instance;
    public static FightingCameraCon Instance { get { return _instance; } }
    public Transform LookAt;
    public Transform Scheme1, Scheme2, CinemachineTrans;

    public Camera mainCamera;
    public Camera FightingCamera;
    public Camera FightingActorCamera;
    public Camera FightingRoundCamera;
    private GaussianBlur oGaussianBlur;

    public const string DefaultLayerName = "Default";
    public const string FightingCameraLayerName = "FightingCamera";
    public const string FightingRoundCameraLayerName = "FightingRoundCamera";
    float limit;
#if Cinemachine
	public BoxCollider BoxCollider;
	private FightingCamCinemaCon fightCamCinemaCon;
#endif
	//限位器
	Vector3 move
    {
        get 
        {
            float x = LookAt.position.x;
            if (leftLimit)
            {
                //左限位,如果控制器输入的值比它小,停止移动
                if (LookAt.position.x < limit)
                {
                    x = limit;
                }
            }

            if (rightLimit)
            {
                //右限位
                if (LookAt.position.x > limit)
                {
                    x = limit;
                }
            }

            return new Vector3(x, transform.position.y, transform.position.z);
        }
    }
    float _initOrthographicSize = -1f;
   [Tooltip("摄像机放大目标值")] private float _targetOrthographicSize = 3.5f;
	float _initMainOrthographicSize = -1f;
    private void Awake()
    {
        _instance = this;
#if Cinemachine
		fightCamCinemaCon = CinemachineTrans.GetComponent<FightingCamCinemaCon>();
		fightCamCinemaCon.InitCameraCullingMask(Scheme1);
		DestroyImmediate(Scheme1.gameObject);
		DestroyImmediate(Scheme2.gameObject);
		mainCamera = CinemachineTrans.Find("Camera").GetComponent<Camera>();

#elif CameraScheme1
        DestroyImmediate(Scheme2.gameObject);
        mainCamera = Scheme1.Find("Camera").GetComponent<Camera>();
        Transform oTransform = Scheme1.Find("FightingCamera");
        FightingCamera = oTransform.GetComponent<Camera>();
        oGaussianBlur = oTransform.GetComponent<GaussianBlur>();
        FightingActorCamera = Scheme1.Find("FightingCamera/FightingActorCamera").GetComponent<Camera>();
        FightingRoundCamera = null;
#elif CameraScheme2
           DestroyImmediate(Scheme1.gameObject);
            mainCamera = Scheme2.Find("Camera").GetComponent<Camera>();
        FightingCamera = Scheme2.Find("FightingCamera").GetComponent<Camera>();
        FightingRoundCamera =Scheme2.Find("FightingRoundCamera").GetComponent<Camera>();
#endif
		_initMainOrthographicSize = mainCamera.orthographicSize;
#if Cinemachine
		_initOrthographicSize = fightCamCinemaCon.cinFightCam.m_Lens.OrthographicSize;
#else
		_initOrthographicSize = FightingCamera.orthographicSize;
#endif
	}

	private void Start()
    {
        ExitFight();
    }

    private void FixedUpdate()
    {      
        transform.position = move;
    }

    /// <summary>
    /// 进入战斗--战斗中
    /// </summary>
    public void Fighting(float fAniTime = 0.2f)
    {
#if Cinemachine
		fightCamCinemaCon.Fighting(fAniTime, _targetOrthographicSize);
#elif CameraScheme1
        mainCamera.gameObject.SetActive(false);
        FightingCamera.gameObject.SetActive(true);
        ///暂时写死-待优化
        Tweener tween = DOTween.To(() => FightingCamera.orthographicSize, x => FightingCamera.orthographicSize = x, _targetOrthographicSize, fAniTime);
        Tweener tween2 = DOTween.To(() => FightingActorCamera.orthographicSize, x => FightingActorCamera.orthographicSize = x, _targetOrthographicSize, fAniTime);
        DoGaussianBlur(0.8f, fAniTime);

#elif CameraScheme2
          FightingRoundCamera.gameObject.SetActive(true);
#endif

	}


	/// <summary>
	/// 退出战斗
	/// </summary>
	public void ExitFight(float fAniTime = 0.2f)
    {
#if Cinemachine
		fightCamCinemaCon.ExitFight(fAniTime, _initOrthographicSize);
#elif CameraScheme1
        Tweener tween = DOTween.To(() => FightingCamera.orthographicSize, x => FightingCamera.orthographicSize = x, _initOrthographicSize, fAniTime);
        Tweener tween2 = DOTween.To(() => FightingActorCamera.orthographicSize, x => FightingActorCamera.orthographicSize = x, _initOrthographicSize, fAniTime);
        DoGaussianBlur(0, fAniTime);
        tween.OnComplete(()=> {
            mainCamera.gameObject.SetActive(true);
            FightingCamera.gameObject.SetActive(false);
        });
#elif CameraScheme2
         FightingRoundCamera.gameObject.SetActive(false);
#endif

	}

	/// <summary>
	/// 战斗摄像机震动
	/// </summary>
	/// <returns>动画执行时间</returns>
	public float DoShake(float nTimeScale, Action<object> act = null, object data = null)
    {
#if Cinemachine
		return fightCamCinemaCon.DoShake(nTimeScale, act, data );
#elif CameraScheme1
		float animTime = 0;
		Transform oCameraTransform = FightingCamera.gameObject.transform;
        Vector3 vPos = oCameraTransform.localPosition;
        Sequence seq = DOTween.Sequence();
        float fAniTime = 0.15f * nTimeScale;
        float fAniTime2 = 0.1f * nTimeScale;
        seq.Append(oCameraTransform.DOLocalMoveY(vPos.y + 0.1f, fAniTime));
        seq.Append(oCameraTransform.DOLocalMoveY(vPos.y - 0.2f, fAniTime));
        seq.Append(oCameraTransform.DOLocalMoveY(vPos.y + 0.15f, fAniTime));
        seq.Append(oCameraTransform.DOLocalMoveY(vPos.y - 0.10f, fAniTime2));
        seq.Append(oCameraTransform.DOLocalMoveY(vPos.y + 0.10f, fAniTime2));
        seq.Append(oCameraTransform.DOLocalMoveY(vPos.y - 0.05f, fAniTime2));
        seq.Append(oCameraTransform.DOLocalMoveY(vPos.y + 0.05f, fAniTime2));
        seq.Append(oCameraTransform.DOLocalMoveY(vPos.y - 0.03f, fAniTime2));
        seq.Append(oCameraTransform.DOLocalMoveY(vPos.y, fAniTime2));

        seq.OnComplete(() => {
			act?.Invoke(data);
			oCameraTransform.localPosition = vPos;
		});
		animTime = fAniTime * 3 + fAniTime2 * 6;
		return animTime;
#elif CameraScheme2
		return 0;
#endif
	}

	/// <summary>
	/// 战斗摄像机偏移
	/// </summary>
	/// <returns>动画执行时间</returns>
	public float DoCameraAni(float nOffsetX, float fAniTime, float fEndAniTime, Action<object> act = null, object data = null)
    {
#if Cinemachine
		return fightCamCinemaCon.DoCameraAni(nOffsetX, fAniTime, fEndAniTime, act, data);
#elif CameraScheme1
		float animTime = fAniTime + fEndAniTime;
		Transform oCameraTransform = FightingCamera.gameObject.transform;
        Sequence seq = DOTween.Sequence();
        Vector3 vPos = oCameraTransform.localPosition;
        seq.Append(oCameraTransform.DOLocalMoveX(vPos.x + nOffsetX, fAniTime));
        seq.AppendInterval(fEndAniTime);
        seq.OnComplete(() => {
			act?.Invoke(data);
			oCameraTransform.DOLocalMoveX(0, fEndAniTime);
            });
		return animTime;
#elif CameraScheme2
		return 0;
#endif
	}

	/// <summary>
	/// 高斯模糊
	/// </summary>
	public void DoGaussianBlur(float fFate, float fAniTime)
    {
#if Cinemachine
		fightCamCinemaCon.DoGaussianBlur(fFate, fAniTime);
#elif CameraScheme1
        Tweener tween = DOTween.To(() => oGaussianBlur.fBlurSize, x => oGaussianBlur.fBlurSize = x, fFate, fAniTime);

#elif CameraScheme2
#endif
	}

	bool leftLimit;
    bool rightLimit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "RoomLeftLimit")
        {
            leftLimit = true;
            limit = transform.position.x;
        }
        else if (collision.tag == "RoomRightLimit")
        {
            rightLimit = true;
            limit = transform.position.x;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "RoomLeftLimit")
        {
            leftLimit = false;
        }
        else if (collision.tag == "RoomRightLimit")
        {
            rightLimit = false;
        }
    }

    // 检测背景是否能动，摄像机不动的时候背景也不能动
    public bool CheckRoadCanMove()
    {
        float x = LookAt.position.x;
        if (leftLimit)
        {
            //左限位,如果控制器输入的值比它小,停止移动
            if (x <= limit)
            {
                return false;
            }
        }

        if (rightLimit)
        {
            //右限位
            if (x >= limit)
            {
                return false;
            }
        }

        return true;
    }
	/// <summary>
	/// 地图左边向右偏移值
	/// </summary>
	float leftOffset = 0.7f;
	/// <summary>
	/// 地图右边向左偏移值
	/// </summary>
	float rightOffset = 0.5f;
	/// <summary>
	/// 每次进入地图前，更新Cinemachine 摄像头碰撞检测范围信息
	/// </summary>
	/// <param name="left"></param>
	/// <param name="right"></param>
	public void CheckUpdateCinemachineLimt(Vector3 left, Vector3 right)
	{
#if Cinemachine
		if (BoxCollider != null)
		{
			BoxCollider.center = (left + right) * 0.5f  + Vector3.right * ((leftOffset - rightOffset) * 0.5f);
			Vector3 offset = right - left;
			BoxCollider.size =  new Vector3(offset.x - leftOffset - rightOffset, 12.0f, 20.0f);
		}
#endif
	}

	/// <summary>
	/// 更新主摄像头的OrthographicSize
	/// </summary>
	/// <param name="orth"></param>
	public void UpdateMainCamOrth(float orth)
	{
#if Cinemachine
		fightCamCinemaCon.UpdateMainCamOrth(orth);
#else
		mainCamera.orthographicSize = _initMainOrthographicSize;
#endif
	}

	/// <summary>
	/// 重置主摄像头的OrthographicSize
	/// </summary>
	public void ResetMainCamOrth()
	{
#if Cinemachine
		fightCamCinemaCon.ResetMainCamOrth(_initMainOrthographicSize);
#else
		mainCamera.orthographicSize = _initMainOrthographicSize;
#endif
	}

}
