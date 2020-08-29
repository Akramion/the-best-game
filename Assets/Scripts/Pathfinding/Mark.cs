using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mark : MonoBehaviour
{

    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

// При столкновении уничтожаем метку
    private void OnCollisionEnter2D(Collision2D collision) {
        
        if (collision.collider.tag == "Unit") {
            Destroy(gameObject);
        }
    }
}
