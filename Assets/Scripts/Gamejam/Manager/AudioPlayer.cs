using UnityEngine;
using FMOD.Studio;
public class AudioPlayer : MonoBehaviour
{
    public GameObject player;
    private EventInstance PlayerFootsteps;
    public Rigidbody playerRb;
   
    void Start()
    {
        PlayerFootsteps = AudioManager.instance.CreateEventInstance(FMODEvents.instance.PlayerFootsteps, gameObject.transform);
        playerRb = player.GetComponent<Player>().rb;
        
    }
    void FixedUpdate()
    {
        UpdateSound();
    }
    private void UpdateSound(){
        if(player.GetComponent<Player>().Grounded() && (Mathf.Abs(playerRb.linearVelocity.x) > 0.01f||Mathf.Abs(playerRb.linearVelocity.z) > 0.01f)){
            
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
