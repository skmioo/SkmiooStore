/* ==============================================================================
   * 类名称：leexiang
   * 类描述：
   * 创建人：leexiang-pc
   * 创建时间：2015/11/18 17:14:39
   * ==============================================================================*/
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
    [AddComponentMenu("YUI/YGridLayoutGroup", 11)]
    [ExecuteInEditMode]
    [RequireComponent(typeof(RectTransform), typeof(YImage))]
    [Serializable]
    public class YGridLayoutGroup : UIBehaviour, IClearable
    {
        public enum StartCorner
        {
            UpperLeft,
            UpperRight,
            LowerLeft,
            LowerRight
        }

        public enum ChildAlignment
        {
            UpperLeft,
            UpperRight,
            MiddleLeft,
            MiddleRight,
            LowerLeft,
            LowerRight
        }

        public enum StartAxis
        {
            Horizontal,
            Vertical
        }

        public enum Constraint
        {
            Flexible,
            FlexibleColumnCount,
            FlexibleRowCount
        }
        class UIGridCellData
        {
            public GameObject go;
            public RectTransform rectTrans;
        }

        public Vector2 rowCols;
        public Vector2 spacing;
        public StartCorner startCorner;
        public ChildAlignment childAlignment;
        public StartAxis startAxis;
        public Constraint constraint;
        public GameObject cellPrefab;

        /// <summary>
        /// Container's Rectransform
        /// </summary>
        private RectTransform _Content;
        /// <summary>
        /// 容器包裹
        /// </summary>
        private GameObject _ContainerBox;

        /// <summary>
        /// 包裹容器Rtf
        /// </summary>
        private RectTransform _ContainerBoxRtf;

        /// <summary>
        /// 数据格式
        /// </summary>
        private int _DataCount;
        /// <summary>
        /// LuaTable对象
        /// </summary>
        private LuaTable _LuaTable;
        /// <summary>
        /// 更新Cell回调
        /// </summary>
        private Action<LuaTable, GameObject, int> _UpdateCellCallback;

        /// <summary>
        /// Cell缓存
        /// </summary>
        private List<GameObject> _CellCache = ObjectPool.goListPool.Create();

        /// <summary>
        /// 缓存池Cell的实际数量
        /// _ReuseableCellNumber = _DataCount < _BufferNumber ? _DataCount : _BufferNumber;
        /// </summary>
        private int _CellCacheNumber;

        /// <summary>
        /// CellPrefab GameObject~s SizeDelta
        /// </summary>
        private Vector2 _CellSize;

        private RectTransform _CellPrefabTransRect = null;

        private string _WinName = null;

        /// <summary>
        /// 更新List
        /// ListCellCount不变
        /// </summary>
        public void UpdateList()
        {
            UpdateList(_DataCount);
        }
        /// <summary>
        /// 更新List
        /// </summary>
        /// <param name="count">新的ListCellCount</param>
        public void UpdateList(int count)
        {
            SetDataCount(count);
        }
        /// <summary>
        /// 设置数据cout
        /// </summary>
        public void SetDataCount(int count)
        {
            _DataCount = count;
            ResetCells();
        }
        /// <summary>
        /// 根据Index获得对应的Cell
        /// 若超出缓存范围，则返回null
        /// </summary>
        public GameObject GetCellByIndex(int luaIndex)
        {
            if (luaIndex >= _CellCache.Count || luaIndex < 0)
                return null;

            return _CellCache[luaIndex - 1];
        }
        /// <summary>
        /// 设置lua更新cell回调
        /// </summary>
        public void SetLuaUpdateCellCallBack(LuaTable lua, Action<LuaTable, GameObject, int> callback)
        {
            _LuaTable = lua;
            _UpdateCellCallback = callback;
        }
        private LuaTable _LuaTableArgs;
        private Action<LuaTable, GameObject, int ,LuaTable> _UpdateCallBackWithArgs;
        private LuaTable _LuaArgs;
        public void SetLuaUpdateCellCallBackWithArgs(LuaTable lua, Action<LuaTable, GameObject, int ,LuaTable> callback, LuaTable args)
        {
            _LuaTableArgs = lua;
            _UpdateCallBackWithArgs = callback;
            _LuaArgs = args;
        }

        /// <summary>
        /// 脚本启动时触发
        /// </summary>`
        protected override void Awake()
        {
            GameAwake();
            base.Awake();
        }
        protected override void OnDestroy()
        {
            ObjectPool.goListPool.Gabage(_CellCache);
            base.OnDestroy();
        }
        /// <summary>
        /// 游戏时Awake
        /// </summary>
        private void GameAwake()
        {
            _Content = gameObject.GetComponent<RectTransform>();
            _Content.anchorMax = Vector2.up;
            _Content.anchorMin = Vector2.up;
            _Content.pivot = Vector2.up;
            _Content.anchoredPosition = Vector2.zero;
            if (_CellPrefabTransRect == null)
                _CellPrefabTransRect = cellPrefab.GetComponent<RectTransform>();
            _CellSize = _CellPrefabTransRect.rect.size;
        }

        /// <summary>
        /// Reset Cells
        /// </summary>
        private void ResetCells()
        {
           // var size = gameObject.GetComponent<RectTransform>().rect;

           
            rowCols = startAxis == StartAxis.Horizontal ? new Vector2(Mathf.CeilToInt(_DataCount / rowCols.y), /*(_DataCount < rowCols.y) ? _DataCount :*/ rowCols.y) : new Vector2(/*(_DataCount < rowCols.x) ? _DataCount :*/ rowCols.x, Mathf.CeilToInt(_DataCount / rowCols.x));
            Vector2 _TotalSize = new Vector2(rowCols.y * (_CellSize.x + spacing.x), rowCols.x * (_CellSize.y + spacing.y));
            if (_ContainerBox == null)
            {
                _ContainerBox = new GameObject("ContainerBox");
                _ContainerBoxRtf = _ContainerBox.AddComponent<RectTransform>();
                _ContainerBoxRtf.SetParent(gameObject.transform);
            }
            _ContainerBoxRtf.sizeDelta = _TotalSize;
            _ContainerBoxRtf.localScale = Vector3.one;
            CalcChildAlignment();

            int cellCount = _CellCache.Count;
            if (cellCount <= _DataCount)
            {
                //更新已有的数据
                for (int idx = 0; idx < cellCount; idx++)
                {
                    SetCell(_CellCache[idx], idx);
                }
                //新建增加的数据
                for(int idx = cellCount; idx < _DataCount; idx++)
                {
                    GameObject newCell = CreateCell();
                    _CellCache.Add(newCell);
                    SetCell(newCell,idx);
                }
            }
            else
            {
                for(int idx =0; idx < _DataCount;idx++)
                {
                    SetCell(_CellCache[idx], idx);
                }
                //回收多余的数据
                for(int idx = cellCount-1;idx >= _DataCount; idx--)
                {
                    UIUtil.GabageCell(_CellCache[idx]);
                    _CellCache.RemoveAt(idx);
                }
            }
        }

        private GameObject CreateCell()
        {
            GameObject cellInst = UIUtil.InstantiateCell(gameObject, cellPrefab, ref _WinName);
            cellInst.transform.localScale = Vector3.one;
            cellInst.transform.SetParent(_ContainerBoxRtf);
            return cellInst;
        }

        /// <summary>
        /// 设置Cell数据
        /// </summary>
        private void SetCell(GameObject cell, int index)
        {
            if (index < 0 || index >= _DataCount)
            {
                return;
            }
            RectTransform cellRtf = cell.GetComponent<RectTransform>();
            int cols, row;
            if (startAxis == StartAxis.Horizontal)
            {
                row = Mathf.FloorToInt(index / (int)rowCols.y); //行
                cols = index % (int)rowCols.y;  //列
            }
            else
            {
                row = index % (int)rowCols.x; //行
                cols = Mathf.FloorToInt(index / (int)rowCols.x);//列
            }

            CalcStartCorner(cell);
            //_CellSize = cellRtf.sizeDelta;
            Vector2 cellPosition;
            cellPosition.x = spacing.x * (cols + 1) + _CellSize.x * cols;
            cellPosition.y = -(spacing.y * (row + 1) + _CellSize.y * row);
            cellRtf.anchoredPosition = cellPosition;
            cellRtf.localScale = new Vector3(1, 1, 1);
            UpdateCellData(cell, index);

        }

        /// <summary>
        /// 更新CellData
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="index"></param>
        private void UpdateCellData(GameObject cell, int index)
        {
            if (_LuaArgs != null)
            {
                _UpdateCallBackWithArgs(_LuaTableArgs, cell, index + 1, _LuaArgs);
            }
            else
            {
                _UpdateCellCallback(_LuaTable, cell, index + 1);
            }
        }

        private void CalcChildAlignment()
        {
            switch (childAlignment)
            {
                case ChildAlignment.LowerLeft:
                    _ContainerBoxRtf.anchorMax = Vector2.zero;
                    _ContainerBoxRtf.anchorMin = Vector2.zero;
                    _ContainerBoxRtf.pivot = Vector2.zero;
                    break;
                case ChildAlignment.LowerRight:
                    _ContainerBoxRtf.anchorMax = Vector2.right;
                    _ContainerBoxRtf.anchorMin = Vector2.right;
                    _ContainerBoxRtf.pivot = Vector2.right;
                    break;
                case ChildAlignment.MiddleLeft:
                    _ContainerBoxRtf.anchorMax = new Vector2(0, 0.5f);
                    _ContainerBoxRtf.anchorMin = new Vector2(0, 0.5f);
                    _ContainerBoxRtf.pivot = new Vector2(0,0.5f);
                    break;
                case ChildAlignment.MiddleRight:
                    _ContainerBoxRtf.anchorMax = new Vector2(0.5f, 0);
                    _ContainerBoxRtf.anchorMin = new Vector2(0.5f, 0);
                    _ContainerBoxRtf.pivot = new Vector2(0.5f,0);
                    break;
                case ChildAlignment.UpperLeft:
                    _ContainerBoxRtf.anchorMax = Vector2.up;
                    _ContainerBoxRtf.anchorMin = Vector2.up;
                    _ContainerBoxRtf.pivot = Vector2.up;
                    break;
                case ChildAlignment.UpperRight:
                    _ContainerBoxRtf.anchorMax = Vector2.one;
                    _ContainerBoxRtf.anchorMin = Vector2.one;
                    _ContainerBoxRtf.pivot = Vector2.one;
                    break;
            }
            _ContainerBoxRtf.anchoredPosition = Vector2.zero;
        }

        private void CalcStartCorner(GameObject cell)
        {
            var cellRtf = cell.GetComponent<RectTransform>();
            switch (startCorner)
            {
                case StartCorner.LowerLeft:
                    cellRtf.anchorMax = Vector2.zero;
                    cellRtf.anchorMin = Vector2.zero;
                    cellRtf.pivot = Vector2.zero;
                    break;
                case StartCorner.LowerRight:
                    cellRtf.anchorMax = Vector2.right;
                    cellRtf.anchorMin = Vector2.right;
                    cellRtf.pivot = Vector2.right;
                    break;
                case StartCorner.UpperLeft:
                    cellRtf.anchorMax = Vector2.up;
                    cellRtf.anchorMin = Vector2.up;
                    cellRtf.pivot = Vector2.up;
                    break;
                case StartCorner.UpperRight:
                    cellRtf.anchorMax = Vector2.one;
                    cellRtf.anchorMin = Vector2.one;
                    cellRtf.pivot = Vector2.one;
                    break;
            }
        }

        public void Clear()
        {
            ClearLuaHandler();

            for (int idx = 0; idx < _CellCache.Count; idx++ )
            {
                UIUtil.GabageCell(_CellCache[idx]);
            }
            _CellCache.Clear();
        }

        public void ClearLuaHandler()
        {
            _LuaTable = null;
            _UpdateCellCallback = null;
            _UpdateCallBackWithArgs = null;
            _LuaArgs = null;
            _LuaTableArgs = null;

        }
    }
}
