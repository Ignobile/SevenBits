using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AuthManager2 : MonoBehaviour {

    email2 Email;
    Firebase.Auth.FirebaseAuth auth;
    Firebase.Auth.FirebaseUser user;

	// Use this for initialization
	void Start () {

        Email = GetComponent<email2>();
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        InitializeFirebase();

    }

    private void OnDestroy()
    {
        auth.StateChanged -= AuthStateChanged;
    }

    void InitializeFirebase()
    {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        auth.StateChanged += AuthStateChanged;
        AuthStateChanged(this, null);
    }

    void AuthStateChanged(object sender, System.EventArgs eventArgs)
    {
        if (auth.CurrentUser != user)
        {
            bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;
            if (!signedIn && user != null)
            {
                Debug.Log("Signed out " + user.UserId);
            }
            user = auth.CurrentUser;
            if (signedIn)
            {
                Debug.Log("Signed in " + user.UserId);
            }
        }
    }

    public void OnLogInButtonClick()
    {
        TryLoginWithFirebaseAuth(Email.loginEmail.text, Email.loginPass.text);
    }
    

    public void TryLoginWithFirebaseAuth(string email, string password)
    {
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }
            else if (task.IsCompleted)
            {
                SceneManager.LoadScene("menu");
            }
            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
            
            

        });
    }

    public void Registrarse()
    {
        SceneManager.LoadScene("registrarse");
    }
    
}
