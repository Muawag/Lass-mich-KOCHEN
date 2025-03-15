using UnityEngine;

public class OtherAudio : MonoBehaviour
{
    
    public GameObject player;
      
    
    bool ToLoudSoundPlayed = false;
    void Start()
    {
        ToLoudSoundPlayed = false;
    }
    void FixedUpdate()
    {
        if(NoiseManager.instance.noise >= 100 && !ToLoudSoundPlayed){
            AudioManager.instance.PlayOneShot(FMODEvents.instance.ToLoud, player.transform.position);
            ToLoudSoundPlayed = true;
        }
    }
}
