using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public static PlayerScore instance;
    public TextMeshProUGUI scoreText;
    private int score = 0;

    void Awake()
    {
        instance = this;
    }

    public void AddPoints(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
        Debug.Log("Points added: " + points + " New score: " + score);
    }
}
