using System.Collections.Generic;
using UnityEngine;

public class Inventar : MonoBehaviour
{
    [SerializeField] Weapon weapon;
    [SerializeField] List<Consumeable> consumeables;
    private int consumeableIndex = 0;
    private int invTypeSel = 0;

    public void AddWeapon(Weapon type) {
        if(weapon != null) {
        weapon.RemoveFromPlayer();
        }
        weapon = type;
        weapon.AddToPlayer();
    }
    public void AddConsumeable(Consumeable type) {
        consumeables.Add(type);
        //EventManager.instance.AddConsumeable(type);
    }

    public float GetDamage() {
        return weapon.GetDamage();
    }
    public void Scroll(int f) {
        if(invTypeSel == 1) {
        consumeableIndex += f;
        if(consumeableIndex < 0) {
            consumeableIndex = consumeables.Count-1;
        }
        else if(consumeableIndex > consumeables.Count-1) {
            consumeableIndex = 0;
        }
        Debug.Log(consumeableIndex);
        }
        EventManager.instance.AddConsToInv(GetConsumeable());
    }
    public int getInvTypeSelIndex() {
        return invTypeSel;
    }
    public void SetInvIndex(int i) {
        invTypeSel = i;
        if(invTypeSel == 1) {
            //Debug.Log("1");
            Debug.Log(GetConsumeable().ToString());
            EventManager.instance.AddConsToInv(GetConsumeable());
            weapon.RemoveFromPlayer();
        }
        else if(invTypeSel == 0) {
            Debug.Log("2");
            EventManager.instance.AddConsToInv(null);
            weapon.AddToPlayer();
        }
    }
    public Consumeable GetConsumeable() {
        if(consumeables.Count == 0) {
            return null;
        }
        else {
        return consumeables[consumeableIndex];
        }
    }
}
