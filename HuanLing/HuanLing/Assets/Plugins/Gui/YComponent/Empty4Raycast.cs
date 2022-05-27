using UnityEngine;
using System.Collections;

namespace UnityEngine.UI
{
    public class Empty4Raycast : YMaskableGraphic
    {
        protected Empty4Raycast()
        {
            useLegacyMeshGeneration = false;
        }

        protected override void OnPopulateMesh(VertexHelper toFill)
        {
            toFill.Clear();
        }
    }
}