using UnityEngine;

public class Molotov : Consumeable
{
    private Rigidbody rb;
    [SerializeField] Camera cam;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
        rb.AddForce((transform.forward + cam.transform.forward) *5, ForceMode.Impulse);
    }
}
