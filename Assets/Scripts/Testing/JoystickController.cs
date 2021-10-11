using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    public Transform topOfJoystick;

    [SerializeField]
    private float forwardBackwardsTilt = 0;

    [SerializeField]
    private float sideToSideTilt = 0;



    void Update()
    {
        forwardBackwardsTilt = topOfJoystick.rotation.eulerAngles.x;
        if (forwardBackwardsTilt < 355 && forwardBackwardsTilt > 290)
        {
            forwardBackwardsTilt = Math.Abs(forwardBackwardsTilt - 360);
            Debug.Log("Forward" + forwardBackwardsTilt);
        }
        else if (forwardBackwardsTilt > 5 && forwardBackwardsTilt < 74)
        {
            Debug.Log("Forward" + forwardBackwardsTilt);
        }

        sideToSideTilt = topOfJoystick.rotation.eulerAngles.z;

        if (sideToSideTilt < 355 && sideToSideTilt > 290)
        {
            sideToSideTilt = Math.Abs(sideToSideTilt - 360);
            Debug.Log("Right" + sideToSideTilt);
        }
        else if (sideToSideTilt > 5 && sideToSideTilt < 74)
        {
            Debug.Log("Left" + sideToSideTilt);
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Playerhand"))
        {
            transform.LookAt(other.transform.position, transform.up);
        }
    }
}
