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
    [AddComponentMenu("YUI/YGridGroup", 13)]
    public class YGridGroup : UIBehaviour, IClearable, IPointerClickHandler
    {
        public enum Direction
        {
            Horizontal,
            Vertical
        }

        /// <summary>
        /// 行列数
        /// </summary>
        [SerializeField]
        private Vector2 _RowCols;
        public Vector2 rowCols
        {
            get { return _RowCols; }
            set { _RowCols = value; }
        }

        /// <summary>
        /// 间距
        /// </summary>
        [SerializeField]
        private Vector2 _Space;
        public Vector2 space
        {
            get { return _Space; }
            set { _Space = value; }
        }

        /// <summary>
        /// 方向
        /// </summary>
        [SerializeField]
        private Direction _Direction;
        public Direction direction
        {
            get { return _Direction; }
            set { _Direction = value; }
        }

        public enum Alignment
        {
            MidThanLeft = 1, //超出时左对齐，不超出时中间对齐
            Left = 2,
            Middle = 3
        }

        /// <summary>
        /// 对齐方式
        /// </summary>
        [SerializeField]
        private Alignment _Alignment;
        private Alignment _OriginalAligement;
        public Alignment alignment
        {
            get { return _Alignment; }
            set { _Alignment = value; }
        }

        [SerializeField]
        private Vector2 _CellSize;

        public Vector2 cellSize
        {
            get { return _CellSize; }
            set { _CellSize = value; }
        }

        private GameObject _ObjList;

        private GameObject _Contanter;

        private int _DataCount;

        private int _LimitedCount;

        /// <summary>
        /// Cell Prefab
        /// </summary>
        [SerializeField]
        private GameObject _CellPrefab;
        [DoNotToLua]
        public GameObject cellPrefab
        {
            get { return _CellPrefab; }
            set { _CellPrefab = value; }
        }
        /// <summary>
        /// 选中效果的Prefab
        /// </summary>
        [SerializeField]
        private GameObject _SelectPrefab;
        [DoNotToLua]
        public GameObject selectPrefab 
        {
            get { return _SelectPrefab; }
            set { _SelectPrefab = value; }
        }

        private List<GameObject> _CellList = ObjectPool.goListPool.Create();
        private int _SelectedCell = -1;

        /// <summary>
        /// 选中效果
        /// </summary>
        private GameObject _SelectedEff = null;

        private object _UpdateCellCaller;
        private Action<object, GameObject, int, object> _UpdateCellCallback;
        private object _UserData;
        /// <summary>
        /// 选中更改监听者
        /// </summary>
        private object _SelectChangedListener = null;
        /// <summary>
        /// 选中更改回调
        /// </summary>
        private Action<object, GameObject, int> _SelectChangedCallback = null;

        private object _ClickItemListener = null;
        private Action<object, int> _ClickItemCallback = null;

        private LuaVar _LuaArgs;

        private string _WinName = null;

        protected override void Awake()
        {
            base.Awake();
            _ObjList = new GameObject("ObjList");
            _ObjList.transform.SetParent(gameObject.transform);
            _ObjList.transform.localPosition = Vector3.zero;
            _ObjList.transform.localScale = Vector3.one;
            RectTransform rectTrans = gameObject.GetComponent<RectTransform>();
            var rtt = _ObjList.AddComponent<RectTransform>();
            rtt.anchorMax = Vector2.one;
            rtt.anchorMin = Vector2.zero;
            rtt.sizeDelta = Vector2.zero;
            rtt.anchoredPosition = Vector2.zero;

            _Contanter = new GameObject("CellContanter");
            _Contanter.transform.SetParent(_ObjList.transform);
            _Contanter.transform.localPosition = Vector3.zero;
            _Contanter.transform.localScale = Vector3.one;

            rtt = _Contanter.AddComponent<RectTransform>();
            rtt.sizeDelta = rectTrans.rect.size;
            rtt.anchorMax = Vector2.up;
            rtt.anchorMin = Vector2.up;
            rtt.pivot = Vector2.up;
            _OriginalAligement = alignment;
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
            //重置container
            _Contanter.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            for (int i = 0; i < _DataCount; ++i)
            {
                _CellList.Add(CreateCell());
            }

            var rtt = _Contanter.GetComponent<RectTransform>();
            if (rtt == null)
                rtt = _Contanter.AddComponent<RectTransform>();
            rtt.sizeDelta = gameObject.GetComponent<RectTransform>().rect.size;

            //计算当前大小最大容纳数量
            _LimitedCount = direction == Direction.Horizontal ? Mathf.FloorToInt(rtt.rect.width / (_CellSize.x + _Space.x)) * (int)_RowCols.x : Mathf.FloorToInt(rtt.rect.height / (_CellSize.y + space.y)) * (int)_RowCols.y;

            //计算实际的行列数
            _RowCols = direction == Direction.Horizontal ? new Vector2(_RowCols.x, Mathf.CeilToInt(_DataCount / _RowCols.x)) : new Vector2(Mathf.CeilToInt(_DataCount / _RowCols.y), _RowCols.y);

            if (_DataCount > _LimitedCount)
                rtt.sizeDelta = direction == Direction.Horizontal ? new Vector2(_RowCols.y * (_Space.x + _CellSize.x), rtt.sizeDelta.y) : new Vector2(rtt.sizeDelta.x, _RowCols.x * (_Space.y + _CellSize.y));

            _Alignment = _OriginalAligement;

            if (_Alignment == Alignment.MidThanLeft)
            {
                _Alignment = _DataCount > _LimitedCount ? Alignment.Left : Alignment.Middle;
            }

            UpdateMask();

            for (int i = 0; i < _DataCount; ++i)
                SetCell(_CellList[i], i);

            if (_SelectedEff != null)
            {
                _SelectedEff.transform.SetAsLastSibling();
                _SelectedEff.gameObject.SetActive(false);
            }
        }

        /// <summary>
        /// 创建Cell
        /// </summary>
        /// <returns></returns>
        private GameObject CreateCell()
        {
            GameObject cell = UIUtil.InstantiateCell(gameObject, _CellPrefab, ref _WinName);
            cell.transform.SetParent(_Contanter.transform);
            cell.transform.localScale = Vector3.one;
            cell.transform.localPosition = Vector3.zero;
            var cellRtf = cell.GetComponent<RectTransform>();
            cellRtf.anchorMax = Vector2.up;
            cellRtf.anchorMin = Vector2.up;
            cellRtf.pivot = Vector2.up;
            cell.SetActive(true);
            return cell;
        }

        /// <summary>
        /// 检查是否需要mask等组件
        /// </summary>
        private void UpdateMask()
        {
            bool needMask = _DataCount > _LimitedCount ? true : false;
            var image = _ObjList.GetComponent<YImage>();
            var mask = _ObjList.GetComponent<Mask>();
            var scrollView = _ObjList.GetComponent<YScrollRect>();
            if (needMask)
            {
                if (image == null)
                    image = _ObjList.AddComponent<YImage>();
                if (mask == null)
                    mask = _ObjList.AddComponent<Mask>();
                if (scrollView == null)
                    scrollView = _ObjList.AddComponent<YScrollRect>();
                mask.showMaskGraphic = false;
                scrollView.horizontal = _Direction == Direction.Horizontal;
                scrollView.vertical = _Direction == Direction.Vertical;
                scrollView.content = _Contanter.GetComponent<RectTransform>();
            }
            else
            {
                U3DUtil.DestroyObject(image);
                U3DUtil.DestroyObject(mask);
                U3DUtil.DestroyObject(scrollView);
            }
        }

        /// <summary>
        /// 设置Cell位置及数据
        /// </summary>
        private void SetCell(GameObject cell, int index)
        {
            // var contanterRtt = _Contanter.GetComponent<RectTransform>();
            var cellRtt = cell.GetComponent<RectTransform>();
            int cols, row; //cell所在的行列数
            if (direction == Direction.Vertical)
            {
                row = Mathf.FloorToInt(index / (int)rowCols.y); //行
                cols = index % (int)rowCols.y;  //列
            }
            else
            {
                row = index % (int)rowCols.x; //行
                cols = Mathf.FloorToInt(index / (int)rowCols.x);//列
            }

            Vector2 cellPosition = Vector2.zero;

            if (_Alignment == Alignment.Left)
            {
                cellRtt.anchorMax = Vector2.up;
                cellRtt.anchorMin = Vector2.up;
                cellRtt.pivot = Vector2.up;

                cellPosition.x = space.x * (cols + 1) + _CellSize.x * cols;
                cellPosition.y = -(space.y * (row + 1) + _CellSize.y * row);
            }
            else if (_Alignment == Alignment.Middle)
            {
                cellRtt.anchorMax = Vector2.one / 2;
                cellRtt.anchorMin = Vector2.one / 2;
                cellRtt.pivot = Vector2.one / 2;
                var correctCols = _DataCount < _RowCols.y ? _DataCount : _RowCols.y;
                var midX = 0;
                var midRow = (_RowCols.x + 1) / 2.0f - 1;
                var midY = 0;
                var midCols = (correctCols + 1) / 2.0f - 1;

                var offsetX = (cols - midCols) * (space.x + _CellSize.x);
                var offsetY = (row - midRow) * (space.y + _CellSize.y);

                cellPosition.x = midX + offsetX;
                cellPosition.y = midY - offsetY;
            }

            cellRtt.anchoredPosition = cellPosition;

            cell.transform.localScale = Vector3.one;

            if(_UpdateCellCallback != null)
            {
                _UpdateCellCallback(_UpdateCellCaller, cell, index+1, _UserData);
            }

            if (index == selectedIndex && _SelectedEff == null && _SelectPrefab != null)
            {
                BuildSelectedEff(cellRtt);
            }
        }
        public GameObject GetCellObj(int index)
        {
            if(index < 0 || index > _DataCount)
            {
                return null;
            }
            return _CellList[index];
        }
        public void UpdateList(int size, object caller, Action<object, GameObject, int, object> updateCallback)
        {
            UpdateList(size, caller, updateCallback, null);
        }

        public void UpdateList(int size, object caller, Action<object, GameObject, int, object> updateCallback, object userData)
        {
            _SelectedCell = -1;
            _DataCount = size;
            _UpdateCellCaller = caller;
            _UpdateCellCallback = updateCallback;
            _UserData = userData;
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
            _UserData = null;
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
        public void SetItemClickCallBack(object luaTable, Action<object, int> callback)
        {
            _ClickItemListener = luaTable;
            _ClickItemCallback = callback;
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
                if( value >= _CellList.Count )
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

            for (int i = 0; i < _CellList.Count; i++)
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
                        if(_ClickItemCallback != null)
                        {
                            _ClickItemCallback.Invoke(_ClickItemListener, i + 1);
                        }
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
                _SelectedEff = UIUtil.InstantiateCell(gameObject, _SelectPrefab, _Contanter.transform, ref _WinName);
                _SelectedEff.transform.localScale = Vector3.one;
                selTrans = _SelectedEff.GetComponent<RectTransform>();
                selTrans.SetSiblingIndex(selTrans.childCount -1);
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
