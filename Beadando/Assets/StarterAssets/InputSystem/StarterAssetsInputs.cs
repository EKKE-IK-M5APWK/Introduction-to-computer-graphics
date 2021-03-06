using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
    public class StarterAssetsInputs : MonoBehaviour
    {
        [Header("Character Input Values")]
        public Vector2 move;
        public Vector2 look;
        public bool jump;
        public bool sprint;
        public bool zoom;
        public bool shoot;
        public bool red;
        public bool blue;
        public bool green;
        public bool yellow;

        [Header("Movement Settings")]
        public bool analogMovement;

#if !UNITY_IOS || !UNITY_ANDROID
        [Header("Mouse Cursor Settings")]
        public bool cursorLocked = true;
        public bool cursorInputForLook = true;
#endif

#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
        public void OnMove(InputValue value)
        {
            MoveInput(value.Get<Vector2>());
        }

        public void OnLook(InputValue value)
        {
            if (cursorInputForLook)
            {
                LookInput(value.Get<Vector2>());
            }
        }

        public void OnJump(InputValue value)
        {
            JumpInput(value.isPressed);
        }

        public void OnSprint(InputValue value)
        {
            SprintInput(value.isPressed);
        }
        public void OnZoom(InputValue value)
        {
            ZoomInput(value.isPressed);
        }
        public void OnShoot(InputValue value)
        {
            ShootInput(value.isPressed);
        }
        public void OnRed(InputValue value)
        {
            RedInput(value.isPressed);
        }
        public void OnBlue(InputValue value)
        {
            BlueInput(value.isPressed);
        }
        public void OnGreen(InputValue value)
        {
            GreenInput(value.isPressed);
        }
        public void OnYellow(InputValue value)
        {
            YellowInput(value.isPressed);
        }
#else
	// old input sys if we do decide to have it (most likely wont)...
#endif


        public void MoveInput(Vector2 newMoveDirection)
        {
            move = newMoveDirection;
        }

        public void LookInput(Vector2 newLookDirection)
        {
            look = newLookDirection;
        }

        public void JumpInput(bool newJumpState)
        {
            jump = newJumpState;
        }

        public void SprintInput(bool newSprintState)
        {
            sprint = newSprintState;
        }

        public void ZoomInput(bool newZoomState)
        {
            zoom = newZoomState;
        }
        public void ShootInput(bool newShootState)
        {
            shoot = newShootState;
        }
        public void RedInput(bool newRedState)
        {
            red = newRedState;
        }

        public void BlueInput(bool newBlueState)
        {
            blue = newBlueState;
        }

        public void GreenInput(bool newGreenState)
        {
            green = newGreenState;
        }

        public void YellowInput(bool newYellowState)
        {
            yellow = newYellowState;
        }


#if !UNITY_IOS || !UNITY_ANDROID

        private void OnApplicationFocus(bool hasFocus)
        {
            SetCursorState(cursorLocked);
        }

        private void SetCursorState(bool newState)
        {
            Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
        }

#endif

    }

}