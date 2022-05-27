using System;
using System.Collections.Generic;
using UYMO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using SLua;

namespace UYMO
{
    /// <summary>
    /// 向规定方向逐步填充的YScorllList，类似竹笋:)
    /// </summary>
    [CustomLuaClass]
    [AddComponentMenu("YUI/YBambooScrollList", 11)]
    [ExecuteInEditMode]
    [RequireComponent(typeof(RectTransform), typeof(YImage))]
    public class YBambooScrollList : UIBehaviour, IClearable, IPointerClickHandler
    {
        /// <summary>
        /// 创建的方向枚举
        /// </summary>
        public enum Direction
        {
            Up,
            Down,
            Left,
            Right,
        };

        /// <summary>
        /// 当前界面显示的行列数
        /// </summary>
        public Vector2 rowCols;
        /// <summary>
        /// Cell之间的间隔
        /// </summary>
        public Vector2 space;

        public bool hideFirstOffset;
        /// <summary>
        /// 滑动的方向
        /// </summary>
        public Direction direction;
        /// <summary>
        /// Cell的Prefab
        /// </summary>
        public GameObject cellPrefab;
        /// <summary>
        /// 选中效果的Prefab
        /// </summary>
        public GameObject selectPrefab;
        /// <summary>
        /// 是否开启尾部的自动排列
        /// </summary>
        public bool autoArrange { set; get; }
        /// <summary>
        /// 是否显示纵向滚动条
        /// </summary>
        public bool verticalScrollBar
        {
            get { return gameObject.transform.Find("VerticalScrollBar"); }
            set
            {
                if (!Application.isEditor)
                {
                    //只在编辑器状态下使用
                    return;
                }
                if (value)
                {
                    YScrollbar scrollBar = null;
                    var transform = gameObject.transform.Find("VerticalScrollBar");
                    if (transform == null)
                    {
                        if (!Application.isPlaying)
                        {
                            var pref = PlayInterface.GetResInEditor(UIResDefine.vertScrollListResID, typeof(GameObject)) as GameObject;
                            var scrollBarObj = UIUtil.Instantiate(pref);
                            scrollBarObj.name = "VerticalScrollBar";
                            scrollBarObj.transform.SetParent(gameObject.transform);
                            scrollBarObj.transform.localScale = Vector3.one;
                            var rtf = scrollBarObj.GetComponent<RectTransform>();
                            var width = rtf.rect.width;
                            rtf.anchoredPosition = Vector2.zero;
                            rtf.offsetMax = Vector2.zero;
                            rtf.offsetMin = Vector2.zero;
                            rtf.sizeDelta = new Vector2(width, 0);
                            scrollBar = scrollBarObj.GetComponent<YScrollbar>();
                        }
                    }
                    else
                    {
                        scrollBar = transform.gameObject.GetComponent<YScrollbar>();
                    }
                    if (scrollBar != null)
                    {
                        _UYScrollRect.verticalScrollbar = scrollBar;
                    }
                }
                else
                {
                    var transform = gameObject.transform.Find("VerticalScrollBar");
                    if (transform != null)
                    {
                        U3DUtil.DestroyGameObject(transform.gameObject);
                    }
                    _UYScrollRect.verticalScrollbar = null;
                }
            }
        }
        /// <summary>
        /// 竖直滚动条对象
        /// </summary>
        public YScrollbar verticalScrollBarObj
        {
            get
            {
                return _UYScrollRect.verticalScrollbar;
            }
        }
        /// <summary>
        /// 是否显示横向滚动条
        /// </summary>
        public bool horizontalScrollBar
        {
            get { return gameObject.transform.Find("HorizontalScrollBar"); }
            set
            {
                if (!Application.isEditor)
                {
                    //只在编辑器状态下使用
                    return;
                }
                if (value)
                {
                    YScrollbar scrollbar = null;
                    var transform = gameObject.transform.Find("HorizontalScrollBar");
                    if (transform == null)
                    {
                        if (!Application.isPlaying)
                        {
                            var pref = PlayInterface.GetResInEditor(UIResDefine.horScrollListResID, typeof(GameObject)) as GameObject;
                            var scrollBarObj = UIUtil.Instantiate(pref);
                            scrollBarObj.name = "HorizontalScrollBar";
                            scrollBarObj.transform.SetParent(gameObject.transform);
                            scrollBarObj.transform.localScale = Vector3.one;
                            var rtf = scrollBarObj.GetComponent<RectTransform>();
                            var height = rtf.rect.height;
                            rtf.anchoredPosition = Vector2.zero;
                            rtf.offsetMax = Vector2.zero;
                            rtf.offsetMin = Vector2.zero;
                            rtf.sizeDelta = new Vector2(0, height);
                            scrollbar = scrollBarObj.GetComponent<YScrollbar>();
                        }
                    }
                    else
                    {
                        scrollbar = transform.gameObject.GetComponent<YScrollbar>();
                    }
                    if (scrollbar != null)
                    {
                        _UYScrollRect.horizontalScrollbar = scrollbar;
                    }
                }
                else
                {
                    var transform = gameObject.transform.Find("HorizontalScrollBar");
                    if (transform != null)
                    {
                        U3DUtil.DestroyGameObject(transform.gameObject);
                    }
                    _UYScrollRect.horizontalScrollbar = null;
                }
            }
        }

