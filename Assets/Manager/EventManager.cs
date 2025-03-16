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
    
    public EventHandler<EventArgs> SwitchToWeaponEvent;
    public EventHandler<PosEventArgs> BurningThingEvent;
    public EventHandler<PosEventArgs> FireEndedEvent;
    public EventHandler<GameobjectSendEventArgs> ThrowablePickedUpEvent;
    public EventHandler<ConsumeableUseEventArgs> RemoveConFromInvEvent;
    public EventHandler<OutlineUpdateEventArgs> UpdateOutlineEvent;
    public EventHandler<EventArgs> GameOverEvent;
    public EventHandler<ObjDestroyedEventArgs> ObjZerfallenEvent;
    public EventHandler<EventArgs> EscapedAfterAlarmEvent;
    public EventHandler<EventArgs> EscapedAfterToLoudEvent;
    public EventHandler<EventArgs> AttackEvent;
    public EventHandler<EventArgs> ThrowObjEvent;

    
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
    public void ObjectDestroyed(float value, GameObject gobject, Vector3 pos, DestroyType type, bool isburning) {
        ObjectDestroyedEvent?.Invoke(this, new DestroyEvent{money = value, pos = pos, type = type, burning = isburning});
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
        GameOverEvent?.Invoke(this, EventArgs.Empty);
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
   
    public void RemoveConsFromInv() {
        SwitchToWeaponEvent?.Invoke(this, EventArgs.Empty);
    }
    public void BurnStuff(Vector3 posnew) {
        BurningThingEvent?.Invoke(this, new PosEventArgs{pos = posnew});
    }
    public void FireEnded(Vector3 pos) {
        FireEndedEvent?.Invoke(this, new PosEventArgs{pos = pos});
    }
    public void ThrowablePickedUp(GameObject obj) {
        ThrowablePickedUpEvent?.Invoke(this, new GameobjectSendEventArgs{obj = obj});
    }
    public void RemoveConFromInv(Consumeable con) {
        RemoveConFromInvEvent?.Invoke(this, new ConsumeableUseEventArgs{type = con});
    }
    public void UpdateOutline(IInteractable interactable, bool flag) {
        UpdateOutlineEvent?.Invoke(this, new OutlineUpdateEventArgs{interactable = interactable, flag = flag});
    }
    public void GameOver() {
        GameOverEvent?.Invoke(this, EventArgs.Empty);
    }
    public void ObjectDestroyed(DestryableItem item) {
        ObjZerfallenEvent?.Invoke(this, new ObjDestroyedEventArgs{item = item});
    }
    public void EscapedAfterAlarm() {
        EscapedAfterAlarmEvent?.Invoke(this, EventArgs.Empty);
    }
    public void EscapedAfterToLoud() {
        EscapedAfterToLoudEvent?.Invoke(this, EventArgs.Empty);
    }
    public void Attack() {
        AttackEvent?.Invoke(this, EventArgs.Empty);
    }
    public void ThrowObj() {
        ThrowObjEvent?.Invoke(this, EventArgs.Empty);
    }
}
