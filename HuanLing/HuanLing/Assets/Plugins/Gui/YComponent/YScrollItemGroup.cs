using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using SLua;

namespace UYMO
{
    /// <summary>
    /// 滑动item数据
    /// </summary>
    public class YScrollItem
    {
        /// <summary>
        /// 数据下标
        /// </summary>
        public int index;

        /// <summary>
        /// 大小
        /// 若是横向滑动，只考虑width
        /// 若是纵向滑动，只考虑height
        /// </summary>
        public Vector2 size;

        /// <summary>
        /// 距离原点的偏移
        /// 若是横向滑动，只考虑x
        /// 若是纵向滑动，只考虑y
        /// </summary>
        public Vector2 offset;

        /// <summary>
        /// 对应的GameObjcet
        /// 在需要生成的时候生成
        /// </summary>
        public GameObject itemObject;
    }
    [CustomLuaClass]
    [AddComponentMenu("YUI/YScrollItemGroup", 15)]
    [ExecuteInEditMode]
    [RequireComponent(typeof(RectTransform), typeof(YImage))]
    public class YScrollItemGroup : UIBehaviour, IClearable
    {
        public enum Direction
        {
            Horizontal,
            Vertical
        }

        public Direction direction;
        public GameObject cellPrefab;

        private LuaTable _LuaClassInstance;
        private YScrollRect _UYScrollRect;
        private GameObject _ListCellContainer;
        private RectTransform _Content;
        private Mask _Mask;

        private Action<LuaTable, int, GameObject> _LuaUpdateCellCallback;

        private LinkedList<YScrollItem> _CellList = new LinkedList<YScrollItem>();

        private int _DataCount;
        private Vector2 _CurrentOffset = Vector2.zero;
        private Vector2 _CheckRange;
        private bool needLoop;
        private Dictionary<int, float> hasCountSize = new Dictionary<int, float>();

        private Queue<YScrollItem> _ReusablebleQueue = new Queue<YScrollItem>();
        private string _WinName = null;


        public void SetluaUpdateCellCallback(LuaTable lua, Action<LuaTable, int, GameObject> callback)
        {
            _LuaClassInstance = lua;
            _LuaUpdateCellCallback = callback;
        }

        public void ClearLuaHandler()
        {
            _LuaClassInstance = null;
            _LuaUpdateCellCallback = null;
        }

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

        private void GameAwake()
        {
            _Mask = gameObject.GetComponent<Mask>();
            _ListCellContainer = gameObject.transform.Find("ListCellContainer").gameObject;
            _UYScrollRect = gameObject.GetComponent<YScrollRect>();
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
            _Content.anchorMax = Vector2.zero;
            _Content.anchorMin = Vector2.zero;
            _Content.pivot = Vector2.zero;
            _Content.anchoredPosition = Vector2.zero;

            _CheckRange = _Content.sizeDelta * 2;
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
            _Content.anchorMax = Vector2.zero;
            _Content.anchorMin = Vector2.zero;
            _Content.pivot = Vector2.zero;
        }

        public void InitGroup(int size)
        {
            _ReusablebleQueue.Clear();
            var first = _CellList.First;
            while (first != null)
            {
                _ReusablebleQueue.Enqueue(first.Value);
                first = first.Next;
            }
            _CellList.Clear();


            _DataCount = size;
            hasCountSize.Clear();
            _Content.anchoredPosition = Vector2.zero;
            needLoop = false;
            float totalSize = 0;
            for (int i = size - 1; i >= 0; --i)
            {
                YScrollItem cellItem;
                if (_ReusablebleQueue.Count > 0)
                {
                    cellItem = _ReusablebleQueue.Dequeue();
                }
                else
                {
                    cellItem = new YScrollItem();
                    var cell = UIUtil.InstantiateCell(gameObject, cellPrefab, ref _WinName);
                    cell.transform.SetParent(_ListCellContainer.transform);
                    cell.transform.localScale = Vector3.one;
                    cellItem.itemObject = cell;
                }

                if (_LuaClassInstance != null && _LuaUpdateCellCallback != null)
                    _LuaUpdateCellCallback(_LuaClassInstance, i + 1, cellItem.itemObject);

                var cellRtf = cellItem.itemObject.GetComponent<RectTransform>();
                cellRtf.anchorMax = new Vector2(0.5f, 0.0f);
                cellRtf.anchorMin = new Vector2(0.5f, 0.0f);
                cellRtf.pivot = new Vector2(0.5f, 0.0f);

                cellItem.index = i;
                cellItem.size = cellRtf.sizeDelta;
                cellItem.offset = new Vector2(0, totalSize);

                _CellList.AddFirst(cellItem);
                cellRtf.anchoredPosition = cellItem.offset;

                totalSize += cellItem.size.y;
                hasCountSize.Add(i, cellItem.size.y);
                if (totalSize > _CheckRange.y)
                {
                    needLoop = true;
                    break;
                }
            }

            ClearCell();

            _Content.sizeDelta = new Vector2(_Content.sizeDelta.x, totalSize);
        }

