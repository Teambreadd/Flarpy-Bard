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
    // audioSources, public so I can set it in Unity.
    //debounce variable
    private bool db = false;
    public GameObject projectile;
    // Reference to projectile gameObject.
    public AudioSource shootSFX;
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
        else if (Input.GetKeyDown(KeyCode.Return) && birdIsAlive)
        {
            // if true, fire a projectile. (Creates a clone of the projectile prefab and sets its position and orientation to the bird.) 
            // also play the shoot sound effect.
            shootSFX.Play();
            Instantiate(projectile, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
        }
    }
    // Listener that checks for bird collision. 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object has the Arrow tag.
        if (collision.gameObject.CompareTag("Arrow"))
        {
            // If it does, return early and ignore the rest of the code
            return;
        }
        // Set birdIsAlive to false so the player can no longer jump
        birdIsAlive = false;

        if (db == false)
        {
            // Set db to true so this code can't run again
            db = true;
            // Play hit SFX
            hitSFX.Play();
        }
        // Run the gameOver function in the logic script
        logic.gameOver();
    }

}
