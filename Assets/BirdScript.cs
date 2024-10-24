using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRidgidbody;
    // reference to the ridid body. Public so I can set it in Unity.
    public float flapStrength;
    // flapStrength variable. Public as it is set in Unity.
    public LogicScript logic; 
    // reference to the logic script. 
    public bool birdIsAlive = true;
    // birdIsAlive is a bool as it is either true or false. Public so I can use it in other classes.
    public AudioSource jumpSFX;
    public AudioSource hitSFX;
    //debounce variable
    private bool db = false;
    // audioSources, public so I can set it in Unity.

    // Update is called once per frame
    void Update()
    {
        // checks if player presses space and if bird is alive.
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            // if true, move the bird up by flapStrength and play jumpSFX.
            myRidgidbody.velocity = Vector2.up * flapStrength;
            jumpSFX.Play();
        }
    }
    // Listener that checks for bird collision. 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Since the only collisions in the game are the pipes, no need for check if the object it collides with is the pipe.
        // set bird is alive to false so player can no longer jump. 
        birdIsAlive = false;
        if (db == false)
        {
            // set db to true so this code can't run again.
            db = true;
            // play hitsfx
            hitSFX.Play();
        }
        // run the gameOver function in the logic script.
        logic.gameOver();
    }
}
