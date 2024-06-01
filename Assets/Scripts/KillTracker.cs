using UnityEngine;

public class KillTracker : MonoBehaviour
{
    public static bool hasKilledZombies = false;

    void Start()
    {
        hasKilledZombies = false;
    }

    public static void ZombieKilled()
    {
        hasKilledZombies = true;
        Debug.Log("Zombie killed");
    }
}
