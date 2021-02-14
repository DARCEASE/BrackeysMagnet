using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//PURPOSE: To test platform effectors and thier boundaries
//USAGE:place this on test player sprite for movement

public class PlayerTest : MonoBehaviour
{
    public Vector3 moveLeft;
    public Vector3 moveUp;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Translate(moveUp);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(moveLeft);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.Translate(-moveUp);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(-moveLeft);
        }
    }
}
