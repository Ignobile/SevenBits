using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AuthManager : MonoBehaviour {

    email Email;
    Firebase.Auth.FirebaseAuth auth;
    Firebase.Auth.FirebaseUser user;

	// Use this for initialization
	void Start () {

        Email = GetComponent<email>();
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

    public void OnLogIn()
    {
        SceneManager.LoadScene("login");
    }

    public void OnCreateaccountButtonClick()
    {
        TrySignupWithFirebaseAuth(Email.signupEmail.text, Email.signupPass.text, Email.signupConfirmPass.text);
    }
    


    public void TrySignupWithFirebaseAuth(string email, string password, string confirmPass)
    {
        if(password != confirmPass) { Debug.Log("Password and confirm password is not matched"); return; }
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            // Firebase user has been created.
            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);

            SceneManager.LoadScene("login");
        });
    }
    
}
