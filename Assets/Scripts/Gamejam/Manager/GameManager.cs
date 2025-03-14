using System;
using System.ComponentModel.Design.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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
        Debug.Log("Times Up");
    }
    public void alarm(object sender, EventArgs e){
        Debug.Log("alarm");
    }
}
