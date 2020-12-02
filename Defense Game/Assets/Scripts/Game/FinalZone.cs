using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalZone : MonoBehaviour
{

    private int enemypassed = 0;
    public int Enemypassed
    { get { return enemypassed; }set { enemypassed = value; if (Enemypassed >= 3) { ServiceLocator.Get<UIManager>().GameOver(); }   } }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.IsDead = true;
            enemy.ResetAndRecycle();
            FindObjectOfType<EnemyManager>().TotalEnemies--;
            Enemypassed++;
            ServiceLocator.Get<UIManager>().UpdateGameDisplay(3 - Enemypassed, Enemypassed);
            
        }
    }

}
