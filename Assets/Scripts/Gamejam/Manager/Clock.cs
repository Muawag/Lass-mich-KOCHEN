using System.Collections;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    public bool timesUp;
    
    [SerializeField] private TextMeshProUGUI time;
    public int clock;
    [SerializeField] private ClockUI clockUI;
    public void Start()
    {
        clock = 0;
        StartCoroutine(Time());
    }
    void FixedUpdate()
    {
        updateTime();
    }
    IEnumerator Time (){
        while(!GameManager.instance.hasEscaped && !timesUp){
           
            if(clock == 20){
                
                EventManager.instance.TimesUp();
                timesUp = true;
                clockUI.StartFlash();
            }

            else{
                yield return new WaitForSeconds(0.5f);
                clock += 1;
            }
        }
    
    }
    void updateTime(){

        if(clock == 0){
            time.text = "23:00";
        }
        if(clock == 1){
            time.text = "23:15";
        }
        if(clock == 2){
            time.text = "23:30";
        }
        if(clock == 3){
            time.text = "23:45";
        }
        if(clock == 4){
            time.text = "00:00";
        }
        if(clock == 5){
            time.text = "00:15";
        }
        if(clock == 6){
            time.text = "00:30";
        }
        if(clock == 7){
            time.text = "00:45";
        }
        if(clock == 8){
            time.text = "01:00";
        }
        if(clock == 9){
            time.text = "01:15";
        }
        if(clock == 10){
            time.text = "01:30";
        }
        if(clock == 11){
            time.text = "01:45";
        }
        if(clock == 12){
            time.text = "02:00";
        }
        if(clock == 13){
            time.text = "02:15";
        }
        if(clock == 14){
            time.text = "02:30";
        }
        if(clock == 15){
            time.text = "02:45";
        }
        if(clock == 16){
            time.text = "03:00";
        }
        if(clock == 17){
            time.text = "03:15";
        }
        if(clock == 18){
            time.text = "03:30";
        }
        if(clock == 19){
            time.text = "03:45";
        }
        if(clock == 20){
            time.text = "04:00";
        }
    }


}
