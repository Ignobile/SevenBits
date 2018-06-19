using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cinereserva : MonoBehaviour
{
    public CambioPelis cp;

    private Ray pulsacion;
    private RaycastHit colision;


    public GameObject objetoc;
    public GameObject nombresilla;
    public GameObject reserva;
    public GameObject peliculas;

    public GameObject camara;

    

    public Text texto;
    public Text texto2;
    

    void Update()
    {

        pulsacion = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(pulsacion, out colision))
        {
            if (colision.collider.gameObject.name == objetoc.name && Input.GetKeyDown("joystick button 1"))
            {
                Camara();
                Reserva();
                
            }

            else if (Input.GetKeyDown("joystick button 2"))
            {
                SalirReserva();
            }
        }
    }

    private void Reserva()
    {
        peliculas.SetActive(true);
        texto.text = nombresilla.name;
        Time.timeScale = 0f;
        if(cp.boton1press == true)
        {
            Peli1();
        }
        else if(cp.boton2press == true)
        {
            Peli2();
        }
    }
    private void SalirReserva()
    {
        reserva.SetActive(false);
        peliculas.SetActive(false);
        camara.SetActive(false);
        cp.boton1press = false;
        cp.boton2press = false;
        Time.timeScale = 1f;

    }
    
    private void Peli1()
    {
        peliculas.SetActive(false);
        reserva.SetActive(true);
        texto2.text = nombresilla.name;
        Time.timeScale = 0f;

    }
    private void Peli2()
    {
        peliculas.SetActive(false);
        reserva.SetActive(true);
        texto2.text = nombresilla.name;
        Time.timeScale = 0f;
    }

    private void Camara()
    {
        camara.SetActive(true);
    }
}
