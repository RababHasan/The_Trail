using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    public Transform player;
    public float detectionRange = 10f;
    public float runningRange = 5f;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        if (distanceToPlayer <= detectionRange)
        {
            if (distanceToPlayer <= runningRange)
            {
                animator.SetBool("isRunning", true);
                animator.SetBool("isWalking", false);
            }
            else
            {
                animator.SetBool("isRunning", false);
                animator.SetBool("isWalking", true);
            }
        }
        else
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isWalking", false);
        }
    }
}
