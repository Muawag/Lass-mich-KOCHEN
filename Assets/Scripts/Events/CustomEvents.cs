using System;
using QFSW.QC.Actions;
using UnityEngine;

public class InteractEventArgs : EventArgs {
    public IInteractable interactable; 
}
public class SoundEvent : EventArgs {
    public float value;
}
