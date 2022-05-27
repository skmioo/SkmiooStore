using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using SLua;
using DG.Tweening;

namespace UYMO
{
    [CustomLuaClassAttribute]
    [ExecuteInEditMode]
    [RequireComponent(typeof(RectTransform), typeof(YImage))]
    public class YScrollView : UIBehaviour, IClearable, IBeginDragHandler, IInitializePotentialDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
    {
        private enum MoveDirection
        {
            None,
            UpOrLeft,
            DownOrRight,
        }

        public enum Alignment
        {
            UpOrLeft,
            Middle,
            DownOrRight,
        }

        /// 滚动方向
        public enum Direction
        {
            Horizontal, //水平
            Vertical  //竖直
        }

        [Tooltip("滑动的方向")]
        public Direction direction = Direction.Horizontal;

        [Tooltip("显示数目")]
        public int showCellNum = 1;

        /// cell的prefab
        [Tooltip("列表里的cell")]
        public GameObject cellPrefab;

        /// 间距
        [Tooltip("Cell之间的间距")]
        public Vector2 cellSpace = Vector2.zero;

        [Tooltip("是否可以循环")]
        public bool canLoop = false;

        [Tooltip("滑动灵敏度")]
        public int scrollFactor = 2;
        [Tooltip("对其方式")]
        public Alignment alignment = Alignment.UpOrLeft;

        private List<GameObject> _CellList;                                         // CellList
        private int _DataCount;                                                     // 实际Cell个数
        private LuaTable _LuaTable;                                                 // 更新Cell回调
        private LuaTable _MoveBeginLuaTable;
        private LuaTable _MoveEndLuaTable;
        private LuaTable _SelectLuaTable;
        private Action<LuaTable, GameObject, int> _UpdateCellCallBack;
        private Action<LuaTable> _MoveEndCallBack;                                  // 移动结束回调
        private Action<LuaTable> _MoveBeginCallBack;                                // 开始移动回调
        private Action<LuaTable, GameObject, int> _SelectCallBack;                  // 点击事件Lua回调
        private Tweener _Tweener;                                                   // DOTween对象
        private GameObject _ListCellContainer;                                      // ListCell容器
        private RectTransform _ListCellConRtf;
        private Vector2 _DragBeginPos;                                              // 拖动开始位置
        private Vector2 _DragPos;                                                   // 拖动中的位置
        private int _RealIndex;                                                     // 真实索引
        private float _CellWidth;                                                   // Cell 宽度
        private float _CellHeight;                                                  // Cell 高度
        private int _CellMoveIndex;                                                 // Cell 移动的索引 左移减1 右移加1
        private MoveDirection _MoveDir;                                             // 移动方向

        private string _WinName = null;

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
        protected override void OnDestroy()
        {
            ObjectPool.goListPool.Gabage(_CellList);
            base.OnDestroy();
        }
        private void EditorAwake()
        {
            Mask mask = gameObject.GetComponent<Mask>();
            if (mask == null)
            {
                gameObject.AddComponent<Mask>();
            }
            var conTransform = gameObject.transform.Find("ListCellContainer");
            if (conTransform == null)
            {
                _ListCellContainer = new GameObject("ListCellContainer");
                _ListCellConRtf = _ListCellContainer.AddComponent<RectTransform>();
                _ListCellConRtf.SetParent(gameObject.transform);
                _ListCellConRtf.localScale = Vector3.one;
                _ListCellConRtf.localPosition = Vector3.zero;
            }
            else
            {
                _ListCellContainer = conTransform.gameObject;
                _ListCellConRtf = _ListCellContainer.GetComponent<RectTransform>();
                if (!_ListCellConRtf)
                {
                    _ListCellConRtf = _ListCellContainer.AddComponent<RectTransform>();
                }
            }
            _ListCellConRtf.sizeDelta = gameObject.GetComponent<RectTransform>().rect.size;
            _ListCellConRtf.anchorMax = Vector2.up;
            _ListCellConRtf.anchorMin = Vector2.up;
            _ListCellConRtf.pivot = Vector2.up;
        }
        private void GameAwake()
        {
            var cellRtf = cellPrefab.GetComponent<RectTransform>();
            _CellWidth = cellRtf.rect.width;
            _CellHeight = cellRtf.rect.height;
            _ListCellContainer = gameObject.transform.Find("ListCellContainer").gameObject;
            _ListCellConRtf = _ListCellContainer.GetComponent<RectTransform>();
            switch (alignment)
            {
                case Alignment.UpOrLeft:
                    _ListCellConRtf.anchorMax = Vector2.up;
                    _ListCellConRtf.anchorMin = Vector2.up;
                    _ListCellConRtf.pivot = Vector2.up;
                    break;
                case Alignment.Middle:
                    _ListCellConRtf.anchorMax = new Vector2(0.5f, 0.5f);
                    _ListCellConRtf.anchorMin = new Vector2(0.5f, 0.5f);
                    _ListCellConRtf.pivot = new Vector2(0.5f, 0.5f);
                    break;
                case Alignment.DownOrRight:
                    _ListCellConRtf.anchorMax = Vector2.one;
                    _ListCellConRtf.anchorMin = Vector2.one;
                    _ListCellConRtf.pivot = Vector2.one;
                    break;
            }
        }

