using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] public WeaponTypes type;
    [SerializeField] public GameObject itemholder;
    [SerializeField] public GameObject awayPos;

    void Start()
    {
        
    }

    public float GetDamage() {
        return damage;
    }
    public void AddToPlayer() {
        transform.position = itemholder.transform.position;
        transform.rotation = itemholder.transform.rotation;
        transform.SetParent(itemholder.transform);
    }
    public void RemoveFromPlayer() {
        transform.SetParent(null);
        transform.position = awayPos.transform.position;
    }
}
