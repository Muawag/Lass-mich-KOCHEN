using System.Collections;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    public bool TimesUp = false;
    public GameObject clockUi;
    private TextMeshProUGUI time;
    public float clock;
    public void Start()
    {
        time = clockUi.GetComponent<TextMeshProUGUI>();
        clock = 23.00f;
        StartCoroutine(Time());
    }
    void FixedUpdate()
    {
        updateTime();
    }
    IEnumerator Time (){
       
        while(GameManager.instance.gameIsActive && !TimesUp){
            
            if(clock == 4.00f){
                TimesUp = true;
                EventManager.instance.TimesUp();
            }
            
            else{
                yield return new WaitForSeconds(10);
                if(clock == 23){
                    clock = 0;
                }
                else{
                    clock += 1f;
                }
            }
            
        }
    
    }
    void updateTime(){
        time.text = clock.ToString() + ":00";
    }
}
