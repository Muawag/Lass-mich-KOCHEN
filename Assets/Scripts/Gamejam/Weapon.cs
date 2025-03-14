using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] public WeaponTypes type;

    void Start()
    {
        
    }

    public float GetDamage() {
        return damage;
    }
}