        /// <summary>
        /// 水平滚动条对象
        /// </summary>
        public YScrollbar horizontalScrollbarObj
        {
            get
            {
                return _UYScrollRect.horizontalScrollbar;
            }
        }
        /// <summary>
        /// 是否显示MaskGraphic
        /// </summary>
        public bool showMaskGraphic
        {
            get { return _Mask == null ? true : _Mask.showMaskGraphic; }
            set
            {
                if (_Mask != null)
                {
                    _Mask.showMaskGraphic = value;
                }
            }
        }

        /// <summary>
        /// 刷新当前缓存中Cell
        /// </summary>
        public void RefreshCells()
        {
            if (_CellCache.Count == 0)
            {
                return;
            }
            var range = _CheckRange;
            for (int i = (int)range.x; i <= (int)range.y; ++i)
            {
                if (_CellCache.ContainsKey(i))
                {
                    var cell = _CellCache[i];
                    SetCell(cell, i);
                }
            }
        }
        /// <summary>
        /// 设置数据count，带有滚动框的位移
        /// </summary>
        /// <param name="count"></param>
        /// <param name="toTop">前往头还是尾部</param>
        public void InitDataCount(int count,bool toTop)
        {
            SetDataCount(count);
            Vector3 pos = _Content.anchoredPosition;
            if(direction == Direction.Up || direction == Direction.Down)
            {
                if (_Content.sizeDelta.y <= _ScrollListSize.y)
                {
                    _Content.anchoredPosition = Vector2.zero;
                    return;
                }
            }
            else
            {
                if (_Content.sizeDelta.x <= _ScrollListSize.x)
                {
                    _Content.anchoredPosition = Vector2.zero;
                    return;
                }
            }
            if(toTop)
            {
                switch(direction)
                {
                    case Direction.Up:
                        pos.y = -(_Content.sizeDelta.y - _ScrollListSize.y);
                        break;
                    case Direction.Down:
                        pos.y = _Content.sizeDelta.y - _ScrollListSize.y;
                        break;
                    case Direction.Left:
                        pos.x = _Content.sizeDelta.x - _ScrollListSize.x;
                        break;
                    case Direction.Right:
                        pos.x = -(_Content.sizeDelta.x - _ScrollListSize.x);
                        break;
                }
                _Content.anchoredPosition = pos;
            }
            else
            {
                _Content.anchoredPosition = Vector3.zero;
            }
                
        }
        /// <summary>
        /// 设置数据count，不会位移滚动框
        /// </summary>
        public void SetDataCount(int count)
        {
            _DataCount = count;
            ResetCells();
            CheckCells();
            Vector2 pos = _Content.anchoredPosition;
            Vector2 min = _Content.offsetMin;
            Vector2 max = _Content.offsetMax;
            //该组件是需要2边都有留边的
            float addSpace = 0;
            if (direction == Direction.Up || direction == Direction.Down)
            {
                int row = Mathf.CeilToInt((count - 1) / (int)rowCols.y) + 1;
                if (!hideFirstOffset) addSpace = space.y;
                float newHeight = (row * (_CellSize.y + space.y) + addSpace);
                float oldHeight = _Content.offsetMax.y - _Content.offsetMin.y;
                if(direction == Direction.Up)
                {
                    min.y -= (newHeight - oldHeight);
                    _Content.offsetMin = min;
                }
                else
                {
                    max.y += (newHeight - oldHeight);
                    _Content.offsetMax = max;
                }
                bool needArrange = autoArrange && (Math.Abs(pos.y) < (_StepLength * 0.1));
                if (needArrange)
                {
                    pos.y = 0;
                    _Content.anchoredPosition = pos;
                }
            }
            else
            {
                int cols = Mathf.CeilToInt((count - 1) / (int)rowCols.x) + 1;
                if (!hideFirstOffset) addSpace = space.x;
                float newWidth = (cols * (_CellSize.x + space.x) + addSpace);
                float oldWidth = _Content.offsetMax.x - _Content.offsetMin.x;
                if (direction == Direction.Right)
                {
                    if(newWidth <= _ScrollListSize.x)
                    {
                        min.x = 0;
                        _Content.offsetMin = min;
                        max.x = newWidth;
                        _Content.offsetMax = max;
                    }
                    else
                    {
                        min.x -= newWidth - oldWidth;
                        _Content.offsetMin = min;
                        if (autoArrange && (Math.Abs(min.x) - _StepLength < (_StepLength * 0.1)))
                        {
                            pos.x = 0;
                            _Content.anchoredPosition = pos;
                        }
                    }
                }
                else
                {
                    if (newWidth <= _ScrollListSize.x)
                    {
                        max.x = 0;
                        _Content.offsetMax = max;
                        min.x = -newWidth;
                        _Content.offsetMin = min;
                    }
                    else
                    {
                        max.x += newWidth - oldWidth;
                        _Content.offsetMax = max;
                        if (autoArrange && (Math.Abs(max.x) - _StepLength < (_StepLength * 0.1)))
                        {
                            pos.x = 0;
                            _Content.anchoredPosition = pos;
                        }
                    }
                }
            }
            //清理掉选中信息
            _SelectedCell = -1;
            if (_SelectedEff != null)
            {
                _SelectedEff.transform.SetAsLastSibling();
                _SelectedEff.gameObject.SetActive(false);
            }
        }
        /// <summary>
        /// 当前选中的Cell index,未选中返回-1 从1开始
        /// </summary>
        public int selectedIndex
        {
            get { return _SelectedCell + 1; }
            set
            {
                SetSelectedByIndex(value - 1 , true, false);
            }
        }
        /// <summary>
        /// 当前所处于的步数，传入和返回都为lua的索引
        /// 以行或列为单位，取决于滚动方向
        /// </summary>
        
