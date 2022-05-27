using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using SLua;
namespace UYMO
{
    /// <summary>
    /// U3D的辅助工具类
    /// </summary>
    [CustomLuaClassAttribute]
    public class U3DUtil
    {
        /// <summary>
        /// 设置某物件的层级（包括其所有的子）
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="layer">层级 LayerIndex</param>
        public static void SetLayer(GameObject obj, int layer)
        {
            for (int idx = 0; idx < obj.transform.childCount; idx++)
            {
                Transform child = obj.transform.GetChild(idx);
                SetLayer(child.gameObject, layer);
            }
            obj.layer = layer;
        }

        /// <summary>
        /// 获取子对象
        /// </summary>
        /// <param name="parent">父对象</param>
        /// <param name="name">子对象名称</param>
        /// <param name="recursive">是否递归遍历</param>
        /// <returns>第一个为name的子对象，没有就返回null</returns>
        public static GameObject GetChildByName(GameObject parent, string name, bool recursive)
        {
            if (string.IsNullOrEmpty(name))
                return parent;
            int count = parent.transform.childCount;
            for (int i = 0; i < count; ++i)
            {
                GameObject obj = parent.transform.GetChild(i).gameObject;
                if (obj.name == name)
                    return obj;
            }
            if (recursive)
            {
                for (int i = 0; i < count; ++i)
                {
                    GameObject cur = parent.transform.GetChild(i).gameObject;
                    GameObject obj = GetChildByName(cur, name, true);
                    if (obj)
                        return obj;
                }
            }
            return null;
        }

        public static GameObject GetChildByPath(GameObject parent,string path)
        {
            Transform ret = parent.transform.Find(path);
            return ret == null ? GetChildByName(parent, path, true) : ret.gameObject;
        }

        public static Component GetChildComponent(GameObject parent, string name, bool recursive, string comName )
        {
            GameObject child = GetChildByName(parent, name, recursive);
            return child == null ? null : child.GetComponent(comName);
        }

