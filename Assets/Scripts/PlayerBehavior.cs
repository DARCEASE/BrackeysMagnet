using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    //public Transform lineStart, lineEnd;
   // public GameObject rayCastHold; //child GO W/ raycast script
    
    //raycast directions
    private Vector3 rt, lt, dwn, u;

    //raycast length
    public float range;

    //when the player can move...when the player can start to move....when the player bounces
    public bool canmove, canclick, isbouncing = false;
    public bool isMoving;
    //if the player is moving

    //base player speed
    public Vector2 move;
    //which is multiplied by a speed
    public float movespeed;

    //our circle collider
    private Collider2D col;
    //to detect anything with the wall mask
    public LayerMask wall;

    //our rigidbody
    private Rigidbody2D rb;

    //the direction we bounce in
    private Vector2 dr;
    //how "far/fast" our bounce is
    private float speed;

    //the bitch ass magnet
    public GameObject magnet;
    //to prevent more than 1 bitch ass magnet
    public int magnetcount;

    //the bitch ass magnet script
    public MagnetScript magnetSc;
    // Start is called before the first frame update

    public int directionID;
    //Identifies the direction
    //0-up; 1-Right; 2-Down; 3-Left

    public int playerID;
    //checks which magnet the player is at the moment
    //0 - North|1 - South

    public Animator ani;
    //animator

    void Start()
    {

        
        //rayCastHold = GetComponentInChildren<RaycastBehavior>().gameObject; 
        col = GetComponent<CircleCollider2D>();
        ani = GetComponent<Animator>();
        canclick = true;
        rb = GetComponent<Rigidbody2D>();

        //BOOUNCE--------------
        float rads = 0;
        while (rads == 0)
        {
            rads = Random.Range(0, 2 * Mathf.PI);
        }

        dr = new Vector2(Mathf.Cos(rads), Mathf.Sin(rads));
        dr.Normalize();
        dr *= speed;
        rb.AddForce(dr);
        //BOOUNCE----------------


        magnetcount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //if (rayCastHold.GetComponent<RaycastBehavior>().isMoving == true)
        //{
        //   rayCastHold.SetActive(false);
        //}

        if (!isMoving)
        {
            if (playerID == 0)//idle animation
            {
                ani.Play("North_Idle");
            }
            else
            {
                ani.Play("South_Idle");
            }
        }
        if(magnet != null)
        {
            //Debug.Log("FOUND");
            magnetSc = magnet.GetComponent<MagnetScript>();
        }

        //RAYCAST BEHAVIOR
          rt = new Vector3(transform.position.x + range, transform.position.y, 0);
          lt = new Vector3(transform.position.x - range, transform.position.y, 0);
          dwn = new Vector3(transform.position.x, transform.position.y - range, 0);
          u = new Vector3(transform.position.x, transform.position.y + range, 0);

        //RAYCAST DETECTION
          RaycastHit2D right = Physics2D.Linecast(transform.position, rt, wall);
          RaycastHit2D left = Physics2D.Linecast(transform.position, lt, wall);
          RaycastHit2D up = Physics2D.Linecast(transform.position, u, wall);
          RaycastHit2D down = Physics2D.Linecast(transform.position, dwn, wall);

        //SHOW RAYCAST
          Debug.DrawLine(transform.position, rt, Color.red);
          Debug.DrawLine(transform.position, lt, Color.green);
          Debug.DrawLine(transform.position, u, Color.blue);
          Debug.DrawLine(transform.position, dwn, Color.yellow);

          if (right.collider == null)
          {
              //there's empty space, so you can move
              if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
              {
                
                  //move until u hit a wall IF you are not already moving
                  if (canclick)
                  {
                    isMoving = true;
                    if(playerID == 0)//throwing animation
                    {
                        ani.Play("North_Throw");
                    }
                    else
                    {
                        ani.Play("South_Throw");
                    }


                    directionID = 1;
                    //set our speed to the right direction
                    move.x = .05f;
                      move.y = 0;


                    // canmove = !canmove;
                    //magnetSc.gameObject.SetActive(false);
                    //Debug.Log("wtf");
                    //magnetSc.ChangeMovement();
                    //magnetSc.speed = 5;
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
                    isMoving = true;
                    if (playerID == 0)//throwing animation
                    {
                        ani.Play("North_Throw");
                    }
                    else
                    {
                        ani.Play("South_Throw");
                    }
                    directionID = 3;
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
                    isMoving = true;
                    if (playerID == 0)//throwing animation
                    {
                        ani.Play("North_Throw");
                    }
                    else
                    {
                        ani.Play("South_Throw");
                    }
                    directionID = 0;
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
                    isMoving = true;
                    if (playerID == 0)//throwing animation
                    {
                        ani.Play("North_Throw");
                    }
                    else
                    {
                        ani.Play("South_Throw");
                    }
                    directionID = 2;
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
        if (playerID == 0)//magnetizing animation
        {
            ani.Play("North_Spin");
        }
        else
        {
            ani.Play("South_Spin");
        }

    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "wall")
        {
            Debug.Log("wall hit");
            isMoving = false;
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
