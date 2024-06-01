using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public int currentLevel = 1;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetLevel(int level)
    {
        currentLevel = level;
    }
}
