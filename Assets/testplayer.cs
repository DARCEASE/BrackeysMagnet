using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testplayer : MonoBehaviour
{
    public GameObject testmagnet;
    public int magnetcount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(magnetcount < 1)
            {
                Instantiate(testmagnet, transform.position, Quaternion.identity);
                magnetcount++;
            }
        }
    }
}
