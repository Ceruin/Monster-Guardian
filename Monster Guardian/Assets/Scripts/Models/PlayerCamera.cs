using UnityEngine;
using UnityEngine.InputSystem;
using static ControlManager;

namespace Assets.Scripts
{
    /// <summary>
    /// This is the player camera class which maps the player controls to camera actions and sets up some camera basic properties.
    /// </summary>
    public class PlayerCamera : MonoBehaviour, ICameraMovementActions
    {
        public int moveSpeed = 5; // default
        private Vector2 move = Vector2.zero;
        private ControlManager playerControls;

        /// <summary>
        /// When a movement key WASD is hit fire commands
        /// </summary>
        /// <param name="context"></param>
        public void OnMovement(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                move = context.ReadValue<Vector2>();
            }
            else
            {
                move = Vector2.zero;
            }
        }

        private void Awake()
        {
            playerControls = new ControlManager();
            playerControls.CameraMovement.SetCallbacks(this);
        }

        private void FixedUpdate()
        {
            Camera.main.transform.position += new Vector3(move.x, 0, move.y) * Time.deltaTime * moveSpeed;
        }

        private void OnDisable()
        {
            playerControls.CameraMovement.Movement.Disable();
        }

        private void OnEnable()
        {
            playerControls.CameraMovement.Movement.Enable();
        }
    }
}