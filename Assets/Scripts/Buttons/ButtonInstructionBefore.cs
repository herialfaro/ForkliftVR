using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Valve.VR.InteractionSystem;
using Valve.VR;

namespace Valve.VR.InteractionSystem
{
    public class ButtonInstructionBefore : MonoBehaviour
    {
        public HoverButton hoverButton;
        ButtonInstruction buttonInstruction;

        private void Start()
        {
            this.hoverButton.onButtonDown.AddListener(OnButtonDown);
            buttonInstruction = FindObjectOfType<ButtonInstruction>();
        }

        private void OnButtonDown(Hand hand)
        {
            buttonInstruction.NegativeIndex();
        }

      
    }
}
