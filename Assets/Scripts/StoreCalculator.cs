using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreCalculator : MonoBehaviour
{

    public int resA = 0;
    public int resB = 0;
    public int resC = 0;

    StoreCalculator storeCalculator;
    TurnController turnController;
    Dropdown type;

    void Start()
    {
        storeCalculator = GameObject.Find("Calculator").GetComponent<StoreCalculator>();
        turnController = GameObject.Find("NextTurn").GetComponent<TurnController>();
        type = GameObject.Find("LoseInput").GetComponent<Dropdown>();
    }

    public void CalculateLow()
    {
        storeCalculator.resA = System.Convert.ToInt32(gameObject.GetComponent<InputField>().text);
        storeCalculator.ShowResult();
    }

    public void CalculateMed()
    {
        storeCalculator.resB = System.Convert.ToInt32(gameObject.GetComponent<InputField>().text);
        storeCalculator.ShowResult();
    }

    public void CalculateHigh()
    {
        storeCalculator.resC = System.Convert.ToInt32(gameObject.GetComponent<InputField>().text);
        storeCalculator.ShowResult();
    }

    public void ChangeType()
    {

    }

    public void ShowResult()
    {
        Text text = gameObject.GetComponent<Text>();
        List<Dropdown.OptionData> menuOptions = type.GetComponent<Dropdown>().options;
        string value = menuOptions[type.value].text;
        float allRes = (float) resA + resB + resC;
        int wether = turnController.wetherCount;

        float countBuilders = 0;
        float countTransport = 0;

        switch (value)
        {
            case "Морской":

                switch (wether)
                {
                    case 0: countTransport = Mathf.Ceil(allRes / 4); break;
                    case 1: countTransport = Mathf.Ceil(allRes / 9); break;
                    case 2: countTransport = Mathf.Ceil(allRes / 6); break;
                }
          
                countBuilders = countTransport;
                break;

            case "Наземный":
                countTransport = Mathf.Ceil(allRes / 8);
                countBuilders = countTransport;
                break;

            case "Воздушный":
                switch (wether)
                {
                    case 0: countTransport = Mathf.Ceil(allRes / 8); break;
                    case 1: countTransport = Mathf.Ceil(allRes / 5); break;
                    case 2: countTransport = Mathf.Ceil(allRes / 2); break;
                }

                countBuilders = countTransport;
                break;
        }

        text.text = countTransport.ToString() + " едениц техники " + countBuilders.ToString() + " бригад";





    }
}
