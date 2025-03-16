using FMODUnity;
using UnityEngine;

public class FMODEvents : MonoBehaviour
{
    [field: Header("Player SFX")]
    [field: SerializeField] public EventReference PlayerFootsteps {get; private set;}
    [field: SerializeField] public EventReference PlayerSprintFootsteps {get; private set;}
    [field: SerializeField] public EventReference MolotovThrow {get; private set;}
    [field: SerializeField] public EventReference Caught {get; private set;}
    [field: SerializeField] public EventReference Success {get; private set;}
    [field: SerializeField] public EventReference JumpSound {get; private set;}
    [field: SerializeField] public EventReference Kloppen {get; private set;}
    [field: SerializeField] public EventReference ThrowSound {get; private set;}
    [field: Header("Other Audio")]
    
    [field: SerializeField] public EventReference DestroyFire {get; private set;}
    [field: SerializeField] public EventReference ChairBreak {get; private set;}
    [field: SerializeField] public EventReference GlasBreak {get; private set;}
    [field: SerializeField] public EventReference ToLoud {get; private set;}
    [field: SerializeField] public EventReference BurningSound {get; private set;}
    [field: SerializeField] public EventReference TableBreak {get; private set;}
    [field: SerializeField] public EventReference PlateBreak {get; private set;}
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

