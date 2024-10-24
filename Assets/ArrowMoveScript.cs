using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMoveScript : MonoBehaviour
{
    public int moveSpeed = 10;
    // movespeed variable determines the arrows movespeed. Set to a default value of 1. Is public so it can be accessed in Unity if needed, and is an integer as it (currently) stays a whole number.
    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.right * moveSpeed) * Time.deltaTime;
        // Moves the arrow across the screen at a speed set by moveSpeed. Time.deltaTime ensures that the arrow moves at the same rate regardless of frame rate.
        if (transform.position.x > 35.3)
        {
            // Checks if the arrow has moved offscreen.
            Destroy(gameObject);
            // If true, destroys game object.
        }
    }
    // Event Listener that destroys the arrow if it hits a pipe.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe"))
        {
            Destroy(transform.gameObject);
        }
    }
}
