using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTowerSpawner : MonoBehaviour
{
    [SerializeField]
    List<Transform> Towertransforms;
    [SerializeField]
    int number2 = 4;
    // Start is called before the first frame update
    void Start()
    {
        SpawnMagicTower(number2);
    }



    private void SpawnMagicTower(int Number)
    {
        ObjectPoolManager poolManager = ServiceLocator.Get<ObjectPoolManager>();
        for (int i = 0; i < Number; ++i)
        {
            GameObject unitGO = poolManager.GetObjectFromPool("SlowTower");
            unitGO.SetActive(true);
            unitGO.transform.position = Towertransforms[i].position;
            unitGO.transform.rotation = Towertransforms[i].rotation;
            SlowTower tower = unitGO.GetComponent<SlowTower>();
            tower.Initialize();

        }
    }
}
