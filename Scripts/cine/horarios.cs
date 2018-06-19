using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class horarios : MonoBehaviour
{
    public CambioPelis cp;

    public Dropdown horas;
    public Dropdown dia;
    public Dropdown categoria;

    public bool choosed2d;

    List<string> dias = new List<string> {"LUNES", "MARTES", "MIERCOLES", "JUEVES", "VIERNES" };
    List<string> sabado = new List<string> { "SABADO" };
    List<string> domingo = new List<string> { "DOMINGO" };

    List<string> Losincreibles2d = new List<string> { "11:00", "13:35", "16:10", "18:45", "21:20" };
    List<string> Losincreibles2ds = new List<string> { "11:00", "13:35", "16:10", "18:45", "21:20", "00:00" };
    List<string> Losincreibles2dd = new List<string> { "12:40","15:20","17:55", "20:30","23:00" };
    List<string> Losincreibles3d = new List<string> { "11:50", "14:25", "16:55", "19:00", "21:50" };
    List<string> Losincreibles3ds = new List<string> { "11:50", "14:25", "16:55", "19:00", "21:50", "00:30" };
    List<string> Lajungla2d = new List<string> { "11:35", "14:55", "17:20","19:40","22:05" };
    List<string> Lajungla2ds = new List<string> { "11:35", "14:55", "17:20", "19:40", "22:05", "00:30" };
    List<string> nulo = new List<string> { "No hay datos" };

    // Use this for initialization
    void Start()
    {
        horas.ClearOptions();
        elegido3d();
    }

    // Update is called once per frame
    void Update()
    {
        horas.ClearOptions();
        elegido3d();
        Tiempos();
    }

    void Tiempos()
    {

        if (cp.boton1press == true)
        {
            if (dias.Contains(dia.captionText.text))
            {
                if (choosed2d == true)
                {
                    horas.AddOptions(Losincreibles2d);
                }

                else if (choosed2d == false)
                {
                    horas.AddOptions(Losincreibles3d);
                }
            }
            else if (sabado.Contains(dia.captionText.text))
            {
                if (choosed2d == true)
                {
                    horas.AddOptions(Losincreibles2ds);
                }
                else if (choosed2d == false)
                {
                    horas.AddOptions(Losincreibles3ds);
                }
            }

            else if (domingo.Contains(dia.captionText.text))
            {
                if (choosed2d == true)
                {
                    horas.AddOptions(Losincreibles2dd);
                }
                else if (choosed2d == false)
                {
                    horas.AddOptions(nulo);
                }
            }
        }
        else if (cp.boton2press == true)
        {
            if (dias.Contains(dia.captionText.text))
            {
                if (choosed2d == true)
                {
                    horas.AddOptions(Lajungla2d);
                }

                else if (choosed2d == false)
                {
                    horas.AddOptions(nulo);
                }
            }
            else if (sabado.Contains(dia.captionText.text))
            {
                if (choosed2d == true)
                {
                    horas.AddOptions(Lajungla2ds);
                }
                else if (choosed2d == false)
                {
                    horas.AddOptions(nulo);
                }
            }

            else if (domingo.Contains(dia.captionText.text))
            {
                if (choosed2d == true)
                {
                    horas.AddOptions(nulo);
                }
                else if (choosed2d == false)
                {
                    horas.AddOptions(nulo);
                }
            }
        }
    }

   

    void elegido3d()
    {
        if (categoria.captionText.text.Contains("3D"))
        {
            choosed2d = false;
        }
        else if (categoria.captionText.text.Contains("2D"))
        {
            choosed2d = true;
        }
    }
}
