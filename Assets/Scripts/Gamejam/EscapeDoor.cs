using UnityEngine;

[RequireComponent(typeof(Outline))]
public class EscapeDoor : MonoBehaviour, IInteractable
{
    private Outline outline;

    public void DisableOutline(object sender, ObjDestroyedEventArgs e)
    {
            if(e.item.Equals(this)) {
                outline.enabled = false;
        }    
        }

    public void HandleOutline(object sender, OutlineUpdateEventArgs e)
    {
        if(e.interactable.Equals(this)) {
            ShowOutline(e.flag);
        }
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
        outline.enabled = flag;
    }

    void Start() {
        EventManager.instance.OnInteract += OnInteract;
        EventManager.instance.UpdateOutlineEvent += HandleOutline;
        outline = GetComponent<Outline>();
        outline.enabled = false;
    }
}
