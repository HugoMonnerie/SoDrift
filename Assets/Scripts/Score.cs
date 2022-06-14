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


    private void Awake() {
        raceStatus = "Ended";
    }

    // Update is called once per frame
    void Update()
    {
        m_ScoreText.text = ScoreValue.ToString();
        
    }

    public static void startLinePassed(){
        if (raceStatus == "Ended"){
            raceStatus = "started";
        }
        else{
            raceStatus = "Ended";
        }
        Debug.Log("Race Status " + raceStatus);
    }

}