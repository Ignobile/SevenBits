
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class DataBase : MonoBehaviour {

    
    public Text mesa;
    public Dropdown dia;
    public Dropdown mes;
    public Dropdown hora;
    public Dropdown minuto;


    private string logText;
    private string Mes;
    private int Dia;
    private int Hora;
    private int Minuto;
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
        newRegMap["1-Mes"] = Mes;
        newRegMap["2-Dia"] = Dia;
        newRegMap["3-Hora"] = Hora;
        newRegMap["4-Minuto"] = Minuto;
        
        Restaurant.Add(newRegMap);
        mutableData.Value = Restaurant;
        return TransactionResult.Success(mutableData);
    }
    
    //Este metodo Añade a la BD
    public void AddScore()
    {
        
        Mes = mes.captionText.text;
        Dia = Int32.Parse(dia.captionText.text);
        Hora = Int32.Parse(hora.captionText.text);
        Minuto = Int32.Parse(minuto.captionText.text);


        string camino = "Denver/";
        string nr = mesa.text;
        string link = camino + nr;
        
        DebugLog(String.Format("Registrando Mesa...",
          Mes, Dia.ToString(), Hora.ToString(), Minuto.ToString()));

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
