using UnityEngine;

namespace ZombieGame
{
    public class ZombieController : MonoBehaviour
    {
        public enum ZombieType { Zombie1, Zombie2, Zombie3 }
        public ZombieType type;

        public int maxHealth;
        private int currentHealth;
        private Animator animator;

        // Health settings based on zombie type
        private void InitializeHealth()
        {
            switch (type)
            {
                case ZombieType.Zombie1:
                    maxHealth = 100; // Lowest health
                    break;
                case ZombieType.Zombie2:
                    maxHealth = 150; // Medium health
                    break;
                case ZombieType.Zombie3:
                    maxHealth = 200; // Highest health
                    break;
            }
        }

        void Start()
        {
            InitializeHealth();
            currentHealth = maxHealth;
            animator = GetComponent<Animator>();
            SetZombieTag();
        }

        public void TakeDamage(int amount)
        {
            currentHealth -= amount;
            if (currentHealth <= 0)
            {
                Die();
            }
        }

        private void SetZombieTag()
        {
            switch (type)
            {
                case ZombieType.Zombie1:
                    gameObject.tag = "Zombie1";
                    break;
                case ZombieType.Zombie2:
                    gameObject.tag = "Zombie2";
                    break;
                case ZombieType.Zombie3:
                    gameObject.tag = "Zombie3";
                    break;
            }
        }

        void Die()
        {
            // Trigger death animation based on zombie type
            switch (type)
            {
                case ZombieType.Zombie1:
                    animator.SetTrigger("Z_FallingForward"); // Or relevant animation trigger
                    break;
                case ZombieType.Zombie2:
                    animator.SetTrigger("Z_FallingBack"); // Or relevant animation trigger
                    break;
                case ZombieType.Zombie3:
                    animator.SetTrigger("Z_FallingSideways"); // Or relevant animation trigger
                    break;
            }

            // Destroy the zombie object after a delay
            Destroy(gameObject, 2.0f);
        }
    }
}

