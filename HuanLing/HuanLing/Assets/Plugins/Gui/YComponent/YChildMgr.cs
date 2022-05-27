using System;
using System.Collections.Generic;
using UYMO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using SLua;

namespace UYMO
{
    [CustomLuaClass]
    [AddComponentMenu("YUI/YChildMgr", 14)]
    public class YChildMgr : UIBehaviour, IClearable, IPointerClickHandler
    {
        private int _DataCount;

        private int _LimitedCount;

        /// <summary>
        /// Cell Prefab
        /// </summary>
        [SerializeField]
        private GameObject _CellPrefab;
        /// <summary>
        /// 选中效果的Prefab
        /// </summary>
        [SerializeField]
        private GameObject _SelectPrefab;

        private List<GameObject> _CellList = ObjectPool.goListPool.Create();
        private int _SelectedCell = -1;

        /// <summary>
        /// 选中效果
        /// </summary>
        private GameObject _SelectedEff = null;

        private object _UpdateCellCaller;
        private Action<object, GameObject, int> _UpdateCellCallback;

        /// <summary>
        /// 选中更改监听者
        /// </summary>
        private object _SelectChangedListener = null;
        /// <summary>
        /// 选中更改回调
        /// </summary>
        private Action<object, GameObject, int> _SelectChangedCallback = null;

        private LuaVar _LuaArgs;

        private string _WinName;

        protected override void Awake()
        {
            base.Awake();
        }
        protected override void OnDestroy()
        {
            ObjectPool.goListPool.Gabage(_CellList);
            base.OnDestroy();
        }

        private void InitContanter()
        {
            //清理所有cell
            ClearCells();
            
            for (int i = 0; i < _DataCount; ++i)
            {
                _CellList.Add(CreateCell());
            }

            for (int i = 0; i < _DataCount; ++i)
                SetCell(_CellList[i], i);
        }

        /// <summary>
        /// 创建Cell
        /// </summary>
        /// <returns></returns>
        private GameObject CreateCell()
        {
            GameObject cell = UIUtil.InstantiateCell(gameObject, _CellPrefab, ref _WinName);
            cell.transform.SetParent(transform);
            cell.transform.localScale = Vector3.one;
            var cellRtf = cell.GetComponent<RectTransform>();
            cellRtf.anchorMax = Vector2.up;
            cellRtf.anchorMin = Vector2.up;
            cellRtf.pivot = Vector2.up;
            return cell;
        }

        /// <summary>
        /// 设置Cell位置及数据
        /// </summary>
        private void SetCell(GameObject cell, int index)
        {
            var cellRtt = cell.GetComponent<RectTransform>();

            if (_UpdateCellCallback != null)
            {
                _UpdateCellCallback(_UpdateCellCaller, cell, index + 1);
            }

            if (index == selectedIndex && _SelectedEff == null && _SelectPrefab != null)
            {
                BuildSelectedEff(cellRtt);
            }
        }

        public void UpdateList(int size, object caller, Action<object, GameObject, int> updateCallback)
        {
            _SelectedCell = -1;
            _DataCount = size;
            _UpdateCellCaller = caller;
            _UpdateCellCallback = updateCallback;
            InitContanter();
        }

        /// <summary>
        /// 清理ObjList
        /// </summary>
        public void Clear()
        {
            ClearCells();
            _UpdateCellCaller = null;
            _UpdateCellCallback = null;
            _SelectedCell = -1;
            _DataCount = 0;
            _LuaArgs = null;
        }
        private void ClearCells()
        {
            for (int i = 0; i < _CellList.Count; ++i)
            {
                UIUtil.GabageCell(_CellList[i]);
            }
            _CellList.Clear();
            _SelectedEff = UIUtil.GabageCell(_SelectedEff);
        }
        #region 选中相关功能
        /// <summary>
        /// 设置选中更改回调
        /// </summary>
        /// <param name="luaTable">lua对象，在lua中注册时，需要传值，回调函数中的index是从1开始的</param>
        /// <param name="callback">回调函数，参数：lua对象，cell对象，cell索引</param>
        public void SetSelectChangedCallBack(object luaTable, Action<object, GameObject, int> callback)
        {
            _SelectChangedListener = luaTable;
            _SelectChangedCallback = callback;
        }
        /// <summary>
        /// 当前选中的Cell index,未选中返回-1 从0开始
        /// </summary>
        public int selectedIndex
        {
            get { return _SelectedCell; }
            set
            {
                if (_SelectedCell == value)
                    return;
                if (value >= _CellList.Count)
                    return;

                GameObject cell = _CellList[value];
                _SelectedCell = value;

                var trans = cell.GetComponent<RectTransform>();
                BuildSelectedEff(trans);

                if (_SelectChangedCallback != null)
                {
                    _SelectChangedCallback.Invoke(_SelectChangedListener, cell, _SelectedCell + 1);
                }
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left)
                return;

            for (int i = 0; i <= _CellList.Count; ++i)
            {
                var cell = _CellList[i];
                if (cell != null)
                {
                    var trans = cell.GetComponent<RectTransform>();
                    bool pressCell = RectTransformUtility.RectangleContainsScreenPoint(trans, eventData.pressPosition, eventData.pressEventCamera); //按下位置是否在Cell上
                    bool upCell = RectTransformUtility.RectangleContainsScreenPoint(trans, eventData.position, eventData.pressEventCamera);         //抬起位置是否在Cell上
                    if (pressCell != upCell)
                    {//按下和抬起不在同一个Cell上
                        break;
                    }
                    else if (pressCell && upCell)
                    {
                        selectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void BuildSelectedEff(RectTransform selectedCellRtt)
        {
            if (_SelectPrefab == null)
                return;

            RectTransform selTrans;
            if (_SelectedEff == null)
            {
                _SelectedEff = UIUtil.InstantiateCell(gameObject, _SelectPrefab, transform, ref _WinName);
                _SelectedEff.transform.localScale = Vector3.one;
                selTrans = _SelectedEff.GetComponent<RectTransform>();
                selTrans.SetSiblingIndex(0);
            }
            else
            {
                selTrans = _SelectedEff.GetComponent<RectTransform>();
            }
            _SelectedEff.gameObject.SetActive(true);

            selTrans.anchorMax = selectedCellRtt.anchorMax;
            selTrans.anchorMin = selectedCellRtt.anchorMin;
            selTrans.pivot = selectedCellRtt.pivot;
            selTrans.anchoredPosition = selectedCellRtt.anchoredPosition;
        }
        #endregion
    }
}
