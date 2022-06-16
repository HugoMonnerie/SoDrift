using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheels : MonoBehaviour
{
    public static WheelCollider m_wheelCollider { get; set; }
    
    void Awake()
    {
        m_wheelCollider = GetComponent<WheelCollider>();
    }
}
