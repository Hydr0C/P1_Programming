using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public PLayer playerScript;

    // Define the variables needed
    public int enemyHealth,
        attackDMG,
        xpValue,
        level;

    bool activeEnemy;
    public bool enemyTurn;

    public TMP_Text enemyStats, enemyText, whomstTurn; 

    void Start()
    {
        // As this script has just started, no enemies will exist yet, and thus one will be spawned. 
        SpawnEnemy();
        enemyTurn = false; 
    }

    // Update is called once per frame
    void Update()
    {
        // Checks if there is an enemy alive
        if(!activeEnemy)
        {
            SpawnEnemy();
        }
        
        //Displays the enemy's stats
        enemyStats.SetText("HP: " + enemyHealth + ", Level: " + level + ", Damage: " + attackDMG);
        
        // Checks if the alive enemy is actually alive
        if(enemyHealth < 1)
        {
            //If it's not alive, let me know it's dead
            activeEnemy = false;
            Debug.Log("Enemy ded");
        }
        else if (enemyTurn)
        {
            whomstTurn.SetText("Turn: Enemy");
            enemyText.SetText("The enemy attacks!!! take " + attackDMG + " damage!");
            
            playerScript.playerHealth -= attackDMG;
            enemyTurn = false;
            whomstTurn.SetText("Turn: Player");
        }
    }

    void SpawnEnemy()
    {
        // This sets the level to a random number between 1 & 5
        level = Random.Range(1, 6);
        Debug.Log("Level = " + level);

        //WIll hopefully make sure enemies are a maximum of 1 level higher than the player and hopefully will not crash everything (saving before i test lol) IT DIDNT LETS GO
        if(level > playerScript.level + 1)
        {
            SpawnEnemy();
        }

        // These are then set based on the new level
        enemyHealth = 10 * level;
        attackDMG = 5 + level;
        xpValue = 5 * level;

        activeEnemy = true;
        enemyText.SetText("A wild enemy appears!");
        Debug.Log("A wild enemy appears!");
        whomstTurn.SetText("Turn: Player");
    }
}
