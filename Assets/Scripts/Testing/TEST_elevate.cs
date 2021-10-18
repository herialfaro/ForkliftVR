using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_elevate : MonoBehaviour
{
    public string _forkTag;
    public int _IDLimit;
    public void OnTriggerEnter(Collider _other)
    {
        if(_other.CompareTag(_forkTag))
        {
            _other.GetComponent<ElevateCrane>().ReachedLimit(this._IDLimit);        
        }
    }
}
