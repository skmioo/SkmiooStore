using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UYMO
{
    class PrefabLightmapData : MonoBehaviour
    {
        //LightMap 信息
        [System.Serializable]
        public struct RendererInfo
        {
            public Renderer renderer;
            public int lightmapIndex;
            public Vector4 lightmapOffsetScale;
        }

        public List<RendererInfo> m_RendererInfo;
        public LightmapsMode lightmapsMode;
       
        /// <summary>
        /// 设置光照数据
        /// </summary>
        public void SetUpLightmap()
        {
            if (m_RendererInfo.Count <= 0) return;

            for (int idx = 0; idx < m_RendererInfo.Count; idx++)
            {
                RendererInfo item = m_RendererInfo[idx];
                item.renderer.lightmapIndex = item.lightmapIndex;
                item.renderer.lightmapScaleOffset = item.lightmapOffsetScale;
            }
        }


        /// <summary>
        /// 保存lightmap数据
        /// </summary>
        [ContextMenu("SaveLightmap")]
        public void SaveLightmap()
        {
            SaveLightmapData();
        }


        /// <summary>
        /// 保存lightmap信息
        /// </summary>
        private void SaveLightmapData()
        {
            List<Texture2D> lightmapNear = new List<Texture2D>();
            List<Texture2D> lightmapFar = new List<Texture2D>();
            LightmapData[] lightmaps = LightmapSettings.lightmaps;

            for (int idx = 0; idx < lightmaps.Length; idx++)
            {
                LightmapData data = lightmaps[idx];
                if(data.lightmapDir!=null)
                {
                    lightmapNear.Add(data.lightmapDir);
                }

                if(data.lightmapColor !=null)
                {
                    lightmapFar.Add(data.lightmapColor);
                }
            }

            m_RendererInfo = new List<RendererInfo>();
            var renderers = UIUtil.GetMeshRendererListInChildren(gameObject, false);
            for(int idx =0; idx < renderers.Count; idx++)
            {
                MeshRenderer renderer = renderers[idx];
                if (!renderer.gameObject.isStatic && renderer.lightmapIndex != -1)
                {
                    RendererInfo info = new RendererInfo();
                    info.renderer = renderer;
                    info.lightmapOffsetScale = renderer.lightmapScaleOffset;
                    info.lightmapIndex = renderer.lightmapIndex;
                    m_RendererInfo.Add(info);
                }
            }
            ObjectPool.meshRendererListPool.Gabage(renderers);

            lightmapsMode = LightmapSettings.lightmapsMode;
        }
    }
}
