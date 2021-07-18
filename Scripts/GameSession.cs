using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] int Score = 0;


    [SerializeField] Text LivesDisplay;
    [SerializeField] Text ScoreDisplay;



     void Start()
    {
        LivesDisplay.text = playerLives.ToString();
        ScoreDisplay.text = Score.ToString();
    }

    private void Awake()
    {
        int gameSession = FindObjectsOfType<GameSession>().Length;
        if(gameSession > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void AddToScore(int ScorePoint)
    {
        Score += ScorePoint;
        ScoreDisplay.text = Score.ToString();
    }
    public int GetScore()
    {
        return Score;
    }
    public void PlayerDeath()
    {
        if(playerLives > 1)
        {
            DecreaseLife();
        }
        else
        {
            ResetGameSession();
        }
    }

   private void DecreaseLife()
    {
        playerLives--;
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        LivesDisplay.text = playerLives.ToString();
    }
    
    public void ResetGameSession()
    {
        
        SceneManager.LoadScene(3);
        Destroy(gameObject);
    }
    public void StartMainMenu()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

   

   

}
