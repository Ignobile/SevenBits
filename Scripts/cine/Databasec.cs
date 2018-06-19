using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Databasec : MonoBehaviour
{


    public Text silla;
    public Dropdown dia;
    public Dropdown categoria;
    public Dropdown hora;


    private string logText;
    private string Dia;
    private string Categoria;
    private string Hora;
    //Inicializacion de Variables




    //Inicializacion de Firebase
    protected virtual void InitializeFirebase()
    {
        FirebaseApp app = FirebaseApp.DefaultInstance;
        //URL de la base de datos actual
        app.SetEditorDatabaseUrl("https://venta-46ce5.firebaseio.com/");
        if (app.Options.DatabaseUrl != null) app.SetEditorDatabaseUrl(app.Options.DatabaseUrl);

    }

    // Output text de la consola
    public void DebugLog(string s)
    {
        Debug.Log(s);
        logText += s + "\n";


    }

    TransactionResult AddRegistro(MutableData mutableData)
    {
        List<object> Restaurant = mutableData.Value as List<object>;

        if (Restaurant == null)
        {
            Restaurant = new List<object>();
        }

        Dictionary<string, object> newRegMap = new Dictionary<string, object>();
        newRegMap["1-Dia"] = Dia;
        newRegMap["2-Tipo"] = Categoria;
        newRegMap["3-Hora"] = Hora;

        Restaurant.Add(newRegMap);
        mutableData.Value = Restaurant;
        return TransactionResult.Success(mutableData);
    }

    //Este metodo Añade a la BD
    public void AddScore()
    {

        Dia = dia.captionText.text;
        Categoria = categoria.captionText.text;
        Hora = hora.captionText.text;



        string camino = "Cine/";
        string nr = silla.text;
        string link = camino + nr;

        DebugLog(String.Format("Registrando Mesa...",
          Dia, Categoria, Hora));

        DatabaseReference reference = FirebaseDatabase.DefaultInstance.GetReference(link);

        DebugLog("Corriendo Transaccion...");

        reference.RunTransaction(AddRegistro)
          .ContinueWith(task =>
          {
              if (task.Exception != null)
              {
                  DebugLog(task.Exception.ToString());
              }
              else if (task.IsCompleted)
              {
                  DebugLog("Transaccion Completa");
              }
          });
    }

}
