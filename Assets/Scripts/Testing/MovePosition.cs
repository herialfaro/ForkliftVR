using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePosition : MonoBehaviour
{
    Rigidbody rb;
    public float force;
    public bool moving = false;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            rb.AddForce(transform.forward * force);
        }
    }


    public void ForMove()
    {
        if (!moving)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }
    }
}
