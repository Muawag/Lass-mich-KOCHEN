using UnityEngine;

public class EscapeDoor : MonoBehaviour, IInteractable
{
    public void DisableOutline(object sender, ObjDestroyedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    public void HandleOutline(object sender, OutlineUpdateEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    public void OnInteract(object sender, InteractEventArgs e)
    {
#pragma warning disable CS0252 // Possible unintended reference comparison; left hand side needs cast
        if (e.interactable == this) {
        Debug.Log("Ich muss raus");
        EventManager.instance.Escaped();
        }
#pragma warning restore CS0252 // Possible unintended reference comparison; left hand side needs cast
    }

    public void ShowOutline(bool flag)
    {
        throw new System.NotImplementedException();
    }

    void Start() {
        EventManager.instance.OnInteract += OnInteract;
    }
}
