using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoParent : MonoBehaviour
{
    public Transform pointOfParent;
    public Transform cargoTransform;
    public string _tag;
    private bool isBeingMoved = false;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag(_tag))
        {
            isBeingMoved = true;
            cargoTransform.SetParent(pointOfParent);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag(_tag))
        {
            isBeingMoved = false;
            cargoTransform.SetParent(null);
        }
    }

    private void Update()
    {
        if(isBeingMoved)
        {
            transform.position = pointOfParent.position;
        }
        
    }
}
