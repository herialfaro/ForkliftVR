using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoParent : MonoBehaviour
{
    public Transform pointOfParent;
    public Transform cargoTransform;
    public string _tag;
    [SerializeField]private bool isBeingMoved = false;
    public float speedOfFollow;
    Rigidbody m_rigid;
    Vector3 velocity;

    private void Awake()
    {
        m_rigid = GetComponent<Rigidbody>();
    }


    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag(_tag))
        {

            isBeingMoved = true;
            cargoTransform.SetParent(pointOfParent);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(_tag))
        {
            isBeingMoved = false;
            cargoTransform.SetParent(null);
        }
    }

    private void OnCollisionStay(Collision _other)
    {
        if(_other.gameObject.CompareTag("Floor"))
        {
            isBeingMoved = false;
            cargoTransform.SetParent(null);

        }

        
    }

    private void Update()
    {
        if(isBeingMoved)
        {
            //transform.position = new Vector3(pointOfParent.position.x, transform.position.y * Time.deltaTime, pointOfParent.position.z) ;
            transform.Translate(pointOfParent.position.x,pointOfParent.position.y,pointOfParent.position.z, transform);
           // transform.Translate(pointOfParent.position*Time.deltaTime);
            
        }
        
    }
}
