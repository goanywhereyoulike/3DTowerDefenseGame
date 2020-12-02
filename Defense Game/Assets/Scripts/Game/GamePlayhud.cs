using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayhud : MonoBehaviour
{
    [SerializeField]
    Text EnemyPassed;


    [SerializeField]
    Text EnemyNumber;

    [SerializeField]
    Text PlayerLife;


    [SerializeField]
    Text timeText;

    [SerializeField]
    Image Gameoverpanel;

    [SerializeField]
    Text WinText;

    //[SerializeField]
    //private Button Resumebutton = null;

    //[SerializeField]
    //private Button Quitbutton = null;

    //UnitSpawner spawner;
    //LevelManager levelmngr;
    //SpawnManager spawnmngr;
    //FinalZone finalzone;
    //EnemyManager enemyMngr;
    //// Start is called before the first frame update
    //void Start()
    //{

    //    Gameoverpanel.gameObject.SetActive(false);
    //    levelmngr = FindObjectOfType<LevelManager>();
    //    enemyMngr = FindObjectOfType<EnemyManager>();
    //    levelmngr.OnEnemypassed += UpdateUIText;
    //    levelmngr.OnPlayerLose += GameOver;
    //    enemyMngr.OnEnemyChanged += UpdateUIText;
    //    enemyMngr.OnPlayerWin += PlayerWin;

    //}



    bool GamePause = false;
    public void Initialize()
    {
        Gameoverpanel.gameObject.SetActive(false);
        EnemyPassed.text = "Score: " + "0";
        timeText.text = "Time: " + "0";
        PlayerLife.text = "Player life: " + "3";
        EnemyPassed.text = "Enemy passed: " + "0";
        EnemyNumber.text = "Enemy left: " + "0";

        //Resumebutton.onClick.AddListener(Resume);
        //Quitbutton.onClick.AddListener(QuitGame);
    }

    public void SetGameplayHUDActive(bool shouldbeActive)
    {
        gameObject.SetActive(shouldbeActive);

    }

    public void UpdateTimeText(float time)
    {
        timeText.text = "Time: " + time;

    }
    //public void Resume()
    //{
    //    Panel.gameObject.SetActive(false);
    //    Time.timeScale = 1f;
    //    GamePause = false;
    //    Cursor.lockState = CursorLockMode.Locked;

    //}

    //public void Pause()
    //{
    //    Cursor.lockState = CursorLockMode.None;
    //    Panel.gameObject.SetActive(true);
    //    Time.timeScale = 0f;
    //    GamePause = true;
    //}

    //public void QuitGame()
    //{
    //    Application.Quit();

    //}

    public void UpdateUIText(int playerlife,int enemypassed)
    {
        PlayerLife.text = "Player life: " + playerlife.ToString();
        EnemyPassed.text = "Enemy passed: " + enemypassed.ToString();
        

    }

    public void UpdateEnemyKilled(int enemykilled)
    {
        EnemyNumber.text = "Enemy left: " + enemykilled.ToString();
    }

    public void GameOver()
    {
        Gameoverpanel.gameObject.SetActive(true);
        Time.timeScale = 0;

    }
    public void PlayerWin()
    {
        WinText.text = "You Win";
        Gameoverpanel.gameObject.SetActive(true);
        Time.timeScale = 0;

    }
}
