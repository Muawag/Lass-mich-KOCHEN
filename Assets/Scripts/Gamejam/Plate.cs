using UnityEngine;

public class Plate : DestryableItem, IThrowable, IInteractable
{
    private Rigidbody rb;
    [SerializeField] Camera cam;
    private bool thrown = false;
    public void OnInteract(object sender, InteractEventArgs e)
    {
        if(e.interactable.Equals(this)) {
            EventManager.instance.ThrowablePickedUp(gameObject);
            Debug.Log("Aufheben Teller");
        }
    }

    public void Throw()
    {
        Yeet();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         Atstart();
        rb = GetComponent<Rigidbody>();
        EventManager.instance.OnInteract += OnInteract;
    }

    private void Yeet() {
        transform.SetParent(null);
        rb.useGravity = true;
        rb.isKinematic = false;
        thrown = true;
        rb.AddForce((transform.forward + cam.transform.forward) *5, ForceMode.Impulse);
    }
    void OnCollisionEnter(Collision collision)
    {
        if(thrown && collision.transform.tag != "Player") {
            if(collision.gameObject.TryGetComponent<DestryableItem>(out DestryableItem item)) {
                if(this.value >= item.GetValue()) {
                    item.DestroyObject();
                }
            }
            EventManager.instance.MakeNoise(noisevolume);
            Debug.Log("Zerbrochen");
            DestroyObject();
        }
    }

    public void ShowOutline(bool flag)
    {
        throw new System.NotImplementedException();
    }

    public void HandleOutline(object sender, OutlineUpdateEventArgs e)
    {
        throw new System.NotImplementedException();
    }
}
