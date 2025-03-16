using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestryableItem : MonoBehaviour
{
    [SerializeField] protected float hp;
    [SerializeField] protected float noisevolume;
    [SerializeField] protected float money;
    [SerializeField] protected int value;
    [SerializeField] public List<Collider> col = new List<Collider>();
    [SerializeField] public DestroyType type;
    protected bool burning = false;
    public bool destroyed = false;
    [SerializeField] protected Zerfallen zerfallen;
    
    void Start()
    {
        EventManager.instance.DamageObjectEvent += GetDamaged;
    }
    protected void Atstart() {
        EventManager.instance.DamageObjectEvent += GetDamaged;
        StartCoroutine(GetColls());

    }
    public void DestroyObject()
    {
        //ParticleSystem ka was da passiert
        EventManager.instance.ObjectDestroyed(money, gameObject, transform.position, type, burning);
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
        destroyed = true;
        zerfallen.YeetComponents();
        EventManager.instance.ObjectDestroyed(this);
        yield return new WaitForSeconds(1f);
        //Destroy(gameObject);
    }

    private void GetDamaged(object sender, DamageEventArgs e) {
        if(e.damageable == this) {
            Damage(e.damageValue);
        }
    }
    public int GetValue() {
        return value;
    }
    IEnumerator GetColls() {
        yield return new WaitForSeconds(0.5f);
        col = zerfallen.GetColliders();
    }
    public bool IsBurning() {
        return burning;
    }
    
}
