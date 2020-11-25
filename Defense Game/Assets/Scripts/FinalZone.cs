using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalZone : MonoBehaviour
{
    public event Action OnEnemyPassed;
    private int enemypassed = 0;
    public int Enemypassed
    { get { return enemypassed; }set { enemypassed = value; OnEnemyPassed?.Invoke(); } }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            Destroy(other.gameObject);
            Enemypassed++;
        }
    }

  
}
