using UYMO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using SLua;

namespace UYMO
{
    [CustomLuaClass]
    [AddComponentMenu("YUI/YUIEffect", 15)]
    public class YUIEffect : UIBehaviour, IClearable
    {
#region PROPERTIES
        /// <summary>
        /// 粒子特效ResID
        /// </summary>
        [SerializeField]
        private ResID _ResID;
        public ResID resID
        {
            get { return _ResID; }
            set { _ResID = value; }
        }

        /// <summary>
        /// 位置
        /// </summary>
        [SerializeField]
        private Vector3 _LocalPosition;
        public Vector3 localPosition
        {
            get { return _LocalPosition; }
            set { _LocalPosition = value; }
        }

        /// <summary>
        /// 缩放
        /// </summary>
        [SerializeField]
        private Vector3 _Scale = Vector3.one;
        public Vector3 scale
        {
            get { return _Scale; }
            set { _Scale = value; }
        }

        /// <summary>
        /// 是否根据父结点旋转
        /// </summary>
        [SerializeField]
        private bool _Rotate = false;
        public bool rotate    
        {
            get { return _Rotate; }
            set { _Rotate = value; }
        }

        /// <summary>
        /// 是否为简单模式
        /// 简单模式：直接创建特效
        /// 非简单模式：渲染到纹理
        /// </summary>
        [SerializeField]
        private bool _Simple = true;
        public bool simple
        {
            get { return _Simple; }
            set { _Simple = value; }
        }

        /// <summary>
        /// 特效是否自动删除
        /// </summary>
        [SerializeField]
        private bool _AutoKill = false;
        public bool autoKill
        {
            get { return _AutoKill; }
            set { _AutoKill = value; }
        }

        /// <summary>
        /// 是否在启动时播放特效
        /// </summary>
        [SerializeField]
        private bool _PlayOnAwake = true;
        public bool playOnAwake
        {
            get { return _PlayOnAwake; }
            set { _PlayOnAwake = value; }
        }

        /// <summary>
        /// 混合方式枚举
        /// </summary>
        public enum BlendMode
        {
            Additive = 0, // 叠加
            Blend = 1,    // 混合
        }

        /// <summary>
        /// 特效的混合模式，非简单模式下启用
        /// </summary>
        [SerializeField]
        private BlendMode _BlendMode = BlendMode.Additive;
        public BlendMode blendMode
        {
            get { return _BlendMode; }
            set { _BlendMode = value; }
        }

        /// <summary>
        /// 特效摄像机大小
        /// 若为0则使用gameobject的高
        /// </summary>
        [SerializeField]
        private float _CameraSize = 0;
        public float cameraSize
        {
            get { return _CameraSize; }
            set { _CameraSize = value; }
        }


        /// <summary>
        /// UI特效生命周期 【-1.0表示forever】 
        /// </summary>
        private float _LifeTime = -1.0f;

        private float _BeginTime = 0;
#endregion

        private List<GameObject> _EffectObjs = ObjectPool.goListPool.Create();
        private List<GameObject> _RawImageObjs = ObjectPool.goListPool.Create();
        private List<GameObject> _CameraObjs = ObjectPool.goListPool.Create();
        private GameObjResAdapter _ResLoader;

        static private float _CameraPosY = -1000;

        protected override void Awake()
        {
            if (_ResID.isZero)
            {
                return;
            }
            base.Awake();
        }
        protected override void OnDestroy()
        {
            ObjectPool.goListPool.Gabage(_EffectObjs);
            ObjectPool.goListPool.Gabage(_RawImageObjs);
            ObjectPool.goListPool.Gabage(_CameraObjs);
            base.OnDestroy();
        }

        protected override void Start()
        {
            base.Start();
            if (_PlayOnAwake)
                PlayEffect();
        }

        void Update()
        {
            if (_LifeTime < 0) return;

            if ((Time.time - _BeginTime) >= _LifeTime)
            {
                Clear();
            }
        }

