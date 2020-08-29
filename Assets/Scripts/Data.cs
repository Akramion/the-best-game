using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{

    public int[]  risks; 
    public int score;
    public int spendScore = 0;

    public bool isWindowOpen = false;
    // Start is called before the first frame update
    private void Awake() {
        DontDestroyOnLoad(this);
        score = 1400000;
        risks = new int[10];
    }

    public void SetScore(int newScore) {
        if(newScore < score) {
            spendScore += score - newScore;
        }
        score = newScore;
    }
}
