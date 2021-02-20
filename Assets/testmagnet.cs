using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testmagnet : MonoBehaviour
{
    public Vector3 move;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(move * Time.deltaTime * speed);


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "wall")
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        }
    }
}