        // Cell 宽度加上间隔
        private float _CellTWidth
        {
            get
            {
                return (_CellWidth + cellSpace.x);
            }
        }

        // Cell 高度加上间隔
        private float _CellTHeight
        {
            get
            {
                return (_CellHeight + cellSpace.y);
            }
        }

        // 设置Cell数量
        public void SetDataCount(int count)
        {
            _DragBeginPos = float.MaxValue * Vector2.one;
            _DataCount = count;
            RectTransform thisRtf = gameObject.GetComponent<RectTransform>();
            float w = 0;
            float h = 0;
            if (_DataCount > 0)
            {
                w = (direction == Direction.Horizontal) ? showCellNum * _CellWidth + (showCellNum - 1) * cellSpace.x : thisRtf.sizeDelta.x;
                h = (direction == Direction.Horizontal) ? thisRtf.sizeDelta.y : showCellNum * _CellHeight + (showCellNum - 1) * cellSpace.y;
            }
            w = Math.Max(w, thisRtf.sizeDelta.x);
            h = Math.Max(h, thisRtf.sizeDelta.y);
            _ListCellConRtf.sizeDelta = new Vector2(w, h);
            _ClearAllCell();
            _RealIndex = 0;
            _CellMoveIndex = 0;
            int totalCellNum = showCellNum + 2;
            if (_CellList == null)
            {
                _CellList = ObjectPool.goListPool.Create();
            }
            GameObject cellObj;
            RectTransform cellObjRect;
            float offsetX = 0;
            float offsetY = 0;
            for (int i = 0; i < totalCellNum; i++)
            {
                int cellShowIndex = i - 1;
                cellObj = UIUtil.InstantiateCell(gameObject, cellPrefab, ref _WinName);
                cellObjRect = cellObj.GetComponent<RectTransform>();
                cellObjRect.anchorMin = Vector2.up;
                cellObjRect.anchorMax = Vector2.up;
                cellObjRect.pivot = Vector2.up;
                _CellList.Add(cellObj);
                cellObj.transform.SetParent(_ListCellContainer.transform);
                cellObjRect.localScale = Vector3.one;
                offsetX = (this.direction == Direction.Horizontal) ? _CellTWidth * cellShowIndex : 0;
                offsetY = (this.direction == Direction.Horizontal) ? 0 : _CellTHeight * cellShowIndex;
                cellObjRect.anchoredPosition = new Vector2(offsetX, offsetY);
                if (_UpdateCellCallBack != null)
                {
                    if (_DataCount != 0)
                    {
                        int realIndex = ((cellShowIndex + _DataCount) % _DataCount) + 1;
                        _UpdateCellCallBack(_LuaTable, cellObj, realIndex);
                    }
                }
            }
            _ListCellConRtf.anchoredPosition = Vector2.zero;
        }

        /// <summary>
        /// 设置lua回调
        /// </summary>
        /// <param name="lua"></param>
        /// <param name="callback"></param>
        public void SetUpdateCellCallBack(LuaTable lua, Action<LuaTable, GameObject, int> callback)
        {
            _LuaTable = lua;
            _UpdateCellCallBack = callback;
        }
        /// <summary>
        /// 设置移动开始回调
        /// </summary>
        public void SetMoveBeginCallBack(LuaTable lua, Action<LuaTable> callback)
        {
            _MoveBeginLuaTable = lua;
            _MoveBeginCallBack = callback;
        }
        /// <summary>
        /// 设置移动结束回调
        /// </summary>
        public void SetMoveEndCallBack(LuaTable lua, Action<LuaTable> endMove)
        {
            _MoveEndLuaTable = lua;
            _MoveEndCallBack = endMove;
        }
        /// <summary>
        /// 设置选中回调
        /// </summary>
        public void SetSelectCallBack(LuaTable lua, Action<LuaTable, GameObject, int> callback)
        {
            _SelectLuaTable = lua;
            _SelectCallBack = callback;
        }

        /// <summary>
        /// 获取Cell GameObject 传进来的是RealIndex 数据的Index
        /// </summary>
        public GameObject GetCellObj(int index)
        {
            if (index < 1 || index > _DataCount)
            {
                return null;
            }
            int i = (index + _DataCount - realIndex) % _DataCount + 1;
            return _CellList[i];
        }

