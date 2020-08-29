using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{

    public int countUnits = 0;
    public GameObject unitPrefab;
    public Sprite builded;
    public int time = -1;


    public void ChangeSprite()
    {
        SpriteRenderer spriteRender = gameObject.GetComponent<SpriteRenderer>();
        spriteRender.sprite = builded;
    }



    public void spawnUnit() {
        if(countUnits > 0) {
            Vector2 unitPos = new Vector2(transform.position.x - 1.5f, transform.position.y);
            Instantiate(unitPrefab, unitPos, Quaternion.identity);
            countUnits--;
        }
    }
}
