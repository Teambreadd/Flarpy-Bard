using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
// This script is very similar to cloudSpawnScript. Check cloudSpawnScript for explaination.
public class GhostSpawnScript : MonoBehaviour
{
    public GameObject ghost;
    public float spawnRate = 4;
    private float timer = 0;
    public float heightOffset;
    private int previousSpeedincrease;
    public LogicScript logicScript;
    // Start is called before the first frame update
    void Start()
    {
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        previousSpeedincrease = logicScript.speedIncrease;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > spawnRate) {
            timer = 0;
            spawnGhost(ghost);
            // Debug.Log(timer.ToString());
            // Debug.Log(spawnRate.ToString());
            // Debug.Log(spawnRate);
            // Debug.Log("Else");
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
    void spawnGhost(GameObject ghost)
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        Instantiate(ghost, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), transform.position.z), transform.rotation);
    }
}
