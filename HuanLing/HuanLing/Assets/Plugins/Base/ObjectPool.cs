using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using SLua;

namespace UYMO
{
    public class ListPoolT<T> : IClearable
    {
        private Stack<List<T>> _Pool;
        private int _MaxCount;
        public ListPoolT(int aMaxCount = 0)
        {
            _Pool = new Stack<List<T>>();
            _MaxCount = aMaxCount <= 0 ? 20 : aMaxCount;
        }
        public int maxCount
        {
            get { return _MaxCount; }
            set
            {
                if (value <= 0)
                    value = 20;
                if (_MaxCount == value)
                    return;
                _MaxCount = value;
                while (_Pool.Count > _MaxCount)
                    _Pool.Pop();
            }
        }
        public List<T> Create()
        {
            return _Pool.Count == 0 ? new List<T>() : _Pool.Pop();
        }
        public List<T> Gabage(List<T> ls)
        {
            if (ls != null)
            {
                ls.Clear();
                if (_Pool.Count < _MaxCount)
                    _Pool.Push(ls);
            }
            return null;
        }
        public void Clear()
        {
            _Pool.Clear();
        }
    }

    /// <summary>
    /// 对象池
    /// </summary>
    [CustomLuaClass]
    public class ObjectPool
    {
        private static LinkedList<Vector3[]> _Vec3ArrayPool = new LinkedList<Vector3[]>();

        private static Dictionary<Type, IClearable> _ListPools = new Dictionary<Type, IClearable>();

        private static ListPoolT<string> strListPool = new ListPoolT<string>();
        public static ListPoolT<float> floatListPool = new ListPoolT<float>();
        public static ListPoolT<Vector2> vec2ListPool = new ListPoolT<Vector2>();
        public static ListPoolT<Vector3> vec3ListPool = new ListPoolT<Vector3>();

        public static ListPoolT<GameObject> goListPool = new ListPoolT<GameObject>();
        public static ListPoolT<IClearable> clearableListPool = new ListPoolT<IClearable>();
        public static ListPoolT<ShowQuality> showQualityListPool = new ListPoolT<ShowQuality>();
        public static ListPoolT<ISpriteUser> spriteUserListPool = new ListPoolT<ISpriteUser>();
        public static ListPoolT<EffectShake> effectShakeListPool = new ListPoolT<EffectShake>();
        public static ListPoolT<LODGroup> lodGroupListPool = new ListPoolT<LODGroup>();
        public static ListPoolT<MeshFilter> meshFilterListPool = new ListPoolT<MeshFilter>();
        public static ListPoolT<Animator> animatorListPool = new ListPoolT<Animator>();

        public static ListPoolT<UIBehaviour> uiBehaveListPool = new ListPoolT<UIBehaviour>();
        public static ListPoolT<Component> componentListPool = new ListPoolT<Component>();

        public static ListPoolT<Renderer> rendererListPool = new ListPoolT<Renderer>();
        public static ListPoolT<MeshRenderer> meshRendererListPool = new ListPoolT<MeshRenderer>();
        public static ListPoolT<SkinnedMeshRenderer> skinnedMeshRendererListPool = new ListPoolT<SkinnedMeshRenderer>();
        public static ListPoolT<TrailRenderer> trailRendererListPool = new ListPoolT<TrailRenderer>();
        public static ListPoolT<LineRenderer> lineRendererListPool = new ListPoolT<LineRenderer>();
        public static ListPoolT<ParticleSystem> particleSystemListPool = new ListPoolT<ParticleSystem>();

        public static ListPoolT<Collider> colliderListPool = new ListPoolT<Collider>();
        public static ListPoolT<MeshCollider> meshColliderListPool = new ListPoolT<MeshCollider>();
        public static ListPoolT<BoxCollider> boxColliderListPool = new ListPoolT<BoxCollider>();

        public static ListPoolT<Shadow> shadowListPool = new ListPoolT<Shadow>();
        public static ListPoolT<YLabel> labelListPool = new ListPoolT<YLabel>();
        public static ListPoolT<YImage> imageListPool = new ListPoolT<YImage>();
        public static ListPoolT<YToggle> toggleListPool = new ListPoolT<YToggle>();

        static ObjectPool()
        {
            _ListPools[typeof(float)] = floatListPool;
            _ListPools[typeof(string)] = strListPool;
            _ListPools[typeof(Vector2)] = vec2ListPool;
            _ListPools[typeof(Vector3)] = vec3ListPool;

            _ListPools[typeof(GameObject)] = goListPool;
            _ListPools[typeof(IClearable)] = clearableListPool;
            _ListPools[typeof(ShowQuality)] = showQualityListPool;
            _ListPools[typeof(ISpriteUser)] = spriteUserListPool;
            _ListPools[typeof(EffectShake)] = effectShakeListPool;
            _ListPools[typeof(LODGroup)] = lodGroupListPool;
            _ListPools[typeof(MeshFilter)] = meshFilterListPool;
            _ListPools[typeof(Animator)] = animatorListPool;

            _ListPools[typeof(UIBehaviour)] = uiBehaveListPool;
            _ListPools[typeof(Component)] = componentListPool;

            _ListPools[typeof(Renderer)] = rendererListPool;
            _ListPools[typeof(MeshRenderer)] = meshRendererListPool;
            _ListPools[typeof(SkinnedMeshRenderer)] = skinnedMeshRendererListPool;
            _ListPools[typeof(TrailRenderer)] = trailRendererListPool;
            _ListPools[typeof(LineRenderer)] = lineRendererListPool;
            _ListPools[typeof(ParticleSystem)] = particleSystemListPool;

            _ListPools[typeof(Collider)] = colliderListPool;
            _ListPools[typeof(MeshCollider)] = meshRendererListPool;
            _ListPools[typeof(BoxCollider)] = boxColliderListPool;

            _ListPools[typeof(Shadow)] = shadowListPool;
            _ListPools[typeof(YLabel)] = labelListPool;
            _ListPools[typeof(YImage)] = imageListPool;
            _ListPools[typeof(YToggle)] = toggleListPool;
        }

