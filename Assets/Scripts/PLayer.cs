using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PLayer : MonoBehaviour
{
    //From here until start is setting up all the variables (not assigning things yet), all spacing is for legibility/aesthetic purposes. 

    public Enemy enemyScript;

    public TMP_Text playerText, attackButtText, healButtText, endText;
    public Button attackButt, healButt, lvlUp;
    public GameObject endGamePanel, inGamePanel;

    private int playerMaxHealth,
        healthPotions, 
        testingVar;
        
    public int level, 
        playerHealth;
    
    private float expPoints,
        attackDmg, //THE ATTACK STUFF IS AN INT BUT NOT HERE, LOOK IN THE ATTACK FUNCTION I JUST NEEDED IT TO CALCULATE NICELY
        lvlUpThreshhold;

    // Start is called before the first frame update
    void Start()
    {
        // Assigns all the variables their base numbers
        level = 1;
        expPoints = 0f;
        lvlUpThreshhold = 20f;
        playerHealth = 100;
        playerMaxHealth = 50;
        healthPotions = 5;
        attackDmg = 5 * (level * 1.25f);

        attackButt.gameObject.SetActive(true);
        healButt.gameObject.SetActive(true);

        testingVar = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Displays the player's stats
        playerText.SetText("HP: " + playerHealth + ", Level: " + level + ", Damage: " + attackDmg);

        // Checks if the player can level up
        if (expPoints >= lvlUpThreshhold)
        {
            lvlUp.interactable = true;
        }
        else
        {
            lvlUp.interactable = false;
        }
        // if we still goin (no one dead or won)
        if (level < 5 && playerHealth > 0)
        {
            //if its the player's turn
            if(!enemyScript.enemyTurn)
            {
                // Player can attack or heal
                attackButtText.SetText("Attack");
                healButtText.SetText("Heal (" + healthPotions + " left)");

                // Allows players to press button and continue their turn (unless thyre out of potions, then they cant prezs that)
                attackButt.interactable = true;
                if (healthPotions > 0)
                {
                    healButt.interactable = true;
                }
            }
            else
            {
                // Stops player from acting out of their turn
                attackButt.interactable = false;
                healButt.interactable = false;
            }
        }
        else
        {
            EndGame();
        }
    }

    public void Attack()
    {
        // This subtracts the damage from the health
        int attInt = (int)Mathf.Round(attackDmg); //SEE IT'S AN INT
        //Debug.Log("damage: " + attInt);

        enemyScript.enemyHealth -= attInt;
        
        // If the enemy dies, this will give the player XP
        if (enemyScript.enemyHealth < 0)
        {
            expPoints += enemyScript.xpValue;
            Debug.Log("EXP: " + expPoints);
        }
        
        // Ends the player's turn
        enemyScript.enemyTurn = true;
    }

    public void Heal()
    {
        testingVar++;

        // Needed so the player doesn't get infinite health
        if(healthPotions > 0)
        {
            //Debug.Log("potion count: " + healthPotions);
            // This will ensure the player does not go over their maximum health
            playerHealth += 15 * level;
            if (playerHealth > playerMaxHealth)
            {
                playerHealth = playerMaxHealth;
            }
            // Remove 1 potion
            healthPotions--;
            //Debug.Log("potion count: " + healthPotions);

            // Updates potion count
            healButtText.SetText("Heal (" + healthPotions + " left)");
        }

        // this will deactivate the button so player's don't waste turns
        if (healthPotions == 0)
        {
            healButt.interactable = false;
        }

        // Ends the player's turn
        enemyScript.enemyTurn = true;
        //Debug.Log("healed " + testingVar);
    }

    public void LevelUp()
    {
        // Levels up the player, increases the level up threshhold, resets xp, increases attack damage and checks if the level up worked.
        level++;
        lvlUpThreshhold = 20 + (level * 10);
        expPoints = 0f;
        attackDmg = 5 * (level * 1.25f);
        Debug.Log("Levelled up, base dmg: " + attackDmg);
    }

    public void EndGame()
    {
        if(level >= 5)
        {
            //Game won
            endText.SetText("Ayy good job :)) you win ");
        }
        else if(playerHealth <= 0)
        {
            // Game Lost
            endText.SetText("L you died");
        }
        attackButt.gameObject.SetActive(false); 
        healButt.gameObject.SetActive(false);

        endGamePanel.SetActive(true);
    }
}