        public int currentStep
        {
            get
            {
                Vector2 offset = _Content.anchoredPosition;
                int step = 1;
                if (direction == Direction.Up || direction == Direction.Down)
                {
                    float offsetY = _Content.sizeDelta.y - _ScrollListSize.y;
                    if (offsetY <= 0)
                    {
                        step = 1;
                    }
                    else
                    {
                        offset.y = _Content.sizeDelta.y - Math.Abs(offset.y) - _ScrollListSize.y;
                        step = Mathf.CeilToInt(offsetY / _StepLength) - Mathf.CeilToInt(offset.y / _StepLength);
                        if (step == 0) step = 1;
                    }
                }
                else
                {
                    float offsetX = _Content.sizeDelta.x - _ScrollListSize.x;
                    if (offsetX <= 0)
                    {
                        step = 1;
                    }
                    else
                    {
                        offset.x = _Content.sizeDelta.x - Math.Abs(offset.x) - _ScrollListSize.x;
                        step = Mathf.CeilToInt(offsetX / _StepLength) - Mathf.CeilToInt(offset.x / _StepLength);
                        if (step == 0) step = 1;
                    }
                }
                return step;
            }
            set
            {
                _UYScrollRect.StopMovement();
                int step = (value - 1 < 0) ? 0 : value - 1;
                _Content.anchoredPosition = GetPosByStep(step);
            }
        }

        /// <summary>
        /// 尝试刷新某个cell
        /// </summary>
        /// <param name="luaIndex">cell索引</param>
        public void TryUpdateCell(int luaIndex)
        {
            var cell = GetCellByIndex(luaIndex);
            if (cell != null)
            {
                if (_LuaTable != null && _UpdateCellCallback != null)
                    _UpdateCellCallback(_LuaTable, cell, luaIndex);
            }
        }

