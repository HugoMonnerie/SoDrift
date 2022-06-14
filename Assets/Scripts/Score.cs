using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public static int ScoreValue { get; set; }
    [SerializeField] TextMeshProUGUI m_ScoreText;

    public static string raceStatus {get; set;}

    string timer;
    [SerializeField] TextMeshProUGUI m_TimerText;
    public static float startTime = 0;


    private void Awake() {
        raceStatus = "Ended";
    }

    // Update is called once per frame
    void Update()
    {
        m_ScoreText.text = ScoreValue.ToString();
        if (raceStatus == "Started"){
        m_TimerText.text = (Time.time - startTime).ToString();
        }
        else{
          m_TimerText.text = "0";   
        }
    }

    public static void startLinePassed(){
        if (raceStatus == "Ended"){
            raceStatus = "Started";
            startTime = Time.time;
        }
        else{
            raceStatus = "Ended";
            startTime = 0;
        }
        Debug.Log("Race Status " + raceStatus);
    }

}