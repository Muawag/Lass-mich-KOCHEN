using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class NoiseManager : MonoBehaviour
{
    
    public bool AlarmStarted = false;
    public static NoiseManager instance {get; private set;}
    
    public GameObject player;
    private void Awake() {
        if(instance == null) {
            instance = this;
        }
        else {
            Debug.LogError("Mehr als ein NoiseManager");
        }
    }
    
    public float noise;
    private ManagerUI manager;

    private void Start() {
        manager = this.GetComponent<ManagerUI>();
        EventManager.instance.MakeNoiseEvent += addNoise;
        AlarmStarted = false;
        //StartCoroutine(noiseCheck());
    }
    
    void Update() {
        manager.UpdateUI(noise, 100f);
        UpdateNoise();
    }

    public void UpdateNoise() {
        if(noise > 0 && noise < 100) {
            noise -= Time.deltaTime * 2f;
        }

        if(noise >= 100f && !AlarmStarted){
            
                EventManager.instance.Alarm();
                AlarmStarted = true;
            
            
        }
    }
    
    // IEnumerator noiseCheck(){
    //     while(GameManager.instance.gameIsActive){
    //         yield return new WaitForSeconds(1);
    //         if(noise > 0){
    //             noise -= 1;
    //         }
    //         if(noise >= 100){
    //             noise = 100;
    //             EventManager.instance.Alarm();
    //         }
    //     }
    // } 
    void addNoise(object sender, NoiseEvent e){
        noise += e.noise;
        Debug.Log("Laut");
    } 
}
