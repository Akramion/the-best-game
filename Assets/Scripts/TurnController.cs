using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TurnController : MonoBehaviour
{

    RiskManager manager;
    Deliverys deliverys;
    StoreController storeController;
    TeamController teamController;
    TeamControllerStore teamControllerStore;
    BuildController buildController;
    ScoreMain score;

    public GameObject panelMesseagePrefab;

    Image wether;
    public Sprite[] wethers;
    public int wetherCount = 0;


    string[] mounths;

    int turn = 1;

    int end = 0;
    private Text turnText;
    
    private void Start() {
        turnText = GameObject.Find("Turn").GetComponent<Text>();
        score = GameObject.Find("Score").GetComponent<ScoreMain>();
        manager = GameObject.FindGameObjectsWithTag("RiskManager")[0].GetComponent<RiskManager>();
        deliverys = GameObject.Find("Deliverys").GetComponent<Deliverys>();
        storeController = GameObject.Find("StoreController").GetComponent<StoreController>();
        teamController = GameObject.Find("TeamController").GetComponent<TeamController>();
        teamControllerStore = GameObject.Find("TeamControllerStore").GetComponent<TeamControllerStore>();
        buildController = GameObject.Find("BuildController").GetComponent<BuildController>();

        wether = GameObject.Find("Wether").GetComponent<Image>();

        score.ChangeScore(-10000000);

        mounths = new string[12];
        mounths[0] = "Июнь";
        mounths[1] = "Июль";
        mounths[2] = "Август";
        mounths[3] = "Сентябрь";
        mounths[4] = "Октябрь";
        mounths[5] = "Ноябрь";
        mounths[6] = "Декабрь";
        mounths[7] = "Янаврь";
        mounths[8] = "Февраль";
        mounths[9] = "Март";
        mounths[10] = "Апрель";
        mounths[11] = "Май";
    }
    public void NextTurn() {
        
        Timer timer = GameObject.Find("Time").GetComponent<Timer>();
        turn++;

        if (turn == 12) end++;

        if (end == 2) ShowEnd();

        if(turn == 24)
        {
            SceneManager.LoadScene("FinalStats", LoadSceneMode.Single);
        }


        ShowTurn();

        timer.ResetTimer();
        OffBlocks();
        deliverys.CheckDeliverys();

        buildController.CheckBuild();
        int teams = teamController.CheckTeams();
        int teamsStore = teamControllerStore.CheckTeams();
        score.ChangeScore(teams * 10000);
        score.ChangeScore(teamsStore * 10000);
        manager.ShowRisk();
    }

    public void ShowEnd()
    {
        GameObject canvas = GameObject.Find("Canvas");
        GameObject linkInputMesseage = (GameObject)Instantiate(panelMesseagePrefab);
        linkInputMesseage.transform.SetParent(canvas.transform, false);
    }

    public void OffBlocks() {
        GameObject.Find("StoreController").GetComponent<StoreController>().isBlock = false;
    }

    private void ShowTurn()
    {
        if (turn % 3 == 0f) ChangeWether();

        if (turn == 12) turn = 0;

        turnText.text = mounths[turn];
    }

    private void ChangeWether()
    {
        wetherCount++;

        if (wetherCount == 3) wetherCount = 0;

        wether.sprite = wethers[wetherCount];
    }
}
