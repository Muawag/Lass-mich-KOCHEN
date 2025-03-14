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
        EventManager.instance.DamageObjectEvent += GetDamaged;
    }

    public void DestroyObject()
    {
        //ParticleSystem ka was da passiert
        EventManager.instance.ObjectDestroyed(money, gameObject);
        StartCoroutine(DestroyAfter());
    }

    public void Damage(float value) {
        hp -= value;
        Debug.Log("Aua");
        EventManager.instance.MakeNoise(noisevolume);
        if(value <= hp) {
            DestroyObject();
        }
    }
    IEnumerator DestroyAfter() {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    private void GetDamaged(object sender, DamageEventArgs e) {
        if(e.damageable == this) {
            Damage(e.damageValue);
        }
    }
    
}
