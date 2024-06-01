using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using ZombieGame;

public class SafeAreaController : MonoBehaviour
{
   
    private bool playerInside;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player character
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the safe area! Zombie attacks disabled.");

            playerInside = true;
            ApplySafetyEffects();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            RemoveSafetyEffects();
        }
    }

    private void ApplySafetyEffects()
    {
        // The player has entered the safe area, apply safety effects

       
        //This assumes that your zombies are controlled by a script called ZombieController
        // Disable zombie attacks
        ZombieController[] zombies = FindObjectsOfType<ZombieController>();
        foreach (ZombieController zombie in zombies)
        {
            /*
                We then iterate through each zombie and call a method (DisableAttacks())
               to disable their attacks. You would need to implement the DisableAttacks() 
               method in your ZombieController script to stop the zombies from attacking.
                */
            //zombie.DisableAttacks();
        }

      

        Debug.Log("Player entered the safe area! Zombie attacks disabled.");
    }

    private void RemoveSafetyEffects()
    {
        // Enable zombie attacks
        ZombieController[] zombies = FindObjectsOfType<ZombieController>();
        foreach (ZombieController zombie in zombies)
        {
            //implement the EnableAttacks() method in your ZombieController script
            //zombie.EnableAttacks();
        }

        // Add any other effects or actions you want when leaving the safe area

        Debug.Log("Player left the safe area! Zombie attacks enabled.");
    }
}
