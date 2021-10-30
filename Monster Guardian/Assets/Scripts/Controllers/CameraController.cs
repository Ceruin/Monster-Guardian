using UnityEngine;
using UnityEngine.InputSystem;
using static ControlManager;

public class CameraController : MonoBehaviour, ICameraMovementActions
{
    public int moveSpeed = 5;
    private Vector2 move = Vector2.zero;
    private ControlManager playerControls;
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