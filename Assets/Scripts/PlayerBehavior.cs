using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    //public Transform lineStart, lineEnd;
   // public GameObject rayCastHold; //child GO W/ raycast script
    
    private Vector3 rt, lt, dwn, u;

    public int direction;
    public float range;
    public bool canmove, canclick, isbouncing = false;
    public Vector2 move;
    public float movespeed;

    private Collider2D col;
    public LayerMask wall;

    private Rigidbody2D rb;
    private Vector2 dr;
    private float speed;

    public GameObject magnet;
    private int magnetcount;

    public MagnetScript magnetSc;
    // Start is called before the first frame update
    void Start()
    {

        
        //rayCastHold = GetComponentInChildren<RaycastBehavior>().gameObject; 
        col = GetComponent<CircleCollider2D>();
        canclick = true;
        rb = GetComponent<Rigidbody2D>();
        float rads = 0;
        while (rads == 0)
        {
            rads = Random.Range(0, 2 * Mathf.PI);
        }

        dr = new Vector2(Mathf.Cos(rads), Mathf.Sin(rads));
        dr.Normalize();
        dr *= speed;
        rb.AddForce(dr);

        magnetcount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //if (rayCastHold.GetComponent<RaycastBehavior>().isMoving == true)
        //{
         //   rayCastHold.SetActive(false);
        //}
        if(magnet != null)
        {
            magnetSc = magnet.GetComponent<MagnetScript>();
        }

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
                  //Debug.Log("Right is Open. pretend i moved");
                  //move until u hit a wall
                  if (canclick)
                  {
                      move.x = .05f;
                      move.y = 0;


                    // canmove = !canmove;

                    magnetSc.ChangeMovement();
                    if (magnetcount < 1)
                    {
                     
                        Instantiate(magnet, transform.position, Quaternion.identity);
                        magnetcount++;
                    }
                    
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
                  //Debug.Log("Left is Open. pretend i moved");

                  if (canclick)
                  {
                      move.x = -.05f;
                      move.y = 0;

                     // canmove = !canmove;
                      

                    if (magnetcount < 1)
                    {
                        magnetSc.move.x = move.x;
                        magnetSc.move.y = move.y;
                        Instantiate(magnet, transform.position, Quaternion.identity);
                        magnetcount++;
                    }
                    else
                    {
                        magnetSc.move.x = move.x;
                        magnetSc.move.y = move.y;
                    }
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
                  //Debug.Log("Up is Open. pretend i moved");
                  //move until u hit a wall
                  if (canclick)
                  {
                      move.x = 0;
                      move.y = .05f;

                      //canmove = !canmove;
                     

                    if (magnetcount < 1)
                    {
                        magnetSc.move.x = move.x;
                        magnetSc.move.y = move.y;
                        Instantiate(magnet, transform.position, Quaternion.identity);
                        magnetcount++;
                    }
                    else
                    {
                        magnetSc.move.x = move.x;
                        magnetSc.move.y = move.y;
                    }

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
                  //Debug.Log("Down is Open. pretend i moved");
                  //move until u hit a wall
                  if (canclick)
                  {
                      move.x = 0;
                      move.y = -.05f;

                      //canmove = !canmove;
                     

                    if (magnetcount < 1)
                    {
                        magnetSc.move.x = move.x;
                        magnetSc.move.y = move.y;
                        Instantiate(magnet, transform.position, Quaternion.identity);
                        magnetcount++;
                    }
                    else
                    {
                        magnetSc.move.x = move.x;
                        magnetSc.move.y = move.y;
                    }

                    canclick = false;
                }
              }
          }
       


        if (canmove)
          {
              Move();
          }

        /*if(!isbouncing)
        {
            rb.MovePosition(rb.position + move * speed * Time.deltaTime);
        }*/
      }

     public void Move()
      {
        transform.Translate(move * Time.deltaTime * movespeed);

      }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "wall")
        {
           // rayCastHold.GetComponent<RaycastBehavior>().isMoving = false;
            //rayCastHold.SetActive(true);
            canmove = false;
            canclick = true;

            float bounce = 20f;
            rb.AddForce(collision.contacts[0].normal * bounce);
            isbouncing = true;
            Invoke("StopBounce", 0.3f);
        }
    }

    void StopBounce()
    {
        isbouncing = false;
        rb.velocity = new Vector3(0, 0, 0);
    }

}
