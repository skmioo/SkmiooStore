using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;
using Datas;
using System.Linq;
using DG.Tweening;
using Spine.Unity;
using System;
using static BattleFlowController;

/// <summary>
/// 单个角色的控制器，这里面只写单个角色的行为控制
/// </summary>
public class RoleAnimationController : MonoBehaviour
{
    /// <summary>
    /// 动画状态机
    /// </summary>
    public Animator animator;

    /// <summary>
    /// 骨骼动画
    /// </summary>
    public SkeletonAnimation skeletonAnimation;

    /// <summary>
    /// 网格渲染，控制渲染层级
    /// </summary>
    public MeshRenderer meshRenderer;

    /// <summary>
    /// 骨骼动画对象
    /// </summary>
    public GameObject goRole;

    /// <summary>
    /// 攻击贴图对象
    /// </summary>
    public GameObject goAttacker;

    /// <summary>
    /// 被击贴图对象
    /// </summary>
    public GameObject goAttacked;

    /// <summary>
    /// 技能特效对象
    /// </summary>
    public GameObject goSkillEffect;

    /// <summary>
    /// 值显示引用
    /// </summary>
    public ValueShow hurtText;// 伤害
    public ValueShow cureText;// 治疗
    /// <summary>
    /// 暴击文字显示
    /// </summary>
    public ValueShow criticalText;
    /// <summary>
    /// 士气文字显示
    /// </summary>
    public ValueShow moraleText;
    public HeroSkillNote skillNote;
    /// <summary>
    /// 记录战斗前位置
    /// </summary>
    private Vector3 Ypos;

    /// <summary>
    /// 记录战斗前的缩放
    /// </summary>
    private Vector3 Yscale;

    /// <summary>
    /// 杀戮形态动画对象
    /// </summary>
    public GameObject goShalu;
    /// <summary>
    /// 头顶状态栏
    /// </summary>
    public RoleStates statesBar;
    /// <summary>
    /// 死亡的shader
    /// </summary>
    public Shader deathShader;
    /// <summary>
    /// buff伤害数字
    /// </summary>
    public Transform oDamageShow;
    /// <summary>
    /// 技能点
    /// </summary>
    public Transform skillPoint;

    public BloodExplosionEffect BloodExplosionEffcet;

