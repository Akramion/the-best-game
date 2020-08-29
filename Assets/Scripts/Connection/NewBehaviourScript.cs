using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Json myObject = new Json();
        myObject.level = 1;
        myObject.timeElapsed = 47.5f;
        myObject.playerName = "Dr Charles Francis";

        string json = JsonUtility.ToJson(myObject);

        Debug.Log(json);

        Json test = JsonUtility.FromJson<Json>(json);

        Debug.Log(test);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
