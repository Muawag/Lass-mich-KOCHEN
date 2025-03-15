using UnityEngine;

public class EscapeDoor : MonoBehaviour, IInteractable
{
    public void OnInteract(object sender, InteractEventArgs e)
    {
#pragma warning disable CS0252 // Possible unintended reference comparison; left hand side needs cast
        if (e.interactable == this) {
        Debug.Log("Ich muss raus");
        EventManager.instance.Escaped();
        }
#pragma warning restore CS0252 // Possible unintended reference comparison; left hand side needs cast
    }
    void Start() {
        EventManager.instance.OnInteract += OnInteract;
    }
}
