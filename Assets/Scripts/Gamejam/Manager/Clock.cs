using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public float clock;
    public void Start()
    {
        clock = 23.00f;
        StartCoroutine(Time());
    }
    IEnumerator Time (){
        while(GameManager.instance.gameIsActive){
           
            if(clock == 4.00f){
                
                EventManager.instance.TimesUp();
            }

            else{
                
                if(clock == 23){
                    clock = 0;
                }
                else{
                    clock += 1f;
                }
            }
            yield return new WaitForSeconds(2);
        }
    
    }
}
