using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public event Action OnEnemyChanged;
    public event Action OnPlayerWin;
    public List<Enemy> enemies;
    private int totalenemies = 18;
    public int TotalEnemies { get { return totalenemies; }set { totalenemies = value; OnEnemyChanged?.Invoke(); } }
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        foreach (Enemy enemy in enemies)
        {
            if (enemy == null)
            {
                enemies.Remove(enemy);
            }
        }
        TotalEnemies = enemies.Count;
        StartCoroutine(CalculateEnemynumber());
    }

    private IEnumerator CalculateEnemynumber()
    {
        yield return new WaitForSeconds(5.0f);
        if (TotalEnemies == 0)
        {
            OnPlayerWin?.Invoke();
        }
    }
}
