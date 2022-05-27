using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using SLua;
using UYMO;

namespace UnityEngine.UI
{
    /// <summary>
    /// Simple toggle -- something that has an 'on' and 'off' states: checkbox, toggle button, radio button, etc.
    /// </summary>
    [CustomLuaClass]
    [AddComponentMenu("UI/YToggle", 35)]
    [RequireComponent(typeof(RectTransform))]
    public class YToggle : YSelectable, IPointerClickHandler, ISubmitHandler, ICanvasElement
    {
        public enum ToggleTransition
        {
            None,
            Fade
        }

        [Serializable]
        public class ToggleEvent : UnityEvent<bool>
        { }

        /// <summary>
        /// Transition type.
        /// </summary>
        public ToggleTransition toggleTransition = ToggleTransition.Fade;

        /// <summary>
        /// Graphic the toggle should be working with.
        /// </summary>
        public Graphic graphic;

        // group that this toggle can belong to
        [SerializeField]
        private YToggleGroup m_Group;

        public YToggleGroup group
        {
            get { return m_Group; }
            set
            {
                m_Group = value;
#if UNITY_EDITOR
                if (Application.isPlaying)
#endif
                {
                    SetToggleGroup(m_Group, true);
                    PlayEffect(true);
                }
            }
        }

        /// <summary>
        /// Allow for delegate-based subscriptions for faster events than 'eventReceiver', and allowing for multiple receivers.
        /// </summary>
        public ToggleEvent onValueChanged = new ToggleEvent();

        // Whether the toggle is on
        [FormerlySerializedAs("m_IsActive")]
        [Tooltip("Is the toggle currently on or off?")]
        [SerializeField]
        private bool m_IsOn;

        [Tooltip("选中|取消两张图片是否互相替换，默认false")]
        [SerializeField]
        private bool m_IsReplace;

        public object userdata;

        protected YToggle()
        {
        }

#if UNITY_EDITOR
        protected override void OnValidate()
        {
            base.OnValidate();
            Set(m_IsOn, false);
            PlayEffect(toggleTransition == ToggleTransition.None);

            var prefabType = UnityEditor.PrefabUtility.GetPrefabType(this);
            if (prefabType != UnityEditor.PrefabType.Prefab && !Application.isPlaying)
                CanvasUpdateRegistry.RegisterCanvasElementForLayoutRebuild(this);

            if (m_TargetLabel != null)
            {
                m_TargetLabel.touchState = m_IsOn ? YLabel.LabelTouchState.Pressed : YLabel.LabelTouchState.Normal;
            }
        }

#endif // if UNITY_EDITOR

        public virtual void Rebuild(CanvasUpdate executing)
        {
#if UNITY_EDITOR
            if (executing == CanvasUpdate.Prelayout)
                onValueChanged.Invoke(m_IsOn);
#endif
        }

        public virtual void LayoutComplete()
        { }

        public virtual void GraphicUpdateComplete()
        { }

        protected override void OnEnable()
        {
            base.OnEnable();
            SetToggleGroup(m_Group, false);
            PlayEffect(true);
        }

        protected override void OnDisable()
        {
            SetToggleGroup(null, false);
            base.OnDisable();
        }

        protected override void OnDidApplyAnimationProperties()
        {
            // Check if isOn has been changed by the animation.
            // Unfortunately there is no way to check if we don�t have a graphic.
            if (graphic != null)
            {
                bool oldValue = !Mathf.Approximately(graphic.canvasRenderer.GetColor().a, 0);
                if (m_IsOn != oldValue)
                {
                    m_IsOn = oldValue;
                    Set(!oldValue);
                }
            }

            base.OnDidApplyAnimationProperties();
        }

        private void SetToggleGroup(YToggleGroup newGroup, bool setMemberValue)
        {
            YToggleGroup oldGroup = m_Group;

            // Sometimes IsActive returns false in OnDisable so don't check for it.
            // Rather remove the toggle too often than too little.
            if (m_Group != null)
                m_Group.UnregisterToggle(this);

            // At runtime the group variable should be set but not when calling this method from OnEnable or OnDisable.
            // That's why we use the setMemberValue parameter.
            if (setMemberValue)
                m_Group = newGroup;

            // Only register to the new group if this Toggle is active.
            if (m_Group != null && IsActive())
                m_Group.RegisterToggle(this);


            // If we are in a new group, and this toggle is on, notify group.
            // Note: Don't refer to m_Group here as it's not guaranteed to have been set.
            if (newGroup != null && newGroup != oldGroup && isOn && IsActive())
                m_Group.NotifyToggleOn(this);
        }

        /// <summary>
        /// Whether the toggle is currently active.
        /// </summary>
        public bool isOn
        {
            get { return m_IsOn; }
            set
            {
                Set(value);
            }
        }
        public bool isReplace
        {
            get { return m_IsReplace; }
            set
            {
                if (m_IsReplace != value)
                {
                    m_IsReplace = value;
                    PlayEffect(toggleTransition == ToggleTransition.None);
                }
            }
        }
        public string text
        {
            get { return m_TargetLabel == null ? "" : m_TargetLabel.text; }
            set
            {
                if (m_TargetLabel != null)
                    m_TargetLabel.text = value;
            }
        }

