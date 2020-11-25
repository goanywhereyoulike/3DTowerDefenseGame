using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    Text EnemyPassed;


    [SerializeField]
    Text EnemyNumber;

    [SerializeField]
    Text PlayerLife;

    [SerializeField]
    Image Gameoverpanel;

    [SerializeField]
    Text WinText;

    UnitSpawner spawner;
    LevelManager levelmngr;
    SpawnManager spawnmngr;
    FinalZone finalzone;
    EnemyManager enemyMngr;
    // Start is called before the first frame update
    void Awake()
    {

        Gameoverpanel.gameObject.SetActive(false);
        levelmngr = FindObjectOfType<LevelManager>();
        enemyMngr = FindObjectOfType<EnemyManager>();
        levelmngr.OnEnemypassed += UpdateUIText;
        levelmngr.OnPlayerLose += GameOver;
        enemyMngr.OnEnemyChanged += UpdateUIText;
        enemyMngr.OnPlayerWin += PlayerWin;

    }


    void UpdateUIText()
    {
        PlayerLife.text = "Player life: " + levelmngr.PlayerLife.ToString();
        EnemyPassed.text = "Enemy passed: " + levelmngr.Enenmypassed.ToString();
        EnemyNumber.text = "Enemy left: " + enemyMngr.TotalEnemies.ToString();

    }

    void GameOver()
    {
        Gameoverpanel.gameObject.SetActive(true);
        Time.timeScale = 0;

    }
    void PlayerWin()
    {
        WinText.text = "You Win";
        Gameoverpanel.gameObject.SetActive(true);
        Time.timeScale = 0;

    }
}
