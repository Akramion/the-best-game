using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiskEvent : MonoBehaviour
{
    public void ChangeGovernment() {
         ScoreMain score = GameObject.Find("Score").GetComponent<ScoreMain>();
         score.ChangeScore(300000);
    }

    public void Shtorm() {
        TurnController turnController = GameObject.Find("NextTurn").GetComponent<TurnController>();
        turnController.NextTurn();
    }

    public void FailedDelivery() {
        GameObject.Find("StoreController").GetComponent<StoreController>().isBlock = true;
    }
}
