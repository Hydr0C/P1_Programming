using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PLayer : MonoBehaviour
{
    public Enemy enemyScript;

    public TMP_Text playerText, attackButt, healButt;

    private int level,
        playerHealth,
        attackDmg,
        healthPotions;
        
    private float expPoints, 
        lvlUpThreshhold;

    

    // Start is called before the first frame update
    void Start()
    {
        level = 1;
        expPoints = 0f;
        lvlUpThreshhold = 20f;
        playerHealth = 50;
        attackDmg = 5 + (level * 2);
        healthPotions = 5;
    }

    // Update is called once per frame
    void Update()
    {
        playerText.SetText("HP: " + playerHealth + ", Level: " + level + ", Damage: " + attackDmg);

        if (expPoints >= lvlUpThreshhold)
        {
            level++;
            lvlUpThreshhold = 20 + (level * 10);
            expPoints = 0f;
            attackDmg = 5 + (level * 2);
        }
        if (level < 5 && playerHealth > 1)
        {
            if(!enemyScript.enemyTurn)
            {
                // Player can attack or heal
                attackButt.SetText("Attack");
                healButt.SetText("Heal (" + healthPotions + " left)");
            }
        }
    }
}
