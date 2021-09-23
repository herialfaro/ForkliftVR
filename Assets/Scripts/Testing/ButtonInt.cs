using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Valve.VR.InteractionSystem;
using Valve.VR;

    public class ButtonInt : MonoBehaviour
    {
    public HoverButton hoverButton;
    public MovePosition movePosition;

    private void Start()
    {
        hoverButton.onButtonDown.AddListener(OnButtonDown);
    }

    private void OnButtonDown(Hand hand)
    {
        StartCoroutine(DoMove());
    }


    private IEnumerator DoMove()
    {
        movePosition = FindObjectOfType<MovePosition>();
        movePosition.ForMove();

        // Rigidbody rigidbody = moving.GetComponent<Rigidbody>();

        yield return null;
    }
}

