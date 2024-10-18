using UnityEngine;

public class Inventar : MonoBehaviour
{
    [SerializeField] Transform mainHand;
    [SerializeField] Transform offHand;
    public void Add(GameObject obj) {
        if(mainHand.childCount == 0) {
            obj.transform.position = mainHand.position;
            obj.transform.SetParent(mainHand);
        }
        else if(offHand.childCount == 0) {
            obj.transform.position = offHand.position;
            obj.transform.SetParent(offHand);
        }
    }
    public void Drop() {
        if(mainHand.childCount == 1) {
            Transform trans = mainHand.GetChild(0);
            trans.SetParent(null);
        }
    }
}
