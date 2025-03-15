using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;

public class OtherAudio : MonoBehaviour
{
    
    public GameObject player;
    private EventInstance BurnSound;
    private List<EventInstance> sounds = new List<EventInstance>();
    
    bool ToLoudSoundPlayed = false;
    
    void Start()
    {
        ToLoudSoundPlayed = false;
        BurnSound = AudioManager.instance.CreateEventInstance(FMODEvents.instance.BurningSound, player.gameObject.transform);
        EventManager.instance.BurningThingEvent += StartBurning;
        EventManager.instance.FireEndedEvent += FireEnded;
        EventManager.instance.ObjectDestroyedEvent += BreakSounds;
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
    void BreakSounds(object sender, DestroyEvent e){
        if(e.type == DestroyType.Glass){
            AudioManager.instance.PlayOneShot(FMODEvents.instance.GlasBreak, e.pos);
        }
        else if(e.type == DestroyType.Chair){
            AudioManager.instance.PlayOneShot(FMODEvents.instance.ChairBreak, e.pos);
        }
    
    
    }
    void FireEnded(object sender, PosEventArgs e) {

    }
}
