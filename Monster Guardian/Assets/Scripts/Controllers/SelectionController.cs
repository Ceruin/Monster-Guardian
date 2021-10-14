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

    //The selection square we draw when we drag the mouse to select units
    public RectTransform selectionSquareTrans;

    //To test the square's corners
    public Transform sphere1;

    public Transform sphere2;

    public Transform sphere3;

    public Transform sphere4;

    //If it was possible to create a square
    private bool hasCreatedSquare;

    //We have hovered above this unit, so we can deselect it next update
    //and dont have to loop through all units
    private GameObject highlightThisUnit;

    private Vector2 mousePosition;

    private ControlManager playerControls;

    //The start and end coordinates of the square we are making
    private Vector3 squareStartPos;

    //The selection squares 4 corner positions
    private Vector3 TL, TR, BL, BR;

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
        }
    }

    private bool isClicking = false;
    private bool isHoldingDown = false;

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
            MouseClick();
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

    //Display the selection with a GUI square
    private void DisplaySquare()
    {
        //The start position of the square is in 3d space, or the first coordinate will move
        //as we move the camera which is not what we want
        Vector3 squareStartScreen = Camera.main.WorldToScreenPoint(startScreenWorldPOS);

        squareStartScreen.z = 0f;

        //Get the middle position of the square
        Vector3 middle = (squareStartScreen + screenMousePOS) / 2f;

        //Set the middle position of the GUI square
        //drawnRect.position = middle;

        //Change the size of the square
        float sizeX = Mathf.Abs(squareStartScreen.x - screenMousePOS.x);
        float sizeY = Mathf.Abs(squareStartScreen.y - screenMousePOS.y);

        //Set the size of the square
        //drawnRect.size = new Vector2(sizeX, sizeY);

        SetupSquarePOS(middle, sizeX, sizeY);
    }

    private void SetupSquarePOS(Vector3 middle, float sizeX, float sizeY)
    {
        //The problem is that the corners in the 2d square is not the same as in 3d space
        //To get corners, we have to fire a ray from the screen
        //We have 2 of the corner positions, but we don't know which,
        //so we can figure it out or fire 4 raycasts
        TL = new Vector3(middle.x - sizeX / 2f, middle.y + sizeY / 2f, 0f);
        TR = new Vector3(middle.x + sizeX / 2f, middle.y + sizeY / 2f, 0f);
        BL = new Vector3(middle.x - sizeX / 2f, middle.y - sizeY / 2f, 0f);
        BR = new Vector3(middle.x + sizeX / 2f, middle.y - sizeY / 2f, 0f);

        //From screen to world
        RaycastHit hit;
        int i = 0;
        //Fire ray from camera
        if (Physics.Raycast(Camera.main.ScreenPointToRay(TL), out hit, 200f, 1 << 8))
        {
            TL = hit.point;
            i++;
        }
        if (Physics.Raycast(Camera.main.ScreenPointToRay(TR), out hit, 200f, 1 << 8))
        {
            TR = hit.point;
            i++;
        }
        if (Physics.Raycast(Camera.main.ScreenPointToRay(BL), out hit, 200f, 1 << 8))
        {
            BL = hit.point;
            i++;
        }
        if (Physics.Raycast(Camera.main.ScreenPointToRay(BR), out hit, 200f, 1 << 8))
        {
            BR = hit.point;
            i++;
        }

        //Could we create a square?
        hasCreatedSquare = false;

        //We could find 4 points
        if (i == 4)
        {
            //Display the corners for debug
            //sphere1.position = TL;
            //sphere2.position = TR;
            //sphere3.position = BL;
            //sphere4.position = BR;

            hasCreatedSquare = true;
        }
    }
    private Rect drawnRect; // the rectangle selection
    private void OnGUI()
    {
        //Display the selection with a GUI image
        if (isClicking) {
            drawnRect = GraphicsUtils.GetScreenRect(startScreenMousePOS, screenMousePOS);
            GraphicsUtils.DrawScreenRect(drawnRect, new Color(0.8f, 0.8f, 0.95f, 0.25f));
            GraphicsUtils.DrawScreenRectBorder(drawnRect, 2, new Color(0.8f, 0.8f, 0.95f));
            DisplaySquare();
        }
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

    //Is a unit within a polygon determined by 4 corners
    private bool IsWithinPolygon(Vector3 unitPos)
    {
        bool isWithinPolygon = false;

        //The polygon forms 2 triangles, so we need to check if a point is within any of the triangles
        //Triangle 1: TL - BL - TR
        if (IsWithinTriangle(unitPos, TL, BL, TR))
        {
            return true;
        }

        //Triangle 2: TR - BL - BR
        if (IsWithinTriangle(unitPos, TR, BL, BR))
        {
            return true;
        }

        return isWithinPolygon;
    }

    //Is a point within a triangle
    //From http://totologic.blogspot.se/2014/01/accurate-point-in-triangle-test.html
    private bool IsWithinTriangle(Vector3 p, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        bool isWithinTriangle = false;

        //Need to set z -> y because of other coordinate system
        float denominator = ((p2.z - p3.z) * (p1.x - p3.x) + (p3.x - p2.x) * (p1.z - p3.z));

        float a = ((p2.z - p3.z) * (p.x - p3.x) + (p3.x - p2.x) * (p.z - p3.z)) / denominator;
        float b = ((p3.z - p1.z) * (p.x - p3.x) + (p1.x - p3.x) * (p.z - p3.z)) / denominator;
        float c = 1 - a - b;

        //The point is within the triangle if 0 <= a <= 1 and 0 <= b <= 1 and 0 <= c <= 1
        if (a >= 0f && a <= 1f && b >= 0f && b <= 1f && c >= 0f && c <= 1f)
        {
            isWithinTriangle = true;
        }

        return isWithinTriangle;
    }

    private void MouseClick()
    {
        //We dont yet know if we are drawing a square, but we need the first coordinate in case we do draw a square
        RaycastHit hit;
        //Fire ray from camera
        if (Physics.Raycast(Camera.main.ScreenPointToRay(mousePosition), out hit, 200f, 1 << 8))
        {
            //The corner position of the square
            squareStartPos = hit.point;
        }
    }

    private void MouseRelease()
    {
        //Select all units within the square if we have created a square
        //Deactivate the square selection image
        selectionSquareTrans.gameObject.SetActive(false);

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

    private void MultiSelect()
    {
        //Drag the mouse to select all units within the square
        if (isHoldingDown)
        {
            //Activate the square selection image
            if (!selectionSquareTrans.gameObject.activeInHierarchy)
            {
                selectionSquareTrans.gameObject.SetActive(true);
            }

            //Highlight the units within the selection square, but don't select the units
            for (int i = 0; i < allUnits.Length; i++)
            {
                GameObject currentUnit = allUnits[i];

                //Is this unit within the square
                if (IsWithinPolygon(currentUnit.transform.position))
                {
                    currentUnit.GetComponent<MeshRenderer>().material = highlightMaterial;
                }
                //Otherwise deactivate
                else
                {
                    currentUnit.GetComponent<MeshRenderer>().material = normalMaterial;
                }
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

    //Select units with click or by draging the mouse
    private void SelectUnits()
    {
        MultiSelect();
    }

    private void SingleSelect()
    {
        //Select one unit with left mouse and deselect all units with left mouse by clicking on what's not a unit
        if (isClicking)
        {
            //Deselect all units
            for (int i = 0; i < selectedUnits.Count; i++)
            {
                selectedUnits[i].GetComponent<MeshRenderer>().material = normalMaterial;
            }

            //Clear the list with selected units
            selectedUnits.Clear();

            //Try to select a new unit
            RaycastHit hit;
            //Fire ray from camera
            if (Physics.Raycast(Camera.main.ScreenPointToRay(mousePosition), out hit, 200f))
            {
                //Did we hit a friendly unit?
                if (hit.collider.CompareTag("Friendly"))
                {
                    GameObject activeUnit = hit.collider.gameObject;
                    //Set this unit to selected
                    activeUnit.GetComponent<MeshRenderer>().material = selectedMaterial;
                    //Add it to the list of selected units, which is now just 1 unit
                    selectedUnits.Add(activeUnit);
                }
            }
        }
    }

    private void Start()
    {
        //Deactivate the square selection image
        selectionSquareTrans.gameObject.SetActive(false);
    }

    private void Update()
    {
        allUnits = GameObject.FindGameObjectsWithTag("Friendly");

        //Select one or several units by clicking or draging the mouse
        SelectUnits();

        //Highlight by hovering with mouse above a unit which is not selected
        HighlightUnit();
    }
}