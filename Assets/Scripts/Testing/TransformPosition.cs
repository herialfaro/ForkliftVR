using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformPosition : MonoBehaviour
{
    Parent parent;
    public Transform carPos;
    void Start()
    {
        parent = FindObjectOfType<Parent>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
            if (parent.isParenting)
            {
                transform.position = carPos.position;                
             //   Debug.Log("Newpos");
            }
        
    }


}
