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
    void Start()
    {
        Atstart();
        rb = GetComponent<Rigidbody>();
        col = GetComponentInChildren<Collider>();
    }
    public override void Use(object sender, ConsumeableUseEventArgs e)
    {
        if(e.type.Equals(this)) {
            Yeet();
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
        colliders = Physics.OverlapSphere(transform.position, 5f, targetMask);
        foreach (Collider item in colliders)
        {
            item.gameObject.GetComponent<IBurnable>().Burn();
        }
            StartCoroutine(HandleDestroy());
        }
        //
    }
    IEnumerator HandleDestroy() {
        yield return new WaitForSeconds(1.5f);
        EventManager.instance.MakeNoise(noise);
        Destroy(gameObject);
        //bombardino crocodilo
    }
}
