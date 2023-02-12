// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Potential/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Grounded"",
            ""id"": ""210325a8-e90a-491d-8cf5-e4b6cadc0aae"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""856b9e72-5011-4b3d-9cc9-3091cd918940"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SwitchState"",
                    ""type"": ""Button"",
                    ""id"": ""40fb2999-5371-4004-92ec-26d8509fd404"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePos"",
                    ""type"": ""Value"",
                    ""id"": ""dd98cd56-2240-4180-b991-b7b2d0f5decb"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""32520c02-36e1-4905-bd45-c3f88691a5c9"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""ee68e1ed-6750-44a9-8342-62f12b0252eb"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b0ced165-4666-40a9-aba5-132d1ef23ae5"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""bfe8dc61-9f12-4714-9b8b-1f858dada5ea"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""faf108b6-570b-4861-90a9-fcfbc797187b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""eaa0ae3c-f3e3-4d70-aabb-a013201644af"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d67f0830-1cd3-4686-a762-70f47de90651"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchState"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""01996d87-5fcd-48c4-a1e4-e658fd064198"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchState"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f5798a55-43d5-4f1f-b278-fc636ba895e8"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePos"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ff200992-22f6-4697-8aa9-2bb7f3eeb099"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePos"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""In Air"",
            ""id"": ""71f1f9e2-67d4-455f-a7c9-afb46424549e"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""356f9941-65f0-462c-9b7b-1efc0f7fd243"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d509722e-b652-444c-93fa-e90c3d69412e"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Grounded
        m_Grounded = asset.FindActionMap("Grounded", throwIfNotFound: true);
        m_Grounded_Move = m_Grounded.FindAction("Move", throwIfNotFound: true);
        m_Grounded_SwitchState = m_Grounded.FindAction("SwitchState", throwIfNotFound: true);
        m_Grounded_MousePos = m_Grounded.FindAction("MousePos", throwIfNotFound: true);
        // In Air
        m_InAir = asset.FindActionMap("In Air", throwIfNotFound: true);
        m_InAir_Newaction = m_InAir.FindAction("New action", throwIfNotFound: true);
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

    // Grounded
    private readonly InputActionMap m_Grounded;
    private IGroundedActions m_GroundedActionsCallbackInterface;
    private readonly InputAction m_Grounded_Move;
    private readonly InputAction m_Grounded_SwitchState;
    private readonly InputAction m_Grounded_MousePos;
    public struct GroundedActions
    {
        private @PlayerControls m_Wrapper;
        public GroundedActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Grounded_Move;
        public InputAction @SwitchState => m_Wrapper.m_Grounded_SwitchState;
        public InputAction @MousePos => m_Wrapper.m_Grounded_MousePos;
        public InputActionMap Get() { return m_Wrapper.m_Grounded; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GroundedActions set) { return set.Get(); }
        public void SetCallbacks(IGroundedActions instance)
        {
            if (m_Wrapper.m_GroundedActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GroundedActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GroundedActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GroundedActionsCallbackInterface.OnMove;
                @SwitchState.started -= m_Wrapper.m_GroundedActionsCallbackInterface.OnSwitchState;
                @SwitchState.performed -= m_Wrapper.m_GroundedActionsCallbackInterface.OnSwitchState;
                @SwitchState.canceled -= m_Wrapper.m_GroundedActionsCallbackInterface.OnSwitchState;
                @MousePos.started -= m_Wrapper.m_GroundedActionsCallbackInterface.OnMousePos;
                @MousePos.performed -= m_Wrapper.m_GroundedActionsCallbackInterface.OnMousePos;
                @MousePos.canceled -= m_Wrapper.m_GroundedActionsCallbackInterface.OnMousePos;
            }
            m_Wrapper.m_GroundedActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @SwitchState.started += instance.OnSwitchState;
                @SwitchState.performed += instance.OnSwitchState;
                @SwitchState.canceled += instance.OnSwitchState;
                @MousePos.started += instance.OnMousePos;
                @MousePos.performed += instance.OnMousePos;
                @MousePos.canceled += instance.OnMousePos;
            }
        }
    }
    public GroundedActions @Grounded => new GroundedActions(this);

    // In Air
    private readonly InputActionMap m_InAir;
    private IInAirActions m_InAirActionsCallbackInterface;
    private readonly InputAction m_InAir_Newaction;
    public struct InAirActions
    {
        private @PlayerControls m_Wrapper;
        public InAirActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_InAir_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_InAir; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InAirActions set) { return set.Get(); }
        public void SetCallbacks(IInAirActions instance)
        {
            if (m_Wrapper.m_InAirActionsCallbackInterface != null)
            {
                @Newaction.started -= m_Wrapper.m_InAirActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_InAirActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_InAirActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_InAirActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public InAirActions @InAir => new InAirActions(this);
    public interface IGroundedActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnSwitchState(InputAction.CallbackContext context);
        void OnMousePos(InputAction.CallbackContext context);
    }
    public interface IInAirActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
}
