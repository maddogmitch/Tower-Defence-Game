using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    // static variable for global access
    public static GameManager Instance;
    //amount of gold player has
    public int gold;
    //num of wave currently being spawned
    public int waveNumber;
    //enemies that make it out
    public int escapedEnemies;
    //num aloud to escape before game over
    public int maxAllowedEscapedEnemies = 5;
    //used to check if the game is spoawning enemies or not
    public bool enemySpawningOver;
    //win and lose audio clips
    public AudioClip gameWinSound;
    public AudioClip gameLoseSound;
    //bool to tell if game is over or not
    private bool gameOver;


    // set the instance to this script 
     void Awake()
     {
        Instance = this;   
     }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver && enemySpawningOver)
        {
            //check if no enemies left if so win 
            if (EnemyManager.Instance.Enemies.Count==0)
            {
                OnGameWin();
            }
        }

        //escape key to go to title screen
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitToTitleScreen();
        }
    }
    //win the game
    private void OnGameWin()
    {
        AudioSource.PlayClipAtPoint(gameWinSound,Camera.main.transform.position);
        gameOver = true;
        UIManager.Instance.ShowWinScreen();
    }
    //escape key goes to title screen
    public void QuitToTitleScreen()
    {
        SceneManager.LoadScene("TitleScreen");
    }
    //check the num of enemies escaped to see if you lose or not
    public void OnEnemyEscape()
    {
        escapedEnemies++;
        if (escapedEnemies == maxAllowedEscapedEnemies)
        {
            // Too many enemies escaped, you lose the game
            OnGameLose();
        }
    }
    //lose the game
    private void OnGameLose()
    {
        gameOver = true;
        AudioSource.PlayClipAtPoint(gameLoseSound,Camera.main.transform.position);

        EnemyManager.Instance.DestroyAllEnemies();
        WaveManager.Instance.StopSpawning();
        UIManager.Instance.ShowLoseScreen();
    }
    //restart
    public void RetryLevel()
    {
        SceneManager.LoadScene("Game");
    }
}