        /// <summary>
        /// 清理
        /// </summary>
        public void Clear()
        {
            _LifeTime = -1.0f;
            ClearResourceReference();
            for (int i = 0; i < _EffectObjs.Count; ++i)
            {
                DestroyEffectObject(_EffectObjs[i]);
            }
            _EffectObjs.Clear();

            for (int i = 0; i < _RawImageObjs.Count; ++i)
            {
                DestroyRawImageObject(_RawImageObjs[i]);
            }
            _RawImageObjs.Clear();

            for (int i = 0; i < _CameraObjs.Count; ++i)
            {
                DestroyCameraObject(_CameraObjs[i]);
            }
            _CameraObjs.Clear();
        }

        /// <summary>
        /// 清空资源引用计数
        /// </summary>
        public void ClearResourceReference()
        {
            _ResLoader = GameObjResAdapter.Gabage(_ResLoader);
        }

        /// <summary>
        /// 播放特效
        /// </summary>
        public void PlayEffect()
        {
            if (_Simple)
                SimpleCreate();
            else
                CameraCreate();
        }

        //me lvns num=10000
        private void SimpleCreate()
        {
            GameObjResAdapter.Gabage(_ResLoader);
            _ResLoader = GameObjResAdapter.Fetch(_ResID, SimpleCreateLoadComplete);
        }

        private Canvas canvas
        {
            get
            {
                var cur = transform;
                while (cur != null)
                {
                    var c = cur.GetComponent<Canvas>();
                    if (c == null)
                        cur = cur.parent;
                    else
                        return c;
                }
                return null;
            }
        }
        private void SimpleCreateLoadComplete(Object res, ResID id)
        {
            if (this.IsDestroyed() || res == null) return;

            var effectObject = UIUtil.Instantiate(res as GameObject);
            effectObject.transform.SetParent(transform);
            effectObject.transform.localPosition = _LocalPosition;
            if (rotate) 
            {
                effectObject.transform.localRotation = Quaternion.identity;
            }
            var ps = effectObject.GetComponentInChildren<ParticleSystem>();
            if (ps == null)
            {
                throw new GuiException("[null]", string.Format("即将播放的UI粒子特效并没有[ParticleSystem]组件 ResID： \"{0}\" ", _ResID.ToString()));
            }
            int sortingLayer = 1;
            int sortingOrder = 1;
            var c = canvas;
            if (c != null)
            {
                sortingLayer = c.sortingLayerID;
                sortingOrder = c.sortingOrder + 1;
            }
            SetLayer(effectObject, LayerIndex.UIEffect);
            UIUtil.SetSortingOrder(effectObject,  sortingLayer, sortingOrder, false);

            var systems = UIUtil.GetParticleSystemListInChildren(effectObject, true);
            for (int idx = 0; idx < systems.Count; ++idx)
            {
                ParticleSystem system = systems[idx];
                system.startSpeed *= _Scale.x * PlayInterface.scaleFactor;
                system.startSize *= _Scale.x * PlayInterface.scaleFactor;
                system.gravityModifier *= _Scale.x * PlayInterface.scaleFactor;
            }
            ObjectPool.particleSystemListPool.Gabage(systems);

            _EffectObjs.Add(effectObject);
            _LifeTime = _AutoKill ? ps.duration : -1.0f;
            _BeginTime = Time.time;
        }

        private void CameraCreate()
        {
            GameObjResAdapter.Gabage(_ResLoader);
            _ResLoader = GameObjResAdapter.Fetch(_ResID, CameraCreateLoadComplete);
        }

