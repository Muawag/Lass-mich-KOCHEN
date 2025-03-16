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
        rb.AddForce((transform.forward + cam.transform.forward) *10, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag != "Player" && !activatetd) {
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
        yield return new WaitForSeconds(1.5f);
        EventManager.instance.MakeNoise(noise);
        Destroy(gameObject);
        //bombardino crocodilo
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
        partsysCreated.transform.rotation = new Quaternion(0,0,0,1);
    }
}
