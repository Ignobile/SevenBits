using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    //Este metodo es donde hace el cambio de escenas
    public void SceneChangerDenver()
    {
        SceneManager.LoadScene("Aqui poner nombre de escenario de denver", LoadSceneMode.Single);
    }
    public void SceneChangerPrime()
    {
        SceneManager.LoadScene("Aqui poner nombre de escenario de Prime", LoadSceneMode.Single);
    }
    public void SceneChangerRegistrar()
    {
        SceneManager.LoadScene("Aqui poner nombre de escenario de Registros", LoadSceneMode.Single);
    }
    public void SalirApp()
    {
        Debug.Log("Saliendo...");
        Application.Quit();
    }
}
