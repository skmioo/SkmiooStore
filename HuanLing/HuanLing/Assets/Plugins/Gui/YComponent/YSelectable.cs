using System;
using System.Collections.Generic;
using UnityEngine.Serialization;
using UnityEngine.EventSystems;
using UYMO;
using SLua;

namespace UnityEngine.UI
{
    // Simple selectable object - derived from to create a control.
    [CustomLuaClass]
    [ExecuteInEditMode]
    [SelectionBase]
    [DisallowMultipleComponent]
    public class YSelectable
        :
        UIBehaviour,
        IMoveHandler,
        IPointerDownHandler, IPointerUpHandler,
        IPointerEnterHandler, IPointerExitHandler,
        ISelectHandler, IDeselectHandler,
        IClearable
    {
        // Selection state

        // List of all the selectable objects currently active in the scene
        private static List<YSelectable> s_List = new List<YSelectable>();
        public static List<YSelectable> allSelectables { get { return s_List; } }

        // Navigation information.
        [FormerlySerializedAs("navigation")]
        [SerializeField]
        private YNavigation m_Navigation = YNavigation.defaultNavigation;

        // Highlighting state
        public enum Transition
        {
            None,
            ColorTint,
            SpriteSwap,
            Animation
        }

        // Type of the transition that occurs when the button state changes.
        [FormerlySerializedAs("transition")]
        [SerializeField]
        private Transition m_Transition = Transition.ColorTint;

        // Colors used for a color tint-based transition.
        [FormerlySerializedAs("colors")]
        [SerializeField]
        private ColorBlock m_Colors = ColorBlock.defaultColorBlock;

        // Sprites used for a Image swap-based transition.
        [FormerlySerializedAs("spriteState")]
        [SerializeField]
        private SpriteState m_SpriteState;

        [FormerlySerializedAs("animationTriggers")]
        [SerializeField]
        private AnimationTriggers m_AnimationTriggers = new AnimationTriggers();

        [Tooltip("Can the Selectable be interacted with?")]
        [SerializeField]
        private bool m_Interactable = true;

        // Graphic that will be colored.
        [FormerlySerializedAs("highlightGraphic")]
        [FormerlySerializedAs("m_HighlightGraphic")]
        [SerializeField]
        private YImage m_TargetGraphic;

        [SerializeField]
        protected YLabel m_TargetLabel;

        private bool m_GroupsAllowInteraction = true;

        private SelectionState m_CurrentSelectionState;

        private Color _LastTargetColor = Color.white;

        private bool _Garbage = false;


        public YNavigation navigation { get { return m_Navigation; } set { if (YSetPropertyUtility.SetStruct(ref m_Navigation, value)) OnSetProperty(); } }
        public Transition transition { get { return m_Transition; } set { if (YSetPropertyUtility.SetStruct(ref m_Transition, value)) OnSetProperty(); } }
        public ColorBlock colors { get { return m_Colors; } set { if (YSetPropertyUtility.SetStruct(ref m_Colors, value)) OnSetProperty(); } }
        public Color normalColor
        {
            get { return m_Colors.normalColor; }
            set
            {
                if (m_Colors.normalColor != value)
                {
                    m_Colors.normalColor = value;
                    OnSetProperty();
                }
            }
        }
        public Color highlightedColor
        {
            get { return m_Colors.highlightedColor; }
            set
            {
                if (m_Colors.highlightedColor != value)
                {
                    m_Colors.highlightedColor = value;
                    OnSetProperty();
                }
            }
        }
        public Color pressedColor
        {
            get { return m_Colors.pressedColor; }
            set
            {
                if (m_Colors.pressedColor != value)
                {
                    m_Colors.pressedColor = value;
                    OnSetProperty();
                }
            }
        }
        public Color disabledColor
        {
            get { return m_Colors.disabledColor; }
            set
            {
                if (m_Colors.disabledColor != value)
                {
                    m_Colors.disabledColor = value;
                    OnSetProperty();
                }
            }
        }
        public float colorMultiplier
        {
            get { return m_Colors.colorMultiplier; }
            set
            {
                if (m_Colors.colorMultiplier != value)
                {
                    m_Colors.colorMultiplier = value;
                    OnSetProperty();
                }
            }
        }
        public float fadeDuration
        {
            get { return m_Colors.fadeDuration; }
            set
            {
                if (m_Colors.fadeDuration != value)
                {
                    m_Colors.fadeDuration = value;
                    OnSetProperty();
                }
            }
        }
        public SpriteState spriteState { get { return m_SpriteState; } set { } }//if (YSetPropertyUtility.SetStruct(ref m_SpriteState, value))       OnSetProperty(); } }
        public AnimationTriggers animationTriggers { get { return m_AnimationTriggers; } set { if (YSetPropertyUtility.SetClass(ref m_AnimationTriggers, value)) OnSetProperty(); } }
        public YImage targetGraphic
        {
            get { return m_TargetGraphic; }
            set
            {
                if (YSetPropertyUtility.SetClass(ref m_TargetGraphic, value)) OnSetProperty();
                if (m_TargetGraphic != null)
                    m_YSpriteState.ApplyTargetImageID(m_TargetGraphic.imageID);
            }
        }
        public YLabel targetLabel { get { return m_TargetLabel; } set { if (YSetPropertyUtility.SetClass(ref m_TargetLabel, value)) OnSetProperty(); } }
        public bool interactable { get { return m_Interactable; } set { if (YSetPropertyUtility.SetStruct(ref m_Interactable, value)) OnSetProperty(); } }

        private bool isPointerInside { get; set; }
        private bool isPointerDown { get; set; }
        private bool hasSelection { get; set; }

        protected YSelectable()
        { }

        // Convenience function that converts the Graphic to a Image, if possible
        public YImage image
        {
            get { return m_TargetGraphic as YImage; }
            set
            {
                m_TargetGraphic = value;
                if (m_TargetGraphic != null)
                    m_YSpriteState.ApplyTargetImageID(m_TargetGraphic.imageID);
            }
        }

        public YLabel label
        {
            get { return m_TargetLabel as YLabel; }
            set { m_TargetLabel = value; }
        }
        // Get the animator
        public Animator animator
        {
            get { return GetComponent<Animator>(); }
        }

        protected override void Awake()
        {
            Init();
        }


        private void Init()
        {
            if (m_TargetGraphic == null)
                m_TargetGraphic = GetComponent<YImage>();

            if (m_TargetGraphic != null)
                m_YSpriteState.ApplyTargetImageID(m_TargetGraphic.imageID);
        }

        /// <summary>
        /// SpriteSwap Sprite加载完成处理
        /// 强制刷新当前Sprite
        /// </summary>
        private void OnLoadSpriteCompeleted(SelectionState state)
        {
            if (IsDestroyed())
            {
                return;
            }
            if (m_Transition == Transition.SpriteSwap && currentSelectionState == state)
            {
                DoStateTransition(currentSelectionState, false);
            }
            if (!m_Interactable && state == SelectionState.Disabled)
            {
                DoStateTransition(state, false);
            }
        }

        private readonly List<CanvasGroup> m_CanvasGroupCache = new List<CanvasGroup>();
        protected override void OnCanvasGroupChanged()
        {
            // Figure out if parent groups allow interaction
            // If no interaction is alowed... then we need
            // to not do that :)
            var groupAllowInteraction = true;
            Transform t = transform;
            while (t != null)
            {
                t.GetComponents(m_CanvasGroupCache);
                bool shouldBreak = false;
                for (var i = 0; i < m_CanvasGroupCache.Count; i++)
                {
                    // if the parent group does not allow interaction
                    // we need to break
                    if (!m_CanvasGroupCache[i].interactable)
                    {
                        groupAllowInteraction = false;
                        shouldBreak = true;
                    }
                    // if this is a 'fresh' group, then break
                    // as we should not consider parents
                    if (m_CanvasGroupCache[i].ignoreParentGroups)
                        shouldBreak = true;
                }
                if (shouldBreak)
                    break;

                t = t.parent;
            }

            if (groupAllowInteraction != m_GroupsAllowInteraction)
            {
                m_GroupsAllowInteraction = groupAllowInteraction;
                OnSetProperty();
            }
        }

        public virtual bool IsInteractable()
        {
            return m_GroupsAllowInteraction && m_Interactable;
        }

        // Call from unity if animation properties have changed
        protected override void OnDidApplyAnimationProperties()
        {
            OnSetProperty();
        }

        // Select on enable and add to the list.
        protected override void OnEnable()
        {
            base.OnEnable();
            if(_Garbage)
            {
                _Garbage = false;
            }

            s_List.Add(this);
            var state = SelectionState.Normal;

            // The button will be highlighted even in some cases where it shouldn't.
            // For example: We only want to set the State as Highlighted if the StandaloneInputModule.m_CurrentInputMode == InputMode.Buttons
            // But we dont have access to this, and it might not apply to other InputModules.
            // TODO: figure out how to solve this. Case 617348.
            if (hasSelection)
                state = SelectionState.Highlighted;

            m_CurrentSelectionState = state;
            InternalEvaluateAndTransitionToSelectionState(true);
        }

        private void OnSetProperty()
        {
#if UNITY_EDITOR
            if (!Application.isPlaying)
                InternalEvaluateAndTransitionToSelectionState(true);
            else
#endif
            InternalEvaluateAndTransitionToSelectionState(false);
        }

        // Remove from the list.
        protected override void OnDisable()
        {
            s_List.Remove(this);
            m_CurrentSelectionState = SelectionState.Disabled;
            InstantClearState();
            base.OnDisable();
        }

#if UNITY_EDITOR
        protected override void OnValidate()
        {
            base.OnValidate();
            m_Colors.fadeDuration = Mathf.Max(m_Colors.fadeDuration, 0.0f);

            // OnValidate can be called before OnEnable, this makes it unsafe to access other components
            // since they might not have been initialized yet.
            // OnSetProperty potentially access Animator or Graphics. (case 618186)
            if (isActiveAndEnabled)
            {
                // Need to clear out the override image on the target...
                DoSpriteSwap(null);

                // If the transition mode got changed, we need to clear all the transitions, since we don't know what the old transition mode was.
                StartColorTween(Color.white, true);
                TriggerAnimation(m_AnimationTriggers.normalTrigger);

                // And now go to the right state.
                InternalEvaluateAndTransitionToSelectionState(true);
            }
        }

        protected override void Reset()
        {
            m_TargetGraphic = GetComponent<YImage>();
            if (m_TargetGraphic != null)
                m_YSpriteState.ApplyTargetImageID(m_TargetGraphic.imageID);
        }

#endif // if UNITY_EDITOR

        protected SelectionState currentSelectionState
        {
            get { return m_CurrentSelectionState; }
        }

        protected virtual void InstantClearState()
        {
            string triggerName = m_AnimationTriggers.normalTrigger;

            isPointerInside = false;
            isPointerDown = false;
            hasSelection = false;

            switch (m_Transition)
            {
                case Transition.ColorTint:
                    StartColorTween(Color.white, true);
                    break;
                case Transition.SpriteSwap:
                    DoSpriteSwap(null);
                    break;
                case Transition.Animation:
                    TriggerAnimation(triggerName);
                    break;
            }
        }

        /// <summary>
        /// 当前切换的状态
        /// </summary>
        private SelectionState _CurrentTranslatedState = SelectionState.Normal;


        protected virtual void DoStateTransition(SelectionState state, bool instant)
        {
            Color tintColor;
            string triggerName;

            _CurrentTranslatedState = state;
            switch (state)
            {
                case SelectionState.Normal:
                    tintColor = m_Colors.normalColor;
                    triggerName = m_AnimationTriggers.normalTrigger;
                    break;
                case SelectionState.Highlighted:
                    tintColor = m_Colors.highlightedColor;
                    triggerName = m_AnimationTriggers.highlightedTrigger;
                    break;
                case SelectionState.Pressed:
                    tintColor = m_Colors.pressedColor;
                    triggerName = m_AnimationTriggers.pressedTrigger;
                    break;
                case SelectionState.Disabled:
                    tintColor = m_Colors.disabledColor;
                    triggerName = m_AnimationTriggers.disabledTrigger;
                    break;
                default:
                    tintColor = Color.black;
                    triggerName = string.Empty;
                    break;
            }

            if (gameObject.activeInHierarchy)
            {
                switch (m_Transition)
                {
                    case Transition.ColorTint:
                        StartColorTween(tintColor * m_Colors.colorMultiplier, instant);
                        break;
                    case Transition.SpriteSwap:
                        DoSpriteSwap(null);
                        break;
                    case Transition.Animation:
                        TriggerAnimation(triggerName);
                        break;
                }
            }

            SetTargetLabelState(state);
        }

        protected virtual void SetTargetLabelState(SelectionState state)
        {

        }
        [SLua.DoNotToLua]
        public enum SelectionState
        {
            Normal,
            Highlighted,
            Pressed,
            Disabled
        }

        // Selection logic

        // Find the next selectable object in the specified world-space direction.
        public YSelectable FindSelectable(Vector3 dir)
        {
            dir = dir.normalized;
            Vector3 localDir = Quaternion.Inverse(transform.rotation) * dir;
            Vector3 pos = transform.TransformPoint(GetPointOnRectEdge(transform as RectTransform, localDir));
            float maxScore = Mathf.NegativeInfinity;
            YSelectable bestPick = null;
            for (int i = 0; i < s_List.Count; ++i)
            {
                YSelectable sel = s_List[i];

                if (sel == this || sel == null)
                    continue;

                if (!sel.IsInteractable() || sel.navigation.mode == YNavigation.Mode.None)
                    continue;

                var selRect = sel.transform as RectTransform;
                Vector3 selCenter = selRect != null ? (Vector3)selRect.rect.center : Vector3.zero;
                Vector3 myVector = sel.transform.TransformPoint(selCenter) - pos;

                // Value that is the distance out along the direction.
                float dot = Vector3.Dot(dir, myVector);

                // Skip elements that are in the wrong direction or which have zero distance.
                // This also ensures that the scoring formula below will not have a division by zero error.
                if (dot <= 0)
                    continue;

                // This scoring function has two priorities:
                // - Score higher for positions that are closer.
                // - Score higher for positions that are located in the right direction.
                // This scoring function combines both of these criteria.
                // It can be seen as this:
                //   Dot (dir, myVector.normalized) / myVector.magnitude
                // The first part equals 1 if the direction of myVector is the same as dir, and 0 if it's orthogonal.
                // The second part scores lower the greater the distance is by dividing by the distance.
                // The formula below is equivalent but more optimized.
                //
                // If a given score is chosen, the positions that evaluate to that score will form a circle
                // that touches pos and whose center is located along dir. A way to visualize the resulting functionality is this:
                // From the position pos, blow up a circular balloon so it grows in the direction of dir.
                // The first Selectable whose center the circular balloon touches is the one that's chosen.
                float score = dot / myVector.sqrMagnitude;

                if (score > maxScore)
                {
                    maxScore = score;
                    bestPick = sel;
                }
            }
            return bestPick;
        }

        private static Vector3 GetPointOnRectEdge(RectTransform rect, Vector2 dir)
        {
            if (rect == null)
                return Vector3.zero;
            if (dir != Vector2.zero)
                dir /= Mathf.Max(Mathf.Abs(dir.x), Mathf.Abs(dir.y));
            dir = rect.rect.center + Vector2.Scale(rect.rect.size, dir * 0.5f);
            return dir;
        }

        // Convenience function -- change the selection to the specified object if it's not null and happens to be active.
        void Navigate(AxisEventData eventData, YSelectable sel)
        {
            if (sel != null && sel.IsActive())
                eventData.selectedObject = sel.gameObject;
        }

        // Find the selectable object to the left of this one.
        public virtual YSelectable FindSelectableOnLeft()
        {
            if (m_Navigation.mode == YNavigation.Mode.Explicit)
            {
                return m_Navigation.selectOnLeft;
            }
            if ((m_Navigation.mode & YNavigation.Mode.Horizontal) != 0)
            {
                return FindSelectable(transform.rotation * Vector3.left);
            }
            return null;
        }

        // Find the selectable object to the right of this one.
        public virtual YSelectable FindSelectableOnRight()
        {
            if (m_Navigation.mode == YNavigation.Mode.Explicit)
            {
                return m_Navigation.selectOnRight;
            }
            if ((m_Navigation.mode & YNavigation.Mode.Horizontal) != 0)
            {
                return FindSelectable(transform.rotation * Vector3.right);
            }
            return null;
        }

        // Find the selectable object above this one
        public virtual YSelectable FindSelectableOnUp()
        {
            if (m_Navigation.mode == YNavigation.Mode.Explicit)
            {
                return m_Navigation.selectOnUp;
            }
            if ((m_Navigation.mode & YNavigation.Mode.Vertical) != 0)
            {
                return FindSelectable(transform.rotation * Vector3.up);
            }
            return null;
        }

        // Find the selectable object below this one.
        public virtual YSelectable FindSelectableOnDown()
        {
            if (m_Navigation.mode == YNavigation.Mode.Explicit)
            {
                return m_Navigation.selectOnDown;
            }
            if ((m_Navigation.mode & YNavigation.Mode.Vertical) != 0)
            {
                return FindSelectable(transform.rotation * Vector3.down);
            }
            return null;
        }

        public virtual void OnMove(AxisEventData eventData)
        {
            switch (eventData.moveDir)
            {
                case MoveDirection.Right:
                    Navigate(eventData, FindSelectableOnRight());
                    break;

                case MoveDirection.Up:
                    Navigate(eventData, FindSelectableOnUp());
                    break;

                case MoveDirection.Left:
                    Navigate(eventData, FindSelectableOnLeft());
                    break;

                case MoveDirection.Down:
                    Navigate(eventData, FindSelectableOnDown());
                    break;
            }
        }

        void StartColorTween(Color targetColor, bool instant)
        {
            if (m_TargetGraphic == null)
                return;

            if(targetColor != _LastTargetColor)
            {
                m_TargetGraphic.CrossFadeColor(targetColor, instant ? 0f : m_Colors.fadeDuration, true, true);
                _LastTargetColor = targetColor;
            }
            
        }

        void DoSpriteSwap(Sprite newSprite)
        {
            if (image == null)
                return;

            if (m_Transition != Transition.SpriteSwap)
                return;

            if(Application.isPlaying)
            {
                switch (_CurrentTranslatedState)
                {
                    case SelectionState.Normal:
                        {
                            //if (!m_YSpriteState.normalSpriteResID.isZero)
                            {
                                image.imageID = m_YSpriteState.normalSpriteResID;
                            }
                        }
                        break;
                    case SelectionState.Highlighted:
                        {
                            if (!m_YSpriteState.highlightedSprite.isZero)
                            {
                                image.imageID = m_YSpriteState.highlightedSprite;
                            }else
                            {
                                if (!m_YSpriteState.normalSpriteResID.isZero)
                                {
                                    image.imageID = m_YSpriteState.normalSpriteResID;
                                }
                            }
                        }
                        break;
                    case SelectionState.Pressed:
                        {
                            if (!m_YSpriteState.pressedSprite.isZero)
                            {
                                image.imageID = m_YSpriteState.pressedSprite;
                            }
                        }
                        break;
                    case SelectionState.Disabled:
                        {
                            if (!m_YSpriteState.disabledSprite.isZero)
                            {
                                image.imageID = m_YSpriteState.disabledSprite;
                            }
                        }
                        break;
                }
            }           
        }

        void TriggerAnimation(string triggername)
        {
            if (animator == null || !animator.isActiveAndEnabled || animator.runtimeAnimatorController == null || string.IsNullOrEmpty(triggername))
                return;

            animator.ResetTrigger(m_AnimationTriggers.normalTrigger);
            animator.ResetTrigger(m_AnimationTriggers.pressedTrigger);
            animator.ResetTrigger(m_AnimationTriggers.highlightedTrigger);
            animator.ResetTrigger(m_AnimationTriggers.disabledTrigger);
            animator.SetTrigger(triggername);
        }

        // Whether the control should be 'selected'.
        protected bool IsHighlighted(BaseEventData eventData)
        {
            if (!IsActive())
                return false;

            if (IsPressed())
                return false;

            bool selected = hasSelection;
            if (eventData is PointerEventData)
            {
                var pointerData = eventData as PointerEventData;
                selected |=
                    (isPointerDown && !isPointerInside && pointerData.pointerPress == gameObject) // This object pressed, but pointer moved off
                    || (!isPointerDown && isPointerInside && pointerData.pointerPress == gameObject) // This object pressed, but pointer released over (PointerUp event)
                    || (!isPointerDown && isPointerInside && pointerData.pointerPress == null); // Nothing pressed, but pointer is over
            }
            else
            {
                selected |= isPointerInside;
            }
            return selected;
        }

        [Obsolete("Is Pressed no longer requires eventData", false)]
        protected bool IsPressed(BaseEventData eventData)
        {
            return IsPressed();
        }

        // Whether the control should be pressed.
        protected bool IsPressed()
        {
            if (!IsActive())
                return false;

            return isPointerInside && isPointerDown;
        }

        // The current visual state of the control.
        protected void UpdateSelectionState(BaseEventData eventData)
        {
            if (IsPressed())
            {
                m_CurrentSelectionState = SelectionState.Pressed;
                return;
            }

            if (IsHighlighted(eventData))
            {
                m_CurrentSelectionState = SelectionState.Highlighted;
                return;
            }

            m_CurrentSelectionState = SelectionState.Normal;
        }

        // Change the button to the correct state
        private void EvaluateAndTransitionToSelectionState(BaseEventData eventData)
        {
            if (!IsActive())
                return;

            UpdateSelectionState(eventData);
            InternalEvaluateAndTransitionToSelectionState(false);
        }

        private void InternalEvaluateAndTransitionToSelectionState(bool instant)
        {
            var transitionState = m_CurrentSelectionState;
            if (IsActive() && !IsInteractable())
                transitionState = SelectionState.Disabled;
            DoStateTransition(transitionState, instant);
        }

        public virtual void OnPointerDown(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left)
                return;

            // Selection tracking
            if (IsInteractable() && navigation.mode != YNavigation.Mode.None)
                EventSystem.current.SetSelectedGameObject(gameObject, eventData);

            isPointerDown = true;
            EvaluateAndTransitionToSelectionState(eventData);
        }