        public void UpdateGroup(int size)
        {
            if (size < _DataCount)
            {
                InitGroup(size);
                return;
            }
            if (_CellList.Count == 0)
            {
                InitGroup(size);
            }
            else
            {
                _DataCount = size;


                if (-_Content.anchoredPosition.y < _CheckRange.y / 2)
                {
                    InitGroup(size);
                    return;
                }
            }
        }

        public void UpdateGroup()
        {
            UpdateGroup(_DataCount);
        }

        private void HandleValueChanged(Vector2 data)
        {
            if (needLoop)
            {
                UpdateCells();
            }
        }

        private void UpdateCells()
        {
            var currentPosY = _Content.anchoredPosition.y;
            var offset = currentPosY - _CurrentOffset.y;
            offset = -offset;
            _CurrentOffset = _Content.anchoredPosition;
            if (offset > 0)
            {
                var lastItem = _CellList.Last.Value;

                while (lastItem.offset.y + currentPosY < -_CheckRange.y / 4 )
                {
                    var firstItem = _CellList.First.Value;
                    if (firstItem.index == 0)
                    {
                        break;
                    }
                    if (_LuaClassInstance != null && _LuaUpdateCellCallback != null)
                        _LuaUpdateCellCallback(_LuaClassInstance, firstItem.index, lastItem.itemObject);

                    var cellRtf = lastItem.itemObject.GetComponent<RectTransform>();
                    lastItem.size = cellRtf.sizeDelta;
                    lastItem.index = firstItem.index - 1;
                    lastItem.offset = new Vector2(0, firstItem.offset.y + firstItem.size.y);
                    cellRtf.anchoredPosition = lastItem.offset;
                    _CellList.AddFirst(lastItem);
                    _CellList.RemoveLast();


                    if (!hasCountSize.ContainsKey(lastItem.index))
                    {
                        hasCountSize.Add(lastItem.index, lastItem.size.y);
                        _Content.sizeDelta = new Vector2(_Content.sizeDelta.x, _Content.sizeDelta.y + lastItem.size.y);
                    }
                    else
                    {
                        var preSize = hasCountSize[lastItem.index];
                        if (preSize != lastItem.size.y)
                        {
                            _Content.sizeDelta = new Vector2(_Content.sizeDelta.x, _Content.sizeDelta.y + lastItem.size.y - preSize);
                        }
                    }
                    lastItem = _CellList.Last.Value;
                }
            }
            else if (offset < 0)
            {
                var firstItem = _CellList.First.Value;

                while (firstItem.offset.y + currentPosY > _CheckRange.y / 4 * 3)          
                {
                    var lastItem = _CellList.Last.Value;
                    if (lastItem.index == _DataCount - 1)
                    {
                        break;
                    }
                    if (_LuaClassInstance != null && _LuaUpdateCellCallback != null)
                        _LuaUpdateCellCallback(_LuaClassInstance, lastItem.index + 2, firstItem.itemObject);

                    var cellRtf = firstItem.itemObject.GetComponent<RectTransform>();
                    firstItem.size = cellRtf.sizeDelta;
                    firstItem.index = lastItem.index + 1;
                    firstItem.offset = new Vector2(0, lastItem.offset.y - firstItem.size.y);
                    cellRtf.anchoredPosition = firstItem.offset;
                    _CellList.AddLast(firstItem);
                    _CellList.RemoveFirst();


                    if (!hasCountSize.ContainsKey(firstItem.index))
                    {
                        var addSizeY = firstItem.size.y;
                        hasCountSize.Add(firstItem.index, firstItem.size.y);
                        _Content.sizeDelta = new Vector2(_Content.sizeDelta.x, _Content.sizeDelta.y + firstItem.size.y);


                        var first = _CellList.First;
                        while (first != null)
                        {
                            cellRtf = first.Value.itemObject.GetComponent<RectTransform>();
                            cellRtf.anchoredPosition = new Vector2(cellRtf.anchoredPosition.x, cellRtf.anchoredPosition.y + addSizeY);
                            first.Value.offset = cellRtf.anchoredPosition;
                            first = first.Next;
                        }
                        _Content.anchoredPosition = new Vector2(_Content.anchoredPosition.x, _Content.anchoredPosition.y - addSizeY);
                    }
                    else
                    {
                        var preSize = hasCountSize[firstItem.index];
                        if (preSize != firstItem.size.y)
                        {
                            _Content.sizeDelta = new Vector2(_Content.sizeDelta.x, _Content.sizeDelta.y + firstItem.size.y - preSize);
                        }
                    }

                    firstItem = _CellList.First.Value;
                }
            }

        }
    
        public void Clear()
        {
            ClearCell();
            ClearLuaHandler();
        }

        public GameObject GetCellByIndex(int index)
        {
            var first = _CellList.First;
            while (first != null)
            {
                if(first.Value.index == index)
                {
                    return first.Value.itemObject;
                }
                first = first.Next;
            }
            return null;
        }

        void ClearCell()
        {
            while (_ReusablebleQueue.Count > 0)
            {
                var item = _ReusablebleQueue.Dequeue();
                UIUtil.GabageCell(item.itemObject);
            }
            _ReusablebleQueue.Clear();
        }
    }
}