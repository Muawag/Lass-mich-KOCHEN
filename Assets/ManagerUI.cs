using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class ManagerUI : MonoBehaviour
{
    [SerializeField] private Slider sliderWhite;
    [SerializeField] private Image Fill;
    
    public float noise;
    public float lerpTimer;
    private float lerpSpeed = 2f;
    private bool EscapeIsActive = false;
    
    void Start()
    {
        
        EventManager.instance.AlarmEvent += EscapeBar;
        EventManager.instance.TimesUpEvent += EscapeBar;
        EscapeIsActive = false;
    }

    void Update()
    {
        //Schrumpfen();
    }

    public void UpdateUI(float noise, float maxNoise)
    {
        if(!EscapeIsActive){
        float fillW = sliderWhite.value; //get current valuesf
        
        float hFraction = noise / maxNoise; //get noise percentage
        
        lerpTimer += Time.deltaTime;
        
        float percentComplete = lerpTimer / lerpSpeed;

        percentComplete = percentComplete * percentComplete; //nice lerp effect

        SetWhite(Mathf.Lerp(fillW, hFraction, percentComplete * 10f));
        }
    }

    public void SetWhite(float value)
    {
        sliderWhite.value = value;
    }
    public void EscapeBar(object sender, EventArgs e)
    {
        EscapeIsActive = true;
        Fill.color = Color.red;
        sliderWhite.value = 1f;
    }

    /*public void Schrumpfen(){
        if(EscapeIsActive) {
            Debug.Log("aj");
            float timer = 0f;
            float progress = 0f;
            timer += 100f *Time.deltaTime;
            progress = 1 - timer/10f;
            sliderWhite.value = Mathf.Lerp(0, 1, progress * 10f);
        }
    }*/
   
}