using System;
using UnityEngine.EventSystems;
using SLua;

namespace UnityEngine.UI
{
    /// <summary>
    /// PointerEvent 对应的Lua事件处理数据
    /// </summary>
    public struct YLuaPointerEventHandler
    {
        public LuaTable lua;
        public Action<LuaTable, PointerEventData> handler;

        /// <summary>
        /// 构造器
        /// </summary>
        public YLuaPointerEventHandler(LuaTable lua, Action<LuaTable, PointerEventData> handler)
        {
            this.lua = lua;
            this.handler = handler;
        }

        /// <summary>
        /// 赋值
        /// </summary>
        public void Set(LuaTable lua, Action<LuaTable, PointerEventData> handler)
        {
            this.lua = lua;
            this.handler = handler;
        }

        /// <summary>
        /// 重置
        /// </summary>
        public void Reset()
        {
            lua = null;
            handler = null;
        }

        /// <summary>
        /// 处理事件
        /// </summary>
        public void Process(PointerEventData data)
        {
            if(lua != null && handler != null)
            {
                handler(lua, data);
            }
        } 
    }


    /// <summary>
    /// PointerEvent 对应的Lua事件处理数据 带Args
    /// </summary>
    public struct YLuaPointerEventArgsHandler
    {
        public LuaTable lua;
        public Action<LuaTable, PointerEventData, LuaTable> handler;
        public LuaTable args;

        /// <summary>
        /// 构造器
        /// </summary>
        public YLuaPointerEventArgsHandler(LuaTable lua, Action<LuaTable, PointerEventData, LuaTable> handler, LuaTable args)
        {
            this.lua = lua;
            this.handler = handler;
            this.args = args;
        }

        /// <summary>
        /// 赋值
        /// </summary>
        public void Set(LuaTable lua, Action<LuaTable, PointerEventData, LuaTable> handler, LuaTable args)
        {
            this.lua = lua;
            this.handler = handler;
            this.args = args;
        }

        /// <summary>
        /// 重置
        /// </summary>
        public void Reset()
        {
            lua = null;
            handler = null;
            args = null;
        }

        /// <summary>
        /// 处理事件
        /// </summary>
        public void Process(PointerEventData data)
        {
            if (lua != null && handler != null)
            {
                handler(lua, data, args);
            }
        }
    }



    public enum YPointerEventType
    {
        // 摘要: 
        //     Intercepts a IPointerEnterHandler.OnPointerEnter.
        PointerEnter = 0,
        //
        // 摘要: 
        //     Intercepts a IPointerExitHandler.OnPointerExit.
        PointerExit = 1,
        //
        // 摘要: 
        //     Intercepts a IPointerDownHandler.OnPointerDown.
        PointerDown = 2,
        //
        // 摘要: 
        //     Intercepts a IPointerUpHandler.OnPointerUp.
        PointerUp = 3,
        //
        // 摘要: 
        //     Intercepts a IPointerClickHandler.OnPointerClick.
        PointerClick = 4,
        //
        // 摘要: 
        //     Intercepts a IDragHandler.OnDrag.
        Drag = 5,
        //
        // 摘要: 
        //     Intercepts a IDropHandler.OnDrop.
        Drop = 6,
        //
        // 摘要: 
        //     Intercepts a IScrollHandler.OnScroll.
        Scroll = 7,
        //
        // 摘要: 
        //     Intercepts a IUpdateSelectedHandler.OnUpdateSelected.
        UpdateSelected = 8,
        //
        // 摘要: 
        //     Intercepts a ISelectHandler.OnSelect.
        Select = 9,
        //
        // 摘要: 
        //     Intercepts a IDeselectHandler.OnDeselect.
        Deselect = 10,
        //
        // 摘要: 
        //     Intercepts a IMoveHandler.OnMove.
        Move = 11,
        //
        // 摘要: 
        //     Intercepts IInitializePotentialDrag.InitializePotentialDrag.
        InitializePotentialDrag = 12,
        //
        // 摘要: 
        //     Intercepts IBeginDragHandler.OnBeginDrag.
        BeginDrag = 13,
        //
        // 摘要: 
        //     Intercepts IEndDragHandler.OnEndDrag.
        EndDrag = 14,
        //
        // 摘要: 
        //     Intercepts ISubmitHandler.Submit.
        Submit = 15,
        //
        // 摘要: 
        //     Intercepts ICancelHandler.OnCancel.
        Cancel = 16,
        //
        // 摘要: 
        //     Intercepts a IPointerClickHandler.OnPointerClick. 在没有Drag的时候触发
        PointerClickWithoutDrag = 17,
    }
}
