using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using static ControlManager;

public class SelectionController : MonoBehaviour, ISelectionActions
{
    [System.NonSerialized]
    public List<GameObject> selectedUnits = new List<GameObject>();

    private GameObject[] allUnits;

    private Rect drawnRect;

    private bool isClicking { get; set; } = false;
    private Vector2 mousePosition;

    private ControlManager playerControls;

    public Vector3 screenMousePOS
    {
        get
        {
            return mousePosition;
        }
    }

    public Vector3 startScreenMousePOS { get; set; }

    public Vector3 startScreenWorldPOS
    {
        get
        {
            Ray ray = Camera.main.ScreenPointToRay(startScreenMousePOS);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            return hit.point;
        }
    }

    public Vector3 worldMousePOS
    {
        get
        {
            Ray ray = Camera.main.ScreenPointToRay(screenMousePOS);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            return hit.point;
        }
    }

    public void OnContinueSelection(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
        }
    }

    public void OnEndSelection(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isClicking = false;
            MouseRelease();
        }
    }

    //FileUtils.Save("test", FileUtils.ToJson(selectedUnits.ToArray(), true));

    // the constant mouse postion in screen pos
    public void OnMousePosition(InputAction.CallbackContext context)
    {
        mousePosition = context.ReadValue<Vector2>();
    }

    public void OnMoveSelection(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            foreach (var item in selectedUnits)
            {
                item.GetComponent<NavMeshAgent>().Path(worldMousePOS);
            }
        }
    }

    public void OnStartSelection(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isClicking = true;
            startScreenMousePOS = new Vector3(screenMousePOS.x, screenMousePOS.y, screenMousePOS.z);
            selectedUnits.Clear(); // Clear the list with selected unit
        }
    }

    public void OnTestSuper(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
        }
    }

    private void Awake()
    {
        playerControls = new ControlManager();
        playerControls.Selection.SetCallbacks(this);
    }

    private void DrawRectangle()
    {
        drawnRect = GraphicsUtils.GetScreenRect(startScreenMousePOS, screenMousePOS);
        GraphicsUtils.DrawScreenRect(drawnRect, new Color(0.8f, 0.8f, 0.95f, 0.25f));
        GraphicsUtils.DrawScreenRectBorder(drawnRect, 2, new Color(0.8f, 0.8f, 0.95f));
    }

    private bool IsWinner(GameObject currentUnit)
    {
        Vector2 space = Camera.main.ConvertToScreen(currentUnit.transform.position);
        return drawnRect.Contains(space);
    }

    // Select all units within the square if we have created a square
    private void MouseRelease()
    {
        foreach (GameObject unit in allUnits)
        {
            if (IsWinner(unit)) // Is this unit within the square
            {
                selectedUnits.Add(unit);
            }
        }
    }

    private void OnDisable()
    {
        playerControls.Selection.StartSelection.Disable();
        playerControls.Selection.ContinueSelection.Disable();
        playerControls.Selection.EndSelection.Disable();
        playerControls.Selection.MousePosition.Disable();
        playerControls.Selection.MoveSelection.Disable();
        playerControls.Selection.TestSuper.Disable();
    }

    private void OnEnable()
    {
        playerControls.Selection.StartSelection.Enable();
        playerControls.Selection.ContinueSelection.Enable();
        playerControls.Selection.EndSelection.Enable();
        playerControls.Selection.MousePosition.Enable();
        playerControls.Selection.MoveSelection.Enable();
        playerControls.Selection.TestSuper.Enable();
    }

    // Display the selection with a GUI image
    private void OnGUI()
    {
        if (isClicking)
        {
            DrawRectangle();
        }
    }

    private void Start()
    {
    }

    private void Update()
    {
        allUnits = GameObject.FindGameObjectsWithTag("Friendly"); // done every update to include constructed enemies
    }
}