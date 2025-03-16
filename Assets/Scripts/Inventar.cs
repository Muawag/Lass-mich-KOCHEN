using System.Collections.Generic;
using UnityEngine;

public class Inventar : MonoBehaviour
{
    [SerializeField] Weapon weapon;
    [SerializeField] List<Consumeable> consumeables;
    [SerializeField] Consumeable molli;
    public bool molliUsed = false;
    private int consumeableIndex = 0;
    public int invTypeSel = 0;
    [SerializeField] Transform throwPos;
    private GameObject throwObj = null;

    public void AddWeapon(Weapon type) {
        if(weapon != null) {
        weapon.RemoveFromPlayer();
        }
        weapon = type;
        weapon.AddToPlayer();
    }
    void Start()
    {
        weapon.AddToPlayer();
        EventManager.instance.RemoveConFromInvEvent += RemoveConsumeable;
        EventManager.instance.ThrowablePickedUpEvent += ThrowablePickedUp;
        EventManager.instance.UseConsumeableEvent += (sender, e) => {invTypeSel = 1;StartCoroutine(ResetInvIndex()) ; molliUsed = true;};
    }
    public void AddConsumeable(Consumeable type) {
        consumeables.Add(type);
        //EventManager.instance.AddConsumeable(type);
    }

    public float GetDamage() {
        return weapon.GetDamage();
    }
    public void Scroll(int f) {
        if(invTypeSel == 1) {
        consumeableIndex += f;
        if(consumeableIndex < 0) {
            consumeableIndex = consumeables.Count-1;
        }
        else if(consumeableIndex > consumeables.Count-1) {
            consumeableIndex = 0;
        }
        Debug.Log(consumeableIndex);
        }
        EventManager.instance.AddConsToInv(GetConsumeable());
    }
    public void ScrollInv(int f) {
        if(!molliUsed) {
            Debug.Log("ScrollInv");
        invTypeSel += f;
        if(invTypeSel > 1) {
            invTypeSel = 0;
        }
        else if(invTypeSel < 0) {
            invTypeSel = 1;
        }
        SetInvIndex(invTypeSel);
        }
    }
    public int getInvTypeSelIndex() {
        return invTypeSel;
    }
    public void SetInvIndex(int i) {
        invTypeSel = i;
        if(invTypeSel == 1) {
            //Debug.Log("1");
            if(consumeables.Count > 0) {
            Debug.Log(GetConsumeable().ToString());
            EventManager.instance.AddConsToInv(GetConsumeable());
            }
            weapon.RemoveFromPlayer();
        }
        else if(invTypeSel == 0) {
            Debug.Log("2");
            if(consumeables.Count > 0) {
            EventManager.instance.RemoveConsFromInv();
            }
            weapon.AddToPlayer();
        }
    }
    public Consumeable GetConsumeable() {
        if(consumeables.Count == 0) {
            return null;
        }
        else {
        return consumeables[consumeableIndex];
        }
    }
    private void RemoveConsumeable(object sender, ConsumeableUseEventArgs e) {
        consumeables.Remove(e.type);
    }

    private void ThrowablePickedUp(object sender, GameobjectSendEventArgs e) {
        if(throwObj == null) {
            if(consumeables.Count > 0) {
            Debug.Log(GetConsumeable().ToString());
            EventManager.instance.RemoveConsFromInv();
            }
            weapon.RemoveFromPlayer();
            DisableColliders(e.obj.GetComponent<DestryableItem>().col);
            throwObj = e.obj;
            throwObj.transform.position = throwPos.position;
            throwObj.transform.rotation = throwPos.rotation;
            throwObj.transform.SetParent(throwPos);
        }
    }
    public bool ThrowColl() {
        return (throwObj!=null);
    }
    public IThrowable GetThrowable() {
        return throwObj.GetComponent<IThrowable>();
    }
    public void ResThrowObj() {
        throwObj = null;
        if(molliUsed) {
            invTypeSel = 0;
        }
        SetInvIndex(invTypeSel);
    }
    private void DisableColliders(List<Collider> colls) {
        foreach (Collider item in colls)
        {
            item.enabled = false;
        }
    }
    System.Collections.IEnumerator ResetInvIndex() {
        yield return new WaitForSeconds(0.5f);
        if(throwObj == null) {
        SetInvIndex(0);
        }
    }
}
