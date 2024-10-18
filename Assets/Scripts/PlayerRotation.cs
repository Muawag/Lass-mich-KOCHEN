using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
  private Vector2 turn;
  [SerializeField] private float mouseSens;
  private void Update() {
        ApplyRotaion();
    }
    public void ApplyRotaion() {
        
        turn.x += Input.GetAxis("Mouse X") * mouseSens;
        transform.localRotation = Quaternion.Euler(0, turn.x, 0);
        

    }
}
