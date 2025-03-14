using UnityEngine;

public class Inventar : MonoBehaviour
{
    [SerializeField] Weapon weapon;
    [SerializeField] ConsumeableType consumeable;

    public void AddWeapon(Weapon type) {
        weapon = type;
    }
    public void AddConsumeable(ConsumeableType type) {
        consumeable = type;
        EventManager.instance.AddConsumeable(consumeable);
    }

    public float GetDamage() {
        return weapon.GetDamage();
    }
}