        void Set(bool value)
        {
            Set(value, true);
        }

        void Set(bool value, bool sendCallback)
        {
            if (m_IsOn == value)
                return;

            if (m_ToggleCheckCallback != null && !m_ToggleCheckCallback(m_ToggleChecker, this))
            {//确认是否可以切换
                return;
            }

            if (m_ChangeEnable)
            {
                // if we are in a group and set to true, do group logic
                m_IsOn = value;
                if (m_Group != null && IsActive())
                {
                    if (m_IsOn || (!m_Group.AnyTogglesOn() && !m_Group.allowSwitchOff))
                    {
                        m_IsOn = true;
                        m_Group.NotifyToggleOn(this);
                    }
                }
            }

            // Handle Registered Toggle Handler
            if (m_LuaTable != null && m_LuaClickHandler != null)
            {
                m_LuaClickHandler(m_LuaTable, this, m_IsOn, m_LuaArgs);
            }

            // Always send event when toggle is clicked, even if value didn't change
            // due to already active toggle in a toggle group being clicked.
            // Controls like SelectionList rely on this.
            // It's up to the user to ignore a selection being set to the same value it already was, if desired.
            PlayEffect(toggleTransition == ToggleTransition.None);
            if (sendCallback)
                onValueChanged.Invoke(m_IsOn);

            if (m_TargetLabel != null)
            {
                m_TargetLabel.touchState = m_IsOn ? YLabel.LabelTouchState.Pressed : YLabel.LabelTouchState.Normal;
            }
        }

        /// <summary>
        /// Play the appropriate effect.
        /// </summary>
        private void PlayEffect(bool instant)
        {
            if (graphic == null)
                return;

#if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                graphic.canvasRenderer.SetAlpha(m_IsOn ? 1f : 0f);
                if (targetGraphic != null)
                {
                    targetGraphic.canvasRenderer.SetAlpha((m_IsOn && m_IsReplace) ? 0.0f : 1.0f);
                }
                return;
            }
#endif
            graphic.CrossFadeAlpha(m_IsOn ? 1f : 0f, instant ? 0f : m_FadeDuration, true);
            if (targetGraphic != null)
                targetGraphic.CrossFadeAlpha((m_IsOn && m_IsReplace) ? 0.0f : 1.0f, instant ? 0.0f : m_FadeDuration, true);
        }

        /// <summary>
        /// Assume the correct visual state.
        /// </summary>
        protected override void Start()
        {
            PlayEffect(true);
        }

        private void InternalToggle()
        {
            if (!IsActive() || !IsInteractable())
                return;

            if (isOn && group != null && !allowOffInGroupManually)
            {
                return;
            }
            isOn = !isOn;
        }

        /// <summary>
        /// React to clicks.
        /// </summary>
        public virtual void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left)
                return;

            if (!sound.isZero)
                PlayInterface.PlayUISound(sound);

            PlayInterface.NotifyLua("SystemNotify", "ClickUIHandle", gameObject);
            InternalToggle();
        }

        public virtual void OnSubmit(BaseEventData eventData)
        {
            InternalToggle();
        }

        private LuaTable m_LuaTable;
        private Action<LuaTable, YSelectable, bool, LuaTable> m_LuaClickHandler;
        private LuaTable m_LuaArgs;

        private Func<object, YSelectable, bool> m_ToggleCheckCallback;
        private object m_ToggleChecker;

        public void SetToggleHandler(LuaTable lua, Action<LuaTable, YSelectable, bool, LuaTable> handler)
        {
            m_LuaTable = lua;
            m_LuaClickHandler = handler;
        }

        public void SetToggleChecker(object caller, Func<object, YSelectable, bool> func)
        {
            m_ToggleChecker = caller;
            m_ToggleCheckCallback = func;
        }

        public void SetToggleHandler(LuaTable lua, Action<LuaTable, YSelectable, bool, LuaTable> handler, LuaTable luaArgs)
        {
            m_LuaTable = lua;
            m_LuaClickHandler = handler;
            m_LuaArgs = luaArgs;
        }
        public override void ClearLuaHandler()
        {
            m_LuaTable = null;
            m_LuaClickHandler = null;
            m_LuaArgs = null;
        }

        [SerializeField]
        private float m_FadeDuration = 0.1f;

        public float fadeDuration
        {
            get { return m_FadeDuration; }
            set { m_FadeDuration = value; }
        }

        [SerializeField]
        private bool m_AllowOffInGroupManually = true;
        /// <summary>
        /// 在有Group的情况下，是否允许通过点击把isON=ture的toggle设置为false
        /// </summary>
        public bool allowOffInGroupManually
        {
            get { return m_AllowOffInGroupManually; }
            set { m_AllowOffInGroupManually = value; }
        }

        [SerializeField]
        private bool m_ChangeEnable = true;
        /// isOn是否可以改变
        public bool changeEnable
        {
            get { return m_ChangeEnable; }
            set { m_ChangeEnable = value; }
        }
    }
}
