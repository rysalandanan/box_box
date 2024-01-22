using UnityEngine;

public class PlayAnimationWhenCollided : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            animator.Play("Jump-pad_Animation");
        }
    }
}
