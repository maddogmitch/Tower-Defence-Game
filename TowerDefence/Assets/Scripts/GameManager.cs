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
    //
    public int escapedEnemies;
    //
    public int maxAllowedEscapedEnemies = 5;
    //
    public bool enemySpawningOver;
    //
    public AudioClip gameWinSound;
    public AudioClip gameLoseSound;
    //
    private bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
