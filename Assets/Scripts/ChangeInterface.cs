using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeInterface : MonoBehaviour
{
    public GameObject interfacePrefab;

    public void ChangeInterfaceFunc() {
        GameObject oldInterface = GameObject.FindWithTag("SpecificInterface");
        Destroy(oldInterface);


        GameObject canvas = GameObject.Find("Canvas");
        GameObject linkInterface = (GameObject)Instantiate(interfacePrefab); 
        linkInterface.transform.SetParent(canvas.transform, false);



    }
}
