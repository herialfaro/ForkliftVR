using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Valve.VR.InteractionSystem;
using Valve.VR;

namespace Valve.VR.InteractionSystem
{
    public class ButtonInt : MonoBehaviour
    {
        AudioManager audioManager;
        public HoverButton hoverButton;
        public CarController carController;
        public bool sound;

        
        private void Start()
        {
            this.hoverButton.onButtonDown.AddListener(OnButtonDown);
            audioManager = FindObjectOfType<AudioManager>();
        }

        private void OnButtonDown(Hand hand)
        {
            StartCoroutine(DoMove());
            audioManager.PlayStart();
            PlaySound();
        }


        private IEnumerator DoMove()
        {
            //movePosition = FindObjectOfType<MovePosition>();
            this.carController.ForMove();

            // Rigidbody rigidbody = moving.GetComponent<Rigidbody>();

            yield return null;
        }
        public void PlaySound()
        {
            if (!sound)
            {
                sound = true;
                audioManager.PlayStart();
            }
            else
            {
                sound = false;
                audioManager.PlayStop();
            }
        }
    }

}

