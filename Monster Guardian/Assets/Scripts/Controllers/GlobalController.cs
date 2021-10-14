using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static ControlManager;

public class GlobalController : MonoBehaviour, ISelectionActions
{
    private bool dragSelect = false; // internal switch to tell if were selecting
    private Rect drawnRect; // the rectangle selection
    private Vector2 mousePosition; // the constant mouse postion in screen pos

    private ControlManager playerControls;
    private SelectedAlliesModel selected_table;

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
    }

    public void OnEndSelection(InputAction.CallbackContext context)
    {
        //Debug.Log(nameof(OnEndSelection));
        if (context.performed)
        {
            //dragSelect = false;

            //GetSelectedObjects();
        }
    }

    public void OnMousePosition(InputAction.CallbackContext context)
    {
        //Debug.Log(nameof(OnMousePosition));
        //mousePosition = context.ReadValue<Vector2>();
        //Debug.Log($"Screen Mouse POS {screenMousePOS}");
        //Debug.Log($"World Mouse POS {worldMousePOS}");
    }

    public void OnMoveSelection(InputAction.CallbackContext context)
    {
        //Debug.Log(nameof(OnMoveSelection));
        if (context.performed)
        {
            //if (!dragSelect)
            //{
            //    foreach (var item in selected_table.SelectedTable)
            //    {
            //        item.Value.GetComponent<PathingController>().MoveToLocation(worldMousePOS);
            //        //Debug.Log($"Try Move: {worldMousePOS}");
            //    }
            //}
        }
    }

    public void OnStartSelection(InputAction.CallbackContext context)
    {
        // Debug.Log(nameof(OnStartSelection));
        if (context.performed)
        {
            //startScreenMousePOS = new Vector3(screenMousePOS.x, screenMousePOS.y, screenMousePOS.z);
            //dragSelect = true;
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
        //if (dragSelect)
        //{
        //    drawnRect = GraphicsUtils.GetScreenRect(startScreenMousePOS, screenMousePOS);
        //    GraphicsUtils.DrawScreenRect(drawnRect, new Color(0.8f, 0.8f, 0.95f, 0.25f));
        //    GraphicsUtils.DrawScreenRectBorder(drawnRect, 2, new Color(0.8f, 0.8f, 0.95f));
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        //selected_table.AddSelection(other.gameObject);
    }

    // Start is called before the first frame update
    private void Start()
    {
        //selected_table = GetComponent<SelectedAlliesModel>();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    [Obsolete("Remove")]
    public void LegacyCode()
    {
        //Ray ray = Camera.main.ScreenPointToRay(mouseSelectStartPOS);

        //RaycastHit hit;
        //if (Physics.Raycast(ray, out hit, 50000.0f))
        //{
        //    selected_table.deselectAll();
        //    selected_table.addSelected(hit.transform.gameObject);
        //}
        //else //if we didnt hit something
        //{
        //    selected_table.deselectAll();
        //}

        //projectedMousePOS = projectedMousePOS;
        //Vector2[] corners = Utils.GetBoundingBox(mouseSelectStartPOS, projectedMousePOS);
    }

    [Obsolete("Fix")]
    private void SelectOverlapUnits()
    {
        Vector3 min = Vector3.zero;
        Vector3 center = Vector3.zero;
        Vector3 max = Vector3.zero;

        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(new Vector3(drawnRect.position.x - drawnRect.width / 2f, drawnRect.position.y - drawnRect.height / 2f) + Camera.main.transform.position), out hit)) min = hit.point;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(new Vector3(drawnRect.position.x + drawnRect.width / 2f, drawnRect.position.y + drawnRect.height / 2f) + Camera.main.transform.position), out hit)) max = hit.point;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(new Vector3(drawnRect.position.x, drawnRect.position.y) + Camera.main.transform.position), out hit)) center = hit.point;

        Collider[] units = Physics.OverlapBox(center, (max - min) / 2f, Quaternion.identity);
        Debug.Log(units.Length);
    }

    [Obsolete("Bad Code")]
    //create a bounding box (4 corners in order) from the start and end mouse position
    private Vector2[] GenBoundingBox(Vector2 p1, Vector2 p2)
    {
        Vector2 newP1;
        Vector2 newP2;
        Vector2 newP3;
        Vector2 newP4;

        if (p1.x < p2.x) //if p1 is to the left of p2
        {
            if (p1.y > p2.y) // if p1 is above p2
            {
                newP1 = p1;
                newP2 = new Vector2(p2.x, p1.y);
                newP3 = new Vector2(p1.x, p2.y);
                newP4 = p2;
            }
            else //if p1 is below p2
            {
                newP1 = new Vector2(p1.x, p2.y);
                newP2 = p2;
                newP3 = p1;
                newP4 = new Vector2(p2.x, p1.y);
            }
        }
        else //if p1 is to the right of p2
        {
            if (p1.y > p2.y) // if p1 is above p2
            {
                newP1 = new Vector2(p2.x, p1.y);
                newP2 = p1;
                newP3 = p2;
                newP4 = new Vector2(p1.x, p2.y);
            }
            else //if p1 is below p2
            {
                newP1 = p2;
                newP2 = new Vector2(p1.x, p2.y);
                newP3 = new Vector2(p2.x, p1.y);
                newP4 = p1;
            }
        }

        Vector2[] corners = { newP1, newP2, newP3, newP4 };
        return corners;
    }

    [Obsolete("Bad Code")]
    //generate a mesh from the 4 bottom points
    private Mesh GenSelectionMesh(Vector3[] corners, Vector3[] vecs)
    {
        Vector3[] verts = new Vector3[8];
        int[] tris = { 0, 1, 2, 2, 1, 3, 4, 6, 0, 0, 6, 2, 6, 7, 2, 2, 7, 3, 7, 5, 3, 3, 5, 1, 5, 0, 1, 1, 4, 0, 4, 5, 6, 6, 5, 7 }; //map the tris of our cube

        for (int i = 0; i < 4; i++)
        {
            verts[i] = corners[i];
        }

        for (int j = 4; j < 8; j++)
        {
            verts[j] = corners[j - 4] + vecs[j - 4];
        }

        Mesh selectionMesh = new Mesh();
        selectionMesh.vertices = verts;
        selectionMesh.triangles = tris;

        return selectionMesh;
    }

    [Obsolete("Bad Code")]
    /// <summary>
    /// Get all game objects within a selected rectangle to be commanded
    /// </summary>
    private void GetSelectedObjects()
    {
        var verts = new Vector3[4];
        var vecs = new Vector3[4];
        int i = 0;
        var corners = GenBoundingBox(startScreenMousePOS, screenMousePOS);
        Debug.Log("Start: " + startScreenMousePOS);
        Debug.Log("End: " + screenMousePOS);
        MeshCollider selectionBox;

        foreach (Vector2 corner in corners)
        {
            Ray ray = Camera.main.ScreenPointToRay(corner);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 50000.0f))
            {
                verts[i] = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                vecs[i] = ray.origin - hit.point;
                Debug.DrawLine(Camera.main.ScreenToWorldPoint(corner), hit.point, Color.red, 1.0f);
            }
            i++;
        }

        selectionBox = gameObject.AddComponent<MeshCollider>();
        selectionBox.sharedMesh = GenSelectionMesh(verts, vecs);
        selectionBox.convex = true;

        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("Enemy"); // todo: refactor code
        selected_table.DeselectAll();
        foreach (var enemy in allObjects)
        {
            //Vector3 pos = Camera.main.WorldToScreenPoint(enemy.transform.position);
            //Debug.Log($"Enemy Screen Space: {pos}");
            //Debug.Log($"Rectangle: {drawnRect}");
            //Debug.DrawLine(startScreenMousePOS, enemy.transform.position, Color.red, 10, false);
            Debug.Log("Collider bound Minimum : " + selectionBox.sharedMesh.bounds.min);
            Debug.Log("Collider bound Maximum : " + selectionBox.sharedMesh.bounds.max);
            Debug.Log("Enemy POS: " + enemy.transform.position);
            if (selectionBox.sharedMesh.bounds.Contains(enemy.transform.position))
            {
                Debug.Log($"Selected Enemy: {enemy}");
                selected_table.AddSelection(enemy);
            }
        }

        //Destroy(selectionBox, 0.02f);
    }
}