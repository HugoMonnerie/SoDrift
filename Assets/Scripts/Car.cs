using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Car : MonoBehaviour {
     
    private float hInput;
    private float vInput;
    private float currentSteerAngle;

    [SerializeField] private float motorForce;
    [SerializeField] private float maxSteerAngle;
    
    [SerializeField] private WheelCollider wheelBackLeftCollider; 
    [SerializeField] private WheelCollider wheelBackRightCollider; 
    [SerializeField] private WheelCollider wheelFrontLeftCollider; 
    [SerializeField] private WheelCollider wheelFrontRightCollider; 
    
    [SerializeField] private Transform wheelBackLeftTransform; 
    [SerializeField] private Transform wheelBackRightTransform; 
    [SerializeField] private Transform wheelFrontLeftTransform; 
    [SerializeField] private Transform wheelFrontRightTransform; 
    
    public void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    private void GetInput()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxis("Vertical");
    }

    private void HandleMotor()
    {
        wheelFrontLeftCollider.motorTorque = vInput * motorForce;
        wheelFrontRightCollider.motorTorque = vInput * motorForce;
    }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * hInput;
        wheelFrontLeftCollider.steerAngle = currentSteerAngle;
        wheelFrontRightCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(wheelFrontLeftCollider, wheelFrontLeftTransform);
        UpdateSingleWheel(wheelFrontRightCollider, wheelFrontRightTransform);
        UpdateSingleWheel(wheelBackLeftCollider, wheelBackLeftTransform);
        UpdateSingleWheel(wheelBackRightCollider, wheelBackRightTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }

    public void incrementSpeed(){
        motorForce += 500;
    }

    void OnTriggerEnter(Collider other){
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (other.gameObject.tag == "Piece")
        {
            Destroy(other.gameObject);
            incrementSpeed();
        }
    }
}