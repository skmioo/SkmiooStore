using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using SLua;

namespace UYMO
{
    [CustomLuaClass]
    public class LuaCompList
    {
        private static Stack<LuaCompList> s_Pool = new Stack<LuaCompList>();
        [DoNotToLua]
        public static LuaCompList Create()
        {
            return s_Pool.Count == 0 ? new LuaCompList() : s_Pool.Pop();
        }
        [DoNotToLua]
        public static void Gabage(LuaCompList ls)
        {
            ls.Clear();
            s_Pool.Push(ls);
        }

        private List<object> _List = new List<object>();
        private LuaCompList() { }
        [DoNotToLua]
        public void ApplyList<T>(List<T> ls)
        {
            for (int i = 0; i < ls.Count; ++i)
            {
                _List.Add(ls[i]);
            }
        }
        [DoNotToLua]
        public void Clear()
        {
            _List.Clear();
        }
        public int Size()
        {
            return _List.Count;
        }
        public object At(int index)
        {
            return _List[index - 1];
        }
    }

    [CustomLuaClass]
    public class UIUtil
    {
        /// <summary>
        /// 从prefab实例化一个gameobject
        /// </summary>
        /// <param name="prefabName">prefab名称</param>
        /// <param name="parentObj">父节点</param>
        /// <returns>实例化的一个go</returns>
        [DoNotToLua]
        public static GameObject CreateUIGameObject(string prefabName, GameObject parentObj = null)
        {
            return PlayInterface.LoadGuiObject(prefabName, parentObj);
        }
        /// <summary>
        /// 删除ui上的go（注意，删除的时候会尝试清理lua来的注册接口，理论上所有的ui对象，都应该走这个函数）
        /// </summary>
        /// <param name="obj">被删除的对象</param>
        public static GameObject DestroyUIGameObject(GameObject obj)
        {
            ClearAllData(obj);
            return U3DUtil.DestroyGameObject(obj);
        }
        /// <summary>
        /// 清除所有子控件的数据（主要是lua注册的回调函数）
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="includeThis">是否包括obj本身的组件</param>
        [DoNotToLua]
        public static void ClearAllData(GameObject obj, bool includeThis = true)
        {
            if (obj == null)
                return;
            var ls = GetClearableListInChildren(obj, true);
            if (includeThis)
            {
                for (int idx = 0; idx < ls.Count; idx++)
                {
                    ls[idx].Clear();
                }
            }
            else
            {
                for (int idx = 0; idx < ls.Count; idx++)
                {
                    var cmp = ls[idx] as Component;
                    if (cmp != null && cmp.gameObject != obj)
                        ls[idx].Clear();
                }
            }
            ObjectPool.clearableListPool.Gabage(ls);
        }

        /// <summary>
        /// 实例化go
        /// </summary>
        /// <param name="go"></param>
        /// <returns></returns>
        [DoNotToLua]
        public static GameObject Instantiate(GameObject go)
        {
            return PlayInterface.InstantiateAlone(go);
        }
        /// <summary>
        /// 实例化go
        /// </summary>
        /// <param name="go"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        [DoNotToLua]
        public static GameObject Instantiate(GameObject go, Transform parent)
        {
            return PlayInterface.InstantiateToParent(go, parent);
        }
        /// <summary>
        /// 实例化go
        /// </summary>
        /// <param name="go"></param>
        /// <param name="pos"></param>
        /// <param name="rot"></param>
        /// <returns></returns>
        [DoNotToLua]
        public static GameObject Instantiate(GameObject go, Vector3 pos, Quaternion rot)
        {
            return PlayInterface.InstantiateToGeom(go, pos, rot);
        }

