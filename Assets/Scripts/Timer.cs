using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float time = 1200f;
    private Text timer;

    private void Awake() {
        timer = GameObject.Find("Time").GetComponent<Text>();
    }

    void Update()
    {
        time -= Time.deltaTime;

        if(time <= 0) {
            RiskManager riskManager = GameObject.Find("RiskManager").GetComponent<RiskManager>();
            riskManager.ShowRisk();
            time = 1200f;
        }
        
        ShowTime();
    }

    private void ShowTime() {
        float showTime = Mathf.Round(time);
        string outputTime = "";
 
        float minutes = Mathf.Floor(showTime / 60);
        float seconds = showTime - (minutes * 60);

        if(seconds < 10) outputTime = minutes.ToString() + ":0" + seconds.ToString();

        else outputTime = minutes.ToString() + ":" + seconds.ToString();

        timer.text = outputTime;
    }

    public void ResetTimer() {
        time = 300f;
    }

}
