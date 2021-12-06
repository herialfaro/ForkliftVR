using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Valve.VR.InteractionSystem;
using Valve.VR;

namespace Valve.VR.InteractionSystem
{
    public class ButtonInstruction : MonoBehaviour
    {
        public HoverButton hoverButton;

        public GameObject txtInitial;
        public GameObject[] Panels;
        public int nextPanel;


        private void Start()
        {
            this.hoverButton.onButtonDown.AddListener(OnButtonDown);      
        }

        private void OnButtonDown(Hand hand)
        {
            nextPanel++;
        }

        private void Update()
        {
            if (nextPanel == 1)
            {
                txtInitial.SetActive(false);
                Panels[1].SetActive(true);
            }
            else if (nextPanel == 2)
            {
                Panels[1].SetActive(false);
                Panels[2].SetActive(true);
            }

            else if (nextPanel == 3)
            {
                Panels[2].SetActive(false);
                Panels[3].SetActive(true);
            }

            else if (nextPanel == 4)
            {
                Panels[3].SetActive(false);
                Panels[4].SetActive(true);
            }

            else if (nextPanel == 5)
            {
                Panels[4].SetActive(false);
                Panels[5].SetActive(true);
            }




        }


    }

}