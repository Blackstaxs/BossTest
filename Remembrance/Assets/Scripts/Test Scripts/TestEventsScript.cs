using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestEventsScript : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction trigger1;
    private InputAction trigger2;
    private InputAction trigger3;

    void Awake()
    {
        playerInput = new PlayerInput();
    }

    void OnEnable()
    {
        trigger1 = playerInput.Testing.Trigger1;
        trigger2 = playerInput.Testing.Trigger2;
        trigger3 = playerInput.Testing.Trigger3;

        trigger1.Enable();
        trigger2.Enable();
        trigger3.Enable();
    }

    void OnDisable()
    {
        trigger1.Disable();
        trigger2.Disable();
        trigger3.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger1.triggered)
            EventManager.TriggerEvent(EVENT.TEST_EVENT, null);
            //EventManager.TriggerEvent("test");
        //if (trigger2.triggered)
            //EventManager.TriggerEvent("Spawn");
        //if (trigger3.triggered)
            //EventManager.TriggerEvent("Destroy");
    }
}
