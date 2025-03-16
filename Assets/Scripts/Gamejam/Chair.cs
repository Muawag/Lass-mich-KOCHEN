using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using FMODUnity;
using System.Collections.Generic;

[RequireComponent(typeof(StudioEventEmitter))]
[RequireComponent(typeof(Outline))]
public class Chair : DestryableItem, IBurnable, IThrowable, IInteractable
{
    private StudioEventEmitter emitter;
    private Rigidbody rb;
    [SerializeField] Camera cam;
    [SerializeField] Transform burnPos;
    private GameObject partSys;
    
    private bool thrown = false;
    private Outline outline;
    private bool hit = false;
    public void Burn()
    {
        if(!burning) {
        burning = true;
        Debug.Log("Jetzt");
        StartCoroutine(HandleBurn());
        }
    }

    public IEnumerator HandleBurn()
    {
        Debug.Log("Soundd in mich rein");
        partSys = FireHandler.instance.PlaceParticleSystem(transform,burnPos.position, 20);
        EventManager.instance.BurnStuff(transform.position);
        emitter.Play();
        while(hp > 0f) {
            hp-= 10f;
            yield return new WaitForSeconds(1f);
        }
        if(hp <= 0f) {
            emitter.Stop();
            Destroy(partSys);
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
        outline = GetComponent<Outline>();
        outline.enabled = false;
        Atstart();
        EventManager.instance.ObjZerfallenEvent += DisableOutline;
        rb = GetComponent<Rigidbody>();
        emitter = AudioManager.instance.InitializeEventEmitters(FMODEvents.instance.BurningSound, this.gameObject);
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

    public void DisableOutline(object sender, ObjDestroyedEventArgs e)
    {
        if(e.item.Equals(this)) {
            outline.enabled = false;
        }
    }
}
