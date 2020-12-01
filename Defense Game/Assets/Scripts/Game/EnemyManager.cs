using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    bool EnemySpawn = false;
    public List<Enemy> enemies;
    private int totalenemies = 0;
    public int TotalEnemies { get { return totalenemies; } set { totalenemies = value; } }
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        foreach (Enemy enemy in enemies)
        {
            if (enemy == null)
            {
                continue;
            }
            if (!enemy.gameObject.activeInHierarchy)
            {
                enemies.Remove(enemy);

            }
        }
        TotalEnemies = enemies.Count;
        if (TotalEnemies > 1)
        {
            EnemySpawn = true;
        }
        ServiceLocator.Get<UIManager>().UpdateEnemyDisplay(TotalEnemies);
        if (TotalEnemies == 0 && EnemySpawn)
        {
            ServiceLocator.Get<UIManager>().PlayerWin();
        }
    }
}
