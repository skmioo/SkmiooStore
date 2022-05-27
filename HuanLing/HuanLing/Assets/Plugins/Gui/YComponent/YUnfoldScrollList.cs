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
    /// 带有2级展开的YScorllList，格式为组+组下的成员，只支持单行或单列
    /// </summary>
    [CustomLuaClass]
    [AddComponentMenu("YUI/YUnfoldScrollList", 11)]
    [ExecuteInEditMode]
    [RequireComponent(typeof(RectTransform), typeof(YImage))]
    public class YUnfoldScrollList : UIBehaviour, IClearable, IPointerClickHandler
    {
        
        /// <summary>
        /// cell的类型
        /// </summary>
        [CustomLuaClass]
        public enum CellType
        {
            Group,
            Member
        }

        /// <summary>
        /// 组之间的间隔
        /// </summary>
        public Vector2 groupSpace;
        /// <summary>
        /// 成员之间的间隔
        /// </summary>
        public Vector2 memberSpace;
        /// <summary>
        /// 是否忽略首个组的间隔
        /// </summary>
        public bool hideFirstGroupOffset;
        /// <summary>
        /// 是否忽略首个成员的间隔
        /// </summary>
        public bool hideFirstMemberOffset;

        public bool hideLastMemberOffset;
        /// <summary>
        /// 组的Prefab
        /// </summary>
        public GameObject groupPrefab;
        /// <summary>
        /// 组下的成员Prefab
        /// </summary>
        public GameObject memberPrefab;
        /// <summary>
        /// 组被选中效果的Prefab
        /// </summary>
        public GameObject selectGroupPrefab;
        /// <summary>
        /// 成员被选中效果的Prefab
        /// </summary>
        public GameObject selectMemberPrefab;

        private string _WinName = null;

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
        /// 更新组，会置空所有成员
        /// </summary>
        /// <param name="count">组的数量</param>
        public void UpdateGroup(int count)
        {
            ResetGroups(count);
            ClearGSelectEff();
            UpdateCell();
            CalcContent();
        }

        public void UpdateMember(int group,int count)
        {
            group = group - 1;
            _ListMemberCount[group] = count;
            ResetMembers(group);
            ClearMSelectEff(group);
            UpdateCell();
            CalcContent();
        }

        //获取组的数量
        public int GetGroupCount()
        {
            return _ListMemberCount.Count;
        }

        // 获取指定组中的成员数量
        public int GetMemberCount(int group)
        {
            group = group - 1;
            return _ListMemberCount[group];
        }

        /// <summary>
        /// 更新指定组
        /// </summary>
        /// <param name="index">组的索引</param>
        public void TryUpdateGroup(int index)
        {
            List<YUSLCell> list;
            if(_DicCellCache.TryGetValue(index - 1,out list))
            {
                //组只会在数组的第一个
                YUSLCell cell = list[0];
                if(cell.Type == CellType.Group)
                {
                    if (_LuaTable != null && _UpdateGroupCallback != null)
                    {
                        _UpdateGroupCallback(_LuaTable, cell.GameObject, index);
                    }
                }
            }
        }

        /// <summary>
        /// 更新指定成员
        /// </summary>
        /// <param name="group">组索引</param>
        /// <param name="index">组中的成员索引</param>
        public void TryUpdateMember(int group,int index)
        {
            group = group - 1;
            index = index - 1;
            List<YUSLCell> list;
            if (_DicCellCache.TryGetValue(group, out list))
            {
                YUSLCell cell = new YUSLCell();
                cell.Type = CellType.Member;
                cell.Group = group;
                cell.Index = index;
                YUSLCell find = list.Find(x => CheckCellSame(cell, x));
                if (find != null)
                {
                    if (_LuaTable != null && _UpdateMemberCallback != null)
                    {
                        _UpdateMemberCallback(_LuaTable, find.GameObject, group + 1, index + 1);
                    }
                }
            }
        }

        /// <summary>
        /// 移动到指定的索引位置
        /// </summary>
        /// <param name="isGroup">是否是组</param>
        /// <param name="group">组索引</param>
        /// <param name="index">成员索引，是组填组索引或不填</param>
        public void MoveToIndex(bool isGroup, int group, int index, float speed)
        {
            group -= 1;
            index -= 1;
            if (group < 0 || group >= _ListGroupPosY.Count)
            {
                return;
            }
            float y = _ListGroupPosY[group];
            Vector2 targetPos = new Vector2(0, y);
            //成员需要再计算具体位置
            if (!isGroup && index >= 0 && index < _ListMemberCount[group])
            {
                y += _GroupCellSize.y;
                for (int i = 0; i < index; i++)
                {
                    float mSpace = (i == 0 && hideFirstMemberOffset) ? 0 : memberSpace.y;
                    float mLastSpace = (i == index - 1 && hideLastMemberOffset) ? 0 : memberSpace.y;
                    y += mSpace + _MemberCellSize.y + mLastSpace;
                }
                y -= _MemberCellSize.y;
                targetPos.y = y;
            }
            _UYScrollRect.ScrollToPosition(targetPos, true, speed);
        }

        /// <summary>
        /// 获取当前选中的元件
        /// </summary>
        public YUSLCell GetSelectedGroup()
        {
            return CopyCell(_SelectedGroup);
        }

        public YUSLCell GetSelectedMember()
        {
            return CopyCell(_SelectedMember);
        }


        /// <summary>
        /// 设置当前选中的元件
        /// </summary>
        /// <param name="isGroup">是否是组</param>
        /// <param name="group">组索引，当<=0时，表示清除组或成员的选中状态</param>
        /// <param name="index">成员索引，是组填组索引或不填，当<=0时，表示清除成员的选中状态</param>
        public void SetSelectedCell(bool isGroup,int group,int index)
        {
            //判断==-1的表示取消选中状态
            if (isGroup)
            {
                if(group <= 0)
                {
                    if (_SelectedGroup != null)
                    {
                        if(_SelectedGroupEff != null) _SelectedGroupEff.SetActive(false);
                        _SelectedGroup = null;
                    }
                    return;
                }
            }
            else
            {
                if (group <= 0 || index <= 0)
                {
                    ClearMSelectEff(group);
                    return;
                }
            }
            group = group - 1;
            index = index - 1;
            YUSLCell cell = new YUSLCell();
            cell.Type = isGroup ? CellType.Group : CellType.Member;
            cell.Group = group;
            cell.Index = isGroup ? group : index;
            if(!_DicCellCache.ContainsKey(group))
            {
                _SelectedWait = cell;
                return;
            }
            List<YUSLCell> listCells = _DicCellCache[group];
            //判断是否可重复触发
            if (!isGroup && _TriggerOnce && CheckCellSame(_SelectedMember, cell))
            {
                //不能重复触发的，只需要刷新选中状态就可以了
                for (int i = 0; i < listCells.Count; i++)
                {
                    if (CheckCellSame(cell, listCells[i]))
                    {
                        _SelectedWait = null;
                        BuildSelectedEff(listCells[i]);
                        return;
                    }
                }
                return;
            }
            
            for (int i = 0; i < listCells.Count; i++ )
            {
                if(CheckCellSame(cell,listCells[i]))
                {
                    _SelectedWait = null;
                    if(isGroup)
                    {
                        cell = _SelectedGroup;
                        _SelectedGroup = listCells[i];
                        BuildSelectedEff(_SelectedGroup);
                        YUSLCell luaCell_1 = CopyCell(_SelectedGroup);
                        YUSLCell luaCell_2 = CopyCell(cell);
                        if (_LuaTable != null && _SelectGroupCallback != null)
                        {
                            _SelectGroupCallback(_LuaTable, luaCell_1, luaCell_2);
                        }
                    }
                    else
                    {
                        cell = _SelectedMember;
                        _SelectedMember = listCells[i];
                        BuildSelectedEff(_SelectedMember);
                        YUSLCell luaCell_1 = CopyCell(_SelectedMember);
                        YUSLCell luaCell_2 = CopyCell(cell);
                        if (_LuaTable != null && _SelectMemberCallback != null)
                        {
                            _SelectMemberCallback(_LuaTable, luaCell_1, luaCell_2);
                        }
                    }
                    return;
                }
            }
            _SelectedWait = cell;
        }

        /// <summary>
        /// 取消同一cell只能触发一次的限制
        /// </summary>
        public void CancelTriggerOnce()
        {
            _TriggerOnce = false;
        }

        /// <summary>
        /// 设置lua组的更新回调
        /// </summary>
        public void SetLuaUpdateGroupCallBack(LuaTable lua, Action<LuaTable, GameObject, int> callback)
        {
            _LuaTable = lua;
            _UpdateGroupCallback = callback;
        }

        /// <summary>
        /// 设置lua成员的更新回调
        /// </summary>
        public void SetLuaUpdateMemberCallBack(LuaTable lua, Action<LuaTable, GameObject, int, int> callback)
        {
            _LuaTable = lua;
            _UpdateMemberCallback = callback;
        }

        /// <summary>
        /// 设置lua组的选中更改回调
        /// </summary>
        /// <param name="callback">回调函数，参数：lua对象，cell对象，当次的组的索引, 之前选中的索引</param>
        public void SetLuaSelectGroupCallBack(LuaTable lua, Action<LuaTable, YUSLCell, YUSLCell> callback)
        {
            _LuaTable = lua;
            _SelectGroupCallback = callback;
        }

        /// <summary>
        /// 设置lua成员的选中更改回调
        /// </summary>
        public void SetLuaSelectMemberCallBack(LuaTable lua, Action<LuaTable, YUSLCell, YUSLCell> callback)
        {
            _LuaTable = lua;
            _SelectMemberCallback = callback;
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
        /// 组件本身的尺寸，用作显示cell用
        /// </summary>
        private Vector2 _ScrollListSize;
        /// <summary>
        /// Cell容器
        /// </summary>
        private GameObject _CellContainer;
        /// <summary>
        /// Container's Rectransform
        /// </summary>
        private RectTransform _Content;
        /// <summary>
        /// 组元件的尺寸
        /// </summary>
        private Vector2 _GroupCellSize;
        /// <summary>
        /// 成员元件的尺寸
        /// </summary>
        private Vector2 _MemberCellSize;
        /// <summary>
        /// 记录每个组含有的成员的数量
        /// </summary>
        private List<int> _ListMemberCount = new List<int>();
        /// <summary>
        /// 记录每个组的坐标
        /// </summary>
        private List<float> _ListGroupPosY = new List<float>();
        /// <summary>
        /// 当前使用的cell,key=组的索引,value=对应的组及成员
        /// </summary>
        private Dictionary<int, List<YUSLCell>> _DicCellCache = new Dictionary<int, List<YUSLCell>>();
        /// <summary>
        /// 已回收可复用的cell
        /// </summary>
        private Dictionary<CellType, Queue<YUSLCell>> _DicReuseableCell = new Dictionary<CellType, Queue<YUSLCell>>();
        /// <summary>
        /// 已经显示的组的数量，用作计算位置用
        /// </summary>
        private int _GroupShowedNum;
        /// <summary>
        /// 组可以无限触发，同个成员是否只触发一次
        /// </summary>
        private bool _TriggerOnce = true;
        /// <summary>
        /// LuaTable对象
        /// </summary>
        private LuaTable _LuaTable;
        /// <summary>
        /// 更新组的回调
        /// </summary>
        private Action<LuaTable, GameObject, int> _UpdateGroupCallback;
        /// <summary>
        /// 更新成员的回调
        /// </summary>
        private Action<LuaTable, GameObject, int, int> _UpdateMemberCallback;
        /// <summary>
        /// 组的选中更改回调
        /// </summary>
        private Action<LuaTable, YUSLCell,YUSLCell> _SelectGroupCallback;
        /// <summary>
        /// 成员的选中更改回调
        /// </summary>
        private Action<LuaTable, YUSLCell, YUSLCell> _SelectMemberCallback;
        private YUSLCell _SelectedGroup;
        /// <summary>
        /// 当前选中的成员
        /// </summary>
        private YUSLCell _SelectedMember;

        private YUSLCell _SelectedWait;
        /// <summary>
        /// 组的选中效果
        /// </summary>
        private GameObject _SelectedGroupEff = null;
        /// <summary>
        /// 成员的选中效果
        /// </summary>
        private GameObject _SelectedMemberEff = null;

        /// <summary>
        /// 脚本启动时触发
        /// </summary>`
        protected override void Awake()
        {
            _DicReuseableCell[CellType.Group] = new Queue<YUSLCell>();
            _DicReuseableCell[CellType.Member] = new Queue<YUSLCell>();
            Rect rect = gameObject.GetComponent<RectTransform>().rect;
            _ScrollListSize = new Vector2(rect.width,rect.height);

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
        /// 游戏时Awake
        /// </summary>
        private void GameAwake()
        {
            _Mask = gameObject.GetComponent<Mask>();
            _Mask.hideFlags = HideFlags.HideInInspector;
            _CellContainer = gameObject.transform.Find("ListCellContainer").gameObject;
            _UYScrollRect = gameObject.GetComponent<YScrollRect>();
            _UYScrollRect.hideFlags = HideFlags.HideInInspector;
            _UYScrollRect.onValueChanged.AddListener(HandleValueChanged);
            _UYScrollRect.horizontal = false;
            _UYScrollRect.vertical = true;

            _Content = _UYScrollRect.content;
            _Content.anchorMax = Vector2.up;
            _Content.anchorMin = Vector2.up;
            _Content.pivot = Vector2.up;
            _Content.anchoredPosition = Vector2.zero;

            _GroupCellSize = groupPrefab.GetComponent<RectTransform>().rect.size;
            _MemberCellSize = memberPrefab.GetComponent<RectTransform>().rect.size;
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
                _CellContainer = new GameObject("ListCellContainer");
                _Content = _CellContainer.AddComponent<RectTransform>();
                _CellContainer.transform.SetParent(gameObject.transform);
                _CellContainer.transform.localScale = Vector3.one;
                _CellContainer.transform.localPosition = Vector3.zero;
            }
            else
            {
                _CellContainer = containerTransfrom.gameObject;
                _Content = _CellContainer.GetComponent<RectTransform>();
                if (!_Content)
                {
                    _Content = _CellContainer.AddComponent<RectTransform>();
                }
            }
            _Content.sizeDelta = gameObject.GetComponent<RectTransform>().rect.size;

            _UYScrollRect = gameObject.GetComponent<YScrollRect>();
            if (_UYScrollRect == null)
            {
                _UYScrollRect = gameObject.AddComponent<YScrollRect>();
            }
            //_UYScrollRect.hideFlags = HideFlags.HideInInspector;
            _UYScrollRect.content = _Content;
            _Content.anchorMax = Vector2.up;
            _Content.anchorMin = Vector2.up;
            _Content.pivot = Vector2.up;
        }

        /// <summary>
        /// 重置组数据就是全部重置
        /// </summary>
        private void ResetGroups(int count)
        {
            foreach (var pair in _DicCellCache)
            {
                for (int i = 0; i < pair.Value.Count; i++)
                {
                    SaveCell(pair.Value[i]);
                }
            }
            _DicCellCache.Clear();
            _ListMemberCount.Clear();
            for (int i = 0; i < count; i++ )
            {
                _ListMemberCount.Add(0);
            }
            _GroupShowedNum = 0;
            if (_SelectedWait != null && _SelectedWait.Type == CellType.Group)
            {
                _SelectedWait = null;
            }
        }

        /// <summary>
        /// 重置组对应的成员
        /// </summary>
        private void ResetMembers(int group)
        {
            List<YUSLCell> listCells;
            if (_DicCellCache.TryGetValue(group, out listCells))
            {
                for (int i = 0; i < listCells.Count; i++)
                {
                    SaveCell(listCells[i]);
                }
                _DicCellCache.Remove(group);
            }
            if (_SelectedWait != null && _SelectedWait.Type == CellType.Member)
            {
                _SelectedWait = null;
            }
        }

        /// <summary>
        /// 更新cell
        /// </summary>
        private void UpdateCell()
        {
            List<YUSLCell> listRemove = new List<YUSLCell>();
            //先清除之前的记录
            foreach (var pair in _DicCellCache)
            {
                for(int i = 0; i < pair.Value.Count; i++)
                {
                    listRemove.Add(pair.Value[i]);
                }
            }
            _DicCellCache.Clear();
            _ListGroupPosY.Clear();
            List<YUSLCell> listTempCells = new List<YUSLCell>();
            //只能遍历来获取当前需要显示的cell
            float offset = ContentOffset;
            float showHeight = offset + _ScrollListSize.y;
            //先加上首行缩进
            float height = 0;
            for (int i = 0; i < _ListMemberCount.Count; i++)
            {
                //先计算超框的长度,一个组，包括成员
                float gSpce = (i == 0 && hideFirstGroupOffset) ? 0 : groupSpace.y;
                float groupHeight = height + _GroupCellSize.y + gSpce;
                //将所有的组坐标存下，用作定位用
                _ListGroupPosY.Add(height + gSpce);
                //只需要获取在范围内的元件
                List<YUSLCell> listCell = new List<YUSLCell>();
                YUSLCell cell;
                //先获取组
                if (groupHeight >= offset && height <= showHeight)
                {
                    cell = listRemove.Find(x => x.Type == CellType.Group && x.Index == i);
                    if(cell != null)
                    {
                        Vector3 pos = cell.GameObject.transform.localPosition;
                        pos.y = -(height + gSpce);
                        cell.GameObject.transform.localPosition = pos;
                        listRemove.Remove(cell);
                    }
                    else
                    {
                        cell = CreateTempCell(CellType.Group, i, i, -(height + gSpce));
                        listTempCells.Add(cell);
                    }
                    listCell.Add(cell);
                }
                height = groupHeight;
                //再获取成员
                for (int j = 0; j < _ListMemberCount[i]; j++)
                {
                    float mSpace = (j == 0 && hideFirstMemberOffset) ? 0 : memberSpace.y;
                    float memberHeight = height + mSpace + _MemberCellSize.y;
                    if (memberHeight >= offset && height <= showHeight)
                    {
                        cell = listRemove.Find(x => x.Type == CellType.Member && x.Group == i && x.Index == j);
                        if (cell != null)
                        {
                            Vector3 pos = cell.GameObject.transform.localPosition;
                            pos.y = -(height + mSpace);
                            cell.GameObject.transform.localPosition = pos;
                            listRemove.Remove(cell);
                        }
                        else
                        {
                            cell = CreateTempCell(CellType.Member, i, j, -(height + mSpace));
                            listTempCells.Add(cell);
                        }
                        listCell.Add(cell);
                    }
                    height = memberHeight;
                }
                if (listCell.Count > 0) _DicCellCache.Add(i, listCell);
                float lastSpace = (_ListMemberCount[i] <= 0 || hideLastMemberOffset) ? 0 : memberSpace.y;
                height += lastSpace;
            }
            //回收不显示的cell
            for (int i = 0; i < listRemove.Count; i++ )
            {
                SaveCell(listRemove[i]);
            }
            listRemove.Clear();
            //将之前临时对象赋值
            for (int i = 0; i < listTempCells.Count; i++ )
            {
                FillCell(listTempCells[i]);
            }
            listTempCells.Clear();
        }

        /// <summary>
        /// 创建一个cell，不过该cell没有GameOjbect，需要后面填入
        /// </summary>
        private YUSLCell CreateTempCell(CellType type, int group, int index, float posY)
        {
            YUSLCell cell = new YUSLCell();
            cell.Type = type;
            cell.Group = group;
            cell.Index = index;
            float x = type == CellType.Group ? groupSpace.x : memberSpace.x;
            cell.Position = new Vector3(x, posY, 0);
            return cell;
        }

        //private YUSLCell FetchCell(CellType type,int group,int index)
        //{
        //    YUSLCell cell;
        //    if (this._DicReuseableCell[type].Count > 0)
        //    {
        //        cell = this._DicReuseableCell[type].Dequeue();
        //        cell.GameObject.SetActive(true);
        //    }
        //    else
        //    {
        //        GameObject obj = UIUtil.CreateCellInst(type == CellType.Group ? groupPrefab : memberPrefab);
        //        obj.transform.SetParent(this._CellContainer.transform);
        //        obj.transform.localScale = Vector3.one;
        //        obj.transform.localPosition = Vector3.zero;
        //        var cellRtf = obj.GetComponent<RectTransform>();
        //        cellRtf.anchorMax = Vector2.up;
        //        cellRtf.anchorMin = Vector2.up;
        //        cellRtf.pivot = Vector2.up;
        //        obj.SetActive(true);
        //        cell = new YUSLCell();
        //        cell.GameObject = obj;
        //    }
        //    cell.Type = type;
        //    cell.Group = group;
        //    cell.Index = index;
        //    if(type == CellType.Group)
        //    {
        //        if(_LuaTable != null && _UpdateGroupCallback != null)
        //            _UpdateGroupCallback(_LuaTable, cell.GameObject, cell.Index + 1);
        //    }
        //    else
        //    {
        //        if (_LuaTable != null && _UpdateMemberCallback != null)
        //            _UpdateMemberCallback(_LuaTable, cell.GameObject, cell.Group + 1, cell.Index + 1);
        //    }
            
        //    return cell;
        //}

        /// <summary>
        /// 在临时cell中填入GameObject
        /// </summary>
        private void FillCell(YUSLCell tempCell)
        {
            if (this._DicReuseableCell[tempCell.Type].Count > 0)
            {
                YUSLCell cell = this._DicReuseableCell[tempCell.Type].Dequeue();
                cell.GameObject.SetActive(true);
                tempCell.GameObject = cell.GameObject;
            }
            else
            {
                GameObject obj = UIUtil.InstantiateCell(gameObject, tempCell.Type == CellType.Group ? groupPrefab : memberPrefab, ref _WinName);
                obj.SetActive(true);
                obj.transform.SetParent(this._CellContainer.transform);
                obj.transform.localScale = Vector3.one;
                obj.transform.localPosition = Vector3.zero;
                var cellRtf = obj.GetComponent<RectTransform>();
                cellRtf.anchorMax = Vector2.up;
                cellRtf.anchorMin = Vector2.up;
                cellRtf.pivot = Vector2.up;
                tempCell.GameObject = obj;
            }
            tempCell.GameObject.transform.localPosition = tempCell.Position;
            if (tempCell.Type == CellType.Group)
            {
                if (_LuaTable != null && _UpdateGroupCallback != null)
                    _UpdateGroupCallback(_LuaTable, tempCell.GameObject, tempCell.Index + 1);
            }
            else
            {
                if (_LuaTable != null && _UpdateMemberCallback != null)
                    _UpdateMemberCallback(_LuaTable, tempCell.GameObject, tempCell.Group + 1, tempCell.Index + 1);
            }
            if (_SelectedWait != null && CheckCellSame(_SelectedWait, tempCell))
            {
                YUSLCell newCell = CopyCell(tempCell);
                if (_SelectedWait.Type == CellType.Group)
                {
                    _SelectedGroup = newCell;
                    _SelectedWait = null;
                    if (_LuaTable != null && _SelectGroupCallback != null)
                        _SelectGroupCallback(_LuaTable, newCell, CopyCell(null));
                }
                else
                {
                    _SelectedMember = newCell;
                    _SelectedWait = null;
                    if (_LuaTable != null && _SelectMemberCallback != null)
                        _SelectMemberCallback(_LuaTable, newCell, CopyCell(null));
                }
            }
        }

        private void SaveCell(YUSLCell cell)
        {
            cell.GameObject.SetActive(false);
            Vector3 pos = Vector3.zero;
            if(cell.Type == CellType.Group)
            {
                pos = new Vector3(-_GroupCellSize.x,_GroupCellSize.y,0);
            }
            else
            {
                pos = new Vector3(-_MemberCellSize.x, _MemberCellSize.y, 0);
            }
            cell.GameObject.transform.localPosition = pos;
            _DicReuseableCell[cell.Type].Enqueue(cell);
        }

        private void BuildSelectedEff(YUSLCell cell)
        {
            if (cell.Type == CellType.Group && selectGroupPrefab == null) return;
            if (cell.Type == CellType.Member && selectMemberPrefab == null) return;
            RectTransform selTrans = FetchSelectEffRect(cell.Type);
            RectTransform cellRect = cell.GameObject.GetComponent<RectTransform>();
            Vector2 offset = (selTrans.sizeDelta - cellRect.sizeDelta) / 2;
            offset.y = -offset.y;
            selTrans.anchoredPosition = cellRect.anchoredPosition - offset;
        }

        private RectTransform FetchSelectEffRect(CellType type)
        {
            RectTransform selTrans;
            GameObject eff = type == CellType.Group ? _SelectedGroupEff : _SelectedMemberEff;
            if (eff == null)
            {
                GameObject prefab = type == CellType.Group ? selectGroupPrefab : selectMemberPrefab;
                eff = UIUtil.Instantiate(prefab, this._CellContainer.transform) as GameObject;
                eff.transform.localScale = Vector3.one;
                selTrans = eff.GetComponent<RectTransform>();
                selTrans.anchorMax = Vector2.up;
                selTrans.anchorMin = Vector2.up;
                selTrans.pivot = Vector2.up;
                if (type == CellType.Group) _SelectedGroupEff = eff;
                else _SelectedMemberEff = eff;
            }
            else
            {
                selTrans = eff.GetComponent<RectTransform>();
            }
            eff.SetActive(true);
            eff.transform.SetAsLastSibling();
            if(type == CellType.Group)
            {
                if (_SelectedMemberEff != null) _SelectedMemberEff.SetActive(false);
            }
            else
            {
                if (_SelectedGroupEff != null) _SelectedGroupEff.SetActive(false);
            }
            return selTrans;
        }

        /// <summary>
        /// 清除组的选中状态
        /// </summary>
        private void ClearGSelectEff()
        {
            if (_SelectedGroupEff != null) _SelectedGroupEff.SetActive(false);
            if (_SelectedMemberEff != null) _SelectedMemberEff.SetActive(false);
            _SelectedGroup = null;
            _SelectedMember = null;
        }

        /// <summary>
        /// 清除成员的选中状态
        /// </summary>
        /// <param name="group"></param>
        private void ClearMSelectEff(int group)
        {
            if (group <= 0)
            {
                if (_SelectedMemberEff != null) _SelectedMemberEff.SetActive(false);
                _SelectedMember = null;
            }
            else
            {
                if (_SelectedMember != null && (_SelectedMember.Group == group))
                {
                    if (_SelectedMemberEff != null) _SelectedMemberEff.SetActive(false);
                    _SelectedMember = null;
                }
            }
        }

        /// <summary>
        /// 计算滚动框尺寸
        /// </summary>
        private void CalcContent()
        {
            float height = _ListMemberCount.Count * _GroupCellSize.y;
            int count = hideFirstGroupOffset ? _ListMemberCount.Count - 1 : _ListMemberCount.Count;
            if (count < 0) count = 0;
            height += count * groupSpace.y;
            for (int i = 0; i < _ListMemberCount.Count; i++)
            {
                count = hideFirstMemberOffset ? _ListMemberCount[i] - 1 : _ListMemberCount[i];
                count = hideLastMemberOffset  ?  count : count + 1;
                if (count < 0) count = 0;
                height += count * memberSpace.y + _ListMemberCount[i] * _MemberCellSize.y;
            }
            _Content.sizeDelta = new Vector2(_Content.sizeDelta.x, height);
        }

        /// <summary>
        /// 当前Content位移(绝对值)
        /// </summary>
        private float ContentOffset
        {
            get
            {
                var offset = _Content.anchoredPosition.y;
                return offset < 0 ? 0 : offset;
            }
        }

        public void SetToTop()
        {
            _Content.anchoredPosition = Vector2.zero;
        }

        /// <summary>
        /// copy一份回给lua用,所有索引需要+1
        /// </summary>
        private YUSLCell CopyCell(YUSLCell cell)
        {
            YUSLCell luaCell = new YUSLCell();
            if (cell == null)
            {
                luaCell.Type = CellType.Group;
                luaCell.GameObject = null;
                luaCell.Group = -1;
                luaCell.Index = -1;
            }
            else
            {
                luaCell.Type = cell.Type;
                luaCell.GameObject = cell.GameObject;
                luaCell.Group = cell.Group + 1;
                luaCell.Index = cell.Index + 1;
            }
            return luaCell;
        }

        /// <summary>
        /// 检查2个cell是否相同
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        private bool CheckCellSame(YUSLCell A, YUSLCell B)
        {
            if (A == null || B == null) return false;
            bool a = A.Type == B.Type;
            bool b = A.Group == B.Group ? a : false;
            bool c = b;
            if (b && A.Type == CellType.Member)
            {
                c = A.Index == B.Index;
            }
            return c;
        }

        /// <summary>
        /// Scroll移动时回调
        /// </summary>
        private void HandleValueChanged(Vector2 data)
        {
            UpdateCell();
        }

        public void Clear()
        {
            _ListGroupPosY.Clear();
            ClearCell();
            ClearLuaHandler();
        }

        public void ClearLuaHandler()
        {
            _LuaTable = null;
            _UpdateGroupCallback = null;
            _UpdateMemberCallback = null;
            _SelectGroupCallback = null;
            _SelectMemberCallback = null;
        }

        void ClearCell()
        {
            if (_DicReuseableCell == null) return;
            while (_DicReuseableCell[CellType.Group].Count > 0)
            {
                UIUtil.GabageCell(_DicReuseableCell[CellType.Group].Dequeue().GameObject);
            }
            while (_DicReuseableCell[CellType.Member].Count > 0)
            {
                UIUtil.GabageCell(_DicReuseableCell[CellType.Member].Dequeue().GameObject);
            }
            _DicReuseableCell.Clear();
            _DicReuseableCell = null;
            foreach(var pair in _DicCellCache)
            {
                for (int i = 0; i < pair.Value.Count; i++ )
                {
                    YUSLCell cell = pair.Value[i];
                    UIUtil.GabageCell(cell.GameObject);
                }
            }
            _DicCellCache.Clear();
            _DicCellCache = null;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left)
                return;

            foreach(var pair in _DicCellCache)
            {
                for (int i = 0; i < pair.Value.Count; i++ )
                {
                    YUSLCell cell = pair.Value[i];
                    var trans = cell.GameObject.GetComponent<RectTransform>();
                    bool pressCell = RectTransformUtility.RectangleContainsScreenPoint(trans, eventData.pressPosition, eventData.pressEventCamera); //按下位置是否在Cell上
                    bool upCell = RectTransformUtility.RectangleContainsScreenPoint(trans, eventData.position, eventData.pressEventCamera);         //抬起位置是否在Cell上
                    if (pressCell != upCell)
                    {//按下和抬起不在同一个Cell上
                        return;
                    }
                    else if (pressCell && upCell)
                    {
                        SetSelectedCell(cell.Type == CellType.Group,cell.Group + 1,cell.Index + 1);
                        return;
                    }
                }
            }
        }
    }

    /// <summary>
    /// 组和成员
    /// </summary>
    [CustomLuaClass]
    public class YUSLCell
    {
        public YUnfoldScrollList.CellType Type { set; get; }
        public int Group { set; get; }
        public int Index { set; get; }
        public GameObject GameObject { set; get; }
        public Vector3 Position { set; get; }
    }
}
