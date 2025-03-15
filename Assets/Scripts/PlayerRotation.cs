using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
  private Vector2 turn;
  private bool gameOver = false;
  [SerializeField] private float mouseSens;
  private void Update() {
        ApplyRotaion();
    }
    public void ApplyRotaion() {
        
        if(!gameOver) {
        turn.x += Input.GetAxis("Mouse X") * mouseSens;
        transform.localRotation = Quaternion.Euler(0, turn.x, 0);
        }

    }
    private void Start()
    {
        EventManager.instance.GameOverEvent += (sender, e) => {Cursor.lockState = CursorLockMode.None;gameOver = true;};
    }
}
