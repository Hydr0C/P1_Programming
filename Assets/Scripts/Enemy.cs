using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Define the variables needed
    public int enemyHealth,
        attackDMG,
        xpValue,
        level;

    bool activeEnemy;
    bool enemyTurn;

    void Start()
    {
        // As this script has just started, no enemies will exist yet, and thus one will be spawned. 
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        // Checks if there is an enemy alive
        if(!activeEnemy)
        {
            SpawnEnemy();
        }
        // Checks if the alive enemy is actually alive
        if(enemyHealth < 1)
        {
            //If it's not alive, let me know it's dead
            activeEnemy = false;
            Debug.Log("Enemy ded");
        }
    }

    void SpawnEnemy()
    {
        // This sets the level to a random number between 1 & 5
        level = Random.Range(1, 6);
        Debug.Log("Level = " + level);

        // These are then set based on the new level
        enemyHealth = 10 * level;
        attackDMG = 5 + level;
        xpValue = 5 * level;

        activeEnemy = true;
    }
}
