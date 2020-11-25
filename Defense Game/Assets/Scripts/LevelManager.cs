using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public event Action OnPlayerLose;
    public event Action OnEnemypassed;

    public WaypointManager waypointManager;
    public SpawnManager spawnManager;
    private FinalZone finalzone;

    private int playerlife = 3;
    public int PlayerLife
    {
        get
        {
            return playerlife;
        }
        set
        {
            playerlife = value;
            if (playerlife <= 0)
            {
                OnPlayerLose?.Invoke();
            }
        }
    }

    public int Enenmypassed = 0;
    public int totalEnemy = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (spawnManager != null)
        {
            spawnManager.Initialize(waypointManager);
            spawnManager.StartSpawners();
        }
        else
        {
            Debug.Log("SpawnManager is NULL!");
        }
        finalzone = FindObjectOfType<FinalZone>();
        finalzone.OnEnemyPassed += () => { PlayerLife--; Enenmypassed++; OnEnemypassed?.Invoke(); };
    }



}
