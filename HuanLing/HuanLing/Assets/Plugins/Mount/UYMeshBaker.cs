using UnityEngine;
using System;
using System.Collections.Generic;

namespace UYMO
{
    public class UYMeshBaker : MonoBehaviour
    {
        [System.Serializable]
        public struct BakerPrefabInfo
        {
            /// <summary>
            /// 位置
            /// </summary>
            public Vector3 pos;

            /// <summary>
            /// 旋转数值
            /// </summary>
            public Quaternion rot;

            /// <summary>
            /// 缩放比例
            /// </summary>
            public Vector3 scale;

            /// <summary>
            /// 路径
            /// </summary>
            public string path;

            /// <summary>
            /// 资源ID
            /// </summary>

            public ResID resID;

            public BakerPrefabInfo(Vector3 p,Quaternion r,Vector3 s)
            {
                pos = p;
                rot = r;
                scale = s;
                path = "";
                resID = ResID.zero;
            }
        }

        /// <summary>
        /// 原始资源信息
        /// </summary>
        public BakerPrefabInfo orgMeshAssetInfo;

        /// <summary>
        /// mesh baker之后的资源信息
        /// </summary>
        public BakerPrefabInfo bakerMeshAssetInfo;


        /// <summary>
        /// 资源编号
        /// </summary>
        public int resOrder;

        /// <summary>
        /// 是否已经加载
        /// </summary>
        [System.NonSerialized]
        public bool loaded = false;
    }
}
