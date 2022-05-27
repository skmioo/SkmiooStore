using UnityEngine;

namespace UYMO
{
    /// <summary>
    /// 用于减弱粒子系统的Prewarm卡顿
    /// </summary>
    public class AntiPSPrewarm : MonoBehaviour
    {
        void OnBecameInvisible()
        {
            var ps = GetComponent<ParticleSystem>();
            if(null!=ps)
            {
                //Debug.LogFormat("Stop Particle System {0}", gameObject.name);
                ps.Stop();
            }
        }

        void OnBecameVisible()
        {
            var ps = GetComponent<ParticleSystem>();
            if(null!=ps)
            {
                //Debug.LogFormat("Play Particle System {0}", gameObject.name);
                ps.Play();
            }
        }
    }
}