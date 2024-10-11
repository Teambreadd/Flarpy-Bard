using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRidgidbody;
    public float flapStrength;
    public LogicScript logic; 
    public bool birdIsAlive = true;
    public AudioSource jumpSFX;
    public AudioSource hitSFX;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            myRidgidbody.velocity = Vector2.up * flapStrength;
            jumpSFX.Play();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (birdIsAlive == true)
        {
            hitSFX.Play();
        }
        logic.gameOver();
        birdIsAlive = false;
    }
}
