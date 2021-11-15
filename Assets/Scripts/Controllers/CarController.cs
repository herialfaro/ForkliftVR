using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    public class CarController : MonoBehaviour
    {
        public LinearMapping linearMapping;
        public LinearMapping wheelMapping;
        private const string HORIZONTAL = "Horizontal";
        private const string VERTICAL = "Vertical";

        private float horizontalInput;
        private float vertivalInput;
        private float currentBreakForce;
        private float currentSteerAngle;
      

        


        [Header("Movement")]
        [SerializeField] private float motorForce;
        [SerializeField] private float aceleractionForce;
        [SerializeField] private float breakForce;
        [SerializeField] private float maxSteerAngle;

        [SerializeField] private bool moving;
        [SerializeField] private bool isBreaking;

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
                HandleSteeringMapping();
                UpdateWheels();
                AddForceCar();
                ApplyBreaking();
            }
           
        }

        private void HandleMotor()
        {
            rearLeftWheel.motorTorque = vertivalInput * motorForce;
            rearRightWheel.motorTorque = vertivalInput * motorForce;
          

        }

        private void AddForceCar()
        {
            
            if (linearMapping.value < 0.1)
            {
                motorForce = -aceleractionForce;
                rearLeftWheel.motorTorque = motorForce;
                rearRightWheel.motorTorque = motorForce;
                Debug.Log("Adding force");
                isBreaking = false;
                FindObjectOfType<AudioManager>().Play("Reverse");
            }

            if (linearMapping.value > 0.9)
            {
                motorForce = aceleractionForce;
                rearLeftWheel.motorTorque = motorForce;
                rearRightWheel.motorTorque = motorForce;
                isBreaking = false;

                FindObjectOfType<AudioManager>().Play("Accelerate");
            }

            if (linearMapping.value < 0.8 && linearMapping.value > 0.2)
            {              
                isBreaking = true;
            }
        }

        private void ApplyBreaking()
        {
            if (isBreaking)
            {         
                rearRightWheel.brakeTorque = breakForce;
                rearLeftWheel.brakeTorque = breakForce;

                rearRightWheel.motorTorque = 0;
                rearLeftWheel.motorTorque = 0;
            }
            else
            {
                rearRightWheel.brakeTorque = 0;
                rearLeftWheel.brakeTorque = 0;
            }
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
        private void HandleSteeringMapping()
        {
            float _normalizedMaping = 0f;
      
            _normalizedMaping = Mathf.Lerp(-1f,1f,wheelMapping.value);
            currentSteerAngle = maxSteerAngle * _normalizedMaping;
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
