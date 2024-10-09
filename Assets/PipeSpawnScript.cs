using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject Pipe;
    public float spawnRate = 4;
    private float timer = 0;
    public float heightOffset;
    private int previousSpeedincrease;
    public LogicScript logicScript;
    // Start is called before the first frame update
    void Start()
    {
        spawnPipe();
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        previousSpeedincrease = logicScript.speedIncrease;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > spawnRate) {
            spawnPipe();
            // Debug.Log(timer.ToString());
            // Debug.Log(spawnRate.ToString());
            timer = 0;
            Debug.Log(spawnRate);
        } else {
            timer = timer + Time.deltaTime;
        }
        if (previousSpeedincrease != logicScript.speedIncrease)
        {
            previousSpeedincrease = logicScript.speedIncrease;
            spawnRate = spawnRate - 0.38f;
            Debug.Log("Gone Down" + spawnRate);
            // spawnRate can only go down a certain amount of times. I will make sure it will not go negative.
            // Currently it will end up around 1.3s spawn rate at maximum speed.
        } 
    }
    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        Instantiate(Pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), transform.position.z), transform.rotation);
    }
}
