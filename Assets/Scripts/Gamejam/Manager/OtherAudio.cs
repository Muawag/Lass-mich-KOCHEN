using UnityEngine;

public class OtherAudio : MonoBehaviour
{
    
    bool ToLoudSoundPlayed = false;
    void Start()
    {
        ToLoudSoundPlayed = false;
    }
    void FixedUpdate()
    {
        if(NoiseManager.instance.noise >= 100 && !ToLoudSoundPlayed){
            AudioManager.instance.PlayOneShot(FMODEvents.instance.ToLoud, transform.position);
            ToLoudSoundPlayed = true;
        }
    }
}
