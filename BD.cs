using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
public class BD : MonoBehaviour
{

    public static BD Instance;
    private DatabaseReference db;
    DependencyStatus dependencyStatus = DependencyStatus.UnavailableOther;
    ArrayList leaderBoard;


    void Start()
    {

        leaderBoard = new ArrayList();
        leaderBoard.Add("Firebase Top " + MaxScores.ToString() + " Scores");
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                Awake();
                Debug.Log("Se conecto a la Bd");
            }
            else
            {
                Debug.LogError(
                  "Could not resolve all Firebase dependencies: " + dependencyStatus);
            }
        });
        //Metodo que corre cuando la app comienza, revisa si tenemos los requerimientos
        //para usar firebase.

    }

    void Update()
    {

    }
    public void Awake()
    {
        if (Instance == null) Instance = this;

        // Url de la Base de Datos
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://virtualreservation.firebaseio.com/");

        // Rama de la Base de datos donde se trabajara.
        db = FirebaseDatabase.DefaultInstance.GetReference("reservas");


    }
}
  /*  public void StartListener() { 
    FirebaseDatabase.DefaultInstance
      .GetReference("Leaders").OrderByChild("score")
      .ValueChanged += (object sender2, ValueChangedEventArgs e2) => {
      if (e2.DatabaseError != null) {
        Debug.LogError(e2.DatabaseError.Message);
        return;
      }
Debug.Log("Received values for Leaders.");
      string title = leaderBoard[0].ToString();
leaderBoard.Clear();
      leaderBoard.Add(title);
      if (e2.Snapshot != null && e2.Snapshot.ChildrenCount > 0) {
        foreach (var childSnapshot in e2.Snapshot.Children) {
          if (childSnapshot.Child("score") == null
            || childSnapshot.Child("score").Value == null) {
            Debug.LogError("Bad data in sample.  Did you forget to call SetEditorDatabaseUrl with your project id?");
            break;
          } else {
            Debug.Log("Leaders entry : " +
              childSnapshot.Child("email").Value.ToString() + " - " +
              childSnapshot.Child("score").Value.ToString());
            leaderBoard.Insert(1, childSnapshot.Child("score").Value.ToString()
              + "  " + childSnapshot.Child("email").Value.ToString());

                      displayScores.text = "";
                      foreach (string item in leaderBoard)
                      {
                          displayScores.text += "\n" + item;
                      }
                  }
        }
      }
    };
  }
}
*/