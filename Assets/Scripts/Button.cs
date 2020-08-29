using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Sprite butDown, butUp;
    private bool state;

    SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        state = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeSprite() {
        if(state == true) {
            spriteRenderer.sprite = butDown;
            state = false;
        }

        else {
            spriteRenderer.sprite = butUp;
            state = true;
        }
    }
}
