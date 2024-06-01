using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using ZombieGame; // Assuming ZombieGame namespace contains necessary classes

public class NPCController : MonoBehaviour
{
    public float followRange = 10f; // Distance at which NPC will start following the player
    public float attackRange = 2f; // Range at which NPC will attack zombies
    public float detectionRadius = 20f; // Radius for detecting nearby zombies
    public int damage = 10; // Damage dealt to zombies
    public float attackCooldown = 2f; // Time between attacks

    private NavMeshAgent agent; // Navigation agent for NPC movement
    private float nextAttackTime = 0f; // Timer for next attack
    private Transform player; // Reference to the player

    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // Get the NavMeshAgent component
        player = GameObject.FindGameObjectWithTag("Player").transform; // Find the player by tag
        if (player == null)
        {
            Debug.LogError("Player not found. Ensure the player GameObject is tagged as 'Player'.");
        }
    }

    void Update()
    {
        if (player == null) return;

        // Calculate the distance between the player and NPC
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        // If the NPC is within the follow range, follow the player
        if (distanceToPlayer <= followRange)
        {
            agent.SetDestination(player.position);
            Debug.Log("Following player. Distance to player: " + distanceToPlayer);
        }

        // Find the closest zombie within detection radius
        GameObject closestZombie = FindClosestZombie();
        if (closestZombie != null)
        {
            float distanceToZombie = Vector3.Distance(closestZombie.transform.position, transform.position);
            // If the zombie is within attack range, attack it
            if (distanceToZombie <= attackRange && Time.time >= nextAttackTime)
            {
                AttackZombie(closestZombie);
                nextAttackTime = Time.time + attackCooldown;
                Debug.Log("Attacking zombie. Distance to zombie: " + distanceToZombie);
            }
            // Otherwise, move towards the zombie if player is far away
            else if (distanceToPlayer > followRange)
            {
                agent.SetDestination(closestZombie.transform.position);
                Debug.Log("Moving towards zombie. Distance to zombie: " + distanceToZombie);
            }
        }
    }

    // Find the closest zombie within the detection radius with tags "Zombie1" or "Zombie2"
    GameObject FindClosestZombie()
    {
        // Find all game objects with tag "Zombie1" and "Zombie2"
        GameObject[] zombies1 = GameObject.FindGameObjectsWithTag("Zombie1");
        GameObject[] zombies2 = GameObject.FindGameObjectsWithTag("Zombie2");

        GameObject closest = null;
        float shortestDistance = detectionRadius;

        // Check all "Zombie1" tagged game objects
        foreach (GameObject zombie in zombies1)
        {
            float distance = Vector3.Distance(zombie.transform.position, transform.position);
            if (distance < shortestDistance)
            {
                closest = zombie;
                shortestDistance = distance;
            }
        }

        // Check all "Zombie2" tagged game objects
        foreach (GameObject zombie in zombies2)
        {
            float distance = Vector3.Distance(zombie.transform.position, transform.position);
            if (distance < shortestDistance)
            {
                closest = zombie;
                shortestDistance = distance;
            }
        }

        if (closest != null)
        {
            Debug.Log("Closest zombie found: " + closest.name + " at distance " + shortestDistance);
        }

        return closest;
    }

    // Damage the zombie
    void AttackZombie(GameObject zombie)
    {
        ZombieController zombieHealth = zombie.GetComponent<ZombieController>(); // Assume ZombieController handles zombie health
        if (zombieHealth != null)
        {
            zombieHealth.TakeDamage(damage); // Apply damage to the zombie
            Debug.Log("Dealt " + damage + " damage to zombie: " + zombie.name);
        }
    }
}
