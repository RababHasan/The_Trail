using UnityEngine;
using UnityEngine.SceneManagement;
public class Navigate : MonoBehaviour
{
    public void goToScene(string sceneName)
    {
        // Find the player controller object in the scene
        PlayerController playerController = FindObjectOfType<PlayerController>();

        // Access properties or methods of the player controller script
        if (playerController != null)
        {
            // Example: Disable character movement before loading the new scene
            playerController.enabled = true;
        }

        // Load the new scene
        SceneManager.LoadScene(sceneName);
        playerController.enabled = true;
    }

    public static bool GameIsPaused = false;

    public GameObject PausedMenuUI;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        PausedMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        PausedMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    /*public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    } */
    public void ExitGame()
    {
        Debug.Log("Exiting game...");
        Application.Quit();
    }



    //For scene 1 navigation to Level1
    // Calling this method when the player interacts with the door
    public void InteractWithDoor()
    {
        goToScene("Level1");
    }

    // Example method for player's interaction with the door
    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
            // You can also check for a key press here if you want to require the player to press a button to interact
            InteractWithDoor();
        } 
    }
    


}