        private void CameraCreateLoadComplete(Object res, ResID id)
        {
            if (this.IsDestroyed()) return;

            var rawObject = new GameObject("RawImage");
            rawObject.SetActive(false);
            rawObject.transform.SetParent(transform);
            if (rotate) 
            {
                rawObject.transform.localRotation = Quaternion.identity;
            }
            var rawRtt = rawObject.AddComponent<RectTransform>();
            var rawImage = rawObject.AddComponent<RawImage>();
            rawRtt.sizeDelta = new Vector2(PlayInterface.sceneSizeDelta.x , _CameraSize > 0 ? _CameraSize * 2 : GetComponent<RectTransform>().rect.size.y);
            rawObject.transform.localScale = _Scale;
            rawObject.transform.localPosition = _LocalPosition;
            rawImage.raycastTarget = false;
            if (_BlendMode == BlendMode.Additive)
                rawImage.material = new Material(PlayInterface.FindShader(UIResDefine.s_UIOneone));
            else
                rawImage.material = null;

            var effectObject = UIUtil.Instantiate(res as GameObject);
            var ps = effectObject.GetComponentInChildren<ParticleSystem>();
            if (ps == null)
            {
                throw new GuiException("[null]", string.Format("即将播放的UI粒子特效并没有[ParticleSystem]组件 ResID： \"{0}\" ", _ResID.ToString()));
            }
            SetLayer(effectObject, LayerIndex.UIEffect);
            var renderers = UIUtil.GetRendererListInChildren(effectObject, true);
            for (int idx = 0; idx < renderers.Count; idx++)
            {
                var renderer = renderers[idx];
                int materialsNumber = renderer.materials.Length;
                Material[] newMats = new Material[materialsNumber];
                for (int i = 0; i < materialsNumber; i++)
                {
                    var mat = new Material(renderer.materials[i]);

                    if (renderer.materials[i].shader.name.Contains("Add"))
                        mat.shader = PlayInterface.FindShader(UIResDefine.s_UIEffectAdditive);
                    else if (renderer.materials[i].shader.name.Contains("Alpha"))
                        mat.shader = PlayInterface.FindShader(UIResDefine.s_UIEffectAlphaBlend);

                    newMats[i] = mat;
                }
                renderer.materials = newMats;
            }
            ObjectPool.rendererListPool.Gabage(renderers);

            var cameraObject = new GameObject(UIResDefine.UIEffectCameraName);
            var camera = cameraObject.AddComponent<Camera>();
            camera.depth = 2;
            camera.clearFlags = CameraClearFlags.SolidColor;
            camera.backgroundColor = Color.clear;
            camera.orthographic = true;
            camera.nearClipPlane = -500;
            camera.farClipPlane = 500;
            camera.cullingMask = 1 << LayerIndex.UIEffect; //只渲染UIEffect层
            int width = (int)rawRtt.rect.width;
            int height = (int)rawRtt.rect.height;
            var rdTexture = RenderTexture.GetTemporary(width, height, 24, RenderTextureFormat.ARGB32);
            camera.orthographicSize = rawRtt.sizeDelta.y / 2;
            camera.targetTexture = rdTexture;
            rawImage.texture = camera.targetTexture;
            rawObject.SetActive(true);
            _CameraPosY -= rawRtt.sizeDelta.y;
            cameraObject.transform.localPosition = new Vector3(0, _CameraPosY, -100);
            _CameraPosY -= rawRtt.sizeDelta.y;
            U3DUtil.DontDestroyOnLoad(cameraObject);

            effectObject.transform.SetParent(cameraObject.transform);
            effectObject.transform.localPosition = new Vector3(0, 0, 5);

            _EffectObjs.Add(effectObject);
            _CameraObjs.Add(cameraObject);
            _RawImageObjs.Add(rawObject);

            _LifeTime = _AutoKill ? ps.duration : -1.0f;
            _BeginTime = Time.time;
        }

        private void SetLayer(GameObject obj, int layer)
        {
            for (int idx = 0; idx < obj.transform.childCount; idx++)
            {
                Transform child = obj.transform.GetChild(idx);
                child.gameObject.layer = layer;
            }
            obj.layer = layer;
        }

        private void DestroyCameraObject(GameObject camObj)
        {
            Camera cam = camObj.GetComponent<Camera>();
            if (cam && cam.targetTexture != null)
            {
                var rtt = cam.targetTexture;
                cam.targetTexture = null;
                if (rtt != null) RenderTexture.ReleaseTemporary(rtt);
            }
            U3DUtil.DestroyGameObject(camObj);
        }

        private void DestroyEffectObject(GameObject effectObj)
        {
            U3DUtil.DestroyGameObject(effectObj);
        }

        private void DestroyRawImageObject(GameObject rawImageObj)
        {
            U3DUtil.DestroyGameObject(rawImageObj);
        }
    }
}
