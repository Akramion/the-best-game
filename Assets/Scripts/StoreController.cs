using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreController : MonoBehaviour
{
    public int[]  smallStore = new int[3];
    public int[]  bigStore = new int[3];


    TeamController teamController;
    ScoreMain scoreController;

    Deliverys deliverys;

    public bool isBlock = false;

    public int[] ShowSmallStore() {
        return smallStore;
    }

    public int[] ShowBigStore() {
        return bigStore;
    }

    private void Start() {
        scoreController = GameObject.Find("Score").GetComponent<ScoreMain>();
        int[] array = new int[3];
        array[0] = 2;
        array[1] = 3;
        array[2] = 10;
        RestoreSmallToBig(array, 1);
        teamController = GameObject.Find("TeamController").GetComponent<TeamController>();
        deliverys = GameObject.Find("Deliverys").GetComponent<Deliverys>();
    }

    public void NewDeliveryToBigStore(int[] store, int loss, float teams)
    {

        for(int i = 0; i < store.Length; i++)
        {
            if (smallStore[i] < store[i]) return;
            smallStore[i] -= store[i];
        }

        teamController.ReserveTeams((int) teams, 1);
        deliverys.AddDeliveryToBigStore(store, loss);

        
        
    }

    public void NewDeliveryToSmallStore(int[] store)
    {
 
            deliverys.AddDeliveryToSmallStore(store);

        
    }



    public void AddToSmallStore(int[] items) {
        if(isBlock == false) {
            for(int i = 0; i < smallStore.Length; i++) {
                smallStore[i] += items[i];
            }
        }

        int score = 0;

        score += items[0] * 1000;
        score += items[1] * 5000;
        score += items[2] * 10000;

        scoreController.ChangeScore(score);
    }

    public int[] RestoreSmallToBig(int[] store, int loss) {
        int[] itemsDelivered = new int[3];
        for(int i = 0; i < smallStore.Length; i++) {

            itemsDelivered[i] = RandomLoss(store[i], loss);
            bigStore[i] += itemsDelivered[i];
            
        }

        return itemsDelivered;
    }

    public int RandomLoss(int item,int loss) {
        switch (loss)
        {
            case 0:
                item -= (int) Random.Range(0, Mathf.Round(item * 0.2f));
                break;

            case 1:
                item -= (int) Random.Range(0, Mathf.Round(item * 0.4f));
                break;
            case 2:
                item -= (int) Random.Range(0, Mathf.Round(item * 0.6f));
                break;
        }

        return item;
    }

    public bool TakeResources(int[] resources)
    {
        for(int i = 0; i < resources.Length; i++)
        {
            if(!(bigStore[i] >= resources[i]))
            {
                return false;
            }
        }

        for (int i = 0; i < resources.Length; i++)
        {
            bigStore[i] -= resources[i];
        }

        return true;

    }
}
