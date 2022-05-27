using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace UYMO
{
    [ExecuteInEditMode]
    public class SlicedSpriteRenderer : MonoBehaviour, ISpriteUser
    {
        public enum Anchor
        {
            Left,
            Middle,
            Right
        }
        [SerializeField]
        int _Z;
        [SerializeField]
        ResID _SpriteID;
        [SerializeField]
        float _Width;
        [SerializeField]
        float _Height;
        [SerializeField]
        Color _Color = Color.white;
        [SerializeField]
        Anchor _Anchor = Anchor.Middle;

        Sprite _Sprite;
        ISpriteHandle _SpriteHandle;
        MeshFilter _MeshFilter;
        MeshRenderer _Render;
        bool _Invalide;

        const string DefaultShaderName = "Sprites/Default";
        void Awake()
        {
            _MeshFilter = GetComponent<MeshFilter>();
            if (_MeshFilter == null)
            {
                _MeshFilter = gameObject.AddComponent<MeshFilter>();
            }
            _MeshFilter.hideFlags = HideFlags.HideInInspector;
            _Render = GetComponent<MeshRenderer>();
            if (_Render == null)
            {
                _Render = gameObject.AddComponent<MeshRenderer>();
            }
            _Render.sortingOrder = _Z;
            _Render.hideFlags = HideFlags.None;
        }
        void OnEnable()
        {
            _RefreshSprite(true);
        }
        void OnDisable()
        {
            _RefreshSprite(false);
        }
        void OnDestroy()
        {
            _RefreshSprite(false);
        }
        void Update()
        {
            if (_Invalide)
            {
                Refresh();
            }
            _Render.sortingOrder = _Z;
        }

        /// <summary>
        /// 是否渲染
        /// </summary>
        public bool visible
        {
            get { return _Render.enabled; }
            set { _Render.enabled = value; }
        }
        public ResID spriteID
        {
            get
            {
                return _SpriteID;
            }
            set
            {
                if (_SpriteID == value)
                    return;
                _SpriteID = value;
                _RefreshSprite(isActiveAndEnabled);
            }
        }
        public Anchor anchor
        {
            get
            {
                return _Anchor;
            }
            set
            {
                if (_Anchor != value)
                {
                    _Invalide = true;
                    _Anchor = value;
                }
            }
        }
        public Color color
        {
            get
            {
                return _Color;
            }
            set
            {
                if (_Color != value)
                {
                    _Color = value;
                    mesh.colors = new Color[]
                    {
                        _Color, _Color, _Color, _Color,
                        _Color, _Color, _Color, _Color,
                        _Color, _Color, _Color, _Color,
                        _Color, _Color, _Color, _Color
                    };
                }
            }
        }
        public float nativeWidth
        {
            get
            {
                return _Sprite ? _Sprite.rect.width / pixelPerUnit : 0;
            }
        }
        public float nativeHeight
        {
            get
            {
                return _Sprite ? _Sprite.rect.height / pixelPerUnit : 0;
            }
        }
        public int z
        {
            get
            {
                return _Z;
            }
            set
            {
                if (_Z != value)
                {
                    _Invalide = true;
                    _Z = value;
                    _Render.sortingOrder = value;
                }
            }
        }
        /// <summary>
        /// 单位宽
        /// </summary>
        public float width
        {
            get { return _Width; }
            set
            {
                if (_Width != value)
                {
                    _Invalide = true;
                    _Width = value;
                }
            }
        }
        /// <summary>
        /// 单位高
        /// </summary>
        public float height
        {
            get { return _Height; }
            set
            {
                if (_Height != value)
                {
                    _Invalide = true;
                    _Height = value;
                }
            }
        }
        public void SetNativeSize()
        {
            width = nativeWidth;
            height = nativeHeight;
        
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
        private void _RefreshSprite(bool isLoad)
        {
            if (isLoad)
            {
                if (_SpriteHandle != null)
                {
                    if (_SpriteHandle.id == _SpriteID)
                    {
                        return;
                    }
                    var mat = material;
                    if (mat != null)
                    {
                        mat.mainTexture = null;
                    }
                    _SpriteHandle = PlayInterface.UnloadSprite(_SpriteHandle);
                }
                if (Application.isPlaying)
                {
                    _SpriteHandle = PlayInterface.LoadSprite(_SpriteID, _HandleSpriteLoaded);
                }
                else
                {
                    sprite = PlayInterface.GetResInEditor(_SpriteID, typeof(Sprite)) as Sprite;
                    var mat = material;
                    if (mat == null)
                    {
                        mat = new Material(Shader.Find(DefaultShaderName));
                        material = mat;
                    }
                    mat.mainTexture = sprite == null ? null : sprite.texture;
                }
            }
            else
            {
                var mat = material;
                if (mat != null)
                {
                    mat.mainTexture = null;
                }
                _SpriteHandle = PlayInterface.UnloadSprite(_SpriteHandle);
            }
        }
        private void _HandleSpriteLoaded(ISpriteHandle h)
        {
            _SpriteHandle = h;
            sprite = h.sprite;
            material = h.normalMat;
            material.mainTexture = sprite == null ? null : sprite.texture;
        }
        private Sprite sprite
        {
            get
            {
                return _Sprite;
            }
            set
            {
                if (_Sprite != value)
                {
                    _Invalide = true;
                    _Sprite = value;
                    if (width == 0)
                    {
                        pixelWidth = _Sprite ? _Sprite.rect.width : 0;
                    }
                    if (height == 0)
                    {
                        pixelHeight = _Sprite ? _Sprite.rect.height : 0;
                    }
                }
            }
        }

        private float pixelPerUnit
        {
            get
            {
                return sprite ? sprite.pixelsPerUnit : 1;
            }
        }
        /// <summary>
        /// 像素宽
        /// </summary>
        private float pixelWidth
        {
            get
            {
                return width * pixelPerUnit;
            }
            set
            {
                width = value / pixelPerUnit;
            }
        }
        /// <summary>
        /// 像素高
        /// </summary>
        private float pixelHeight
        {
            get
            {
                return height * pixelPerUnit;
            }
            set
            {
                height = value / pixelPerUnit;
            }
        }
        public void Refresh()
        {
            _Invalide = false;
            //if(sprite)
            {
                Vector4 bord = sprite ? sprite.border : Vector4.zero;
                float pt = bord.w;
                float pl = bord.x;
                float pb = bord.y;
                float pr = bord.z;

                float t = bord.w / pixelPerUnit;
                float l = bord.x / pixelPerUnit;
                float b = bord.y / pixelPerUnit;
                float r = bord.z / pixelPerUnit;

                float xoffset = 0;
                switch (_Anchor)
                {
                    case Anchor.Left: xoffset = width / 2; break;
                    case Anchor.Middle: xoffset = 0; break;
                    case Anchor.Right: xoffset = -width / 2; break;

                }

                float lr = l + r;
                if (l + r > width)
                {
                    l = l / lr * width;
                    r = r / lr * width;
                }
                float tb = t + b;
                if (tb > height)
                {
                    t = t / tb * height;
                    b = b / tb * height;
                }

                float minX = -width / 2 + xoffset;
                float lx = minX + l;
                float maxX = width / 2 + xoffset;
                float rx = maxX - r;

                float minY = -height / 2;
                float by = minY + b;
                float maxY = height / 2;
                float ty = maxY - t;

                mesh.vertices = new Vector3[]
                {
                    new Vector3(minX, maxY), new Vector3(lx, maxY), new Vector3(rx, maxY), new Vector3(maxX, maxY),
                    new Vector3(minX, ty), new Vector3(lx, ty), new Vector3(rx, ty), new Vector3(maxX, ty),
                    new Vector3(minX, by), new Vector3(lx, by), new Vector3(rx, by), new Vector3(maxX, by),
                    new Vector3(minX, minY), new Vector3(lx, minY), new Vector3(rx, minY), new Vector3(maxX, minY),
                };
                mesh.triangles = new int[]
                {
                    0,1,5,
                    0,5,4,
                    1,2,6,
                    1,6,5,
                    2,3,7,
                    2,7,6,
                    4,5,9,
                    4,9,8,
                    5,6,10,
                    5,10,9,
                    6,7,11,
                    6,11,10,
                    8,9,13,
                    8,13,12,
                    9,10,14,
                    9,14,13,
                    10,11,15,
                    10,15,14
                };

                Rect rect = _Sprite ? _Sprite.rect : new Rect();
                float spriteWidth = rect.width;
                float spriteHeight = rect.height;

                float minu = 0;
                float lu = pl / spriteWidth;
                float ru = (spriteWidth - pr) / spriteWidth;
                float maxu = 1;

                float minv = 0;
                float bv = pb / spriteHeight;
                float tv = (spriteHeight - pt) / spriteHeight;
                float maxv = 1;

                if (sprite != null && sprite.texture != null)
                {
                    Rect offRect = sprite.rect;
                    if (offRect.width != sprite.texture.width || offRect.height != sprite.texture.height)
                        offRect = sprite.textureRect;
                    float texW = sprite.texture.width;
                    float texH = sprite.texture.height;
                    float uOffset = offRect.x / texW;
                    float vOffset = offRect.y / texH;
                    float uFactor = offRect.width / texW;
                    float vFactor = offRect.height / texH;
                    minu = uOffset + minu * uFactor;
                    lu = uOffset + lu * uFactor;
                    ru = uOffset + ru * uFactor;
                    maxu = uOffset + maxu * uFactor;
                    minv = vOffset + maxv * vFactor;
                    tv = vOffset + tv * vFactor;
                    bv = vOffset + bv * vFactor;
                    maxv = vOffset + maxv * vFactor;
                }

                mesh.uv = new Vector2[]
                {
                    new Vector2(minu, maxv), new Vector2(lu, maxv), new Vector2(ru, maxv), new Vector2(maxu, maxv),
                    new Vector2(minu, tv), new Vector2(lu, tv), new Vector2(ru, tv), new Vector2(maxu, tv),
                    new Vector2(minu, bv), new Vector2(lu, bv), new Vector2(ru, bv), new Vector2(maxu, bv),
                    new Vector2(minu, minv), new Vector2(lu, minv), new Vector2(ru, minv), new Vector2(maxu, minv),
                };

                //material.mainTexture = sprite ? sprite.texture : null;
                _Render.sortingOrder = _Z;
            }
        }
        private Mesh mesh
        {
            get
            {
                if (!Application.isPlaying)
                {
                    if (_MeshFilter.sharedMesh == null)
                    {
                        _MeshFilter.sharedMesh = new Mesh();
                    }
                    return _MeshFilter.sharedMesh;
                }
                else
                {
                    if (_MeshFilter.mesh == null)
                    {
                        _MeshFilter.mesh = new Mesh();
                    }
                    return _MeshFilter.mesh;
                }
            }
        }
        private Material material
        {
            get
            {
                if (!Application.isPlaying)
                {
                    return _Render ? _Render.sharedMaterial : null;
                }
                else
                {
                    return _Render ? _Render.material : null;
                }
            }
            set
            {
                if (value == null)
                    value = new Material(Shader.Find(DefaultShaderName));
                if (_Render)
                {
                    if (!Application.isPlaying)
                    {
                        _Render.sharedMaterial = value;
                    }
                    else
                    {
                        _Render.material = value;
                    }
                }
            }
        }
    }
}
