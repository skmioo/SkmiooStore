using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GEvent
{
    public enum GEventType
    {
        RightClickMedal,OpenRollMedal,ReturnMedal,HeroBusy,AddItem,RemoveItem,PreparePanelInitial,GoBattle
    }

    public delegate void GameEvent(Hashtable args);

    public class EventHelper
    {
        public static bool flag;
        static EventHelper instance;
        public static EventHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EventHelper();
                }
                return instance;
            }
        }

        private Dictionary<GEventType, GameEvent> gameEventDic;

        public EventHelper()
        {
            gameEventDic = new Dictionary<GEventType, GameEvent>();
        }

        public void AddEvent(GEventType eventType, GameEvent gameEvent)
        {
            GameEvent gEvent;
            if (gameEventDic.TryGetValue(eventType, out gEvent))
            {
                gEvent += gameEvent;
                gameEventDic[eventType] = gEvent;
            }
            else
            {
                gEvent += gameEvent;
                gameEventDic.Add(eventType, gEvent);
            }
        }

        public void RemoveEvent(GEventType eventType, GameEvent gameEvent)
        {
            GameEvent gEvent;
            if (gameEventDic.TryGetValue(eventType, out gEvent))
            {
                gEvent -= gameEvent;
                gameEventDic[eventType] = gEvent;
            }
        }

        public void ExcuteEvent(GEventType eventType,Hashtable args)
        {
            GameEvent gEvent;
            if (gameEventDic.TryGetValue(eventType,out gEvent))
            {
                if (gEvent != null)
                {
                    gEvent(args);
                }
            }
        }

        private void OnDestroy()
        {
            ClearEvents();
        }

        public void ClearEvents()
        {
            gameEventDic.Clear();
        }
    }
}


