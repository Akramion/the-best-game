using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningController : MonoBehaviour
{
    public void OpenMesseage(GameObject prefab)
    {

        if (gameObject.name == "OpenRequestMoneyPanel")
        {
            Destroy(gameObject);
        }

        GameObject helpPanelDestroy = GameObject.FindWithTag("HelpPanel"); ;
        Destroy(helpPanelDestroy);

        GameObject canvas = GameObject.Find("Canvas");
        GameObject linkInputMesseage = (GameObject)Instantiate(prefab);
        linkInputMesseage.transform.SetParent(canvas.transform, false);
    }

    public void CloseMesseage()
    {
        GameObject panelMesseage = GameObject.FindWithTag("Window");
        Destroy(panelMesseage);

        Data data = GameObject.Find("Data").GetComponent<Data>();
        data.isWindowOpen = false;
    }

    public bool isAllowOpenWindow()
    {
        Data data = GameObject.Find("Data").GetComponent<Data>();
        return data.isWindowOpen;
    }

    public void SetIsAllopenWindow()
    {
        Data data = GameObject.Find("Data").GetComponent<Data>();
        data.isWindowOpen = true;
    }
}
