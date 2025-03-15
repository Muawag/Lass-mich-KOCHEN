using UnityEngine;

public class Consumeable : MonoBehaviour
{
    [SerializeField] protected int uses;
    [SerializeField] public ConsumeableType type;
    [SerializeField] public float noise;
    [SerializeField] GameObject holder, awayPos;
    
    public virtual void Use(object sender, ConsumeableUseEventArgs e) {
       
    }
    private void Awake()
    {
        EventManager.instance.UseConsumeableEvent += Use;
        EventManager.instance.AddConsumeableEvent += UpdatePos;
    }
    private void UpdatePos(object sender, ConsumeableUseEventArgs e) {
        if(e.type.Equals(this)) {
            transform.position = holder.transform.position;
            transform.rotation = holder.transform.rotation;
            transform.SetParent(holder.transform);
        }
        else {
            transform.SetParent(null);
            transform.position = awayPos.transform.position;
        } 
    }
}
