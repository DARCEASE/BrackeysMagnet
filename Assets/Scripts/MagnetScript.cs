using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetScript : MonoBehaviour
{
    public PlayerBehavior player;
    public Vector3 move;

    public bool metPLayer, walltouch;
    public float speed;

    public int tf;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerBehavior>();
        move.x = player.move.x;
        move.y = player.move.y;

        metPLayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(move * Time.deltaTime * speed);
        //if (walltouch == false)
       // {
            // GetComponent<Rigidbody2D>().AddForce(move * Time.deltaTime * speed * 3);
            transform.Translate(move * Time.deltaTime * speed);
        //}
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "wall")
        {
            player.canmove = true;
            //Freeze();
            walltouch = true;
            player.canclick = true;

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
    public void ChangeMovement()
    {
        Debug.Log("!!!!!!!!!!!!!!!!");

        player = GameObject.FindObjectOfType<PlayerBehavior>();
        move.x = 10;
        move.y = player.move.y;
        speed = 20000;
    }

    public void Freeze()
    {
        move.x = 0;
        move.y = 0;
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
    }
}
