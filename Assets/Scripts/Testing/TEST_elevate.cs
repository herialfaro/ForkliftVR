using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{

    /*<summary>
     this code is a limit checker for the elevation fo the fork.
     it has a callback to the fork to make it stop
      </summary>*/
    public class TEST_elevate : MonoBehaviour
    {
        AudioManager audioManager;
        public string _forkTag;
        public int _IDLimit;
        public bool isRotation = false;

        void Awake()
        {

            audioManager = FindObjectOfType<AudioManager>();
        }

        public void OnTriggerEnter(Collider _other)
        {
            if (_other.CompareTag(_forkTag))
            {
                if (isRotation)
                {
                    _other.GetComponent<RotateCrane>().ReachedLimit(this._IDLimit);
                    audioManager.StopLoopElevate();
                }
                else
                {
                    _other.GetComponent<ElevateCrane>().ReachedLimit(this._IDLimit);
                    audioManager.StopLoopElevate();
                }
            }
        }
    }
}
