using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceTowerSpawner : MonoBehaviour
{
    [SerializeField]
    List<Transform> Towertransforms;
    [SerializeField]
    int number=10;
    // Start is called before the first frame update
    void Start()
    {
        SpawnTower(number);
    }


    private void SpawnTower(int Number)
    {
        ObjectPoolManager poolManager = ServiceLocator.Get<ObjectPoolManager>();
        for (int i = 0; i < Number; ++i)
        {
            GameObject unitGO = poolManager.GetObjectFromPool("DefenceTower");
            unitGO.SetActive(true);
            unitGO.transform.position = Towertransforms[i].position;
            unitGO.transform.rotation = Towertransforms[i].rotation;
            DefeceTower tower = unitGO.GetComponent<DefeceTower>();
            tower.Initialize();

        }
    }
    private void MagicTower(int Number)
    {
        ObjectPoolManager poolManager = ServiceLocator.Get<ObjectPoolManager>();
        for (int i = 0; i < Number; ++i)
        {
            GameObject unitGO = poolManager.GetObjectFromPool("SlowTower");
            unitGO.SetActive(true);
            unitGO.transform.position = Towertransforms[i].position;
            unitGO.transform.rotation = Towertransforms[i].rotation;
            DefeceTower tower = unitGO.GetComponent<DefeceTower>();
            tower.Initialize();

        }
    }
}
