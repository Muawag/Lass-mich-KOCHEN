using UnityEngine;

[RequireComponent(typeof(Outline))]
public class Glass : DestryableItem, IThrowable, IInteractable
{
  private Rigidbody rb;
    [SerializeField] Camera cam;
    private bool thrown = false;
    private Outline outline;
    private bool hit = false;

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
        outline = GetComponent<Outline>();
        outline.enabled = false;
        Atstart();
        rb = GetComponent<Rigidbody>();
        EventManager.instance.OnInteract += OnInteract;
        EventManager.instance.UpdateOutlineEvent += HandleOutline;
    }

    private void Yeet() {
        transform.SetParent(null);
        rb.useGravity = true;
        rb.isKinematic = false;
        foreach(Collider collider in col) {
            collider.enabled = true;
        }
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
            if(hit == false) {
            hit = true;
            EventManager.instance.MakeNoise(noisevolume);
            Debug.Log("Zerbrochen");
            DestroyObject();
            }
        }
    }

    public void ShowOutline(bool flag)
    {
        outline.enabled = flag;
    }

    public void HandleOutline(object sender, OutlineUpdateEventArgs e)
    {
        if(e.interactable.Equals(this) && !thrown && !destroyed) {
            ShowOutline(e.flag);
        }
    }
}
