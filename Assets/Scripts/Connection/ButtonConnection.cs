using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonConnection : MonoBehaviour
{

   public void ButtonDown()
    {
        Button yourButton = gameObject.GetComponent<Button>();
        Debug.Log(yourButton);
    }
}
