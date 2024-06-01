using TMPro;
using UnityEngine;

public class LevelCompletion : MonoBehaviour
{
    public TextMeshProUGUI statusText;
    public int extraPoints = 1000;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (LevelManager.instance.currentLevel == 2)
            {
                if (!KillTracker.hasKilledZombies)
                {
                    PlayerScore.instance.AddPoints(extraPoints);
                    statusText.text = "Level Complete! Side Quest Completed! Extra Points: " + extraPoints;
                }
                else
                {
                    statusText.text = "Level Complete! But you killed zombies.";
                }
            }
            else
            {
                statusText.text = "Level Complete!";
            }
        }
    }
}
