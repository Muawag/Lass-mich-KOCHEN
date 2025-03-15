using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using FMODUnity;

[RequireComponent(typeof(StudioEventEmitter))]
public class Chair : DestryableItem, IBurnable
{
    private StudioEventEmitter emitter;
    public void Burn()
    {
        StartCoroutine(HandleBurn());
    }

    public IEnumerator HandleBurn()
    {
        Debug.Log("Soundd in mich rein");
        //EventManager.instance.BurnStuff(transform.position);
        emitter.Play();
        while(hp > 0f) {
            hp-= 10f;
            yield return new WaitForSeconds(1f);
        }
        if(hp <= 0f) {
            EventManager.instance.FireEnded(transform.position);
            DestroyObject();
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Atstart();
        emitter = AudioManager.instance.InitializeEventEmitters(FMODEvents.instance.BurningSound, this.gameObject);
    }

}
