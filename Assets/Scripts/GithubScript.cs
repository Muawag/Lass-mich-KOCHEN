using UnityEngine;
using UnityEngine.InputSystem;

public class GithubScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private PlayerInput input;
    void Start()
    {
        Debug.Log("Test");
        input = new PlayerInput();
        HandleInput();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)) {
            AudioManager.instance.PlayOneShot(FMODEvents.instance.testSFX, transform.position);
        }
    }
    void HandleInput() {
        input.Player.Enable();
        input.Player.Interact.performed += Interact;
    }
    private void Interact(InputAction.CallbackContext context) {
        if(context.performed) {
            Debug.Log("Interact");
        }
    }
}
