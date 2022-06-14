using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] float m_TranslationSpeed; // m/s
    [SerializeField] float m_RotationSpeed; // °/s

    Rigidbody m_Rigidbody;

    void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    //COMPORTEMENT CINEMATIQUE
    // Update is called once per frame
    void Update()
    {
        /*
        float hInput = Input.GetAxisRaw("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        //Vector3 moveVect = vInput*transform.forward * m_TranslationSpeed * Time.deltaTime;
        //transform.Translate(moveVect, Space.World);

        Vector3 localMoveVect = new Vector3(0, 0, vInput * m_TranslationSpeed * Time.deltaTime);
        transform.Translate(localMoveVect, Space.Self);

        float deltaAngle = hInput * m_RotationSpeed * Time.deltaTime;
        transform.Rotate(transform.up, deltaAngle, Space.World);
        */
    }

    //COmportement dynamique (physique ... moteur PhysX)
    private void FixedUpdate()
    {
        float hInput = Input.GetAxisRaw("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        //MODE POSITIONNEL
        /*
        Vector3 moveVect = vInput * transform.forward * m_TranslationSpeed * Time.fixedDeltaTime;
        m_Rigidbody.MovePosition(m_Rigidbody.position + moveVect);

        float deltaAngle = hInput * m_RotationSpeed * Time.fixedDeltaTime;
        Quaternion qRot = Quaternion.AngleAxis(deltaAngle, transform.up);
        Quaternion qNewOrient = qRot * transform.rotation;
        m_Rigidbody.MoveRotation(qNewOrient);

        m_Rigidbody.AddForce(-m_Rigidbody.velocity, ForceMode.VelocityChange);
        m_Rigidbody.AddTorque(-m_Rigidbody.angularVelocity, ForceMode.VelocityChange);
        */
        //MODE VELOCITY
        
        Vector3 translationVelocity = vInput * transform.forward * m_TranslationSpeed;
        m_Rigidbody.AddForce(translationVelocity-m_Rigidbody.velocity, ForceMode.VelocityChange);

        Vector3 angularVelocity = hInput * transform.up * m_RotationSpeed * Mathf.Deg2Rad;
        m_Rigidbody.AddTorque(angularVelocity-m_Rigidbody.angularVelocity , ForceMode.VelocityChange);
    }
}
