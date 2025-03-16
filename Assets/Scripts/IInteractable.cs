using UnityEngine;

public interface IInteractable 
{
    public void OnInteract(object sender, InteractEventArgs e);

    public void ShowOutline(bool flag);
    public void HandleOutline(object sender, OutlineUpdateEventArgs e);
    public void DisableOutline(object sender, ObjDestroyedEventArgs e);
    
}
