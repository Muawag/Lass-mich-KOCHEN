using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using FMODUnity;

[RequireComponent(typeof(StudioEventEmitter))]
public class Chair : DestryableItem, IBurnable, IThrowable, IInteractable
{
    private StudioEventEmitter emitter;
    private Rigidbody rb;
    [SerializeField] Camera cam;
    [SerializeField] Collider col;
    private bool thrown = false;
    public void Burn()
    {
        StartCoroutine(HandleBurn());
    }

    public IEnumerator HandleBurn()
    {
        Debug.Log("Soundd in mich rein");
        //EventManager.instance.BurnStuff(transform.position);
        emitter.Play();
        while(hp > 0f) {
            hp-= 10f;
            yield return new WaitForSeconds(1f);
        }
        if(hp <= 0f) {
            EventManager.instance.FireEnded(transform.position);
            DestroyObject();
        }
    }

    public void OnInteract(object sender, InteractEventArgs e)
    {
        if(e.interactable.Equals(this)) {
            EventManager.instance.ThrowablePickedUp(gameObject);
            Debug.Log("Aufheben Stuhl");
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
        emitter = AudioManager.instance.InitializeEventEmitters(FMODEvents.instance.BurningSound, this.gameObject);
        EventManager.instance.OnInteract += OnInteract;
    }
    private void Yeet() {
        transform.SetParent(null);
        rb.useGravity = true;
        rb.isKinematic = false;
        col.enabled = true;
        thrown = true;
        rb.AddForce((transform.forward + cam.transform.forward) *5, ForceMode.Impulse);
    }
    void OnCollisionEnter(Collision collision)
    {
        if(thrown) {
            if(collision.gameObject.TryGetComponent<DestryableItem>(out DestryableItem item)) {
                if(this.value > item.GetValue()) {
                    item.DestroyObject();
                }
            }
            EventManager.instance.MakeNoise(noisevolume);
            Debug.Log("Zerbrochen");
            DestroyObject();
        }
    }


}
