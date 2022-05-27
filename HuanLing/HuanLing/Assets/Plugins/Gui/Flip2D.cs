using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using SLua;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace UYMO
{
    [SLua.CustomLuaClass]
    public class Flip2D : MonoBehaviour
    {
        [SerializeField]
        private Transform _Face;//正面
        [DoNotToLua]
        public Transform face
        {
            get { return _Face; }
            set { _Face = value; }
        }
        [SerializeField]
        private Transform _Back;//背面
        [DoNotToLua]
        public Transform back
        {
            get { return _Back; }
            set { _Back = value; }
        }
        [SerializeField][HideInInspector]
        private bool _IsFaceUp;
        [SerializeField][HideInInspector]
        private float _TurnCost = 1.0f;//翻转耗时

        private float _TurnBegin = 0;

        public bool isTurnOver{ 
            get{
                return (_TurnBegin == 0);
            }
        }
        /// <summary>
        /// 是否下面朝上
        /// </summary>
        public bool isFaceUp
        {
            get
            {
                return _IsFaceUp;
            }
            set
            {
                if(_IsFaceUp != value)
                {
                    _IsFaceUp = value;
                    _TurnBegin = Time.time;
                }
            }
        }

        public float turnCost
        {
            get
            {
                return _TurnCost;
            }
            set
            {
                if(_TurnCost != value)
                {
                    _TurnCost = Math.Max(0.001f, value);
                }
            }
        }

        void Start()
        {
            Transform up = _IsFaceUp ? _Face : _Back;
            Transform down = _IsFaceUp ? _Back : _Face;
            down.rotation = Quaternion.AngleAxis(90, Vector3.up);
            up.rotation = Quaternion.AngleAxis(0, Vector3.up);
        }

        void Update()
        {
            if(_TurnBegin > 0 )
            {
                float pass = Time.time - _TurnBegin;
                pass = Mathf.Min(pass, _TurnCost);
                float ratio = pass / _TurnCost;

                float upCur = 90;
                float upTarget = 0;

                float downCur = 0;
                float downTarget = 90;

                Transform up = _IsFaceUp ? _Face : _Back;
                Transform down = _IsFaceUp ? _Back : _Face;

                if (ratio <= 0.5f && down)
                {//先把上边的翻下去
                    down.rotation = Quaternion.AngleAxis(downCur + (downTarget - downCur) * ratio * 2, Vector3.up);
                }
                if (ratio >= 0.5f && up)
                {//再把下边的翻上来
                    down.rotation = Quaternion.AngleAxis(90, Vector3.up);
                    up.rotation = Quaternion.AngleAxis(upCur + (upTarget - upCur) * (ratio - 0.5f) * 2, Vector3.up);
                }
                

                if(pass >= _TurnCost)
                {
                    _TurnBegin = 0;
                    up.rotation = Quaternion.AngleAxis(0, Vector3.up);
                }
            }
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(Flip2D))]
    public class Flip2DEditor:Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var flip = (Flip2D)target;
            flip.turnCost = EditorGUILayout.FloatField("Turn Cost", flip.turnCost);
            flip.isFaceUp = EditorGUILayout.Toggle("Is Face Up", flip.isFaceUp);
        }
    }
#endif
}
