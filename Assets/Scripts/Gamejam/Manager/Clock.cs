using System.Collections;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    public GameObject clockUi;
    private TextMeshProUGUI time;
    public float clock;
    public void Start()
    {
        time = clockUi.GetComponent<TextMeshProUGUI>();
        clock = 22.00f;
        StartCoroutine(Time());
    }
    void FixedUpdate()
    {
        updateTime();
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
            yield return new WaitForSeconds(10);
        }
    
    }
    void updateTime(){
        time.text = clock.ToString() + ":00";
    }
}
