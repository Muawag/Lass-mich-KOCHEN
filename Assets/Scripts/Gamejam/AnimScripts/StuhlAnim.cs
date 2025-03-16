using UnityEngine;

public class StuhlAnim : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha5)) {
            animator.SetTrigger("Anim1");

        }
        else if(Input.GetKeyDown(KeyCode.Alpha6)) {
            animator.SetTrigger("Anim2");
        }
    }
}
