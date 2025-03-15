using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventManager : MonoBehaviour
{
    public EventHandler<EventArgs> EscapedEvent;
    public EventHandler<EventArgs> NewNightEvent;
    public static EventManager instance;
    public EventHandler<InteractEventArgs> OnInteract;
    public EventHandler<NoiseEvent> MakeNoiseEvent;
    public EventHandler<DestroyEvent> ObjectDestroyedEvent;
    public EventHandler<EventArgs> AlarmEvent;
    public EventHandler<EventArgs> TimesUpEvent;
    public EventHandler<DamageEventArgs> DamageObjectEvent;
    public EventHandler<WeaponAddEventArgs> AddWeaponEvent;
    public EventHandler<ConsumeableUseEventArgs> UseConsumeableEvent;
    public EventHandler<ConsumeableUseEventArgs> AddConsumeableEvent;
    public EventHandler<PosEventArgs> MolotovThrownEvent;
    public EventHandler<EventArgs> EscapeEvent;
    public EventHandler<EventArgs> SwitchToWeaponEvent;
    public EventHandler<PosEventArgs> BurningThingEvent;
    public EventHandler<PosEventArgs> FireEndedEvent;

    
    private void Awake() {
        if(instance == null) {
            instance = this;
        }
        else {
            Debug.LogError("Mehr als ein EventManager");
        }
    }
    public void Interact(IInteractable interactable) {
        OnInteract?.Invoke(this, new InteractEventArgs {interactable = interactable});
    }
    public void DamageObject(DestryableItem damageItem, float damageValue) {
        DamageObjectEvent?.Invoke(this, new DamageEventArgs {damageable = damageItem, damageValue = damageValue});
    }
    public void MakeNoise(float noiseVolume) {
        MakeNoiseEvent?.Invoke(this, new NoiseEvent{noise = noiseVolume});
    }
    public void ObjectDestroyed(float value, GameObject gobject) {
        ObjectDestroyedEvent?.Invoke(this, new DestroyEvent{money = value});
    }
    IEnumerator DestroyAfter(GameObject toDestroy) {
        yield return new WaitForSeconds(1f);
        Destroy(toDestroy);
    }
    public void TimesUp(){
        TimesUpEvent?.Invoke(this,EventArgs.Empty);
    }
    public void Alarm(){
        AlarmEvent?.Invoke(this,EventArgs.Empty);
    }
    public void NewNight(){
        NewNightEvent?.Invoke(this, EventArgs.Empty);
    }
    public void Escaped(){
        EscapedEvent?.Invoke(this, EventArgs.Empty);
    }
    public void AddWeapon(WeaponTypes wtype) {
        AddWeaponEvent?.Invoke(this, new WeaponAddEventArgs {type = wtype});
    }
    public void AddConsumeable(Consumeable ctype) {
        //AddConsumeableEvent?.Invoke(this, new ConsumeableAddEventArgs {type = ctype});
    }
    public void UseConsumeable(Consumeable con) {
        UseConsumeableEvent?.Invoke(this, new ConsumeableUseEventArgs{type = con});
    }
    public void AddConsToInv(Consumeable con) {
        AddConsumeableEvent?.Invoke(this, new ConsumeableUseEventArgs{type = con});
    }
    public void MolotovThrown(Vector3 posM) {
        MolotovThrownEvent?.Invoke(this, new PosEventArgs {pos = posM});
    }
    public void Escape() {
        EscapedEvent?.Invoke(this, EventArgs.Empty);
    }
    public void RemoveConsFromInv() {
        SwitchToWeaponEvent?.Invoke(this, EventArgs.Empty);
    }
    public void BurnStuff(Vector3 posnew) {
        BurningThingEvent?.Invoke(this, new PosEventArgs{pos = posnew});
    }
    public void FireEnded(Vector3 pos) {
        FireEndedEvent?.Invoke(this, new PosEventArgs{pos = pos});
    }

}
