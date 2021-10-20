using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static ControlManager;

public class SelectionController : MonoBehaviour, ISelectionActions
{
    //Add all units in the scene to this array
    public GameObject[] allUnits;

    public Material highlightMaterial;

    //The materials
    public Material normalMaterial;

    public Material selectedMaterial;

    //All currently selected units
    [System.NonSerialized]
    public List<GameObject> selectedUnits = new List<GameObject>();

    private Rect drawnRect;

    //If it was possible to create a square
    private bool hasCreatedSquare;

    //We have hovered above this unit, so we can deselect it next update
    //and dont have to loop through all units
    private GameObject highlightThisUnit;

    private bool isClicking = false;
    private bool isHoldingDown = false;
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
            isHoldingDown = true;
        }
    }

    public void OnEndSelection(InputAction.CallbackContext context)
    {
        //Debug.Log(nameof(OnEndSelection));
        if (context.performed)
        {
            //Are we clicking with left mouse or holding down left mouse
            //SingleSelect();
            isClicking = false;
            isHoldingDown = false;

            MouseRelease();

            if (selectedUnits.Count > 0)
            {
                FileUtils.Save("test", FileUtils.ToJson<GameObject>(selectedUnits.ToArray(), true));
            }
        }
    }

    // the constant mouse postion in screen pos
    public void OnMousePosition(InputAction.CallbackContext context)
    {
        //Debug.Log(nameof(OnMousePosition));
        mousePosition = context.ReadValue<Vector2>();
        //Debug.Log($"Screen Mouse POS {screenMousePOS}");
        //Debug.Log($"World Mouse POS {worldMousePOS}");
    }

    public void OnMoveSelection(InputAction.CallbackContext context)
    {
        //Debug.Log(nameof(OnMoveSelection));
        if (context.performed)
        {
            foreach (var item in selectedUnits)
            {
                item.GetComponent<PathingController>().MoveToLocation(worldMousePOS);
                //Debug.Log($"Try Move: {worldMousePOS}");
            }
        }
    }

    public void OnStartSelection(InputAction.CallbackContext context)
    {
        // Debug.Log(nameof(OnStartSelection));
        if (context.performed)
        {
            startScreenMousePOS = new Vector3(screenMousePOS.x, screenMousePOS.y, screenMousePOS.z);
            isClicking = true;
        }
    }

    public void OnTestSuper(InputAction.CallbackContext context)
    {
        //Debug.Log(nameof(OnTestSuper));
        if (context.performed)
        {
        }
    }

    private void Awake()
    {
        playerControls = new ControlManager();
        playerControls.Selection.SetCallbacks(this);
    }

    //Highlight a unit when mouse is above it
    private void HighlightUnit()
    {
        //Change material on the latest unit we highlighted
        if (highlightThisUnit != null)
        {
            //But make sure the unit we want to change material on is not selected
            bool isSelected = false;
            for (int i = 0; i < selectedUnits.Count; i++)
            {
                if (selectedUnits[i] == highlightThisUnit)
                {
                    isSelected = true;
                    break;
                }
            }

            if (!isSelected)
            {
                highlightThisUnit.GetComponent<MeshRenderer>().material = normalMaterial;
            }

            highlightThisUnit = null;
        }

        //Fire a ray from the mouse position to get the unit we want to highlight
        RaycastHit hit;
        //Fire ray from camera
        if (Physics.Raycast(Camera.main.ScreenPointToRay(mousePosition), out hit, 200f))
        {
            //Did we hit a friendly unit?
            if (hit.collider.CompareTag("Friendly"))
            {
                //Get the object we hit
                GameObject currentObj = hit.collider.gameObject;

                //Highlight this unit if it's not selected
                bool isSelected = false;
                for (int i = 0; i < selectedUnits.Count; i++)
                {
                    if (selectedUnits[i] == currentObj)
                    {
                        isSelected = true;
                        break;
                    }
                }

                if (!isSelected)
                {
                    highlightThisUnit = currentObj;

                    highlightThisUnit.GetComponent<MeshRenderer>().material = highlightMaterial;
                }
            }
        }
    }

    private void MouseRelease()
    {
        //Select all units within the square if we have created a square

        //Clear the list with selected unit
        selectedUnits.Clear();

        //Select the units
        for (int i = 0; i < allUnits.Length; i++)
        {
            GameObject currentUnit = allUnits[i];
            Vector2 space = Camera.main.ConvertToScreen(currentUnit.transform.position);
            Debug.Log("Space: " + space);
            bool winner = drawnRect.Contains(space);
            Debug.Log("Rect:" + drawnRect);

            //Is this unit within the square
            if (winner)
            {
                currentUnit.GetComponent<MeshRenderer>().material = selectedMaterial;

                selectedUnits.Add(currentUnit);
            }
            //Otherwise deselect the unit if it's not in the square
            else
            {
                currentUnit.GetComponent<MeshRenderer>().material = normalMaterial;
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

    private void OnGUI()
    {
        //Display the selection with a GUI image
        if (isClicking)
        {
            drawnRect = GraphicsUtils.GetScreenRect(startScreenMousePOS, screenMousePOS);
            GraphicsUtils.DrawScreenRect(drawnRect, new Color(0.8f, 0.8f, 0.95f, 0.25f));
            GraphicsUtils.DrawScreenRectBorder(drawnRect, 2, new Color(0.8f, 0.8f, 0.95f));
        }
    }

    private void Start()
    {
    }

    private void Update()
    {
        allUnits = GameObject.FindGameObjectsWithTag("Friendly"); // done every update to include constructed enemies

        //Highlight by hovering with mouse above a unit which is not selected
        HighlightUnit();
    }
}