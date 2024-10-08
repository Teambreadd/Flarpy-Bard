using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed = 5;
    private float originalMoveSpeed;
    public float deadZone = -34;
    public LogicScript logicScript;
    // Start is called before the first frame update
    void Start()
    {
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        originalMoveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        if (transform.position.x < deadZone) 
        {
            Debug.Log("Pipe Deleted");
            Destroy(gameObject);
        }
        moveSpeed = originalMoveSpeed;
        moveSpeed += logicScript.speedIncrease;
    }
}
