using FMODUnity;
using UnityEngine;

public class FMODEvents : MonoBehaviour
{
    [field: Header("Player SFX")]
    [field: SerializeField] public EventReference PlayerFootsteps {get; private set;}

    [field: Header("Jump Sound")]
    [field: SerializeField] public EventReference JumpSound {get; private set;}

    [field: Header("punch")]
    [field: SerializeField] public EventReference punch {get; private set;}
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

