using UnityEngine;
using UnityEngine.InputSystem;

public class TempItemManager : MonoBehaviour
{
    [SerializeField] private Inventar inventar;
    [SerializeField] private Weapon axe, crowbar;
    [SerializeField] private Consumeable molotov, graffiti;

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.M)) {
            Debug.Log("Crowbar");
            inventar.AddWeapon(crowbar);
        }
        else if(Input.GetKeyDown(KeyCode.N)) {
            Debug.Log("Axe");
            inventar.AddWeapon(axe);
        }
        else if(Input.GetKeyDown(KeyCode.L)) {
            inventar.AddConsumeable(new Consumeable());
        }*/
    }
}
