using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    private Vector2 turn;
    [SerializeField] private float mouseSens;
    public void LockCursor() {
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void ApplyRotaion() {
        
        turn.y += Input.GetAxis("Mouse Y") * mouseSens;
        transform.localRotation = Quaternion.Euler(-turn.y, 0, 0);
        if(turn.y >= 90) {
            turn.y = 90;
            transform.localRotation = Quaternion.Euler(-turn.y, 0, 0);
        }
        if(turn.y <= -90) {
            turn.y = -90;
            transform.localRotation = Quaternion.Euler(-turn.y, 0, 0);
        }
    }
    void Start() {
        LockCursor();
    }
    private void Update() {
        ApplyRotaion();
    }
}
