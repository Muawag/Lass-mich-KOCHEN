using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Vector3 forceDirection = Vector3.zero;
    private PlayerInput input;
    private Rigidbody rb;
    public float movementForce = 2.0f;
    public float maxSpeed = 0.5f;
    [SerializeField] private Camera cam;
    [SerializeField] private float interactDistance;
    private Inventar inventar;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        input = new PlayerInput();
        HandleInput();
        inventar = GetComponent<Inventar>();
    }
    void HandleInput() {
        input.Player.Enable();
        input.Player.Interact.performed += Interact;
        input.Player.Drop.performed += Drop;
        input.Player.Jump.performed += Jump;
        input.Player.Sprint.started += Sprint;
        input.Player.Sprint.canceled += Sprint;
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
    private void AudioTest() {
        if(Input.GetKeyDown(KeyCode.A)) {
            AudioManager.instance.PlayOneShot(FMODEvents.instance.testSFX, transform.position);
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
            inventar.Drop();
        }
    }
    private void Jump(InputAction.CallbackContext context) {
        if(Grounded() && context.performed) {
            rb.AddForce(Vector3.up * movementForce *5f, ForceMode.Impulse);
        }
    }
    private bool Grounded() {
        return true;
    }
    private void Sprint(InputAction.CallbackContext context) {
        if(context.started) {
            movementForce = 3f;
            maxSpeed = 2f;
        }
        else if(context.canceled) {
            movementForce = 2f;
            maxSpeed = 1f;
        }
    }
}
