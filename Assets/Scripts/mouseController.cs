using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseController : MonoBehaviour
{
    private Unit UnitController;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // Выделение юнита
         if(Input.GetMouseButtonDown(0)) {
            
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2d = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2d, Vector2.zero);
            
            if(hit.collider.tag == "Unit") {

                UnitController = hit.collider.gameObject.GetComponent<Unit>();
                UnitController.isSelect = true;
            }


            if(hit.collider.tag == "Build") {
                Debug.Log(hit.collider.tag);
                Build buildComp = hit.collider.GetComponent<Build>();
                buildComp.spawnUnit();
            }

         }
    }
}
