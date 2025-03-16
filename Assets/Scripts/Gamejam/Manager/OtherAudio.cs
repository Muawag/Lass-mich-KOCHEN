using System;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using NUnit.Framework.Constraints;
using UnityEngine;

public class OtherAudio : MonoBehaviour
{
    
    public bool AlarmIsOn = false;
    public GameObject player;
    private EventInstance BurnSound;
    private List<EventInstance> sounds = new List<EventInstance>();
    private EventInstance instance, instancePolice;
    
    bool ToLoudSoundPlayed = false;
    
    void Start()
    {
        ToLoudSoundPlayed = false;
        AlarmIsOn = false;
        BurnSound = AudioManager.instance.CreateEventInstance(FMODEvents.instance.BurningSound, player.gameObject.transform);
        EventManager.instance.TimesUpEvent += StartAlarmClock;
        EventManager.instance.BurningThingEvent += StartBurning;
        EventManager.instance.ObjectDestroyedEvent += BreakSounds;
        EventManager.instance.EscapedAfterAlarmEvent += DisableAlarm;
        EventManager.instance.EscapedAfterToLoudEvent += DisablePolice;
    }
    void FixedUpdate()
    {
        if(NoiseManager.instance.noise >= 100 && !ToLoudSoundPlayed && !AlarmIsOn && !GameManager.instance.hasEscaped){
            ToLoudSoundPlayed = true;
            instancePolice = RuntimeManager.CreateInstance(FMODEvents.instance.ToLoud);
            instancePolice.set3DAttributes(RuntimeUtils.To3DAttributes(player.transform.position));
            instancePolice.start();
            instancePolice.release();
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
        if(!ToLoudSoundPlayed && !GameManager.instance.hasEscaped){
            AlarmIsOn = true;
            //AudioManager.instance.PlayOneShot(FMODEvents.instance.AlarmClock, player.transform.position);
            instance = RuntimeManager.CreateInstance(FMODEvents.instance.AlarmClock);
            instance.set3DAttributes(RuntimeUtils.To3DAttributes(player.transform.position));
            instance.start();
            instance.release();
        }
       
    }
    private void DisableAlarm(object sender, EventArgs e) {
        if(AlarmIsOn) {
            instance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
    }
     private void DisablePolice(object sender, EventArgs e) {
        if(ToLoudSoundPlayed) {
            instancePolice.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
    }
}
