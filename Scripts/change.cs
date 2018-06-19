using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class change : MonoBehaviour {

    public GameObject objeto;

    private Ray pulsacion;
    private RaycastHit colision;


    void Update()
    {
        pulsacion = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(pulsacion, out colision))
        {
            if (colision.collider.gameObject.name == objeto.name && Input.GetKeyDown("joystick button 1"))
            {
                SceneManager.LoadScene("menu");

            }
            
        }
    }
}