        /// <summary>
        /// 移动到指定的索引位置
        /// </summary>
        /// <param name="index">lua的索引</param>
        /// <param name="speed">速度=0 默认速度，-1 不做动画</param>
        public void MoveToIndex(int index,float speed)
        {
            _UYScrollRect.StopMovement();
            index = index - 1;
            int step = 0;
            if (direction == Direction.Up || direction == Direction.Down)
            {
                step = Mathf.FloorToInt(index / rowCols.y);
            }
            else
            {
                step = Mathf.FloorToInt(index / rowCols.x);
            }
            Vector2 pos = GetPosByStep(step);
            if (speed == -1)
            {
                _UYScrollRect.ScrollToPosition(pos, true, -1);
            }
            else
            {
                _UYScrollRect.ScrollToPosition(pos, true);
            }
        }

        /// <summary>
        /// 根据Index获得对应的Cell
        /// 若超出缓存范围，则返回null
        /// </summary>
        public GameObject GetCellByIndex(int luaIndex)
        {
            GameObject rtn = null;
            _CellCache.TryGetValue(luaIndex - 1, out rtn);
            return rtn;
        }

        public void ResetCellSize()
        {
            _CellSize = cellPrefab.GetComponent<RectTransform>().rect.size;
            var size = gameObject.GetComponent<RectTransform>().rect;
            if (direction == Direction.Up || direction == Direction.Down )
            {
                _StepLength = space.y + _CellSize.y;
                rowCols = new Vector2(Mathf.FloorToInt(size.height / _StepLength), rowCols.y);
                _BufferNumber = 4 * (int)rowCols.y;
            }
            else
            {
                _StepLength = space.x + _CellSize.x;
                rowCols = new Vector2(rowCols.x, Mathf.FloorToInt(size.width / _StepLength));
                _BufferNumber = 4 * (int)rowCols.x;
            }
            _BufferNumber += (int)rowCols.x * (int)rowCols.y;
        }

        public void SetRowCols(uint x, uint y)
        {
            rowCols = new Vector2(x, y);
            ResetCellSize();
        }

        /// <summary>
        /// 取消同一cell只能触发一次的限制
        /// </summary>
        public void CancelTriggerOnce()
        {
            _TriggerOnce = false;
        }

        /// <summary>
        /// 设置lua更新cell回调
        /// </summary>
        public void SetLuaUpdateCellCallBack(LuaTable lua, Action<LuaTable, GameObject, int> callback)
        {
            _LuaTable = lua;
            _UpdateCellCallback = callback;
        }

        /// <summary>
        /// 设置选中更改回调
        /// </summary>
        /// <param name="luaTable">lua对象，在lua中注册时，需要传值，且此时回调函数中的index是从1开始的</param>
        /// <param name="callback">回调函数，参数：lua对象，cell对象，cell索引, 之前选中的索引</param>
        public void SetSelectChangedCallBack(object luaTable, Action<object, GameObject, int, int> callback)
        {
            _SelectChangedListener = luaTable;
            _SelectChangedCallback = callback;
        }

        /// <summary>
        /// Lua 滚动时回调
        /// </summary>
        public void SetLuaOnScrolling(LuaTable lua, Action<LuaTable, Vector2> callback)
        {
            _LuaTableOnScroll = lua;
            _LuaOnScrolling = callback;
        }

        public void ClearLuaHandler()
        {
            _LuaTable = null;
            _UpdateCellCallback = null;

            _LuaTableOnScroll = null;
            _LuaOnScrolling = null;
        }

