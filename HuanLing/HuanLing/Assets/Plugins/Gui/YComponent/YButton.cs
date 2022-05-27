using System;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using SLua;
using DG.Tweening;
using UYMO;


namespace UnityEngine.UI
{
    // Button that's meant to work with mouse or touch-based devices.
    [CustomLuaClassAttribute]
    [AddComponentMenu("YUI/YButton", 3)]
    public class YButton : YSelectable, IPointerClickHandler, ISubmitHandler
    {
        private float _CDTime = 0.0f;
        private float _LastClickTime = 0.0f;
        [SLua.DoNotToLua]
        public event Action<YButton> eClick;

        public GameObject playEffect = null;

        protected YButton()
        { }

        public string text
        {
            get { return m_TargetLabel == null ? "" : m_TargetLabel.text; }
            set
            {
                if (m_TargetLabel != null)
                    m_TargetLabel.text = value;
            }
        }
        private void Press()
        {
            if (!IsActive() || !IsInteractable())
                return;

            if (Time.unscaledTime < _CDTime + _LastClickTime) 
                return;
            _LastClickTime = Time.unscaledTime;

            if (!sound.isZero)
                PlayInterface.PlayUISound(sound);
            PlayInterface.NotifyLua("SystemNotify", "ClickUIHandle", gameObject);

            if (m_LuaTable != null && m_LuaClickHandler != null)
            {
                m_LuaClickHandler(m_LuaTable, this, m_LuaArgs);
            }
            if(eClick!= null)
            {
                eClick(this);
            }

        }

        // Trigger all registered callbacks.
        [DoNotToLuaAttribute]
        public virtual void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left)
                return;

            Press();
        }

        [DoNotToLuaAttribute]
        public virtual void OnSubmit(BaseEventData eventData)
        {
            Press();

            // if we get set disabled during the press
            // don't run the coroutine.
            if (!IsActive() || !IsInteractable())
                return;

            DoStateTransition(SelectionState.Pressed, false);
            StartCoroutine(OnFinishSubmit());
        }

        public void SetCDTime(float cdTime)
        {
            _CDTime = cdTime;
        }
        private IEnumerator OnFinishSubmit()
        {
            var fadeTime = colors.fadeDuration;
            var elapsedTime = 0f;

            while (elapsedTime < fadeTime)
            {
                elapsedTime += Time.unscaledDeltaTime;
                yield return null;
            }

            DoStateTransition(currentSelectionState, false);
        }

        protected override void SetTargetLabelState(YSelectable.SelectionState state)
        {
            if (m_TargetLabel != null)
            {
                m_TargetLabel.touchState = state == SelectionState.Pressed ? YLabel.LabelTouchState.Pressed : YLabel.LabelTouchState.Normal;
            }
        }

        private LuaTable m_LuaTable;
        private LuaTable m_LuaArgs;
        private Action<LuaTable, YSelectable, LuaTable> m_LuaClickHandler;

        public void SetClickHandler(LuaTable lua, Action<LuaTable, YSelectable, LuaTable> handler)
        {
            SetClickHandler(lua, handler, null);
        }

        public void SetClickHandler(LuaTable lua, Action<LuaTable, YSelectable, LuaTable> handler, LuaTable args)
        {
            m_LuaTable = lua;
            m_LuaArgs = args;
            m_LuaClickHandler = handler;
        }

        public override void ClearLuaHandler()
        {
            m_LuaArgs = m_LuaTable = null;
            m_LuaClickHandler = null;
        }
     
    }
}
