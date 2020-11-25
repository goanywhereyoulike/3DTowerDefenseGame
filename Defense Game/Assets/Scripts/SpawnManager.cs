﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public List<UnitSpawner> Spawners;

    private WaypointManager _waipointManager;

    public int totalEnemy = 0;


    void Start()
    {
        foreach (UnitSpawner spawner in Spawners)
        {
            totalEnemy += spawner.Enemytotal;
        }
    }
    public void Initialize(WaypointManager wpMngr)
    {
        _waipointManager = wpMngr;
        foreach (UnitSpawner spawner in Spawners)
        {
            spawner.Init(_waipointManager.GetPath(spawner.pathId));
        }
    }

    public void StartSpawners()
    {
        foreach (UnitSpawner spawner in Spawners)
        {
            spawner.StartSpawner();
        }
    }
}