        /// <summary>
        /// UYScrollRect对象
        /// </summary>
        private YScrollRect _UYScrollRect;
        /// <summary>
        /// Mask对象
        /// </summary>
        private Mask _Mask;
        /// <summary>
        /// ListCell容器
        /// </summary>
        private GameObject _ListCellContainer;
        /// <summary>
        /// Container's Rectransform
        /// </summary>
        private RectTransform _Content;
        /// <summary>
        /// 组件本身的尺寸，用作计算可以显示多少个cell
        /// </summary>
        private Vector2 _ScrollListSize;
        /// <summary>
        /// 数据数量
        /// </summary>
        private int _DataCount;
        /// <summary>
        /// Cell的Size数据
        /// </summary>
        private Vector2 _CellSize;
        /// <summary>
        /// 移动一步所需要的距离
        /// </summary>
        private float _StepLength;
        /// <summary>
        /// LuaTable对象
        /// </summary>
        private LuaTable _LuaTable;
        /// <summary>
        /// 更新Cell回调
        /// </summary>
        private Action<LuaTable, GameObject, int> _UpdateCellCallback;
        /// <summary>
        /// 滚动时响应者
        /// </summary>
        private LuaTable _LuaTableOnScroll;
        /// <summary>
        /// Lua 滚动时回调
        /// </summary>
        private Action<LuaTable, Vector2> _LuaOnScrolling;
        /// <summary>
        /// 当前选中的Cell
        /// </summary>
        private int _SelectedCell = -1;
        /// <summary>
        /// 选中效果
        /// </summary>
        private GameObject _SelectedEff = null;
        /// <summary>
        /// 选中更改监听者
        /// </summary>
        private object _SelectChangedListener = null;
        private bool _SetCellSelectCBFlag = false;
        /// <summary>
        /// 选中更改回调
        /// </summary>
        private Action<object, GameObject, int, int> _SelectChangedCallback = null;
        /// <summary>
        /// 已回收可复用的Cells
        /// </summary>
        private Queue<GameObject> _ReuseableCells = new Queue<GameObject>();
        /// <summary>
        /// Cell缓存
        /// </summary>
        private Dictionary<int, GameObject> _CellCache = new Dictionary<int, GameObject>();
        private List<int> _UnVisibleList = new List<int>();
        /// <summary>
        /// 数据过多时需要的最少缓存数量
        /// </summary>
        private int _BufferNumber;
        /// <summary>
        /// 缓存池Cell的实际数量
        /// _ReuseableCellNumber = _DataCount < _BufferNumber ? _DataCount : _BufferNumber;
        /// </summary>
        private int _CellCacheNumber;
        /// <summary>
        /// 是否循环利用Cell
        /// </summary>
        private bool _Looping;
        private bool _Awaked = false;
        /// <summary>
        /// 同个cell是否只触发一次
        /// </summary>
        private bool _TriggerOnce = true;
        
        private string _WinName = null;
        /// <summary>
        /// 脚本启动时触发
        /// </summary>`
        protected override void Awake()
        {
            base.Awake();
            if (Application.isPlaying)
            {
                GameAwake();
            }
            else
            {
                EditorAwake();
            }
        }
        
        /// <summary>
        /// 编辑器模式下Awake
        /// </summary>
        private void EditorAwake()
        {
            _Mask = gameObject.GetComponent<Mask>();
            if (_Mask == null)
            {
                _Mask = gameObject.AddComponent<Mask>();
            }
            _Mask.hideFlags = HideFlags.HideInInspector;

            var containerTransfrom = gameObject.transform.Find("ListCellContainer");
            if (containerTransfrom == null)
            {
                _ListCellContainer = new GameObject("ListCellContainer");
                _Content = _ListCellContainer.AddComponent<RectTransform>();
                _ListCellContainer.transform.SetParent(gameObject.transform);
                _ListCellContainer.transform.localScale = Vector3.one;
                _ListCellContainer.transform.localPosition = Vector3.zero;
            }
            else
            {
                _ListCellContainer = containerTransfrom.gameObject;
                _Content = _ListCellContainer.GetComponent<RectTransform>();
                if (!_Content)
                {
                    _Content = _ListCellContainer.AddComponent<RectTransform>();
                }
            }
            _Content.sizeDelta = gameObject.GetComponent<RectTransform>().rect.size;

            _UYScrollRect = gameObject.GetComponent<YScrollRect>();
            if (_UYScrollRect == null)
            {
                _UYScrollRect = gameObject.AddComponent<YScrollRect>();
            }
            _UYScrollRect.content = _Content;
        }
        /// <summary>
        /// 游戏时Awake
        /// </summary>
        private void GameAwake()
        {
            _Mask = gameObject.GetComponent<Mask>();
            _Mask.hideFlags = HideFlags.HideInInspector;
            _ListCellContainer = gameObject.transform.Find("ListCellContainer").gameObject;
            _UYScrollRect = gameObject.GetComponent<YScrollRect>();
            _UYScrollRect.hideFlags = HideFlags.HideInInspector;
            _UYScrollRect.onValueChanged.AddListener(HandleValueChanged);
            _Content = _UYScrollRect.content;
            switch (direction)
            {
                case Direction.Left:
                    _UYScrollRect.horizontal = true;
                    _UYScrollRect.vertical = false;
                    _Content.anchorMax = Vector2.one;
                    _Content.anchorMin = Vector2.one;
                    _Content.pivot = Vector2.one;
                    break;
                case Direction.Right:
                    _UYScrollRect.horizontal = true;
                    _UYScrollRect.vertical = false;
                    _Content.anchorMax = Vector2.up;
                    _Content.anchorMin = Vector2.up;
                    _Content.pivot = Vector2.up;
                    break;
                case Direction.Up:
                    _UYScrollRect.horizontal = false;
                    _UYScrollRect.vertical = true;
                    _Content.anchorMax = Vector2.zero;
                    _Content.anchorMin = Vector2.zero;
                    _Content.pivot = Vector2.zero;
                    break;
                case Direction.Down:
                    _UYScrollRect.horizontal = false;
                    _UYScrollRect.vertical = true;
                    _Content.anchorMax = Vector2.up;
                    _Content.anchorMin = Vector2.up;
                    _Content.pivot = Vector2.up;
                    break;
            }
            _Content.anchoredPosition = Vector2.zero;
            Rect rect = gameObject.GetComponent<RectTransform>().rect;
            _ScrollListSize = new Vector2(rect.width, rect.height);
            _Content.sizeDelta = _ScrollListSize;
            ResetCellSize();
            autoArrange = true;
        }

