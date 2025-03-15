using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Chair : DestryableItem, IBurnable
{
    public void Burn()
    {
        StartCoroutine(HandleBurn());
    }

    public IEnumerator HandleBurn()
    {
        EventManager.instance.BurnStuff(transform.position);
        while(hp > 0f) {
            hp-= 10f;
            yield return new WaitForSeconds(1f);
        }
        if(hp <= 0f) {
            DestroyObject();
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Atstart();
    }
}
