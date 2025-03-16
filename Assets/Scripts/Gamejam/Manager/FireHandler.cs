using System.Collections.Generic;
using UnityEngine;

public class FireHandler : MonoBehaviour
{
    public GameObject particleObj;
    public static FireHandler instance;
    public Dictionary<int, GameObject> systems = new Dictionary<int, GameObject>(); 

    public GameObject PlaceParticleSystem(Transform t, Vector3 pos, float size) {
        GameObject partnew =  Instantiate(particleObj, pos, Quaternion.identity);
        ParticleSystem particle = partnew.GetComponentInChildren<ParticleSystem>();
        var shape = particle.shape;
        shape.angle = size; 
        partnew.transform.SetParent(t);
        return partnew;
    }
    void Awake()
    {
        if(instance == null) {
            instance = this;
        }
    }
}
