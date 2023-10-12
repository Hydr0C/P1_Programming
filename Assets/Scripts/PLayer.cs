using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayer : MonoBehaviour
{
    public Enemy enemyScript;

    private int level,
        playerHealth,
        attackDmg,
        expPoints;

    

    // Start is called before the first frame update
    void Start()
    {
        level = 1;
        expPoints = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
