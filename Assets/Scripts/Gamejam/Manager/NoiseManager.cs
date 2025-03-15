using System.Collections;
using UnityEngine;

public class NoiseManager : MonoBehaviour
{
    public float noise;
    private ManagerUI manager;

    private void Start() {
        //manager = this.GetComponent<ManagerUI>();
        EventManager.instance.MakeNoiseEvent += addNoise;
        //StartCoroutine(noiseCheck());
    }
    
    void Update() {
        //manager.UpdateUI(noise, 100f);
        UpdateNoise();
    }

    public void UpdateNoise() {
        if(noise > 0) {
            noise -= Time.deltaTime * 2f;
        }

        if(noise >= 100f){
            noise = 100f;
            EventManager.instance.Alarm();
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
