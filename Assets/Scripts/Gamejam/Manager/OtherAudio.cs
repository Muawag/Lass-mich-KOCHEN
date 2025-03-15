using FMOD.Studio;
using UnityEngine;

public class OtherAudio : MonoBehaviour
{
    
    public GameObject player;
    private EventInstance BurnSound;
    
    bool ToLoudSoundPlayed = false;
    void Start()
    {
        ToLoudSoundPlayed = false;
        BurnSound = AudioManager.instance.CreateEventInstance(FMODEvents.instance.BurningSound, player.gameObject.transform);
    }
    void FixedUpdate()
    {
        if(NoiseManager.instance.noise >= 100 && !ToLoudSoundPlayed){
            AudioManager.instance.PlayOneShot(FMODEvents.instance.ToLoud, player.transform.position);
            ToLoudSoundPlayed = true;
        }
    }
    public void playBurningSound(){
        BurnSound.start();
    }
}
