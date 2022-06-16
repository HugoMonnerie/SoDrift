using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class Score : MonoBehaviour
{
    public static int piecesCount { get; set; }
    [SerializeField] TextMeshProUGUI m_ScoreText;

    public static string raceStatus {get; set;}

    string timer;
    [SerializeField] TextMeshProUGUI m_TimerText;
    public static float startTime = 0;

    [SerializeField] GameObject m_CheckPoint1;
    [SerializeField] GameObject m_CheckPoint2;
    [SerializeField] GameObject m_CheckPoint3;

    public static bool[] checkPointsPassed;

    private void Awake() {
        raceStatus = "Ended";
        checkPointsPassed = new bool[3] {false, false, false};
    }
    

    // Update is called once per frame
    void Update()
    {
        m_ScoreText.text = piecesCount.ToString();
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
            checkPointsPassed = new bool[3] {false, false, false};
        }
        else if (!checkPointsPassed.Contains(false)){
            raceStatus = "Ended";
            startTime = 0;
        }
    }

    public static void checkPointPassed (int checkPointNumber){
        checkPointsPassed[checkPointNumber-1] = true;

    }

}