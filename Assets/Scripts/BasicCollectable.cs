using System.Xml.Serialization;
using UnityEngine;

public class BasicCollectable : MonoBehaviour, IInteractable
{
    [SerializeField] Inventar inventar;
    public void OnInteract(object sender, InteractEventArgs e)
    {
#pragma warning disable CS0252 // Possible unintended reference comparison; left hand side needs cast
        if (e.interactable == this) {
            Debug.Log("Rein");
            inventar.Add(gameObject);
        }
#pragma warning restore CS0252 // Possible unintended reference comparison; left hand side needs cast
    }
    void Start() {
        EventManager.instance.OnInteract += OnInteract;
    }
}
