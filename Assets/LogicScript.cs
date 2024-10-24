using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
// Using scene management so I can reset scene.
using UnityEngine.AI;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    // Player score, public so it can be accessed by other players. Int because score should be whole number.
    public GameObject gameOverScreen;
    // Reference to gameOverScreen game object. Public so I can reference it in Unity.
    public Text scoreText;
    // Reference to text, public for the same reason.
    public int speedIncrease = 0;
    // speed increase variable, must be int as I intend speed increase to be whole numbers only. Public so other classes can access.
    private int db = 0;
    // debouce variable. Int because must be whole number, private becuase not used anywhere else.
    private int pipesPast = 1;
    // same reason.
    public AudioSource dingSFX;
    public AudioSource restartSFX;
    public AudioSource clickSFX;
    public AudioSource gameOverSFX;
    public AudioSource gameMusic;
    // all these are references to audiosources. Public so I can reference them in Unity.
    public bool gameIsOver = false;
    // checks if game is over. Is a bool as it can either be true or false. Public as it is used in GhostScript.
    // context menu allows me to test this addScore method manually in Unity.
    [ContextMenu("Increase Score")]
    // context menu allows me to test this addScore method manually in Unity.
    // addScore method adds score. ScoreToAdd parameter determines the score to add. 
    public void addScore(int scoreToAdd, bool isPipePassed)
    {
        if (gameIsOver == false)
        {
            dingSFX.Play();
            // play ding sound.
            playerScore = playerScore + scoreToAdd;
            // add player score by the scoreToAdd value. 
            scoreText.text = playerScore.ToString();
            // Since score currently only increases when player passes a pipe, this method can be used to check how many pipes past.
            // Checks if the score increase is from passing a pipe. If true then the pipesPast variable can increase and speedUp game if necessary. 
            if (isPipePassed)
            {
                pipesPast++;
                if (pipesPast <= 21)
                {
                    if (db == 2)
                    {
                        // increases speed every 3 pipes.
                        speedIncrease++;
                        db = 0;
                        // reset db so the cycle can repeat itself.
                    }
                    else
                    {
                        // if db is not 2 then add 1 to db.
                        db++;
                    }
                }
            }
        }
    }
    // method that restarts the game when called.
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // reloads the current scene.
        // clickSFX.Play();
        // restartSFX.Play();
    }
    // method that shows the game over screen and plays the game over tune while also stopping the background music. 
    public void gameOver()
    {
        // This ensures that the code inside the block only runs once. (since collisions2D may fire multiple times as the bird slides down the pipe.)
        if (gameIsOver == false)
        {
            gameIsOver = true;
            // sets game over to true so it cant run again.
            gameMusic.Stop();
            // stops the background music.
            gameOverSFX.Play();
            // plays gameover sound.
            gameOverScreen.SetActive(true);
            // makes gameOverSCreen visible.
        }
    }
}

