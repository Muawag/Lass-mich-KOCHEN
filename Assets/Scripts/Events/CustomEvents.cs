using System;
using QFSW.QC.Actions;
using UnityEngine;

public class InteractEventArgs : EventArgs {
    public IInteractable interactable; 
}
public class DamageEventArgs : EventArgs {
    public DestryableItem damageable; 
    public float damageValue;
}
public class NoiseEvent : EventArgs {
    public float noise;
}
public class DestroyEvent : EventArgs {
    public float money;
    public DestroyType type;
    public Vector3 pos;
    public bool burning;
}
public class WeaponAddEventArgs : EventArgs {
    public WeaponTypes type;
}
public class ConsumeableAddEventArgs : EventArgs {
    public ConsumeableType type;
}
public class ConsumeableUseEventArgs : EventArgs {
    public Consumeable type;
}
public class PosEventArgs : EventArgs {
    public Vector3 pos;
}
public class GameobjectSendEventArgs : EventArgs {
    public GameObject obj;
}
public class OutlineUpdateEventArgs : EventArgs {
    public IInteractable interactable;
    public bool flag;
}
public class ObjDestroyedEventArgs : EventArgs {
    public DestryableItem item;
}
