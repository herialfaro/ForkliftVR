using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    public class CarController : MonoBehaviour
    {
        public LinearMapping linearMapping;
        private const string HORIZONTAL = "Horizontal";
        private const string VERTICAL = "Vertical";

        private float horizontalInput;
        private float vertivalInput;
        private float currentBreakForce;
        private bool isBreaking;
        private float currentSteerAngle;

        [SerializeField] private float motorForce;
        [SerializeField] private float negativeMotorForce;
        [SerializeField] private float breakForce;
        [SerializeField] private float maxSteerAngle;

        [SerializeField] private bool moving;

        [Header("Wheels")]
        [SerializeField] private WheelCollider frontLeftWheel;
        [SerializeField] private WheelCollider frontRightWheel;
        [SerializeField] private WheelCollider rearLeftWheel;
        [SerializeField] private WheelCollider rearRightWheel;

        [SerializeField] private Transform frontLeftTransform;
        [SerializeField] private Transform frontRightTransform;
        [SerializeField] private Transform rearLeftTransform;
        [SerializeField] private Transform rearRightTransform;

        private void FixedUpdate()
        {
            if (linearMapping == null)
            {
                linearMapping = GetComponent<LinearMapping>();
            }

            if (moving)
            {
                GetInput();
                HandleMotor();
                HandleSteering();
                UpdateWheels();
                AddForceCar();
            }
        }

        private void HandleMotor()
        {
            rearLeftWheel.motorTorque = vertivalInput * motorForce;
            rearRightWheel.motorTorque = vertivalInput * motorForce;
            currentBreakForce = isBreaking ? breakForce : 0.05f;

            if (isBreaking)
            {
                ApplyBreaking();
            }

        }

        private void AddForceCar()
        {
            
            if (linearMapping.value < 0.4)
            {
                motorForce = 1000;
                rearLeftWheel.motorTorque = motorForce;
                rearRightWheel.motorTorque = motorForce;
                Debug.Log("Adding force");
            }

            if (linearMapping.value > 0.6)
            {
                motorForce = -1000;
                rearLeftWheel.motorTorque = motorForce;
                rearRightWheel.motorTorque = motorForce;
            }

            if (linearMapping.value < 0.58 || linearMapping.value > 0.38)
            {
                motorForce = 0;
            }
        }

        private void ApplyBreaking()
        {
            frontRightWheel.brakeTorque = currentBreakForce;
            frontLeftWheel.brakeTorque = currentBreakForce;
            rearRightWheel.brakeTorque = currentBreakForce;
            rearLeftWheel.brakeTorque = currentBreakForce;
        }

        private void GetInput()
        {
            horizontalInput = Input.GetAxis(HORIZONTAL);
            vertivalInput = Input.GetAxis(VERTICAL);
            isBreaking = Input.GetKey(KeyCode.Space);
        }

        private void HandleSteering()
        {
            currentSteerAngle = maxSteerAngle * horizontalInput;
            rearLeftWheel.steerAngle = currentSteerAngle;
            rearRightWheel.steerAngle = currentSteerAngle;
        }

        private void UpdateWheels()
        {
            UpdateSingleWheel(frontLeftWheel, frontLeftTransform);
            UpdateSingleWheel(frontRightWheel, frontRightTransform);
            UpdateSingleWheel(rearLeftWheel, rearLeftTransform);
            UpdateSingleWheel(rearRightWheel, rearRightTransform);
        }

        private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
        {
            Vector3 pos;
            Quaternion rot;
            wheelCollider.GetWorldPose(out pos, out rot);
            wheelTransform.rotation = rot;
            wheelTransform.position = pos;
        }

        public void ForMove()
        {
            if (!moving)
            {
                moving = true;
            }
            else
            {
                moving = false;
            }
        }
    }

}
