using UnityEngine;

public class AxeAnim : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        EventManager.instance.AttackEvent += (sender, e) => {animator.SetTrigger("Anim"); Debug.Log("Anim");};

    }
}
