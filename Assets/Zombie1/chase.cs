using UnityEngine;

public class chase : MonoBehaviour
{
    public Transform player;
    public PlayerHealth ph;
    static Animator anim;
    public detectHit dethit;
    public float moveSpeed = 3f; // Adjust the speed as necessary
    public float attackRange = 2f; // Adjust the attack range as necessary
    public float timeBetweenAttacks = 1f;
    public int attackDamage = 10;
    float attackTimer;

    // Define state constants
    const int IdleState = 0;
    const int WalkingState = 1;
    const int AttackingState = 2;
    const int DeadState = 3;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (dethit.currentHealth > 0)
        {
            Vector3 direction = player.position - transform.position;
            float angle = Vector3.Angle(direction, transform.forward);

            // Debug direction and angle
            Debug.DrawRay(transform.position, direction, Color.red);
            Debug.Log("Angle: " + angle);

            if (Vector3.Distance(player.position, transform.position) < 50 && angle < 360)
            {
                direction.y = 0;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.1f);

                anim.SetInteger("state", WalkingState); // Set the state to walking

                // Move the zombie towards the player
                transform.position += transform.forward * moveSpeed * Time.deltaTime;

                // Check if the zombie is within attacking range
                if (direction.magnitude <= attackRange)
                {
                    Attack();
                }
                else
                {
                    attackTimer = 0f; // Reset attack timer if not attacking
                }
            }
            else
            {
                anim.SetInteger("state", IdleState); // Set the state to idle
            }
        }
        else
        {
            anim.SetInteger("state", DeadState); // Set the state to dead
        }
    }

    void Attack()
    {
        attackTimer += Time.deltaTime;

        if (attackTimer >= timeBetweenAttacks)
        {
            anim.SetInteger("state", AttackingState); // Set the state to attacking
           // ph.TakeDamage(attackDamage);
            attackTimer = 0f;
        }
    }
}
