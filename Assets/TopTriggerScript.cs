using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopTriggerScript : MonoBehaviour
{
    public LogicScript logic; 
    public BirdScript birdScript;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            logic.gameOver();
            birdScript.birdIsAlive = false;
        }
    }
}