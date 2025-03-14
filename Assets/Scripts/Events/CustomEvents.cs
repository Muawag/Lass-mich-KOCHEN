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
}
