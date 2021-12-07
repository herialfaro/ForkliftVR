using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Valve.VR.InteractionSystem
{
    public class LeverMovement : MonoBehaviour
    {
        public LinearMapping linearMapping;
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (linearMapping == null)
            {
                linearMapping = GetComponent<LinearMapping>();
            }
        }
    }
}
