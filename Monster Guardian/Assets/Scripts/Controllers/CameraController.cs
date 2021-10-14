using UnityEngine;
using UnityEngine.InputSystem;
using static ControlManager;

public class CameraController : MonoBehaviour, ICameraMovementActions
{
    private ControlManager playerControls;
    private Vector2 move = Vector2.zero;
    public int moveSpeed = 5;

    public void OnMovement(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Movement: " + context.ReadValue<Vector2>());
            move = context.ReadValue<Vector2>();
        }
        else
        {
            move = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        Debug.Log(move);
        Camera.main.transform.position += new Vector3(move.x, 0, move.y) * Time.deltaTime * moveSpeed;
    }

    private void Awake()
    {
        playerControls = new ControlManager();
        playerControls.CameraMovement.SetCallbacks(this);
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