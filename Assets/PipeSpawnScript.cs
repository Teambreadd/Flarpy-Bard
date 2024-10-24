using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
// This script is very similar to cloudSpawnScript. Check cloudSpawnScript for explaination.
public class PipeSpawnScript : MonoBehaviour
{
    public GameObject Pipe;
    public GameObject GoldenPipe;
    public float spawnRate = 4;
    private float timer = 0;
    public float heightOffset;
    private int previousSpeedincrease;
    public LogicScript logicScript;
    private int db = 0;
    // Start is called before the first frame update
    void Start()
    {
        db++;
        spawnPipe(Pipe);
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        previousSpeedincrease = logicScript.speedIncrease;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > spawnRate) {
            if (db == 2)
            {
                timer = 0;
                Debug.Log("If");
                spawnPipe(GoldenPipe);
                db = 0;
            } else 
            {
                timer = 0;
                db++;
                spawnPipe(Pipe);
                // Debug.Log(timer.ToString());
                // Debug.Log(spawnRate.ToString());
                Debug.Log(spawnRate);
                Debug.Log("Else");
            }
        } else {
            timer = timer + Time.deltaTime;
        }
        if (previousSpeedincrease != logicScript.speedIncrease)
        {
            previousSpeedincrease = logicScript.speedIncrease;
            if (logicScript.speedIncrease <= 18)
            {
                spawnRate = spawnRate - 0.38f;
            Debug.Log("Gone Down" + spawnRate);
            // spawnRate can only go down a certain amount of times. I will make sure it will not go negative.
            }
        } 
    }
    void spawnPipe(GameObject pipe)
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), transform.position.z), transform.rotation);
    }
}
