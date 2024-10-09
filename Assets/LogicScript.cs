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
    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd) 
    { 
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
        if (playerScore <= 21)
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
    }
    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
