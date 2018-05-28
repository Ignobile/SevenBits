
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;


public class DatabaseHandler : MonoBehaviour
{
    ArrayList Registros = new ArrayList();
    //Creacion de arraylist para guardar los datos

    public Text scoreText;
    public Text nameText;
    public Text leaderBoardText;

    private string logText = "";
    private string Nombre = "";
    private int NumeroMesa = 24;
    //Inicializacion de Variables

    const int kMaxLogSize = 16382;
    DependencyStatus dependencyStatus = DependencyStatus.UnavailableOther;

    protected virtual void Start()
    {
        Registros.Clear();
        Registros.Add("    Denver Restaurant BD    " + "\n" + "#Mesa : Nombre");
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                InitializeFirebase();
            }
            else
            {
                Debug.LogError(
                  "Could not resolve all Firebase dependencies: " + dependencyStatus);
            }
        });

    }

    //Inicializacion de Firebase
    protected virtual void InitializeFirebase()
    {
        FirebaseApp app = FirebaseApp.DefaultInstance;
    //URL de la base de datos actual
        app.SetEditorDatabaseUrl("https://mesaregistros.firebaseio.com/");
        if (app.Options.DatabaseUrl != null) app.SetEditorDatabaseUrl(app.Options.DatabaseUrl);
        StartListener();
    }

    protected void StartListener()
    {
        FirebaseDatabase.DefaultInstance
          .GetReference("Denver").OrderByChild("Numero Mesa")
          .ValueChanged += (object sender2, ValueChangedEventArgs e2) =>
          {
              if (e2.DatabaseError != null)
              {
                  Debug.LogError(e2.DatabaseError.Message);
                  return;
              }
              Debug.Log("Registro Recivido");
              string title = Registros[0].ToString();
              Registros.Clear();
              Registros.Add(title);
              if (e2.Snapshot != null && e2.Snapshot.ChildrenCount > 0)
              {
                  foreach (var childSnapshot in e2.Snapshot.Children)
                  {
                      if (childSnapshot.Child("Numero Mesa") == null
                    || childSnapshot.Child("Numero Mesa").Value == null)
                      {
                          Debug.LogError("Bad data in sample.  Did you forget to call SetEditorDatabaseUrl with your project id?");
                          break;
                      }
                      else
                      {
                          Debug.Log("Entrada de Registros : " +
                        childSnapshot.Child("Nombre").Value.ToString() + " - " +
                        childSnapshot.Child("Numero Mesa").Value.ToString());
                          Registros.Insert(1, childSnapshot.Child("Numero Mesa").Value.ToString()
                        + "  " + childSnapshot.Child("Nombre").Value.ToString());
                          leaderBoardText.text = "";

                          //actualiza la base de datos
                          foreach(string item in Registros)
                          {
                              leaderBoardText.text += "\n" + item;
                          }
                          
                      }
                  }
              }
          };
    }

    // Output text de la consola
    public void DebugLog(string s)
    {
        Debug.Log(s);
        logText += s + "\n";

        while (logText.Length > kMaxLogSize)
        {
            int index = logText.IndexOf("\n");
            logText = logText.Substring(index + 1);
        }
    }

    TransactionResult AddRegistro(MutableData mutableData)
    {
        List<object> Restaurant = mutableData.Value as List<object>;

        if (Restaurant == null)
        {
            Restaurant = new List<object>();
        }

        Dictionary<string, object> newRegMap = new Dictionary<string, object>();
        newRegMap["Numero Mesa"] = NumeroMesa;
        newRegMap["Nombre"] = Nombre;
        Restaurant.Add(newRegMap);
        mutableData.Value = Restaurant;
        return TransactionResult.Success(mutableData);
    }
    //Este metodo Añade a la BD
    public void AddScore()
    {
        NumeroMesa = Int32.Parse(scoreText.text);
        Nombre = nameText.text;
        if (NumeroMesa == 0 || string.IsNullOrEmpty(Nombre))
        {
            DebugLog("Numero de Mesas invalido o Correo");
            return;
        }
        DebugLog(String.Format("Registrando Mesa...",
          Nombre, NumeroMesa.ToString()));

        DatabaseReference reference = FirebaseDatabase.DefaultInstance.GetReference("Denver");

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