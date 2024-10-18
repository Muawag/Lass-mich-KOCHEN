using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;
    public EventHandler<InteractEventArgs> OnInteract;
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
}
