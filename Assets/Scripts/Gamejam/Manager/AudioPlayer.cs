using UnityEngine;
using FMOD.Studio;
using FMODUnityResonance;
public class AudioPlayer : MonoBehaviour
{
    public GameObject player;
    private EventInstance PlayerFootsteps;
    private EventInstance PlayerSprintFootsteps;
    public Rigidbody playerRb;
   
    void Start()
    {
        EventManager.instance.MolotovThrownEvent += playMolotovSound;
        PlayerFootsteps = AudioManager.instance.CreateEventInstance(FMODEvents.instance.PlayerFootsteps, gameObject.transform);
        PlayerSprintFootsteps = AudioManager.instance.CreateEventInstance(FMODEvents.instance.PlayerSprintFootsteps, gameObject.transform);
        playerRb = player.GetComponent<Player>().rb;
        
    }
    void FixedUpdate()
    {
        /*if(Input.GetKeyDown(KeyCode.J)){
            playKloppSound();
        }*/
        UpdateSound();
    }
    private void UpdateSound(){
        if(player.GetComponent<Player>().isSprinting == false && player.GetComponent<Player>().Grounded() && (Mathf.Abs(playerRb.linearVelocity.x) > 0.01f||Mathf.Abs(playerRb.linearVelocity.z) > 0.01f)){
            
            PlayerSprintFootsteps.stop(STOP_MODE.ALLOWFADEOUT);
            PLAYBACK_STATE playbackState1;
            PlayerFootsteps.getPlaybackState(out playbackState1);
            PlayerFootsteps.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform));
            if(playbackState1.Equals(PLAYBACK_STATE.STOPPED)){
                
                PlayerFootsteps.start();
            }
        }
       else if(player.GetComponent<Player>().isSprinting && player.GetComponent<Player>().Grounded() && (Mathf.Abs(playerRb.linearVelocity.x) > 0.02f||Mathf.Abs(playerRb.linearVelocity.z) > 0.02f)){
            
            PlayerFootsteps.stop(STOP_MODE.ALLOWFADEOUT);
            PLAYBACK_STATE playbackState2;
            PlayerSprintFootsteps.getPlaybackState(out playbackState2);
            PlayerSprintFootsteps.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform));
            EventManager.instance.MakeNoise(2);
            if(playbackState2.Equals(PLAYBACK_STATE.STOPPED)){
                
                PlayerSprintFootsteps.start();
                
            }
        }
       
       
       else{
            PlayerFootsteps.stop(STOP_MODE.ALLOWFADEOUT);
            PlayerSprintFootsteps.stop(STOP_MODE.ALLOWFADEOUT);
       }
        
    }
    public void playMolotovSound(object sender, PosEventArgs e){
        AudioManager.instance.PlayOneShot(FMODEvents.instance.MolotovThrow, e.pos);
        
    }
    public void playGameOverSound(){
        
        AudioManager.instance.PlayOneShot(FMODEvents.instance.Caught, transform.position);
    }
    public void playSuccesSound(){
        AudioManager.instance.PlayOneShot(FMODEvents.instance.Success, transform.position);
    }
    public void playKloppSound(){
         AudioManager.instance.PlayOneShot(FMODEvents.instance.Kloppen, transform.position);
    }
    
}
