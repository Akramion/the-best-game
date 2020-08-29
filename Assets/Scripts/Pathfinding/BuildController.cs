using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class BuildController : MonoBehaviour
{
    public Build[] builds;
    private GameObject[] buildsGameObjcets;
    private bool isHide = false;
    private TeamController teamController;
    public StoreController storeController;
    public GameObject build;
    public int time = -1;
    public Sprite[] sprites;

    WarningController warningController;
    public GameObject warningResources;
    public GameObject warningTeams;
    public GameObject warningBuildStart;
    public GameObject warningBuildNotEnd;

    public int spriteCount = 0;
    SpriteRenderer spriteRender;


    private void Start()
    {
        warningController = GameObject.Find("WarningController").GetComponent<WarningController>();

        teamController = GameObject.Find("TeamController").GetComponent<TeamController>();
        buildsGameObjcets = GameObject.FindGameObjectsWithTag("Build");
        storeController = GameObject.Find("StoreController").GetComponent<StoreController>();
        build = GameObject.Find("Build");
        spriteRender = build.GetComponent<SpriteRenderer>();

        HideBuild();
    }

    public void CheckBuild()
    {
        if (time == 1)
        {
            spriteCount++;
            spriteRender.sprite = sprites[spriteCount];
            time = -1;
        }

        if(time > 0)
        {
            time--;
        }
    }

    public void StartBuild()
    {
        
        int[] resources = new int[3];

        switch (spriteCount)
        {
            case 0:
                resources[0] = 165;
                resources[1] = 63;
                resources[2] = 0;
                break;
            case 1:
                resources[0] = 77;
                resources[1] = 60;
                resources[2] = 28;
                break;
            case 2:
                resources[0] = 0;
                resources[1] = 4;
                resources[2] = 20;
                break;
            case 3:
                resources[0] = 0;
                resources[1] = 0;
                resources[2] = 4;
                break;
            case 4:
                resources[0] = 0;
                resources[1] = 0;
                resources[2] = 4;
                break;
            case 5:
                resources[0] = 0;
                resources[1] = 0;
                resources[2] = 1;
                break;
        }

        // Warnings
        if (time > 0)
        {
            warningController.OpenMesseage(warningBuildNotEnd);
            return;
        }

        if (resources[0] > storeController.bigStore[0] || resources[1] > storeController.bigStore[1] || resources[2] > storeController.bigStore[2])
        {
            warningController.OpenMesseage(warningResources);
            return;
        }

        if (teamController.openTeams() < 3)
        {
            warningController.OpenMesseage(warningTeams);
            return;
        }



        // End warnings

        if (teamController.ReserveTeams(3, 3) == false)
        {
            return;
        }

        if(storeController.TakeResources(resources) == false)
        {
            return;
        }



        build.SetActive(true);
        time = 3;

        warningController.OpenMesseage(warningBuildStart);


    }

    public void HideBuild()
    {

        if(isHide == true)
        {
            ShowAll();
            isHide = false;
            return;
        }


        
        if(spriteCount == 0 && time == -1)
        {
            build.SetActive(false);
        }


        isHide = true;

        if(spriteCount > -1) spriteRender.sprite = sprites[spriteCount];

        else
        {
            spriteRender.sprite = sprites[0];
        }
    }

    public void ShowAll()
    {

        build.SetActive(true);
        spriteRender.sprite = sprites[5];

    }

   // public void ChangeSprite()
  //  {
   //     SpriteRenderer spriteRender = gameObject.GetComponent<SpriteRenderer>();
   //     spriteRender.sprite = builded;
  //  }
}
