using UnityEngine;

public class Inventar : MonoBehaviour
{
    [SerializeField] Weapon weapon;
    [SerializeField] ConsumeableType consumeable;

    public void AddWeapon(Weapon type) {
        if(weapon != null) {
        weapon.RemoveFromPlayer();
        }
        weapon = type;
        weapon.AddToPlayer();
    }
    public void AddConsumeable(ConsumeableType type) {
        consumeable = type;
        EventManager.instance.AddConsumeable(consumeable);
    }

    public float GetDamage() {
        return weapon.GetDamage();
    }
}
