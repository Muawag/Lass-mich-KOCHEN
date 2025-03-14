using UnityEngine;

public class Inventar : MonoBehaviour
{
    [SerializeField] WeaponTypes weapon;
    [SerializeField] ConsumeableType consumeable;

    public void AddWeapon(WeaponTypes type) {
        weapon = type;
        EventManager.instance.AddWeapon(weapon);
    }
    public void AddConsumeable(ConsumeableType type) {
        consumeable = type;
        EventManager.instance.AddConsumeable(consumeable);
    }
}
