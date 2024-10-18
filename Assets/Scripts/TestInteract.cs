using UnityEngine;

public class TestInteract : MonoBehaviour, IInteractable
{
    public void OnInteract(object sender, InteractEventArgs e)
    {
        IInteractable interact = (IInteractable) this;
        if(e.interactable == interact) {
            Debug.Log("Shuuu");
        }
    }
    void Start() {
        EventManager.instance.OnInteract += OnInteract;
    }
}
