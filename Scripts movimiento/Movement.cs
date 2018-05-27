using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private Transform myTransform;
    //Variable de Transform

    public float speed = 10.0F;
    //Velocidad del personaje
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    // Update is called once per frame
    void Update()
    { /*
        if (Input.GetKey(KeyCode.W))
        {
            myTransform.Translate(new Vector3(0, 0, speed) * Time.deltaTime);
        }
        //Condicion si se pulsa una tecla, que su eje z vaya en negativo

        if (Input.GetKey(KeyCode.S))
        {
            myTransform.Translate(new Vector3(0, 0, -speed) * Time.deltaTime);
        }


        if (Input.GetKey(KeyCode.A))
        {
            myTransform.Translate(new Vector3(-speed, 0, 0) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            myTransform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime);
        }

    }
    */
        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        transform.Translate(straffe, 0, translation);

        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;
    }
}
