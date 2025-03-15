using UnityEngine;

public class Molotov : Consumeable
{
    private Rigidbody rb;
    [SerializeField] Camera cam;
    private Collider col;
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
}
