using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    //public Transform lineStart, lineEnd;
   // public GameObject rayCastHold; //child GO W/ raycast script
    
    public Vector3 rt, lt, dwn, u;

    public int range, direction;

    public bool canmove, canclick;
    public Vector3 move;

    public Collider2D col;
    public LayerMask wall;
    // Start is called before the first frame update
    void Start()
    {
        //rayCastHold = GetComponentInChildren<RaycastBehavior>().gameObject; 
        col = GetComponent<CircleCollider2D>();
        canclick = true;
    }

    // Update is called once per frame
    void Update()
    {
        //if (rayCastHold.GetComponent<RaycastBehavior>().isMoving == true)
        //{
         //   rayCastHold.SetActive(false);
        //}
          rt = new Vector3(transform.position.x + range, transform.position.y, 0);
          lt = new Vector3(transform.position.x - range, transform.position.y, 0);
          dwn = new Vector3(transform.position.x, transform.position.y - range, 0);
          u = new Vector3(transform.position.x, transform.position.y + range, 0);

          RaycastHit2D right = Physics2D.Linecast(transform.position, rt, wall);
          RaycastHit2D left = Physics2D.Linecast(transform.position, lt, wall);
          RaycastHit2D up = Physics2D.Linecast(transform.position, u, wall);
          RaycastHit2D down = Physics2D.Linecast(transform.position, dwn, wall);


          Debug.DrawLine(transform.position, rt, Color.red);
          Debug.DrawLine(transform.position, lt, Color.green);
          Debug.DrawLine(transform.position, u, Color.blue);
          Debug.DrawLine(transform.position, dwn, Color.yellow);

          if (right.collider == null)
          {
              //Debug.Log("em");
              //there's empty space, so you can move
              if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
              {
                  Debug.Log("Right is Open. pretend i moved");
                  //move until u hit a wall
                  if (canclick)
                  {
                      move.x = .07f;
                      move.y = 0;

                      canmove = !canmove;
                      canclick = false;
                  }

              }
          }

          if (left.collider == null)
          {
              //Debug.Log("em");
              //there's empty space, so you can move
              if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
              {
                  Debug.Log("Left is Open. pretend i moved");

                  if (canclick)
                  {
                      move.x = -.07f;
                      move.y = 0;

                      canmove = !canmove;
                      canclick = false;
                  }
              }
          }


          if (up.collider == null)
          {
              //Debug.Log("em");
              //there's empty space, so you can move
              if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
              {
                  Debug.Log("Up is Open. pretend i moved");
                  //move until u hit a wall
                  if (canclick)
                  {
                      move.x = 0;
                      move.y = .07f;

                      canmove = !canmove;
                      canclick = false;
                  }
              }
          }

          if (down.collider == null)
          {
              //Debug.Log("em");
              //there's empty space, so you can move
              if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
              {
                  Debug.Log("Down is Open. pretend i moved");
                  //move until u hit a wall
                  if (canclick)
                  {
                      move.x = 0;
                      move.y = -.07f;

                      canmove = !canmove;
                      canclick = false;
                  }
              }
          }
          else
        {
            canmove = false;
        }

         /* if (canmove)
          {
              Move();
          }*/
      }

      private void Move()
      {
          transform.Translate(move);

      }
    
  /*      private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "wall")
        {
           // rayCastHold.GetComponent<RaycastBehavior>().isMoving = false;
            //rayCastHold.SetActive(true);
            canmove = false;
            canclick = true;
        }
    }*/

}
