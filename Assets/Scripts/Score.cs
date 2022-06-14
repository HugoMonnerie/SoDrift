using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public static int ScoreValue { get; set; }
    [SerializeField] TextMeshProUGUI m_ScoreText;

    // Update is called once per frame
    void Update()
    {
        m_ScoreText.text = ScoreValue.ToString();
    }
}