        [DoNotToLua]
        public static ListPoolT<T> FetchListPool<T>()
        {
            var t = typeof(T);
            IClearable o;
            if (!_ListPools.TryGetValue(t, out o))
            {
                o = new ListPoolT<T>();
                _ListPools.Add(t, o);
            }
            return o as ListPoolT<T>;
        }
        [DoNotToLua]
        public static List<T> FetchList<T>()
        {
            return FetchListPool<T>().Create();
        }
        [DoNotToLua]
        public static List<T> GabageList<T>(List<T> ls)
        {
            return FetchListPool<T>().Gabage(ls);
        }

        /// <summary>
        /// 创建一个vector3 list
        /// </summary>
        /// <returns></returns>
        [DoNotToLua]
        public static List<Vector3> FetchVec3List()
        {
            return vec3ListPool.Create();
        }
        /// <summary>
        /// 回收一个vector3 list
        /// </summary>
        /// <param name="path">可以传null</param>
        /// <returns>返回null</returns>
        [DoNotToLua]
        public static List<Vector3> Gabage(List<Vector3> path)
        {
            return vec3ListPool.Gabage(path);
        }
        /// <summary>
        /// 拷贝一个vector3 list
        /// </summary>
        /// <param name="ls">待拷贝的数组</param>
        /// <param name="ret">用于返回的数组</param>
        /// <returns></returns>
        [DoNotToLua]
        public static List<Vector3> CloneVec3List(List<Vector3> ls, List<Vector3> ret = null)
        {
            if (ret == null)
                ret = FetchVec3List();
            else
                ret.Clear();
            if (ls == null)
                return ret;
            ret.Capacity = ls.Count;
            for (int i = 0; i < ls.Count; ++i)
            {
                ret.Add(ls[i]);
            }
            return ret;
        }

        [DoNotToLua]
        public static List<Vector3> Vec3ArrayToList(Vector3[] ary)
        {
            if (ary == null)
                return null;
            List<Vector3> ls = FetchVec3List();
            ls.Capacity = ary.Length;
            ls.AddRange(ary);
            return ls;
        }
        /// <summary>
        /// 创建一个给定长度的vector3数组
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        [DoNotToLua]
        public static Vector3[] FetchVec3Array(int size)
        {
            if (_Vec3ArrayPool.Count > 0)
            {
                var node = _Vec3ArrayPool.First;
                while (node != null)
                {
                    Vector3[] p = node.Value;
                    if (p.Length == size)
                    {
                        _Vec3ArrayPool.Remove(node);
                        return p;
                    }
                    node = node.Next;
                }
            }
            return new Vector3[size];
        }
        /// <summary>
        /// 重新分配给定大小的数组
        /// </summary>
        /// <param name="array">当前数组</param>
        /// <param name="size">目标尺寸</param>
        /// <param name="allowNullArry">当size小于等于0的时候，是否可以返回null，false表示返回一个空数组</param>
        /// <returns>新的数组</returns>
        [DoNotToLuaAttribute]
        public static Vector3[] ResizeVec3Array(Vector3[] array, int size, bool allowNullArry)
        {
            size = size < 0 ? 0 : size;
            int curSize = array == null ? -1 : array.Length;
            if (curSize == size)
                return array;
            Gabage(array);
            if (size == 0 && allowNullArry)
                return null;
            return FetchVec3Array(size);
        }
        /// <summary>
        /// 回收一个Vector3数组
        /// </summary>
        /// <param name="ary"></param>
        /// <returns>null</returns>
        [DoNotToLua]
        public static Vector3[] Gabage(Vector3[] ary)
        {
            if (ary != null && ary.Length < 20)
            {
                _Vec3ArrayPool.AddFirst(ary);
                if (_Vec3ArrayPool.Count > 10)
                {
                    _Vec3ArrayPool.RemoveLast();
                }
            }
            return null;
        }

        /// <summary>
        /// 清理缓存数据
        /// </summary>
        [DoNotToLua]
        public static void GabageAll()
        {
            var it = _ListPools.GetEnumerator();
            while (it.MoveNext())
            {
                it.Current.Value.Clear();
            }
            _Vec3ArrayPool.Clear();
        }

        /// <summary>
        /// 重载Object的实例化接口
        /// </summary>
        /// <param name="original"></param>
        /// <returns></returns>
        public static UnityEngine.Object Instantiate(UnityEngine.Object original)
        {
            if (original == null)
                return null;
            UnityEngine.Object obj = UnityEngine.Object.Instantiate(original);
            return obj;
        }

        public static T Instantiate<T>(T original) where T : UnityEngine.Object
        {
            if (original == null)
                return null;
            T obj = UnityEngine.Object.Instantiate<T>(original);
            return obj;
        }

        public static T Instantiate<T>(T original, Transform parent) where T : UnityEngine.Object
        {
            if (original == null)
                return null;
            T obj = UnityEngine.Object.Instantiate(original, parent) as T;
            return obj;
        }

        public static GameObject Instantiate(GameObject original, Transform parent, bool worldPosStay)
        {
            GameObject obj = UnityEngine.Object.Instantiate(original, parent, worldPosStay) as GameObject;
            return obj;
        }

        public static UnityEngine.Object Instantiate(UnityEngine.Object original, Vector3 position, Quaternion rotation)
        {
            if (original == null)
                return null;
            UnityEngine.Object obj = UnityEngine.Object.Instantiate(original, position, rotation);
            return obj;
        }
    }
}