        public void Clear()
        {
            //清理cache中的对象
            foreach (var pair in _CellCache)
            {
                UIUtil.GabageCell(pair.Value);
            }
            _CellCache.Clear();

            ClearCell();
            ClearLuaHandler();
        }

        void ClearCell()
        {
            while (_ReuseableCells.Count > 0)
            {
                UIUtil.GabageCell(_ReuseableCells.Dequeue());
            }
        }

        /// <summary>
        /// Reset Cells
        /// </summary>
        private void ResetCells()
        {
            ClearCell();

            var keys = _CellCache.Keys;
            foreach (var key in keys)
            {
                var cell = _CellCache[key];
                _ReuseableCells.Enqueue(cell);
            }
            _CellCache.Clear();

            var currentCount = _ReuseableCells.Count;
            _CellCacheNumber = _DataCount < _BufferNumber ? _DataCount : _BufferNumber;
            _Looping = _DataCount < _BufferNumber ? false : true;

            if (_CellCacheNumber > currentCount)
            {
                for (int i = 0; i < _CellCacheNumber - currentCount; ++i)
                {
                    var cell = UIUtil.InstantiateCell(gameObject, cellPrefab, _ListCellContainer.transform, ref _WinName);
                    cell.transform.localScale = Vector3.one;
                    cell.transform.localPosition = Vector3.zero;
                    var cellRtf = cell.GetComponent<RectTransform>();
                    switch(direction)
                    {
                        case Direction.Up:
                            cellRtf.anchorMax = Vector2.up;
                            cellRtf.anchorMin = Vector2.up;
                            cellRtf.pivot = Vector2.up;
                            break;
                        case Direction.Down:
                            cellRtf.anchorMax = Vector2.zero;
                            cellRtf.anchorMin = Vector2.zero;
                            cellRtf.pivot = Vector2.zero;
                            break;
                        case Direction.Left:
                            cellRtf.anchorMax = Vector2.up;
                            cellRtf.anchorMin = Vector2.up;
                            cellRtf.pivot = Vector2.up;
                            break;
                        case Direction.Right:
                            cellRtf.anchorMax = Vector2.one;
                            cellRtf.anchorMin = Vector2.one;
                            cellRtf.pivot = Vector2.one;
                            break;
                    }
                    cell.SetActive(false);
                    _ReuseableCells.Enqueue(cell);
                }
            }
            else if (_CellCacheNumber < currentCount)
            {
                for (int i = 0; i < currentCount - _CellCacheNumber; ++i)
                {
                    var cell = _ReuseableCells.Dequeue();
                    UIUtil.GabageCell(cell);
                }
            }
        }

        /// <summary>
        /// 更新Cells
        /// </summary>
        private void CheckCells()
        {
            if (_DataCount == 0)
            {
                return;
            }

            _UnVisibleList.Clear();
            var range = _CheckRange;
            foreach (var pair in _CellCache)
            {
                var index = pair.Key;
                if (index < range.x || index > range.y)
                {
                    _UnVisibleList.Add(index);
                }
            }
            for (int i = 0; i < _UnVisibleList.Count; ++i)
            {
                _ReuseableCells.Enqueue(_CellCache[_UnVisibleList[i]]);
                _CellCache[_UnVisibleList[i]].SetActive(false);
                _CellCache.Remove(_UnVisibleList[i]);
            }
            for (int i = (int)range.x; i <= (int)range.y; ++i)
            {
                if (_CellCache.ContainsKey(i))
                {
                    continue;
                }
                var cell = _ReuseableCells.Dequeue();
                SetCell(cell, i);
                cell.SetActive((i >= 0 && i < _DataCount));
                _CellCache.Add(i, cell);
            }
        }

