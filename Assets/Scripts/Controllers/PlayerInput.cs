using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class PlayerInput : MonoBehaviour
{
    public float Acceleration
    {
        get { return m_Acceleration; }
    }

    public float Steering
    {
        get { return m_Steering; }
    }

    float m_Acceleration;
    float m_Steering;

    bool m_FixedUpdateHappened;

    private bool accelerating = false;
    private bool breaking = false;
    private bool turningLeft = false;
    private bool turningRight = false;

    public float wheelDampening;

    private void Update()
    {

        GetPlayerInput();
        
        if (accelerating)
        {
            m_Acceleration = 1f;
            wheelDampening = 500f;
        }

        else if (breaking)
        {
            m_Acceleration = -0.5f;
            wheelDampening = 10000;
        }

        else
        {
            m_Acceleration = 0f;
            wheelDampening = 5f;
        }

        if (turningLeft)
            m_Steering = -1f;
        else if (!turningLeft && turningRight)
            m_Steering = 1f;
        else
            m_Steering = 0f;
    }

    private void GetPlayerInput()
    {
        bool Accelerate = SteamVR_Input.GetState("Accelerate", SteamVR_Input_Sources.RightHand);
        bool Break = SteamVR_Input.GetState("Break", SteamVR_Input_Sources.LeftHand);
        bool TurnLeft = SteamVR_Input.GetState("TurnLeft", SteamVR_Input_Sources.LeftHand);
        bool TurnRight = SteamVR_Input.GetState("TurnRight", SteamVR_Input_Sources.RightHand);
    }
}
