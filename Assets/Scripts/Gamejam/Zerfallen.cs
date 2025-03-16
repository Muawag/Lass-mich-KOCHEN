using System.Collections.Generic;
using UnityEngine;

public class Zerfallen : MonoBehaviour
{
    public List<GameObject> components = new List<GameObject>();
    public List<Collider> colls = new List<Collider>();
    Rigidbody rTemp;
    GameObject gTemp;
    MeshCollider mTemp;
    private bool yeeted = false;
    [SerializeField] bool flag;

    public void YeetComponents() {
        if(!yeeted) {
            yeeted = true;
            if(!flag) {
                foreach (Collider item in colls)
                {
                    item.enabled = true;
                }
            }
        foreach(GameObject g in components) {
            rTemp = g.AddComponent<Rigidbody>();
            Debug.Log("Drauf");
            Vector3 forceVec = new Vector3(Random.Range(0,1),Random.Range(0,1),Random.Range(0,1));
            rTemp.AddForce(forceVec * 2);
        }
        }
    }
    private void Setup(bool flag) {
        for(int i = 0; i < transform.childCount; i++) {
            gTemp = transform.GetChild(i).gameObject;
            mTemp = gTemp.AddComponent<MeshCollider>();
            mTemp.convex = true;
            mTemp.enabled = flag;
            colls.Add(mTemp);
            components.Add(gTemp);
        }
    }
    void Start()
    {
        Setup(flag);
    }
    public List<Collider> GetColliders() {
        return colls;
    }
    public List<GameObject> GetChilds() {
        return components;
    }
}
