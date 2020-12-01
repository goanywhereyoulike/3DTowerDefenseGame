using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    public GameObject UnitPrefab;
    public int numberOfWaves;
    public int enemiesPerWave;
    public int secondsBetweenWaves;
    public int secondsStartDelay;
    public int pathId;
    public int Enemytotal = 0;
    private int _currentWave = 0;
    EnemyManager enemyMngr;
    private WaypointManager.Path _path;

    public void Init(WaypointManager.Path path)
    {
        _path = path;
    }

    public void StartSpawner()
    {
        StartCoroutine("BeginWaveSpawn");
        Enemytotal = numberOfWaves * enemiesPerWave;
    }

    private IEnumerator BeginWaveSpawn()
    {
        yield return new WaitForSeconds(secondsStartDelay);

        while (_currentWave < numberOfWaves)
        {
            yield return SpawnWave(_currentWave++);
            yield return new WaitForSeconds(secondsBetweenWaves);
        }
    }

    private IEnumerator SpawnWave(int waveNumber)
    {
        ObjectPoolManager poolManager = ServiceLocator.Get<ObjectPoolManager>();
        for (int i = 0; i < enemiesPerWave; ++i)
        {
            GameObject unitGO = poolManager.GetObjectFromPool("Enemies");
            unitGO.SetActive(true);
            unitGO.transform.position = transform.position;
            unitGO.transform.rotation = transform.rotation;
            //Instantiate(UnitPrefab, transform.position, Quaternion.identity);
            Enemy enemy = unitGO.GetComponent<Enemy>();
            enemyMngr = FindObjectOfType<EnemyManager>();
            enemyMngr.enemies.Add(enemy);
            enemyMngr.TotalEnemies++;
            enemy.Initialize(_path);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
