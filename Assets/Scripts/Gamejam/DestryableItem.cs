using System.Collections;
using UnityEngine;

public class DestryableItem : MonoBehaviour
{
    [SerializeField] private float hp;
    [SerializeField] 
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void DestroyObject()
    {
        
    }

    public void Damage(float value) {
        hp -= value;
        
        if(value <= hp) {
            DestroyObject();
        }
    }
    
}
