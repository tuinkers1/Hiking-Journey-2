using UnityEngine;

public class SwingTrigger : MonoBehaviour
{
    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Check for click input
        if (Input.GetMouseButtonDown(0))
        {
            // Trigger the animation
            animator.SetTrigger("Swing");
        }
    }
}