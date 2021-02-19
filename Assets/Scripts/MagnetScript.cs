using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetScript : MonoBehaviour
{
    public PlayerBehavior player;
    public Vector3 move;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerBehavior>();
        move.x = player.move.x;
        move.y = player.move.y;

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(player.move);
        transform.Translate(move * Time.deltaTime * speed);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "wall")
        {
            Debug.Log("a");
            player.canmove = true;
            move.x = 0;
            move.y = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.name == "wall")
        {
            move.x = player.move.x;
            move.y = player.move.y;
            player.canmove = false;
        }
        
    }
}
