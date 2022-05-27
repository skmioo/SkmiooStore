using System;
using System.Collections.Generic;
using UnityEngine.Events;
using UYMO;
using SLua;

/// <summary>
/// y系列的EventTigger
/// </summary>
namespace UnityEngine.EventSystems
{

    [CustomLuaClassAttribute]
    public class YEventTrigger:EventTrigger
    {
        [CustomLuaClassAttribute]
        public class YEntry
        {
            public LuaTable caller;
            public LuaTable args;

            public Action<LuaTable, BaseEventData, LuaTable> callback;

            public EventTriggerType eventID = EventTriggerType.PointerClick;

            public YEntry()
            {

            }

            public void SetLuaFunc(EventTriggerType eventType, LuaTable c, Action<LuaTable, BaseEventData, LuaTable> callback, LuaTable args)
            {
                this.caller = c;
                this.eventID = eventType;
                this.callback = callback;
                this.args = args;
            }
        }
        private List<YEntry> m_Delegates;

        public new List<YEntry> triggers
        {
            get
            {
                if (m_Delegates == null)
                    m_Delegates = new List<YEntry>();
                return m_Delegates;
            }
            set { m_Delegates = value; }
        }
        
        private void Execute(EventTriggerType id, BaseEventData eventData)
        {
            for (int i = 0, imax = triggers.Count; i < imax; ++i)
            {
                var ent = triggers[i];
                if (ent.eventID == id && ent.callback != null)
                    ent.callback(ent.caller, eventData, ent.args);
            }
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            Execute(EventTriggerType.PointerEnter, eventData);
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            Execute(EventTriggerType.PointerExit, eventData);
        }

        public override void OnDrag(PointerEventData eventData)
        {
            Execute(EventTriggerType.Drag, eventData);
        }

        public override void OnDrop(PointerEventData eventData)
        {
            Execute(EventTriggerType.Drop, eventData);
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            Execute(EventTriggerType.PointerDown, eventData);
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            Execute(EventTriggerType.PointerUp, eventData);
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            Execute(EventTriggerType.PointerClick, eventData);
        }

        public override void OnSelect(BaseEventData eventData)
        {
            Execute(EventTriggerType.Select, eventData);
        }

        public override void OnDeselect(BaseEventData eventData)
        {
            Execute(EventTriggerType.Deselect, eventData);
        }

        public override void OnScroll(PointerEventData eventData)
        {
            Execute(EventTriggerType.Scroll, eventData);
        }

        public override void OnMove(AxisEventData eventData)
        {
            Execute(EventTriggerType.Move, eventData);
        }

        public override void OnUpdateSelected(BaseEventData eventData)
        {
            Execute(EventTriggerType.UpdateSelected, eventData);
        }

        public override void OnInitializePotentialDrag(PointerEventData eventData)
        {
            Execute(EventTriggerType.InitializePotentialDrag, eventData);
        }

        public override void OnBeginDrag(PointerEventData eventData)
        {
            Execute(EventTriggerType.BeginDrag, eventData);
        }

        public override void OnEndDrag(PointerEventData eventData)
        {
            Execute(EventTriggerType.EndDrag, eventData);
        }

        public override void OnSubmit(BaseEventData eventData)
        {
            Execute(EventTriggerType.Submit, eventData);
        }

        public override void OnCancel(BaseEventData eventData)
        {
            Execute(EventTriggerType.Cancel, eventData);
        }

    }
}