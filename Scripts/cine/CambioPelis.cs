using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CambioPelis : MonoBehaviour {

    public bool boton1press = false;
    public bool boton2press = false;


    public void Boton1()
    {
        boton1press = true;
    }

    public void Boton2()
    {
        boton2press = true;
    }
}
