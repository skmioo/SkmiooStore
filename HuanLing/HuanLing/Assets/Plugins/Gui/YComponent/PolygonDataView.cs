using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnityEngine.UI
{
    /// <summary>
    /// 多边形数据图（我也不知道学名叫啥，策划也无知，所以我就自己取一个了）
    /// </summary>
    public class PolygonDataView:Graphic
    {
        [SerializeField]
        public int _Count;
        [SerializeField]
        public float[] _Prgs;
        [SerializeField]
        public float _BeginAngle;
        protected override void OnPopulateMesh(VertexHelper vh)
        {
            _Count = Math.Max(3, _Count);
            AdjustPrgArray();

            Vector2 size = rectTransform.rect.size;
            vh.Clear();

            float radiu = Math.Min(size.x, size.y) / 2;
            float spaceAngle = 360 / _Count;
            Vector2 pivot = rectTransform.pivot;
            Vector3 centre = new Vector3((0.5f - pivot.x) * size.x, (0.5f - pivot.y) * size.y);
            vh.AddVert(centre, color, new Vector2(0, 0));
            Vector3 zeroDir = Vector3.right;
            for (var idx = 0; idx < _Count; ++idx)
            {
                float angle = _BeginAngle + spaceAngle * idx;
                Vector3 dir = Quaternion.AngleAxis(angle, Vector3.forward) * zeroDir;
                Vector3 pos = centre + dir * (radiu * _Prgs[idx]);
                vh.AddVert(pos, color, new Vector2(0, 0));
                vh.AddTriangle(0, idx +1, idx == 0 ? _Count : idx);
            }
        }

        public void SetCount(int count )
        {
            if(_Count != count && count >= 3)
            {
                _Count = count;
                AdjustPrgArray();
            }
        }

        public int count { get { return _Count; } }

        public void SetProgress(int idx, float progress)
        {
            if(idx < _Prgs.Length)
            {
                _Prgs[idx] = Math.Max(0, Math.Min(progress, 1));//[0,1]之间
            }
        }

        public float GetProgress(int idx )
        {
            return idx < _Prgs.Length ? _Prgs[idx] : 0;
        }

        void AdjustPrgArray()
        {
            if (_Prgs == null || _Prgs.Length != _Count)
            {
                float[] n = new float[_Count];
                for (var i = 0; i < n.Length; ++i)
                {
                    n[i] = _Prgs != null && i < _Prgs.Length ? _Prgs[i] : 1;
                }
                _Prgs = n;
            }
        }
    }
}
