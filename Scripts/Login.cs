using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Facebook.Unity;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour {
    


    List<string> Perms = new List<string>() {"public_profile","email","user_friends" };
	void Awake () {
        FB.Init(InitCompleteCallback, UnityCallbackDelegate);
	}
    
    public void LoginButton()
    {
        if (!FB.IsLoggedIn)
        {
            FB.LogInWithReadPermissions(Perms, LoginCallback);
        }
        else
        {
            SceneManager.LoadScene("menu");
        }
        
    }
    

    #region callback
    private void LoginCallback(IResult result) {

        if(result.Error != null)
        {
            Debug.Log(result.Error);
        }
        else
        {
            if (FB.IsLoggedIn)
            {
                Debug.Log("FB is logged in");
            }
            else
            {
                Debug.Log("FB is not logged in");
            }
       
        }
        }
  
    private void InitCompleteCallback() {
        if (FB.IsInitialized)
        {
            Debug.Log("loguado exitosamente");
        }
        else
        {
            Debug.Log("fallo");
        }
        
    }
    private void UnityCallbackDelegate(bool isUnity)
    {
        if (isUnity)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }
    #endregion


}
