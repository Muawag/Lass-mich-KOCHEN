using FMODUnity;
using UnityEngine;

public class FMODEvents : MonoBehaviour
{
    [field: Header("Test SFX")]
    [field: SerializeField] public EventReference testSFX {get; private set;}
    
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

