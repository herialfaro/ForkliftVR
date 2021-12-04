using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCENTERoFmAS : MonoBehaviour
{
    public GameObject _centerMass;
    private Rigidbody m_rigid;

    private void Awake()
    {
        m_rigid = GetComponent<Rigidbody>();
        m_rigid.centerOfMass = _centerMass.transform.position;
        
    }

    // Start is called before the first frame update
    void Start()
    {
      
    }

   
}
