using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine.UI
{
    public static class YFontUpdateTracker
    {
        static Dictionary<Font, List<YLabel>> m_Tracked = new Dictionary<Font, List<YLabel>>();

        public static void TrackText(YLabel t)
        {
            if (t.font == null)
                return;

            List<YLabel> exists;
            m_Tracked.TryGetValue(t.font, out exists);
            if (exists == null)
            {
                exists = new List<YLabel>();
                m_Tracked.Add(t.font, exists);

                Font.textureRebuilt += RebuildForFont;
            }

            for (int i = 0; i < exists.Count; i++)
            {
                if (exists[i] == t)
                    return;
            }

            exists.Add(t);
        }

        private static void RebuildForFont(Font f)
        {
            List<YLabel> texts;
            m_Tracked.TryGetValue(f, out texts);

            if (texts == null)
                return;

            for (var i = 0; i < texts.Count; i++)
                texts[i].FontTextureChanged();
        }

        public static void UntrackText(YLabel t)
        {
            if (t.font == null)
                return;

            List<YLabel> texts;
            m_Tracked.TryGetValue(t.font, out texts);

            if (texts == null)
                return;

            texts.Remove(t);

            if (texts.Count == 0)
            {
                //m_Tracked.Remove(t.font);
            }
        }
    }
}
