using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class MenuControl : MonoBehaviour
{
    [SerializeField] private GameObject button;
    void Start()
    {
        StartCoroutine(WaitForVideo());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator WaitForVideo()
    {
        yield return new WaitForSeconds(4f);
        button.SetActive(true);
    }
}
