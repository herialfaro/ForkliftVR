using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryRigidBody : MonoBehaviour
{
    public string _tagToCarry;
    public List<Rigidbody> rigidbodies = new List<Rigidbody>();

    public Vector3 LastPosition;
    Transform _transform;
    // Start is called before the first frame update
    void Start()
    {
        _transform = transform;
        LastPosition = _transform.position;
    }
    private void LateUpdate()
    {
        if(rigidbodies.Count >0)
        {
            for (int i = 0; i < rigidbodies.Count; i++)
            {
                Rigidbody rb = rigidbodies[i];
                Vector3 velocity = (_transform.position - LastPosition);
                rb.transform.Translate(velocity);
            }

        }
        LastPosition = transform.position;
    }

    private void OnCollisionEnter(Collision other)
    {
        Rigidbody rb = other.collider.GetComponent<Rigidbody>();
       
            if(rb != null)
            {
                Add(rb);
            }

      
    }
    private void OnCollisionExit(Collision other)
    {
        Rigidbody rb = other.collider.GetComponent<Rigidbody>();
        
            if (rb != null)
            {
                Remove(rb);
            }
        
    }

    //Functions

    void Add(Rigidbody _rb)
    {
        rigidbodies.Add(_rb);
    }

    void Remove(Rigidbody _rb)
    {
        if(rigidbodies.Contains(_rb))
            rigidbodies.Remove(_rb);
    }
}
