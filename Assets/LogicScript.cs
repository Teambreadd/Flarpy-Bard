using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public GameObject gameOverScreen;
    public Text scoreText;
    public int speedIncrease = 0;
    public int db = 0;
    private int pipesPast = 1;
    public AudioSource dingSFX;
    public AudioSource restartSFX;
    public AudioSource clickSFX;
    public AudioSource gameOverSFX;
    public AudioSource gameMusic;
    private bool gameIsOver = false;
    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd) 
    { 
        dingSFX.Play();
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
        pipesPast++;
        if (pipesPast <= 21)
        {
            if (db == 2)
            {
                speedIncrease++;
                db = 0;
            } else 
            {
                db++;
            }
        }
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // clickSFX.Play();
        // restartSFX.Play();
    }
    public void gameOver()
    {
        if (gameIsOver == false)
        {
            gameIsOver = true;
            gameMusic.Stop();
            gameOverSFX.Play();
            gameOverScreen.SetActive(true);
        }
    }
}

