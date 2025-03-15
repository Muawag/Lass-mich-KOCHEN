using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;

public class OtherAudio : MonoBehaviour
{
    
    public GameObject player;
    private EventInstance BurnSound;
    private List<EventInstance> sounds = new List<EventInstance>();
    
    bool ToLoudSoundPlayed = false;
    private Dictionary<Vector3,EventInstance> burningSounds = new Dictionary<Vector3, EventInstance>();
    void Start()
    {
        ToLoudSoundPlayed = false;
        BurnSound = AudioManager.instance.CreateEventInstance(FMODEvents.instance.BurningSound, player.gameObject.transform);
        EventManager.instance.BurningThingEvent += StartBurning;
        EventManager.instance.FireEndedEvent += FireEnded;
    }
    void FixedUpdate()
    {
        if(NoiseManager.instance.noise >= 100 && !ToLoudSoundPlayed){
            AudioManager.instance.PlayOneShot(FMODEvents.instance.ToLoud, player.transform.position);
            ToLoudSoundPlayed = true;
        }
    }
    void StartBurning(object sender, PosEventArgs e) {
        Vector3 postemp = e.pos;
        sounds.Add(AudioManager.instance.CreateEventInstance(FMODEvents.instance.BurningSound, player.gameObject.transform));
        
    }
    void FireEnded(object sender, PosEventArgs e) {

    }
}
