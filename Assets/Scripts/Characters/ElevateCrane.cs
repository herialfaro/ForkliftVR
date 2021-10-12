using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class ElevateCrane : MonoBehaviour
{
    [SerializeField] private LinearMapping leverMapping;
    [SerializeField] private float elevationSpeed;
    [SerializeField] private Vector3 initialPosY;
    [SerializeField] private Vector3 endPosY;
    [SerializeField] private GameObject fork;
    private Rigidbody my_rigid;
    private float previousMapping;
    private bool reachedLimit;

    void Awake()
    {
        my_rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        if(!reachedLimit)
        {
            AddElevationForce();
            if(fork.transform.localPosition == endPosY)
            {
                reachedLimit = Stop();
                Debug.Log("Top Limit reached");
                previousMapping = leverMapping.value;
                    
            }
            if(fork.transform.localPosition == initialPosY )
            {
                reachedLimit = Stop();
                Debug.Log("Bottom Limit reached");
                previousMapping = leverMapping.value;
                    
            }

        }
        if(leverMapping.value != previousMapping)
        {
            reachedLimit = false;
        }
    }


    public void AddElevationForce()
    {
       
            if(leverMapping.value > 0.9f )
            {   
                fork.transform.Translate(Vector3.up * Time.deltaTime);
               
            }

            if (leverMapping.value < 0.1f )
            {
                fork.transform.Translate(-Vector3.up * Time.deltaTime);   
                
            }

     
        


    }
    public bool Stop()
    {
        bool _reached = false;
        if(fork.transform.localPosition == endPosY  )
        {
         fork.transform.localPosition = endPosY; 
         _reached = true; 

                
        }else if(fork.transform.localPosition == initialPosY)
        {
            fork.transform.localPosition=initialPosY;
            _reached = true; 
           

        }
        Debug.Log("It has to stop!");
         return _reached;
    }
}
