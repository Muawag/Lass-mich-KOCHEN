using UnityEngine;
using FMOD.Studio;
public class AudioPlayer : MonoBehaviour
{
    public GameObject player;
    private EventInstance PlayerFootsteps;
    void Start()
    {
        PlayerFootsteps = AudioManager.instance.CreateEventInstance(FMODEvents.instance.PlayerFootsteps, gameObject.transform);

    }
    void FixedUpdate()
    {
        UpdateSound();
    }
    private void UpdateSound(){
        if(player.GetComponent<Player>().Grounded()){
            
            PLAYBACK_STATE playbackState;
            PlayerFootsteps.getPlaybackState(out playbackState);
            PlayerFootsteps.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform));
            if(playbackState.Equals(PLAYBACK_STATE.STOPPED)){
                
                PlayerFootsteps.start();
            }
        }
       else{
            PlayerFootsteps.stop(STOP_MODE.ALLOWFADEOUT);
       }
        
}
}
