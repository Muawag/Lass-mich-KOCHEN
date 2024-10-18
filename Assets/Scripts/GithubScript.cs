using UnityEngine;

public class GithubScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Test");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)) {
            AudioManager.instance.PlayOneShot(FMODEvents.instance.testSFX, transform.position);
        }
    }
}
