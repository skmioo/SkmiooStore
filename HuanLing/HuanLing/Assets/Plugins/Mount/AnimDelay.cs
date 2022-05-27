using UnityEngine;

namespace UYMO
{
    /// <summary>
    /// 动画延迟脚本
    /// </summary>
    public class AnimDelay : MonoBehaviour
    {
        public float delayTime = 0.0f;
        public string actorName = "";
        public bool playOnStart = true;

        private Animator _Animator;
        void Awake()
        {
            _Animator = gameObject.GetComponent<Animator>();
        }
        // Use this for initialization
        void Start()
        {
            if (playOnStart)
                ResetDelayTime(delayTime);
        }
        /// <summary>
        /// 重置延迟时间
        /// </summary>
        /// <param name="dtime">延迟时间，秒</param>
        public void ResetDelayTime(float dtime)
        {
            CancelInvoke("DelayFunc");
            delayTime = dtime;
            if (delayTime <= 0.0f)
            {//马上开始，不用延迟
                PlayAnim();
            }
            else
            {//延迟一会儿
                StopAnim();
                Invoke("DelayFunc", delayTime);
            }
        }
        public void ResetToTPos()
        {
            if (_Animator != null)
            {
                if (!string.IsNullOrEmpty(actorName))
                {
                    _Animator.enabled = true;
                    _Animator.speed = 0.0f;
                    _Animator.Play(Animator.StringToHash(actorName), -1, 0.0f);
                }
            }
        }

        void DelayFunc()
        {
            PlayAnim();
        }
        public void PlayAnim()
        {
            if (_Animator == null)
                return;
            _Animator.enabled = true;
            _Animator.speed = 1.0f;
            if (!string.IsNullOrEmpty(actorName))
            {
                _Animator.Play(Animator.StringToHash(actorName), -1, 0.0f);
            }
        }
        public void StopAnim()
        {
            if (_Animator != null)
            {
                _Animator.enabled = false;
            }
        }
    }
}
