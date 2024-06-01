using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteraction : MonoBehaviour
{
    private bool isPlayerNearDoor = false;

    // A list of level names in the order they should be loaded.
    private string[] levels = new string[] { "Scene1", "Level1", "Level2", "Level3" };

    // Reference to the zombie spawner script
    public ZombieSpawn zombieSpawner;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearDoor = true;
            Debug.Log("Player is near the door.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearDoor = false;
            Debug.Log("Player has moved away from the door.");
        }
    }

    private void Update()
    {
        if (isPlayerNearDoor && Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("P key pressed. Door tag: " + gameObject.tag);
            if (gameObject.CompareTag("rightDoor"))
            {
                LoadNextLevel();
            }
            else if (gameObject.CompareTag("wrongDoor"))
            {
                SpawnMoreZombies();
            }
            else
            {
                Debug.LogError("Door has an unexpected tag.");
            }
        }
    }

    private void LoadNextLevel()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        Debug.Log("Current Scene: " + currentScene);
        int currentLevelIndex = System.Array.IndexOf(levels, currentScene);
        Debug.Log("Current Level Index: " + currentLevelIndex);
        if (currentLevelIndex >= 0 && currentLevelIndex < levels.Length - 1)
        {
            string nextScene = levels[currentLevelIndex + 1];
            Debug.Log("Loading Next Level: " + nextScene);
            SceneManager.LoadScene(nextScene);
        }
        else if (currentLevelIndex == levels.Length - 1)
        {
            string firstScene = levels[0];
            Debug.Log("Looping back to First Level: " + firstScene);
            SceneManager.LoadScene(firstScene);
        }
        else
        {
            Debug.LogError("The current scene is not in the levels list!");
        }
    }

    private void SpawnMoreZombies()
    {
        if (zombieSpawner != null)
        {
            Debug.Log("Spawning more zombies.");
            zombieSpawner.InvokeRepeating("EnemySpawner", 1f, 1f);
        }
        else
        {
            Debug.LogError("ZombieSpawner is not assigned!");
        }
    }
}

