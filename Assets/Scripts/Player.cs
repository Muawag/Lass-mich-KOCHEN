using System.Collections;
using FMOD.Studio;
using Mono.CSharp;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    
    public GameObject GroundCheck;
    public Vector3 forceDirection = Vector3.zero;
    private PlayerInput input;
    public Rigidbody rb;
    public float movementForce = 2.0f;
    public float maxSpeed = 0.5f;
    [SerializeField] private Camera cam;
    [SerializeField] private float interactDistance;
    private Inventar inventar;
    private bool canAttack = true;
    private float scrollchange;
    public bool isSprinting = false;
    private IInteractable tempInteractable = null;
   
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        input = new PlayerInput();
        HandleInput();
        inventar = GetComponent<Inventar>();
        EventManager.instance.GameOverEvent += (sender, e) => {input.Player.Disable();FreezeRot();};
    }
    void Update()
    {
        HandleScrollChange();
        SearchForOutline();
        
    }
    void HandleInput() {
        input.Player.Enable();
        input.Player.Interact.performed += Interact;
        input.Player.Drop.performed += Drop;
        input.Player.Jump.performed += Jump;
        input.Player.Sprint.started += Sprint;
        input.Player.Sprint.canceled += Sprint;
        input.Player.Use.performed += Use;
        input.Player.Scroll.performed += x => scrollchange = x.ReadValue<float>();
        input.Player.Inv1.performed += Inv1;
        input.Player.Inv2.performed += Inv2;
    }
    private void Interact(InputAction.CallbackContext context) {
        if(context.performed) {
            if(Physics.Raycast(cam.transform.position, cam.transform.forward,  out RaycastHit hit, interactDistance)) {
                if(hit.transform.TryGetComponent<IInteractable>(out IInteractable interact)) {
                    EventManager.instance.Interact(interact);
                }
            }

        }
    }
    private void Move() {
        
        forceDirection += input.Player.Movement.ReadValue<Vector2>().x * GetCameraRight(gameObject) * movementForce;
        forceDirection += input.Player.Movement.ReadValue<Vector2>().y * GetCameraForward(gameObject) * movementForce;
        rb.AddForce(forceDirection* movementForce , ForceMode.Impulse);
        forceDirection = Vector3.zero;
        Vector3 horizontalVelocity = rb.linearVelocity;
        horizontalVelocity.y = 0;
        if(horizontalVelocity.sqrMagnitude > maxSpeed * maxSpeed) {
            rb.linearVelocity = horizontalVelocity.normalized + Vector3.up * rb.linearVelocity.y;
        }
        
           
    }
    private Vector3 GetCameraRight(GameObject playerCamera) {
        Vector3 right = playerCamera.transform.right;
        right.y = 0;
        return right.normalized;
    }
    private Vector3 GetCameraForward(GameObject playerCamera) {
        Vector3 forward = playerCamera.transform.forward;
        forward.y = 0;
        return forward.normalized;
    }
    private void FixedUpdate() {
        Move();
        
    }
    private void Drop(InputAction.CallbackContext context) {
        if(context.performed) {
        }
    }
    private void Jump(InputAction.CallbackContext context) {
        if(Grounded() && context.performed) {
            rb.AddForce(Vector3.up * movementForce *5f, ForceMode.Impulse);
            AudioManager.instance.PlayOneShot(FMODEvents.instance.JumpSound, transform.position);
        }
    }
    public bool Grounded() {
        return Physics.Raycast(transform.position,transform.TransformDirection(Vector3.down),1.5f);
    }
    private void Sprint(InputAction.CallbackContext context) {
        if(context.started) {
            movementForce = 3f;
            maxSpeed = 2f;
            isSprinting = true;
        }
        else if(context.canceled) {
            movementForce = 2f;
            maxSpeed = 1f;
            isSprinting = false;
        }
    }
    private void Use(InputAction.CallbackContext context) {
        if(context.performed) {
            if(!inventar.ThrowColl()) {
            if(inventar.getInvTypeSelIndex() == 0 && canAttack) {
            if(Physics.Raycast(cam.transform.position, cam.transform.forward,  out RaycastHit hit, interactDistance)) {
                if(hit.transform.TryGetComponent<DestryableItem>(out DestryableItem interact)) {
                    Debug.Log("AGGGGGGGGG");
                    StartCoroutine(DelayAttack());
                    EventManager.instance.DamageObject(interact, inventar.GetDamage());
                }
            }
            }
            else if(inventar.getInvTypeSelIndex() == 1) {
                EventManager.instance.UseConsumeable(inventar.GetConsumeable());
            }
        }
        else {
            Debug.Log("Stuhl Yeeten");
            inventar.GetThrowable().Throw();
            inventar.ResThrowObj();
        }
        }
    }
    IEnumerator DelayAttack() {
        canAttack = false;
        yield return new WaitForSeconds(1f);
        canAttack = true;
        
    }

    private void HandleScrollChange() {
        if(scrollchange != 0) {
        int change = 0;
        if(scrollchange < 0) {
            change = -1;
        }
        else if(scrollchange > 0) {
            change = 1;
        }
        inventar.Scroll(change);
        change = 0;
        scrollchange = 0f;
        }     
    }
    private void Inv1(InputAction.CallbackContext context) {
        if(context.performed) {
            inventar.SetInvIndex(0);
        }
    }
    private void Inv2(InputAction.CallbackContext context) {
        if(context.performed) {
            inventar.SetInvIndex(1);
        }
    }
    private void SearchForOutline() {
         if(Physics.Raycast(cam.transform.position, cam.transform.forward,  out RaycastHit hit, interactDistance) && !inventar.ThrowColl()) {
                if(hit.transform.gameObject.TryGetComponent<IInteractable>(out IInteractable interactable)) {
                    if(tempInteractable != interactable) {
                        if(tempInteractable == null) {
                            EventManager.instance.UpdateOutline(interactable, true);
                            tempInteractable = interactable;
                        }
                        else {
                            EventManager.instance.UpdateOutline(tempInteractable, false);
                            EventManager.instance.UpdateOutline(tempInteractable, true);
                            tempInteractable = interactable;
                        }
                    }
                }
                else if(tempInteractable != null){
                EventManager.instance.UpdateOutline(tempInteractable, false);
                tempInteractable = null;
         }
         }
         else if(tempInteractable != null){
            EventManager.instance.UpdateOutline(tempInteractable, false);
            tempInteractable = null;
         }
    }
    private void FreezeRot() {
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;

    }
}


