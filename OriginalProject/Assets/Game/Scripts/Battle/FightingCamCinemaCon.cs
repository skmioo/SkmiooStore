using Cinemachine;
using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public enum CamCinemaType
{
	MainCam,
	FightingCam,
}

/// <summary>
/// 通过Cinemachine来控制战斗摄像头
/// </summary>
public class FightingCamCinemaCon : MonoBehaviour
{
	public Camera brainCamera;
	CinemachineBrain cameraCineBrain;
	public Camera fightingActorCamera;
	public CinemachineVirtualCamera cinMainCam;
	public CinemachineVirtualCamera cinFightCam;
	public GaussianBlur oGaussianBlur;
	int mainCamCullingMask;
	Color mainCamBg;
	int fightingCamCullingMask;
	Color fightingCamBg;
	//退出战斗回到主摄像头的动画时间
	private const float exitFightToMainCamTime = 0.5f;
	bool showbrainCameraDebugText = false;
	//是否立即跟随；
	bool isFollowImmediately = true;
	//值越小跟随速度越快
	float cameraFollowSpeed = 1.0f;
	private void Awake()
	{
		cameraCineBrain = brainCamera.GetComponent<CinemachineBrain>();
		cameraCineBrain.m_ShowDebugText = showbrainCameraDebugText;
		//设置相机跟随速度
		setCameraFollowSpeed(isFollowImmediately ? 0 : cameraFollowSpeed);
	}

	/// <summary>
	/// 值越小，跟随速度越快
	/// </summary>
	internal void setCameraFollowSpeed(float speed)
	{
		CinemachineTransposer transposer = cinMainCam.GetCinemachineComponent<CinemachineTransposer>();
		transposer.m_YDamping = transposer.m_XDamping = speed;
	}

	/// <summary>
	/// 初始化切镜的CullingMask
	/// </summary>
	/// <param name="scheme1"></param>
	internal void InitCameraCullingMask(Transform scheme1)
	{
		Camera mainCamera = scheme1.Find("Camera").GetComponent<Camera>();
		Camera fightCamera = scheme1.Find("FightingCamera").GetComponent<Camera>();
		mainCamCullingMask = mainCamera.cullingMask;
		mainCamBg = mainCamera.backgroundColor;
		fightingCamCullingMask = fightCamera.cullingMask;
		fightingCamBg = fightCamera.backgroundColor;
	}

	/// <summary>
	/// 选中使用的摄像头
	/// </summary>
	/// <param name="camCinemaType"></param>
	public void ChooseCineCam(CamCinemaType camCinemaType, float blendCamTime)
	{
		switch (camCinemaType)
		{
			case CamCinemaType.MainCam:
				cinMainCam.Priority = 10;
				cinFightCam.Priority = 5;
				brainCamera.cullingMask = mainCamCullingMask;
				brainCamera.backgroundColor = mainCamBg;
				brainCamera.depth = 0;
				fightingActorCamera.enabled = false;
				oGaussianBlur.enabled = false;
				break;
			case CamCinemaType.FightingCam:
				cinMainCam.Priority = 5;
				cinFightCam.Priority = 10;
				brainCamera.cullingMask = fightingCamCullingMask;
				brainCamera.backgroundColor = fightingCamBg;
				brainCamera.depth = -1;
				fightingActorCamera.enabled = true;
				oGaussianBlur.fBlurSize = 0;
				oGaussianBlur.enabled = true;
				break;
			default:
				break;
		}
		if (cameraCineBrain)
		{
			if (blendCamTime < 0.01f)
			{
				cameraCineBrain.m_DefaultBlend.m_Style = CinemachineBlendDefinition.Style.Cut;
			}
			else {
				cameraCineBrain.m_DefaultBlend.m_Style = CinemachineBlendDefinition.Style.EaseInOut;
				cameraCineBrain.m_DefaultBlend.m_Time = blendCamTime;
			}
		}
	}
	Vector3 mainCamPos;
	/// <summary>
	/// 进入战斗--战斗中
	/// </summary>
	public void Fighting(float fAniTime, float orthSize)
	{
		mainCamPos = brainCamera.transform.position;
		ChooseCineCam(CamCinemaType.FightingCam, 0);
		Tweener tween = DOTween.To(() => cinFightCam.m_Lens.OrthographicSize, x =>  cinFightCam.m_Lens.OrthographicSize = x, orthSize, fAniTime);
		Tweener tween2 = DOTween.To(() => fightingActorCamera.orthographicSize, x => fightingActorCamera.orthographicSize = x, orthSize, fAniTime);
		DoGaussianBlur(0.8f, fAniTime);
	}


