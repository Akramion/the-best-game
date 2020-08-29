using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deliverys : MonoBehaviour
{
    public Delivery[] deliverysBigStore;

    public Delivery[] deliverysSmallStore;

    StoreController storeController;


   public void Start()
    {
        storeController = GameObject.Find("StoreController").GetComponent<StoreController>();
    }

    public void CheckDeliverys()
    {
        for(int i = 0; i < deliverysBigStore.Length; i++)
        {
            if(deliverysBigStore[i].type != -1)
            {
                deliverysBigStore[i].time -= 1;

                if (deliverysBigStore[i].time == 0)
                {
                    storeController.RestoreSmallToBig(deliverysBigStore[i].resources, deliverysBigStore[i].type);
                    deliverysBigStore[i].type = -1;
                }
            }


        }

        for (int i = 0; i < deliverysSmallStore.Length; i++)
        {
            if (deliverysSmallStore[i].type != -1)
            {
                deliverysSmallStore[i].time -= 1;

                if (deliverysSmallStore[i].time == 0)
                {
                    Debug.Log(deliverysSmallStore[i].time);
                    storeController.AddToSmallStore(deliverysSmallStore[i].resources);
                    deliverysSmallStore[i].type = -1;
                }
            }


        }
    }

    public void AddDeliveryToBigStore(int[] resources, int type)
    {
        for(int i = 0; i < deliverysBigStore.Length; i++)
        {
            if(deliverysBigStore[i].type == -1)
            {
                deliverysBigStore[i].type = type;
                deliverysBigStore[i].resources = resources;

                switch (type)
                {
                    case 0:
                        deliverysBigStore[i].time = 3;
                        break;

                    case 1:
                        deliverysBigStore[i].time = 2;
                        break;
                    case 2:
                        deliverysBigStore[i].time = 1;
                        break;
                }

                break;

                Debug.Log(deliverysBigStore[i]);
            }
        }
    }

    public void AddDeliveryToSmallStore(int[] resources)
    {
        for (int i = 0; i < deliverysSmallStore.Length; i++)
        {
            if (deliverysBigStore[i] != null)
            {
                deliverysSmallStore[i].type = 0;
                deliverysSmallStore[i].resources = resources;
                deliverysSmallStore[i].time = 1;
                Debug.Log(deliverysSmallStore[i].time);
                break;
            }
        }
    }
}
