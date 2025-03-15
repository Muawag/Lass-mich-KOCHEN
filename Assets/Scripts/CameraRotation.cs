using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    private Vector2 turn;
    [SerializeField] private float mouseSens;
    private bool gameOver = false;
    public void LockCursor() {
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void ApplyRotaion() {
        if(!gameOver) {
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
    }
    void Start() {
        LockCursor();
        EventManager.instance.GameOverEvent += (sender, e) => {Cursor.lockState = CursorLockMode.None;gameOver = true;};
    }
    private void Update() {
        ApplyRotaion();
    }
}
