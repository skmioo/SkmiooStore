using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UYMO
{
    public static class U3DExtension
    {
        public static string ToCfgStr(this Vector3 vec)
        {
            return MathUtil.Vec3ToCfgStr(vec);
        }
        public static string ToCfgStr(this Vector2 vec)
        {
            return MathUtil.Vec2ToCfgStr(vec);
        }
        public static string ToCfgStr(this Quaternion val)
        {
            return MathUtil.QuaternionToCfgStr(val);
        }
        public static float DotProduct(this Vector2 val, Vector2 rhs)
        {
            return val.x * rhs.x + val.y * rhs.y;
        }

        public static Transform FindChildRecursively(this Transform trans, params string[] names)
        {
            return DoFindChildRecursively(trans, names);
        }
        /// <summary>
        /// 指定节点下查找对象
        /// </summary>
        /// <param name="trans"></param>
        /// <param name="path">指定节点的路径</param>
        /// <param name="names">查找的名称清单</param>
        /// <returns></returns>
        public static Transform FindChildRecursivelyQuick(this Transform trans, string path, params string[] names)
        {
            Transform pathRoot = trans.Find(path);
            return pathRoot == null ? null : DoFindChildRecursively(pathRoot, names);
        }
        static Transform DoFindChildRecursively(Transform trans, string[] names)
        {
            var count = trans.childCount;
            for (int i = 0; i < count; i++)
            {
                Transform child = trans.GetChild(i);
                if (names.IndexOf(child.name) != -1)
                {
                    return child;
                }
                else
                {
                    Transform ret = DoFindChildRecursively(child, names);
                    if (ret != null)
                    {
                        return ret;
                    }
                }
            }
            return null;
        }

        public delegate void delegateProcessComponent<T>(T obj) where T : Component;

        /// <summary>
        /// 递归处理所有符合类型的组件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="trans"></param>
        /// <param name="onProcessComponent"></param>
        public static void ProcessAllComponents<T>(this Transform trans, delegateProcessComponent<T> onProcessComponent) where T : Component
        {
            for (int n = 0; n < trans.childCount; n++)
            {
                var child = trans.GetChild(n);
                ProcessAllComponents(child, onProcessComponent);
            }
            T cpt = trans.GetComponent<T>();
            if (null != cpt)
            {
                onProcessComponent(cpt);
            }
        }


        public static void SetCull(this GameObject obj, bool cull, bool recursively)
        {
            if (recursively)
            {
                var tr = obj.transform;
                for (int i = 0; i < tr.childCount; ++i )
                {
                    tr.GetChild(i).gameObject.SetCull(cull, true);
                }
            }

            CanvasRenderer canvasRenderer = obj.GetComponent<CanvasRenderer>();
            if (canvasRenderer == null)
                return;
            canvasRenderer.cull = cull;
            Graphic graphic = obj.gameObject.GetComponent<Graphic>();
            if (graphic == null)
                return;
            if (!cull)
                graphic.SetAllDirty();
            if (graphic is YImage)
            {
                YImage img = graphic as YImage;
                img.cull = cull;
            }
        }
    }
}
