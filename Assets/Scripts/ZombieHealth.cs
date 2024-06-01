using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private Animator animator;
    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        animator.SetTrigger("Die");
        // Disable other zombie behaviors
    }
}
