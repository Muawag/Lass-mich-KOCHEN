using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class NoiseManager : MonoBehaviour
{
    
    public bool AlarmStarted = false;
    public static NoiseManager instance {get; private set;}
    public bool showGRR = true;
    public GameObject player;
    public List<Sprite> sprites = new List<Sprite>();
    [SerializeField] private Image holder;
    private void Awake() {
        if(instance == null) {
            instance = this;
        }
        else {
            Debug.LogError("Mehr als ein NoiseManager");
        }
    }
    
    public float noise;
    private ManagerUI manager;

    private void Start() {
        showGRR = true;
        manager = this.GetComponent<ManagerUI>();
        EventManager.instance.MakeNoiseEvent += addNoise;
        EventManager.instance.TimesUpEvent += deleteGRR;
        AlarmStarted = false;
        //StartCoroutine(noiseCheck());
    }
    
    void Update() {
        manager.UpdateUI(noise, 100f);
        UpdateNoise();
        UpdateGRR();
    }

    public void UpdateNoise() {
        if(noise > 0 && noise < 100) {
            noise -= Time.deltaTime * 2f;
        }

        if(noise >= 100f && !AlarmStarted){
            
                EventManager.instance.Alarm();
                AlarmStarted = true;
            
            
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
    private void UpdateGRR() {
        if(!GameManager.instance.hasEscaped && showGRR){
            if(noise < 33){
                //erstesGRR
                holder.sprite = sprites[0];
            }
            if(noise >= 33 && noise < 66){
                holder.sprite = sprites[1];
            }
            if(noise > 66 && noise < 100){
                holder.sprite = sprites[2];
            }
            if(noise >= 100){
                holder.sprite = sprites[3];
            }
        }
        else{
            holder.enabled = false;
        }
    
    }
    void deleteGRR(object sender, EventArgs e){
        showGRR = false;
    }
}
