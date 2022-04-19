// GENERATED AUTOMATICALLY FROM 'Assets/TestingControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @TestingControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @TestingControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""TestingControls"",
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
    public struct TestingActions
    {
        private @TestingControls m_Wrapper;
        public TestingActions(@TestingControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Trigger1 => m_Wrapper.m_Testing_Trigger1;
        public InputAction @Trigger2 => m_Wrapper.m_Testing_Trigger2;
        public InputAction @Trigger3 => m_Wrapper.m_Testing_Trigger3;
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
            }
        }
    }
    public TestingActions @Testing => new TestingActions(this);
    public interface ITestingActions
    {
        void OnTrigger1(InputAction.CallbackContext context);
        void OnTrigger2(InputAction.CallbackContext context);
        void OnTrigger3(InputAction.CallbackContext context);
    }
}
