using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UYMO;

namespace UnityEngine.UI
{
    [AddComponentMenu("UI/YToggle Group", 36)]
    public class YToggleGroup : UIBehaviour, IClearable
    {
        [SerializeField] private bool m_AllowSwitchOff = false;
        public bool allowSwitchOff { get { return m_AllowSwitchOff; } set { m_AllowSwitchOff = value; } }

        private List<YToggle> m_Toggles = ObjectPool.toggleListPool.Create();

        protected override void OnDestroy()
        {
            ObjectPool.toggleListPool.Gabage(m_Toggles);
            base.OnDestroy();
        }
        private void ValidateToggleIsInGroup(YToggle toggle)
        {
            if (toggle == null || !m_Toggles.Contains(toggle))
                throw new ArgumentException(string.Format("YToggle {0} is not part of YToggleGroup {1}", new object[] {toggle, this}));
        }

        public void NotifyToggleOn(YToggle toggle)
        {
            ValidateToggleIsInGroup(toggle);

            // disable all toggles in the group
            for (var i = 0; i < m_Toggles.Count; i++)
            {
                if (m_Toggles[i] == toggle)
                    continue;

                m_Toggles[i].isOn = false;
            }
        }

        public void UnregisterToggle(YToggle toggle)
        {
            if (m_Toggles.Contains(toggle))
                m_Toggles.Remove(toggle);
        }

        public void RegisterToggle(YToggle toggle)
        {
            if (!m_Toggles.Contains(toggle))
                m_Toggles.Add(toggle);
        }

        public bool AnyTogglesOn()
        {
            return m_Toggles.Find(x => x.isOn) != null;
        }

        public IEnumerable<YToggle> ActiveToggles()
        {
            return m_Toggles.Where(x => x.isOn);
        }

        public void SetAllTogglesOff()
        {
            bool oldAllowSwitchOff = m_AllowSwitchOff;
            m_AllowSwitchOff = true;

            for (var i = 0; i < m_Toggles.Count; i++)
                m_Toggles[i].isOn = false;

            m_AllowSwitchOff = oldAllowSwitchOff;
        }

        public void Clear()
        {
            m_Toggles.Clear();
        }
    }
}
