using UnityEngine;

namespace UYMO
{
    public class UIParticleScaler : MonoBehaviour
    {
        public Vector3 scale;
        void OnWillRenderObject()
        {
            var renderer = GetComponent<Renderer>();
            renderer.material.SetVector("_Position", Camera.current.worldToCameraMatrix.MultiplyPoint(transform.position));
            renderer.material.SetVector("_Scale", scale);
        }
    }
}