using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMoveScript : MonoBehaviour
{
    public int moveSpeed = 1;
    // movespeed variable determines the clouds movespeed. Set to a default value of 1. Is public so it can be accessed in Unity if needed, and is an integer as it (currently) stays a whole number.
    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        // Moves the cloud across the screen at a speed set by moveSpeed. Time.deltaTime ensures that the cloud moves at the same rate regardless of frame rate.
        if (transform.position.x < -35.3)
        {
            // Checks if the cloud has moved offscreen.
            Destroy(gameObject);
            // If true, destroys game object.
        }
    }
}