        public virtual void OnPointerUp(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left)
                return;

            isPointerDown = false;
            EvaluateAndTransitionToSelectionState(eventData);
        }

        public virtual void OnPointerEnter(PointerEventData eventData)
        {
            isPointerInside = true;
            EvaluateAndTransitionToSelectionState(eventData);
        }

        public virtual void OnPointerExit(PointerEventData eventData)
        {
            isPointerInside = false;
            EvaluateAndTransitionToSelectionState(eventData);
        }

        public virtual void OnSelect(BaseEventData eventData)
        {
            hasSelection = true;
            EvaluateAndTransitionToSelectionState(eventData);
        }

        public virtual void OnDeselect(BaseEventData eventData)
        {
            hasSelection = false;
            EvaluateAndTransitionToSelectionState(eventData);
        }

        public virtual void Select()
        {
            if (EventSystem.current.alreadySelecting)
                return;

            EventSystem.current.SetSelectedGameObject(gameObject);
        }

        [FormerlySerializedAs("yspriteState")]
        [SerializeField]
        private YSpriteState m_YSpriteState = new YSpriteState();
        public YSpriteState yspriteState { get { return m_YSpriteState; } set { m_YSpriteState = value; OnSetProperty(); } }

        public ResID highlightedSprite
        {
            get { return m_YSpriteState.highlightedSprite; }
            set
            {
                if (m_YSpriteState.highlightedSprite != value)
                {
                    m_YSpriteState.highlightedSprite = value;
                }
            }
        }
        public ResID pressedSprite
        {
            get { return m_YSpriteState.pressedSprite; }
            set
            {
                if (m_YSpriteState.pressedSprite!= value)
                {
                    m_YSpriteState.pressedSprite = value;
                }
            }
        }
        public ResID disabledSprite
        {
            get { return m_YSpriteState.disabledSprite; }
            set
            {
                if (m_YSpriteState.disabledSprite != value)
                {
                    m_YSpriteState.disabledSprite = value;
                }
            }
        }

        public void SetHighlightedSprite(ResID id)
        {
            m_YSpriteState.highlightedSprite = id;
        } 
        public void SetPressedSprite(ResID id)
        {
            m_YSpriteState.pressedSprite = id;
        }
        public void SetDisabledSprite(ResID id)
        {
            m_YSpriteState.disabledSprite = id;
        }



        [SerializeField]
        private ResID m_Sound = UYMO.UIResDefine.uiSoundResID;
        public ResID sound
        {
            get { return m_Sound; }
            set { m_Sound = value; }
        }

        /// <summary>
        /// 用户数据
        /// </summary>
        public object userData { get; set; }

        public bool visible
        {
            get { return gameObject.activeSelf; }
            set { gameObject.SetActive(value); }
        }

        public virtual void ClearLuaHandler() { }

        public void Clear()
        {
            ClearLuaHandler();       
            userData = null;
            _Garbage = true;
        }

        /// <summary>
        /// 验证重新刷新
        /// </summary>
        public void Validate()
        {
            var state = SelectionState.Normal;

            // The button will be highlighted even in some cases where it shouldn't.
            // For example: We only want to set the State as Highlighted if the StandaloneInputModule.m_CurrentInputMode == InputMode.Buttons
            // But we dont have access to this, and it might not apply to other InputModules.
            // TODO: figure out how to solve this. Case 617348.
            if (hasSelection)
                state = SelectionState.Highlighted;

            m_CurrentSelectionState = state;
            InternalEvaluateAndTransitionToSelectionState(true);
        }
    }
}
