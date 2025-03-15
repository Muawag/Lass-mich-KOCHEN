using System;
using System.Collections;
using System.ComponentModel.Design.Serialization;
using Mono.CSharp;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public bool hasEscaped = false;
    public GameObject player;
    public float escapeTimer = 15f;
    public bool gameIsActive = true;
    public static GameManager instance;

    [SerializeField] private GameOverScreen Screen;

    private void Awake()
    {
        if(instance == null) {
            instance = this;
        }
        
    }
    private void Start() {
        EventManager.instance.TimesUpEvent += alarm;    
        EventManager.instance.AlarmEvent += alarm;
        EventManager.instance.EscapedEvent += escaped;
    }
   
    public void alarm(object sender, EventArgs e){
        StartCoroutine(Escape());
    }
    IEnumerator Escape(){
        while(!hasEscaped && escapeTimer > 0){
            yield return new WaitForSeconds(1);
            escapeTimer -= 1;
            if(escapeTimer == 0){
                gameover();
            }
        }
        
    }
    public void gameover(){
        if(!hasEscaped){
            player.GetComponent<AudioPlayer>().playGameOverSound();
            Screen.Setup(false);
        }
        
    }
    public void escaped (object sender, EventArgs e){
        
        hasEscaped = true;
        player.GetComponent<AudioPlayer>().playSuccesSound();
        Screen.Setup(true);
       
    }
}
