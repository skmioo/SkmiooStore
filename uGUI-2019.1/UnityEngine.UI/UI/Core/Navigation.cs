using System;
using UnityEngine.Serialization;

namespace UnityEngine.UI
{
    [Serializable]
    /// <summary>
    /// Navigation（按钮导航）：在EventSystem中，存在⼀个当前被选中按钮，我们可以通过代码按下的上下左右，
    /// 使被选中按钮进⾏更改。该导航有五种：
    /// None（关闭）：关闭导航。
    /// Automatic（⾃动导航）：⾃动识别最近的⼀个控件并导航到下⼀个控件。
    /// Horizontal（⽔平导航）：⽔平⽅向导航到下⼀个控件。
    /// Vertical（垂直导航）：垂直⽅向导航到下⼀个控件。
    /// Explicit（指定导航）：特别指定在按下特定⽅向键时从此按钮导航到哪⼀个控件
    /// Structure storing details related to navigation.
    /// </summary>
    public struct Navigation : IEquatable<Navigation>
    {
        /*
         * This looks like it's not flags, but it is flags,
         * the reason is that Automatic is considered horizontal
         * and verical mode combined
         */
        [Flags]
        /// <summary>
        /// Navigation mode enumeration.
        /// </summary>
        /// <remarks>
        /// This looks like it's not flags, but it is flags, the reason is that Automatic is considered horizontal and vertical mode combined
        /// </remarks>
        /// <example>
        /// <code>
        /// using UnityEngine;
        /// using System.Collections;
        /// using UnityEngine.UI; // Required when Using UI elements.
        ///
        /// public class ExampleClass : MonoBehaviour
        /// {
        ///     public Button button;
        ///
        ///     void Start()
        ///     {
        ///         //Set the navigation to the mode "Vertical".
        ///         if (button.navigation.mode == Navigation.Mode.Vertical)
        ///         {
        ///             Debug.Log("The button's navigation mode is Vertical");
        ///         }
        ///     }
        /// }
        /// </code>
        /// </example>
        public enum Mode
        {
            /// <summary>
            /// No navigation is allowed from this object.
            /// </summary>
            None        = 0,

            /// <summary>
            /// Horizontal Navigation.
            /// </summary>
            /// <remarks>
            /// Navigation should only be allowed when left / right move events happen.
            /// </remarks>
            Horizontal  = 1,

            /// <summary>
            /// Vertical navigation.
            /// </summary>
            /// <remarks>
            /// Navigation should only be allowed when up / down move events happen.
            /// </remarks>
            Vertical    = 2,

            /// <summary>
            /// Automatic navigation.
            /// </summary>
            /// <remarks>
            /// 尝试找到下一个要选择的“最佳”对象。这应该基于一个明智的启发式。
            /// Attempt to find the 'best' next object to select. This should be based on a sensible heuristic.
            /// </remarks>
            Automatic = 3,

            /// <summary>
            /// Explicit navigation.
            /// </summary>
            /// <remarks>
            /// User should explicitly specify what is selected by each move event.
            /// 用户应明确指定每个移动事件选择的内容。
            /// </remarks>
            Explicit = 4,
        }

        // Which method of navigation will be used.
        [SerializeField]
        private Mode m_Mode;

        // Game object selected when the joystick moves up. Used when navigation is set to "Explicit".
        [SerializeField]
        private Selectable m_SelectOnUp;

        // Game object selected when the joystick moves down. Used when navigation is set to "Explicit".
        [SerializeField]
        private Selectable m_SelectOnDown;

        // Game object selected when the joystick moves left. Used when navigation is set to "Explicit".
        [SerializeField]
        private Selectable m_SelectOnLeft;

        // Game object selected when the joystick moves right. Used when navigation is set to "Explicit".
        [SerializeField]
        private Selectable m_SelectOnRight;

        /// <summary>
        /// Navigation mode.
        /// </summary>
        public Mode       mode           { get { return m_Mode; } set { m_Mode = value; } }

        /// <summary>
        /// Specify a Selectable UI GameObject to highlight when the Up arrow key is pressed.
        /// </summary>
        /// <example>
        /// <code>
        /// using UnityEngine;
        /// using System.Collections;
        /// using UnityEngine.UI;  // Required when Using UI elements.
        ///
        /// public class HighlightOnKey : MonoBehaviour
        /// {
        ///     public Button btnSave;
        ///     public Button btnLoad;
        ///
        ///     public void Start()
        ///     {
        ///         // get the Navigation data
        ///         Navigation navigation = btnLoad.navigation;
        ///
        ///         // switch mode to Explicit to allow for custom assigned behavior
        ///         navigation.mode = Navigation.Mode.Explicit;
        ///
        ///         // highlight the Save button if the up arrow key is pressed
        ///         navigation.selectOnUp = btnSave;
        ///
        ///         // reassign the struct data to the button
        ///         btnLoad.navigation = navigation;
        ///     }
        /// }
        /// </code>
        /// </example>
        public Selectable selectOnUp     { get { return m_SelectOnUp; } set { m_SelectOnUp = value; } }

