using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Despite the name, TopTriggerScript is used for both the top and bottom trigger gameObject.
public class TopTriggerScript : MonoBehaviour
{
    public LogicScript logic; 
    // Logic script referenced in Unity. 
    public BirdScript birdScript;
    // BirdScript referenced in Unity.
    // No start or update method because it is not needed.
    // Event listener that checks for objects passing through it. (e.g., the bird)
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            logic.gameOver();
            // If the colliding object is in layer 3, (which is assigned to only the bird) call the gameOVer method. (This is to prevent the addscore method from firing when it detects pipes)
            birdScript.birdIsAlive = false;
            // Set the birdScript's birdIsAlive to false.
        }
    }
}
