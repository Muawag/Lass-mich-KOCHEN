using UnityEngine;

public class TestInteract : MonoBehaviour, IInteractable
{
    public void OnInteract(object sender, InteractEventArgs e)
    {
       // IInteractable interact = (IInteractable) this;
#pragma warning disable CS0252 // Possible unintended reference comparison; left hand side needs cast
        if(e.interactable == this) {
            Debug.Log("Shuuu");
        }
#pragma warning restore CS0252 // Possible unintended reference comparison; left hand side needs cast
    }
    void Start() {
        EventManager.instance.OnInteract += OnInteract;
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Ich gebe mir die kugel");
    }

    public void ShowOutline(bool flag)
    {
        throw new System.NotImplementedException();
    }

    public void HandleOutline(object sender, OutlineUpdateEventArgs e)
    {
        throw new System.NotImplementedException();
    }
}
