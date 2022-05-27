using UnityEngine;
using System.Collections;

namespace UYMO
{
    public class DUIRayIgnore : MonoBehaviour, ICanvasRaycastFilter
    {
        public bool IsRaycastLocationValid(Vector2 screenPoint,Camera eventCamera)
        {
            return false;
        }
    }
}
