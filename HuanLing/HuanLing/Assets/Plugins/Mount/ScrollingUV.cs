using UnityEngine;
using System.Collections;

namespace UYMO
{
    public class ScrollingUV : MonoBehaviour
    {
        public float m_SpeedU = 0.1f;
        public float m_SpeedV = -0.1f;

        // Update is called once per frame  
        void Update()
        {
            Renderer renderer = GetComponentInChildren<Renderer>();

            float newOffsetU = Time.time * m_SpeedU;
            float newOffsetV = Time.time * m_SpeedV;

            if (renderer && renderer.material)
            {
                renderer.material.mainTextureOffset = new Vector2(newOffsetU, newOffsetV);
            }
        }  
    }
}
