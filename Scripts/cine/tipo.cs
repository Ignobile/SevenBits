using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tipo : MonoBehaviour
{


    public CambioPelis cp;
    public Dropdown tip;
    // Use this for initialization

    List<string> op1 = new List<string> { "2D", "3D" };
    List<string> op2 = new List<string> { "2D" };
    

    // Update is called once per frame
    void Update()
    {
        tip.ClearOptions();
        Categorias();
    }

    void Categorias()
    {
        if (cp.boton1press == true)
        {
            tip.AddOptions(op1);
        }
        else if (cp.boton2press == true)
        {
            tip.AddOptions(op2);
        }
    }
}