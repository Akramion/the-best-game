using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float panSpeed = 20f;
    public float panBorderrThickness = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        if(Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderrThickness) {
            if (pos.y < 3) pos.y += panSpeed * Time.deltaTime; ;
            
        }

        if(Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderrThickness) {
            if (pos.x < 100) pos.x += panSpeed * Time.deltaTime;
        }

        if(Input.GetKey("s") || Input.mousePosition.y <= panBorderrThickness - 10) {
            if (pos.y > -10) pos.y -= panSpeed * Time.deltaTime;
        }

        if(Input.GetKey("a") || Input.mousePosition.x <= panBorderrThickness) {
            if (pos.x > -20) pos.x -= panSpeed * Time.deltaTime;

        }


        transform.position = pos;
    }

    // void CameraWidthPosition() {
    //     if(Input.mousePosition.x < 20) {
    //         transform.position -= new Vector3(cameraSpeed, 0, 0);
    //     }

    //     if((Screen.width - 10) < Input.mousePosition.x) {
    //         transform.position += new Vector3(cameraSpeed, 0, 0);
    //     }

    //     if(Input.mousePosition.y < 40) {
    //         transform.position -= new Vector3(0, cameraSpeed, 0);
    //     }

    //     if((Screen.width - 10) < Input.mousePosition.y) {
    //         transform.position += new Vector3(0, cameraSpeed, 0);
    //     }
    // }
}
