using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menureserva : MonoBehaviour
{
    public GameObject objeto;
    public GameObject ReservaMenu;

    public Text texto;

    private Ray pulsacion;
    private RaycastHit colision;

    public static bool paused = false;
    
    void Update()
    {
        
        pulsacion = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(pulsacion, out colision))
         {
            if (colision.collider.gameObject.name == objeto.name && Input.GetKeyDown("joystick button 1"))
            {
                reserva();
            }

            else if (Input.GetKeyDown("joystick button 2"))
            {
                SalirReserva();
            }
        }
    }

    private void reserva()
    {
        ReservaMenu.SetActive(true);
        texto.text = objeto.name;
        Time.timeScale = 0f;
    }
    private void SalirReserva()
    {
        ReservaMenu.SetActive(false);
        Time.timeScale = 1f;
        
    }
}