using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoParent : MonoBehaviour
{
    public Transform pointOfParent;
    public Transform cargoTransform;
    public string _tag;
    [SerializeField]private bool isBeingMoved = false;
    // Start is called before the first frame update
    private void OnTriggerStay(Collision other)
    {
        if(other.gameObject.CompareTag("Finish"))
        {

            isBeingMoved = true;
            cargoTransform.SetParent(pointOfParent);
        }
    }

    private void OnTriggerExit(Collision other)
    {
        if (other.gameObject.CompareTag("Finish"))
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