        /// <summary>
        /// 设置Cell数据
        /// </summary>
        private void SetCell(GameObject cell, int index)
        {
            var cellRtf = cell.GetComponent<RectTransform>();
            int cols, row;
            if (direction == Direction.Up || direction == Direction.Down)
            {
                row = Mathf.FloorToInt(index / (int)rowCols.y); //行
                cols = index % (int)rowCols.y;  //列
            }
            else
            {
                row = index % (int)rowCols.x; //行
                cols = Mathf.FloorToInt(index / (int)rowCols.x);//列
            }
            int addSpace = 1;
            if (hideFirstOffset) addSpace = 0;
            Vector3 cellPosition = Vector3.zero;
            
            switch (direction)
            {
                case Direction.Left:
                    cellPosition.x = space.x * (cols + addSpace) + _CellSize.x * cols;
                    cellPosition.y = -(space.y * (row + addSpace) + _CellSize.y * row);
                    break;
                case Direction.Right:
                    cellPosition.x = -(space.x * (cols + addSpace) + _CellSize.x * cols);
                    cellPosition.y = -(space.y * (row + addSpace) + _CellSize.y * row);
                    break;
                case Direction.Up:
                    cellPosition.x = space.x * (cols + addSpace) + _CellSize.x * cols;
                    cellPosition.y = -(space.y * (row + addSpace) + _CellSize.y * row);
                    break;
                case Direction.Down:
                    cellPosition.x = space.x * (cols + addSpace) + _CellSize.x * cols;
                    cellPosition.y = space.y * (row + addSpace) + _CellSize.y * row;
                    break;
            }
            cellPosition.z = 0;
            cellRtf.anchoredPosition = cellPosition;
            if (_LuaTable != null && _UpdateCellCallback != null)
                _UpdateCellCallback(_LuaTable, cell, index + 1);
            if (index == selectedIndex)
            {
                if (_SetCellSelectCBFlag && _SelectChangedCallback != null)
                {
                    _SetCellSelectCBFlag = false;
                    _SelectChangedCallback.Invoke(_SelectChangedListener, cell, _SelectedCell + 1, _SelectedCell + 1);
                }
                if (_SelectedEff == null && selectPrefab != null)
                {
                    BuildSelectedEff(cellRtf);
                }
            }
        }

        private void SetSelectedByIndex(int idx, bool sendEvt, bool guideNotify)
        {
            //判断是否可重复触发
            if (_TriggerOnce && _SelectedCell == idx)
                return;

            GameObject cell = null;
            if (!_CellCache.TryGetValue(idx, out cell))
            {
                if (idx < _DataCount)
                {
                    _SelectedCell = idx;
                    
                    if(direction == Direction.Up || direction == Direction.Down)
                    {
                        currentStep = Mathf.FloorToInt(idx / rowCols.y);
                    }
                    else
                    {
                        currentStep = Mathf.FloorToInt(idx / rowCols.x);
                    }
                    _SetCellSelectCBFlag = true;
                }
                return;
            }

            var oldSelectedIdx = _SelectedCell;
            _SelectedCell = idx;
            var trans = cell.GetComponent<RectTransform>();
            BuildSelectedEff(trans);
            if (_SelectChangedCallback != null)
            {//触发选择cell回调
                _SelectChangedCallback.Invoke(_SelectChangedListener, cell, _SelectedCell + 1, oldSelectedIdx + 1);
            }
            if (guideNotify)
            {//触发guide回调
                PlayInterface.NotifyLua("SystemNotify", "ClickUIHandle", cell);
            }
        }

