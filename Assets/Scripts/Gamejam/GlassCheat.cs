using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassCheat : MonoBehaviour
{
    [SerializeField] Zerfallen zerfallen;
    private List<GameObject> g;
    private List<MeshRenderer> renderers = new List<MeshRenderer>();
    private MeshRenderer rendTemp;
    public List<MeshRenderer> oldMesh = new List<MeshRenderer>();

    public IEnumerator UnsichtbarOnStart() {
        yield return new WaitForSeconds(0.5f);
        g = zerfallen.GetChilds();
        foreach (GameObject gs in g)
        {
            rendTemp = gs.GetComponent<MeshRenderer>();
            rendTemp.enabled = false;
            renderers.Add(rendTemp);
        }
    }
    public void UpdateOnThrow() {
        
        foreach (MeshRenderer rend in renderers)
        {
            rend.enabled = true;
        }
        foreach (MeshRenderer r in oldMesh)
        {
            r.enabled = false;
        }
        
    }

    void Start()
    {
        StartCoroutine(UnsichtbarOnStart());
    }
    

}