        /// <summary>
        /// 实例化“cell”，cell的意思是指愿意重复使用的，不用了需要调用gabage
        /// </summary>
        /// <param name="user">使用者，一般是一个组件</param>
        /// <param name="prefabCell">原始cell，用来实例化新对象</param>
        /// <param name="winName">传入并生成窗口名称，这个名称与传入的原始cell名称一起唯一标定一个cell资源</param>
        /// <returns>实例化出的go</returns>
        [DoNotToLua]
        public static GameObject InstantiateCell(GameObject user, GameObject prefabCell, ref string winName)
        {
            return InstantiateCell(user, prefabCell, null, ref winName);
        }
        /// <summary>
        /// 实例化“cell”，cell的意思是指愿意重复使用的，不用了需要调用gabage
        /// </summary>
        /// <param name="user">使用者，一般是一个组件</param>
        /// <param name="prefabCell">原始cell，用来实例化新对象</param>
        /// <param name="parent">父节点</param>
        /// <param name="winName">传入并生成窗口名称，这个名称与传入的原始cell名称一起唯一标定一个cell资源</param>
        /// <returns>实例化出的go</returns>
        [DoNotToLua]
        public static GameObject InstantiateCell(GameObject user, GameObject prefabCell, Transform parent, ref string winName)
        {
            if (winName == null)
            {
                var cur = user.transform;
                while (cur != null)
                {
                    var win = cur.GetComponent<Window>();
                    if (win != null)
                    {
                        winName = win.name;
                        break;
                    }
                    cur = cur.parent;
                }
                if (winName == null)
                {
                    winName = "";
                }
            }
            if (string.IsNullOrEmpty(winName))
            {
                Debug.LogErrorFormat("根据窗口名称创建prefab cell失败");
                return null;
            }
            return PlayInterface.InstantiateFromPool(winName + "/" + prefabCell.name, prefabCell, parent);
        }
        /// <summary>
        /// 实例化“cell”，cell的意思是指愿意重复使用的，不用了需要调用gabage
        /// </summary>
        /// <param name="user">使用者，一般是一个组件</param>
        /// <param name="prefabCell">原始cell，用来实例化新对象</param>
        /// <param name="pos">全局坐标位置</param>
        /// <param name="rot">全局旋转</param>
        /// <param name="winName">传入并生成窗口名称，这个名称与传入的原始cell名称一起唯一标定一个cell资源</param>
        /// <returns>实例化出的go</returns>
        [DoNotToLua]
        public static GameObject InstantiateCell(GameObject user, GameObject prefabCell, Vector3 pos, Quaternion rot, ref string winName)
        {
            var go = InstantiateCell(user, prefabCell, null, ref winName);
            go.transform.position = pos;
            go.transform.rotation = rot;
            return go;
        }
        /// <summary>
        /// 回收一个cell
        /// </summary>
        /// <param name="cell">即将被回收的cell对象</param>
        /// <returns>null</returns>
        [DoNotToLua]
        public static GameObject GabageCell(GameObject cell)
        {
           PlayInterface.GabageToPool(cell);
           return null;
        }

        /// <summary>
        /// 獲取YLabel
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="childName"></param>
        /// <returns></returns>
        [DoNotToLua]
        public static YLabel GetYLabel(GameObject parent, string childName)
        {
            return UIUtil.GetYCtrl<YLabel>(parent, childName);
        }
        [DoNotToLua]
        public static YLabel GetYLabel(GameObject parent)
        {
            return GetYLabel(parent, "");
        }

        /// <summary>
        /// 獲取Y控件 如果沒有AddComponent
        /// </summary>
        /// <typeparam name="TYCtrl"></typeparam>
        /// <param name="parent"></param>
        /// <param name="childName"></param>
        /// <returns></returns>
        [DoNotToLua]
        public static TYCtrl GetYCtrl<TYCtrl>(GameObject parent, string childName = "")
            where TYCtrl : Component
        {
            if (childName == "")
            {
                return parent.GetComponent<TYCtrl>();
            }
            var childObj = U3DUtil.GetChildByName(parent, childName, true);
            if (childObj != null)
            {
                var ui = childObj.GetComponent<TYCtrl>();
                if (ui == null)
                {
                    return ui;
                }
                return ui;
            }
            return null;
        }
        [DoNotToLua]
        public static TYCtrl GetYCtrlByPath<TYCtrl>(GameObject parent, string path)
            where TYCtrl : Component
        {
            if (string.IsNullOrEmpty(path))
            {
                return parent.GetComponent<TYCtrl>();
            }
            var childObj = U3DUtil.GetChildByPath(parent, path);
            if (childObj != null)
            {
                var ui = childObj.GetComponent<TYCtrl>();
                if (ui == null)
                {
                    return ui;
                }
                return ui;
            }
            return null;
        }
        [DoNotToLua]
        public static TYCtrl GetHotCtrl<TYCtrl>(GameObject parent, string childName = "")
            where TYCtrl : HotComponent
        {
            if (childName == "")
            {
                var ui = parent.GetHotComponent<TYCtrl>();
                if (ui == null)
                {
                    return ui;
                }
                return ui;
            }
            var childObj = U3DUtil.GetChildByName(parent, childName, true);
            if (childObj != null)
            {
                var ui = childObj.GetHotComponent<TYCtrl>();
                if (ui == null)
                {
                    return ui;
                }
                return ui;
            }
            return null;
        }

        [DoNotToLua]
        public static T GetComponent<T>(GameObject parent, string childName = "")
            where T : UnityEngine.Component
        {
            if (childName == "")
            {
                var ui = parent.GetComponent<T>();
                if (ui == null)
                {
                    return ui;
                }
                return ui;
            }
            var childObj = U3DUtil.GetChildByName(parent, childName, true);
            if (childObj != null)
            {
                var ui = childObj.GetComponent<T>();
                if (ui == null)
                {
                    return ui;
                }
                return ui;
            }
            return null;
        }

