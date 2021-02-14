using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetScript : MonoBehaviour
{
    //PURPOSE: ALLOWS THE MAGNET TO STICK TO THE WALL AND TELL THE PLAYER TO FOLLOW IT
    //USAGE: ON THE MAGNET

    //how fast the magnet is going
    public float speed;

    //stores the magnets x,y,z coords
    public Vector3 mypos;

    //the player script
    public PlayerMovementScript player;
    // Start is called before the first frame update
    void Start()
    {
        //the player variable is connected to the actual player script
        player = GameObject.FindObjectOfType<PlayerMovementScript>();

    }

    // Update is called once per frame
    void Update()
    {
        //always move the magnet towards the wall
        transform.position = Vector3.MoveTowards(transform.position, player.lastWall, speed);

        //sets the magnet's x,y,z to the mypos variable
        mypos = GetComponent<Transform>().position;

       

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //if i stay on something called wall
        if (collision.gameObject.name == "wall")
        {
            //tell the player to follow me
            player.follow = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //if i get off the object called wall
        if (collision.gameObject.name == "wall")
        {
            //the player cannot follow me anymore
            player.follow = false;
        }
    }
}

