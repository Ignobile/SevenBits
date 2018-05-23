using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Facebook.Unity;

public class Login : MonoBehaviour {

    public GameObject DialogLoggedIn;
    public GameObject DialogLoggedOut;
    public GameObject DialogUsername;
    public GameObject DialogProfilePic;


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
            Debug.Log("El usuario esta logueado");
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

            DealWithFBMenus(FB.IsLoggedIn);
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

        DealWithFBMenus(FB.IsLoggedIn);
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

    void DealWithFBMenus(bool isLoggedIn)
    {
        if (isLoggedIn)
        {
            DialogLoggedIn.SetActive(true);
            DialogLoggedOut.SetActive(false);

            FB.API("/me?fields=first_name", HttpMethod.GET, DisplayUsername);
            FB.API("/me/picture?type=square&height=100&width=100", HttpMethod.GET, DisplayProfilePic);
            
        }
        else
        {
            DialogLoggedIn.SetActive(false);
            DialogLoggedOut.SetActive(true);

        }
    }

    void DisplayUsername(IResult result)  
    {
        Text Username = DialogUsername.GetComponent<Text>();
        if(result.Error == null)
        {
            Username.text = "Hola, " + result.ResultDictionary["first_name"];
        }
        else
        {
            Debug.Log(result.Error);
        }
    }

    void DisplayProfilePic(IGraphResult result)
    {
        if(result.Texture != null)
        {
            Image ProfilePic = DialogProfilePic.GetComponent<Image>();
            ProfilePic.sprite = Sprite.Create(result.Texture, new Rect(0, 0, 100, 100), new Vector2());

        }
    }
    
}
