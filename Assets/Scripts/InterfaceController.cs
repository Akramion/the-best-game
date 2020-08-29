using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceController : MonoBehaviour
{

    public GameObject panelMesseagePrefab;
    public GameObject helpPanel;
    public GameObject[] helpBuilds;


   
   public void AddMoney() {
        Text txt = GameObject.Find("Score").GetComponent<Text>();
        Data data = GameObject.Find("Data").GetComponent<Data>();
        int score = data.score;

        score += 1400000;
        txt.text = score.ToString();
        data.SetScore(score);
   }

   public bool isAllowOpenWindow() {
       Data data = GameObject.Find("Data").GetComponent<Data>();
       return data.isWindowOpen;
   }

   public void SetIsAllopenWindow() {
       Data data = GameObject.Find("Data").GetComponent<Data>();
        data.isWindowOpen = true;
   }

   public void OpenMesseage() {


        if(gameObject.name == "OpenRequestMoneyPanel") {
            Destroy(gameObject);
        }

        GameObject helpPanelDestroy = GameObject.FindWithTag("HelpPanel");;
        Destroy(helpPanelDestroy);

        GameObject canvas = GameObject.Find("Canvas");
        GameObject linkInputMesseage = (GameObject)Instantiate(panelMesseagePrefab); 
        linkInputMesseage.transform.SetParent(canvas.transform, false);
   }



   public void OpenSpendMoneyPanel() {


        GameObject canvas = GameObject.Find("Canvas");
        GameObject linkInputMesseage = (GameObject)Instantiate(panelMesseagePrefab); 
        linkInputMesseage.transform.SetParent(canvas.transform, false);

        Data data = GameObject.Find("Data").GetComponent<Data>();
        int score = data.spendScore;

        Text spendMoneyOutput = GameObject.Find("AllSpendMoneyOutput").GetComponent<Text>();  
        spendMoneyOutput.text = score.ToString();
   }

   public void CloseMesseage() {
       GameObject panelMesseage = GameObject.FindWithTag("Window");
       Destroy(panelMesseage);

        Data data = GameObject.Find("Data").GetComponent<Data>();
        data.isWindowOpen = false;
    }

   public void CloseMesseageAndEventRisk() {
        GameObject panelMesseage = GameObject.FindWithTag("Window");
        Destroy(panelMesseage);
        RiskManager riskManager = GameObject.Find("RiskManager").GetComponent<RiskManager>(); 
        riskManager.RiskCheckEvent();
        SetIsAllopenWindow();      
   }

   public void CloseMesseageAndDeleteResponse() {
        GameObject panelMesseage = GameObject.FindWithTag("Window");;
        Destroy(panelMesseage);     
        RiskManager riskManager = GameObject.Find("RiskManager").GetComponent<RiskManager>(); 
        ResponseManager responseManager = GameObject.Find("InventoryData").GetComponent<ResponseManager>();

        if(responseManager.responses[riskManager.response] != null) {
            responseManager.DeleteResponse(riskManager.response);
        }
        SetIsAllopenWindow();
   }

   public void RequestMoney() {
        Text txt = GameObject.Find("Score").GetComponent<Text>();
        Data data = GameObject.Find("Data").GetComponent<Data>();
        InputField input = GameObject.Find("RequestMoneyInput").GetComponent<InputField>();
        int score = data.score;
        int newScore = System.Convert.ToInt32(input.text);

        score += newScore;
        txt.text = score.ToString();
        data.SetScore(score);


        GameObject panelMesseage = GameObject.Find("RequestMoney(Clone)");
        Destroy(panelMesseage);

        SetIsAllopenWindow();
   }

    public void ShowHelpPanel() {
        GameObject canvas = GameObject.Find("Canvas");
        Vector3 worldDirection = transform.TransformPoint(this.transform.position);

        GameObject helpPanelLink = (GameObject)Instantiate(helpPanel); 
        helpPanelLink.transform.SetParent(canvas.transform, false);

        Vector3 helpPanelPos = gameObject.transform.position;
        helpPanelPos.x -= 2.8f;
        helpPanelLink.transform.position = helpPanelPos;
    }

    public void ShowHelpPanelUp() {
        GameObject canvas = GameObject.Find("Canvas");
        Vector3 worldDirection = transform.TransformPoint(this.transform.position);

        GameObject helpPanelLink = (GameObject)Instantiate(helpPanel); 
        helpPanelLink.transform.SetParent(canvas.transform, false);

        Vector3 helpPanelPos = gameObject.transform.position;
        helpPanelPos.y += 1.2f;
        helpPanelPos.x += 1.5f;
        helpPanelLink.transform.position = helpPanelPos;
    }

    public void ShowHelpPanelBuild()
    {
        GameObject canvas = GameObject.Find("Canvas");
        BuildController buildController = GameObject.Find("BuildController").GetComponent<BuildController>();
        int count = buildController.spriteCount;
        Vector3 worldDirection = transform.TransformPoint(this.transform.position);



        GameObject helpPanelLink = (GameObject)Instantiate(helpBuilds[count]);
        helpPanelLink.transform.SetParent(canvas.transform, false);

        Vector3 helpPanelPos = gameObject.transform.position;
        helpPanelPos.y += 1.8f;
        helpPanelPos.x += 2f;
        helpPanelLink.transform.position = helpPanelPos;
    }

    public void CloseHelpPanel() {
       GameObject helpPanelDestroy = GameObject.FindWithTag("HelpPanel");;
       Destroy(helpPanelDestroy);
    }

     public void CloseInventory() {
        GameObject inventory = GameObject.Find("Inventory");
        inventory.SetActive(false);
    }

    public void ShowInventory() {
        GameObject.Find("Main Camera").GetComponent<ShowInventory>().InventoryOn();
    }

   public void ShowSmallStore() {
        GameObject canvas = GameObject.Find("Canvas");
        GameObject linkInputMesseage = (GameObject)Instantiate(panelMesseagePrefab); 
        linkInputMesseage.transform.SetParent(canvas.transform, false);   

        Text resourceA = GameObject.Find("ResourceA").GetComponent<Text>(); 
        Text resourceB = GameObject.Find("ResourceB").GetComponent<Text>(); 
        Text resourceC = GameObject.Find("ResourceC").GetComponent<Text>(); 

        StoreController storeController = GameObject.Find("StoreController").GetComponent<StoreController>(); 
        int[] smallStore = storeController.ShowSmallStore();

        resourceA.text = smallStore[0].ToString();
        resourceB.text = smallStore[1].ToString();
        resourceC.text = smallStore[2].ToString();
   }

   public void ShowBigStore() {
        GameObject canvas = GameObject.Find("Canvas");
        GameObject linkInputMesseage = (GameObject)Instantiate(panelMesseagePrefab); 
        linkInputMesseage.transform.SetParent(canvas.transform, false);   

        Text resourceA = GameObject.Find("ResourceA").GetComponent<Text>(); 
        Text resourceB = GameObject.Find("ResourceB").GetComponent<Text>(); 
        Text resourceC = GameObject.Find("ResourceC").GetComponent<Text>(); 

        StoreController storeController = GameObject.Find("StoreController").GetComponent<StoreController>(); 
        int[] bigStore = storeController.ShowBigStore();

        resourceA.text = bigStore[0].ToString();
        resourceB.text = bigStore[1].ToString();
        resourceC.text = bigStore[2].ToString();
   }

   public void AddToSmallStore() {
      StoreController storeController = GameObject.Find("StoreController").GetComponent<StoreController>();  

      InputField ResourceAInput = GameObject.Find("InputResourceA").GetComponent<InputField>();
      InputField ResourceBInput = GameObject.Find("InputResourceB").GetComponent<InputField>();
      InputField ResourceCInput = GameObject.Find("InputResourceC").GetComponent<InputField>();

      int[] arrayItems = new int[3];
      arrayItems[0] = System.Convert.ToInt32(ResourceAInput.text);
      arrayItems[1] = System.Convert.ToInt32(ResourceBInput.text);
      arrayItems[2] = System.Convert.ToInt32(ResourceCInput.text);

      storeController.NewDeliveryToSmallStore(arrayItems);

      CloseMesseage();
   }

   public void AddToBigStore() {
        TeamControllerStore teamController = GameObject.Find("TeamControllerStore").GetComponent<TeamControllerStore>();

        StoreController storeController = GameObject.Find("StoreController").GetComponent<StoreController>();
        TurnController turnController = GameObject.Find("NextTurn").GetComponent<TurnController>();

        InputField ResourceAInput = GameObject.Find("InputResourceA").GetComponent<InputField>();
        InputField ResourceBInput = GameObject.Find("InputResourceB").GetComponent<InputField>();
        InputField ResourceCInput = GameObject.Find("InputResourceC").GetComponent<InputField>();

        Dropdown loseInput = GameObject.Find("LoseInput").GetComponent<Dropdown>();
        List<Dropdown.OptionData> menuOptions = loseInput.GetComponent<Dropdown>().options;
        string value = menuOptions[loseInput.value].text;
        int lose = 0;

        int[] arrayItems = new int[3];
        arrayItems[0] = System.Convert.ToInt32(ResourceAInput.text);
        arrayItems[1] = System.Convert.ToInt32(ResourceBInput.text);
        arrayItems[2] = System.Convert.ToInt32(ResourceCInput.text);

        float allItems = (float) arrayItems[0] + arrayItems[1] + arrayItems[2];


        float teams = 0f;
        int wether = turnController.wetherCount;

        switch (value)
        {
            case "Морской":
                switch (wether)
                {
                    case 0: teams = Mathf.Ceil(allItems / 4); break;
                    case 1: teams = Mathf.Ceil(allItems / 9); break;
                    case 2: teams = Mathf.Ceil(allItems / 6); break;
                }
                
                lose = 1;
                break;

            case "Наземный":
                lose = 0;
                teams = Mathf.Ceil(allItems / 8);
                break;

            case "Воздушный":
                switch (wether)
                {
                    case 0: teams = Mathf.Ceil(allItems / 8); break;
                    case 1: teams = Mathf.Ceil(allItems / 5); break;
                    case 2: teams = Mathf.Ceil(allItems / 2); break;
                }
                lose = 2;
                break;
        }

        Debug.Log(teams);



        if (teamController.openTeams() < teams)
        {
            CloseMesseage();
            OpenMesseage();
            return;
        }


        storeController.NewDeliveryToBigStore(arrayItems, lose, teams);

        CloseMesseage();

        /* OpenMesseage();

        Text resourceDeliveredA = GameObject.Find("ResourceDeliveredA").GetComponent<Text>(); 
        Text resourceDeliveredB = GameObject.Find("ResourceDeliveredB").GetComponent<Text>(); 
        Text resourceDeliveredC = GameObject.Find("ResourceDeliveredC").GetComponent<Text>(); 

        Text resourceDroppedA = GameObject.Find("ResourceDroppedA").GetComponent<Text>(); 
        Text resourceDroppedB = GameObject.Find("ResourceDroppedB").GetComponent<Text>(); 
        Text resourceDroppedC = GameObject.Find("ResourceDroppedC").GetComponent<Text>(); 

        resourceDeliveredA.text += deliveredItems[0].ToString();
        resourceDeliveredB.text += deliveredItems[1].ToString();
        resourceDeliveredC.text += deliveredItems[2].ToString();

        resourceDroppedA.text += (arrayItems[0] - deliveredItems[0]).ToString();
        resourceDroppedB.text += (arrayItems[1] - deliveredItems[1]).ToString();
        resourceDroppedC.text += (arrayItems[2] - deliveredItems[2]).ToString(); */
   }

    public void ShowProject()
    {
        BuildController buildController = GameObject.Find("BuildController").GetComponent<BuildController>();

        buildController.HideBuild();
    }

    public void StartBuild()
    {
        BuildController buildController = GameObject.Find("BuildController").GetComponent<BuildController>();

        buildController.StartBuild();
    }

    public void HireTeam()
    {
        TeamController teamController = GameObject.Find("TeamController").GetComponent<TeamController>();

        teamController.HireTeam();
    }

    public void DismissTeam()
    {
        TeamController teamController = GameObject.Find("TeamController").GetComponent<TeamController>();

        teamController.DismissTeam();
    }

    public void HireTeamStore()
    {
        TeamControllerStore teamController = GameObject.Find("TeamControllerStore").GetComponent<TeamControllerStore>();

        teamController.HireTeam();
    }

    public void DismissTeamStore()
    {
        TeamControllerStore teamController = GameObject.Find("TeamControllerStore").GetComponent<TeamControllerStore>();

        teamController.DismissTeam();
    }

}
