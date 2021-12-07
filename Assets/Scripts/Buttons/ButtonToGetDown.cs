using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Valve.VR.InteractionSystem;
using Valve.VR;

public class ButtonToGetDown : MonoBehaviour
{
    public HoverButton hoverButton;

    Parent parent;

    public Transform downPos;
    public Transform player;

    public bool tranformPos = false;
    public bool doFunction = false;

    private void Start()
    {
        this.hoverButton.onButtonDown.AddListener(OnButtonDown);
        parent = FindObjectOfType<Parent>();
    }

    private void Update()
    {
        if (tranformPos)
        {
            player.transform.position = downPos.position;
        }

        if (doFunction)
        {
            ForGetDown();
            tranformPos = true;
            StartCoroutine(StopTranform());
        }
    }

    private void OnButtonDown(Hand hand)
    {
        doFunction = true;
    }

    public void ForGetDown()
    {
        parent.GetDown();
        
    }

    IEnumerator StopTranform()
    {
        yield return new WaitForSeconds(2f);
        tranformPos = false;
        doFunction = false;
    }
  
}
