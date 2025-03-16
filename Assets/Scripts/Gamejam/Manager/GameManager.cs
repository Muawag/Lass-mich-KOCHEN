using System;
using System.Collections;
using System.ComponentModel.Design.Serialization;
using Mono.CSharp;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    
    public bool hasEscaped = false;
    public GameObject player;
    public float escapeTimer = 10f;
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
        escapeTimer = 10f;
        EventManager.instance.TimesUpEvent += alarm;    
        EventManager.instance.AlarmEvent += alarm;
        EventManager.instance.EscapedEvent += escaped;
    }
   
    public void alarm(object sender, EventArgs e){
        StartCoroutine(Escape());
        Debug.Log("a");
    }
    IEnumerator Escape(){
        while(!hasEscaped && escapeTimer > 0f){
            yield return new WaitForSeconds(1f);
            escapeTimer -= 1f;
            if(escapeTimer == 0f){
                gameover();
            }
        }
        
    }
    public void gameover(){
        if(!hasEscaped){
            EventManager.instance.GameOver();
            //player.GetComponent<AudioPlayer>().playGameOverSound();
            Screen.Setup(false);
        }
        
    }
    public void escaped (object sender, EventArgs e){
        
        hasEscaped = true;
        player.GetComponent<AudioPlayer>().playSuccesSound();
        Screen.Setup(true);
       
    }
}
