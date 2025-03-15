using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance {get; private set;}

    private void Awake() {
        if(instance == null) {
            instance = this;
        }
        else {
            Debug.LogError("Mehr als ein AudioManager");
        }
    }
    public void PlayOneShot(EventReference sound, Vector3 pos){
        RuntimeManager.PlayOneShot(sound, pos);
    }
    public EventInstance CreateEventInstance(EventReference eventReference, Transform transform){
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        RuntimeManager.AttachInstanceToGameObject(eventInstance, transform);
        return eventInstance;
    }
}
