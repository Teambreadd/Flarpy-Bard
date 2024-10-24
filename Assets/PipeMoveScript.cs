using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed = 5;
    // movespeed variable determines the pipes movespeed. Set to a default value of 5. Is public so it can be accessed in Unity if needed and is a float as it is often changed, and is a float just incase it is set to a decimal.
    private float originalMoveSpeed;
    // Variable for original movespeed. is a float as it could be a decimal and is private as it is only required in this script. 
    public float deadZone = -34;
    // This variable determines where the pipes destroy themselves. (On the x-axis)
    private LogicScript logicScript;
    // Reference to logic Script. Has no reference as prefab objects cannot access scene objects.
    // Start is called before the first frame update
    void Start()
    {
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        // When the object is instantiated in the scene, find the GameObject tagged as "Logic" and get its LogicScript component.
        originalMoveSpeed = moveSpeed;
        // Set original movespeed to moveSpeed. 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        // Moves the pipe across the screen at a speed set by moveSpeed. Time.deltaTime ensures that the pipe moves at the same rate regardless of frame rate.
        if (transform.position.x < deadZone) 
        {
            // Debug.Log("Pipe Deleted");
            Destroy(gameObject);
            // if the pipes x position is less than the deadZone position (further left than deadZone value) then destroy the gameObject.
        }
        moveSpeed = originalMoveSpeed;
        // Set moveSpeed back to Original moveSpeed.
        moveSpeed += logicScript.speedIncrease;
        // Increase moveSpeed by the logicScripts speedincrease variable. 
        // MoveSpeed is set to originalMoveSpeed before adding moveSpeed by logicScript to reset original the previous addition done by the speedIncrease variable.
        // E.g., 5 + 1 = 6
        // set back to 5 right before.
        // 5 + 2 = 7.
        // set back to 5 right before.
        // It appears that moveSpeed is increasing by 1.
    }
}
