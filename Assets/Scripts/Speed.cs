using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Speed : MonoBehaviour
{
    [SerializeField] TMP_Text m_SpeedText;

    [SerializeField] private WheelCollider m_wheelCollider;
    // Update is called once per frame
    void Update()
    {
        m_SpeedText.text = m_wheelCollider.rpm.ToString() + " RPM";
    }
}
