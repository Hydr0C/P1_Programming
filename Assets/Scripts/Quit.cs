using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    public void EndGame()
    {
        Debug.Log("game over");
        Application.Quit();

    }
}
