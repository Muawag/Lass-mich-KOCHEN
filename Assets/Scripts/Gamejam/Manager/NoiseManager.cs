using System.Collections;
using UnityEngine;

public class NoiseManager : MonoBehaviour
{
    public float noise;

    IEnumerator noiseCheck(){
        while(GameManager.instance.gameIsActive){
            if(noise > 0){
                yield return new WaitForSeconds(1);
                noise -= 1;
            }
            if(noise >= 100){
                Debug.Log("Alarm");
            }
        }
    } 
    
}
