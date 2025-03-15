using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance {get; private set;}
    private List<StudioEventEmitter> eventemitters;

    private void Awake() {
        if(instance == null) {
            instance = this;
        }
        else {
            Debug.LogError("Mehr als ein AudioManager");
        }
        eventemitters = new List<StudioEventEmitter>();
    }
    public void PlayOneShot(EventReference sound, Vector3 pos){
        RuntimeManager.PlayOneShot(sound, pos);
    }
    public EventInstance CreateEventInstance(EventReference eventReference, Transform transform){
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        RuntimeManager.AttachInstanceToGameObject(eventInstance, transform);
        return eventInstance;
    }
    public StudioEventEmitter InitializeEventEmitters(EventReference reference, GameObject eGameObject) {
        StudioEventEmitter emitter = eGameObject.GetComponent<StudioEventEmitter>();
        emitter.EventReference = reference;
        eventemitters.Add(emitter);
        return emitter;
    }
    void OnDestroy()
    {
        foreach(StudioEventEmitter e in eventemitters) {
            e.Stop();
        }
    }



}
