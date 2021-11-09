using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_elevate : MonoBehaviour
{
    public string _forkTag;
    public int _IDLimit;
    public bool isRotation = false;

    public void OnTriggerEnter(Collider _other)
    {
        if(_other.CompareTag(_forkTag))
        {
            if(isRotation)
            {
                _other.GetComponent<RotateCrane>().ReachedLimit(this._IDLimit);

                }else
                {
                    _other.GetComponent<ElevateCrane>().ReachedLimit(this._IDLimit);        

                }
        }
    }
}