        /// <summary>
        /// 当前实际Index接口
        /// lua 下标从1开始
        /// </summary>
        public int realIndex
        {
            get
            {
                return _RealIndex + 1;
            }
            set
            {
                if (value < 1 || value > _DataCount)
                {
                    return;
                }
                if (_CellList == null || _IsMoving())
                {
                    return;
                }
                _RealIndex = value - 1;
                _ClearTween();
                for (var i = 0; i < _CellList.Count; i++)
                {
                    if (_UpdateCellCallBack != null)
                    {
                        var cellObj = _CellList[i];
                        int rI = (_RealIndex + i) % _DataCount;
                        rI = (rI == 0) ? _DataCount : rI;
                        _UpdateCellCallBack(_LuaTable, cellObj, rI);
                    }
                }
                if (_MoveEndCallBack != null)
                {
                    _MoveEndCallBack(_MoveEndLuaTable);
                }
            }
        }

        // 中心Index
        public int centerIndex
        {
            get
            {
                var cI = (realIndex + Mathf.FloorToInt(showCellNum / 2)) % _DataCount;
                cI = (cI == 0) ? _DataCount : cI;
                return cI;
            }
            set
            {
                var rI = (value - Mathf.FloorToInt(showCellNum / 2) + _DataCount) % _DataCount;
                rI = (rI == 0) ? _DataCount : rI;
                realIndex = rI;
            }
        }


        // 清除全部的Cell
        private void _ClearAllCell()
        {
            if (_CellList == null)
            {
                return;
            }
            for (int i = 0; i < _CellList.Count; i++)
            {
                UIUtil.GabageCell(_CellList[i]);
            }
            _CellList.Clear();
        }

        public virtual void OnInitializePotentialDrag(PointerEventData data)
        {
        }


        /// <summary>
        /// 移动Cell
        /// </summary>
        /// <param name="offset">偏移值</param>
        /// <param name="direction"> MoveDirection </param>
        private void _CellMove(float offsetValue)
        {
            Vector2 pos = (direction == Direction.Horizontal) ? new Vector2(offsetValue, 0) : new Vector2(0, offsetValue);
            pos += _ListCellConRtf.anchoredPosition;
            _ListCellConRtf.anchoredPosition = pos;
        }

        // 左 或 上 移动
        public void MoveUpOrLeft()
        {
            if (realIndex == _DataCount && !canLoop)
            {
                return;
            }
            _MoveStep(MoveDirection.UpOrLeft);
        }

        // 右 或 下 移动
        public void MoveDownOrRight()
        {
            if (_RealIndex == 0 && !canLoop)
            {
                return;
            }
            _MoveStep(MoveDirection.DownOrRight);
        }


        private void _MoveStep(MoveDirection moveDir, int step = 1)
        {
            if (_IsMoving())
            {
                return;
            }
            Vector2 pos = Vector2.zero;
            _MoveDir = moveDir;
            if (moveDir == MoveDirection.UpOrLeft)
            {
                _CellMoveIndex -= step;
            }
            else if (moveDir == MoveDirection.DownOrRight)
            {
                _CellMoveIndex += step;
            }
            pos = (direction == Direction.Horizontal) ? new Vector2(_CellMoveIndex * _CellTWidth, 0) : new Vector2(0, _CellMoveIndex * _CellTHeight);
            _ClearTween();
            this._Tweener = _ListCellConRtf.DOAnchorPos(pos, 0.3f).OnComplete(_OnMoveEnd);
        }


        // 移动结束
        private void _OnMoveEnd()
        {
            _ClearTween();
            GameObject updateCellObj = _CellList[0];
            int updateIndex = _RealIndex;
            Vector2 movePos = (direction == Direction.Horizontal) ? new Vector2(_CellTWidth, 0) : new Vector2(0, _CellTHeight);
            if (_MoveDir == MoveDirection.UpOrLeft)
            {
                _RealIndex = (_RealIndex + 1) % _DataCount;
                updateCellObj = _CellList[0];
                updateCellObj.GetComponent<RectTransform>().anchoredPosition = _CellList[_CellList.Count - 1].GetComponent<RectTransform>().anchoredPosition + movePos;
                for (int i = 0; i < _CellList.Count - 1; i++)
                {
                    _CellList[i] = _CellList[i + 1];
                }
                _CellList[_CellList.Count - 1] = updateCellObj;
                updateIndex = (_RealIndex + showCellNum) % _DataCount + 1;
            }
            else if (_MoveDir == MoveDirection.DownOrRight)
            {
                _RealIndex = (_RealIndex - 1 + _DataCount) % _DataCount;
                updateCellObj = _CellList[_CellList.Count - 1];
                updateCellObj.GetComponent<RectTransform>().anchoredPosition = _CellList[0].GetComponent<RectTransform>().anchoredPosition - movePos;
                for (int i = _CellList.Count - 1; i > 0; i--)
                {
                    _CellList[i] = _CellList[i - 1];
                }
                _CellList[0] = updateCellObj;
                updateIndex = (_RealIndex - 1 + _DataCount) % _DataCount + 1;
            }
            if (_UpdateCellCallBack != null && _MoveDir != MoveDirection.None)
            {
                _UpdateCellCallBack(_LuaTable, updateCellObj, updateIndex);
            }
            if (_MoveEndCallBack != null)
            {
                _MoveEndCallBack(_MoveEndLuaTable);
            }
        }


