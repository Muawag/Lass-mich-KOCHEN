using System;
using System.Collections;
using UnityEngine;

public class DestryableItem : MonoBehaviour
{
    [SerializeField] private float hp;
    [SerializeField] private float noisevolume;
    [SerializeField] private float money;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void DestroyObject()
    {
        //ParticleSystem ka was da passiert
        EventManager.instance.ObjectDestroyed(money, gameObject);
    }

    public void Damage(float value) {
        hp -= value;
        EventManager.instance.MakeNoise(noisevolume);
        if(value <= hp) {
            DestroyObject();
        }
    }
    
}
