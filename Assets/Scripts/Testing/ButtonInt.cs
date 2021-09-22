using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Valve.VR.InteractionSystem;
using Valve.VR;

    public class ButtonInt : MonoBehaviour
    {
        public HoverButton hoverButton;
    public MovePosition movePosition;
        private bool move;
       
       


        private void Start()
        {
            hoverButton.onButtonDown.AddListener(OnButtonDown);
        }

        private void OnButtonDown(Hand hand)
        {
           if (!move)
           {

            StartCoroutine(DoMove());
            move = true;
               
           }
           else
           {
            move = false;
           }
        }

        


        private IEnumerator DoMove()
        {
            movePosition = FindObjectOfType<MovePosition>();
            movePosition.MoveCar();

            // Rigidbody rigidbody = moving.GetComponent<Rigidbody>();

            yield return null;
        }
    }

