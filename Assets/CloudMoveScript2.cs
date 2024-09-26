using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawnScript2 : MonoBehaviour
{
    public GameObject Cloud;
    private float spawnRate;
    private float timer = 0;
    public float heightOffset;
    // Start is called before the first frame update
    void Start()
    {
        spawnRate = Random.Range(3,6);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > spawnRate) {
            spawnCloud();
            // Debug.Log(timer.ToString());
            // Debug.Log(sawnRate.ToString());
            spawnRate = Random.Range(3,6);
            timer = 0;
        } else {
            timer = timer + Time.deltaTime;
        }
    }
    void spawnCloud()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        Instantiate(Cloud, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), transform.position.z), transform.rotation);
    }
}
