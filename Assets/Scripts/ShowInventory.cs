using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowInventory : MonoBehaviour
{
    public GameObject prefab;
    private ResponseManager responseManager;

    GameObject inventory;

    int count;

    void Start()
    {
        responseManager = GameObject.Find("InventoryData").GetComponent<ResponseManager>();
        count = responseManager.count;
        inventory = GameObject.Find("Inventory");

        ChangeHeightContent();
        CreateElement();

        inventory.SetActive(false);
    }

    public void ChangeHeightContent() {
        RectTransform rt = GameObject.Find("InventoryList").GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2 (rt.sizeDelta.x, 360 * Mathf.Ceil((float) count / 3));
        
    }

    public void CreateElement() {
        int currentcount = 0;

        for(int i = 0; i < Mathf.Ceil((float) count / 3); i++) {
            for(int j = 0; j < 3; j++) {
                if(currentcount == responseManager.responses.Length) break;
                if(String.IsNullOrEmpty(responseManager.responses[currentcount].name) || responseManager.responses[currentcount] == null) {
                    currentcount++;
                    j--;
                    Debug.Log("Break");
                    continue;
                }
                Debug.Log(currentcount);
                GameObject inventoryList = GameObject.Find("InventoryList");
                GameObject linkItem = (GameObject)Instantiate(prefab); 
                linkItem.transform.SetParent(inventoryList.transform, false);

                Vector3 position = linkItem.transform.position;
                position.x += 4.0f * j;
                position.y += 6.8f * -i;
                linkItem.transform.position = position;

                Image image = linkItem.GetComponent<Image>();
                image.sprite = responseManager.responses[currentcount].image.sprite;
                currentcount++;
            }

            if(currentcount > responseManager.responses.Length) break;
        }
    }

    public void ResetInventory() {
        GameObject[] items = GameObject.FindGameObjectsWithTag("InventoryItem");
        for(int i = 0; i < items.Length; i++) {
            Destroy(items[i]);
        }
    }

    public void InventoryOn() {
        inventory.SetActive(true);
        ResetInventory();
        ChangeHeightContent();
        CreateElement();
    }
}
