// GENERATED AUTOMATICALLY FROM 'Assets/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Testing"",
            ""id"": ""baa7c273-3a11-4d2b-9ef4-d9c637b1f453"",
            ""actions"": [
                {
                    ""name"": ""Trigger1"",
                    ""type"": ""Button"",
                    ""id"": ""7c4996bc-b5bf-461f-827d-bd9b857896e2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Trigger2"",
                    ""type"": ""Button"",
                    ""id"": ""779271d7-9cca-4118-ae68-09308889337e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Trigger3"",
                    ""type"": ""Button"",
                    ""id"": ""db408aa1-a3cf-48f3-829d-90aa5fb9c2ca"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""7bd59786-bf70-4a0b-8964-521aec60c90b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""3bb9dee3-53a0-4a5a-9bb6-8ecf755d50fd"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Charge"",
                    ""type"": ""Button"",
                    ""id"": ""cd2f4d57-a569-4942-ae0e-78f0537f5b7a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""abe14382-14c6-4496-95ba-6167a5c08c5e"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Trigger1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8aa3633a-0ee2-4aef-a714-19b578ac8d63"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Trigger2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""df87ad6f-1d05-4085-bae2-22ba7331c384"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Trigger3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d8a030e3-8964-4bd6-ad1c-936c95272627"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4315355b-7b47-434f-857c-22505133986a"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""758fbfc8-fc9c-4773-a27d-6807b308a740"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Hold(duration=10)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Charge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player"",
            ""id"": ""ee87bd50-0000-453d-b46e-961fd2380bae"",
            ""actions"": [
                {
                    ""name"": ""Forward"",
                    ""type"": ""Button"",
                    ""id"": ""fecddec7-7251-4dd2-a87c-78c4a618c94c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Backward"",
                    ""type"": ""Button"",
                    ""id"": ""146bf278-2f77-4aa6-a836-1abbd9ba8008"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""8f6297cb-cb1e-454f-b8c3-0211b9610298"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""6cc54b77-ed6d-412e-9c4a-9872b6af98b4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""a26475d6-562e-4424-8df0-53f0d5a7b59c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Charge"",
                    ""type"": ""Button"",
                    ""id"": ""fcc21921-f655-4c84-81a5-842b60b00c8a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3cb6e8f1-daeb-48c9-b6c5-998d86c307d5"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ddc1a01e-ee2f-479f-bfb2-8ee242c0c6c3"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Backward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0e016bc9-16bc-46b1-818e-866c5c691655"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""52b0530c-51c8-4a1e-8f77-048ded7177d0"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""692cde69-b0ac-4b9f-a846-15b5bc4c2a96"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3dabfbda-113f-4a49-88b6-94c4094f9a23"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Hold(duration=10)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Charge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Testing
        m_Testing = asset.FindActionMap("Testing", throwIfNotFound: true);
        m_Testing_Trigger1 = m_Testing.FindAction("Trigger1", throwIfNotFound: true);
        m_Testing_Trigger2 = m_Testing.FindAction("Trigger2", throwIfNotFound: true);
        m_Testing_Trigger3 = m_Testing.FindAction("Trigger3", throwIfNotFound: true);
        m_Testing_Attack = m_Testing.FindAction("Attack", throwIfNotFound: true);
        m_Testing_MousePosition = m_Testing.FindAction("MousePosition", throwIfNotFound: true);
        m_Testing_Charge = m_Testing.FindAction("Charge", throwIfNotFound: true);
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Forward = m_Player.FindAction("Forward", throwIfNotFound: true);
        m_Player_Backward = m_Player.FindAction("Backward", throwIfNotFound: true);
        m_Player_Left = m_Player.FindAction("Left", throwIfNotFound: true);
        m_Player_Right = m_Player.FindAction("Right", throwIfNotFound: true);
        m_Player_MousePosition = m_Player.FindAction("MousePosition", throwIfNotFound: true);
        m_Player_Charge = m_Player.FindAction("Charge", throwIfNotFound: true);
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

    // Testing
    private readonly InputActionMap m_Testing;
    private ITestingActions m_TestingActionsCallbackInterface;
    private readonly InputAction m_Testing_Trigger1;
    private readonly InputAction m_Testing_Trigger2;
    private readonly InputAction m_Testing_Trigger3;
    private readonly InputAction m_Testing_Attack;
    private readonly InputAction m_Testing_MousePosition;
    private readonly InputAction m_Testing_Charge;
    public struct TestingActions
    {
        private @PlayerInput m_Wrapper;
        public TestingActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Trigger1 => m_Wrapper.m_Testing_Trigger1;
        public InputAction @Trigger2 => m_Wrapper.m_Testing_Trigger2;
        public InputAction @Trigger3 => m_Wrapper.m_Testing_Trigger3;
        public InputAction @Attack => m_Wrapper.m_Testing_Attack;
        public InputAction @MousePosition => m_Wrapper.m_Testing_MousePosition;
        public InputAction @Charge => m_Wrapper.m_Testing_Charge;
        public InputActionMap Get() { return m_Wrapper.m_Testing; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TestingActions set) { return set.Get(); }
        public void SetCallbacks(ITestingActions instance)
        {
            if (m_Wrapper.m_TestingActionsCallbackInterface != null)
            {
                @Trigger1.started -= m_Wrapper.m_TestingActionsCallbackInterface.OnTrigger1;
                @Trigger1.performed -= m_Wrapper.m_TestingActionsCallbackInterface.OnTrigger1;
                @Trigger1.canceled -= m_Wrapper.m_TestingActionsCallbackInterface.OnTrigger1;
                @Trigger2.started -= m_Wrapper.m_TestingActionsCallbackInterface.OnTrigger2;
                @Trigger2.performed -= m_Wrapper.m_TestingActionsCallbackInterface.OnTrigger2;
                @Trigger2.canceled -= m_Wrapper.m_TestingActionsCallbackInterface.OnTrigger2;
                @Trigger3.started -= m_Wrapper.m_TestingActionsCallbackInterface.OnTrigger3;
                @Trigger3.performed -= m_Wrapper.m_TestingActionsCallbackInterface.OnTrigger3;
                @Trigger3.canceled -= m_Wrapper.m_TestingActionsCallbackInterface.OnTrigger3;
                @Attack.started -= m_Wrapper.m_TestingActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_TestingActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_TestingActionsCallbackInterface.OnAttack;
                @MousePosition.started -= m_Wrapper.m_TestingActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_TestingActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_TestingActionsCallbackInterface.OnMousePosition;
                @Charge.started -= m_Wrapper.m_TestingActionsCallbackInterface.OnCharge;
                @Charge.performed -= m_Wrapper.m_TestingActionsCallbackInterface.OnCharge;
                @Charge.canceled -= m_Wrapper.m_TestingActionsCallbackInterface.OnCharge;
            }
            m_Wrapper.m_TestingActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Trigger1.started += instance.OnTrigger1;
                @Trigger1.performed += instance.OnTrigger1;
                @Trigger1.canceled += instance.OnTrigger1;
                @Trigger2.started += instance.OnTrigger2;
                @Trigger2.performed += instance.OnTrigger2;
                @Trigger2.canceled += instance.OnTrigger2;
                @Trigger3.started += instance.OnTrigger3;
                @Trigger3.performed += instance.OnTrigger3;
                @Trigger3.canceled += instance.OnTrigger3;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @Charge.started += instance.OnCharge;
                @Charge.performed += instance.OnCharge;
                @Charge.canceled += instance.OnCharge;
            }
        }
    }
    public TestingActions @Testing => new TestingActions(this);

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Forward;
    private readonly InputAction m_Player_Backward;
    private readonly InputAction m_Player_Left;
    private readonly InputAction m_Player_Right;
    private readonly InputAction m_Player_MousePosition;
    private readonly InputAction m_Player_Charge;
    public struct PlayerActions
    {
        private @PlayerInput m_Wrapper;
        public PlayerActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Forward => m_Wrapper.m_Player_Forward;
        public InputAction @Backward => m_Wrapper.m_Player_Backward;
        public InputAction @Left => m_Wrapper.m_Player_Left;
        public InputAction @Right => m_Wrapper.m_Player_Right;
        public InputAction @MousePosition => m_Wrapper.m_Player_MousePosition;
        public InputAction @Charge => m_Wrapper.m_Player_Charge;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Forward.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnForward;
                @Forward.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnForward;
                @Forward.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnForward;
                @Backward.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBackward;
                @Backward.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBackward;
                @Backward.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBackward;
                @Left.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeft;
                @Right.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRight;
                @MousePosition.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMousePosition;
                @Charge.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCharge;
                @Charge.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCharge;
                @Charge.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCharge;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Forward.started += instance.OnForward;
                @Forward.performed += instance.OnForward;
                @Forward.canceled += instance.OnForward;
                @Backward.started += instance.OnBackward;
                @Backward.performed += instance.OnBackward;
                @Backward.canceled += instance.OnBackward;
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @Charge.started += instance.OnCharge;
                @Charge.performed += instance.OnCharge;
                @Charge.canceled += instance.OnCharge;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface ITestingActions
    {
        void OnTrigger1(InputAction.CallbackContext context);
        void OnTrigger2(InputAction.CallbackContext context);
        void OnTrigger3(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
        void OnCharge(InputAction.CallbackContext context);
    }
    public interface IPlayerActions
    {
        void OnForward(InputAction.CallbackContext context);
        void OnBackward(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
        void OnCharge(InputAction.CallbackContext context);
    }
}
