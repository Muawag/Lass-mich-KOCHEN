using System.ComponentModel.Design.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameIsActive = true;
    public static GameManager instance;

    private void Awake()
    {
        if(instance == null) {
            instance = this;
        }
    }

}
