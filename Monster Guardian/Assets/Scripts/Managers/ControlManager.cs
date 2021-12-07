// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Managers/ControlManager.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @ControlManager : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @ControlManager()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ControlManager"",
    ""maps"": [
        {
            ""name"": ""Camera Movement"",
            ""id"": ""debb6a51-f32a-4230-a15a-030b840c060c"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Button"",
                    ""id"": ""9010d893-dc2a-4afe-a28f-33424ce397fc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""fa512ff2-bccf-46b5-b12b-f336bc8e16d8"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""68141a17-0908-4f2a-972d-0fe7bfa908a1"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b9a40806-2700-45ce-ab5d-a4f75cf00f35"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""eb9b5257-4f25-420b-9b24-a06d785d3635"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""1cdc2af8-e66d-445b-a8a3-5f41064d6972"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Selection"",
            ""id"": ""df7ba2d9-0b31-472c-9cfe-cfae8cae445c"",
            ""actions"": [
                {
                    ""name"": ""Start Selection"",
                    ""type"": ""Button"",
                    ""id"": ""33888605-557f-451a-9498-113dcbd5baff"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Continue Selection"",
                    ""type"": ""Button"",
                    ""id"": ""24608127-1f32-481d-8a0c-1bf986178f19"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""End Selection"",
                    ""type"": ""Button"",
                    ""id"": ""d1c383b8-b65e-44dc-8460-eafd2c7793c3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Mouse Position"",
                    ""type"": ""Value"",
                    ""id"": ""1c747ae8-f113-4fed-a556-2cfc9b2eb0eb"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move Selection"",
                    ""type"": ""Button"",
                    ""id"": ""1660cbcb-7caa-4842-82b7-f4e0c5d36073"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2767c4b6-4077-4262-80ef-0053db31f5e7"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""End Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""21072b34-93d7-4de2-946f-e796ab356fa0"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouse Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""122233ce-c963-4a0e-8849-f4327206113c"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Continue Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9bb3cfc7-a5f1-46c7-ad94-891ad1007b8c"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Start Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eeb46380-76f8-4a8d-8720-6c9cb80e1618"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Camera Movement
        m_CameraMovement = asset.FindActionMap("Camera Movement", throwIfNotFound: true);
        m_CameraMovement_Movement = m_CameraMovement.FindAction("Movement", throwIfNotFound: true);
        // Selection
        m_Selection = asset.FindActionMap("Selection", throwIfNotFound: true);
        m_Selection_StartSelection = m_Selection.FindAction("Start Selection", throwIfNotFound: true);
        m_Selection_ContinueSelection = m_Selection.FindAction("Continue Selection", throwIfNotFound: true);
        m_Selection_EndSelection = m_Selection.FindAction("End Selection", throwIfNotFound: true);
        m_Selection_MousePosition = m_Selection.FindAction("Mouse Position", throwIfNotFound: true);
        m_Selection_MoveSelection = m_Selection.FindAction("Move Selection", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Camera Movement
    private readonly InputActionMap m_CameraMovement;
    private ICameraMovementActions m_CameraMovementActionsCallbackInterface;
    private readonly InputAction m_CameraMovement_Movement;
    public struct CameraMovementActions
    {
        private @ControlManager m_Wrapper;
        public CameraMovementActions(@ControlManager wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_CameraMovement_Movement;
        public InputActionMap Get() { return m_Wrapper.m_CameraMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CameraMovementActions set) { return set.Get(); }
        public void SetCallbacks(ICameraMovementActions instance)
        {
            if (m_Wrapper.m_CameraMovementActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_CameraMovementActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_CameraMovementActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_CameraMovementActionsCallbackInterface.OnMovement;
            }
            m_Wrapper.m_CameraMovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
            }
        }
    }
    public CameraMovementActions @CameraMovement => new CameraMovementActions(this);

    // Selection
    private readonly InputActionMap m_Selection;
    private ISelectionActions m_SelectionActionsCallbackInterface;
    private readonly InputAction m_Selection_StartSelection;
    private readonly InputAction m_Selection_ContinueSelection;
    private readonly InputAction m_Selection_EndSelection;
    private readonly InputAction m_Selection_MousePosition;
    private readonly InputAction m_Selection_MoveSelection;
    public struct SelectionActions
    {
        private @ControlManager m_Wrapper;
        public SelectionActions(@ControlManager wrapper) { m_Wrapper = wrapper; }
        public InputAction @StartSelection => m_Wrapper.m_Selection_StartSelection;
        public InputAction @ContinueSelection => m_Wrapper.m_Selection_ContinueSelection;
        public InputAction @EndSelection => m_Wrapper.m_Selection_EndSelection;
        public InputAction @MousePosition => m_Wrapper.m_Selection_MousePosition;
        public InputAction @MoveSelection => m_Wrapper.m_Selection_MoveSelection;
        public InputActionMap Get() { return m_Wrapper.m_Selection; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SelectionActions set) { return set.Get(); }
        public void SetCallbacks(ISelectionActions instance)
        {
            if (m_Wrapper.m_SelectionActionsCallbackInterface != null)
            {
                @StartSelection.started -= m_Wrapper.m_SelectionActionsCallbackInterface.OnStartSelection;
                @StartSelection.performed -= m_Wrapper.m_SelectionActionsCallbackInterface.OnStartSelection;
                @StartSelection.canceled -= m_Wrapper.m_SelectionActionsCallbackInterface.OnStartSelection;
                @ContinueSelection.started -= m_Wrapper.m_SelectionActionsCallbackInterface.OnContinueSelection;
                @ContinueSelection.performed -= m_Wrapper.m_SelectionActionsCallbackInterface.OnContinueSelection;
                @ContinueSelection.canceled -= m_Wrapper.m_SelectionActionsCallbackInterface.OnContinueSelection;
                @EndSelection.started -= m_Wrapper.m_SelectionActionsCallbackInterface.OnEndSelection;
                @EndSelection.performed -= m_Wrapper.m_SelectionActionsCallbackInterface.OnEndSelection;
                @EndSelection.canceled -= m_Wrapper.m_SelectionActionsCallbackInterface.OnEndSelection;
                @MousePosition.started -= m_Wrapper.m_SelectionActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_SelectionActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_SelectionActionsCallbackInterface.OnMousePosition;
                @MoveSelection.started -= m_Wrapper.m_SelectionActionsCallbackInterface.OnMoveSelection;
                @MoveSelection.performed -= m_Wrapper.m_SelectionActionsCallbackInterface.OnMoveSelection;
                @MoveSelection.canceled -= m_Wrapper.m_SelectionActionsCallbackInterface.OnMoveSelection;
            }
            m_Wrapper.m_SelectionActionsCallbackInterface = instance;
            if (instance != null)
            {
                @StartSelection.started += instance.OnStartSelection;
                @StartSelection.performed += instance.OnStartSelection;
                @StartSelection.canceled += instance.OnStartSelection;
                @ContinueSelection.started += instance.OnContinueSelection;
                @ContinueSelection.performed += instance.OnContinueSelection;
                @ContinueSelection.canceled += instance.OnContinueSelection;
                @EndSelection.started += instance.OnEndSelection;
                @EndSelection.performed += instance.OnEndSelection;
                @EndSelection.canceled += instance.OnEndSelection;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @MoveSelection.started += instance.OnMoveSelection;
                @MoveSelection.performed += instance.OnMoveSelection;
                @MoveSelection.canceled += instance.OnMoveSelection;
            }
        }
    }
    public SelectionActions @Selection => new SelectionActions(this);
    public interface ICameraMovementActions
    {
        void OnMovement(InputAction.CallbackContext context);
    }
    public interface ISelectionActions
    {
        void OnStartSelection(InputAction.CallbackContext context);
        void OnContinueSelection(InputAction.CallbackContext context);
        void OnEndSelection(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
        void OnMoveSelection(InputAction.CallbackContext context);
    }
}
