using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Car : MonoBehaviour {
     
    private float hInput;
    private float vInput;
    private float currentSteerAngle;
    private float currentbreakForce;
    private bool isBreaking;
    private float targetSteerAngle = 0;
    
    [SerializeField] private float speedBoost; // m/s
    
    Rigidbody m_Rigidbody;

    void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    [SerializeField] private float turnSpeed;

    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
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
        LerpToSteerAngle();
    }

    private void GetInput()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxis("Vertical");
        isBreaking = Input.GetKey(KeyCode.Space);
    }

    private void HandleMotor()
    {
        /*wheelBackLeftCollider.motorTorque = vInput * motorForce;
        wheelBackRightCollider.motorTorque = vInput * motorForce;*/
        wheelFrontLeftCollider.motorTorque = vInput * motorForce;
        wheelFrontRightCollider.motorTorque = vInput * motorForce;
        
        currentbreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();
    }
    
    private void ApplyBreaking()
    {
        wheelBackLeftCollider.brakeTorque = currentbreakForce;
        wheelBackRightCollider.brakeTorque = currentbreakForce;
        wheelFrontLeftCollider.brakeTorque = currentbreakForce;
        wheelFrontRightCollider.brakeTorque = currentbreakForce;
    }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * hInput;
        targetSteerAngle = currentSteerAngle;
        /*wheelFrontLeftCollider.steerAngle = currentSteerAngle;
        wheelFrontRightCollider.steerAngle = currentSteerAngle;*/
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
        motorForce += 100;
    }

    private void LerpToSteerAngle()
    {
        wheelFrontRightCollider.steerAngle =
            Mathf.Lerp(wheelFrontRightCollider.steerAngle, targetSteerAngle, Time.deltaTime * turnSpeed);
        wheelFrontLeftCollider.steerAngle =
            Mathf.Lerp(wheelFrontLeftCollider.steerAngle, targetSteerAngle, Time.deltaTime * turnSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "SpeedBoost":
                Vector3 translationVelocity = vInput * transform.forward * speedBoost;
                m_Rigidbody.AddForce(translationVelocity-m_Rigidbody.velocity, ForceMode.VelocityChange);
                break;
        }
        else if (other.gameObject.tag == "StartLine"){
        case "Piece":
            Destroy(other.gameObject);
            if (Score.piecesCount <10){
                incrementSpeed();
                Score.piecesCount++;
            }
            break;
        case "StartLine":
            Score.startLinePassed();
            break;
        case "CheckPoint":
            Score.checkPointPassed(int.Parse(other.gameObject.name.Split("_")[1]));
            break;
        default:
            break;
        }

    
    }
}