    private float OffsetPos = 0.5f;
    private void Awake()
    {
        hurtText.Initialized(GetComponent<ObjLife>());
        cureText.Initialized(GetComponent<ObjLife>());
        criticalText.Initialized(GetComponent<ObjLife>());
        moraleText.Initialized(GetComponent<ObjLife>());
        skillNote.Initialized(GetComponent<ObjLife>());
        transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        oDamageShow = transform.Find("DamageShow");
    }
    /// <summary>
    /// 战斗开始，记录位置、放大人物
    /// </summary>
    /// <param name="time">动画时间</param>
    public void StartFighting(float time, float nTimeScale = 1)
    {
        Ypos = transform.localPosition;
        Yscale = transform.localScale;
        // transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), time);
        Sequence seq = DOTween.Sequence();
        float fAniTime2 = 0.1f * nTimeScale;
        float fAniTime1 = time - fAniTime2;
        seq.Append(transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), fAniTime1));
        seq.Append(transform.DOScale(new Vector3(0.8f, 0.8f, 0.8f), fAniTime2));

        var offset = transform.gameObject.GetComponentsInChildren<Offset>(true);

        foreach (var item in offset)
        {
            DOOffset(item, time);
        }
        // buff文字控制

        if (oDamageShow != null)
        {
            oDamageShow.transform.DOLocalMove(new Vector3(-1.5f, -2f, 0f), time);
            oDamageShow.transform.DOScale(new Vector3(0.8f, 0.8f, 0.8f), time);
            // oDamageShow.transform.localPosition = new Vector3(-1.5f, -2f, 0f);
            // oDamageShow.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        }
    }
    /// <summary>
    /// 受击目标战斗开始，记录位置、放大人物
    /// </summary>
    /// <param name="time">动画时间</param>
    public void TargetStartFighting(float time, float nTimeScale = 1)
    {
        Ypos = transform.localPosition;
        Yscale = transform.localScale;
        transform.DOScale(new Vector3(0.8f, 0.8f, 0.8f), time);

        var offset = transform.gameObject.GetComponentsInChildren<Offset>(true);

        foreach (var item in offset)
        {
            DOOffset(item, time);
        }

        // buff文字控制
        if (oDamageShow != null)
        {
            oDamageShow.transform.DOLocalMove(new Vector3(-1.5f, -2f, 0f), time);
            oDamageShow.transform.DOScale(new Vector3(0.8f, 0.8f, 0.8f), time);
            // oDamageShow.transform.localPosition = new Vector3(-1.5f, -2f, 0f);
            // oDamageShow.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        }
    }

    public void DOOffset(Offset offset, float time)
    {
        var seq = DOTween.Sequence();

        switch (offset)
        {
            case SetPosition setP:
                for (int i = 0; i < setP.offsets.Count; i++)
                {
                    seq.Append(setP.transform.DOLocalMove(setP.offsets[i].offset, setP.offsets[i].time).SetEase(setP.offsets[i].curv));
                }
                break;
        }
    }

    public void SkillNodeAni(float time)
    {
        skillNote.play(time);
    }
    /// <summary>
    /// 攻击前移动画
    /// </summary>
    /// <param name="time">动画时间</param>
    public void MoveForward(float time)
    {
        transform.DOLocalMoveX(0, time);
    }

    public void ShowReleaseSkillName(string name)
    {
        RoleInfoView.Instance.battleActNumInfo.goSkillInfo.ShowSkillName(name);
    }
    /// <summary>
    /// 显示任务顶部状态
    /// </summary>
    /// <param name="state"></param>
    public void SetTopState(string state, float delay = 0,int value =0,ObjLife obj =null)
    {
        statesBar.SetStates(state, delay,value, obj);
    }


    float deathTimer = 0;
    Material removeMat;
    float dispeartimer = 1;
    /// <summary>
    /// 死亡消失特效
    /// </summary>
    public void PlayDeathEffect()
    {
        var lastMat = goRole.GetComponent<Renderer>().sharedMaterial;
        removeMat = new Material(deathShader);
        removeMat.mainTexture = lastMat.mainTexture;
        goRole.GetComponent<Renderer>().sharedMaterial = removeMat;

        DOTween.To(() => deathTimer, x =>
        {
            deathTimer = x;
            removeMat.SetFloat("_Alpha", x);
        }, 1, 2);
    }
    /// <summary>
    /// 进门特效
    /// </summary>
    /// <param name="DoorPos 门的位置"></param>
    public bool EntryDoorAnim=false;
    public void PlayIndoorEffect(Vector3 DoorPos,float maxDistance)
    {
        EntryDoorAnim = true;

        Vector3 targetpos = new Vector3(DoorPos.x, transform.position.y+1, transform.position.z);//y+1
        transform.DOMove(targetpos, 3f);

        Vector3 scale = transform.localScale;
        transform.DOScale(scale * 0.7f, 3f).OnComplete(() =>
          {
              transform.localScale = scale;
          });

        var lastMat = goRole.GetComponent<Renderer>().sharedMaterial;

        DOTween.To(() => dispeartimer, x =>
        {
            if (DoorPos.x > transform.position.x)
            {
                animator.SetFloat("Speed", 1);
            }
            else
            {
                animator.SetFloat("Speed", 0.5f);
            }
            dispeartimer = x;
            float alpha = Mathf.Abs(targetpos.x - transform.position.x) / maxDistance;
            lastMat.SetColor("_Color", new Color(1, 1, 1, alpha));
        }, 0, 3f);


    }

    private float CaluateTargetDoorTime(Vector3 targetpos)
    {
        float speed = 1f;//
        float dis = Vector3.Distance(targetpos, transform.position);
        return dis / speed;
    }

    public void MoveForward(float target, float time)
    {
        // Sequence seq = DOTween.Sequence();
        //seq.Append(transform.DOLocalMoveY(YTest, time * 0.1f));
        // seq.Append(transform.DOLocalMoveX(target, time * 0.9f));


        //float y = transform.localPosition.y;
        //transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + BattleFlowController.Instance.YTest, transform.localPosition.z);
        //transform.DOLocalMove(new Vector3(target, y, transform.localPosition.z), time);
        transform.DOLocalMoveX(target, time);
    }
    public void MoveForward(float targetx, float targety, float time)
    {
        var life = GetComponent<ObjLife>();
        if (life.GetRoleType().Equals(RoleType.英雄))
        {
            transform.localPosition += OffsetPos * Vector3.right;
            transform.DOLocalMoveX(targetx + OffsetPos, time);
        }
        else
        {
            transform.localPosition -= OffsetPos * Vector3.right;
            transform.DOLocalMoveX(targetx - OffsetPos, time);
        }
        transform.DOLocalMoveY(targety, time);
    }
    /// <summary>
    /// 被击后移动画
    /// </summary>
    /// <param name="time">动画时间</param>
    /// <param name="type">角色类型</param>
    public void MoveBackward(float time, RoleType type)
    {
        if (type.Equals(RoleType.英雄))
        {
            transform.DOLocalMoveX(transform.localPosition.x - 0.5f, time);
        }
        else
        {

            transform.DOLocalMoveX(transform.localPosition.x + 0.5f, time);
        }
    }

    /// <summary>
    /// 显示被击效果
    /// </summary>
    /// <param name="effect">被击效果资源</param>
    /// <param name="time">效果存在时间</param>
    public void ShowEffect(float time, AssetReferenceGameObject effect)
    {
        effect.InstantiateAsync(transform).Completed += go =>
        {
            Transform[] transArray = go.Result.GetComponentsInChildren<Transform>();
            foreach (Transform trans in transArray)
            {
				trans.gameObject.layer = (int)Enum_Layer.FightingCamera;
            }
            Destroy(go.Result, time);
        };
    }

    /// <summary>
    /// 战斗结束，回到位置、缩小人物
    /// </summary>
    /// <param name="time">动画时间</param>
    public void EndFighting(float time)
    {
        transform.DOLocalMove(Ypos, time);
        transform.DOScale(Yscale, time);

        if (oDamageShow != null)
        {
            oDamageShow.transform.DOLocalMove(new Vector3(-1f, -3f, 0f), time);
            oDamageShow.transform.DOScale(new Vector3(1.0f, 1.0f, 1.0f), time);
            // oDamageShow.transform.localPosition = new Vector3(-1f, -3f, 0f);
            // oDamageShow.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }

    /// <summary>
    /// 换位移动动画
    /// </summary>
    /// <param name="time">动画时间</param>
    /// <param name="target">移动目标</param>
    public void ExchangePositionMove(float time, Vector3 target)
    {
        transform.DOLocalMove(target, time);
    }

    /// <summary>
    /// 显示spine动画，隐藏贴图
    /// </summary>
    public void UseGoRole()
    {
        AllActiveFalse();
        goRole.SetActive(true);
    }
    public void UseMoralSkill(AssetReferenceSprite ars)
    {
        AllActiveFalse();
    }
    /// <summary>
    /// 显示攻击贴图，隐藏spine动画和其他贴图
    /// </summary>
    public void UseGoAttack(AssetReferenceSprite ars)
    {
        AllActiveFalse();
        if (ars.SubObjectName != string.Empty)
        {
            ars.LoadAssetAsync().Completed += go =>
            {
                goAttacker.GetComponent<SpriteRenderer>().sprite = go.Result;
                goAttacker.SetActive(true);

            };
        }
        else
        {
            goAttacker.SetActive(true);
        }
    }


    /// <summary>
    /// 显示被击贴图，隐藏spine动画和其他贴图
    /// </summary>
    public void UseGoAttacked()
    {
        AllActiveFalse();
        goAttacked.SetActive(true);

        SpriteRenderer spr = goAttacked.GetComponent<SpriteRenderer>();
        if (spr != null)
        {
            spr.enabled = true;
        }

    }
    /// <summary>
    /// 显示血爆特效
    /// </summary>
    public void ShowBloodExplosionEffect(RoleType roleType)
    {
        switch (roleType)
        {

            case RoleType.怪物:
                BloodExplosionEffcet.TweenBloods();
                break;
            case RoleType.英雄:
                BloodExplosionEffcet.TweenBloods();
                break;
        }
    }
    public void ShowXuewu(RoleType roleType)
    {
        if (FullScreenBloodEffect.Instance)
            FullScreenBloodEffect.Instance.Show(roleType);
    }
    /// <summary>
    /// 显示技能特效
    /// </summary>
    /// <param name="ars"></param>
    /// <param name="time"></param>
    public void ShowSkillEffect(AssetReferenceSprite ars, float time, Vector3 offset)
    {
        if (ars.SubObjectName != string.Empty)
        {
            ars.LoadAssetAsync().Completed += go =>
            {
                goSkillEffect.GetComponent<SpriteRenderer>().sprite = go.Result;
                goSkillEffect.transform.localPosition += offset;
                goSkillEffect.SetActive(true);
                Transform[] transArray = goSkillEffect.GetComponentsInChildren<Transform>();
                foreach (Transform trans in transArray)
                {
					trans.gameObject.layer = (int)Enum_Layer.FightingCamera;
				}

                Invoke("HideSkillEffect", time);
            };
        }
    }

    /// <summary>
    /// 显示技能特效
    /// </summary>
    /// <param name="argo"></param>
    /// <param name="time"></param>
    public void ShowSkillEffect(AssetReferenceGameObject argo, float time, Vector3 offset, ObjLife source)
    {
        argo.InstantiateAsync(transform).Completed += go =>
        {
            Transform[] transArray = go.Result.GetComponentsInChildren<Transform>();
            foreach (Transform trans in transArray)
            {
                trans.gameObject.layer = (int)Enum_Layer.FightingCamera;
            }
            if (source == GetComponent<ObjLife>())
            {
                go.Result.transform.localPosition += offset;
            }
            else
            {
                go.Result.transform.localPosition += skillPoint.localPosition + offset;
            }
            Destroy(go.Result, time);
        };
    }

    /// <summary>
    /// 隐藏技能特效
    /// </summary>
    private void HideSkillEffect()
    {
        goSkillEffect.SetActive(false);
    }

    /// <summary>
    /// 更改渲染层级
    /// </summary>
    /// <param name="value">目标值</param>
    public void UpdateSortingOrder(int value)
    {
        if (meshRenderer != null)
        {
            meshRenderer.sortingOrder = value;
        }
        if (spriteRenderer != null)
        {
            spriteRenderer.sortingOrder = value;
        }


        //贴图动效使用spriteRenderer控制
        if (goAttacker != null)
        {
            goAttacker.GetComponent<SpriteRenderer>().sortingOrder = value;
        }
        if (goAttacked != null)
        {
            goAttacked.GetComponent<SpriteRenderer>().sortingOrder = value;
            BloodExplosionEffcet.SetSortOrder(value+1);
        }
    }

    /// <summary>
    /// 使用杀戮骨骼动画
    /// </summary>
    public void UseShalu()
    {
        if (goShalu != null)
        {
            AllActiveFalse();
            goShalu.SetActive(true);
        }
    }
    //bool isDestory = false;
    //private void OnDestroy()
    //{
    //    isDestory = true;
    //}
    /// <summary>
    /// 隐藏角色所有动画和贴图
    /// </summary>
    private void AllActiveFalse()
    {
        //if (isDestory) return;
        goRole.SetActive(false);
        goAttacker.SetActive(false);
        // goAttacked.SetActive(false); //xiugai

        SpriteRenderer spr = goAttacked.GetComponent<SpriteRenderer>();
        if (spr != null)
        {
            spr.enabled = false;
        }

        if (goAttacked.activeInHierarchy)
        {
            BloodExplosionEffect bloodExplosion= goAttacked.GetComponentInChildren<BloodExplosionEffect>();
            if (bloodExplosion == null)
            {
                goAttacked.SetActive(false);
            }
            else
            {
                bloodExplosion.WaitFadeOver(() =>
               {
                   goAttacked.SetActive(false);
               });
            }
        }
        else
        {
            goAttacked.SetActive(false);
        }

        if (goShalu != null)
        {
            goShalu.SetActive(false);
        }
    }
    /// <summary>
    /// 显示伤害/治疗值
    /// </summary>
    /// <param name="value"></param>
    public void ShowValue(int value, float delay, bool IsCrits, string hexString = "#FFFFFF")
    {
        if (value > 0)
        {
            cureText.ShowStart(value, delay, hexString);//治疗
        }
        else if (IsCrits)
        {
            criticalText.ShowStart(value, delay, hexString);//暴击
        }
        else
        {
            hurtText.ShowStart(-value, delay, hexString);//伤害
        }
    }

    public void ShowMoraleValue(int value, float delay)
    {
        moraleText.ShowStart(value, delay);
    }

    public void ShowValue(string str)
    {
        criticalText.ShowStart(str);
    }

    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = transform.Find("Role")?.GetComponent<SpriteRenderer>();
    }


    #region Spine动画控制部分

    readonly int hashIdle = Animator.StringToHash("Idle");
    readonly int hashWalk = Animator.StringToHash("Walk");
    readonly int hashFight = Animator.StringToHash("Fight");
    readonly int hashAttack = Animator.StringToHash("Attack");
    readonly int hashDamage = Animator.StringToHash("Damage");

    //主控状态机依然是Animator ,当改变Animator的状态时,会自动改变Spine播放的动画
    private void FixedUpdate()
    {
         if(!EntryDoorAnim)//如果没有播放进门动画
        {
            animator.SetFloat("Speed", Mathf.Abs(MoveTeam.moveX));

        }
        CheckAnimatorInSpine();
    }

    int nowHashNumber = -1;
    static int curPlayingAudioId = int.MinValue;
    //string _clipName = "";
    //切换Spine中的动画--动画器独立为状态机
    void CheckAnimatorInSpine()
    {
        if (animator.GetCurrentAnimatorClipInfo(0).Length.Equals(0))
        {
            return;
        }

        //有些怪物,或者还没有做动画的角色
        if (skeletonAnimation == null)
            return;

        string nowClipName = animator.GetCurrentAnimatorClipInfo(0)[0].clip.name;

        int hashNumber = animator.GetCurrentAnimatorStateInfo(0).shortNameHash;

        //if (_clipName == nowClipName).
        if (hashNumber == nowHashNumber)
            return;
        //单次开关--只有nowClipName改变时才会执行一次
        //_clipName = nowClipName;
        nowHashNumber = hashNumber;
        skeletonAnimation.timeScale = 1f;
        skeletonAnimation.loop = true;

        if (hashNumber == hashIdle)
        {
            skeletonAnimation.AnimationName = "stand";
            if (curPlayingAudioId != int.MinValue)
            {
                AudioManager.Instance.StopAudio(curPlayingAudioId);
                curPlayingAudioId = int.MinValue;
            }
        }
        else if (hashNumber == hashWalk)
        {
            skeletonAnimation.AnimationName = "walk";
            if (curPlayingAudioId != int.MinValue) return;
            if (MoveTeam.moveX < 0) curPlayingAudioId = AudioManager.Instance.PlayAudio(AudioName.FOOTSTEP_Trainers_Gravel_Compact_Walk_Slow_RR8_mono, AudioType.BattleCommon, true, 100);
            else if (MoveTeam.moveX > 0) curPlayingAudioId = AudioManager.Instance.PlayAudio(AudioName.FOOTSTEP_Asphalt_Trainers_Walk_Slow_RR7_mono, AudioType.BattleCommon, true, 100);

        }
        else if (hashNumber == hashFight)
        {

        }
        else if (hashNumber == hashAttack)
        {

        }
        else if (hashNumber == hashDamage)
        {

        }
        else if (hashNumber == hashWalk)
        {

        }


        //改用状态名称判断
        //switch (nowClipName)
        //{
        //    case "Status_Idle":
        //        skeletonAnimation.AnimationName = "stand";
        //        break;
        //    case "Status_Walk":
        //        //skeletonAnimation.state.SetAnimation(0, "walk", false);
        //        skeletonAnimation.AnimationName = "walk";
        //        break;
        //    case "Status_Fight":
        //        break;
        //    case "Status_Attack":
        //        break;
        //    case "Status_Dameg":
        //        break;
        //    default:
        //        break;
        //}
    }
    #endregion
}