	/// <summary>
	/// 退出战斗
	/// </summary>
	public void ExitFight(float fAniTime, float orthSize)
	{
		Tweener tween = DOTween.To(() => cinFightCam.m_Lens.OrthographicSize, x => cinFightCam.m_Lens.OrthographicSize = x, orthSize, fAniTime);
		Tweener tween2 = DOTween.To(() => fightingActorCamera.orthographicSize, x => fightingActorCamera.orthographicSize = x, orthSize, fAniTime);
		DoGaussianBlur(0, fAniTime);
		tween.OnComplete(() =>
		{
			ChooseCineCam(CamCinemaType.MainCam, exitFightToMainCamTime);
		});
	}
	bool isInShake = false;
	/// <summary>
	/// 战斗摄像机震动
	/// </summary>
	/// <returns>动画执行时间</returns>
	public float DoShake(float nTimeScale, Action<object> act = null, object data = null)
	{
		CinemachineTransposer transposer = cinFightCam.GetCinemachineComponent<CinemachineTransposer>();
		Vector3 vPos = transposer.m_FollowOffset;
		float animTime = 0;
		isInShake = true;
		Sequence seq = DOTween.Sequence();
		float fAniTime = 0.15f * nTimeScale;
		float fAniTime2 = 0.1f * nTimeScale;
		float screenYRatio = 0.1f;
		seq.Append(moveCineCamY(transposer, vPos.y + 0.1f * screenYRatio, fAniTime));
		seq.Append(moveCineCamY(transposer, vPos.y - 0.2f * screenYRatio, fAniTime));
		seq.Append(moveCineCamY(transposer, vPos.y + 0.15f * screenYRatio, fAniTime));
		seq.Append(moveCineCamY(transposer, vPos.y - 0.10f * screenYRatio, fAniTime2));
		seq.Append(moveCineCamY(transposer, vPos.y + 0.10f * screenYRatio, fAniTime2));
		seq.Append(moveCineCamY(transposer, vPos.y - 0.05f * screenYRatio, fAniTime2));
		seq.Append(moveCineCamY(transposer, vPos.y + 0.05f * screenYRatio, fAniTime2));
		seq.Append(moveCineCamY(transposer, vPos.y - 0.03f * screenYRatio, fAniTime2));
		seq.Append(moveCineCamY(transposer, vPos.y, fAniTime2));

		seq.OnComplete(() =>
		{
			act?.Invoke(data);
			transposer.m_FollowOffset = vPos;
			isInShake = false;
		});
		animTime = fAniTime * 3 + fAniTime2 * 6;
		return animTime;
	}

	private Tween moveCineCamY(CinemachineTransposer transposer, float targetY, float time)
	{
		return DOTween.To(() => transposer.m_FollowOffset.y, y => transposer.m_FollowOffset.y = y, targetY, time);
	}

	/// <summary>
	/// 战斗摄像机偏移
	/// </summary>
	/// <returns>动画执行时间</returns>
	public float DoCameraAni(float nOffsetX, float fAniTime, float fEndAniTime, Action<object> act = null, object data = null)
	{
		float animTime = fAniTime + fEndAniTime;
		Transform oCameraTransform = cinFightCam.gameObject.transform;
		Sequence seq = DOTween.Sequence();
		Vector3 vPos = oCameraTransform.localPosition;
		seq.Append(oCameraTransform.DOLocalMoveX(vPos.x + nOffsetX, fAniTime));
		seq.AppendInterval(fEndAniTime);
		seq.OnComplete(() =>
		{
			act?.Invoke(data);
			oCameraTransform.DOLocalMoveX(0, fEndAniTime);
		});
		return animTime;
	}
	/// <summary>
	/// 高斯模糊
	/// </summary>
	public void DoGaussianBlur(float fFate, float fAniTime)
	{
		Tweener tween = DOTween.To(() => oGaussianBlur.fBlurSize, x => oGaussianBlur.fBlurSize = x, fFate, fAniTime);

	}


	/// <summary>
	/// 更新主摄像头的OrthographicSize
	/// </summary>
	/// <param name="orth"></param>
	internal void UpdateMainCamOrth(float orth)
	{
		cinMainCam.m_Lens.OrthographicSize = orth;
	}

	/// <summary>
	/// 重置主摄像头的OrthographicSize
	/// </summary>
	internal void ResetMainCamOrth(float orthographicSize)
	{
		cinMainCam.m_Lens.OrthographicSize = orthographicSize;
	}


}

