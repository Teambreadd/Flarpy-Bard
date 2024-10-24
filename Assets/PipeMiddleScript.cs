using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    private LogicScript logic; 
    // variable for logicScript. It is private and unassigned as this script is in a prefab in assets and cannot access the logicscript in a scene object.
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        // When the pipe is instantiated in the scene, find the gameObject with tagged as "Logic" and get its logicScript component. 
    }

    // Event listener that checks for objects passing through it. (e.g., the bird)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            // If the colliding object is in layer 3, (which is assigned to only the bird) call the addScore method. (This is to prevent the addscore method from firing when it detects pipes)
            logic.addScore(1, true);
            // call the addscore method in the logicScript and pass in 1 as an argument. 
        }
    }

}
