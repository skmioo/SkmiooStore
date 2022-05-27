using System;
using SLua;
using System.Collections.Generic;
using UnityEngine.UI;
using UYMO;

namespace UnityEngine.UI
{
    [CustomLuaClass]
    [Serializable]
    [ExecuteInEditMode]
    public class UVImage : YMaskableGraphic, ISpriteUser
    {
        [SerializeField]
        private Vector2 _Center = Vector2.zero;
        [SerializeField]
        private float _Orient = 0.0f;
        [SerializeField]
        private Vector2 _Scale = Vector2.one;
        [SerializeField]
        private Rect _SubRect = new Rect(0.0f, 0.0f, 1.0f, 1.0f);
        [SerializeField]
        private ResID _ImageID = ResID.zero;

        private ISpriteHandle _SpriteHandle;
        private Texture _NativeTexture;

#if UNITY_EDITOR
        [DoNotToLua]
        public bool modified { get; set; }
#endif

        protected override void OnEnable()
        {
            base.OnEnable();
            _SynImage(true);
        }
        protected override void OnDisable()
        {
            _SynImage(false);
            base.OnDisable();
        }
        protected override void OnDestroy()
        {
            _SynImage(false);
            base.OnDestroy();
        }
        private void _SynImage(bool isEnabled)
        {
            _NativeTexture = null;
            _SpriteHandle = PlayInterface.UnloadSprite(_SpriteHandle);
            if (isEnabled)
            {
                if (_ImageID.valid)
                {
                    _SpriteHandle = PlayInterface.LoadSprite(_ImageID, _HandleSpriteLoaded);
                }
                SetAllDirty();
            }
#if UNITY_EDITOR
            modified = true;
#endif
        }
        private void _HandleSpriteLoaded(ISpriteHandle handle)
        {
            _SpriteHandle = handle;
            var sp = _SpriteHandle.sprite;
            if (sp != null)
            {
                _NativeTexture = sp.texture;
                material = _SpriteHandle.normalMat;
                if (_NativeTexture != null && _NativeTexture.width > 0 && _NativeTexture.height > 0)
                {
                    var rc = sp.rect;
                    _SubRect.x = rc.x / _NativeTexture.width;
                    _SubRect.y = rc.y / _NativeTexture.height;
                    _SubRect.width = rc.width / _NativeTexture.width;
                    _SubRect.height = rc.height / _NativeTexture.height;
                }
                SetAllDirty();
#if UNITY_EDITOR
                modified = true;
#endif
            }
        }
        [DoNotToLua]
        public override Texture mainTexture
        {
            get
            {
                if (_NativeTexture != null)
                {
                    return _NativeTexture;
                }
                return s_WhiteTexture;
            }
        }

        public override Color color
        {
            get
            {
                return base.color;
            }
            set
            {
                if (base.color != value)
                {
                    base.color = value;
#if UNITY_EDITOR
                    modified = true;
#endif
                }
            }
        }

        /// <summary>
        /// implement ISpriteUser
        /// </summary>
        public bool imageReady
        {
            get { return _SpriteHandle == null || _SpriteHandle.ready; }
        }
        /// <summary>
        /// implement ISpriteUser
        /// </summary>
        public ResID[] imageHold
        {
            get
            {
                return _SpriteHandle == null ? null : new ResID[] { _SpriteHandle.id };
            }
        }

        /// <summary>
        /// 当前使用的纹理，可以直接设置外部的纹理
        /// </summary>
        public Texture texture
        {
            get { return _NativeTexture; }
            set
            {
                if (_NativeTexture == value)
                    return;
                _SynImage(false);
                _ImageID = ResID.zero;
                _NativeTexture = value;
                SetAllDirty();
#if UNITY_EDITOR
                modified = true;
#endif
            }
        }

        /// <summary>
        /// 当前使用的图片id，如果使用的是外部直接设置的纹理，返回zero
        /// </summary>
        public ResID imageID
        {
            get { return _ImageID; }
            set
            {
                if (_ImageID == value)
                    return;
                _ImageID = value;
                _SynImage(isActiveAndEnabled);
            }
        }

        /// <summary>
        /// 使用纹理的子部分，默认全部
        /// </summary>
        public Rect subRect
        {
            get { return _SubRect; }
            set
            {
                if (_SubRect != value)
                {
                    _SubRect = value;
                    SetAllDirty();
#if UNITY_EDITOR
                    modified = true;
#endif
                }
            }
        }

