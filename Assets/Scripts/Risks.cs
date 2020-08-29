using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Risks : MonoBehaviour
{
    public void ChangeScore() {
        Text txt = GameObject.Find("Score").GetComponent<Text>();
        Data data = GameObject.Find("Data").GetComponent<Data>();
        int score = data.score;

        switch(this.name)
        {
            case "risk1":
                score -= 45000;
                break;
            case "risk2":
                score -= 100000;
                break;
            case "risk3":
            score -= 55000;
                break;
            case "risk4":
            score -= 50000;
                break;
            case "risk5":
            score -= 100000;
                break;
            case "risk6":
                score -= 15000;
                break;
            case "risk7":
                score -= 40000;
                break;
            case "risk8":
            score -= 20000;
                break;
            case "risk9":
            score -= 50000;
                break;
            case "risk10":
            score -= 500000;
                break;
            case "risk11":
                score -= 60000;
                break;
            case "risk12":
                score -= 30000;
                break;
            case "risk13":
            score -= 20000;
                break;
            case "risk14":
            score -= 15000;
                break;
            case "risk15":
            score -= 45000;
                break;
            case "risk16":
                score -= 15000;
                break;
            case "risk17":
                score -= 100000;
                break;
            case "risk18":
            score -= 35000;
                break;
            case "risk19":
            score -= 25000;
                break;
            case "risk20":
            score -= 50000;
                break;
        }

        if(score > 0) {
            txt.text = score.ToString() + "$";
            data.SetScore(score);

            Image image = gameObject.GetComponent<Image>();
            string name = this.name;

            ResponseManager responseManager = GameObject.Find("InventoryData").GetComponent<ResponseManager>();

            responseManager.AddResponse(name, image);
        }



    }

    public void startMainScene() {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

    public void StartResponseScene() {
        SceneManager.LoadScene("ResponseMeasures", LoadSceneMode.Single);
    }
}
