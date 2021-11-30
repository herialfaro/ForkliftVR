using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class ElevateCrane : MonoBehaviour
{
    AudioManager audioManager;
    [SerializeField] private LinearMapping leverMapping;
    [SerializeField] private Vector3 initialPosY;
    [SerializeField] private Vector3 endPosY;
    [SerializeField] private GameObject fork;
    private Rigidbody my_rigid;
    private float previousMapping;
    public bool reachedLimit = false;

    void Awake()
    {
        my_rigid = GetComponent<Rigidbody>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //Stop();

        AddElevationForce();

        if (leverMapping.value != previousMapping && reachedLimit)
        {
            reachedLimit = false;
        }



    }


    public void AddElevationForce()
    {
        if (!reachedLimit)
        {
            if (leverMapping.value == 1f /*&& !reachedLimit*/)
            {
                fork.transform.Translate(Vector3.up * Time.deltaTime);
                audioManager.PlayLoopElevateUp();

            }

            if (leverMapping.value == 0f /*&& !reachedLimit*/ )
            {
                fork.transform.Translate(-Vector3.up * Time.deltaTime);
                audioManager.PlayLoopElevateDown();
            }

            if (leverMapping.value != 0 && leverMapping.value != 1)
            {
                audioManager.StopLoopElevate();
            }
        }





    }

    //TIP: IDLIMIT IF 1 MEANS TOP LIMIT, 2 MEANS BOTTOM LIMIT
    public void ReachedLimit(int _IDLimit)
    {
        reachedLimit = true;
        previousMapping = leverMapping.value;
        switch (_IDLimit)
        {
            case 1:
                fork.transform.localPosition = endPosY;
                //audioManager.StopLoopElevate();
                break;

            case 2:
                fork.transform.localPosition = initialPosY;
                //audioManager.StopLoopElevate();
                break;
        }

        Debug.Log("It has to stop!");
    }
}
