using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance
    {
        get
        {
            if (!audioManager)
            {
                audioManager = FindObjectOfType(typeof(AudioController)) as AudioController;
                if (!audioManager)
                    Debug.Log("There needs to be one active AudioManager script on a GameObject in your scene.");
                else
                    audioManager.Init();
            }

            return audioManager;
        }
    }

    public ObjectPool audioSourcePool;
    public AudioSource bgmSource;
    
    private Dictionary<string, AudioClip> clipMap;
    private List<AudioSource> activeSourceList;
    private Dictionary<string, AudioSource> reservedSourceList;
    private static AudioController audioManager;

    private const string INITIAL_BGM_TRACK = "Track1";

    public void HandleAudioEvent(object o, AudioEventArgs e)
    {
        GameObject container = audioSourcePool.GetPooledObject();
        AudioSource source = container != null ? container.GetComponent<AudioSource>() : null;
        AudioClip audio = null;
        if(source && clipMap.TryGetValue(e.clipLabel, out audio) && audio != null)
        {
            container.SetActive(true);
            source.clip = audio;
            container.transform.position = e.position;
            source.Play();
            activeSourceList.Add(source);
        }
    }

    public void HandleAudioControlEvent(object o, AudioControlEventArgs e)
    {
        switch(e.command)
        {
            case AUDIO_CONTROL_EVENT.PLAY:
                bgmSource.Play();
                break;
            case AUDIO_CONTROL_EVENT.PAUSE:
                bgmSource.Pause();
                break;
            case AUDIO_CONTROL_EVENT.STOP:
                bgmSource.Stop();
                break;
            case AUDIO_CONTROL_EVENT.TRACK:
                SwitchTracks(e.args);
                break;
            default:
                break;
        }
    }

    private void Init()
    {
        clipMap = new Dictionary<string, AudioClip>();
        activeSourceList = new List<AudioSource>();
        EventManager.instance.AudioEvent += HandleAudioEvent;
        EventManager.instance.AudioControlEvent += HandleAudioControlEvent;

        LoadResources();
        InitBGM();
    }

    private void LoadResources()
    {
        AudioClip clip = Resources.Load<AudioClip>("Audio/Placeholder/RubberBand");
        if (clip == null)
            Debug.Log("Rubber not loading!");
        clipMap.Add("Rubber", clip);
        clip = Resources.Load<AudioClip>("Audio/Placeholder/Track1");
        if (clip == null)
            Debug.Log("Track1 not loading!");
        clipMap.Add("Track1", clip);
        clip = Resources.Load<AudioClip>("Audio/Placeholder/Track2");
        if (clip == null)
            Debug.Log("Track2 not loading!");
        clipMap.Add("Track2", clip);
    }

    private void InitBGM()
    {
        AudioClip clip = null;
        if(clipMap.TryGetValue(INITIAL_BGM_TRACK, out clip) && clip != null)
        {
            bgmSource.clip = clip;
        }
        bgmSource.Play();
    }

    private void SwitchTracks(string track)
    {
        Debug.Log("Switching tracks to " + track);
        AudioClip music;
        if(clipMap.TryGetValue(track, out music) && music != null)
        {
            bgmSource.Stop();
            bgmSource.clip = music;
            bgmSource.Play();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AudioController.instance.UpdateSources();
    }

    public void UpdateSources()
    {
        foreach (AudioSource source in activeSourceList)
        {
            if (!source.isPlaying)
                source.gameObject.SetActive(false);
        }
    }
}
