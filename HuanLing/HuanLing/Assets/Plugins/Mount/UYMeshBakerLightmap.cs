using UnityEngine;
using System.Collections.Generic;

namespace UYMO
{
    public class UYMeshBakerLightmap : MonoBehaviour
    {
        /// <summary>
        /// mesh baker 后的网格lightmap信息
        /// </summary>
        [System.Serializable]
        public struct BakerRenderLMInfo
        {
            public Renderer renderer;
            public int lightmapIndex;
            public Vector4 lightmapOffsetScale;
        }

        /// <summary>
        /// 网格LM信息
        /// </summary>
        public List<BakerRenderLMInfo> rendererLMInfo;

        public void SetUpLightmap()
        {
            if (rendererLMInfo == null || rendererLMInfo.Count <= 0)
                return;

            for (int idx = 0; idx < rendererLMInfo.Count; idx++)
            {
                BakerRenderLMInfo item = rendererLMInfo[idx];
                if(item.renderer !=null)
                {
                    item.renderer.lightmapIndex = item.lightmapIndex;
                    item.renderer.lightmapScaleOffset = item.lightmapOffsetScale;
                }
                
            }
        }

        [ContextMenu("SaveLightmap")]
        public void SaveLightmap()
        {
            List<Texture2D> lightmapNear = new List<Texture2D>();
            List<Texture2D> lightmapFar = new List<Texture2D>();
            LightmapData[] lightmaps = LightmapSettings.lightmaps;

            for (int idx = 0; idx < lightmaps.Length; idx++)
            {
                LightmapData data = lightmaps[idx];
                if (data.lightmapDir != null)
                {
                    lightmapNear.Add(data.lightmapDir);
                }

                if (data.lightmapColor != null)
                {
                    lightmapFar.Add(data.lightmapColor);
                }
            }

            rendererLMInfo = new List<BakerRenderLMInfo>();
            var renderers = UIUtil.GetMeshRendererListInChildren(gameObject, false);
            for (int idx = 0; idx < renderers.Count; idx++)
            {
                MeshRenderer renderer = renderers[idx];
                if (renderer.lightmapIndex != -1)
                {
                    BakerRenderLMInfo info = new BakerRenderLMInfo();
                    info.renderer = renderer;
                    info.lightmapOffsetScale = renderer.lightmapScaleOffset;
                    info.lightmapIndex = renderer.lightmapIndex;
                    rendererLMInfo.Add(info);
                }
            }
            ObjectPool.meshRendererListPool.Gabage(renderers);
        }
    }
}
