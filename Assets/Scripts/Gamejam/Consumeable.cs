using System;
using UnityEngine;

public class Consumeable : MonoBehaviour
{
    [SerializeField] protected int uses;
    [SerializeField] public ConsumeableType type;
    [SerializeField] public float noise;
    [SerializeField] GameObject holder, awayPos;
    
    public virtual void Use(object sender, ConsumeableUseEventArgs e) {
       
    }
    private void Start()
    {
        
    }
    private void UpdatePos(object sender, ConsumeableUseEventArgs e) {
        Debug.Log("Rein");
        if(e.type.Equals(this)) {
            transform.position = holder.transform.position;
            transform.rotation = holder.transform.rotation;
            transform.SetParent(holder.transform);
        } 
    }
        protected void Atstart() {
        EventManager.instance.UseConsumeableEvent += Use;
        EventManager.instance.AddConsumeableEvent += UpdatePos;
        EventManager.instance.SwitchToWeaponEvent += SwitchToWeapon;
        }
        private void SwitchToWeapon(object sender, EventArgs e) {
            transform.SetParent(null);
            transform.position = awayPos.transform.position;
        }
    
}
