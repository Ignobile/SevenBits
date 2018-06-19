using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dia : MonoBehaviour {


    public CambioPelis cp;
    public Dropdown categ;
    // Use this for initialization

    List<string> dias = new List<string> { "LUNES", "MARTES", "MIERCOLES", "JUEVES", "VIERNES", "SABADO", "DOMINGO" };
    List<string> dias2 = new List<string> { "LUNES", "MARTES", "MIERCOLES", "JUEVES", "VIERNES", "SABADO"};
   
	// Update is called once per frame
	void Update () {
        categ.ClearOptions();
        Categorias();
	}

    void Categorias()
    {
        if (cp.boton1press == true)
        {
            categ.AddOptions(dias);
        }
        else if (cp.boton2press == true)
        {
            categ.AddOptions(dias2);
        }
    }
}