        [DoNotToLua]
        public static List<T> GetComponentListInChildren<T>(GameObject go, bool includeInactive)
        {
            var lspool = ObjectPool.FetchListPool<T>();
            var ls = lspool.Create();
            go.GetComponentsInChildren<T>(includeInactive, ls);
            return ls;
        }
        [DoNotToLua]
        public static List<YLabel> GetYLabelListInChildren(GameObject go, bool includeInactive)
        {
            var ls = ObjectPool.labelListPool.Create();
            go.GetComponentsInChildren<YLabel>(includeInactive, ls);
            return ls;
        }
        [DoNotToLua]
        public static List<YImage> GetYImageListInChildren(GameObject go, bool includeInactive)
        {
            var ls = ObjectPool.imageListPool.Create();
            go.GetComponentsInChildren<YImage>(includeInactive, ls);
            return ls;
        }
        [DoNotToLua]
        public static List<YToggle> GetYToggleListInChildren(GameObject go, bool includeInactive)
        {
            var ls = ObjectPool.toggleListPool.Create();
            go.GetComponentsInChildren<YToggle>(includeInactive, ls);
            return ls;
        }
        [DoNotToLua]
        public static List<IClearable> GetClearableListInChildren(GameObject go, bool includeInactive)
        {
            var ls = ObjectPool.clearableListPool.Create();
            go.GetComponentsInChildren<IClearable>(includeInactive, ls);
            return ls;
        }
        [DoNotToLua]
        public static List<Component> GetCompListInChildren(GameObject go, bool includeInactive)
        {
            var ls = ObjectPool.componentListPool.Create();
            go.GetComponentsInChildren<Component>(includeInactive, ls);
            return ls;
        }
        [DoNotToLua]
        public static List<UIBehaviour> GetUIBehaviourListInChildren(GameObject go, bool includeInactive)
        {
            var ls = ObjectPool.uiBehaveListPool.Create();
            go.GetComponentsInChildren<UIBehaviour>(includeInactive, ls);
            return ls;
        }
        [DoNotToLua]
        public static List<Renderer> GetRendererListInChildren(GameObject go, bool includeInactive)
        {
            var ls = ObjectPool.rendererListPool.Create();
            go.GetComponentsInChildren<Renderer>(includeInactive, ls);
            return ls;
        }
        [DoNotToLua]
        public static List<MeshRenderer> GetMeshRendererListInChildren(GameObject go, bool includeInactive)
        {
            var ls = ObjectPool.meshRendererListPool.Create();
            go.GetComponentsInChildren<MeshRenderer>(includeInactive, ls);
            return ls;
        }
        [DoNotToLua]
        public static List<LineRenderer> GetLineRendererListInChildren(GameObject go, bool includeInactive)
        {
            var ls = ObjectPool.lineRendererListPool.Create();
            go.GetComponentsInChildren<LineRenderer>(includeInactive, ls);
            return ls;
        }
        [DoNotToLua]
        public static List<ParticleSystem> GetParticleSystemListInChildren(GameObject go, bool includeInactive)
        {
            var ls = ObjectPool.particleSystemListPool.Create();
            go.GetComponentsInChildren<ParticleSystem>(includeInactive, ls);
            return ls;
        }
        [DoNotToLua]
        public static List<ISpriteUser> GetSpriteUserListInChildren(GameObject go, bool includeInactive)
        {
            var ls = ObjectPool.spriteUserListPool.Create();
            go.GetComponentsInChildren<ISpriteUser>(includeInactive, ls);
            return ls;
        }
        [DoNotToLua]
        public static List<LODGroup> GetLODGroupListInChildren(GameObject go, bool includeInactive)
        {
            var ls = ObjectPool.lodGroupListPool.Create();
            go.GetComponentsInChildren<LODGroup>(includeInactive, ls);
            return ls;
        }
        [DoNotToLua]
        public static List<ShowQuality> GetShowQualityListInChildren(GameObject go, bool includeInactive)
        {
            var ls = ObjectPool.showQualityListPool.Create();
            go.GetComponentsInChildren<ShowQuality>(includeInactive, ls);
            return ls;
        }
        [DoNotToLua]
        public static List<EffectShake> GetEffectShakeListInChildren(GameObject go, bool includeInactive)
        {
            var ls = ObjectPool.effectShakeListPool.Create();
            go.GetComponentsInChildren<EffectShake>(includeInactive, ls);
            return ls;
        }

        [DoNotToLua]
        private static LuaCompList _GetComponentList<T>(GameObject go, bool includeInactive)
        {
            var ls = GetCompListInChildren(go, includeInactive);
            var luals = LuaCompList.Create();
            luals.ApplyList(ls);
            return luals;
        }

