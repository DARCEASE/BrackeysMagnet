using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetScript : MonoBehaviour
{
    public PlayerBehavior player;
    public Vector3 move;

    public bool metPLayer, walltouch;
    public float speed;

    public int tf, dirid, playerid;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerBehavior>();
        anim = GetComponent<Animator>();
        //move.x = player.move.x;
        //move.y = player.move.y;
        dirid = player.directionID;
        playerid = player.playerID;
        metPLayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(move * Time.deltaTime * speed);
        //if (walltouch == false)
       // {
            // GetComponent<Rigidbody2D>().AddForce(move * Time.deltaTime * speed * 3);
            
        //}

        if(!walltouch)
        {
            if (playerid == 1)//spinning animation
            {
                anim.Play("North_Spin");
            }
            else
            {
                anim.Play("South_Spin");
            }
            switch (dirid)
            {
                case 0:
                    move = new Vector3(0, .2f, 0);
                    Debug.Log("up");
                    break;
                case 1:
                    move = new Vector3(.2f, 0, 0);
                    Debug.Log("right");
                    break;
                case 2:
                    move = new Vector3(0, -.2f, 0);
                    Debug.Log("down");
                    break;
                case 3:
                    move = new Vector3(-.2f, 0, 0);
                    Debug.Log("left");
                    break;
            }
        }
        else
        {
            move = Vector3.zero;
        }

        transform.Translate(move * Time.deltaTime * speed);

        if (player.canclick)
        {
            Debug.Log("destroyed magnet");
            player.magnetcount = 0;

            if(playerid == 0)
            {
                player.playerID = 1;
            }
            else
            {
                player.playerID = 0;
            }
            Destroy(gameObject);
        }
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision detected");
        if (collision.gameObject.name == "wall")
        {
            if (playerid == 1)//hitting wall animation
            {
                anim.Play("North_Fall");
            }
            else
            {
                anim.Play("South_fall");
            }
            walltouch = true;
            player.canmove = true;

            //Freeze();
            //walltouch = true;
            //player.canclick = true;

            move.x = 0;
            move.y = 0;
            //GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        }

      
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.name == "wall")
        {
            walltouch = false;
        }
    }

}
