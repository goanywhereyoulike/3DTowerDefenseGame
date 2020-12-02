using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    bool EnemySpawn = false;
    public List<Enemy> enemies;
    private int totalenemies = 0;
    public int TotalEnemies { get { return totalenemies; } set { totalenemies = value; ServiceLocator.Get<UIManager>().UpdateEnemyDisplay(TotalEnemies); } }
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        
        if (TotalEnemies > 1)
        {
            EnemySpawn = true;
        }
       
        if (TotalEnemies == 0 && EnemySpawn)
        {
            ServiceLocator.Get<UIManager>().PlayerWin();
        }
    }
}
