using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour {

    GameObject[] enemies;
    int enemiesLeft;

    public void CheckEnemies()
    {   
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesLeft = enemies.Length;
    }

    public void DestoryEnemy()              // Tracks enemies left on the map
    {
        enemiesLeft -= 1;
        if (enemiesLeft <= 0)
        {
            print("you win");
        }
    }
}
