using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class ResponseManager : MonoBehaviour
{
    public Response[]  responses;
    public int count = 0;

    private void Awake() {
        DontDestroyOnLoad(this);
    }

    public void AddResponse(string name, Image image) {
        responses[count].name = name;
        responses[count].image = image;
        count++;
    }

    public void DeleteResponse(int count) {
        responses[count].name = null;
        count--;
    }
}