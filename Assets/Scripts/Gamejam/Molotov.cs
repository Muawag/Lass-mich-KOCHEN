using System.Collections;
using UnityEngine;

public class Molotov : Consumeable
{
    private Rigidbody rb;
    [SerializeField] Camera cam;
    [SerializeField] LayerMask targetMask;
    private Collider col;
    public Collider[] colliders;
    private bool activatetd = false;
    [SerializeField] GameObject partSystem;
    [SerializeField] Transform burnPos;
    GameObject partsysCreated;
    [SerializeField] GameObject explodePartSys;
    [SerializeField] GlassCheat cheat;
    [SerializeField] Zerfallen zerfallen;
    private bool burningOver = false;
    void Start()
    {
        Atstart();
        rb = GetComponent<Rigidbody>();
        col = GetComponentInChildren<Collider>();
        CreateMolotovParticle();
    }
    void FixedUpdate()
    {
        UpdateRot();
    }
    public override void Use(object sender, ConsumeableUseEventArgs e)
    {
        if(e.type.Equals(this)) {
            uses--;
            Yeet();
            if(uses <= 0) {
                EventManager.instance.RemoveConFromInv(this);
            }
        }
    }

    private void Yeet() {
        transform.SetParent(null);
        rb.useGravity = true;
        rb.isKinematic = false;
        col.enabled = true;
        cheat.UpdateOnThrow();
        rb.AddForce((transform.forward + cam.transform.forward) *10, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag != "Player" && !activatetd) {
        PlaceExplosion();
        zerfallen.YeetComponents();
        Debug.Log("Burn");
        activatetd = true;
        colliders = Physics.OverlapSphere(transform.position, 3f, targetMask);
        foreach (Collider item in colliders)
        {
            item.transform.parent.GetComponentInParent<IBurnable>().Burn();
        }
            StartCoroutine(HandleDestroy());
        }
        //
    }
    IEnumerator HandleDestroy() {
        EventManager.instance.MolotovThrown(transform.position);
        yield return new WaitForSeconds(3.1f);
        EventManager.instance.MakeNoise(noise);
        //Destroy(gameObject);
        //bombardino crocodilo
        burningOver = true;
        Destroy(partsysCreated);
    }
    private void CreateMolotovParticle() {
        partsysCreated = Instantiate(partSystem, burnPos.position, burnPos.rotation);
        ParticleSystem sys = partSystem.GetComponentInChildren<ParticleSystem>();
        partsysCreated.transform.SetParent(burnPos.transform);
        var shape = sys.shape;
        shape.angle = 10f;
        ParticleSystem.MainModule size = sys.main;
        size.startSize = new ParticleSystem.MinMaxCurve(1f, 1.5f);
        
    }
    private void UpdateRot() {
        if(!burningOver) {
        partsysCreated.transform.rotation = new Quaternion(0,0,0,1);
        }
    }
    private void PlaceExplosion() {
        Debug.Log("Explode");
        GameObject explode = Instantiate(explodePartSys, transform.position, Quaternion.identity);
        StartCoroutine(DelExplosion(explode));
    }
    IEnumerator DelExplosion(GameObject g) {
        Debug.Log("dawdawdagawg");
        yield return new WaitForSeconds(3f);
        Debug.Log("Del");
        Destroy(g);
    }
}
