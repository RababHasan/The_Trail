using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public int maxHealth = 4;
    public int currentHealth;
    public GameObject gameOverUI;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        //this is a temporary code I will change it later
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            TakeDamage(1); // Adjust the damage value as per your requirement
        }
    }

    void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    void Die()
    {
        // Perform actions when the player dies
        // For example: End the game, show game over screen, etc.
        Debug.Log("Player died!");
        GameOver();
    }

    void GameOver()
    {
        // Show the game over screen
        gameOverUI.SetActive(true);
        Time.timeScale = 0f; // Pause the game

    }


}

