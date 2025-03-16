using System.Collections.Generic;
using UnityEngine;

public class Zerfallen : MonoBehaviour
{
    private List<GameObject> components = new List<GameObject>();
    public List<Collider> colls = new List<Collider>();
    Rigidbody rTemp;
    GameObject gTemp;
    MeshCollider mTemp;
    private bool yeeted = false;

    public void YeetComponents() {
        if(!yeeted) {
            yeeted = true;
        foreach(GameObject g in components) {
            rTemp = g.AddComponent<Rigidbody>();
            Vector3 forceVec = new Vector3(Random.Range(0,1),Random.Range(0,1),Random.Range(0,1));
            rTemp.AddForce(forceVec * 2);
        }
        }
    }
    private void Setup() {
        for(int i = 0; i < transform.childCount; i++) {
            gTemp = transform.GetChild(i).gameObject;
            mTemp = gTemp.AddComponent<MeshCollider>();
            mTemp.convex = true;
            colls.Add(mTemp);
            components.Add(gTemp);
        }
    }
    void Start()
    {
        Setup();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha9)) {
            YeetComponents();
        }
    }
    public List<Collider> GetColliders() {
        return colls;
    }
}