        public Rect subRectInPixel
        {
            get
            {
                if (_NativeTexture == null)
                    return new Rect(0.0f, 0.0f, 0.0f, 0.0f);
                var rc = new Rect(_SubRect.x * _NativeTexture.width, _SubRect.y * _NativeTexture.height, _SubRect.width * _NativeTexture.width, _SubRect.height * _NativeTexture.height);
                return MathUtil.Floor(rc);
            }
            set
            {
                if (_NativeTexture == null)
                    return;
                var rc = MathUtil.Floor(value);
                var old = subRectInPixel;
                if (old != rc)
                {
                    _SubRect.x = value.x / _NativeTexture.width;
                    _SubRect.y = value.y / _NativeTexture.height;
                    _SubRect.width = value.width / _NativeTexture.width;
                    _SubRect.height = value.height / _NativeTexture.height;
                    SetAllDirty();
#if UNITY_EDITOR
                    modified = true;
#endif
                }
            }
        }

        public Vector2 centerInPixel
        {
            get
            {
                if (_NativeTexture == null)
                    return Vector2.zero;
                return MathUtil.Floor(new Vector2(_Center.x * _NativeTexture.width, _Center.y * _NativeTexture.height));
            }
            set
            {
                if (_NativeTexture == null)
                    return;
                var old = centerInPixel;
                var v = MathUtil.Floor(value);
                if (old != v)
                {
                    SetRotateUV(new Vector2(value.x / _NativeTexture.width, value.y / _NativeTexture.height), _Orient);
                }
            }
        }
        public Vector2 center
        {
            get { return _Center; }
            set
            {
                SetRotateUV(value, _Orient);
            }
        }

        public float centerX
        {
            get { return _Center.x; }
            set
            {
                SetRotateUV(new Vector2(value, _Center.y), _Orient);
            }
        }

        public float centerY
        {
            get { return _Center.y; }
            set
            {
                SetRotateUV(new Vector2(_Center.x, value), _Orient);
            }
        }

        public float orient
        {
            get { return _Orient; }
            set
            {
                SetRotateUV(_Center, value);
            }
        }

        public float scaleX
        {
            get { return _Scale.x; }
            set
            {
                SetScale(value, _Scale.y);
            }
        }
        public float scaleY
        {
            get { return _Scale.y; }
            set
            {
                SetScale(_Scale.x, value);
            }
        }
        public Vector2 scale
        {
            get { return _Scale; }
            set
            {
                SetScale(value.x, value.y);
            }
        }

        /// <summary>
        /// 旋转计算(归一化), 左下角 0,0 右上 1，1
        /// </summary>
        /// <param name="aCenter">中心点</param>
        /// <param name="aOrient">旋转</param>
        public void SetRotateUV(Vector2 aCenter, float aOrient)
        {
            if (aCenter == _Center && _Orient == aOrient)
                return;
            _Center = aCenter;
            _Orient = aOrient;
            SetAllDirty();
#if UNITY_EDITOR
            modified = true;
#endif
        }

        /// <summary>
        /// 设置缩放
        /// </summary>
        /// <param name="aScaleX"></param>
        /// <param name="aScaleY"></param>
        public void SetScale(float aScaleX, float aScaleY)
        {
            aScaleX = Mathf.Clamp(aScaleX, 0.0f, 100.0f);
            aScaleY = Mathf.Clamp(aScaleY, 0.0f, 100.0f);
            if (_Scale.x == aScaleX && _Scale.y == aScaleY)
            {
                return;
            }
            _Scale.Set(aScaleX, aScaleY);
            SetAllDirty();
#if UNITY_EDITOR
            modified = true;
#endif
        }


        protected override void OnPopulateMesh(VertexHelper vh)
        {
            vh.Clear();
            if (_NativeTexture == null)
            {//没有图片
                return;
            }

            float texW = _NativeTexture.width * _SubRect.width;
            float texH = _NativeTexture.height * _SubRect.height;
            float rectW = rectTransform.sizeDelta.x;
            float rectH = rectTransform.sizeDelta.y;
            if (texW <= 0.0f || texH <= 0.0f || rectW <= 0.0f || rectH <= 0.0f)
            {//尺寸为0
                return;
            }
            float ratioX = _Scale.x * rectW / 2 / texW;
            float ratioY = _Scale.y * rectH / 2 / texH;
            var ratio = new Vector2(ratioX, ratioY);

            var o1 = _Center - ratio;
            var o2 = _Center + new Vector2(-ratio.x, ratioY);
            var o3 = _Center + ratio;
            var o4 = _Center + new Vector2(ratio.x, -ratioY);

            o1 = CalculateRotatePt(_Center, o1, -_Orient, true);
            o2 = CalculateRotatePt(_Center, o2, -_Orient, true);
            o3 = CalculateRotatePt(_Center, o3, -_Orient, true);
            o4 = CalculateRotatePt(_Center, o4, -_Orient, true);

            var pivot = rectTransform.pivot;
            vh.Clear();
            vh.AddVert(new Vector3(-pivot.x * rectW, -pivot.y * rectH), color, o1);
            vh.AddVert(new Vector3(-pivot.x * rectW, (1 - pivot.y) * rectH), color, o2);
            vh.AddVert(new Vector3((1 - pivot.x) * rectW, (1 - pivot.y) * rectH), color, o3);
            vh.AddVert(new Vector3((1 - pivot.x) * rectW, -pivot.y * rectH), color, o4);
            vh.AddTriangle(0, 1, 2);
            vh.AddTriangle(2, 3, 0);
        }