        private void _ClearTween()
        {
            if (_Tweener != null)
            {
                _Tweener.Kill();
            }
            _Tweener = null;
        }

        /// 拖拽开始回调
        /// </summary>
        /// <param name="data"></param>
        public virtual void OnBeginDrag(PointerEventData data)
        {
            _DragBeginPos = _DragPos = data.position;
            if (_MoveBeginCallBack != null)
            {
                _MoveBeginCallBack(_MoveBeginLuaTable);
            }
        }

        /// <summary>
        /// 拖拽结束回调
        /// </summary>
        /// <param name="data"></param>
        public virtual void OnEndDrag(PointerEventData data)
        {
            Vector2 endPos = data.position;
            Vector2 offset = endPos - _DragBeginPos;
            float offsetValue = (direction == Direction.Horizontal) ? offset.x : offset.y;
            float scrollDis = ((direction == Direction.Horizontal) ? _CellWidth : _CellHeight) / scrollFactor;
            _DragBeginPos = _DragPos = Vector2.one * float.MaxValue;
            if (offsetValue > 0)
            {
                //向右滑动
                if (offsetValue < scrollDis)
                {
                    _MoveStep(MoveDirection.None);
                }
                else
                {
                    MoveDownOrRight();
                }
            }
            else if (offsetValue < 0)
            {
                //向左滑动
                if (offsetValue > -scrollDis)
                {
                    _MoveStep(MoveDirection.None);
                }
                else
                {
                    MoveUpOrLeft();
                }
            }
        }

        private bool _IsMoving()
        {
            return ((_Tweener != null) && (!_Tweener.IsComplete()))                                     // 移动中
                || ((_Tweener == null) && (_DragBeginPos != Vector2.one * float.MaxValue));             // 拖动中
        }
        /// <summary>
        /// 拖拽回调
        /// </summary>
        /// <param name="data"></param>
        public virtual void OnDrag(PointerEventData data)
        {
            Vector2 curPos = data.position;
            Vector2 offset = curPos - _DragPos;
            _DragPos = curPos;
            float curOffset = (direction == Direction.Horizontal) ? offset.x : offset.y;
            if (curOffset > 0)
            {
                if (_RealIndex > 0 || canLoop)
                {
                    //向右滑动
                    _CellMove(curOffset);
                }
            }
            else if (curOffset < 0)
            {
                if (_RealIndex + showCellNum < _DataCount || canLoop)
                {
                    //向左滑动
                    _CellMove(curOffset);
                }
            }
        }

        // 选中
        public virtual void OnPointerClick(PointerEventData data)
        {
            if (data.dragging)
            {
                return;
            }
            for (int i = 0; i < _CellList.Count; i++)
            {
                var cellObj = _CellList[i];
                var cellObjRtf = cellObj.GetComponent<RectTransform>();
                bool pressOnCell = RectTransformUtility.RectangleContainsScreenPoint(cellObjRtf, data.pressPosition, data.pressEventCamera); //按下位置是否在Cell上
                bool upOnCell = RectTransformUtility.RectangleContainsScreenPoint(cellObjRtf, data.position, data.pressEventCamera);         //抬起位置是否在Cell上
                if (pressOnCell != upOnCell)
                {//按下和抬起不在同一个Cell上
                    break;
                }
                else if (upOnCell && upOnCell)
                {
                    if (_SelectCallBack != null)
                    {
                        int selectIndex = (_RealIndex + i);
                        _SelectCallBack(_SelectLuaTable, cellObj, selectIndex);
                    }
                    break;
                }
            }
        }

        // 清理
        public virtual void Clear()
        {
            _LuaTable = null;
            _UpdateCellCallBack = null;
            _MoveBeginCallBack = null;
            _MoveEndCallBack = null;
            _SelectCallBack = null;
            _ClearTween();
            _ClearAllCell();
            _CellList = ObjectPool.goListPool.Gabage(_CellList);
        }
    }
}
