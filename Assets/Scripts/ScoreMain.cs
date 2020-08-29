using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMain : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Text txt = GameObject.Find("Score").GetComponent<Text>();
        Data data = GameObject.Find("Data").GetComponent<Data>();
        int score = data.score; 

        txt.text = score.ToString() + "$";
    }

    public void ChangeScore(int newScore)  {
        Text txt = GameObject.Find("Score").GetComponent<Text>();
        Data data = GameObject.Find("Data").GetComponent<Data>();
        int score = data.score;
        score = score - newScore;

        txt.text = score.ToString() + "$";
        data.SetScore(score);

    }
}
