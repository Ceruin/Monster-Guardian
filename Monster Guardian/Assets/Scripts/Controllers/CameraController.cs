using UnityEngine;
using UnityEngine.InputSystem;
using static ControlManager;

public class CameraController : MonoBehaviour, ICameraMovementActions
{
    private ControlManager playerControls;

    public void OnMovement(InputAction.CallbackContext context)
    {
        Debug.Log("Movement: " + context.ReadValue<Vector2>());
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
    // Update is called once per frame
    private void Update()
    {
    }
}