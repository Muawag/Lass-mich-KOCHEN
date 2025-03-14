using System;
using System.Collections;
using System.ComponentModel.Design.Serialization;
using Mono.CSharp;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float escapeTimer = 15f;
    public bool gameIsActive = true;
    public static GameManager instance;

    private void Awake()
    {
        if(instance == null) {
            instance = this;
        }
    }
    private void Start() {
        EventManager.instance.TimesUpEvent += timesUp;    
        EventManager.instance.AlarmEvent += alarm;
    }
    public void timesUp(object sender, EventArgs e) {
        gameover();
    }
    public void alarm(object sender, EventArgs e){
        StartCoroutine(Escape());
    }
    IEnumerator Escape(){
        while(escapeTimer > 0){
            yield return new WaitForSeconds(1);
            escapeTimer -= 1;
            if(escapeTimer == 0){
                gameover();
            }
        }
        
    }
    public void gameover(){
        Debug.Log("game over");
    }
}
