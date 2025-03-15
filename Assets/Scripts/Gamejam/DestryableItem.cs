using System;
using System.Collections;
using UnityEngine;

public class DestryableItem : MonoBehaviour
{
    [SerializeField] protected float hp;
    [SerializeField] protected float noisevolume;
    [SerializeField] protected float money;
    [SerializeField] protected int value;
    
    void Start()
    {
        EventManager.instance.DamageObjectEvent += GetDamaged;
    }
    protected void Atstart() {
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
        if(hp <= 0f) {
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
    public int GetValue() {
        return value;
    }
    
}
