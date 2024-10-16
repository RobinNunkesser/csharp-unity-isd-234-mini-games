using UI_Inputs.Tools;
using UnityEngine;

namespace Script
{
    public class UIInputJoystick : UIInput<JoyStickAction, Vector2>
    {
        [Header("---------Joystick Action-----------")] [SerializeField]
        private JoyStickAction joystickAction = JoyStickAction.Movement;

        private Joystick joystick;

        public override JoyStickAction InputID => joystickAction;
        public override Vector2 InputValue => JoystickDirection();
        public override Vector2 InputDefaultValue => Vector2.zero;

        private void Awake()
        {
            GetJoystick();
        }

        private void OnDisable()
        {
            if (joystick != null)
                joystick.ResetJoystick();
        }

        private void GetJoystick()
        {
            joystick = GetComponent<Joystick>();

            if (joystick == null)
                Debug.LogError(
                    $"Couldn't find a joystick in: {gameObject.name}");
        }

        private Vector2 JoystickDirection()
        {
            return joystick == null ? Vector2.zero : joystick.Direction;
        }
    }
}