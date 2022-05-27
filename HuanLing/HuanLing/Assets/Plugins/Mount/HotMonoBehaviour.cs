using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace UnityEngine
{
    /// <summary>
    /// 支持热更新的组件机制
    /// </summary>
    [ExecuteInEditMode]
    public class HotMonoBehaviour : MonoBehaviour
    {
        [SerializeField]
        string _SerializedStr;
        [SerializeField]
        string _TypeName;

        Type _ComponentType;

        MethodInfo _AwakeFunc;
        MethodInfo _StartFunc;

        MethodInfo _UpdateFunc;
        MethodInfo _FixedUpdateFuc;
        MethodInfo _LateUpdateFunc;

        MethodInfo _OnDestroyFunc;

        MethodInfo _OnDisableFuc;
        MethodInfo _OnEnableFuc;

        MethodInfo _OnGUIFunc;
        MethodInfo _OnDrawGizmosFunc;

        HotComponent _Component;

        private void InitComponent()
        {
            if (string.IsNullOrEmpty(_TypeName))
            {
                return;
            }
            Assembly[] asms = AppDomain.CurrentDomain.GetAssemblies();
            for(var ai = 0; ai<asms.Length; ++ai)
            {
                var asm = asms[ai];
                _ComponentType = asm.GetType(_TypeName);
                if(_ComponentType != null)
                {
                    break;
                }
            }
            if (_ComponentType == null)
            {
                throw new System.InvalidProgramException("unknown type:" + _TypeName);
            }
            if (!_ComponentType.IsSubclassOf(typeof(HotComponent)))
            {
                throw new System.InvalidProgramException(string.Format("Invalid behaviour type {0}, it should inherited from UnityEngine.HotBehaviour", _TypeName));
            }
            BindingFlags findFlag = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;
            _AwakeFunc = _ComponentType.GetMethod("Awake", findFlag);
            _StartFunc = _ComponentType.GetMethod("Start", findFlag);

            _UpdateFunc = _ComponentType.GetMethod("Update", findFlag);
            _FixedUpdateFuc = _ComponentType.GetMethod("FixedUpdate", findFlag);
            _LateUpdateFunc = _ComponentType.GetMethod("LateUpdate", findFlag);

            _OnDestroyFunc = _ComponentType.GetMethod("OnDestroy", findFlag);

            _OnDisableFuc = _ComponentType.GetMethod("OnDisable", findFlag);
            _OnEnableFuc = _ComponentType.GetMethod("OnEnable", findFlag);

            _OnGUIFunc = _ComponentType.GetMethod("OnGUI", findFlag);
            _OnDrawGizmosFunc = _ComponentType.GetMethod("OnDrawGizmos", findFlag);

            if( string.IsNullOrEmpty(_SerializedStr))
            {
                var ct = _ComponentType.GetConstructor(Type.EmptyTypes);
                _Component = (HotComponent)ct.Invoke(null);
            }
            else
            {
                _Component = (HotComponent)JsonUtility.FromJson(_SerializedStr, _ComponentType);
            }

            FieldInfo gof = typeof(HotComponent).GetField("_GameObject", findFlag);
            gof.SetValue(_Component, gameObject);

            InvokeMethod(_AwakeFunc, null);
        }
        

        public HotComponent component
        {
            get
            {
                return _Component;
            }
        }

        public string typeName
        {
            get
            {
                return _TypeName;
            }
        }
        public Type componentType
        {
            get
            {
                return _ComponentType;
            }
        }

        /// <summary>
        /// 设置热更组件类型（只在编辑时有效）
        /// </summary>
        /// <param name="type">类型</param>
        public void SetComponentClass(Type type)
        {
            SetBhaviourClass(type.FullName);
        }
        /// <summary>
        /// 重新初始化一下热更组件(只在编辑时有效）
        /// </summary>
        public void ReInitComponent()
        {
#if UNITY_EDITOR
            if(!Application.isPlaying)
            {
                InitComponent();
            }
#endif
        }

        /// <summary>
        /// 设置脚本类型
        /// </summary>
        /// <param name="typeName">类型全名</param>
        public void SetBhaviourClass(string typeName)
        {
            if (Application.isPlaying)
            {
                if(string.IsNullOrEmpty(_TypeName) || _TypeName == typeName)
                {
                    _TypeName = typeName;
                    _ComponentType = null;
                    _Component = null;
                    InitComponent();
                }
                else
                {
                    throw new InvalidProgramException(string.Format("can't change component type in running..."));
                }
                return;
            }
#if UNITY_EDITOR
            if (typeName != _TypeName )
            {
                _TypeName = typeName;
                _ComponentType = null;
                _Component = null;
                InitComponent();
            }
#endif
        }
        /// <summary>
        /// 序列化脚本，以使其能被保存（apply)
        /// </summary>
        public void SerializeComponent()
        {
#if UNITY_EDITOR
            if(_Component!= null)
            {
                _SerializedStr = JsonUtility.ToJson(_Component);
            }
#endif
        }

        void Awake()
        {
            InitComponent();
        }

        void Start()
        {
            InvokeMethod(_StartFunc, null);
        }

        void Update()
        {
            InvokeMethod(_UpdateFunc, null);
        }

        void LateUpdate()
        {
            InvokeMethod(_LateUpdateFunc, null);
        }

        void FixedUpdate()
        {
            InvokeMethod(_FixedUpdateFuc, null);
        }

        void OnDestroy()
        {
            InvokeMethod(_OnDestroyFunc, null);
        }

        void OnEnable()
        {
            InvokeMethod(_OnEnableFuc, null);
        }

        void OnDisable()
        {
            InvokeMethod(_OnDisableFuc, null);
        }

        void OnGUI()
        {
            InvokeMethod(_OnGUIFunc, null);
        }

        void OnDrawGizmos()
        {
            InvokeMethod(_OnDrawGizmosFunc, null);
        }

        object InvokeMethod(MethodInfo method, object[] parameters)
        {
            if(method != null && _Component != null)
            {
                method.Invoke(_Component, parameters);
            }
            return null;
        }

    }

    public abstract class HotComponent
    {
        private GameObject _GameObject;
        public GameObject gameObject
        {
            get
            {
                return _GameObject;
            }
        }
        
        public T GetComponent<T>()where T:Component
        {
            return gameObject.GetComponent<T>();
        }

        public Component GetComponent(Type t)
        {
            return gameObject.GetComponent(t);
        }

        public HotComponent GetHotComponent<T>()where T:HotComponent
        {
            return gameObject.GetHotComponent<T>();
        }

        public HotComponent GetHotComponent(Type t)
        {
            return gameObject.GetHotComponent(t);
        }

        public HotComponent AddHotComponent<T>()where T:HotComponent
        {
            return gameObject.AddHotComponent<T>();
        }

        public HotComponent AddHotComponent(Type t)
        {
            return gameObject.AddHotComponent(t);
        }
    }

    public class TestHotComponent:HotComponent
    {
        public int a;
        public float b;
        public long c;
        public bool d;
        public string e;
    }
}
