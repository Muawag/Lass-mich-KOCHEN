using System;
using System.Collections.Generic;
using FMOD.Studio;
using NUnit.Framework.Constraints;
using UnityEngine;

public class OtherAudio : MonoBehaviour
{
    
    public bool AlarmIsOn = false;
    public GameObject player;
    private EventInstance BurnSound;
    private List<EventInstance> sounds = new List<EventInstance>();
    
    bool ToLoudSoundPlayed = false;
    
    void Start()
    {
        ToLoudSoundPlayed = false;
        AlarmIsOn = false;
        BurnSound = AudioManager.instance.CreateEventInstance(FMODEvents.instance.BurningSound, player.gameObject.transform);
        EventManager.instance.TimesUpEvent += StartAlarmClock;
        EventManager.instance.BurningThingEvent += StartBurning;
        EventManager.instance.ObjectDestroyedEvent += BreakSounds;
    }
    void FixedUpdate()
    {
        if(NoiseManager.instance.noise >= 100 && !ToLoudSoundPlayed && !AlarmIsOn){
            AudioManager.instance.PlayOneShot(FMODEvents.instance.ToLoud, player.transform.position);
            ToLoudSoundPlayed = true;
        }
    }
    void StartBurning(object sender, PosEventArgs e) {
        Vector3 postemp = e.pos;
        Debug.Log("gadwgi");
        sounds.Add(AudioManager.instance.CreateEventInstance(FMODEvents.instance.BurningSound, player.gameObject.transform));
        
    }
    void BreakSounds(object sender, DestroyEvent e){
        if(e.type == DestroyType.Glass){
            AudioManager.instance.PlayOneShot(FMODEvents.instance.GlasBreak, e.pos);
        }
        else if(e.type == DestroyType.Chair && !e.burning){
            AudioManager.instance.PlayOneShot(FMODEvents.instance.ChairBreak, e.pos);
        }
        else if(e.type == DestroyType.Table && !e.burning){
            AudioManager.instance.PlayOneShot(FMODEvents.instance.TableBreak, e.pos);
        }
        else if(e.type == DestroyType.Plate){
            AudioManager.instance.PlayOneShot(FMODEvents.instance.PlateBreak, e.pos);
        }
        else if(e.burning){
            AudioManager.instance.PlayOneShot(FMODEvents.instance.DestroyFire, e.pos);
        }
    }
    void StartAlarmClock(object sender, EventArgs e){
        if(!ToLoudSoundPlayed){
            AlarmIsOn = true;
            AudioManager.instance.PlayOneShot(FMODEvents.instance.AlarmClock, player.transform.position);
        }
       
    }
}
