using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class email : MonoBehaviour {

    public GameObject loginpanel;
    public GameObject signuppanel;

    public InputField loginEmail;
    public InputField loginPass;

    public InputField signupEmail;
    public InputField signupPass;
    public InputField signupConfirmPass;


	// Use this for initialization
	void Start () {

        ShowLoginPanel();
		
	}
	
	public void ShowLoginPanel()
    {
        ShowPanel(loginpanel);
    }

    public void ShowSignUpPanel()
    {
        ShowPanel(signuppanel);
    }
    

    public void ShowPanel(GameObject panel)
    {
        loginpanel.SetActive(false);
        signuppanel.SetActive(false);

        panel.SetActive(true);
    }
}
