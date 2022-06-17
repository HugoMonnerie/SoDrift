using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_ScoreText;
    [SerializeField] TextMeshProUGUI m_TimerText;
    [SerializeField] private int m_mapNumber;

    public static int piecesCount {get; set;}
    public static string raceStatus {get; set;}
    string timer;
    public static float startTime = 0;
    public static bool[] checkPointsPassed;
    static int scoreLabelStatic;

    private void Awake() {
        raceStatus = "Ended";
        checkPointsPassed = new bool[3] {false, false, false};
        scoreLabelStatic = m_mapNumber;
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
            float raceTimeScore = Time.time - startTime;
            string scoreLabel = "BestScore" + scoreLabelStatic.ToString();
            float oldTime = PlayerPrefs.GetFloat(scoreLabel, 9999999); 
            Debug.Log(raceTimeScore.ToString() + "/" + oldTime.ToString());
            if (raceTimeScore < oldTime){
                PlayerPrefs.SetFloat(scoreLabel, raceTimeScore);
                PlayerPrefs.Save();
            }
            startTime = 0;
        }

    }

    public static void checkPointPassed (int checkPointNumber){
        checkPointsPassed[checkPointNumber-1] = true;

    }

}