        public static LuaCompList BeginYImageList(GameObject go, bool includeInactive)
        {
            var ls = GetYImageListInChildren(go, includeInactive);
            var luals = LuaCompList.Create();
            luals.ApplyList(ls);
            ObjectPool.imageListPool.Gabage(ls);
            return luals;
        }
        public static LuaCompList BeginYLabelList(GameObject go, bool includeInactive)
        {
            var ls = GetYLabelListInChildren(go, includeInactive);
            var luals = LuaCompList.Create();
            luals.ApplyList(ls);
            ObjectPool.labelListPool.Gabage(ls);
            return luals;
        }
        public static LuaCompList BeginYToggleList(GameObject go, bool includeInactive)
        {
            var ls = GetYToggleListInChildren(go, includeInactive);
            var luals = LuaCompList.Create();
            luals.ApplyList(ls);
            ObjectPool.toggleListPool.Gabage(ls);
            return luals;
        }
        public static LuaCompList EndUIList(LuaCompList ls)
        {
            if (ls != null)
                LuaCompList.Gabage(ls);
            return null;
        }

        /// <summary>
        /// 设置SortingOrder
        /// </summary>
        [SLua.DoNotToLua]
        public static void SetSortingOrder(GameObject target, int sortLayer, int order, bool isUI)
        {
            if (isUI)
            {
                var can = target.GetComponent<Canvas>();
                if (can == null)
                {
                    can = target.AddComponent<Canvas>();
                }
                can.overrideSorting = true;
                can.sortingLayerID = sortLayer;
                can.sortingOrder = order;
                target.AddComponent<GraphicRaycaster>();
            }
            else
            {
                var renders = GetRendererListInChildren(target, true);
                for (int idx = 0; idx < renders.Count; idx++)
                {
                    var render = renders[idx];
                    render.sortingLayerID = sortLayer;
                    render.sortingOrder = order;
                }
                ObjectPool.rendererListPool.Gabage(renders);
            }
        }


        struct GuiComponentInfo
        {
            public string comName;
            public int index;

            public GuiComponentInfo(string name, int idx)
            {

                comName = name;
                index = idx;
            }
        }
        /// <summary>
        /// 绑定组件
        /// </summary>
        /// <param name="parent">根节点</param>
        /// <param name="bindinfos">绑定信息, gameObject名,组件名...</param>
        /// <returns></returns>

        static int _BindGuiCount;
        static string[] _Bindinfos;
        static public object[] BindGuis(GameObject parent, string[] bindinfos)
        {
            if (bindinfos.Length % 2 != 0)
                return null;


            _BindGuiCount = bindinfos.Length / 2;
            _Bindinfos = bindinfos;
            object[] ret = new object[_BindGuiCount];
            CheckObjGui(ret, parent);
            return ret;
        }

        /// <summary>
        /// 递归检查GameObject的组件
        /// </summary>
        private static void CheckObjGui(object[] ret, GameObject obj)
        {
            for (int i = 0; i < _Bindinfos.Length - 1; )
            {
                if (_Bindinfos[i] == obj.name)
                {
                    if (_Bindinfos[i + 1] == "go")
                        ret[i / 2] = obj;
                    else
                    {
                        switch (_Bindinfos[i + 1])
                        {
                            case "YLabel": ret[i / 2] = obj.GetComponent<YLabel>(); break;
                            case "YImage": ret[i / 2] = obj.GetComponent<YImage>(); break;
                            case "YButton": ret[i / 2] = obj.GetComponent<YButton>(); break;
                            case "YToggle": ret[i / 2] = obj.GetComponent<YToggle>(); break;
                            case "YScrollList": ret[i / 2] = obj.GetComponent<YScrollList>(); break;
                            case "YInputField": ret[i / 2] = obj.GetComponent<YInputField>(); break;
                            case "YUIEffect": ret[i / 2] = obj.GetComponent<YUIEffect>(); break;
                            case "YSpriteAnimation": ret[i / 2] = obj.GetComponent<YSpriteAnimation>(); break;
                            case "YRichLabel": ret[i / 2] = obj.GetComponent<YRichLabel>(); break;
                            case "YTouchableGraphic": ret[i / 2] = obj.GetComponent<YTouchableGraphic>(); break;
                            case "YGridGroup": ret[i / 2] = obj.GetComponent<YGridGroup>(); break;
                            case "YScrollRect": ret[i / 2] = obj.GetComponent<YScrollRect>(); break;
                            default: ret[i / 2] = obj.GetComponent(_Bindinfos[i + 1]); break;
                        }
                    }

                }
                i = i + 2;
            }
            if (_BindGuiCount == 0)
                return;

            for (int i = 0; i < obj.transform.childCount; ++i)
            {
                var sub = obj.transform.GetChild(i).gameObject;
                CheckObjGui(ret, sub);
                if (_BindGuiCount == 0)
                    return;
            }
        }
    }
}
