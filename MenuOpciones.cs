using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOpciones : MonoBehaviour {

    public static bool MenuIsOpen = false;
    public GameObject SubMenuUI;

    //Este Metodo se ocupa de abrir el sub menu
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            SubMenuUI.SetActive(true);
            Debug.Log("Key Pressed");
        }
        else if(Input.GetKeyDown(KeyCode.F2))
        {
            SubMenuUI.SetActive(false);
            Debug.Log("Key Pressed");
        }

    }

    //Cambia a la Escnea del Menu Principal
    public void scenechangerMainMenu()
    {
        SceneManager.LoadScene("Menu3D", LoadSceneMode.Single);
    }

    /*void CloseMenu()
    {
        SubMenuUI.SetActive(false);
        MenuIsOpen = false;
    }
    void OpenMenu()
    {
        SubMenuUI.SetActive(true);
        MenuIsOpen = true;
    }*/
}

