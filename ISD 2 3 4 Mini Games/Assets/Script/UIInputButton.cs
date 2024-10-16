using System;
using System.Collections;
using UI_Inputs.Tools;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Script
{
    public class UIInputButton : UIInput<ButtonAction, bool>,
        IPointerDownHandler, IPointerUpHandler
    {
        [Header("---------Button Type---------------")] [SerializeField]
        private ButtonType buttonType = ButtonType.Click;

        [Header("---------Button Action-------------")] [SerializeField]
        private ButtonAction buttonAction = ButtonAction.Player1Fire;

        private bool isPressing;

        public override bool InputDefaultValue => false;
        public override bool InputValue => isPressing;
        public override ButtonAction InputID => buttonAction;

        private void OnDisable()
        {
            isPressing = false;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            ProcessClick();
            OnTouch?.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            ProcessClick(false);
            OnClick?.Invoke();
        }

        public event Action OnClick;
        public event Action OnTouch;

        private void ProcessClick(bool pressing = true)
        {
            switch (buttonType)
            {
                case ButtonType.Touch when pressing:
                    StartCoroutine(MakeAFrameClick());
                    break;
                case ButtonType.Hold:
                    isPressing = !isPressing;
                    break;
                case ButtonType.Click when !pressing:
                    StartCoroutine(MakeAFrameClick());
                    break;
            }
        }

        private IEnumerator MakeAFrameClick()
        {
            isPressing = true;
            yield return new WaitForFixedUpdate();
            isPressing = false;
        }

        private enum ButtonType
        {
            Click,
            Touch,
            Hold
        }
    }
}