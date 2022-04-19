using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestAudioEventScript : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction trigger1;
    private InputAction trigger2;
    private InputAction trigger3;

    bool flop;

    void Awake()
    {
        playerInput = new PlayerInput();
        flop = false;
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

    // Start is called before the first frame update
    void Start()
    {
        AudioControlEventArgs args = new AudioControlEventArgs(AUDIO_CONTROL_EVENT.TRACK, flop ? "Track1" : "Track2");
        EventManager.TriggerEvent(EVENT.AUDIO_CONTROL_EVENT, args);
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger1.triggered)
        {
            AudioControlEventArgs args = new AudioControlEventArgs(AUDIO_CONTROL_EVENT.PLAY, null);
            EventManager.TriggerEvent(EVENT.AUDIO_CONTROL_EVENT, args);
        }
        if (trigger2.triggered)
        {
            AudioControlEventArgs args = new AudioControlEventArgs(AUDIO_CONTROL_EVENT.STOP, null);
            EventManager.TriggerEvent(EVENT.AUDIO_CONTROL_EVENT, args);
        }
        if (trigger3.triggered)
        {
            AudioControlEventArgs args = new AudioControlEventArgs(AUDIO_CONTROL_EVENT.TRACK, flop ? "Track1" : "Track2");
            EventManager.TriggerEvent(EVENT.AUDIO_CONTROL_EVENT, args);
            flop = !flop;
        }
    }
}
