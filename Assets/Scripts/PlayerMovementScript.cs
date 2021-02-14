using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    //PURPOSE: ALLOWS THE PLAYER TO CLICK ON A WALL TO SPAWN A GRAPPLING HOOK IN ORDER TO MOVE
    //USAGE: ON THE PLAYER

    //the magnet we spawn
    public GameObject magnet;
    //where the magnet spawns
    public Transform magnetSpawn;

    //lastWall: checks tha most recent wall that the magnet hit
    //offset: to give some space between the player and magnet, so the player doesnt "ram" into the magnet/wall
    public Vector3 lastWall, offset;

    //the players rigigbody
    public Rigidbody2D rb;

    //prevents more than 1 magnet from spawning
    public int magnetCount;
    //allows the player to follow the magnet when it hits a wall
    public bool follow;

    // Start is called before the first frame update
    void Start()
    {
        magnetCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //if you press down on the mousebutton
        if (Input.GetMouseButtonDown(0))
        {

            //creates a ray for the mouse, tracking its position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //allows the ray to be able to detect things
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            //if you're hiting something and if that thing is called wall
            if (hit.collider != null && hit.collider.name == "wall")
            {
                //set lastwall to this wall
                lastWall = hit.collider.GetComponent<Transform>().position;

                //if there isnt a magnet already
                if (magnetCount == 0)
                {
                    //increment the magnet count
                    magnetCount++;
                    //spawn a magnet in front of us
                    Instantiate(magnet, magnetSpawn.position, Quaternion.identity);
                }

            }

        }

        //if follow is true
        if (follow)
        {
            //call this function
            FollowMagnet();
        }
    }

    //allows the player to follow the magnet
    public void FollowMagnet()
    {

        //move the player towards the magnet, while keeping a distance, at the speed of 1
        transform.position = Vector3.MoveTowards(transform.position, lastWall - offset, 1);
    }
}
