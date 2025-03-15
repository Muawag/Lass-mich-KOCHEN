using System.Collections;
using UnityEngine;

public class NoiseManager : MonoBehaviour
{
    public float noise;
    
    void Update() {
        
        //this.GetComponent<ManagerUI>().UpdateUI(noise, 100f);
        
    }
    private void Start() {
        EventManager.instance.MakeNoiseEvent += addNoise;
        StartCoroutine(noiseCheck());
    }
    IEnumerator noiseCheck(){
        while(GameManager.instance.gameIsActive){
            yield return new WaitForSeconds(1);
            if(noise > 0){
                noise -= 1;
            }
            if(noise >= 100){
                noise = 100;
                EventManager.instance.Alarm();
            }
        }
    } 
    private void addNoise(object sender, NoiseEvent e){
        noise += e.noise;
        Debug.Log("Laut");
    } 
}
