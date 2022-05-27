using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using SLua;
using System.Collections.Generic;
using System;

namespace UYMO
{
    /// <summary>
    /// 抽奖时的循环展示
    /// </summary>
    [CustomLuaClass]
    [AddComponentMenu("YUI/YNeonRolling", 24)]
    public class YNeonRolling : UIBehaviour
    {
        [SerializeField]
        public Transform CellEffect;
        /// <summary>
        /// 基础间隔，为多少帧显示下一效果
        /// </summary>
        [SerializeField]
        public int BasicInterval = 10;
        /// <summary>
        /// 不是总时长，只是中间匀速段的持续时间
        /// </summary>
        [SerializeField]
        public float RollingTime = 1;
        /// <summary>
        /// 起始隔间的速率，(>0 && <= 1)
        /// </summary>
        [SerializeField]
        public float StartRate = 1;
        /// <summary>
        /// 结束隔间的速率，(>0 && <= 1)
        /// </summary>
        [SerializeField]
        public float EndRate = 1;

        private enum State
        {
            None,
            Start,
            Center,
            End,
        }
        private List<Transform> _ListCells;
        private int _OverIdx;
        private int _CurrIdx;
        private int _StartIdx;
        private int _ChangedSpet = 0;
        private float _CurrSpet = 0;
        private float _CurrTime = 0;
        private State _State;
        private LuaTable _LuaTable;
        private Action<LuaTable, GameObject, int> _LuaCallback;

        protected override void Awake()
        {
            base.Awake();
            _ListCells = new List<Transform>();
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                _ListCells.Add(child);
            }
        }

        void FixedUpdate()
        {
            if (_State == State.None) return;
            if (_State == State.Start)
            {
                if (_CurrSpet >= _ChangedSpet)
                {
                    if (_ChangedSpet > 1)
                    {
                        _ChangedSpet--;
                    }
                    else
                    {
                        _State = State.Center;
                    }
                    _CurrSpet = 0;
                    SetEffect();
                }
                else
                {
                    _CurrSpet += StartRate;
                }
            }
            else if (_State == State.Center)
            {
                _CurrTime += Time.fixedDeltaTime;
                if (_CurrTime >= RollingTime)
                {
                    _State = State.End;
                }
                SetEffect();
            }
            else if (_State == State.End)
            {
                if (_CurrSpet >= _ChangedSpet)
                {
                    if (_ChangedSpet < BasicInterval)
                    {
                        _ChangedSpet++;
                    }
                    else
                    {
                        if (_CurrIdx == _OverIdx)
                        {
                            _State = State.None;
                            if (_LuaTable != null && _LuaCallback != null)
                            {
                                _LuaCallback(_LuaTable, _ListCells[_CurrIdx].gameObject, _OverIdx + 1);
                            }
                            return;
                        }
                    }
                    _CurrSpet = 0;
                    SetEffect();
                }
                else
                {
                    _CurrSpet += EndRate;
                }
            }
        }

        public void Clear()
        {
            _ListCells.Clear();
        }

        /// <summary>
        /// 开始循环
        /// </summary>
        /// <param name="luaStartIdx">lua，起始索引</param>
        /// <param name="luaOverIdx">lua，结束索引</param>
        /// <param name="isBeginning">是否从头开始循环</param>
        /// <param name="lua"></param>
        /// <param name="callBack"></param>
        public void StartRolling(int luaStartIdx, int luaOverIdx, bool isBeginning = false, LuaTable lua = null, Action<LuaTable, GameObject, int> callBack = null)
        {
            _ChangedSpet = BasicInterval;
            _OverIdx = luaOverIdx - 1;
            _CurrIdx = luaStartIdx - 1;
            _StartIdx = isBeginning ? _StartIdx = 0 : _StartIdx = _CurrIdx;
            _LuaTable = lua;
            _LuaCallback = callBack;
            _CurrSpet = 0;
            _CurrTime = 0;
            _State = State.Start;
        }

        public void OverImmediately(int luaOverIdx, LuaTable lua = null, Action<LuaTable, GameObject, int> callBack = null)
        {
            _State = State.None;
            CellEffect.SetParent(_ListCells[luaOverIdx - 1]);
            CellEffect.localPosition = Vector3.zero;
            if (lua != null && callBack != null)
            {
                callBack(lua, _ListCells[luaOverIdx - 1].gameObject, luaOverIdx);
            }
        }

        private void SetEffect()
        {
            _CurrIdx = (_CurrIdx + 1 >= _ListCells.Count) ? _StartIdx : _CurrIdx + 1;
            CellEffect.SetParent(_ListCells[_CurrIdx]);
            CellEffect.localPosition = Vector3.zero;
        }

    }
}
