using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//PURPOSE: To test platform effectors and thier boundaries
//USAGE:place this on test player sprite for movement

public class PlayerTest : MonoBehaviour
{
    public Vector3 moveLeft;
    public Vector3 moveUp;
    public GameObject youWinPanel;
   
    // Start is called before the first frame update
    void Start()
    {
        youWinPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(moveUp);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(moveLeft);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-moveUp);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(-moveLeft);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Captive")
        {
            Debug.Log("YEAAAAAAAAAAAA");
            youWinPanel.SetActive(true); // open winning Panel that plays animation of the magnet boi and thier pal
           
        }
    }
}
