using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RiskManager : MonoBehaviour
{
    public Risk[]  risks;

    public int response;

    public GameObject panelMesseagePrefab;

    public void RiskCheckEvent() {
        Data data = GameObject.Find("Data").GetComponent<Data>();
        RiskEvent riskEvent = GameObject.Find("RiskEvent").GetComponent<RiskEvent>();
        Debug.Log("Risk" + data.risks[0]);
        switch(data.risks[0]) {
            case 0: break;
            case 1: riskEvent.ChangeGovernment(); break;
            case 2: break;
            case 3: break;
            case 4: break;
            case 5: break;
            case 6: break;
            case 7: riskEvent.FailedDelivery(); break;;
            case 8: break;
            case 9: riskEvent.Shtorm(); break;
            case 10: break;
        }

        data.risks[0] = -1;
    }

    public void ShowRisk() {
        int count = Random.Range(0, 10);

        GameObject canvas = GameObject.Find("Canvas");
        Data data = GameObject.Find("Data").GetComponent<Data>();
        data.risks[0] = count;

        GameObject linkInputMesseage = (GameObject)Instantiate(panelMesseagePrefab); 
        linkInputMesseage.transform.SetParent(canvas.transform, false);

        Image riskImage = GameObject.Find("RiskImage").GetComponent<Image>();  
        Image responseImage = GameObject.Find("ResponseImage").GetComponent<Image>();  

        riskImage.sprite = risks[count].sprite;

        ResponseManager responseManager = GameObject.Find("InventoryData").GetComponent<ResponseManager>();

        Response[]  responses = responseManager.responses;

        for(int i = 0; i < responses.Length; i++) {
            if(responses[i] != null) {
                if(responses[i].name == risks[count].name) {
                    responseImage.sprite = responses[i].image.sprite;
                    response = i;
                    // responseManager.DeleteResponse(i);
                    break;
                }
            }
        }
    }

     

}