        /// <summary>
        /// 根据步数获取对应的坐标
        /// </summary>
        /// <param name="step">步数</param>
        /// <returns>对应的坐标</returns>
        private Vector2 GetPosByStep(int step)
        {
            Vector2 pos = _Content.anchoredPosition;
            if(direction == Direction.Up || direction == Direction.Down)
            {
                if (_Content.sizeDelta.y - _ScrollListSize.y <= 0)
                {
                    pos.y = 0;
                }
                else
                {
                    float height = -_Content.sizeDelta.y;
                    height += step * _StepLength + _ScrollListSize.y;
                    if (height >= 0)
                    {
                        pos.y = 0;
                    }
                    else
                    {
                        if (direction == Direction.Down) height *= -1;
                        pos.y = height;
                    }
                }
            }
            else
            {
                if (_Content.sizeDelta.x - _ScrollListSize.x <= 0)
                {
                    pos.x = 0;
                }
                else
                {
                    float width = -_Content.sizeDelta.x;
                    width += step * _StepLength + _ScrollListSize.x;
                    if (width >= 0)
                    {
                        pos.x = 0;
                    }
                    else
                    {
                        if (direction == Direction.Left) width *= -1;
                        pos.x = width;
                    }
                }
            }
            return pos;
        }
        /// <summary>
        /// 需要检查的Index范围
        /// </summary>
        private Vector2 _CheckRange
        {
            get
            {
                Vector2 range = new Vector2(0, _DataCount - 1);
                if (_Looping)
                {
                    int currStep = currentStep;
                    int beginStep = currStep - 1;
                    int beginIndex = 0;
                    if(direction == Direction.Up || direction == Direction.Down)
                    {
                        beginStep = Mathf.CeilToInt(_DataCount / rowCols.y) - currStep;
                        beginIndex = beginStep * (int)rowCols.y;
                        range.x = beginIndex - _CellCacheNumber + 1;
                        if (range.x < 0) range.x = 0;
                        range.y = beginIndex;
                    }
                    else
                    {
                        beginStep = Mathf.CeilToInt(_DataCount / rowCols.x) - currStep;
                        beginIndex = beginStep * (int)rowCols.x;
                        range.x = beginIndex - _CellCacheNumber + 1;
                        if (range.x < 0) range.x = 0;
                        range.y = beginIndex;
                    }
                }
                //Debug.Log("_CheckRange===" + range);
                return range;
            }
        }

        private void BuildSelectedEff(RectTransform selectedCellRtt)
        {
            if (selectPrefab == null)
                return;

            RectTransform selTrans;
            if (_SelectedEff == null)
            {
                _SelectedEff = UIUtil.InstantiateCell(gameObject, selectPrefab, _ListCellContainer.transform, ref _WinName);
                _SelectedEff.transform.localScale = Vector3.one;
                selTrans = _SelectedEff.GetComponent<RectTransform>();
                selTrans.anchorMax = selectedCellRtt.anchorMax;
                selTrans.anchorMin = selectedCellRtt.anchorMin;
                selTrans.pivot = selectedCellRtt.pivot;
            }
            else
            {
                selTrans = _SelectedEff.GetComponent<RectTransform>();
            }
            _SelectedEff.gameObject.SetActive(true);
            Vector2 offset = (selTrans.sizeDelta - selectedCellRtt.sizeDelta) / 2;
            if(direction == Direction.Up || direction == Direction.Left)
            {
                offset.y = -offset.y;
            }
            else if(direction == Direction.Right)
            {
                offset *= -1;
            }
            selTrans.anchoredPosition = selectedCellRtt.anchoredPosition - offset;
        }

        /// <summary>
        /// Scroll移动时回调
        /// </summary>
        private void HandleValueChanged(Vector2 data)
        {

            if (_Looping)
            {
                CheckCells();
            }
            if (_LuaOnScrolling != null)
            {
                _LuaOnScrolling(_LuaTableOnScroll, data);
            }
        }

        [SLua.DoNotToLua]
        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left)
                return;

            var range = _CheckRange;
            for (int i = 0; i <= (int)range.y; ++i)
            {
                if (_CellCache.ContainsKey(i))
                {
                    var cell = _CellCache[i];
                    var trans = cell.GetComponent<RectTransform>();
                    bool pressCell = RectTransformUtility.RectangleContainsScreenPoint(trans, eventData.pressPosition, eventData.pressEventCamera); //按下位置是否在Cell上
                    bool upCell = RectTransformUtility.RectangleContainsScreenPoint(trans, eventData.position, eventData.pressEventCamera);         //抬起位置是否在Cell上
                    if (pressCell != upCell)
                    {//按下和抬起不在同一个Cell上
                        break;
                    }
                    else if (pressCell && upCell)
                    {
                        SetSelectedByIndex(i, true, true);
                        break;
                    }
                }
            }
        }
    }
}
