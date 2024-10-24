using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawnScript : MonoBehaviour
{
    public GameObject Cloud;
    // Reference to cloud gameObject. public so I can set it in Unity.
    private float spawnRate;
    // variable for spawnRate. Value is the time between clouds spawning. Private to prevent it from accidently being modified by another script. Only needed in this script. Float as the variable may be a decimal. 
    private float timer = 0;
    // time variable. private for the same reason as spawnRate. set to a default value of 0.
    public float heightOffset;
    // The height offset. Set in Unity. Float as it could be a decimal.
    // Start is called before the first frame update
    void Start()
    {
        spawnRate = Random.Range(1,2);
        // When game starts, set spawnrate to either 1 or 2.
    }

    // Update is called once per frame
    void Update()
    {
        // checks if timer is bigger than spawnRate.
        if (timer > spawnRate) {
            spawnCloud();
            // If true, then call the spawn cloud method.
            // Debug.Log(timer.ToString());
            // Debug.Log(sawnRate.ToString());
            spawnRate = Random.Range(10,20);
            // Randomise spawnRate again. 
            timer = 0;
            // Set timer back to 0 so this cycle can repeat.
        } else {
            timer = timer + Time.deltaTime;
            // If timer is not bigger than spawnRate, make it increase by Time.deltaTime. After 1 second, timer will equal 1. After 2 seconds, 2 etc. Basically timer counts up by one every second. 
        }
    }
    void spawnCloud()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        // calculates highest and lowest point based on the heightOffset and assigns both to 2 variables.
        Instantiate(Cloud, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), transform.position.z), transform.rotation);
        // creates a clone of the cloud and then sets its position based on lowestPoint and heightestPoint.
    }
}
