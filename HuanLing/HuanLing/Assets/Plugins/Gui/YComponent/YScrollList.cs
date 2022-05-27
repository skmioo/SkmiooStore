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
    [AddComponentMenu("YUI/YScrollList", 11)]
    [ExecuteInEditMode]
    [RequireComponent(typeof(RectTransform), typeof(YImage))]
    public class YScrollList : UIBehaviour, IClearable, IPointerClickHandler
    {
        /// <summary>
        /// ScrollList方向枚举
        /// </summary>
        public enum Direction
        {
            Horizontal,
            Vertical
        }
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

        private string _WinName = null;

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
                        //scrollBar.gameObject.hideFlags = HideFlags.HideInHierarchy;
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
                ;
            }
            private set { }
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
                        //scrollbar.gameObject.hideFlags = HideFlags.HideInHierarchy;
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
            private set { }
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
        /// 设置数据cout
        /// </summary>
        public void SetDataCount(int count)
        {
            _DataCount = count;
            ResetCells();
            CheckCells();

            int cols, row;
            if (direction == Direction.Vertical)
            {
                row = Mathf.CeilToInt((count - 1) / (int)rowCols.y) + 1; //行
                _Content.sizeDelta = new Vector2(_Content.sizeDelta.x, row * (_CellSize.y + space.y));
            }
            else
            {
                cols = Mathf.CeilToInt((count - 1) / (int)rowCols.x) + 1;//列
                _Content.sizeDelta = new Vector2(cols * (_CellSize.x + space.x), _Content.sizeDelta.y);
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
        /// 根据Index获得对应的Cell
        /// 若超出缓存范围，则返回null
        /// </summary>
        public GameObject GetCellByIndex(int luaIndex)
        {
            GameObject rtn = null;
            _CellCache.TryGetValue(luaIndex - 1, out rtn);
            return rtn;
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
        /// 当前所处于的步数
        /// 以行或列为单位，取决于滚动方向
        /// </summary>
        public float currentStep
        {
            get
            {
                return currentOffset / _StepLength;
            }
            set
            {
                _UYScrollRect.StopMovement();
                var targetOffset = value * _StepLength;
                if (direction == Direction.Horizontal)
                {
                    _Content.anchoredPosition = new Vector2(-targetOffset, _Content.anchoredPosition.y);
                }
                else if (direction == Direction.Vertical)
                {
                    _Content.anchoredPosition = new Vector2(_Content.anchoredPosition.x, targetOffset);
                }
            }
        }
        /// <summary>
        /// 当前Content位移(绝对值)
        /// </summary>
        public float currentOffset
        {
            get
            {
                var offset = direction == Direction.Horizontal ? -_Content.anchoredPosition.x : _Content.anchoredPosition.y;
                return offset < 0 ? 0 : offset;
            }
        }
        /// <summary>
        /// 通过步数移动
        /// </summary>
        public void MoveByStep(int step)
        {
            MoveByStep(step, false);
        }
        /// <summary>
        /// 通过步数移动
        /// </summary>
        /// <param name="step">移动的步数，step>0为正方向，step<0为反方向</param>
        /// <param name="interrupt">是否打断当前的Move</param>
        /// <param name="speed">速度=0 默认速度，-1 不做动画</param>
        private void _CalculateStep(int step, bool interrupt, float speed)
        {
            float targetStep;

            if (step > 0)
            {
                targetStep = Mathf.FloorToInt(currentStep + 0.01f) + step;
            }
            else
            {
                targetStep = Mathf.CeilToInt(currentStep - 0.01f) + step;
            }

            float targetOffset = targetStep * _StepLength;
            if (targetOffset < 0)
            {
                targetOffset = -20.0f;
            }
            else if (targetOffset > _MaxOffset)
            {
                targetOffset = _MaxOffset + 20.0f;
            }
            var targetPosition = direction == Direction.Horizontal ? new Vector2(-targetOffset, _Content.anchoredPosition.y) : new Vector2(_Content.anchoredPosition.x, targetOffset);
            if (speed == -1)
            {
                _UYScrollRect.ScrollToPosition(targetPosition, interrupt, -1);
            }
            else
            {
                _UYScrollRect.ScrollToPosition(targetPosition, interrupt);
            }
        }
        /// <summary>
        /// 通过步数移动
        /// </summary>
        /// <param name="step">移动的步数，step>0为正方向，step<0为反方向</param>
        /// <param name="interrupt">是否打断当前的Move</param>
        public void MoveByStep(int step, bool interrupt)
        {
            _CalculateStep(step, interrupt, 0);
        }

        /// <summary>
        /// 直接滚动对应位置，不做滑动动画
        /// </summary>
        /// <param name="step"></param>
        /// <param name="interrupt"></param>
        /// <param name="fresh">是否刷新缓存</param>
        /// <param name="speed">滑动速度</param>
        public void MoveByStep(int step, bool interrupt, bool fresh, float speed)
        {
            _CalculateStep(step, interrupt, speed);
            if (fresh)
            {
                RefreshCells();
            }
        }
        /// <summary>
        /// 设置到最大步数
        /// </summary>
        public void SetToMaxStep()
        {
            _UYScrollRect.normalizedPosition = direction == Direction.Horizontal ? new Vector2(0.0f, _UYScrollRect.normalizedPosition.y) : new Vector2(_UYScrollRect.normalizedPosition.x, 0.0f);
        }

        /// <summary>
        /// 设置到头部
        /// </summary>
        public void SetToZeroStep()
        {
            _UYScrollRect.normalizedPosition = direction == Direction.Horizontal ? new Vector2(1.0f, _UYScrollRect.normalizedPosition.y) : new Vector2(_UYScrollRect.normalizedPosition.x, 1.0f);
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
        /// 数据格式
        /// </summary>
        private int _DataCount;
        /// <summary>
        /// Cell的Size数据
        /// </summary>
        private Vector2 _CellSize;
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
        /// 已回收可复用的Cells
        /// </summary>
        private Queue<GameObject> _ReuseableCells = new Queue<GameObject>();
        /// <summary>
        /// Cell缓存
        /// </summary>
        private Dictionary<int, GameObject> _CellCache = new Dictionary<int, GameObject>();
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
        /// <summary>
        /// 选中更改回调
        /// </summary>
        private Action<object, GameObject, int, int> _SelectChangedCallback = null;
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
                    int beginStep = Mathf.FloorToInt(currentStep) - 2;
                    int beginIndex = direction == Direction.Horizontal ? beginStep * (int)rowCols.x : beginStep * (int)rowCols.y;
                    range.x = beginIndex;
                    range.y = beginIndex + _CellCacheNumber - 1;
                }
                return range;
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
                    cellRtf.anchorMax = Vector2.up;
                    cellRtf.anchorMin = Vector2.up;
                    cellRtf.pivot = Vector2.up;
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

        private List<int> _UnVisibleList = new List<int>();
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
        /// 同个cell是否只触发一次
        /// </summary>
        private bool _TriggerOnce = true;

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
            _Content.anchorMax = Vector2.up;
            _Content.anchorMin = Vector2.up;
            _Content.pivot = Vector2.up;
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
            switch (direction)
            {
                case Direction.Horizontal:
                    {
                        _UYScrollRect.horizontal = true;
                        _UYScrollRect.vertical = false;
                        break;
                    }
                case Direction.Vertical:
                    {
                        _UYScrollRect.horizontal = false;
                        _UYScrollRect.vertical = true;
                        break;
                    }
            }

            _Content = _UYScrollRect.content;
            _Content.anchorMax = Vector2.up;
            _Content.anchorMin = Vector2.up;
            _Content.pivot = Vector2.up;
            _Content.anchoredPosition = Vector2.zero;
            ResetCellSize();
        }

        public void ResetCellSize()
        {
            _CellSize = cellPrefab.GetComponent<RectTransform>().rect.size;
            _StepLength = direction == Direction.Horizontal ? space.x + _CellSize.x : space.y + _CellSize.y;
            var size = gameObject.GetComponent<RectTransform>().rect;
            rowCols = direction == Direction.Horizontal ? new Vector2(rowCols.x, Mathf.FloorToInt(size.width / (_CellSize.x + space.x))) : new Vector2(Mathf.FloorToInt(size.height / (_CellSize.y + space.y)), rowCols.y);
            _BufferNumber = direction == Direction.Horizontal ? 4 * (int)rowCols.x : 4 * (int)rowCols.y;
            _BufferNumber += (int)rowCols.x * (int)rowCols.y;
        }
        public void SetRowCols(uint x, uint y)
        {
            rowCols = new Vector2(x, y);
            var size = gameObject.GetComponent<RectTransform>().rect;
            rowCols = direction == Direction.Horizontal ? new Vector2(rowCols.x, Mathf.FloorToInt(size.width / (_CellSize.x + space.x))) : new Vector2(Mathf.FloorToInt(size.height / (_CellSize.y + space.y)), rowCols.y);
            _BufferNumber = direction == Direction.Horizontal ? 4 * (int)rowCols.x : 4 * (int)rowCols.y;
            _BufferNumber += (int)rowCols.x * (int)rowCols.y;
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
        /// <summary>
        /// 设置Cell数据
        /// </summary>
        private void SetCell(GameObject cell, int index)
        {
            if (index < 0 || index >= _DataCount)
            {
                return;
            }

            var cellRtf = cell.GetComponent<RectTransform>();
            int cols, row;
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

            Vector3 cellPosition;
            cellPosition.x = space.x * (cols + 1) + _CellSize.x * cols;
            cellPosition.y = -(space.y * (row + 1) + _CellSize.y * row);
            cellPosition.z = 0;
            if (hideFirstOffset && direction == Direction.Vertical) //这里面有特殊需求少计算一个空格
                cellPosition.y += space.y;
            cellRtf.anchoredPosition3D = cellPosition;

            //Profiler.BeginSample("_UpdateCellCallback");
            if (_LuaTable != null && _UpdateCellCallback != null)
                _UpdateCellCallback(_LuaTable, cell, index + 1);
            //Profiler.EndSample();

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

        private bool _SetCellSelectCBFlag = false;

        /// <summary>
        /// 移动一步所需要的距离
        /// </summary>
        private float _StepLength;
        /// <summary>
        /// 最大的Offset
        /// </summary>
        private float _MaxOffset
        {
            get { return direction == Direction.Horizontal ? _Content.rect.width - gameObject.GetComponent<RectTransform>().rect.width : _Content.rect.height - gameObject.GetComponent<RectTransform>().rect.height; }
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

            _SelectedEff = UIUtil.GabageCell(_SelectedEff);
        }


        void ClearCell()
        {
            while (_ReuseableCells.Count > 0)
            {
                UIUtil.GabageCell(_ReuseableCells.Dequeue());
            }
        }
        /// <summary>
        /// 当前选中的Cell index,未选中返回-1 从0开始
        /// </summary>
        public int selectedIndex
        {
            get { return _SelectedCell; }
            set
            {
                SetSelectedByIndex(value, true, false);
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
                    if(direction == Direction.Horizontal)
                    {
                        currentStep = Mathf.CeilToInt(_DataCount / (int)rowCols.x);
                    }
                    else
                    {
                        currentStep = Mathf.CeilToInt(_DataCount / (int)rowCols.y);
                    }
                    currentStep = idx;
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
        /// 取消同一cell只能触发一次的限制
        /// </summary>
        public void CancelTriggerOnce()
        {
            _TriggerOnce = false;
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
                selTrans.anchorMax = Vector2.up;
                selTrans.anchorMin = Vector2.up;
                selTrans.pivot = Vector2.up;
            }
            else
            {
                selTrans = _SelectedEff.GetComponent<RectTransform>();
            }
            _SelectedEff.gameObject.SetActive(true);
            Vector2 offset = (selTrans.sizeDelta - selectedCellRtt.sizeDelta) / 2;
            offset.y = -offset.y;
            selTrans.anchoredPosition = selectedCellRtt.anchoredPosition - offset;
        }
    }
}
