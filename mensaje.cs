using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mensaje : MonoBehaviour {

    public bool Entrar;
    private Rect BoxSize = new Rect(100, 50, 500, 500);
    //modifica las caracteristicas del mensaje que se mostrara
    public GUISkin customSkin;

    //si el sript esta en un objeto, con un collider muestra informacion
    void OnTriggerEnter()
    {
        Entrar = true;
    }
    //sale del trigger, deja de mostrar el mensaje
    void OnTriggerExit()
    {
        Entrar = false;
    }

    void OnGUI()
    {
        if (customSkin != null)
        {
            GUI.skin = customSkin;
        }

        if (Entrar == true)
        {
            //crea un grupo de informacion en el centro de la pantalla
            GUI.BeginGroup(new Rect((Screen.width - BoxSize.width) / 2, (Screen.height - BoxSize.height) / 2, BoxSize.width, BoxSize.height));

            //muestra el mensaje
            GUI.Label(BoxSize, "MENU DENVER                                                                      " +
                               "                                                                                 " +
                               "Entrada:                                                                         " +
                               "Mejillones a la sal    Bs.8                                                      " + 
                               "Tomate huerto          Bs.16                                                     " + 
                               "Pulpo a la brasa       Bs.17                                                     " +
                               "                                                                                 " +               
                               "Plato:                                                                           " +
                               "Arroz de cigalitas     Bs.35                                                     " +
                               "Pescado Cambrills      Bs.40                                                     " +
                               "Arroz con calamares    Bs.30                                                     " +
                               "                                                                                 " +
                               "Postre:                                                                          " +
                               "Tarta de hojaldre      Bs.15                                                     " +
                               "Empiñonat              Bs.10                                                     " +
                               "                                                                                 " +
                               "Bebidas:                                                                         " +
                               "Chop de cerveza        Bs.20                                                     " +
                               "Botella de vino        Bs.30                                                     " +
                               "Botella de champán     Bs.25                                                     ");


            //finaliza el grupo
            GUI.EndGroup();

        }
    }
}