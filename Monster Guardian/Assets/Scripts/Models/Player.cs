using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static ControlManager;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour, ISelectionActions, IRestoration
    {
        public GameObject creatureprefab;

        public List<GameObject> selectedUnits = new List<GameObject>();
        private GameObject[] allFriendlys;

        private Rect drawnRect;

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
                return Camera.main.GetWorldPOS(startScreenMousePOS);
            }
        }

        public Vector3 worldMousePOS
        {
            get
            {
                return Camera.main.GetWorldPOS(screenMousePOS);
            }
        }

        private bool isClicking { get; set; } = false;

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
                HandleSelectionCommand();
            }
        }

        private void HandleSelectionCommand()
        {
            if (isClicking)
            {
                isClicking = false;
                MouseRelease();
            }
        }

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
                    item.GetComponent<Creature>().AssignLocation(worldMousePOS);
                }
            }
        }

        public void OnStartSelection(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                if (!mousePosition.IsPointerOverUIObject()) // if not clicking UI
                {
                    isClicking = true;
                    selectedUnits.Clear(); // Clear the list with selected unit
                    startScreenMousePOS = new Vector3(screenMousePOS.x, screenMousePOS.y, screenMousePOS.z);
                }
            }
        }

        public void Save()
        {
            Creature[] allObjects = FindObjectsOfType<Creature>();
            List<BlueprintCreature> allBlueprints = allObjects.Select(p => p.SaveState()).ToList();
            FileConstants.SaveFile.SaveJson(allBlueprints.ToJson(true));
        }

        public void Load()
        {
            // Destory old creatures
            Creature[] allCreatures = FindObjectsOfType<Creature>();
            foreach (Creature gme in allCreatures)
            {
                Destroy(gme);
            }

            // Load from file
            Creature[] savedCreatures = FileConstants.SaveFile.LoadJson<Creature[]>();

            // Instantiate and load new creatures
            foreach (Creature hobbit in savedCreatures)
            {
                Instantiate(hobbit);
            }
        }

        [Obsolete]
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

        /// <summary>
        /// Checks to see if the object is inside of our drawn rect
        /// This will be based on the objects PIVOT POINT
        /// </summary>
        /// <param name="currentUnit"></param>
        /// <returns></returns>
        private bool IsWinner(GameObject currentUnit)
        {
            Vector2 space = Camera.main.ConvertToScreen(currentUnit.transform.position); // for this I think the rectangle contains checks something wrong(?) so it needs to be converted
            return drawnRect.Contains(space);
        }

        private void MouseRelease()
        {
            foreach (GameObject unit in allFriendlys) // Select all units within the square if we have created a square
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
        }

        private void OnEnable()
        {
            playerControls.Selection.StartSelection.Enable();
            playerControls.Selection.ContinueSelection.Enable();
            playerControls.Selection.EndSelection.Enable();
            playerControls.Selection.MousePosition.Enable();
            playerControls.Selection.MoveSelection.Enable();
        }

        // Display the selection with a GUI image
        private void OnGUI()
        {
            if (isClicking)
            {
                drawnRect = GraphicsController.DrawRectangle(startScreenMousePOS, screenMousePOS);
            }
        }

        private void Update()
        {
            allFriendlys = GameObject.FindGameObjectsWithTag(TeamStatus.Friendly.ToString()); // done every update to include constructed objects
        }
    }
}