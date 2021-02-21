using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastBehavior : MonoBehaviour
{
    public PlayerBehavior behavior;

    public Vector3 move;
    // Start is called before the first frame update
    void Start()
    {
        behavior = GetComponent<PlayerBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
      if(behavior.canmove == true)
        {
            Move();
        }
    }
    private void Move()
    {
        move.x = behavior.move.x;
        move.y = behavior.move.y;
        transform.Translate(move);
      //  behavior.enabled = false;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "wall")
        {
            // rayCastHold.GetComponent<RaycastBehavior>().isMoving = false;
            //rayCastHold.SetActive(true);
           // behavior.enabled = true;
            behavior.canmove = false;
            behavior.canclick = true;


        }
    }

}

