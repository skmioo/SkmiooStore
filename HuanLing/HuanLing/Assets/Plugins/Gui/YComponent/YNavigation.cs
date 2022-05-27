using System;
using UnityEngine.Serialization;

namespace UnityEngine.UI
{
    [Serializable]
    public struct YNavigation
    {
        /*
         * This looks like it's not flags, but it is flags,
         * the reason is that Automatic is considered horizontal
         * and verical mode combined
         */
        [Flags]
        public enum Mode
        {
            None = 0, // No navigation
            Horizontal = 1, // Automatic horizontal navigation
            Vertical = 2, // Automatic vertical navigation
            Automatic = 3, // Automatic navigation in both dimensions
            Explicit = 4, // Explicitly specified only
        }

        // Which method of navigation will be used.
        [FormerlySerializedAs("mode")]
        [SerializeField]
        private Mode m_Mode;

        // Game object selected when the joystick moves up. Used when navigation is set to "Explicit".
        [FormerlySerializedAs("selectOnUp")]
        [SerializeField]
        private YSelectable m_SelectOnUp;

        // Game object selected when the joystick moves down. Used when navigation is set to "Explicit".
        [FormerlySerializedAs("selectOnDown")]
        [SerializeField]
        private YSelectable m_SelectOnDown;

        // Game object selected when the joystick moves left. Used when navigation is set to "Explicit".
        [FormerlySerializedAs("selectOnLeft")]
        [SerializeField]
        private YSelectable m_SelectOnLeft;

        // Game object selected when the joystick moves right. Used when navigation is set to "Explicit".
        [FormerlySerializedAs("selectOnRight")]
        [SerializeField]
        private YSelectable m_SelectOnRight;

        public Mode mode { get { return m_Mode; } set { m_Mode = value; } }
        public YSelectable selectOnUp { get { return m_SelectOnUp; } set { m_SelectOnUp = value; } }
        public YSelectable selectOnDown { get { return m_SelectOnDown; } set { m_SelectOnDown = value; } }
        public YSelectable selectOnLeft { get { return m_SelectOnLeft; } set { m_SelectOnLeft = value; } }
        public YSelectable selectOnRight { get { return m_SelectOnRight; } set { m_SelectOnRight = value; } }

        static public YNavigation defaultNavigation
        {
            get
            {
                var defaultNav = new YNavigation();
                defaultNav.m_Mode = Mode.Automatic;
                return defaultNav;
            }
        }
    }
}
