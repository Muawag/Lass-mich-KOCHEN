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
        if (e.interactable.Equals(this)) {
        Debug.Log("Ich muss raus");
        EventManager.instance.Escaped();
        }
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
