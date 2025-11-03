using UnityEngine;

public class swordScript : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Swing");
        }
    }
}