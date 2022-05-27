using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using SLua;
using UYMO;

namespace UnityEngine.UI
{
    /// <summary>
    /// 客户自定义小部件
    /// </summary>
    public class CustomWidget:UIBehaviour
    {
        /// <summary>
        /// 小部件的prefab资源
        /// </summary>
        [SerializeField]
        GameObject _Prefab;

        /// <summary>
        /// 小部件layout路径
        /// </summary>
        string _LayoutPath;
        /// <summary>
        /// 小部件的lua逻辑类名
        /// </summary>
        [SerializeField]
        string _LuaWidgetClass;
        [SerializeField]
        bool _ShowWidget = true;
        GameObject _WidgetLayout;
        LuaTable _Widget;

        /// <summary>
        /// 初始化小部件
        /// </summary>
        /// <param name="prefab">小部件prefab资源</param>
        /// <param name="luaName">小部件lua逻辑</param>
        public void Init(string prefab, string luaName )
        {
#if UNITY_EDITOR
            if(Application.isPlaying )
            {
                return;
            }
            if (_LayoutPath != prefab || _LuaWidgetClass != luaName)
            {
                _LayoutPath = prefab;
                _LuaWidgetClass = luaName;
                Prepare();
            }
#endif
        }

        void Prepare()
        {
             _WidgetLayout = UIUtil.DestroyUIGameObject(_WidgetLayout);

#if UNITY_EDITOR
            if(Application.isPlaying )
            {
                RefreshViewdWidget();
            }
            else
            {
                _Prefab = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(_LayoutPath);
                if (_ShowWidget)
                {
                    RefreshViewdWidget();
                }
            }
#else
            RefreshViewdWidget();
#endif
            if (Application.isPlaying)
            {
                if (_Widget != null)
                {
                    _Widget.Dispose();
                    _Widget = null;
                }
                var luacls = PlayInterface.GetLuaState().getTable(_LuaWidgetClass);
                _Widget = (LuaTable)luacls.CallMethod("new");
                _Widget.CallMethod("Init", _WidgetLayout);
            }
        }

        private void RefreshViewdWidget()
        {
            if (_Prefab)
            {
                _WidgetLayout = UIUtil.Instantiate(_Prefab);
                var wtrans = _WidgetLayout.transform;
                wtrans.SetParent(transform);
                wtrans.localPosition = Vector3.zero;
                _WidgetLayout.name = _Prefab.name;
            }
        }
        /// <summary>
        /// 设置是否显示小部件（编辑器下有效）
        /// </summary>
        public bool showWidget
        {
#if UNITY_EDITOR
            get
            {
                return _ShowWidget;
            }
            set
            {
                if (_ShowWidget != value)
                {
                    _ShowWidget = value;
                    _WidgetLayout = UIUtil.DestroyUIGameObject(_WidgetLayout);
                    if(_ShowWidget)
                    {
                        RefreshViewdWidget();
                    }
                }
            }
#else
            get{ return true;}
#endif
        }
        /// <summary>
        /// 保存对小部件的修改（编辑器下有效）
        /// </summary>
        public void SaveWidget()
        {
#if UNITY_EDITOR
            UnityEditor.PrefabUtility.ReplacePrefab(_WidgetLayout, _Prefab, UnityEditor.ReplacePrefabOptions.ReplaceNameBased);
#endif
        }

        public GameObject prefab
        {
            get
            {
                return _Prefab;
            }
        }


        protected override void Awake()
        {
            Prepare();
        }
        protected override void Start()
        {
            
        }
        protected override void OnDestroy()
        {
            if(_Widget!= null)
            {
                _Widget.CallMethod("Destroy");
            }
        }
        /// <summary>
        /// 获取组件实例
        /// </summary>
        public SLua.LuaTable widget
        {
            get
            {
                return _Widget;
            }
        }
        /// <summary>
        /// 获取组件UI实例
        /// </summary>
        public GameObject widgetGameObject
        {
            get
            {
                return _WidgetLayout;
            }
        }
    }
}
