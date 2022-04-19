using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEventArgs : EventArgs
{
    public AudioEventArgs(Vector3 location, string clip)
    {
        position = location;
        clipLabel = clip;
    }

    public Vector3 position { get; set; }
    public string clipLabel { get; set; }
}

public class AudioControlEventArgs : EventArgs
{
    public AudioControlEventArgs(AUDIO_CONTROL_EVENT order, string argv)
    {
        command = order;
        args = argv;
    }

    public AUDIO_CONTROL_EVENT command { get; set; }
    public string args { get; set; }
}

public delegate void AudioEventHandler(object sender, AudioEventArgs e);
public delegate void AudioControlEventHandler(object sender, AudioControlEventArgs e);
public delegate void TestEventHandler(object sender, EventArgs e);

public enum EVENT
{
    AUDIO_EVENT,
    AUDIO_CONTROL_EVENT,
    TEST_EVENT
};

public enum AUDIO_CONTROL_EVENT
{
    PLAY,
    PAUSE,
    STOP,
    TRACK
};

public class EventManager : MonoBehaviour
{
    public event AudioEventHandler AudioEvent;
    public event AudioControlEventHandler AudioControlEvent;
    public event TestEventHandler TestEvent;

    public static EventManager instance
    {
        get
        {
            if(!eventManager)
            {
                eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;
                if (!eventManager)
                    Debug.Log("There needs to be one active EventManager script on a GameObject in your scene.");
                else
                    eventManager.Init();
            }

            return eventManager;
        }
    }

    private static EventManager eventManager;

    private void Init()
    {
        //if(eventDictionary == null)
            //Instantiate dictionary
    }

    public static void TriggerEvent(EVENT eventType, EventArgs args)
    {
        switch(eventType)
        {
            case (EVENT.AUDIO_EVENT):
                EventManager.instance.AudioEventRaised(args);
                break;
            case (EVENT.AUDIO_CONTROL_EVENT):
                EventManager.instance.AudioControlEventRaised(args);
                break;
            case (EVENT.TEST_EVENT):
                EventManager.instance.TestEventRaised(args);
                break;
            default:
                return;
        }
    }

    protected void AudioControlEventRaised(EventArgs e)
    {
        AudioControlEventHandler handler = AudioControlEvent;
        if(AudioControlEvent != null)
        {
            handler(this, e as AudioControlEventArgs);
        }
    }

    protected void AudioEventRaised(EventArgs e)
    {
        AudioEventHandler handler = AudioEvent;
        if(AudioEvent != null)
        {
            handler(this, e as AudioEventArgs);
        }
    }

    protected void TestEventRaised(EventArgs e)
    {
        TestEventHandler handler = TestEvent;
        Debug.Log("Test event raised!");
        if(TestEvent != null)
        {
            handler(this, e);
        }
    }
}