using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class RotateCrane : MonoBehaviour
{
     [SerializeField] private LinearMapping leverMapping;
     [SerializeField] private Transform maxTarget;
     [SerializeField] private Transform minTarget;
     public float rotationSpeed;
     private float previousMapping;
     public bool reachedLimit = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    
         AddRotationForce();
           if(leverMapping.value != previousMapping && reachedLimit)
                {
                    reachedLimit = false;
                }
    }


    private void AddRotationForce()
    {

        if(!reachedLimit)
        {
            if(leverMapping.value == 1f)
            {   
          
               transform.rotation = Quaternion.RotateTowards(transform.rotation,
                maxTarget.rotation,rotationSpeed * Time.deltaTime);
            }

            if (leverMapping.value == 0f)
            {
                 
                transform.rotation = Quaternion.RotateTowards(transform.rotation,
                    minTarget.rotation,rotationSpeed * Time.deltaTime);
            }
        }
        
    }


    //TIP: IDLIMIT IF 1 MEANS Max LIMIT, 2 MEANS Min LIMIT
    public void ReachedLimit(int _IDLimit)
    {
            reachedLimit = true;
            previousMapping = leverMapping.value;
            switch(_IDLimit)
            {
                case 1: 
                    transform.rotation = maxTarget.rotation; 
                break;

                case 2:
                    transform.rotation = minTarget.rotation; 
                break;
            }
            
            Debug.Log("It has to stop!");
    }
}
