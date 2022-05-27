using System;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using SLua;
using UYMO;

namespace UnityEngine.UI
{
    /// <summary>
    /// 可触摸交互的Image
    /// </summary>
    [CustomLuaClass]
    public class YTouchableImage :
        YImage,
        IPointerClickHandler,
        IPointerDownHandler,
        IPointerUpHandler,
        IDragHandler,
        IBeginDragHandler,
        IEndDragHandler,
        IClearable
    {
        private Dictionary<YPointerEventType, YLuaPointerEventHandler> _HandlerDic = new Dictionary<YPointerEventType, YLuaPointerEventHandler>();
        private Dictionary<YPointerEventType, YLuaPointerEventArgsHandler> _ArgsHandlerDic = new Dictionary<YPointerEventType, YLuaPointerEventArgsHandler>();

        public object userData;
        public void SetClickHandler(LuaTable lua, Action<LuaTable, PointerEventData> handler)
        {
            _HandlerDic[YPointerEventType.PointerClick] = new YLuaPointerEventHandler(lua, handler);
        }

        public void SetClickHandler(LuaTable lua, Action<LuaTable, PointerEventData, LuaTable> handler, LuaTable args)
        {
            _ArgsHandlerDic[YPointerEventType.PointerClick] = new YLuaPointerEventArgsHandler(lua, handler, args);
        }

        public void SetPointerDownHandler(LuaTable lua, Action<LuaTable, PointerEventData> handler)
        {
            _HandlerDic[YPointerEventType.PointerDown] = new YLuaPointerEventHandler(lua, handler);
        }

        public void SetPointerDownHandler(LuaTable lua, Action<LuaTable, PointerEventData, LuaTable> handler, LuaTable args)
        {
            _ArgsHandlerDic[YPointerEventType.PointerDown] = new YLuaPointerEventArgsHandler(lua, handler, args);
        }

        public void SetPointerUpHandler(LuaTable lua, Action<LuaTable, PointerEventData> handler)
        {
            _HandlerDic[YPointerEventType.PointerUp] = new YLuaPointerEventHandler(lua, handler);
        }

        public void SetPointerUpHandler(LuaTable lua, Action<LuaTable, PointerEventData, LuaTable> handler, LuaTable args)
        {
            _ArgsHandlerDic[YPointerEventType.PointerUp] = new YLuaPointerEventArgsHandler(lua, handler, args);
        }

        public void SetDragHandler(LuaTable lua, Action<LuaTable, PointerEventData> handler)
        {
            _HandlerDic[YPointerEventType.Drag] = new YLuaPointerEventHandler(lua, handler);
        }

        public void SetDragHandler(LuaTable lua, Action<LuaTable, PointerEventData, LuaTable> handler, LuaTable args)
        {
            _ArgsHandlerDic[YPointerEventType.Drag] = new YLuaPointerEventArgsHandler(lua, handler, args);
        }

        public void SetBeginDragHandler(LuaTable lua, Action<LuaTable, PointerEventData> handler)
        {
            _HandlerDic[YPointerEventType.BeginDrag] = new YLuaPointerEventHandler(lua, handler);
        }

        public void SetBeginDragHandler(LuaTable lua, Action<LuaTable, PointerEventData, LuaTable> handler, LuaTable args)
        {
            _ArgsHandlerDic[YPointerEventType.BeginDrag] = new YLuaPointerEventArgsHandler(lua, handler, args);
        }

        public void SetEndDragHandler(LuaTable lua, Action<LuaTable, PointerEventData> handler)
        {
            _HandlerDic[YPointerEventType.EndDrag] = new YLuaPointerEventHandler(lua, handler);
        }

        public void SetEndDragHandler(LuaTable lua, Action<LuaTable, PointerEventData, LuaTable> handler, LuaTable args)
        {
            _ArgsHandlerDic[YPointerEventType.EndDrag] = new YLuaPointerEventArgsHandler(lua, handler, args);
        }

        public void SetClickWithoutDragHandler(LuaTable lua, Action<LuaTable, PointerEventData> handler)
        {
            _HandlerDic[YPointerEventType.PointerClickWithoutDrag] = new YLuaPointerEventHandler(lua, handler);
        }

        public void SetClickWithoutDragHandler(LuaTable lua, Action<LuaTable, PointerEventData, LuaTable> handler, LuaTable args)
        {
            _ArgsHandlerDic[YPointerEventType.PointerClickWithoutDrag] = new YLuaPointerEventArgsHandler(lua, handler, args);
        }

        public void ClearLuaHandler()
        {
            foreach (var pair in _HandlerDic)
            {
                pair.Value.Reset();
            }
            _HandlerDic.Clear();

            foreach (var pair in _ArgsHandlerDic)
            {
                pair.Value.Reset();
            }
            _ArgsHandlerDic.Clear();
        }

        public void Clear()
        {
            ClearLuaHandler();
       }


        [DoNotToLua]
        public void OnPointerClick(PointerEventData eventData)
        {
            YLuaPointerEventHandler hander;
            if (_HandlerDic.TryGetValue(YPointerEventType.PointerClick, out hander))
            {
                hander.Process(eventData);
            }

            if (!eventData.dragging)
            {
                if (_HandlerDic.TryGetValue(YPointerEventType.PointerClickWithoutDrag, out hander))
                {
                    hander.Process(eventData);
                }
            }

            YLuaPointerEventArgsHandler argsHandler;
            if (_ArgsHandlerDic.TryGetValue(YPointerEventType.PointerClick, out argsHandler))
            {
                argsHandler.Process(eventData);
            }

            if (!eventData.dragging)
            {
                if (_ArgsHandlerDic.TryGetValue(YPointerEventType.PointerClickWithoutDrag, out argsHandler))
                {
                    argsHandler.Process(eventData);
                }
            }
        }

        [DoNotToLua]
        public void OnPointerDown(PointerEventData eventData)
        {
            YLuaPointerEventHandler hander;
            if (_HandlerDic.TryGetValue(YPointerEventType.PointerDown, out hander))
            {
                hander.Process(eventData);
            }

            YLuaPointerEventArgsHandler argsHandler;
            if (_ArgsHandlerDic.TryGetValue(YPointerEventType.PointerDown, out argsHandler))
            {
                argsHandler.Process(eventData);
            }
        }

        [DoNotToLua]
        public void OnPointerUp(PointerEventData eventData)
        {
            YLuaPointerEventHandler hander;
            if (_HandlerDic.TryGetValue(YPointerEventType.PointerUp, out hander))
            {
                hander.Process(eventData);
            }

            YLuaPointerEventArgsHandler argsHandler;
            if (_ArgsHandlerDic.TryGetValue(YPointerEventType.PointerUp, out argsHandler))
            {
                argsHandler.Process(eventData);
            }
        }

        [DoNotToLua]
        public void OnDrag(PointerEventData eventData)
        {
            YLuaPointerEventHandler hander;
            if (_HandlerDic.TryGetValue(YPointerEventType.Drag, out hander))
            {
                hander.Process(eventData);
            }

            YLuaPointerEventArgsHandler argsHandler;
            if (_ArgsHandlerDic.TryGetValue(YPointerEventType.Drag, out argsHandler))
            {
                argsHandler.Process(eventData);
            }
        }

        [DoNotToLua]
        public void OnBeginDrag(PointerEventData eventData)
        {
            YLuaPointerEventHandler hander;
            if (_HandlerDic.TryGetValue(YPointerEventType.BeginDrag, out hander))
            {
                hander.Process(eventData);
            }

            YLuaPointerEventArgsHandler argsHandler;
            if (_ArgsHandlerDic.TryGetValue(YPointerEventType.BeginDrag, out argsHandler))
            {
                argsHandler.Process(eventData);
            }
        }

        [DoNotToLua]
        public void OnEndDrag(PointerEventData eventData)
        {
            YLuaPointerEventHandler hander;
            if (_HandlerDic.TryGetValue(YPointerEventType.EndDrag, out hander))
            {
                hander.Process(eventData);
            }

            YLuaPointerEventArgsHandler argsHandler;
            if (_ArgsHandlerDic.TryGetValue(YPointerEventType.EndDrag, out argsHandler))
            {
                argsHandler.Process(eventData);
            }
        }
    }
}
