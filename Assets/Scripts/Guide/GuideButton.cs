using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideButton : MonoBehaviour
{
    public GameObject[] slides;
    private int count = 0;

    public void NextSlide()
    {
        if(count == 13)
        {
            return;
        }

        slides[count].SetActive(false);

        count++;
        slides[count].SetActive(true);
    }
}