        /// <summary>
        /// 移除全部的子对象，但不删除
        /// </summary>
        /// <param name="parent"></param>
        public static void RemoveAllChildGameObject(GameObject parent)
        {
            var objList = ObjectPool.goListPool.Create();
            int count = parent.transform.childCount;
            for (int i = 0; i < count; ++i)
            {
                GameObject obj = parent.transform.GetChild(i).gameObject;
                objList.Add(obj);
            }
            for (int i = 0; i < objList.Count; ++i)
            {
                objList[i].transform.SetParent(null);
            }
            ObjectPool.goListPool.Gabage(objList);
        }
        /// <summary>
        /// 删除给定范围的所有子元素
        /// </summary>
        /// <param name="parent">父节点</param>
        /// <param name="startIndx">开始索引</param>
        /// <param name="count">数量</param>
        public static void DeleteAllChildGameObject(GameObject parent, int startIndx =0, int count =-1)
        {
            int cc = parent.transform.childCount;
            if (cc == 0)
                return;
            if (startIndx < 0 || startIndx >= cc)
                return;
            if (count < 0)
                count = cc;
            count = Mathf.Min(count, cc - startIndx);
            var objList = ObjectPool.goListPool.Create();
            for (int i = startIndx; i < count +startIndx; ++i)
            {
                GameObject obj = parent.transform.GetChild(i).gameObject;
                objList.Add(obj);
            }
            for (int i =0; i<objList.Count; ++i)
            {
                DestroyGameObject(objList[i]);
            }
            ObjectPool.goListPool.Gabage(objList);
        }
        /// <summary>
        /// 判断节点中 祖先-后裔的关系
        /// </summary>
        /// <param name="ancestor">祖先</param>
        /// <param name="child">后裔</param>
        /// <returns>如果是祖先后裔关系返回true</returns>
        public static bool IsAncestorOf(GameObject ancestor, GameObject child)
        {
            if (child == null || ancestor == null)
                return false;
            Transform cur = child.transform;
            while (cur.gameObject != ancestor)
            {
                cur = cur.parent;
                if (cur == null)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 初始化EventTrigger Entry
        /// </summary>
        /// <param name="entry">Entry对象</param>
        /// <param name="type">Event Type</param>
        /// <param name="call">CallBack 回调函数</param>
        public static void InitEventCallback(EventTrigger.Entry entry, EventTriggerType type, UnityAction<BaseEventData> call)
        {
            entry.eventID = type;
            entry.callback = new EventTrigger.TriggerEvent();
            entry.callback.AddListener(call);
        }

        /// <summary>
        /// 删除一个给定物件（代码里尽量调用此函数，不要直接调用Object.Destroy）
        /// </summary>
        /// <typeparam name="T">一个UnityEngine.Object的类型</typeparam>
        /// <param name="obj">待删除的物件，可以传null</param>
        /// <returns>null</returns>
        public static T DestroyObject<T>(T obj) where T : UnityEngine.Object
        {
            if (obj == null)
                return null;
#if UNITY_EDITOR
            //unity 下
            if (Application.isPlaying)
            {//运行状态下
                UnityEngine.Object.Destroy(obj);
            }
            else
            {//编辑器状态下
                UnityEngine.Object.DestroyImmediate(obj);
            }
#else
            //发布情况下
            GameObject.Destroy(obj);
#endif
            return null;
        }
        /// <summary>
        /// 删除给定tag的所有对象
        /// </summary>
        /// <param name="tag"></param>
        [DoNotToLua]
        public static bool DestroyAllGameObjectsByTag(string tag)
        {
            bool changed = false;
            var objs = GameObject.FindGameObjectsWithTag(tag);
            foreach (var obj in objs)
            {
                changed = true;
                DestroyGameObject(obj);
            }
            return changed;
        }
        /// <summary>
        /// 删除一个给定物件（代码里尽量调用此函数，不要直接调用GameObject.Destroy）
        /// </summary>
        /// <param name="obj">待删除的物件，可以传null</param>
        /// <returns>null</returns>
        [DoNotToLua]
        public static GameObject DestroyGameObject(GameObject obj)
        {
            if (obj == null)
                return null;
#if UNITY_EDITOR
            //unity 下
            if (Application.isPlaying)
            {//运行状态下
                GameObject.Destroy(obj);
            }
            else
            {//编辑器状态下
                GameObject.DestroyImmediate(obj);
            }
#else
            //发布情况下
            GameObject.Destroy(obj);
#endif
            return null;
        }

        public static void DriveAnimation(GameObject obj, bool recursively, float deltaTime)
        {
            if (obj == null)
                return;
            Animator anim = obj.GetComponent<Animator>();
            if (anim != null)
            {
                anim.Update(deltaTime);
            }
            if (recursively)
            {
                for (int i = 0; i < obj.transform.childCount; ++i)
                {
                    DriveAnimation(obj.transform.GetChild(i).gameObject, recursively, deltaTime);
                }
            }
        }
        /// <summary>
        /// 从当前给定的对象或者它的先祖对象中获取某个组件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">当前对象</param>
        /// <returns>组件，没有就返回null</returns>
        public static T GetComponentFromAncestor<T>(GameObject obj) where T : MonoBehaviour
        {
            GameObject cur = obj;
            while (cur != null)
            {
                T t = cur.GetComponent<T>();
                if (t != null)
                    return t;
                if (cur.transform.parent == null)
                    return null;
                cur = cur.transform.parent.gameObject;
            }
            return null;
        }
        /// <summary>
        /// 获取某个组件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">物件, null表示全局搜索</param>
        /// <param name="recursively">是否递归查找</param>
        /// <returns></returns>
        public static T GetComponent<T>(GameObject obj =null, bool recursively =true) where T : Component
        {
            T com = null;
            if (obj == null)
            {
                if (recursively == false)
                    return null;
                GameObject[] objs = GameObject.FindObjectsOfType<GameObject>();
                for (int idx =0; idx < objs.Length; idx++)
                {
                    var o = objs[idx];
                    com = o.GetComponent<T>();
                    if (com != null)
                        return com;
                }
                return null;
            }
            com = obj.GetComponent<T>();
            if (com != null)
                return com;
            if (!recursively)
            {
                return null;
            }
            for (int i=0; i<obj.transform.childCount; ++i)
            {
                com = GetComponent<T>(obj.transform.GetChild(i).gameObject, recursively);
                if (com != null)
                    return com;
            }
            return null;
        }
        /// <summary>
        /// 获取某个组件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">物件, null表示全局搜索</param>
        /// <param name="targetObj">组件所属的obj</param>
        /// <param name="recursively">是否递归查找</param>
        /// <returns></returns>
        public static T GetComponent<T>(GameObject obj, out GameObject targetObj, bool recursively) where T : Component
        {
            targetObj = null;
            T com = null;
            if (obj == null)
            {
                if (recursively == false)
                    return null;
                GameObject[] objs = GameObject.FindObjectsOfType<GameObject>();
                for (int idx =0; idx < objs.Length; idx++)
                {
                    var o = objs[idx];
                    com = o.GetComponent<T>();
                    if (com != null)
                    {
                        targetObj = o;
                        return com;
                    }
                }
                return null;
            }
            com = obj.GetComponent<T>();
            if (com != null)
            {
                targetObj = obj;
                return com;
            }
            if (!recursively)
            {
                return null;
            }
            for (int i=0; i<obj.transform.childCount; ++i)
            {
                com = GetComponent<T>(obj.transform.GetChild(i).gameObject, out targetObj, recursively);
                if (com != null)
                    return com;
            }
            return null;
        }
        /// <summary>
        /// 从给定的obj的子节点中寻找tag
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        public static GameObject FindChildWithTag(GameObject parent, string tag)
        {
            for (int i=0; i<parent.transform.childCount; ++i)
            {
                Transform child = parent.transform.GetChild(i);
                if (child.gameObject.CompareTag(tag))
                    return child.gameObject;
                GameObject obj = FindChildWithTag(child.gameObject, tag);
                if (obj != null)
                    return obj;
            }
            return null;
        }
        public static IEnumerable<GameObject> TraverseChildren(GameObject parent, bool recursive)
        {
            for (int i=0; i<parent.transform.childCount; ++i)
            {
                GameObject child = parent.transform.GetChild(i).gameObject;
                yield return child;
                if (recursive)
                {
                    foreach(var cc in TraverseChildren(child, recursive))
                    {
                        yield return cc;
                    }
                }
            }
        }
        /// <summary>
        /// 获取给定对象在父节点中的索引
        /// </summary>
        /// <param name="me"></param>
        /// <returns></returns>
        public static int IndexOf(GameObject me)
        {
            if (me == null || me.transform.parent == null)
                return -1;
            Transform pt = me.transform.parent.transform;
            for (int i=0; i<pt.childCount; ++i)
            {
                if (pt.GetChild(i).gameObject == me)
                    return i;
            }
            return -1;
        }
        /// <summary>
        /// 获取给定对象的兄弟节点
        /// </summary>
        /// <param name="obj">给定对象</param>
        /// <param name="indexOffset">相对当前对象的索引偏移，小于0表示之前兄弟，大于0表示之后的兄弟</param>
        /// <returns>兄弟，没找到返回null</returns>
        public static GameObject GetSibling(GameObject obj, int indexOffset)
        {
            if (obj == null || obj.transform.parent == null)
                return null;
            int myIdx = IndexOf(obj);
            int sibIdx = myIdx + indexOffset;
            Transform parent = obj.transform.parent;
            if (sibIdx < 0 || sibIdx >= parent.childCount)
                return null;
            return parent.GetChild(sibIdx).gameObject;
        }
        /// <summary>
        /// 设置给定对象在所在父节点的索引
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="index">索引，0表示最底层，-1表示最顶层</param>
        public static void SetSibling(GameObject obj, int index)
        {
            var parent = obj.transform.parent;
            if (parent == null)
                return;
            var pt = parent.transform;
            if (index <0 || index >= pt.childCount)
                index = pt.childCount -1;
            obj.transform.SetSiblingIndex(index);
        }
        public static void StampHideFlags(GameObject obj, HideFlags flgs)
        {
            if(obj == null )
            {
                return;
            }
            obj.hideFlags = flgs;
            int count = obj.transform.childCount;
            for (int i = 0; i < count; ++i)
            {
                GameObject child = obj.transform.GetChild(i).gameObject;
                StampHideFlags(child, flgs);
            }
        }

        /// <summary>
        /// 封装LookRotation
        /// </summary>
        /// <param name="vec"></param>
        public static Quaternion LookRotation(Vector3 forwardVec)
        {
            if (forwardVec != Vector3.zero)
                return Quaternion.LookRotation(forwardVec);
            else
                return Quaternion.identity;
        }

        public static Quaternion LookRotation(Vector3 forwardVec, Vector3 upwards)
        {
            if (forwardVec != Vector3.zero)
                return Quaternion.LookRotation(forwardVec, upwards);
            else
                return Quaternion.identity;
        }
        /// <summary>
        /// 调整rotation值
        /// </summary>
        public static Quaternion AdjustRotation(Quaternion aRot)
        {
            return aRot;

            //Vector3 elr;
            //float angle = 0;
            //aRot.ToAngleAxis(out angle, out elr);
            //if (angle >= 80.0f)
            //{
            //    angle = 80.0f;
            //    return Quaternion.AngleAxis(angle, elr);
            //}
            //return aRot;
        }

        /// <summary>
        /// 只移动节点，不改变本地属性
        /// </summary>
        /// <param name="self"></param>
        /// <param name="parent"></param>
        public static void SetParentOnly(Transform self, Transform parent)
        {
            var pos = self.localPosition;
            var rot = self.localRotation;
            var scale = self.localScale;
            self.SetParent(parent);

            self.localScale = scale;
            self.localRotation = rot;
            self.localPosition = pos;
        }
        public static void DontDestroyOnLoad(GameObject obj)
        {
            if (obj != null && Application.isPlaying)
            {
                GameObject.DontDestroyOnLoad(obj);
            }
        }
        /// <summary>
        /// 对单个物品引用cull
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="cull"></param>
        /// <param name="recursively"></param>
        public static void SetCull(GameObject obj, bool cull, bool recursively)
        {
            U3DExtension.SetCull(obj, cull, recursively);
        }
    }
}
