using FMODUnity;
using UnityEngine;

public class FMODEvents : MonoBehaviour
{
    [field: Header("Player SFX")]
    [field: SerializeField] public EventReference PlayerFootsteps {get; private set;}

    [field: Header("Jump Sound")]
    [field: SerializeField] public EventReference JumpSound {get; private set;}

    [field: Header("Other Audio")]
    [field: SerializeField] public EventReference ToLoud {get; private set;}
    
    
    public static FMODEvents instance { get; private set;}

    private void Awake() {
        if(instance == null) {
            instance = this;
        }
        else {
            Debug.LogError("Mehr als ein FMODEvents");
        }

    }
}