        /// <summary>
        /// Specify a Selectable UI GameObject to highlight when the down arrow key is pressed.
        /// </summary>
        /// <example>
        /// <code>
        /// using UnityEngine;
        /// using System.Collections;
        /// using UnityEngine.UI;  // Required when Using UI elements.
        ///
        /// public class HighlightOnKey : MonoBehaviour
        /// {
        ///     public Button btnSave;
        ///     public Button btnLoad;
        ///
        ///     public void Start()
        ///     {
        ///         // get the Navigation data
        ///         Navigation navigation = btnLoad.navigation;
        ///
        ///         // switch mode to Explicit to allow for custom assigned behavior
        ///         navigation.mode = Navigation.Mode.Explicit;
        ///
        ///         // highlight the Save button if the down arrow key is pressed
        ///         navigation.selectOnDown = btnSave;
        ///
        ///         // reassign the struct data to the button
        ///         btnLoad.navigation = navigation;
        ///     }
        /// }
        /// </code>
        /// </example>
        public Selectable selectOnDown   { get { return m_SelectOnDown; } set { m_SelectOnDown = value; } }

        /// <summary>
        /// Specify a Selectable UI GameObject to highlight when the left arrow key is pressed.
        /// </summary>
        /// <example>
        /// <code>
        /// using UnityEngine;
        /// using System.Collections;
        /// using UnityEngine.UI;  // Required when Using UI elements.
        ///
        /// public class HighlightOnKey : MonoBehaviour
        /// {
        ///     public Button btnSave;
        ///     public Button btnLoad;
        ///
        ///     public void Start()
        ///     {
        ///         // get the Navigation data
        ///         Navigation navigation = btnLoad.navigation;
        ///
        ///         // switch mode to Explicit to allow for custom assigned behavior
        ///         navigation.mode = Navigation.Mode.Explicit;
        ///
        ///         // highlight the Save button if the left arrow key is pressed
        ///         navigation.selectOnLeft = btnSave;
        ///
        ///         // reassign the struct data to the button
        ///         btnLoad.navigation = navigation;
        ///     }
        /// }
        /// </code>
        /// </example>
        public Selectable selectOnLeft   { get { return m_SelectOnLeft; } set { m_SelectOnLeft = value; } }

        /// <summary>
        /// Specify a Selectable UI GameObject to highlight when the right arrow key is pressed.
        /// </summary>
        /// <example>
        /// <code>
        /// using UnityEngine;
        /// using System.Collections;
        /// using UnityEngine.UI;  // Required when Using UI elements.
        ///
        /// public class HighlightOnKey : MonoBehaviour
        /// {
        ///     public Button btnSave;
        ///     public Button btnLoad;
        ///
        ///     public void Start()
        ///     {
        ///         // get the Navigation data
        ///         Navigation navigation = btnLoad.navigation;
        ///
        ///         // switch mode to Explicit to allow for custom assigned behavior
        ///         navigation.mode = Navigation.Mode.Explicit;
        ///
        ///         // highlight the Save button if the right arrow key is pressed
        ///         navigation.selectOnRight = btnSave;
        ///
        ///         // reassign the struct data to the button
        ///         btnLoad.navigation = navigation;
        ///     }
        /// }
        /// </code>
        /// </example>
        public Selectable selectOnRight  { get { return m_SelectOnRight; } set { m_SelectOnRight = value; } }

        /// <summary>
        /// Return a Navigation with sensible default values.
        /// </summary>
        /// <example>
        /// <code>
        /// using UnityEngine;
        /// using System.Collections;
        /// using UnityEngine.UI; // Required when Using UI elements.
        ///
        /// public class ExampleClass : MonoBehaviour
        /// {
        ///     public Button button;
        ///
        ///     void Start()
        ///     {
        ///         //Set the navigation to the default value. ("Automatic" is the default value).
        ///         button.navigation = Navigation.defaultNavigation;
        ///     }
        /// }
        /// </code>
        /// </example>
        static public Navigation defaultNavigation
        {
            get
            {
                var defaultNav = new Navigation();
                defaultNav.m_Mode = Mode.Automatic;
                return defaultNav;
            }
        }

        public bool Equals(Navigation other)
        {
            return mode == other.mode &&
                selectOnUp == other.selectOnUp &&
                selectOnDown == other.selectOnDown &&
                selectOnLeft == other.selectOnLeft &&
                selectOnRight == other.selectOnRight;
        }
    }
}
