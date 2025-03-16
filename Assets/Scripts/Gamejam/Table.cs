using System.Collections;
using FMODUnity;
using UnityEngine;
[RequireComponent(typeof(StudioEventEmitter))]
public class Table : DestryableItem, IBurnable
{
    [SerializeField] Transform burnPos;
    private StudioEventEmitter emitter;
    private GameObject partSys;


    public void Burn()
    {
        if(!burning) {
        burning = true;
        Debug.Log("Tisch");
        StartCoroutine(HandleBurn());
        }
    }

    public IEnumerator HandleBurn()
    {
        Debug.Log("Tisch in mich rein");
        partSys = FireHandler.instance.PlaceParticleSystem(transform,burnPos.position, 40);
        EventManager.instance.BurnStuff(transform.position);
        emitter.Play();
        while(hp > 0f) {
            hp-= 10f;
            yield return new WaitForSeconds(1f);
        }
        if(hp <= 0f) {
            emitter.Stop();
            Destroy(partSys);
            EventManager.instance.FireEnded(transform.position);
            DestroyObject();
        }
    }
    void Start()
    {
        Atstart();
        emitter = AudioManager.instance.InitializeEventEmitters(FMODEvents.instance.BurningSound, this.gameObject);

    }


}
