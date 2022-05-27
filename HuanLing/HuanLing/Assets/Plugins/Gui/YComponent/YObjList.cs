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
    [AddComponentMenu("YUI/YObjList", 12)]
    public class YObjList : UIBehaviour, IClearable, IGameObjResAcceptor
    {
        public enum Direction
        {
            Horizontal,
            Vertical
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
        private Vector2 _CellSize = new Vector2(82, 82);

        public Vector2 cellSize
        {
            get { return _CellSize; }
            set { _CellSize = value; }
        }

        [SerializeField]
        private bool _CellNativeSize;

        public bool cellNativeSize
        {
            get { return _CellNativeSize; }
            set { _CellNativeSize = value; }
        }

        private GameObject _ObjList;

        private GameObject _Contanter;

        private LuaTable _DataTable;

        private int _DataCount;

        private int _LimitedCount;

        private GameObject _CellPrefab;
        private GameObject _SpecialCellPrefab;

        private bool _CellPrefabRequired = false;

        private float _CellScale;

        private List<GameObject> _CellList = ObjectPool.goListPool.Create();

        private Action<GameObject, object> _SetDataCallBack;
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
            rtt.sizeDelta = rectTrans.rect.size;

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
        }

        /// <summary>
        /// 创建Cell
        /// </summary>
        /// <returns></returns>
        private GameObject CreateCell()
        {
            var cell = UIUtil.InstantiateCell(gameObject, _SpecialCellPrefab == null ? _CellPrefab : _SpecialCellPrefab, ref _WinName);
            cell.transform.SetParent(_Contanter.transform);
            cell.transform.localScale = Vector3.one * _CellScale;
            var cellRtf = cell.GetComponent<RectTransform>();
            cellRtf.anchorMax = Vector2.up;
            cellRtf.anchorMin = Vector2.up;
            cellRtf.pivot = Vector2.up;
            return cell;
        }

        /// <summary>
        /// 检查是否需要mask等组件
        /// </summary>
        private void UpdateMask()
        {
            var needMask = _DataCount > _LimitedCount ? true : false;
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

                var midX = 0;
                var midRow = (_RowCols.x + 1) / 2.0f - 1;
                var midY = 0;
                var midCols = (_RowCols.y + 1) / 2.0f - 1;

                var offsetX = (cols - midCols) * (space.x + _CellSize.x);
                var offsetY = (row - midRow) * (space.y + _CellSize.y);

                cellPosition.x = midX + offsetX;
                cellPosition.y = midY - offsetY;
            }

            cellRtt.anchoredPosition = cellPosition;

            cell.transform.localScale = Vector3.one * _CellScale;

            object data = _DataTable[index + 1];
            if (_SetDataCallBack != null)
                _SetDataCallBack(cell, data);
        }

        public void AcceptGameObjRes(GameObject res, ResID id)
        {
            _CellPrefab = res;
            _CellScale = _CellNativeSize ? 1 : _CellSize.x / _CellPrefab.GetComponent<RectTransform>().rect.size.x;
            InitContanter();
        }

        /// <summary>
        /// 设置数据接口
        /// </summary>
        /// <param name="datas">数据数组</param>
        /// <param name="cout">数据个数</param>
        /// <param name="setDataCallBack">设置数据回调，由Lua的YObjCell提供</param>
        public void SetData(LuaTable datas, int cout, Action<GameObject, object> setDataCallBack)
        {
            _DataTable = datas;
            _DataCount = cout;
            _SetDataCallBack = setDataCallBack;
            if (_CellPrefab != null)
            {
                InitContanter();
            }
            else if (!_CellPrefabRequired)
            {
                _CellPrefabRequired = true;
                PlayInterface.FetchGameObject(UIResDefine.objCellPrefabResID, this);
            }
        }
        public void SetData(GameObject prefab, LuaTable datas, int cout, Action<GameObject, object> setDataCallBack)
        {
            _SpecialCellPrefab = prefab;
            _DataTable = datas;
            _DataCount = cout;
            _SetDataCallBack = setDataCallBack;
            _CellScale = _CellNativeSize ? 1 : _CellSize.x / _SpecialCellPrefab.GetComponent<RectTransform>().rect.size.x;
            InitContanter();
        }

        /// <summary>
        /// 清理ObjList
        /// </summary>
        public void Clear()
        {
            PlayInterface.UnloadGameObject(UIResDefine.objCellPrefabResID, this);
            ClearCells();
            _DataTable = null;
            _DataCount = 0;
            _SetDataCallBack = null;
        }
        private void ClearCells()
        {
            for (int i=0; i<_CellList.Count; ++i)
            {
                UIUtil.GabageCell(_CellList[i]);
            }
            _CellList.Clear();
        }
    }
}
