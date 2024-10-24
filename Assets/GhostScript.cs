using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostScript : MonoBehaviour
{
    public float moveSpeed = 7;
    // movespeed variable determines the ghosts movespeed. Set to a default value of 1. Is public so it can be accessed in Unity if needed, and is an integer as it (currently) stays a whole number.
    private float originalMoveSpeed;
    // Variable for original movespeed. is a float as it could be a decimal and is private as it is only required in this script. 
    private BirdScript birdScript;
    // BirdScript referenced when the object is created. 
    private BoxCollider2D boxCollider2D;
    // reference to the boxCollider2D component. Set in Unity. This script and the boxCollider share the same parent so it can be referenced in Unity.
    public LogicScript logic; 
    // Logic script referenced in Unity. 
    private AudioSource hitSFX;
     // Start is called before the first frame update
    void Start()
    {
        birdScript = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();
        // When the object is instantiated in the scene, find the GameObject tagged as "Bird" and get its BirdScript component.
        AudioSource[] audioSources = GameObject.FindGameObjectWithTag("Bird").GetComponents<AudioSource>();
        hitSFX = audioSources[1];  // This gets the second audiosource in the list (HitSFX)
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        // When the object is instantiated in the scene, find the GameObject tagged as "Logic" and get its LogicScript component.
        originalMoveSpeed = moveSpeed;
        // Set original movespeed to moveSpeed. 

    }
    // Event listener that checks for objects passing through it. (e.g., the bird)
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (logic.gameIsOver == false)
        {
            // Checks if the gameOver variable is set to true. If not, run the following code. (It won't run again as the gameOver() method in the logic script will set the gameIsOver variable to true.)
            // I should have done this in all the other scripts instead of the db variable. 
            if (collision.gameObject.layer == 3)
            {
                hitSFX.Play();
                // Plays the hit sound effect. 
                logic.gameOver();
                // If the colliding object is in layer 3, (which is assigned to only the bird) call the gameOVer method. (This is to prevent the addscore method from firing when it detects pipes)
                birdScript.birdIsAlive = false;
                // Set the birdScript's birdIsAlive to false.
                Destroy(gameObject);
                // arrow is set to collision layer 6. 
            } else if (collision.gameObject.layer == 6)
            {
                // adds 1 score. 
                logic.addScore(1, false);
                // Destroys the arrow and ghost. 
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        // Moves the ghost across the screen at a speed set by moveSpeed. Time.deltaTime ensures that the ghost moves at the same rate regardless of frame rate.
        if (transform.position.x < -35.3)
        {
            // Checks if the ghost has moved offscreen.
            Destroy(gameObject);
            // If true, destroys game object.
        }
        moveSpeed = originalMoveSpeed;
        // Set moveSpeed back to Original moveSpeed.
        moveSpeed += logic.speedIncrease;
        // Explained it in the PipeMoveScript.
    }
}