        /// <summary>
        /// 获取相对UVImage的center的偏移
        /// </summary>
        /// <param name="uv">在地图（纹理）上的绝对uv（归一化）</param>
        /// <returns>相对center的像素级偏移（已旋转）</returns>
        public Vector2 ToRotateRelativePixel(Vector2 uv)
        {
            uv = ToRotateRelativeUV(uv);
            uv.x *= rectTransform.sizeDelta.x;
            uv.y *= rectTransform.sizeDelta.y;
            return uv;
        }
        /// <summary>
        /// 获取相对UVImage的center的uv偏移
        /// </summary>
        /// <param name="uv">在地图（纹理）上的绝对uv（归一化）</param>
        /// <returns>相对center的uv偏移（已旋转）</returns>
        public Vector2 ToRotateRelativeUV(Vector2 uv)
        {
            var offset = uv - _Center;
            var polar = MathUtil.Cartesian2polar(offset.x, offset.y);
            polar.x += _Orient * Mathf.Deg2Rad;
            return MathUtil.Polar2cartesian(polar.x, polar.y);
        }

        private Vector2 ToRotateUV(Vector2 uv)
        {
            return ToRotateRelativeUV(uv) + _Center;
        }

        /// <summary>
        /// 绕圆心旋转一个角度后新的位置（归一化)
        /// </summary>
        /// <param name="aCenter"></param>
        /// <param name="point"></param>
        /// <param name="angle"></param>
        /// <returns></returns>
        private Vector2 CalculateRotatePt(Vector2 aCenter, Vector2 point, float angle, bool clamp)
        {
            Vector2 ret = ToRotateUV(point);
            ret.x = _SubRect.x + _SubRect.width * ret.x;
            ret.y = _SubRect.y + _SubRect.height * ret.y;
            if (clamp)
            {
                ret.x = Mathf.Clamp(ret.x, _SubRect.x, _SubRect.xMax);
                ret.y = Mathf.Clamp(ret.y, _SubRect.y, _SubRect.yMax);
            }
            return ret;

            //var ret = point - aCenter;
            //float length = ret.magnitude;

            //float x1;
            //float y1;
            //float factor = Mathf.Deg2Rad;
            //float startAngle = Mathf.Atan2(ret.y, ret.x) * Mathf.Rad2Deg;
            //if (ret.x >= 0 && ret.y >= 0)
            //{
            //    x1 = length * Mathf.Cos((startAngle + angle) * factor) + aCenter.x;
            //    y1 = length * Mathf.Sin((startAngle + angle) * factor) + aCenter.y;
            //}
            //else if (ret.y >= 0 && ret.x <= 0)
            //{
            //    x1 = length * Mathf.Cos((startAngle + angle) * factor) + aCenter.x;
            //    y1 = length * Mathf.Sin((startAngle + angle) * factor) + aCenter.y;
            //}
            //else if (ret.x <= 0 && ret.y <= 0)
            //{
            //    x1 = length * Mathf.Cos((startAngle + 360 + angle) * factor) + aCenter.x;
            //    y1 = length * Mathf.Sin((startAngle + 360 + angle) * factor) + aCenter.y;
            //}
            //else
            //{
            //    x1 = length * Mathf.Cos((startAngle + 360 + angle) * factor) + aCenter.x;
            //    y1 = length * Mathf.Sin((startAngle + 360 + angle) * factor) + aCenter.y;
            //}
            //x1 = _SubRect.x + _SubRect.width * x1;
            //y1 = _SubRect.y + _SubRect.height * y1;
            //if (clamp)
            //{
            //    x1 = Mathf.Clamp(x1, _SubRect.x, _SubRect.xMax);
            //    y1 = Mathf.Clamp(y1, _SubRect.y, _SubRect.yMax);
            //}
            //return new Vector2(x1, y1);
        }
    }
}

